<%@ Page Title="ABM Pacientes" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMPacientes.aspx.cs" Inherits="ABMPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .admin-title {
            text-align: center;
            font-size: 2em;
            color: #4CAF50;
            margin-top: 20px;
        }
        .admin-description {
            text-align: center;
            font-size: 1.2em;
            color: #555;
            margin-top: 10px;
        }
        .form-container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            background-color: #fff;
        }
        .form-title {
            text-align: center;
            font-size: 1.5em;
            color: #0066CC;
            margin-bottom: 20px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .form-group input,
        .form-group select,
        .form-group textarea {
            width: calc(100% - 10px);
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }
        .form-group button {
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #0066CC;
            color: white;
            font-size: 1em;
            cursor: pointer;
        }
        .form-group button:hover {
            background-color: #005bb5;
        }
        .error-label {
            color: red;
            text-align: center;
        }
        .table-container {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }
        .table-container th,
        .table-container td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }
        .table-container th {
            background-color: #f4f4f4;
            color: #333;
        }
        .table-container td input,
        .table-container td select,
        .table-container td textarea {
            width: 100%;
            box-sizing: border-box;
        }
        .auto-style1 {
            text-align: center;
            font-size: 1.5em;
            color: #00CC66;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-container">
        <div class="auto-style1">ABM Pacientes</div>
        <table class="table-container">
            <tr>
                <td colspan="1">
                    <asp:Button ID="BtnBusco" runat="server" Text="Buscar" CssClass="form-button" OnClick="BtnBusco_Click" />
                    &nbsp;<br />
                    
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    Cedula:
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtCedula" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td colspan="1">
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    Nombre:
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td colspan="1">
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    Fecha de Nacimiento:
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtFechaNac" runat="server"  Width="100%"></asp:TextBox>
                </td>
                <td colspan="1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <strong>
                    <br />
                    <asp:TextBox ID="txtPatologias" runat="server" Width="100%"></asp:TextBox>
                    <br />
                    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar Patología" CssClass="form-button" OnClick="BtnAgregar_Click" />
                    </strong>&nbsp;
                </td>
                <td colspan="3">
                    <strong>Patologías</strong><br />
                    <asp:ListBox ID="LbPatologias" runat="server" Width="100%"></asp:ListBox>
                    &nbsp;<asp:Button ID="BtnBorrarPat" runat="server" Text="Eliminar Patología" CssClass="form-button" OnClick="BtnBorrarPat_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="LblError" runat="server" CssClass="error-label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="BtnAlta" runat="server" Enabled="False" Text="Alta" CssClass="form-button" OnClick="BtnAlta_Click" />
                </td>
                <td colspan="2">
                    <asp:Button ID="BtnBaja" runat="server" Enabled="False" Text="Baja" CssClass="form-button" OnClick="BtnBaja_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnModificar" runat="server" Enabled="False" Text="Modificar" CssClass="form-button" OnClick="BtnModificar_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnRefresh" runat="server" Text="Limpiar Pantalla" CssClass="form-button" OnClick="BtnLimpiar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
