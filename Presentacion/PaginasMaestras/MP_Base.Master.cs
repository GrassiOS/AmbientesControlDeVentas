using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.PaginasMaestras
{
  public partial class MP_Base : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      lblNombreSistema.Text = "Sistema de Control de Ventas";
    }
  }
}