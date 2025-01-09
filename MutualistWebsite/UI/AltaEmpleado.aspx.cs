using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using modelo

public partial class AltaEmpleado : System.Web.UI.Page
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
                // Crear un nuevo empleado con los datos del formulario
                var nuevoEmpleado = new Empleado
                {
                    NomUsuario = txtNombreUsuario.Text.Trim(),
                    PassUsuario = txtContraseña.Text.Trim()
                };

                // Agregar el nuevo empleado al contexto
                context.Empleado.Add(nuevoEmpleado);
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
        txtNombreUsuario.Text = string.Empty;
        txtContraseña.Text = string.Empty;
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
        txtContraseña.Text = "";
        txtNombreUsuario.Text = "";
    }
}
