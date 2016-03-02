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
    public partial class frmPrincipalSeccion : Form
    {
        public frmPrincipalSeccion()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("seccion", "SELECT seccion.codigo_seccion as Codigo, seccion.nombre as Nombre, seccion.estado as Estado from seccion WHERE seccion.estado = 'ACTIVO'", "consulta", grdSeccionesPrincipal);

        }

        private void frmPrincipalSeccion_Load(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }
        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdSeccionesPrincipal);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdSeccionesPrincipal);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdSeccionesPrincipal);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdSeccionesPrincipal);
        }

        private void grdSeccionesPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodSeccion = grdSeccionesPrincipal.Rows[grdSeccionesPrincipal.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sSeccion = grdSeccionesPrincipal.Rows[grdSeccionesPrincipal.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmSeccion temp = new frmSeccion (sCodSeccion, sSeccion);
            temp.Show();
        }

        private void btnIrPrimero_Click_1(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdSeccionesPrincipal);
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdSeccionesPrincipal);
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdSeccionesPrincipal);
        }

        private void btnIrUltimo_Click_1(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdSeccionesPrincipal);
        }
    }
}
