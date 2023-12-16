using DatosSQL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Usuarios
{
    public class N_Rol
    {
        readonly ComandosSQL DatosSql = new ComandosSQL("ConexionBD");

        // Listado generales de la clase Roles en formato DataTable y List<E_Roleses>.
        public DataTable DT_LstRoles() => DatosSql.Listado("Roles", "NombreRol");
        public List<E_Roles> ListadoRoles() => DatosSql.ConvertirDTALista<E_Roles>(DT_LstRoles());

        // Acciones de Insertar, Borrar y Modificar los datos de la clase Roles.
        public string InsertaRoles(E_Roles Rol)
        {
            Rol.Accion = "INSERTAR";

            int R = DatosSql.IBM_Entidad<E_Roles>("IBM_Roles", Rol);

            if (R > 0)
                return "Exito: Los datos de la rol " + Rol.NombreRol + " fueron insertados correctamente.";
            else
                return "Error: Los datos de la rol " + Rol.NombreRol + "  no se insertaron en el sistema.";
        }
        public string BorraRoles(int IdRoles)
        {
            E_Roles Rol = new E_Roles
            {
                Accion = "BORRAR",
                IdRol = IdRoles
            };

            int R = DatosSql.IBM_Entidad<E_Roles>("IBM_Roles", Rol);

            if (R > 0)
                return "Exito: Los datos de la rol " + Rol.NombreRol + " fueron borrados correctamente.";
            else
                return "Error: Los datos de la rol " + Rol.NombreRol + " no se borraron del sistema.";
        }
        public string ModificaRoles(E_Roles Rol)
        {
            Rol.Accion = "MODIFICAR";

            int R = DatosSql.IBM_Entidad<E_Roles>("IBM_Roles", Rol);

            if (R > 0)
                return "Exito: Los datos de la rol " + Rol.NombreRol + " fueron modificado correctamente.";
            else
                return "Error: Los datos de la rol " + Rol.NombreRol + " no se modificaron en el sistema.";
        }

        // Busquedas de la claseRoles por diferente Criterios
        public E_Roles BuscaRolesPorId(int IdRol)
        {
            return (from Roles in ListadoRoles() where Roles.IdRol == IdRol select Roles).FirstOrDefault();
        }
        public List<E_Roles> LIstaRolPorCriterio(string criterio)
        {
            return (from Roles in ListadoRoles() where Roles.NombreRol.Contains(criterio) select Roles).ToList();
        }
        public List<SeleccionaRol> SeleccionaRoles()
        {
            List<E_Roles> Listado = ListadoRoles();
            List<SeleccionaRol> Lista = new List<SeleccionaRol>();

            foreach (E_Roles c in Listado)
            {
                if (c.Estado == true)
                {
                    SeleccionaRol cat = new SeleccionaRol
                    {
                        IdRol = c.IdRol,
                        NombreRol = c.NombreRol
                    };
                    Lista.Add(cat);
                }
            }

            return Lista;
        }
        public bool ActivaRol(int IdRol)
        {
            E_Roles Rol = BuscaRolesPorId(IdRol);

            Rol.Accion = "MODIFICAR";
            Rol.Estado = true;

            ModificaRoles(Rol);
            return Rol.Estado;
        }
        public bool DesactivarRol(int IdRol)
        {
            E_Roles Rol = BuscaRolesPorId(IdRol);

            Rol.Accion = "MODIFICAR";
            Rol.Estado = false;

            ModificaRoles(Rol);
            return Rol.Estado;
        }
        public bool ExisteRol(int IdRol) => ListadoRoles().Exists(c => c.IdRol == IdRol);
    }
}
