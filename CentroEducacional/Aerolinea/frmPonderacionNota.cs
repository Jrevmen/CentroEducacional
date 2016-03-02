using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navegador;

namespace Aerolinea
{
    public partial class frmPonderacionNota : Form
    {
        public frmPonderacionNota()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("curso", "SELECT codigo_curso, nombre, valor, creditos, estado FROM curso WHERE estado = 'ACTIVO'", "consulta", grdNota);
        }

        private void grdNota_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodNota = grdNota.Rows[grdNota.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNota = grdNota.Rows[grdNota.CurrentCell.RowIndex].Cells[1].Value.ToString();
            /*frmNota temp = new frmNota(sCodNota, sNota);
            temp.Show();*/
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("curso", "SELECT codigo_curso, nombre, valor, creditos, estado FROM curso WHERE estado = 'ACTIVO' AND nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdNota);
        }

    }
}
