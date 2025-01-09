<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaPoliclinica.aspx.cs" Inherits="AltaPoliclinica" %>

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
            max-width: 600px;
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
        .form-group input {
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
        <div class="auto-style1">Alta Policlínica</div>
        <div class="form-group">
            <label for="txtCodigoID">Codigo ID:</label>
            <asp:TextBox ID="txtCodigoID" runat="server" Width="100%" />
        </div>
        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Width="100%"  />
        </div>
        <div class="form-group">
            <label for="txtDireccion">Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server" Width="100%"  />
        </div>
        <div class="form-group">
            <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" CssClass="form-button" OnClick="BtnAgregar_Click" />
        </div>
        <div class="form-group">
            <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar / Deshacer" CssClass="form-button" OnClick="BtnLimpiar_Click" />
        </div>
        <asp:Label ID="lblError" runat="server" CssClass="error-label" />
    </div>
</asp:Content>

