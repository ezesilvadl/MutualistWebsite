using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMConsultorio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Empleado"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigoID = txtCodigoID.Text.Trim();

            EntidadesCompartidas.Policlinica policlinica = Logica.FabricaLogica.GetLogicaPoliclinica().BuscarPoliclinica(codigoID);

            if (policlinica != null)
            {
                EntidadesCompartidas.Consultorio _unConsultorio = Logica.FabricaLogica.GetLogicaConsultorio().BuscarConsultorioActivo(
                    Convert.ToInt32(txtNumConsultorio.Text), policlinica);

                if (_unConsultorio == null)
                {
                    BtnAgregar.Enabled = true;
                    lblError.Text = "No se encontró un consultorio activo con los datos proporcionados.";
                }
                else
                {
                    BtnModificar.Enabled = true;
                    BtnBaja.Enabled = true;
                    Session["Empleado"] = _unConsultorio;
                    txtNumConsultorio.Text = _unConsultorio.NumConsultorio.ToString();
                    txtCodigoID.Text = _unConsultorio.CodigoID.CodigoID;
                    txtDescripcion.Text = _unConsultorio.Descripcion;
                }
            }
            else
            {
                lblError.Text = "Policlinica no encontrada.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigoID = txtCodigoID.Text.Trim();

            EntidadesCompartidas.Policlinica policlinica = Logica.FabricaLogica.GetLogicaPoliclinica().BuscarPoliclinica(codigoID);

            if (policlinica != null)
            {
                EntidadesCompartidas.Consultorio _unConsultorio = new EntidadesCompartidas.Consultorio(
                    Convert.ToInt32(txtNumConsultorio.Text),
                    txtDescripcion.Text.Trim(),
                    policlinica
                );

                Logica.FabricaLogica.GetLogicaConsultorio().AltaConsultorio(_unConsultorio);


                lblError.Text = "Alta con éxito";
            }
            else
            {
                lblError.Text = "Policlinica no encontrada.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try { 
        
            string codigoID = txtCodigoID.Text.Trim();

            EntidadesCompartidas.Policlinica policlinica = Logica.FabricaLogica.GetLogicaPoliclinica().BuscarPoliclinica(codigoID);

            if (policlinica != null)
            {
                EntidadesCompartidas.Consultorio _unConsultorio = new EntidadesCompartidas.Consultorio(
                    Convert.ToInt32(txtNumConsultorio.Text),
                    txtDescripcion.Text.Trim(),
                    policlinica
                );

                Logica.FabricaLogica.GetLogicaConsultorio().Eliminar(_unConsultorio);

                lblError.Text = "Baja con éxito";
            }
            else
            {
                lblError.Text = "Policlinica no encontrada.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigoID = txtCodigoID.Text.Trim();

            EntidadesCompartidas.Policlinica policlinica = Logica.FabricaLogica.GetLogicaPoliclinica().BuscarPoliclinica(codigoID);

            if (policlinica != null)
            {
                EntidadesCompartidas.Consultorio _unConsultorio = new EntidadesCompartidas.Consultorio(
                    Convert.ToInt32(txtNumConsultorio.Text),
                    txtDescripcion.Text.Trim(),
                    policlinica
                );

                Logica.FabricaLogica.GetLogicaConsultorio().Modificar(_unConsultorio);


                lblError.Text = "Modificación con éxito";
            }
            else
            {
                lblError.Text = "Policlinica no encontrada.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodigoID.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
        txtNumConsultorio.Text = string.Empty;
        lblError.Text = string.Empty;
        this.ActivoBotones();
    }
    private void DesActivoBotones()
    {
        BtnAgregar.Enabled = false;
        BtnLimpiar.Enabled = true;
    }
    private void ActivoBotones()
    {
        BtnAgregar.Enabled = true;
        BtnLimpiar.Enabled = true;
    }
    private void LimpioControles()
    {
        txtCodigoID.Text = "";
        txtDescripcion.Text = "";
        txtNumConsultorio.Text = "";
    }
}