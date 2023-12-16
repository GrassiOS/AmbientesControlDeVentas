/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Ingresos.cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
	public class E_Ingresos
	{
		#region Constructor
		public E_Ingresos()
		{
			Accion = string.Empty;
			IdIngreso = 0;
			IdPersona = 0;
			IdUsuario = 0;
			TipoComprobante = string.Empty;
			SerieComprobante = string.Empty;
			NumeroComprobante = string.Empty;
			FechaHoraComprobante = Convert.ToDateTime(DateTime.Now);
			Impuestos = 0;
			Total = 0;
			Estado = false;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get; set; }
		public int IdIngreso { get; set; }
		public int IdPersona { get; set; }
		public int IdUsuario { get; set; }
		public string TipoComprobante { get; set; }
		public string SerieComprobante { get; set; }
		public string NumeroComprobante { get; set; }
		public DateTime? FechaHoraComprobante { get; set; }
		public decimal Impuestos { get; set; }
		public decimal Total { get; set; }
		public Boolean Estado { get; set; }
		#endregion
	}
}

