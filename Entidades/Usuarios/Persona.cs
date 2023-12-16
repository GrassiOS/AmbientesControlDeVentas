/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Personas.cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_Persona
    {
        #region Constructor
        public E_Persona()
        {
            Accion = string.Empty;
            IdPersona = 0;
            TipoPersona = string.Empty;
            NombrePersona = string.Empty;
            TipoDocumento = string.Empty;
            NumeroDocumento = string.Empty;
            DireccionPersona = string.Empty;
            TelefonoPersona = string.Empty;
            EmailPersona = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get; set; }
        public int IdPersona { get; set; }
        public string TipoPersona { get; set; }
        public string NombrePersona { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DireccionPersona { get; set; }
        public string TelefonoPersona { get; set; }
        public string EmailPersona { get; set; }
        #endregion
    }

    public class SeleccionaPersona
    {
        public SeleccionaPersona()
        {
            IdPersona = 0;
            NombrePersona = string.Empty;
        }

        public int IdPersona { get; set; }
        public string NombrePersona { get; set; } = string.Empty;
    }
}

