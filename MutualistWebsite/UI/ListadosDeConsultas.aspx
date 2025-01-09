<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadosDeConsultas.aspx.cs" Inherits="ListadosDeConsultas" %>

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
        <label for="ddlPoliclinica">Seleccione Policlinica:</label>
        <asp:DropDownList ID="ddlPoliclinica" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPoliclinica_SelectedIndexChanged">
            <asp:ListItem>Seleccione Policlinica:</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtAnio">Año:</label>
        <asp:TextBox ID="txtAnio" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtMes">Mes:</label>
        <asp:TextBox ID="txtMes" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="error-label"></asp:Label>
    <div class="table-container">
        <asp:GridView ID="gvConsultas" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" PageSize="3" OnPageIndexChanging="gvConsultas_PageIndexChanging" OnSelectedIndexChanged="gvConsultas_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="CodigoC" HeaderText="Código Consulta" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Medico" HeaderText="Médico" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="table-container gridview-container">
        <asp:GridView ID="gvSolicitudes" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" PageSize="3" OnPageIndexChanging="gvSolicitudes_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="NumeroInterno" HeaderText="Número de Solicitud" />
                <asp:BoundField DataField="Cedula" HeaderText="Paciente" />
            </Columns>
        </asp:GridView>
    </div>
           <div class="additional-space"></div>
</div>


</asp:Content>

