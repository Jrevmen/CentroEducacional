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
    public partial class frmPrincipalFacultad : Form
    {
        public frmPrincipalFacultad()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("facultad", "SELECT codigoFacultad as Codigo,nombre as Nombre, estado as Estado from facultad WHERE condicion = '1'", "consulta", grdFacultad);
        }

        private void grdFacultad_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodFacultad = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sFacultad = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmFacultad temp = new frmFacultad(sCodFacultad, sFacultad);
            temp.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("facultad", "SELECT codigoFacultad as Codigo, nombre as Nombre , estado as Estado  from facultad WHERE condicion = '1' AND nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdFacultad);

            //funFiltrar("query llenado", "SELECT codigoFacultad as Codigo, nombre as Nombre , estado as Estado  from facultad WHERE condicion = '1' AND nombre LIKE '", codigo_usuario, nombre_usuario);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmFacultad temp = new frmFacultad();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdFacultad);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdFacultad);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdFacultad);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdFacultad);
        }

    }
}
