using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using modelo

public partial class AltaPoliclinica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new MutualistWebsiteEFEntities())
            {
                // Crear una nueva policlínica con los datos del formulario
                var nuevaPoliclinica = new Policlinica
                {
                    CodigoID = txtCodigoID.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                // Agregar la nueva policlínica al contexto
                context.Policlinica.Add(nuevaPoliclinica);
                context.SaveChanges();

                // Mensaje de éxito y limpieza de controles
                lblError.Text = "Alta con éxito";
                DesActivoBotones();
                LimpioControles();
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
        txtNombre.Text = string.Empty;
        txtDireccion.Text = string.Empty;
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
        txtNombre.Text = "";
        txtDireccion.Text = "";
    }
}