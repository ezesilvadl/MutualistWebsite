using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMPacientes : System.Web.UI.Page
{
    EntidadesCompartidas.Paciente PacienteSeleccionado;
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
    private List<string> CargoListaPatologias()
    {
        List<string> listaPatologias = new List<string>();

        foreach (ListItem item in LbPatologias.Items)
        {
            listaPatologias.Add(item.Text.Trim());
        }

        return listaPatologias;
    }
    protected void BtnBusco_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Paciente _unPaciente = null;
            _unPaciente = Logica.FabricaLogica.GetLogicaPaciente().BuscarPacienteActivo(Convert.ToInt32(txtCedula.Text));
            this.LimpioControles();


            if (_unPaciente == null)
            {
                BtnAlta.Enabled = true;
            }
            else
            {
                BtnModificar.Enabled = true;
                BtnBaja.Enabled = true;
                Session["Empleado"] = _unPaciente;
                txtCedula.Text = _unPaciente.Cedula.ToString();
                txtNombre.Text = _unPaciente.Nombre;
                txtFechaNac.Text = _unPaciente.FechaNac.ToShortDateString();
                LbPatologias.DataSource = _unPaciente.Patologias;
                LbPatologias.DataBind();
                LbPatologias.SelectedIndex = -1;

            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Paciente _unPaciente = null;
            _unPaciente = new EntidadesCompartidas.Paciente(Convert.ToInt32(txtCedula.Text), txtNombre.Text.Trim(), Convert.ToDateTime(txtFechaNac.Text)
                , CargoListaPatologias());
            Logica.FabricaLogica.GetLogicaPaciente().AltaPaciente(_unPaciente);
            this.DesActivoBotones();
            this.LimpioControles();

            LblError.Text = "Alta con Exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Paciente _unPaciente = (EntidadesCompartidas.Paciente)Session["Empleado"];
            Logica.FabricaLogica.GetLogicaPaciente().Eliminar(_unPaciente);
            this.DesActivoBotones();
            this.LimpioControles();

            LblError.Text = "Baja con Exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Paciente _unPaciente = (EntidadesCompartidas.Paciente)Session["Empleado"];
            _unPaciente.Cedula = Convert.ToInt32(txtCedula.Text);
            _unPaciente.Nombre = txtNombre.Text.Trim();
            _unPaciente.FechaNac = Convert.ToDateTime(txtFechaNac.Text);
            _unPaciente.Patologias = CargoListaPatologias();
            Logica.FabricaLogica.GetLogicaPaciente().Modificar(_unPaciente);
            this.DesActivoBotones();
            this.LimpioControles();

            LblError.Text = "Modificacion con Exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {

        Session["Empleado"] = null;
        this.DesActivoBotones();
        this.LimpioControles();
    }
    private void DesActivoBotones()
    {
        //BtnAgregar.Enabled = false;
        //BtnLimpiar.Enabled = true;
    }
    private void ActivoBotones()
    {
        //BtnAgregar.Enabled = true;
        //BtnLimpiar.Enabled = true;
    }
    private void LimpioControles()
    {
        txtCedula.Text = "";
        txtNombre.Text = "";
        txtFechaNac.Text = "";
        txtPatologias.Text = "";

        LbPatologias.Items.Clear();
        LbPatologias.SelectedIndex = -1;
    }
    protected void BtnBorrarPat_Click(object sender, EventArgs e)
    {
        if (LbPatologias.SelectedIndex >= 0)
        {
            LbPatologias.Items.RemoveAt(LbPatologias.SelectedIndex);
            LblError.Text = "Eliminacion de patología de la Lista con éxito";
        }
        else
            LblError.Text = "Debe Seleccionar una patología de la lista para eliminar";
    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        if (txtPatologias.Text.Trim().Length > 0)
        {
            LbPatologias.Items.Add(txtPatologias.Text.Trim());
            txtPatologias.Text = "";
            LblError.Text = "Se agrego Correctamente la patología a la Lista";
        }
        else
            LblError.Text = "No Hay nada ingresado - No se agrega patología a la lista";
    }
}