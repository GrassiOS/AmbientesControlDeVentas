/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_DetalleVentas.cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
	public class E_DetalleVentas
	{
		#region Constructor
		public E_DetalleVentas()
		{
			Accion = string.Empty;
			IdDetalleVentas = 0;
			IdVenta = 0;
			IdArticulo = 0;
			Cantidad = 0;
			Descuento = 0;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get; set; }
		public int IdDetalleVentas { get; set; }
		public int IdVenta { get; set; }
		public int IdArticulo { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Descuento { get; set; }
		#endregion
	}
}

