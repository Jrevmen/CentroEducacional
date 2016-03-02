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
    public partial class frmbitacora : Form
    {
        public frmbitacora()
        {
            InitializeComponent();
        }
        private void funllenarGridBitacora()
        {
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "CONSULTA", "BITACORA");
            string squery = "SELECT bitacora.accion, bitacora.tabla, bitacora.fecha, usuario.nombre_usuario, bitacora.ip, bitacora.hora from BITACORA, USUARIO WHERE usuario.codigo_usuario = bitacora.codigo_usuario";
            OdbcCommand cmdc = new OdbcCommand(squery, ConexionODBC.Conexion.ObtenerConexion());
            DataTable dtDatos = new DataTable();
            OdbcDataAdapter mdaDatos = new OdbcDataAdapter(squery, ConexionODBC.Conexion.ObtenerConexion());
            mdaDatos.Fill(dtDatos);
            grdBitacora.DataSource = dtDatos;
        }
        private void frmbitacora_Load(object sender, EventArgs e)
        {
            funllenarGridBitacora();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funllenarGridBitacora();
        }
    }
}
