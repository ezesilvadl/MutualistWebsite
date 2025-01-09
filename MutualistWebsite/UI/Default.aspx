<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asociación Española</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5;
            color: #333;
            margin: 0;
            padding: 0;
        }

        #form1 {
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 100vh;
            padding: 20px;
        }

        h1 {
            color: #4CAF50;
            margin-bottom: 20px;
        }

        .login-container {
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
            width: 300px;
            text-align: center;
        }

        h2 {
            color: #4CAF50;
            margin-top: 40px;
        }

        .grid-container {
            margin-top: 20px;
            width: 100%;
            max-width: 800px;
        }

        .grid-container .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            background-color: #ffffff;
            border-radius: 5px;
            overflow: hidden;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .grid-container .gridview th, .grid-container .gridview td {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .grid-container .gridview th {
            background-color: #4CAF50;
            color: white;
        }

        .grid-container .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>Mutualista</h1>
            <asp:Login ID="LoginControl" runat="server" DisplayRememberMe="False" 
                    LoginButtonText="Login" PasswordLabelText="" RenderOuterTable="False" 
                    TitleText="Ingreso" UserNameLabelText="" 
                    onauthenticate="Logueo_Authenticate" style="text-align: left">
            </asp:Login>
        </div>
        <h2>Consultas Pendientes</h2>
        <div class="grid-container">
            <asp:GridView ID="GridViewConsultas" runat="server" AutoGenerateColumns="False" GridLines="None"
    OnRowDataBound="GridViewConsultas_RowDataBound" 
    OnPageIndexChanging="GridViewConsultas_PageIndexChanging"
    AllowPaging="True" PageSize="5" CssClass="gridview">
    <Columns>
        <asp:BoundField DataField="Fecha" HeaderText="Fecha y Hora" />
        <asp:BoundField DataField="Medico" HeaderText="Médico" />
        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
        <asp:BoundField DataField="CantNumConsulta" HeaderText="Cantidad" />
        <asp:BoundField DataField="NumConsultorio.CodigoID.Direccion" HeaderText="Dirección" />
    </Columns>
</asp:GridView>
            <br />
        <asp:Label ID="LblError" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
