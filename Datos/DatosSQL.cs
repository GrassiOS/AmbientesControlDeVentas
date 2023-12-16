using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Datos
{
  public class SQLDatos
  {
    public SqlConnection Conexion;
    public static string NombreDelServidor => ConfigurationManager.ConnectionStrings["ConexionBD"].ProviderName;
    public static string CadenaDeConexion => ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
    public static DbProviderFactory ProveedorDB => DbProviderFactories.GetFactory(NombreDelServidor);

    public SQLDatos()
    {
      Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString);
    }

    private static int ExecuteNonQuery(string StoreProcedure, List<DbParameter> Parametros)
    {
      int RegistrosAfectados = 0;
      try
      {
        using (DbConnection Con = ProveedorDB.CreateConnection())
        {
          Con.ConnectionString = CadenaDeConexion;

          using (DbCommand cmd = ProveedorDB.CreateCommand())
          {
            cmd.Connection = Con;
            cmd.CommandText = StoreProcedure;
            cmd.CommandType = CommandType.StoredProcedure;

            if (Parametros != null)
            {

              foreach (DbParameter Param in Parametros)
              {
                cmd.Parameters.Add(Param);
              }
            }

            Con.Open();
            RegistrosAfectados = cmd.ExecuteNonQuery();
            Con.Close();
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Ocurrió algún error al tratar de ejecutar el procedimiento almacenado.", ex);
      }
      return RegistrosAfectados;
    }

    private static List<TSource> ExecuteReader<TSource>(string StoreProcedure, List<DbParameter> Parametros) where TSource : new()
    {
      var Lista = new List<TSource>();
      try
      {
        using (DbConnection Con = ProveedorDB.CreateConnection())
        {
          Con.ConnectionString = CadenaDeConexion;
          using (DbCommand cmd = ProveedorDB.CreateCommand())
          {
            cmd.Connection = Con;
            cmd.CommandText = StoreProcedure;
            cmd.CommandType = CommandType.StoredProcedure;

            if (Parametros != null)
            {
              foreach (DbParameter param in Parametros)       // Se agregan al objeto cmd la lista de parámetros recibido en Parámetros, misma que será  
                cmd.Parameters.Add(param);                  // enviada al Procedimiento Almacenado.
            }

            Con.Open();                                     // Se abre la conexión.
            using (DbDataReader DR = cmd.ExecuteReader())
            {
              while (DR.Read())
              {
                var Data = new TSource();
                PropertyInfo[] Properties = Data.GetType().GetProperties();
                foreach (var p in Properties)
                {
                  p.SetValue(Data, DR.GetValue(DR.GetOrdinal(p.Name)), null);
                }
                Lista.Add(Data);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Ocurrió algún error al tratar de ejecutar el procedimiento almacenado.", ex);
      }

      return Lista;
    }
  }
}
