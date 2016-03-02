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
    public partial class frmPrincipalPensum : Form
    {
        public frmPrincipalPensum()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("pensum", "SELECT pensum.codigo_pensum as Codigo, pensum.ano as Año , concat(carrera.codigoCarrera,'.',carrera.nombre) as Carrera  from pensum, carrera WHERE pensum.condicion ='1' AND pensum.codigoCarrera = carrera.codigoCarrera", "consulta", grdPensum);
        }

        private void grdPensum_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodPensum = grdPensum.Rows[grdPensum.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sAno = grdPensum.Rows[grdPensum.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCarrera = grdPensum.Rows[grdPensum.CurrentCell.RowIndex].Cells[2].Value.ToString();
            
            frmPensum temp = new frmPensum(sCodPensum, sAno, sCarrera);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPensum temp = new frmPensum();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdPensum);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdPensum);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdPensum);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdPensum);
        }


    }
}
