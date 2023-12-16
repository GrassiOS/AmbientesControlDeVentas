/*************************************************************************************
* Autor: M.I. Víctor Rafael Nazario Velázquez Mejía
* Proyecto: Sistema para el control de centas
* Archivo: Articulo.cs
* Fecha de creación: 10/25/2023
* Propósito: Clase de Artítulos
* D.R. Ingeniero en Software y Tecnologías Emergentes (ISyTE)
****************************************************************************************/

using System;

namespace Entidades
{
	public class E_Articulo
	{
		#region Constructor
		public E_Articulo()
		{
			Accion = string.Empty;
			IdArticulo = 0;
			IdCategoria = 0;
			CodigoArticulo = string.Empty;
			NombreArticulo = string.Empty;
			PrecioVenta = 0;
			Stock = 0;
			DescripcionArticulo = string.Empty;
			Estado = false;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get; set; }
		public int IdArticulo { get; set; }
		public int IdCategoria { get; set; }
		public string CodigoArticulo { get; set; }
		public string NombreArticulo { get; set; }
		public decimal PrecioVenta { get; set; }
		public int Stock { get; set; }
		public string DescripcionArticulo { get; set; }
		public Boolean Estado { get; set; }
		#endregion
	}
}