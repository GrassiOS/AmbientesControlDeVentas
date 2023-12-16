using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;

using Negocios;
namespace Presentacion.WebService
{
  /// <summary>
  /// Summary description for WS_Categoria
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class WS_Categoria : System.Web.Services.WebService
  {
    readonly N_Categoria NC = new N_Categoria();

    [WebMethod]
    public List<E_Categoria> ListadoCategorias() => NC.ListadoCategorias();

    //INSERTAR, BORRAR Y MODIFICAR
    [WebMethod]
    public string InsertaCategorias(E_Categoria categoria) => NC.InsertaCategorias(categoria);
    [WebMethod]
    public string BorraCategorias(int IdCategorias) =>NC.BorraCategorias(IdCategorias);
    [WebMethod]
    public string ModificaCategorias(E_Categoria categoria) => NC.ModificaCategorias(categoria);        
    [WebMethod]
    public List<SeleccionaCategoria> SeleccionaCategorias() => NC.SeleccionaCategorias();
    [WebMethod]
    public E_Categoria BuscaCategoriasPorId(int IdCategoria) => NC.BuscaCategoriasPorId(IdCategoria);
    [WebMethod]
    public bool ActivaCategoria(int IdCategoria) => NC.ActivaCategoria(IdCategoria);
    [WebMethod]
    public bool DesactivarCategoria(int IdCategoria) => NC.ActivaCategoria(IdCategoria);
    [WebMethod]
    public bool ExisteCategoria(int IdCategoria) => NC.ExisteCategoria(IdCategoria);
  }
}
