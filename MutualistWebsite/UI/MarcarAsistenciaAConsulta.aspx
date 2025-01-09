<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MarcarAsistenciaAConsulta.aspx.cs" Inherits="MarcarAsistenciaAConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style>
        .form-container {
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0,0,0,0.1);
    background-color: #fff;
    overflow: hidden;
}
.form-title {
    text-align: center;
    font-size: 1.8em;
    color: #333;
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
.form-group button {
    width: calc(100% - 10px);
    padding: 10px;
    border-radius: 5px;
    border: 1px solid #ccc;
    font-size: 1em;
    margin-bottom: 10px;
}
.form-group button {
    width: 100%;
    background-color: #0066CC;
    color: white;
    cursor: pointer;
}
.form-group button:hover {
    background-color: #005bb5;
}
.error-label {
    color: red;
    text-align: center;
    margin-bottom: 10px;
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
.gridview-container {
    max-height: 400px; 
    overflow-y: auto;
}
.additional-space {
    height: 200px; 
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-container">
    <div class="form-title">Listados de Consultas</div>
    <div class="form-group">
        <label for="ddlPoliclinica">Seleccione la solicitud de consulta:</label>
        <asp:DropDownList ID="ddlConsultas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConsultas_SelectedIndexChanged">
            <asp:ListItem>Seleccione Policlinica:</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Button ID="btnMarcarAsistencia" runat="server" Text="Marcar Asistencia " OnClick="btnMarcarAsistencia_Click" />
    </div>

    <asp:Label ID="lblError" runat="server" CssClass="error-label"></asp:Label>
</div>
</asp:Content>
