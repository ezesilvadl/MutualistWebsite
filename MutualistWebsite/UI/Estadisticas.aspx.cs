using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class Estadisticas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarEstadisticasSolicitudes();
            CargarEstadisticasConsultas();
        }
    }
    private void CargarEstadisticasSolicitudes()
    {
        List<Solicitud> solicitudes = Logica.FabricaLogica.GetLogicaSolicitud().ListarTodasLasSolicitudes();

        var solicitudesPorAsistencia = (from s in solicitudes
                                        group s by s.AsistioONo into g
                                        select new
                                        {
                                            TipoAsistencia = g.Key ? "Con Asistencia" : "Sin Asistencia",
                                            Cantidad = g.Count()
                                        }).ToList();

        gvSolicitudesAsistencia.DataSource = solicitudesPorAsistencia;
        gvSolicitudesAsistencia.DataBind();
    }
    private void CargarEstadisticasConsultas()
    {
        List<Consulta> consultas = Logica.FabricaLogica.GetLogicaConsulta().ListarTodasLasConsultas();

        var consultasPorConsultorio = (from c in consultas
                                       group c by new { c.NumConsultorio.CodigoID.Nombre, c.NumConsultorio.NumConsultorio } into g
                                       orderby g.Key.Nombre, g.Key.NumConsultorio
                                       select new
                                       {
                                           Policlínica = g.Key.Nombre,
                                           Consultorio = g.Key.NumConsultorio,
                                           CantidadConsultas = g.Count()
                                       }).ToList();

        gvConsultasPorConsultorio.DataSource = consultasPorConsultorio;
        gvConsultasPorConsultorio.DataBind();
    }


}