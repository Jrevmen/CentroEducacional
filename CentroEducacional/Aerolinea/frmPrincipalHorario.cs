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
    public partial class frmPrincipalHorario : Form
    {
        public frmPrincipalHorario()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("horario", "SELECT horario.codigoHorario as Codigo, horario.rangoHora as Horario, horario.estado as Estado from horario WHERE horario.estado='ACTIVO'", "consulta", grdHorarioPrincipal);
        }

        private void frmPrincipalHorario_Load(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funPrimero(grdHorarioPrincipal);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funAnterior(grdHorarioPrincipal);

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funSiguiente(grdHorarioPrincipal);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funUltimo(grdHorarioPrincipal);
        }

        private void grdHorarioPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodHorario = grdHorarioPrincipal.Rows[grdHorarioPrincipal.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sRango = grdHorarioPrincipal.Rows[grdHorarioPrincipal.CurrentCell.RowIndex].Cells[1].Value.ToString();
            
            frmHorario temp = new frmHorario(sCodHorario, sRango);
            temp.Show();
        }
    }
}
