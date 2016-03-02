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
    public partial class frmParqueos : Form
    {
        string sCod;
        string estado = "";
        public frmParqueos( string scodParqueo, string sNumParqueo, string sCantidadParqueo, string sUbicacionParqueo)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            funActualizarGrid();

        }
        private void funActualizarGrid() {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("parqueo", "SELECT parqueo.codigo_parqueo as Codigo, parqueo.numero_parqueo as NumeroParqueo, parqueo.cantidad as CantidadDisponible, parqueo.ubicacion as Ubicacion, parqueo.estado as Estado from parqueo WHERE parqueo.estado = 'ACTIVO'", "consulta", grdParqueo);
        
        }

        private void frmParqueos_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNumero, true);
            cnegocio.funactivarDesactivarTextbox(txtCantidad, true);
            cnegocio.funactivarDesactivarTextbox(txtUbicacion, true);
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
            cnegocio.funactivarDesactivarTextbox(txtNumero, true);
            cnegocio.funactivarDesactivarTextbox(txtCantidad, true);
            cnegocio.funactivarDesactivarTextbox(txtUbicacion, true);
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
            cn.funactivarDesactivarTextbox(txtNumero, false);
            cn.funactivarDesactivarTextbox(txtCantidad, false);
            cn.funactivarDesactivarTextbox(txtUbicacion, false);
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
            cn.funactivarDesactivarTextbox(txtNumero, false);
            cn.funactivarDesactivarTextbox(txtCantidad, false);
            cn.funactivarDesactivarTextbox(txtUbicacion, false);
            txtBuscar.Visible = false;
            lblBuscar.Visible = false;
            lblNumero.Visible = true;
            txtNumero.Visible = true;
            lblCantidad.Visible = true;
            txtCantidad.Visible = true;
            lblUbicacion.Visible = true;
            txtUbicacion.Visible = true;
            txtNumero.Clear();
            txtBuscar.Clear();
            txtCantidad.Clear();
            txtUbicacion.Clear();

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
            lblNumero.Visible = false;
            txtNumero.Visible = false;
            lblCantidad.Visible = false;
            txtCantidad.Visible = false;
            lblUbicacion.Visible = false;
            txtUbicacion.Visible = false;

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
            cnegocio.funPrimero(grdParqueo);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdParqueo);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdParqueo);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdParqueo);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            if (estado.Equals("editar"))
            {
                TextBox[] aDatosEdit = { txtNumero, txtCantidad, txtUbicacion };
                string sTabla = "parqueo";
                string sCodigo = "codigo_parqueo";
                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "parqueo";
                string sCampoLlavePrimaria = "codigo_parqueo";
                string sCampoEstado = "estado";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtNumero, txtCantidad, txtUbicacion, txtEstado };
                string sTabla = "parqueo";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
            }
            estado = "";
            txtNumero.Clear();
            txtCantidad.Clear();
            txtUbicacion.Clear();
            cn.funactivarDesactivarTextbox(txtNumero, false);
            cn.funactivarDesactivarTextbox(txtCantidad, false);
            cn.funactivarDesactivarTextbox(txtUbicacion, false);
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

        private void grdParqueo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estado.Equals("editar"))
            {
                sCod = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtNumero.Text = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[1].Value.ToString();


            } if (estado.Equals("eliminar"))
            {
                sCod = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}
