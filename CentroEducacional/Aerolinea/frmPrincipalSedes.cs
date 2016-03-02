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
    public partial class frmPrincipalSedes : Form
    {
        public frmPrincipalSedes()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("sedes", "SELECT codigo_sede as Codigo,nombre as Nombre, ubicacion as Ubicacion, estado as Estado from sedes WHERE condicion = '1'", "consulta", grdSedes);
        }

        private void grdSedes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodigo = grdSedes.Rows[grdSedes.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombre = grdSedes.Rows[grdSedes.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sUbicacion = grdSedes.Rows[grdSedes.CurrentCell.RowIndex].Cells[2].Value.ToString();
            frmSedes temp = new frmSedes(sCodigo, sNombre, sUbicacion);
            temp.Show();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("sedes", "SELECT codigo_sede as Codigo,nombre as Nombre, ubicacion as Ubicacion, estado as Estado from sedes WHERE condicion = '1' AND nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdSedes);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmSedes temp = new frmSedes();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdSedes);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdSedes);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdSedes);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdSedes);
        }
    }
}
