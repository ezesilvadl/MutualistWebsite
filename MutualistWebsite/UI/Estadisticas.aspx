<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Estadisticas.aspx.cs" Inherits="Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .container {
            max-width: 900px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
        .section-title {
            text-align: center;
            font-size: 1.8em;
            color: #333;
            margin-bottom: 20px;
        }


        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
        }
        .grid-view th {
            background-color: #f4f4f4;
            color: #333;
            font-weight: bold;
        }
        .grid-view tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        .grid-view tr:hover {
            background-color: #f1f1f1;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="section-title">Estadísticas</div>


        <asp:GridView ID="gvSolicitudesAsistencia" runat="server" CssClass="grid-view" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TipoAsistencia" HeaderText="Tipo Asistencia" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de Solicitudes" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="gvConsultasPorConsultorio" runat="server" CssClass="grid-view" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Policlínica" HeaderText="Policlínica" />
                <asp:BoundField DataField="Consultorio" HeaderText="Consultorio" />
                <asp:BoundField DataField="CantidadConsultas" HeaderText="Cantidad de Consultas" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
