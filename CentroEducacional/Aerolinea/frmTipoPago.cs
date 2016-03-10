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
    public partial class frmTipoPago : Form
    {
        string estado = "";
        string sCod;
        public frmTipoPago()
        {
            InitializeComponent();
        }

        public frmTipoPago(string sCodPago, string sDescripcion, string sCuotas)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            sCod = sCodPago;
            txtDescripcion.Text = sDescripcion;
            txtCuotas.Text = sCuotas;
            
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmTipoPago");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtCuotas.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtDescripcion, true);
            cnegocio.funactivarDesactivarTextbox(txtCuotas, true);
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
            cnegocio.funactivarDesactivarTextbox(txtDescripcion, true);
            cnegocio.funactivarDesactivarTextbox(txtCuotas, true);
            //txtNombre.Clear();
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
            cn.funactivarDesactivarTextbox(txtDescripcion, false);
            cn.funactivarDesactivarTextbox(txtCuotas, false);
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;


            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtDescripcion, txtCuotas };
                string sTabla = "tipo_pago";
                string sCodigo = "cod_tipo_pago";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "tipo_pago";
                string sCampoLlavePrimaria = "cod_tipo_pago";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtDescripcion, txtCuotas, txtEstado, txtCondicion };
                string sTabla = "tipo_pago";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }

            estado = "";
            txtDescripcion.Clear();
            txtCuotas.Clear();
            cn.funactivarDesactivarTextbox(txtDescripcion, false);
            cn.funactivarDesactivarTextbox(txtCuotas, false);
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funactivarDesactivarTextbox(txtDescripcion, false);
            cn.funactivarDesactivarTextbox(txtCuotas, false);
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            lblCuotas.Visible = true;
            txtCuotas.Visible = true;
            txtDescripcion.Clear();
            txtCuotas.Clear();

            /*
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmTipoPago");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            */
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void grdPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTipoPago_Load(object sender, EventArgs e)
        {

        }
    }
}
