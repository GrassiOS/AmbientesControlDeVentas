<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuAlfabetico.ascx                                                   |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar que se capture datos                                         |
| La entrada de datos es obligatoria. NO                                        |
| Caracteres válidos: A-Z, a-Z, 0-9. ÁÉÍÓÚ, áéíóú, ñÑ,                          |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucAlfaNumerico.ascx.cs" Inherits="WebLoginFIAD.Controles.wucAlfaNumerico" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbAlfaNumerico" runat="server" CssClass="form-control"></asp:TextBox>

