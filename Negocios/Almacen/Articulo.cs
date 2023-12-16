using System.Collections.Generic;
using System.Data;
using System.Linq;

using DatosSQL;
using Entidades;

namespace Negocios.Almacen
{
    public class N_Articulos
    {
        readonly ComandosSQL DatosSql = new ComandosSQL("ConexionBD");

        // Listado generales de la clase Articulos en formato DataTable y List<E_Articulos>.
        public DataTable DT_LstArticulos() => DatosSql.Listado("Articulos", "NombreArticulo");
        public List<E_Articulo> ListadoArticulos() => DatosSql.ConvertirDTALista<E_Articulo>(DT_LstArticulos());

        // Acciones de Insertar, Borrar y Modificar los datos de la clase Articulos.
        public string InsertaArticulo(E_Articulo articulo)
        {
            articulo.Accion = "INSERTAR";

            int R = DatosSql.IBM_Entidad<E_Articulo>("IBM_Articulos", articulo);

            if (R > 0)
                return "Exito: Los datos del artículo " + articulo.NombreArticulo + " fueron insertados correctamente.";
            else
                return "Error: Los datos del artículo " + articulo.NombreArticulo + " no se insertaron en el sistema.";
        }
        public string BorraArticulo(int IdArticulos)
        {
            E_Articulo articulo = new E_Articulo
            {
                Accion = "BORRAR",
                IdArticulo = IdArticulos
            };

            int R = DatosSql.IBM_Entidad<E_Articulo>("IBM_Articulos", articulo);

            if (R > 0)
                return "Exito: Los datos del articulo " + articulo.NombreArticulo + " de fueron borrados correctamente.";
            else
                return "Error: Los datos  del artículo" + articulo.NombreArticulo + " no se borraron del sistema.";
        }
        public string ModificaArticulo(E_Articulo articulo)
        {
            articulo.Accion = "MODIFICAR";

            int R = DatosSql.IBM_Entidad<E_Articulo>("IBM_Articulos", articulo);

            if (R > 0)
                return "Exito: Los datos del articulo " + articulo.NombreArticulo + " fueron modificado correctamente.";
            else
                return "Error: Los datos del articulo " + articulo.NombreArticulo + " no se modificaron en el sistema.";
        }
        
        public List<E_Articulo> LIstaArticulosPorCriterio(string criterio)
        {
            return (from Articulos in ListadoArticulos() where Articulos.NombreArticulo.Contains(criterio) select Articulos).ToList();
        }
        


        // Busquedas de la claseArticulos por diferente Criterios
        public E_Articulo BuscaArticulosPorId(int IdArticulo) => (from Articulos in ListadoArticulos() where Articulos.IdArticulo == IdArticulo select Articulos).FirstOrDefault();
    }
}
