/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: .cs
* Fecha de creación: 10/25/2023
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System.Data;
using System.Linq;
using System.Collections.Generic;

using DatosSQL;
using Entidades;


namespace Negocios
{
  public class N_Categoria
  {
    readonly ComandosSQL DatosSql = new ComandosSQL("ConexionBD");

    // Listado generales de la clase Categorias en formato DataTable y List<E_Categorias>.
    public DataTable DT_LstCategorias() => DatosSql.Listado("Categorias", "NombreCategoria");
    public List<E_Categoria> ListadoCategorias() => DatosSql.ConvertirDTALista<E_Categoria>(DT_LstCategorias());

    // Acciones de Insertar, Borrar y Modificar los datos de la clase Categorias.
    public string InsertaCategorias(E_Categoria categoria)
    {
      categoria.Accion = "INSERTAR";

      int R = DatosSql.IBM_Entidad<E_Categoria>("IBM_Categorias", categoria);

      if (R > 0)
        return "Exito: Los datos de la categoría " + categoria.NombreCategoria + " fueron insertados correctamente.";
      else
        return "Error: Los datos de la categoría " + categoria.NombreCategoria + "  no se insertaron en el sistema.";
    }
    public string BorraCategorias(int IdCategorias)
    {
      E_Categoria categoria = new E_Categoria
      {
        Accion = "BORRAR",
        IdCategoria = IdCategorias
      };

      int R = DatosSql.IBM_Entidad<E_Categoria>("IBM_Categorias", categoria);

      if (R > 0)
        return "Exito: Los datos de la categoría " + categoria.NombreCategoria + " fueron borrados correctamente.";
      else
        return "Error: Los datos de la categoría " + categoria.NombreCategoria + " no se borraron del sistema.";
    }
    public string ModificaCategorias(E_Categoria categoria)
    {
      categoria.Accion = "MODIFICAR";

      int R = DatosSql.IBM_Entidad<E_Categoria>("IBM_Categorias", categoria);

      if (R > 0)
        return "Exito: Los datos de la categoría " + categoria.NombreCategoria + " fueron modificado correctamente.";
      else
        return "Error: Los datos de la categoría " + categoria.NombreCategoria + " no se modificaron en el sistema.";
    }

    // Busquedas de la claseCategorias por diferente Criterios
    public E_Categoria BuscaCategoriasPorId(int IdCategoria)
    {
      return (from Categorias in ListadoCategorias() where Categorias.IdCategoria == IdCategoria select Categorias).FirstOrDefault();
    }
    public List<E_Categoria> LIstaCategoriaPorCriterio(string criterio)
    {
      return (from Categorias in ListadoCategorias() where Categorias.NombreCategoria.Contains(criterio) select Categorias).ToList();
    }
    public List<SeleccionaCategoria> SeleccionaCategorias()
    {
      List<E_Categoria> Listado = ListadoCategorias();
      List<SeleccionaCategoria> Lista = new List<SeleccionaCategoria>();

      foreach(E_Categoria c in  Listado)
      {
        if (c.Estado == true)
        {
          SeleccionaCategoria cat = new SeleccionaCategoria
          {
            IdCategoria = c.IdCategoria,
            NombreCategoria = c.NombreCategoria
          };
          Lista.Add(cat);
        }        
      }
      
      return Lista;
    }    
    public bool ActivaCategoria(int IdCategoria)
    {
      E_Categoria categoria = BuscaCategoriasPorId(IdCategoria);

      categoria.Accion = "MODIFICAR";
      categoria.Estado = true;

      ModificaCategorias(categoria);
      return categoria.Estado;
    }
    public bool DesactivarCategoria(int IdCategoria)
    {
      E_Categoria categoria = BuscaCategoriasPorId(IdCategoria);

      categoria.Accion = "MODIFICAR";
      categoria.Estado = false;

      ModificaCategorias(categoria);
      return categoria.Estado;
    }
    public bool ExisteCategoria(int IdCategoria) => ListadoCategorias().Exists(c => c.IdCategoria == IdCategoria);
  }
}