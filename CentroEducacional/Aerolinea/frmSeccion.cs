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
    public partial class frmSeccion : Form
    {
        string sCod;
        string estado = "";

        public frmSeccion( string sCodSeccion, string sSeccion)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            funActualizarGrid();

        }

        private void funActualizarGrid() {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("seccion", "SELECT seccion.codigo_seccion as Codigo, seccion.nombre as Nombre, seccion.estado as Estado from seccion WHERE seccion.estado = 'ACTIVO'", "consulta", grdSeccion);
        
        }

        private void frmSeccion_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
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
            txtBuscar.Visible = false;
            lblBuscar.Visible = false;
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            txtNombre.Clear();
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
            lblNombre.Visible = false;
            txtNombre.Visible = false;

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
            cnegocio.funPrimero(grdSeccion);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdSeccion);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdSeccion);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdSeccion);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            if (estado.Equals("editar"))
            {
                TextBox[] aDatosEdit = { txtNombre };
                string sTabla = "seccion";
                string sCodigo = "codigo_seccion";
                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "seccion";
                string sCampoLlavePrimaria = "codigo_seccion";
                string sCampoEstado = "estado";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtNombre, txtEstado};
                string sTabla = "seccion";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
            }
            estado = "";
            txtNombre.Clear();
            cn.funactivarDesactivarTextbox(txtNombre, false);
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

        private void grdSeccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estado.Equals("editar"))
            {
                sCod = grdSeccion.Rows[grdSeccion.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = grdSeccion.Rows[grdSeccion.CurrentCell.RowIndex].Cells[1].Value.ToString();


            } if (estado.Equals("eliminar"))
            {
                sCod = grdSeccion.Rows[grdSeccion.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}
