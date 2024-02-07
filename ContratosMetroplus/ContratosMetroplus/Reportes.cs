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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            /*Muestra el Formulario*/
            InitializeComponent();
            /*Centra el fromulario en la pantalla*/
            this.CenterToScreen();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        /*Metodo Generar Informe - Boton Boton Generar Informe*/
        private void button1_Click(object sender, EventArgs e)
        {
            /*Creo una variable de la clase EntidadesContrato*/
            var a = new EntidadesContrato();
            /*Creo la conexion  a la base de datos*/
            var entityConnection = a.Database.Connection;
            /*Variable fecha1*/
            DateTime fecha1 = dt1.Value;
            /*Variable fecha1*/
            DateTime fecha2 = dt2.Value;
            /*Crea la conexion del FormularioReporte por fechas*/
            var oReport = new FrmReporte((SqlConnection)entityConnection, fecha1, fecha2);
            /*Muestra los datos*/
            oReport.Show();
        }
    }
}
