using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;
using Negocios.Almacen;

namespace Presentacion
{
  public partial class Inicio : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      N_Articulos NA = new N_Articulos();

      LblTitulo.Text = "Listado de Articulos";
      var A = NA.BuscaArticulosPorId(2);

      GrvCategorías.DataSource = NA.ListadoArticulos();
      GrvCategorías.DataBind();
    }
  }
}