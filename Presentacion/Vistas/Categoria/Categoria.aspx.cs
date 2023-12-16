using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace Presentacion.Vistas.Categoria
{
    public partial class Categoria : System.Web.UI.Page
    {
        readonly N_Categoria NC = new N_Categoria();
        private string Color;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializaControles();
                VisualizaGrvCategorias(NC.ListadoCategorias());
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
            PnlGrvCategorias.Visible = false;
            PnlCapturaCategorias.Visible = false;

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
            tbNombreCategoria.Text = string.Empty;
            tbDescripcionCategoria.Text = string.Empty; ;
        }
        protected void ControlesOnOff(bool TrueOrFalse)
        {
            tbNombreCategoria.Enabled = TrueOrFalse;
            tbDescripcionCategoria.Enabled = TrueOrFalse;
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
        protected E_Categoria Controles_ObjetoCategoria()
        {
            E_Categoria categoria = new E_Categoria
            {
                NombreCategoria = tbNombreCategoria.Text.Trim(),
                DescripcionCategoria = tbDescripcionCategoria.Text.Trim()
            };

            return categoria;
        }
        protected void ObjetoCategoria_Controles(int idCategoria)
        {
            E_Categoria categoria = NC.BuscaCategoriasPorId(idCategoria);
            if (categoria != null)
            {
                tbNombreCategoria.Text = categoria.NombreCategoria;
                tbDescripcionCategoria.Text = categoria.DescripcionCategoria;
            }
        }

        protected void VisualizaGrvCategorias(List<E_Categoria> categorias)
        {
            GrvCategorias.DataSource = categorias;
            GrvCategorias.DataBind();
            PnlGrvCategorias.Visible = true;
        }
        #endregion
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            AtributosHeaderCard("Registro de una nuevo categoría", "bg-success");

            PnlCapturaCategorias.Visible = true;

            BtnInserta.Visible = true;
            BtnCancela.Visible = true;

            ControlesClear();
            ControlesOnOff(true);
        }

        protected void BtnMnuListadoWeb_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvCategorias(NC.ListadoCategorias());
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
                List<E_Categoria> categorias = NC.LIstaCategoriaPorCriterio(tbNombreCategoriaBuscar.Text.Trim());

                if (categorias.Count == 0)        // No se encontró el módulo
                    ;// Master.ModalMsg("Precaucion: No se encontró el módulo solicitado");
                else if (categorias.Count == 1)// Se encontró un módulo con el criterio solicitado
                {
                    AtributosHeaderCard("Modificar o Borrar los datos del Módulo", "bg-warning");
                    ObjetoCategoria_Controles(categorias[0].IdCategoria);

                    hfIdCategoria.Value = categorias[0].IdCategoria.ToString();
                    hfIdCateoriaSeleccionada.Value = categorias[0].IdCategoria.ToString();
                    hfNombreCategoriaSeleccionada.Value = categorias[0].NombreCategoria;

                    ControlesOnOff(false);
                    PnlCapturaCategorias.Visible = true;

                    BtnMnuModifica.Visible = true;
                    BtnMnuBorra.Visible = true;
                    BtnCancela.Visible = true;
                }
                else // Se encontro mas de un módulo con el criterio solicitado
                {
                    VisualizaGrvCategorias(categorias);
                }
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda.");
            }
        }



        protected void BtnBorra_Click(object sender, EventArgs e)
        {
            string R = NC.BorraCategorias(Convert.ToInt16(hfIdCategoria.Value));
            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvCategorias(NC.ListadoCategorias());
            }
        }

        protected void BtnModifica_Click(object sender, EventArgs e)
        {

            try
            {
                E_Categoria categoria = NC.BuscaCategoriasPorId(Convert.ToInt16(hfIdCategoria.Value));
                categoria.NombreCategoria = tbNombreCategoria.Text.Trim();
                categoria.DescripcionCategoria = tbDescripcionCategoria.Text.Trim();

                string R = NC.ModificaCategorias(categoria);

                //Master.ModalMsg(R);

                if (R.Contains("Exito"))
                {
                    InicializaControles();
                    VisualizaGrvCategorias(NC.ListadoCategorias());
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

            PnlCapturaCategorias.Visible = true;
        }

        protected void BtnMnuBorra_Click(object sender, EventArgs e)
        {
            AtributosHeaderCard("Borrar los datos de la categoría", "bg-danger");
            BtnMnuModifica.Visible = false;
            BtnMnuBorra.Visible = false;

            BtnBorra.Visible = true;
            BtnCancela.Visible = true;

            ControlesOnOff(false);

            PnlCapturaCategorias.Visible = true;
        }

        protected void BtnCancela_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvCategorias(NC.ListadoCategorias());
        }
        #region Selecciones del GridView
        protected void GrvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                InicializaControles();
                AtributosHeaderCard("Modificar los datos del Módulo", "bg-primary");

                hfIdCategoria.Value = GrvCategorias.DataKeys[e.NewEditIndex].Value.ToString();
                e.Cancel = true; //Deshabilita el modo edit del GridView de Modulos
                ObjetoCategoria_Controles(Convert.ToInt16(hfIdCategoria.Value));

                PnlCapturaCategorias.Visible = true;

                BtnModifica.Visible = true;
                BtnCancela.Visible = true;
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("md-error: Error: OCURRIO UN ERROR INESPERADO: " + ex.Message + " " + ex.InnerException);
            }
        }
        protected void GrvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ControlesOFF();
                ControlesOnOff(false);
                AtributosHeaderCard("Borrar los datos del Módulo", "bg-danger");

                hfIdCategoria.Value = GrvCategorias.DataKeys[e.RowIndex].Value.ToString();
                ObjetoCategoria_Controles(Convert.ToInt16(hfIdCategoria.Value));
                e.Cancel = true;  //Deshabilita el modo borrado del GridView de Modulos

                PnlCapturaCategorias.Visible = true;

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
            string R = NC.InsertaCategorias(Controles_ObjetoCategoria());

            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvCategorias(NC.ListadoCategorias());
            }
        }
        
        protected void alterState(object sender, EventArgs e)
        {
            // Obtén el ID del rol del CommandArgument
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
        
            // Ahora puedes usar idRol como necesites
                var entity = NC.BuscaCategoriasPorId(id);
                entity.Estado = !entity.Estado;

                string R = NC.ModificaCategorias(entity);

                //Master.ModalMsg(R);

                if (R.Contains("Exito"))
                {
                    InicializaControles();
                    VisualizaGrvCategorias(NC.ListadoCategorias());
                }
        
            // Resto del código...
        }
    }
}