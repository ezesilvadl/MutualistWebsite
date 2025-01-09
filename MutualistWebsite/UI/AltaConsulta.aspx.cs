using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AltaConsulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigoID = txtCodigoID.Text.Trim();

            EntidadesCompartidas.Policlinica policlinica = Logica.FabricaLogica.GetLogicaPoliclinica().BuscarPoliclinica(codigoID);
            int numConsultorio = Convert.ToInt32(txtNumConsultorio.Text);


            EntidadesCompartidas.Consultorio consultorio = Logica.FabricaLogica.GetLogicaConsultorio().BuscarConsultorioActivo(numConsultorio, policlinica);

            if (consultorio != null)
            {
                EntidadesCompartidas.Consulta consulta = new EntidadesCompartidas.Consulta(0, Convert.ToDateTime(txtFecha.Text),
                txtMedico.Text.Trim(), txtEspecialidad.Text.Trim(), Convert.ToInt32(txtCantNumConsulta.Text), consultorio);

                Logica.FabricaLogica.GetLogicaConsulta().AltaConsulta(consulta);

                lblError.Text = "Alta con exito";
            }
            else
            {
                lblError.Text = "Error";
            }
        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }
    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        txtCantNumConsulta.Text = string.Empty;
        txtCodigoID.Text = string.Empty;
        txtEspecialidad.Text = string.Empty;
        txtFecha.Text = string.Empty;
        txtMedico.Text = string.Empty;
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
        txtCantNumConsulta.Text = string.Empty;
        txtCodigoID.Text = string.Empty;
        txtEspecialidad.Text = string.Empty;
        txtFecha.Text = string.Empty;
        txtMedico.Text = string.Empty;
        txtNumConsultorio.Text = string.Empty;
        lblError.Text = string.Empty;
    }
}