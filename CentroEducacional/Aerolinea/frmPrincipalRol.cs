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
    public partial class frmPrincipalRol : Form
    {
        public frmPrincipalRol()
        {
            InitializeComponent();
            funActualizargrid();
        }
        private void funActualizargrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("rol", "SELECT rol.codigo_rol as Codigo, rol.tipo as TipoRol, rol.descripcion as Descripcion, rol.estado as Estado from rol WHERE rol.estado = 'ACTIVO'", "consulta", grdrRolPrincipal);
        }

        private void frmPrincipalRol_Load(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizargrid();
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("rol", " SELECT rol.codigo_rol as Codigo, rol.tipo as TipoRol, rol.descripcion as Descripcion, rol.estado as Estado WHERE rol.estado = 'ACTIVO' rol.tipo LIKE '" + txtBuscar.Text + "%'", "consulta", grdrRolPrincipal);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodTipo = grdrRolPrincipal.Rows[grdrRolPrincipal.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sTipo = grdrRolPrincipal.Rows[grdrRolPrincipal.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sDescripcion = grdrRolPrincipal.Rows[grdrRolPrincipal.CurrentCell.RowIndex].Cells[2].Value.ToString();
            frmRol temp = new frmRol (sCodTipo, sTipo, sDescripcion);
            temp.Show();
        }
        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdrRolPrincipal);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdrRolPrincipal);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdrRolPrincipal);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdrRolPrincipal);
        }
    }
}
