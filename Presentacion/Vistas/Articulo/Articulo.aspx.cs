using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;
using Negocios.Almacen;
using Negocios.Usuarios;

namespace Presentacion.Vistas.Articulo
{
    public partial class Articulo : System.Web.UI.Page
    {
        readonly N_Articulos NC = new N_Articulos();
        private string Color;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializaControles();
                VisualizaGrvArticulos(NC.ListadoArticulos());
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
            PnlGrvArticulos.Visible = false;
            PnlCapturaArticulos.Visible = false;

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
            tbNombreArticulo.Text = string.Empty;
            tbDescripcionArticulo.Text = string.Empty;
            tbCodigoArticulo.Text = string.Empty;
            tbPrecioVenta.Text = "0.0"; // Establecer valor por defecto para decimal
            tbStock.Text = "0"; // Establecer valor por defecto para entero
            tbIdCategoria.Text = "0";
            // Agrega más campos aquí según sea necesario
        }

        protected void ControlesOnOff(bool TrueOrFalse)
        {
            tbNombreArticulo.Enabled = TrueOrFalse;
            tbDescripcionArticulo.Enabled = TrueOrFalse;
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
        protected E_Articulo Controles_ObjetoArticulo()
        {
            E_Articulo Articulo = new E_Articulo
            {
                NombreArticulo = tbNombreArticulo.Text.Trim(),
                DescripcionArticulo = tbDescripcionArticulo.Text.Trim(),
                PrecioVenta = Convert.ToDecimal(tbPrecioVenta.Text.Trim()),
                Stock = Convert.ToInt32(tbStock.Text.Trim()),
                IdCategoria = Convert.ToInt32(tbIdCategoria.Text.Trim()),
                CodigoArticulo = tbCodigoArticulo.Text.Trim()

            };

            return Articulo;
        }
        protected void ObjetoArticulo_Controles(int idArticulo)
        {
            E_Articulo Articulo = NC.BuscaArticulosPorId(idArticulo);
            if (Articulo != null)
            {
                tbNombreArticulo.Text = Articulo.NombreArticulo;
                tbDescripcionArticulo.Text = Articulo.DescripcionArticulo;
                tbPrecioVenta.Text = Articulo.PrecioVenta.ToString();
                tbStock.Text = Articulo.Stock.ToString();
                tbIdCategoria.Text = Articulo.IdCategoria.ToString();
                tbCodigoArticulo.Text = Articulo.IdArticulo.ToString();
                
            }
        }

        protected void VisualizaGrvArticulos(List<E_Articulo> Articulos)
        {
            GrvArticulos.DataSource = Articulos;
            GrvArticulos.DataBind();
            PnlGrvArticulos.Visible = true;
        }
        #endregion
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            AtributosHeaderCard("Registro de una nuevo Articulo", "bg-success");

            PnlCapturaArticulos.Visible = true;

            BtnInserta.Visible = true;
            BtnCancela.Visible = true;

            ControlesClear();
            ControlesOnOff(true);
        }

        protected void BtnMnuListadoWeb_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvArticulos(NC.ListadoArticulos());
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
                List<E_Articulo> Articulos = NC.LIstaArticulosPorCriterio(tbNombreArticuloBuscar.Text.Trim());

                if (Articulos.Count == 0)        // No se encontró el módulo
                    ;// Master.ModalMsg("Precaucion: No se encontró el módulo solicitado");
                else if (Articulos.Count == 1)// Se encontró un módulo con el criterio solicitado
                {
                    AtributosHeaderCard("Modificar o Borrar los datos del Módulo", "bg-warning");
                    ObjetoArticulo_Controles(Articulos[0].IdArticulo);

                    hfIdArticulo.Value = Articulos[0].IdArticulo.ToString();
                    hfIdArticuloSeleccionada.Value = Articulos[0].IdArticulo.ToString();
                    hfNombreArticuloseleccionada.Value = Articulos[0].NombreArticulo;

                    ControlesOnOff(false);
                    PnlCapturaArticulos.Visible = true;

                    BtnMnuModifica.Visible = true;
                    BtnMnuBorra.Visible = true;
                    BtnCancela.Visible = true;
                }
                else // Se encontro mas de un módulo con el criterio solicitado
                {
                    VisualizaGrvArticulos(Articulos);
                }
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda.");
            }
        }



        protected void BtnBorra_Click(object sender, EventArgs e)
        {
            string R = NC.BorraArticulo(Convert.ToInt16(hfIdArticulo.Value));
            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvArticulos(NC.ListadoArticulos());
            }
        }

        protected void BtnModifica_Click(object sender, EventArgs e)
        {

            try
            {
                E_Articulo Articulo = NC.BuscaArticulosPorId(Convert.ToInt16(hfIdArticulo.Value));
                Articulo.NombreArticulo = tbNombreArticulo.Text.Trim();
                Articulo.DescripcionArticulo = tbDescripcionArticulo.Text.Trim();
                Articulo.IdCategoria = Convert.ToInt32(tbIdCategoria.Text.Trim());
                Articulo.PrecioVenta = Convert.ToDecimal(tbPrecioVenta.Text.Trim());
                Articulo.Stock = Convert.ToInt32(tbStock.Text.Trim());
                Articulo.CodigoArticulo = tbCodigoArticulo.Text.Trim();
                

                string R = NC.ModificaArticulo(Articulo);

                //Master.ModalMsg(R);

                if (R.Contains("Exito"))
                {
                    InicializaControles();
                    VisualizaGrvArticulos(NC.ListadoArticulos());
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
            AtributosHeaderCard("Modificar los datos de la Articulo", "bg-primary");

            BtnMnuModifica.Visible = false;
            BtnMnuBorra.Visible = false;

            BtnModifica.Visible = true;
            BtnCancela.Visible = true;

            ControlesOnOff(true);

            PnlCapturaArticulos.Visible = true;
        }

        protected void BtnMnuBorra_Click(object sender, EventArgs e)
        {
            AtributosHeaderCard("Borrar los datos de la Articulo", "bg-danger");
            BtnMnuModifica.Visible = false;
            BtnMnuBorra.Visible = false;

            BtnBorra.Visible = true;
            BtnCancela.Visible = true;

            ControlesOnOff(false);

            PnlCapturaArticulos.Visible = true;
        }

        protected void BtnCancela_Click(object sender, EventArgs e)
        {
            InicializaControles();
            VisualizaGrvArticulos(NC.ListadoArticulos());
        }
        #region Selecciones del GridView
        protected void GrvArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                InicializaControles();
                AtributosHeaderCard("Modificar los datos del Módulo", "bg-primary");

                hfIdArticulo.Value = GrvArticulos.DataKeys[e.NewEditIndex].Value.ToString();
                e.Cancel = true; //Deshabilita el modo edit del GridView de Modulos
                ObjetoArticulo_Controles(Convert.ToInt16(hfIdArticulo.Value));

                PnlCapturaArticulos.Visible = true;

                BtnModifica.Visible = true;
                BtnCancela.Visible = true;
            }
            catch (Exception ex)
            {
                // Master.ModalMsg("md-error: Error: OCURRIO UN ERROR INESPERADO: " + ex.Message + " " + ex.InnerException);
            }
        }
        protected void GrvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ControlesOFF();
                ControlesOnOff(false);
                AtributosHeaderCard("Borrar los datos del Módulo", "bg-danger");

                hfIdArticulo.Value = GrvArticulos.DataKeys[e.RowIndex].Value.ToString();
                ObjetoArticulo_Controles(Convert.ToInt16(hfIdArticulo.Value));
                e.Cancel = true;  //Deshabilita el modo borrado del GridView de Modulos

                PnlCapturaArticulos.Visible = true;

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
            string R = NC.InsertaArticulo(Controles_ObjetoArticulo());

            //Master.ModalMsg(R);

            if (R.Contains("Exito"))
            {
                InicializaControles();
                VisualizaGrvArticulos(NC.ListadoArticulos());
            }
        }
        
        protected void alterState(object sender, EventArgs e)
        {
            // Obtén el ID del rol del CommandArgument
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
        
            // Ahora puedes usar idRol como necesites
                var entity = NC.BuscaArticulosPorId(id);
                entity.Estado = !entity.Estado;

                string R = NC.ModificaArticulo(entity);

                //Master.ModalMsg(R);

                if (R.Contains("Exito"))
                {
                    InicializaControles();
                    VisualizaGrvArticulos(NC.ListadoArticulos());
                }
        
            // Resto del código...
        }
    }

}