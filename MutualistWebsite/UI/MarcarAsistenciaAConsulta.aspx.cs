using EntidadesCompartidas;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MarcarAsistenciaAConsulta : System.Web.UI.Page
{
    EntidadesCompartidas.Consulta ConsultaSeleccionada;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["ConsultaSel"] = null;

                CargarSolicitudes();
            }
            else
            {
                if (Session["ConsultaSel"] != null)
                    ConsultaSeleccionada = (EntidadesCompartidas.Consulta)Session["ConsultaSel"];
                else
                    ConsultaSeleccionada = null;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    private void CargarSolicitudes()
    {
        List<Solicitud> consultas = Logica.FabricaLogica.GetLogicaSolicitud().ListarSinAsistirHoy();

        var policlinicas = (from c in consultas
                            select c.CodigoC)
                            .Distinct()
                            .ToList();

        ddlConsultas.Items.Clear();
        ddlConsultas.Items.Add(new ListItem("Seleccione:", "0"));

        foreach (var nombrePoliclinica in policlinicas)
        {
            ddlConsultas.Items.Add(new ListItem(nombrePoliclinica.CodigoC.ToString()));
        }
        Session["Consultas"] = consultas;
    }



    protected void btnMarcarAsistencia_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlConsultas.SelectedIndex > 0) 
            {
                int codigoC = int.Parse(ddlConsultas.SelectedValue);

                List<Solicitud> consultas = (List<Solicitud>)Session["Consultas"];

                Solicitud solicitudSeleccionada = (from s in consultas
                                                   where s.CodigoC.CodigoC == codigoC
                                                   select s).FirstOrDefault();

                if (solicitudSeleccionada != null)
                {
                    Logica.FabricaLogica.GetLogicaSolicitud().MarcarAsistencia(solicitudSeleccionada);
                    lblError.Text = "Asistencia marcada exitosamente.";
                }
                else
                {
                    lblError.Text = "No se encontró la solicitud seleccionada.";
                }
            }
            else
            {
                lblError.Text = "Por favor, seleccione una solicitud.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void ddlConsultas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
