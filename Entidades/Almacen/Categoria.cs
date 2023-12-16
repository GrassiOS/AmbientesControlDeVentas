/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Categorias.cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
  public class E_Categoria
  {
    #region Constructor
    public E_Categoria()
    {
      Accion = string.Empty;
      IdCategoria = 0;
      NombreCategoria = string.Empty;
      DescripcionCategoria = string.Empty;
      Estado = false;
    }
    #endregion

    #region Encapsulamiento
    public string Accion { get; set; }
    public int IdCategoria { get; set; }
    public string NombreCategoria { get; set; }
    public string DescripcionCategoria { get; set; }
    public Boolean Estado { get; set; }
    #endregion
  }

  public class SeleccionaCategoria
  {
    public SeleccionaCategoria()
    {
      IdCategoria = 0;
      NombreCategoria = string.Empty;
    }

    public int IdCategoria { get; set; }
    public string NombreCategoria { get; set; } = string.Empty;
  }
}

