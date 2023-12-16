using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;
using Negocios.Usuarios;

namespace Presentacion.Vistas.Persona
{
    public partial class Persona : System.Web.UI.Page
    {
        readonly N_Persona NC = new N_Persona();
        private string Color;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializaControles();
                VisualizaGrvPersonas(NC.ListadoPersonas());
            }
        }

        #region Métodos generales
        protected void InicializaControles()
        {
            lblAccion.Text = string.Empty;

            ControlesOFF();
            ControlesClear();
            ControlesOnOff(true);
        }
        protected void ControlesOFF()
        {
            PnlGrvPersonas.Visible = false;
            PnlCapturaPersonas.Visible = false;

            #region Botones de acciones (IBM)
            BtnMnuNuevo.Visible = true;
            BtnBusca.Visible = true;

            BtnInserta.Visible = false;
            BtnBorra.Visible = false;
            BtnModifica.Visible = false;
            BtnCancela.Visible = false;

            BtnMnuBorra.Visible = false;     //Botón Borrar después de realizar una acción de búsqueda.
            BtnMnuModifica.Visible = false;  //Botón Borrar después de realizar una acción de búsqueda.
            #endregion
        }
        protected void ControlesClear()
        {
            tbNombrePersona.Text = string.Empty;
            tbTipoPersona.Text = string.Empty;
            tbTipoDocumento.Text = string.Empty;
            tbNumeroDocumento.Text = string.Empty;
            tbDireccionPersona.Text = string.Empty;
            tbTelefonoPersona.Text = string.Empty;
            tbEmailPersona.Text = string.Empty;
            
        }

        protected void ControlesOnOff(bool TrueOrFalse)
        {
            tbNombrePersona.Enabled = TrueOrFalse;
            tbTipoPersona.Enabled = TrueOrFalse;
            tbTipoDocumento.Enabled = TrueOrFalse;
            tbNumeroDocumento.Enabled = TrueOrFalse;
            tbDireccionPersona.Enabled = TrueOrFalse;
            tbTelefonoPersona.Enabled = TrueOrFalse;
            tbEmailPersona.Enabled = TrueOrFalse;
           
        }

        protected void AtributosHeaderCard(string Msg, string Color)
        {
            ControlesOFF();
            CardHeader.Attributes.Clear();
            CardHeader.Attributes.Add("class", "card-header text-center " + Color);
            lblAccion.Text = Msg;
        }


        #endregion

        #region Objeto_Entidades
        protected E_Persona Controles_ObjetoPersona()
        {
            E_Persona Persona = new E_Persona
            {
                NombrePersona = tbNombrePersona.Text.Trim(),
                TipoPersona = tbTipoPersona.Text.Trim(),
                TipoDocumento = tbTipoDocumento.Text.Trim(),
                NumeroDocumento = tbNumeroDocumento.Text.Trim(),
                DireccionPersona = tbDireccionPersona.Text.Trim(),
                TelefonoPersona = tbTelefonoPersona.Text.Trim(),
                EmailPersona = tbEmailPersona.Text.Trim()
            };

            return Persona;
        }
        protected void ObjetoPersona_Controles(int idPersona)
        {
            E_Persona Persona = NC.BuscaPersonasPorId(idPersona);
            if (Persona != null)
            {
                tbNombrePersona.Text = Persona.NombrePersona;
                tbTipoPersona.Text = Persona.TipoPersona;
                tbTipoDocumento.Text = Persona.TipoDocumento;
                tbNumeroDocumento.Text = Persona.NumeroDocumento;
                tbDireccionPersona.Text = Persona.DireccionPersona;
                tbTelefonoPersona.Text = Persona.TelefonoPersona;
                tbEmailPersona.Text = Persona.EmailPersona;

            }
        }

        protected void VisualizaGrvPersonas(List<E_Persona> Personas)
        {
            GrvPersonas.DataSource = Personas;
            GrvPersonas.DataBind();
            PnlGrvPersonas.Visible = true;
        }
        #endregion
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            AtributosHeaderCard("Registro de una nueva persona", "bg-success");

            PnlCapturaPersonas.Visible = true;

            BtnInserta.Visible = true;
            BtnCancela.Visible = true;

            ControlesClear();
            ControlesOnOff(true);
        }

        protected void BtnMnuListadoWeb_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvPersonas(NC.ListadoPersonas());
        }

        protected void BtnMnuImprimir_Click(object sender, EventArgs e)
        {

        }

        protected void BtnInformacion_Click(object sender, EventArgs e)
        {
            // Master.ModalMsg("Precaucion:  Para borrar un móndulo es necesario que <br /><br /> 1. El módulo no esté asignado a un Rol. De estar asignado a algún rol, primero deberá desasignarlo del rol en el múdulo de roles<br /> <br />" +
            //                "2. Que el módulo no tenga asignada alguna acción. De estar asignada alguna acción primero se deberá quitar la acción de los privilegios.");

        }

        protected void BtnBusca_Click(object sender, EventArgs e)
        {
            try
            {
                List<E_Persona> Personas = NC.LIstaPersonaPorCriterio(tbNombrePersonaBuscar.Text.Trim());

                if (Personas.Count == 0)        // No se encontró el módulo
                    ;// Master.ModalMsg("Precaucion: No se encontró el módulo solicitado");
                else if (Personas.Count == 1)// Se encontró un módulo con el criterio solicitado
                {
                    AtributosHeaderCard("Modificar o Borrar los datos del Módulo", "bg-warning");
                    ObjetoPersona_Controles(Personas[0].IdPersona);

                    hfIdPersona.Value = Personas[0].IdPersona.ToString();
                    hfIdPersonaSeleccionada.Value = Personas[0].IdPersona.ToString();
                    hfNombrePersonaseleccionada.Value = Personas[0].NombrePersona;

                    ControlesOnOff(false);
                    PnlCapturaPersonas.Visible = true;

                    BtnMnuModifica.Visible = true;
                    BtnMnuBorra.Visible = true;
                    BtnCancela.Visible = true;
                }
                else // Se encontro mas de un módulo con el criterio solicitado
                {
                    VisualizaGrvPersonas(Personas);
                }
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda.");
            }
        }



        protected void BtnBorra_Click(object sender, EventArgs e)
        {
            string R = NC.BorraPersonas(Convert.ToInt16(hfIdPersona.Value));
            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvPersonas(NC.ListadoPersonas());
            }
        }

        protected void BtnModifica_Click(object sender, EventArgs e)
        {

            try
            {
                E_Persona Persona = NC.BuscaPersonasPorId(Convert.ToInt16(hfIdPersona.Value));
                Persona.NombrePersona = tbNombrePersona.Text.Trim();
                Persona.TipoPersona = tbTipoPersona.Text.Trim();
                Persona.TipoDocumento = tbTipoDocumento.Text.Trim();
                Persona.NumeroDocumento = tbNumeroDocumento.Text.Trim();
                Persona.DireccionPersona = tbDireccionPersona.Text.Trim();
                Persona.TelefonoPersona = tbTelefonoPersona.Text.Trim();
                Persona.EmailPersona = tbEmailPersona.Text.Trim();

                string R = NC.ModificaPersonas(Persona);

                //Master.ModalMsg(R);

                if (R.Contains("Exito"))
                {
                    InicializaControles();
                    VisualizaGrvPersonas(NC.ListadoPersonas());
                }
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("md-error: Error: " + ex.Message + " " + ex.InnerException + " Cuando se tratar de modificar el Modulo, posiblemente se está duplicando información.");
            }
        }


        protected void BtnMnuModifica_Click(object sender, EventArgs e)
        {
            InicializaControles();
            AtributosHeaderCard("Modificar los datos de la persona", "bg-primary");

            BtnMnuModifica.Visible = false;
            BtnMnuBorra.Visible = false;

            BtnModifica.Visible = true;
            BtnCancela.Visible = true;

            ControlesOnOff(true);

            PnlCapturaPersonas.Visible = true;
        }

        protected void BtnMnuBorra_Click(object sender, EventArgs e)
        {
            AtributosHeaderCard("Borrar los datos de la persona", "bg-danger");
            BtnMnuModifica.Visible = false;
            BtnMnuBorra.Visible = false;

            BtnBorra.Visible = true;
            BtnCancela.Visible = true;

            ControlesOnOff(false);

            PnlCapturaPersonas.Visible = true;
        }

        protected void BtnCancela_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvPersonas(NC.ListadoPersonas());
        }
        #region Selecciones del GridView
        protected void GrvPersonas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                InicializaControles();
                AtributosHeaderCard("Modificar los datos del Módulo", "bg-primary");

                hfIdPersona.Value = GrvPersonas.DataKeys[e.NewEditIndex].Value.ToString();
                e.Cancel = true; //Deshabilita el modo edit del GridView de Modulos
                ObjetoPersona_Controles(Convert.ToInt16(hfIdPersona.Value));

                PnlCapturaPersonas.Visible = true;

                BtnModifica.Visible = true;
                BtnCancela.Visible = true;
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("md-error: Error: OCURRIO UN ERROR INESPERADO: " + ex.Message + " " + ex.InnerException);
            }
        }
        protected void GrvPersonas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ControlesOFF();
                ControlesOnOff(false);
                AtributosHeaderCard("Borrar los datos del Módulo", "bg-danger");

                hfIdPersona.Value = GrvPersonas.DataKeys[e.RowIndex].Value.ToString();
                ObjetoPersona_Controles(Convert.ToInt16(hfIdPersona.Value));
                e.Cancel = true;  //Deshabilita el modo borrado del GridView de Modulos

                PnlCapturaPersonas.Visible = true;

                BtnBorra.Visible = true;
                BtnCancela.Visible = true;
            }
            catch (Exception ex)
            {
                //Master.ModalMsg("Error: OCURRIO UN ERROR INESPERADO: " + ex.Message + " : " + ex.InnerException);
            }
        }

        #endregion

        protected void BtnInserta_Click(object sender, EventArgs e)
        {
            string R = NC.InsertaPersonas(Controles_ObjetoPersona());

            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvPersonas(NC.ListadoPersonas());
            }
        }
        
    }
}