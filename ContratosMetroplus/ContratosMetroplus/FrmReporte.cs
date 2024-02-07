using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContratosMetroplus
{
    public partial class FrmReporte : Form
    {
        public FrmReporte(SqlConnection conn, DateTime fecha1, DateTime fecha2)
        {
            InitializeComponent();
            this.CenterToScreen();
            var adp = new SqlDataAdapter();
            var Reporte = new ReportDocument();

            var comm = new SqlCommand(@"select NumContrato, ClaseContrato, SectorCorrespondiente, 
                                      ObjetoContrato, NombreCompletoContratista from Personas where 
                                      FechaSuscripcion between @fecha1 and @fecha2", conn);

            comm.Parameters.Add(new SqlParameter("fecha1", fecha1));
            comm.Parameters.Add(new SqlParameter("fecha2", fecha2));

            adp.SelectCommand = comm;

            var datatable = new DataTable();
            adp.Fill(datatable);

            Reporte.Load("ReporteContratos.rpt");
            Reporte.SetDataSource(datatable);
            crystalReportViewer1.ReportSource = Reporte;
        }
    }
}
