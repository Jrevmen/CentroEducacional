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
    public partial class frmPrincipalSalones : Form
    {
        public frmPrincipalSalones()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("salon", "SELECT salon.codigo_salon as Codigo, salon.nombre_salon as Nombre, salon.cupo as Cupo, salon.estado as Estado, concat(sedes.codigo_sede,'.',sedes.nombre) as Sede  from salon, sedes WHERE salon.condicion = '1' AND sedes.codigo_sede = salon.codigo_sede", "consulta", grdSalones);
        }

        private void grdSalones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodSalon = grdSalones.Rows[grdSalones.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombre = grdSalones.Rows[grdSalones.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCupo = grdSalones.Rows[grdSalones.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sSede = grdSalones.Rows[grdSalones.CurrentCell.RowIndex].Cells[4].Value.ToString();
            frmSalones temp = new frmSalones(sCodSalon,sNombre,sCupo, sSede);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmSalones temp = new frmSalones();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdSalones);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdSalones);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdSalones);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdSalones);
        }

    }
}
