<%@ Page Title="Página de Administración" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>

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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="admin-title">Página de Administración</h2>
    <p class="admin-description">Bienvenido a la página de administración. Aquí puedes gestionar diversas funcionalidades del sistema.</p>
</asp:Content>
