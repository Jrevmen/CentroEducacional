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
    public partial class frmPrincipalJornada : Form
    {
        public frmPrincipalJornada()
        {
            InitializeComponent();
            funAcatualizarGrid();
        }

        private void funAcatualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("jornada", "SELECT jornada.codigoJornada as Codigo, jornada.nombre as Nombre, jornada.horario as HorarioJornada, jornada.estado as Estado from jornada WHERE jornada.estado ='ACTIVO'", "consulta", grdJornadaPrincipal);


        }
        private void frmPrincipalJornada_Load(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funAcatualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funPrimero(grdJornadaPrincipal);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funAnterior(grdJornadaPrincipal);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funSiguiente(grdJornadaPrincipal);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funUltimo(grdJornadaPrincipal);
        }

        private void grdJornadaPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodJornada = grdJornadaPrincipal.Rows[grdJornadaPrincipal.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombre = grdJornadaPrincipal.Rows[grdJornadaPrincipal.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sHorario = grdJornadaPrincipal.Rows[grdJornadaPrincipal.CurrentCell.RowIndex].Cells[2].Value.ToString();
            frmJornada temp = new frmJornada(sCodJornada, sNombre, sHorario);
            temp.Show();
        }
    }
}
