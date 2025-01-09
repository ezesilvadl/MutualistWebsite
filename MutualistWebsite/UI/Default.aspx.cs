using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargoGrilla();
        }
    }
    protected void CargoGrilla()
    {
        GridViewConsultas.DataSource = Logica.FabricaLogica.GetLogicaConsulta().ListarConsultasPendientes();
        GridViewConsultas.DataBind();
    }
    protected void Logueo_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            string _Usu = LoginControl.UserName.Trim();
            string _Pass = LoginControl.Password.Trim();
            EntidadesCompartidas.Empleado _unCli = Logica.FabricaLogica.GetLogicaEmpleado().Logueo(_Usu, _Pass);

            if (_unCli == null)
                LblError.Text = "Usuario o pass invalidos";
            else
            {
                Session["Empleado"] = _unCli;
                Session["UsuarioNombre"] = _unCli.NomUsuario;
                Response.Redirect("~/Principal.aspx");
            }
        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
    }
    protected void GridViewConsultas_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridViewConsultas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewConsultas.PageIndex = e.NewPageIndex;
        CargoGrilla();
    }
}