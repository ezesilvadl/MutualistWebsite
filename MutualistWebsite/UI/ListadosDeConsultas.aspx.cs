using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class ListadosDeConsultas : System.Web.UI.Page
{
    EntidadesCompartidas.Consulta ConsultaSeleccionada;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["ConsultaSel"] = null;
                List<Consulta> listaCompleta = Logica.FabricaLogica.GetLogicaConsulta().ListarTodasLasConsultas();
                Session["_listaCompleta"] = listaCompleta;
                gvConsultas.DataSource = listaCompleta;
                gvConsultas.DataBind();

                CargarPoliclinicas();
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
    private void CargarPoliclinicas()
    {
        List<Consulta> consultas = Logica.FabricaLogica.GetLogicaConsulta().ListarTodasLasConsultas();

        var policlinicas = (from c in consultas
                            select c.NumConsultorio.CodigoID.Nombre)
                            .Distinct()
                            .ToList();

        ddlPoliclinica.Items.Clear();
        ddlPoliclinica.Items.Add(new ListItem("Seleccione Policlinica:", "0"));

        foreach (var nombrePoliclinica in policlinicas)
        {
            ddlPoliclinica.Items.Add(new ListItem(nombrePoliclinica));
        }
    }
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        List<Consulta> listaCompleta = (List<Consulta>)Session["_listaCompleta"];

        try
        {
            string nombrePoliclinica = ddlPoliclinica.SelectedItem.Text;

            int anio;
            int mes;
            bool anioValido = int.TryParse(txtAnio.Text, out anio);
            bool mesValido = int.TryParse(txtMes.Text, out mes);

            if (anioValido && mesValido && ddlPoliclinica.SelectedIndex > 0)
            {
                List<Consulta> resultado = (from UnaConsulta in listaCompleta
                                            where UnaConsulta.Fecha.Year == anio
                                            && UnaConsulta.Fecha.Month == mes
                                            && UnaConsulta.NumConsultorio.CodigoID.Nombre == nombrePoliclinica
                                            select UnaConsulta).ToList();
                gvConsultas.DataSource = resultado;
                gvConsultas.DataBind();
            }
            else if (anioValido && mesValido)
            {
                List<Consulta> resultado = (from UnaConsulta in listaCompleta
                                            where UnaConsulta.Fecha.Year == anio
                                            && UnaConsulta.Fecha.Month == mes
                                            select UnaConsulta).ToList();
                gvConsultas.DataSource = resultado;
                gvConsultas.DataBind();
            }
            else if (anioValido && ddlPoliclinica.SelectedIndex > 0)
            {
                List<Consulta> resultado = (from UnaConsulta in listaCompleta
                                            where UnaConsulta.Fecha.Year == anio
                                            && UnaConsulta.NumConsultorio.CodigoID.Nombre == nombrePoliclinica
                                            select UnaConsulta).ToList();
                gvConsultas.DataSource = resultado;
                gvConsultas.DataBind();
            }
            else if (mesValido && ddlPoliclinica.SelectedIndex > 0)
            {
                List<Consulta> resultado = (from UnaConsulta in listaCompleta
                                            where UnaConsulta.Fecha.Month == mes
                                            && UnaConsulta.NumConsultorio.CodigoID.Nombre == nombrePoliclinica
                                            select UnaConsulta).ToList();
                gvConsultas.DataSource = resultado;
                gvConsultas.DataBind();
            }
            else if (anioValido)
            {
                List<Consulta> resultado = (from UnaConsulta in listaCompleta
                                            where UnaConsulta.Fecha.Year == anio
                                            select UnaConsulta).ToList();
                gvConsultas.DataSource = resultado;
                gvConsultas.DataBind();
            }
            else if (mesValido)
            {
                List<Consulta> resultado = (from UnaConsulta in listaCompleta
                                            where UnaConsulta.Fecha.Month == mes
                                            select UnaConsulta).ToList();
                gvConsultas.DataSource = resultado;
                gvConsultas.DataBind();
            }
            else if (ddlPoliclinica.SelectedIndex > 0)
            {
                List<Consulta> resultado = (from UnaConsulta in listaCompleta
                                            where UnaConsulta.NumConsultorio.CodigoID.Nombre == nombrePoliclinica
                                            select UnaConsulta).ToList();
                gvConsultas.DataSource = resultado;
                gvConsultas.DataBind();
            }
            else
            {
                gvConsultas.DataSource = listaCompleta;
                gvConsultas.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error al filtrar las consultas: " + ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtAnio.Text = "";
        txtMes.Text = "";
        ddlPoliclinica.SelectedIndex = 0;
    }
    protected void ddlPoliclinica_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvConsultas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Consulta consultaSeleccionada = Logica.FabricaLogica.GetLogicaConsulta().BuscarConsulta(Convert.ToInt32(gvConsultas.SelectedRow.Cells[0].Text));
            if (consultaSeleccionada == null)
            {
                lblError.Text = "Error al buscar la consulta seleccionada";
                Session["ConsultaSel"] = null;
            }
            else
            {
                Session["ConsultaSel"] = consultaSeleccionada;
                CargarSolicitudesConsulta(consultaSeleccionada);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error al cargar las consultas: " + ex.Message;
        }
    }
    private void CargarSolicitudesConsulta(Consulta consulta)
    {
        try
        {
            List<Solicitud> listaSolicitudes = Logica.FabricaLogica.GetLogicaSolicitud().ListarSolicitudesConsulta(consulta);

            if (listaSolicitudes != null && listaSolicitudes.Count > 0)
            {
                Session["_listaSolicitudes"] = listaSolicitudes;

                gvSolicitudes.DataSource = listaSolicitudes;
                gvSolicitudes.DataBind();
            }
            else
            {
                lblError.Text = "No se encontraron solicitudes para la consulta seleccionada.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error al cargar las solicitudes: " + ex.Message;
        }
    }
    protected void CargoConsulta()
    {

    }
    protected void gvConsultas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["_listaCompleta"] != null)
            {
                List<Consulta> listaCompleta = (List<Consulta>)Session["_listaCompleta"];

                gvConsultas.PageIndex = e.NewPageIndex;
                gvConsultas.DataSource = listaCompleta;
                gvConsultas.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error al cambiar de página: " + ex.Message;
        }
    }
    protected void gvSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["_listaSolicitudes"] != null)
            {
                List<Solicitud> listaSolicitudes = (List<Solicitud>)Session["_listaSolicitudes"];

                gvSolicitudes.PageIndex = e.NewPageIndex;
                gvSolicitudes.DataSource = listaSolicitudes;
                gvSolicitudes.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error al cambiar de página: " + ex.Message;
        }
    }
}