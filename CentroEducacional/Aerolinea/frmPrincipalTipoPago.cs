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
    public partial class frmPrincipalTipoPago : Form
    {
        public frmPrincipalTipoPago()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("tipo_pago", "SELECT cod_tipo_pago as Codigo, Descripcion as Descripcion, Cuotas as Cuotas, estado as Estado from tipo_pago WHERE condicion = '1'", "consulta", grdPago);
        }

        private void grdPago_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodPago = grdPago.Rows[grdPago.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sDescripcion = grdPago.Rows[grdPago.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCuotas = grdPago.Rows[grdPago.CurrentCell.RowIndex].Cells[2].Value.ToString();
            frmTipoPago temp = new frmTipoPago(sCodPago, sDescripcion, sCuotas);
            temp.Show();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("tipo_pago", "SELECT cod_tipo_pago as Codigo, Descripcion as Descripcion, Cuotas as Cuotas, estado as Estado from tipo_pago WHERE condicion = '1' AND descripcion LIKE '" + txtBuscar.Text + "%'", "consulta", grdPago);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmTipoPago temp = new frmTipoPago();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdPago);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdPago);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdPago);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdPago);
        }
    }
}
