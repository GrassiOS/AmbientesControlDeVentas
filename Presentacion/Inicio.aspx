<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentacion.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8" />
  <title>Super sistema de ventas</title>
  <link href="Recursos/CSS/bootstrap.css" rel="stylesheet" />
  <link href="Recursos/CSS/main.css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
    <header>
      <div class="container">
        <h1>Sistema de ventas: Martin</h1>
      </div>
    </header>
    <!-- Barra lateral -->
    <nav class="sidebar">
      <a href="Vistas/Articulo/Articulo.aspx">Artículos</a>
      <a href="Vistas/Categoria/Categoria.aspx">Categorías</a>
      <a href="Vistas/Categoria/Persona.aspx">Personas</a>
      <a href="Vistas/Usuarios/Rol.aspx">Roles</a>
    </nav>

    <!-- Contenido principal -->
    <main class="content">
      <div class="container mt-5" style="display: none">
        <h3> <asp:Label ID="LblTitulo" runat="server"></asp:Label></h3>
        <asp:GridView ID="GrvCategorías" runat="server">
        </asp:GridView>
      </div>
    </main>
  </form>
</body>
</html>
