using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionODBC;
using Navegador;

namespace Aerolinea
{
    public partial class frmHorario : Form
    {
        string sCod;
        string estado = "";
        public frmHorario( string sCodHorario, string sRango)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            funActualizarGrid();
        }
        private void funActualizarGrid() {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("horario", "SELECT horario.codigoHorario as Codigo, horario.rangoHora as Horario, horario.estado as Estado from horario WHERE horario.estado='ACTIVO'", "consulta", grdHorario);
        }

        private void frmHorario_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtHorario, true);
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estado = "editar";
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtHorario, true);
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            estado = "eliminar";
            clasnegocio cn = new clasnegocio();
            cn.funactivarDesactivarTextbox(txtHorario, false);
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
            btnAnterior.Enabled = false;
            btnIrPrimero.Enabled = false;
            btnSiguiente.Enabled = false;
            btnIrUltimo.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funactivarDesactivarTextbox(txtHorario, false);
            txtBuscar.Visible = false;
            lblBuscar.Visible = false;
            lblRango.Visible = true;
            txtHorario.Visible = true;
            txtHorario.Clear();
            txtBuscar.Clear();

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
            btnAnterior.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnSiguiente.Enabled = true;
            btnIrUltimo.Enabled = true;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            lblBuscar.Visible = true;
            lblRango.Visible = false;
            txtHorario.Visible = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("horario", " SELECT horario.codgioHorario as Codigo, horario.rangoHora as Horario, horario.estado as Estado WHERE carrera.estado = 'ACTIVO' AND horario.rangoHora LIKE '" + txtBuscar.Text + "%'", "consulta", grdHorario);
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdHorario);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdHorario);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdHorario);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdHorario);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            if (estado.Equals("editar"))
            {
                TextBox[] aDatosEdit = { txtHorario };
                string sTabla = "horario";
                string sCodigo = "codigoHorario";
                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "horario";
                string sCampoLlavePrimaria = "codigoHorario";
                string sCampoEstado = "estado";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtHorario, txtEstado};
                string sTabla = "horario";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
            }
            estado = "";
            txtHorario.Clear();
            cn.funactivarDesactivarTextbox(txtHorario, false);
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
            btnAnterior.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnSiguiente.Enabled = true;
            btnIrUltimo.Enabled = true;
            funActualizarGrid();
        }

        private void grdHorario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estado.Equals("editar"))
            {
                sCod = grdHorario.Rows[grdHorario.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtHorario.Text = grdHorario.Rows[grdHorario.CurrentCell.RowIndex].Cells[1].Value.ToString();


            } if (estado.Equals("eliminar"))
            {
                sCod = grdHorario.Rows[grdHorario.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

    }
}
