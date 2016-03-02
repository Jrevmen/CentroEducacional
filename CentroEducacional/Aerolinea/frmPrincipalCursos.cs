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
    public partial class frmPrincipalCursos : Form
    {
        public frmPrincipalCursos()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("curso", "SELECT codigo_curso as Codigo, nombre as Curso, valor as Valor, creditos as Creditos, estado as Estado from curso WHERE condicion = '1'", "consulta", grdCursos);
        }

        private void grdCursos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodCurso = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombre = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sValor = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sCreditos = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[3].Value.ToString();
            frmCurso temp = new frmCurso(sCodCurso, sNombre, sValor, sCreditos);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCurso temp = new frmCurso();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdCursos);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdCursos);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdCursos);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdCursos);
        }
    }
}
