/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Usuarios.cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
	public class E_Usuarios
	{
		#region Constructor
		public E_Usuarios()
		{
			Accion = string.Empty;
			IdUsuario = 0;
			IdRol = 0;
			NombreUsuario = string.Empty;
			TipoDocumento = string.Empty;
			NumeroDocumento = string.Empty;
			Direccion = string.Empty;
			Telefono = string.Empty;
			Email = string.Empty;
			PasswordHash = string.Empty;
			PasswordSalt = string.Empty;
			Estado = false;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get; set; }
		public int IdUsuario { get; set; }
		public int IdRol { get; set; }
		public string NombreUsuario { get; set; }
		public string TipoDocumento { get; set; }
		public string NumeroDocumento { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }
		public Boolean Estado { get; set; }
		#endregion
	}

    public class SeleccionaUsuario
    {
        public SeleccionaUsuario()
        {
            IdUsuario = 0;
            NombreUsuario = string.Empty;
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
    }
}

