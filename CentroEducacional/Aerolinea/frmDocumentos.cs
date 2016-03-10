using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Filtrado;
using Navegador;

namespace Aerolinea
{
    public partial class frmDocumentos : Form
    {
        string sCodSer, sTrans, estado, sCad, sTran;
        
        public frmDocumentos(string sCodServicio, string sTransaccion, string sCarnet, string sNombre, string sMonto, string sFecha)
        {
            InitializeComponent();
            sCodSer = sCodServicio;
            sTrans = sTransaccion;
            txtCarnet.Text = sCarnet;
            txtNombre.Text = sNombre;
            dtFecha.Value = Convert.ToDateTime(sFecha);
            txtMonto.Text = sMonto;
            Boolean[] PermisoBotones;
            PermisoBotones = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmReasignacion");
            btnNuevo.Enabled = PermisoBotones[0];
            btnEditar.Enabled = PermisoBotones[1];
            btnEliminar.Enabled = PermisoBotones[2];
        }

        void funpersona()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("carnet", "SELECT concat(TRIM(carnet.codigoCarnet), '.', TRIM(persona.nombre)) as Persona from carnet,persona  WHERE carnet.codigopersona = persona.codigopersona and persona.condicion = '1'", "Persona", cmbInteligente);

        }

        private void frmDocumentos_Load(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funactivarDesactivarBoton(btnGuardar, false);
            cneg.funactivarDesactivarBoton(btnAnterior, true);
            cneg.funactivarDesactivarBoton(btnIrPrimero, true);
            cneg.funactivarDesactivarBoton(btnIrUltimo, true);
            cneg.funactivarDesactivarBoton(btnSiguiente, true);
            cneg.funactivarDesactivarBoton(btnCancelar, false);
            cneg.funactivarDesactivarBoton(btnRefrescar, true);
            cneg.funactivarDesactivarBoton(btnImprimir, false);
            cneg.funactivarDesactivarBoton(btnBuscar, false);
            btnFiltrar.Enabled = false;
            cmbInteligente.Enabled = false;
            txtCarnet.Enabled = false;
            txtCondicion.Enabled = false;
            txtEstado.Enabled = false;
            txtNombre.Enabled = false;
            dtFecha.Enabled = false;
            txtMonto.Enabled = false;

        }

        string funCortadorID(string sDato)
        {
            sCad = "";
            try
            {
                for (int i = 0; i < sDato.Length; i++)
                {
                    if (sDato.Substring(i, 1) != ".")
                    {
                        sCad = sCad + sDato.Substring(i, 1);
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
            return sCad;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbInteligente.Enabled = true;
            btnFiltrar.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            funpersona();
            txtCarnet.Clear();
            txtCarnet.Enabled = true;
            txtMonto.Clear();
            txtMonto.Enabled = true;
            txtNombre.Clear();
            txtNombre.Enabled = true;
            dtFecha.Enabled = true;
            cmbInteligente.Text = "";
            estado = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            string sTabla = "servicio";
            string sCodigo = "codigo_servicio";
            cn.funconsultarRegistrosCombo("cod_tipo_pago", "SELECT cod_tipo_pago as Codigo FROM tipo_pago WHERE descripcion = 'Pago unico' and condicion = '1'", "Codigo", cmdTp);
            sTran = funCortadorID(sTrans);
            txtTipoServicio.Text = sTran;
            txtTipoPago.Text = cmdTp.Text;
            txtFecha.Text = dtFecha.Text;
            txtContrato.Text = null;


            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtTipoServicio, txtTipoPago, txtCarnet, txtMonto, txtFecha, txtEstado, txtCondicion };

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCodSer, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {

                string sCampoEstado = "Condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCodSer, sCodigo, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtTipoServicio, txtTipoPago, txtCarnet, txtMonto, txtFecha, txtEstado, txtCondicion };
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }

            this.Close();
         
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estado = "editar";
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
            txtNombre.Enabled = true;
            txtCarnet.Enabled = true;
            txtMonto.Enabled = true;
            dtFecha.Enabled = true;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            estado = "eliminar";
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estado = "";
            btnFiltrar.Enabled = false;
            cmbInteligente.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            txtMonto.Clear();
            txtCarnet.Clear();
            txtNombre.Clear();
            txtMonto.Enabled = false;
            txtCarnet.Enabled = false;
            txtNombre.Enabled = false;
            dtFecha.Enabled = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string sCampoCodigo = "codigoCarnet";
            string ScampoDescripcion = "nombre";
            string query = "Select codigoCarnet,nombre from carnet,persona where  carnet.codigopersona = persona.codigopersona and persona.condicion = '1' ";
            frmFiltrado filtro = new frmFiltrado(query, sCampoCodigo, ScampoDescripcion);
            filtro.ShowDialog(this);
            int index = cmbInteligente.FindString(filtro.funResultado());
            cmbInteligente.SelectedIndex = index;

        }

        private void cmbInteligente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            string nombre = funCortadorID(cmbInteligente.Text);
            string carnet = funCortadorID(cmbInteligente.Text);
            txtCarnet.Text = carnet;
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("nombre", "SELECT persona.nombre as Nombre from carnet, persona WHERE carnet.codigoCarnet = " + nombre + " and carnet.codigopersona = persona.codigopersona", "nombre", cmbnombre);
            txtNombre.Text = cmbnombre.Text;
        }
    }
}
