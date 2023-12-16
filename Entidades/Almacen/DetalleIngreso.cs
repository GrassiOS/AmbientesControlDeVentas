/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_DetalleIngreso.cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
	public class E_DetalleIngreso
	{
		#region Constructor
		public E_DetalleIngreso()
		{
			Accion = string.Empty;
			IdDetalleIngreso = 0;
			IdIngreso = 0;
			IdArticulo = 0;
			Cantidad = 0;
			Precio = 0;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get; set; }
		public int IdDetalleIngreso { get; set; }
		public int IdIngreso { get; set; }
		public int IdArticulo { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		#endregion
	}
}

