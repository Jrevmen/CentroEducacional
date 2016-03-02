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
    public partial class fromPrincipalParqueos : Form
    {
        public fromPrincipalParqueos()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("parqueo", "SELECT parqueo.codigo_parqueo as Codigo, parqueo.numero_parqueo as NumeroParqueo, parqueo.cantidad as CantidadDisponible, parqueo.ubicacion as Ubicacion, parqueo.estado as Estado from parqueo WHERE parqueo.estado = 'ACTIVO'", "consulta", grdParqueoPrincipal);

        }

        private void fromPrincipalParqueos_Load(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funPrimero(grdParqueoPrincipal);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funAnterior(grdParqueoPrincipal);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funSiguiente(grdParqueoPrincipal);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funUltimo(grdParqueoPrincipal);
        }

        private void grdParqueoPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodParqueo = grdParqueoPrincipal.Rows[grdParqueoPrincipal.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNumpParqueo = grdParqueoPrincipal.Rows[grdParqueoPrincipal.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCantidadParqueo = grdParqueoPrincipal.Rows[grdParqueoPrincipal.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sUbicacionParqueo = grdParqueoPrincipal.Rows[grdParqueoPrincipal.CurrentCell.RowIndex].Cells[3].Value.ToString();
            frmParqueos temp = new frmParqueos (sCodParqueo, sNumpParqueo, sCantidadParqueo,sUbicacionParqueo);
            temp.Show();
        }
    }
}
