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
    public partial class frmTipoServicio : Form
    {
        string estado = "";
        string sCod;
        public frmTipoServicio()
        {
            InitializeComponent();
        }

        public frmTipoServicio(string sCodServicio, string sDescripcion, string sFecha, string sMonto, string sAccion)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;

            sCod = sCodServicio;
            txtDescripcion.Text = sDescripcion;
            dtpFecha.Value = Convert.ToDateTime(sFecha);
            txtMonto.Text = sMonto;
            int index = cmbAccion.FindString(sAccion);
            cmbAccion.SelectedIndex = index;
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmTipoServicio");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
        }

       

        string funCortador(string sDato)
        {
            string sCadena = "";
            try
            {
                for (int i = 0; i < sDato.Length; i++)
                {
                    if (sDato.Substring(i, 1) != ".")
                    {
                        sCadena = sCadena + sDato.Substring(i, 1);
                    }
                    else
                    {
                        break;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error al obtener Codigo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return sCadena;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtMonto.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtDescripcion, true);
            cnegocio.funactivarDesactivarTextbox(txtMonto, true);
            dtpFecha.Enabled = true;
            cnegocio.funactivarDesactivarCombobox(cmbAccion, true);
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
            cnegocio.funactivarDesactivarTextbox(txtMonto, true);
            dtpFecha.Enabled = true;
            cnegocio.funactivarDesactivarCombobox(cmbAccion, true);
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
            cn.funactivarDesactivarTextbox(txtMonto, false);
            dtpFecha.Enabled = false;
            cn.funactivarDesactivarCombobox(cmbAccion, false);
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

            txtAccion.Text = cmbAccion.Text;
            txtFecha.Text = dtpFecha.Text;
            //System.Console.WriteLine("*************dtpFecha: " + dtpFecha.Text);

            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtDescripcion, txtFecha, txtMonto, txtAccion };
                string sTabla = "tipo_servicio";
                string sCodigo = "codigo_tipo_servicio";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "tipo_servicio";
                string sCampoLlavePrimaria = "codigo_tipo_servicio";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtDescripcion, txtFecha, txtMonto, txtAccion, txtEstado, txtCondicion };
                string sTabla = "tipo_servicio";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }

            estado = "";
            txtDescripcion.Clear();
            txtMonto.Clear();
            cmbAccion.SelectedIndex = -1;
            cn.funactivarDesactivarTextbox(txtDescripcion, false);
            cn.funactivarDesactivarTextbox(txtMonto, false);
            dtpFecha.Enabled = false;
            cn.funactivarDesactivarCombobox(cmbAccion, false);

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
            cn.funactivarDesactivarTextbox(txtMonto, false);
            dtpFecha.Enabled = false;
            cn.funactivarDesactivarCombobox(cmbAccion, false);

            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            lblFecha.Visible = true;
            dtpFecha.Visible = true;
            lblMonto.Visible = true;
            txtMonto.Visible = true;
            lblAccion.Visible = true;
            cmbAccion.Visible = true;

            txtDescripcion.Clear();
            txtMonto.Clear();
            cmbAccion.SelectedIndex = -1;

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

        private void grdTipoServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTipoServicio_Load(object sender, EventArgs e)
        {

        }
    }
}
