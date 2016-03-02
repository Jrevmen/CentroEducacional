using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using ConexionODBC;

namespace Aerolinea
{
    public partial class frmreporteUsuarios : Form
    {
        public frmreporteUsuarios()
        {
            InitializeComponent();
        }

        private void fromreporteUsuarios_Load(object sender, EventArgs e)
        {
            funllenarGridReporte();
            funllenarGridReporteGeneral();
        }

        private void funllenarGridReporte()
        {
            string squery = "SELECT codigo_usuario as NombreUsuario, accion as Accion, count(accion) as transacciones from BITACORA group by accion";
            OdbcCommand cmdc = new OdbcCommand(squery, ConexionODBC.Conexion.ObtenerConexion());
            DataTable dtDatos = new DataTable();
            OdbcDataAdapter mdaDatos = new OdbcDataAdapter(squery, ConexionODBC.Conexion.ObtenerConexion());
            mdaDatos.Fill(dtDatos);
            grdReporte.DataSource = dtDatos;
        }

        private void funllenarGridReporteGeneral()
        {
            string squery = "SELECT codigo_usuario as NombreUsuario, count(accion) as transacciones from BITACORA group by codigo_usuario";
            OdbcCommand cmdc = new OdbcCommand(squery, ConexionODBC.Conexion.ObtenerConexion());
            DataTable dtDatos = new DataTable();
            OdbcDataAdapter mdaDatos = new OdbcDataAdapter(squery, ConexionODBC.Conexion.ObtenerConexion());
            mdaDatos.Fill(dtDatos);
            grdReporte2.DataSource = dtDatos;
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rEFRESCARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funllenarGridReporte();
            funllenarGridReporte();
        }

    }
}
