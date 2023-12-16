using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;
using Negocios.Usuarios;

namespace Presentacion.Vistas.Usuarios
{
    public partial class Rol : System.Web.UI.Page
    {
        readonly N_Rol NC = new N_Rol();
        private string Color;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializaControles();
                VisualizaGrvRoles(NC.ListadoRoles());
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
            PnlGrvRoles.Visible = false;
            PnlCapturaRoles.Visible = false;

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
            tbNombreRol.Text = string.Empty;
            tbDescripcionRol.Text = string.Empty; ;
        }
        protected void ControlesOnOff(bool TrueOrFalse)
        {
            tbNombreRol.Enabled = TrueOrFalse;
            tbDescripcionRol.Enabled = TrueOrFalse;
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
        protected E_Roles Controles_ObjetoRol()
        {
            E_Roles Rol = new E_Roles
            {
                NombreRol = tbNombreRol.Text.Trim(),
                DescripcionRol = tbDescripcionRol.Text.Trim()
            };

            return Rol;
        }
        protected void ObjetoRol_Controles(int idRol)
        {
            E_Roles Rol = NC.BuscaRolesPorId(idRol);
            if (Rol != null)
            {
                tbNombreRol.Text = Rol.NombreRol;
                tbDescripcionRol.Text = Rol.DescripcionRol;
            }
        }

        protected void VisualizaGrvRoles(List<E_Roles> Roles)
        {
            GrvRoles.DataSource = Roles;
            GrvRoles.DataBind();
            PnlGrvRoles.Visible = true;
        }
        #endregion
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            AtributosHeaderCard("Registro de una nuevo categoría", "bg-success");

            PnlCapturaRoles.Visible = true;

            BtnInserta.Visible = true;
            BtnCancela.Visible = true;

            ControlesClear();
            ControlesOnOff(true);
        }

        protected void BtnMnuListadoWeb_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvRoles(NC.ListadoRoles());
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
                List<E_Roles> Roles = NC.LIstaRolPorCriterio(tbNombreRolBuscar.Text.Trim());

                if (Roles.Count == 0)        // No se encontró el módulo
                    ;// Master.ModalMsg("Precaucion: No se encontró el módulo solicitado");
                else if (Roles.Count == 1)// Se encontró un módulo con el criterio solicitado
                {
                    AtributosHeaderCard("Modificar o Borrar los datos del Módulo", "bg-warning");
                    ObjetoRol_Controles(Roles[0].IdRol);

                    hfIdRol.Value = Roles[0].IdRol.ToString();
                    hfIdRolesSeleccionada.Value = Roles[0].IdRol.ToString();
                    hfNombreRoleseleccionada.Value = Roles[0].NombreRol;

                    ControlesOnOff(false);
                    PnlCapturaRoles.Visible = true;

                    BtnMnuModifica.Visible = true;
                    BtnMnuBorra.Visible = true;
                    BtnCancela.Visible = true;
                }
                else // Se encontro mas de un módulo con el criterio solicitado
                {
                    VisualizaGrvRoles(Roles);
                }
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda.");
            }
        }



        protected void BtnBorra_Click(object sender, EventArgs e)
        {
            string R = NC.BorraRoles(Convert.ToInt16(hfIdRol.Value));
            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvRoles(NC.ListadoRoles());
            }
        }


        protected void alterState(object sender, EventArgs e)
        {
            // Obtén el ID del rol del CommandArgument
            int idRol = Convert.ToInt32((sender as LinkButton).CommandArgument);
        
            // Ahora puedes usar idRol como necesites
                E_Roles Rol = NC.BuscaRolesPorId(idRol);
                Rol.Estado = !Rol.Estado;

                string R = NC.ModificaRoles(Rol);

                //Master.ModalMsg(R);

                if (R.Contains("Exito"))
                {
                    InicializaControles();
                    VisualizaGrvRoles(NC.ListadoRoles());
                }
        
            // Resto del código...
        }
        protected void BtnModifica_Click(object sender, EventArgs e)
        {

            try
            {
                E_Roles Rol = NC.BuscaRolesPorId(Convert.ToInt16(hfIdRol.Value));
                Rol.NombreRol = tbNombreRol.Text.Trim();
                Rol.DescripcionRol = tbDescripcionRol.Text.Trim();

                string R = NC.ModificaRoles(Rol);

                //Master.ModalMsg(R);

                if (R.Contains("Exito"))
                {
                    InicializaControles();
                    VisualizaGrvRoles(NC.ListadoRoles());
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
            AtributosHeaderCard("Modificar los datos de la categoría", "bg-primary");

            BtnMnuModifica.Visible = false;
            BtnMnuBorra.Visible = false;

            BtnModifica.Visible = true;
            BtnCancela.Visible = true;

            ControlesOnOff(true);

            PnlCapturaRoles.Visible = true;
        }

        protected void BtnMnuBorra_Click(object sender, EventArgs e)
        {
            AtributosHeaderCard("Borrar los datos de la categoría", "bg-danger");
            BtnMnuModifica.Visible = false;
            BtnMnuBorra.Visible = false;

            BtnBorra.Visible = true;
            BtnCancela.Visible = true;

            ControlesOnOff(false);

            PnlCapturaRoles.Visible = true;
        }

        protected void BtnCancela_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvRoles(NC.ListadoRoles());
        }
        #region Selecciones del GridView
        protected void GrvRoles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                InicializaControles();
                AtributosHeaderCard("Modificar los datos del Módulo", "bg-primary");

                hfIdRol.Value = GrvRoles.DataKeys[e.NewEditIndex].Value.ToString();
                e.Cancel = true; //Deshabilita el modo edit del GridView de Modulos
                ObjetoRol_Controles(Convert.ToInt16(hfIdRol.Value));

                PnlCapturaRoles.Visible = true;

                BtnModifica.Visible = true;
                BtnCancela.Visible = true;
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("md-error: Error: OCURRIO UN ERROR INESPERADO: " + ex.Message + " " + ex.InnerException);
            }
        }
        protected void GrvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ControlesOFF();
                ControlesOnOff(false);
                AtributosHeaderCard("Borrar los datos del Módulo", "bg-danger");

                hfIdRol.Value = GrvRoles.DataKeys[e.RowIndex].Value.ToString();
                ObjetoRol_Controles(Convert.ToInt16(hfIdRol.Value));
                e.Cancel = true;  //Deshabilita el modo borrado del GridView de Modulos

                PnlCapturaRoles.Visible = true;

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
            string R = NC.InsertaRoles(Controles_ObjetoRol());

            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvRoles(NC.ListadoRoles());
            }
        }
    }
}