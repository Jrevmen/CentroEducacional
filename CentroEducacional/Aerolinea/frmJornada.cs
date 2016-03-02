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
using ConexionODBC;

namespace Aerolinea
{
    public partial class frmJornada : Form
    {
        string sCod;
        string estado = "";
        public frmJornada( string sCodJornada, string sNombre, string sHorario)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            funAcatualizarGrid();
        }

        private void funAcatualizarGrid() {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("jornada", "SELECT jornada.codigoJornada as Codigo, jornada.nombre as Nombre, jornada.horario as HorarioJornada, jornada.estado as Estado from jornada WHERE jornada.estado ='ACTIVO'", "consulta", grdJornada);
        
        
        }


        private void frmJornada_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
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
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
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
            cn.funactivarDesactivarTextbox(txtNombre, false);
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
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarTextbox(txtHorario, false);
            txtBuscar.Visible = false;
            lblBuscar.Visible = false;
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            lblHorario.Visible = true;
            txtHorario.Visible = true;
            txtNombre.Clear();
            txtBuscar.Clear();
            txtHorario.Clear();

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
            funAcatualizarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            lblBuscar.Visible = true;
            lblNombre.Visible = false;
            txtNombre.Visible = false;
            lblHorario.Visible = false;
            txtHorario.Visible = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdJornada);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdJornada);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdJornada);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdJornada);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            if (estado.Equals("editar"))
            {
                TextBox[] aDatosEdit = { txtNombre, txtHorario };
                string sTabla = "jornada";
                string sCodigo = "codigoJornada";
                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "jornada";
                string sCampoLlavePrimaria = "codigoJornada";
                string sCampoEstado = "estado";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtNombre, txtHorario, txtEstado };
                string sTabla = "jornada";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
            }
            estado = "";
            txtNombre.Clear();
            txtHorario.Clear();
            cn.funactivarDesactivarTextbox(txtNombre, false);
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
            funAcatualizarGrid();
        }

        private void grdJornada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estado.Equals("editar"))
            {
                sCod = grdJornada.Rows[grdJornada.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = grdJornada.Rows[grdJornada.CurrentCell.RowIndex].Cells[1].Value.ToString();


            } if (estado.Equals("eliminar"))
            {
                sCod = grdJornada.Rows[grdJornada.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("jornada", " SELECT jornada.codigoJornada as Codigo, jornada.nombre as Nombre, jornada.horario as Horario, jornada.estado as Estado from jornada WHERE jornada.estado = 'ACTIVO' AND jornada.nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdJornada);
        }
    }

}
