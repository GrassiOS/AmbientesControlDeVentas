using DatosSQL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

using DatosSQL;
using Entidades;

namespace Negocios.Usuarios
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class N_Persona
    {
        readonly ComandosSQL DatosSql = new ComandosSQL("ConexionBD");

        // Listado generales de la clase Personas en formato DataTable y List<E_Personas>.
        public DataTable DT_LstPersonas() => DatosSql.Listado("Personas", "NombrePersona");
        public List<E_Persona> ListadoPersonas() => DatosSql.ConvertirDTALista<E_Persona>(DT_LstPersonas());

        // Acciones de Insertar, Borrar y Modificar los datos de la clase Personas.
        public string InsertaPersonas(E_Persona Persona)
        {
            Persona.Accion = "INSERTAR";

            int R = DatosSql.IBM_Entidad<E_Persona>("IBM_Personas", Persona);

            if (R > 0)
                return "Exito: Los datos de la categoría " + Persona.NombrePersona + " fueron insertados correctamente.";
            else
                return "Error: Los datos de la categoría " + Persona.NombrePersona + " no se insertaron en el sistema.";
        }

        public string BorraPersonas(int IdPersonas)
        {
            E_Persona Persona = new E_Persona
            {
                Accion = "BORRAR",
                IdPersona = IdPersonas
            };

            int R = DatosSql.IBM_Entidad<E_Persona>("IBM_Personas", Persona);

            if (R > 0)
                return "Exito: Los datos de la categoría " + Persona.NombrePersona + " fueron borrados correctamente.";
            else
                return "Error: Los datos de la categoría " + Persona.NombrePersona + " no se borraron del sistema.";
        }

        public string ModificaPersonas(E_Persona Persona)
        {
            Persona.Accion = "MODIFICAR";

            int R = DatosSql.IBM_Entidad<E_Persona>("IBM_Personas", Persona);

            if (R > 0)
                return "Exito: Los datos de la categoría " + Persona.NombrePersona + " fueron modificados correctamente.";
            else
                return "Error: Los datos de la categoría " + Persona.NombrePersona + " no se modificaron en el sistema.";
        }

        // Búsquedas de la clase Personas por diferentes criterios
        public E_Persona BuscaPersonasPorId(int IdPersona) =>
            (from Personas in ListadoPersonas() where Personas.IdPersona == IdPersona select Personas).FirstOrDefault();

        public List<E_Persona> LIstaPersonaPorCriterio(string criterio) =>
            (from Personas in ListadoPersonas() where Personas.NombrePersona.Contains(criterio) select Personas).ToList();

       public List<SeleccionaPersona> SeleccionaPersonas()
        {
            List<E_Persona> Listado = ListadoPersonas();
            List<SeleccionaPersona> Lista = new List<SeleccionaPersona>();

            foreach (E_Persona c in Listado)
            {
                
                    SeleccionaPersona cat = new SeleccionaPersona
                    {
                        IdPersona = c.IdPersona,
                        NombrePersona = c.NombrePersona
                    };
                    Lista.Add(cat);
                
            }

            return Lista;
        }

        /*public bool ActivaPersona(int IdPersona)
        {
            E_Persona Persona = BuscaPersonasPorId(IdPersona);

            Persona.Accion = "MODIFICAR";
            Persona.Estado = true;

            ModificaPersonas(Persona);
            return Persona.Estado;
        }

        public bool DesactivarPersona(int IdPersona)
        {
            E_Persona Persona = BuscaPersonasPorId(IdPersona);

            Persona.Accion = "MODIFICAR";
            Persona.Estado = false;

            ModificaPersonas(Persona);
            return Persona.Estado;
        }*/

        public bool ExistePersona(int IdPersona) => ListadoPersonas().Exists(c => c.IdPersona == IdPersona);
    }

}
