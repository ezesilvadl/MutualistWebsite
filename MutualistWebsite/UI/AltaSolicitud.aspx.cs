using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AltaSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Empleado empleado = (EntidadesCompartidas.Empleado)Session["Empleado"];

            string nomUsuario = empleado.NomUsuario;

            int numSeleccionado = Convert.ToInt32(txtCodigoC.Text);
            EntidadesCompartidas.Consulta consulta = Logica.FabricaLogica.GetLogicaConsulta().BuscarConsulta(numSeleccionado);
            
            int cedula = Convert.ToInt32(txtCedula.Text);
            EntidadesCompartidas.Paciente paciente = Logica.FabricaLogica.GetLogicaPaciente().BuscarPacienteActivo(cedula);


            if (consulta != null)
            {
                EntidadesCompartidas.Solicitud solicitud = new EntidadesCompartidas.Solicitud(0, Convert.ToInt32(txtNumSeleccionado.Text), false, consulta, paciente, empleado);

                Logica.FabricaLogica.GetLogicaSolicitud().AltaSolicitud(solicitud);

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
        txtCodigoC.Text = string.Empty;
        txtCedula.Text = string.Empty;
        txtNumSeleccionado.Text = string.Empty;

        lblError.Text = string.Empty;
    }

}