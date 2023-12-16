<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="Presentacion.Vistas.Articulo.Articulo" %>

<%@ Register Src="~/Recursos/Controles/wucAlfaNumerico.ascx" TagPrefix="uc1" TagName="wucAlfaNumerico" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.11.2/css/all.css" />
    <link rel="stylesheet" href="../../Recursos/CSS/bootstrap.css" />
    <link rel="stylesheet" href="../../Recursos/CSS/NovoHub.css" />
    <meta charset="UTF-8">
</head>

<body>
    <form id="form1" runat="server">
        <div class="sidebar">
          <a href="../../Inicio.aspx">Home</a>
          <a href="../Articulo/Articulo.aspx">Artículos</a>
          <a href="../Categoria/Categoria.aspx">Categorías</a>
          <a href="../Categoria/Persona.aspx">Personas</a>
          <a href="../Usuarios/Rol.aspx">Roles</a>
        </div>
        <div class="container">
            <h5>Gestion de Articulos</h5>
            <hr class="bg-success mt-0 mb-2" />

            <!-- Contenedor del tipo panel para el WebForm de captura de datos-->
            <div class="row mt-5">
                <div class="col-lg-8 col-md-6 col-sm-6">
                    <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-success " ToolTip="Registrar un nuevo Articulo" OnClick="BtnMnuNuevo_Click" CausesValidation="False"> Nuevo Articulo</asp:LinkButton>
                    <asp:LinkButton ID="BtnMnuListadoWeb" runat="server" CssClass="btn btn-success " ToolTip="Listado de Articulos por pantalla" CausesValidation="false" OnClick="BtnMnuListadoWeb_Click"> Listado</asp:LinkButton>
                    <!-- 
                    <asp:LinkButton ID="BtnInformacion" runat="server" CssClass="btn btn-primary fa fa-question-circle-o" CausesValidation="False" OnClick="BtnInformacion_Click"> Ayuda</asp:LinkButton>
                    -->
                </div>

                <div class="col-lg-4 col-md-6 col-sm-6 mb-5">
                    <div class="row">
                        <div class="col-lg-9">
                            <asp:TextBox ID="tbNombreArticuloBuscar" runat="server" CssClass="form-control" placeholder="Criterio de busqueda" ToolTip="Buscar"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <asp:LinkButton ID="BtnBusca" runat="server" CssClass="btn btn-success" ToolTip="Permite buscar un Articulo" OnClick="BtnBusca_Click" CausesValidation="False"> Buscar </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>



            <!-- Contenedor del tipo panel para el GridView de presentación del listado de Articulos-->
            <div class="container-fluid mt-5">
                <asp:Panel ID="PnlGrvArticulos" runat="server">
                    <asp:GridView ID="GrvArticulos" runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdArticulo"
                        OnRowEditing="GrvArticulos_RowEditing"
                        OnRowDeleting="GrvArticulos_RowDeleting"
                        CssClass="table table-sm table-bordered">
                        <Columns>
                            <asp:BoundField DataField="NombreArticulo" HeaderText="Artículo"></asp:BoundField>
                            <asp:BoundField DataField="DescripcionArticulo" HeaderText="Descripción"></asp:BoundField>
                            <asp:BoundField DataField="IdCategoria" HeaderText="Categoría" />
                            <asp:BoundField DataField="CodigoArticulo" HeaderText="Código de artículo" />
                            <asp:BoundField DataField="PrecioVenta" HeaderText="Precio de venta" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock" />
                            <asp:TemplateField InsertVisible="False" ShowHeader="False" HeaderText="Editar" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnGrvEdita" runat="server" CssClass="btn btn-sm btn-primary  " ToolTip="Modifica los datos del Articulo" CausesValidation="False" CommandName="Edit">Edit</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False" HeaderText="Borrar" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnGrvBorrar" runat="server" CssClass="btn btn-sm btn-danger " ToolTip="Borra los datos del Articulo" CausesValidation="False" CommandName="Delete">Borrar</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False" HeaderText="Disponibilidad" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnEstado" runat="server" 
                                        CssClass='<%# (bool)Eval("Estado") ? "btn btn-sm btn-success" : "btn btn-sm btn-danger" %>' 
                                        Text='<%# (bool)Eval("Estado") ? "Activo" : "No activo" %>' 
                                        OnClick="alterState" 
                                        CommandArgument='<%# Eval("IdArticulo") %>'>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>

            <!-- Contenedor del tipo panel para el WebForm de captura de datos-->
            <asp:Panel ID="PnlCapturaArticulos" runat="server">
                <div class="container pl-0 mt-3">
                    <div class="card">
                        <div id="CardHeader" runat="server">
                            <h5 class="card-title">
                                <asp:Label ID="lblAccion" runat="server" >s</asp:Label></h5>
                        </div>

                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-12">
                                <div class="form-group">
                                    <p>Nombre del Articulo</p>
                                    <uc1:wucAlfaNumerico runat="server" ID="tbNombreArticulo" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        
                        <div class="row pl-2 pr-2">
                            <div class="col-12">
                                <div class="form-group">
                                    <p>ID de categoria</p>
                                    <uc1:wucAlfaNumerico runat="server" ID="tbIdCategoria" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    
                        <div class="row pl-2 pr-2">
                            <div class="col-12">
                                <div class="form-group">
                                    <p>Descripción</p>
                                    <asp:TextBox ID="tbDescripcionArticulo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    
                        <div class="row pl-2 pr-2">
                            <div class="col-12">
                                <div class="form-group">
                                    <p>Precio de Venta</p>
                                    <asp:TextBox ID="tbPrecioVenta" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    
                        <div class="row pl-2 pr-2">
                            <div class="col-12">
                                <div class="form-group">
                                    <p>Stock</p>
                                    <asp:TextBox ID="tbStock" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    
                        <div class="row pl-2 pr-2">
                            <div class="col-12">
                                <div class="form-group">
                                    <p>Código</p>
                                    <asp:TextBox ID="tbCodigoArticulo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                        <div class="card-footer text-muted text-right">
                            <asp:LinkButton ID="BtnInserta" runat="server" CssClass="btn btn-success fa fa-check" OnClick="BtnInserta_Click"> Grabar</asp:LinkButton>
                            <asp:LinkButton ID="BtnBorra" runat="server" CssClass="btn btn-danger fa fa-minus-circle" CausesValidation="False" OnClick="BtnBorra_Click" OnClientClick="return confirm(&quot;Los datos del Articulo serán borrados permanentemente. ¿Está seguro de borrarlos?&quot;);"> Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnModifica" runat="server" CssClass="btn btn-primary fa fa-check" OnClick="BtnModifica_Click"> Modificar</asp:LinkButton>

                            <asp:LinkButton ID="BtnMnuModifica" runat="server" CssClass="btn btn-primary fa fa-check" CausesValidation="False" OnClick="BtnMnuModifica_Click"> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuBorra" runat="server" CssClass="btn btn-danger fa fa-eraser" OnClick="BtnMnuBorra_Click" CausesValidation="False"> Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnCancela" runat="server" CssClass="btn btn-dark fa fa-rotate-left" OnClick="BtnCancela_Click" CausesValidation="False"> Regresar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>



            <asp:HiddenField ID="hfIdArticulo" runat="server" />
            <asp:HiddenField ID="hfIdArticuloSeleccionada" runat="server" Value="" />
            <asp:HiddenField ID="hfNombreArticuloseleccionada" runat="server" Value="" />
    </form>
</body>
</html>

