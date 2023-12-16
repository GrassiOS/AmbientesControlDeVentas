using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.PaginasMaestras
{
  public partial class MP_Entidades : System.Web.UI.MasterPage
  {
    private string Color;    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AtributosModal(string Tipo)
    {
      switch (Tipo)
      {
        case "Exito": Color = "bg-success"; break;
        case "Error": Color = "bg-danger"; break;
        case "Informacion": Color = "bg-info"; break;
        case "Precaucion": Color = "bg-warning"; break;
        default: Color = "bg-dark"; break;
      }
    }
    public void PonMensaje(string pMsg)
    {
      String[] TipoMsg = pMsg.Split(':');
      AtributosModal(TipoMsg[0]);
      ModalHeader.Attributes.Clear();
      ModalHeader.Attributes.Add("class", Color);
      if (TipoMsg[0].Contains("Informacion"))
        TipoMsg[0] = "Información";
      if (TipoMsg[0].Contains("Precaucion"))
        TipoMsg[0] = "Precaución";
      ModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
      ModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
      BtnEntendido.Attributes.Clear();
      BtnEntendido.Attributes.Add("class", Color);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalMensaje();", true);
    }
  }
}