/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Roles.cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
	public class E_Roles
	{
		#region Constructor
		public E_Roles()
		{
			Accion = string.Empty;
			IdRol = 0;
			NombreRol = string.Empty;
			DescripcionRol = string.Empty;
			Estado = false;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get; set; }
		public int IdRol { get; set; }
		public string NombreRol { get; set; }
		public string DescripcionRol { get; set; }
		public Boolean Estado { get; set; }
		#endregion
	}

    public class SeleccionaRol
    {
        public SeleccionaRol()
        {
            IdRol = 0;
            NombreRol = string.Empty;
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;
    }
}

