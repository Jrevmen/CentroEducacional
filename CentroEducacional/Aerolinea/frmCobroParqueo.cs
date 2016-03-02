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
    public partial class frmCobroParqueo : Form
    {
        string sCod, estado, sTrans, sCadena, sTransac;
        public frmCobroParqueo()
        {
            InitializeComponent();
          
            funActualizarGrid();
            funCargarNavegador();
        }

        public frmCobroParqueo(string sCodServicio, string sTransaccion, string sCarnet, string sNombre, string sMonto, string sFecha)
        {
            InitializeComponent();
            sCod = sCodServicio;
            sTrans = sTransaccion;
            txtCarnet.Text = sCarnet;
            txtMonto.Text = sMonto;
            txtNombre.Text = sNombre;
            dtpFecha.Value = Convert.ToDateTime(sFecha);
            funActualizarGrid();
            funCargarNavegador();
            

        }

        public void funCargarNavegador()
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            txtMonto.Enabled = false;
            txtCarnet.Enabled = false;
            txtNombre.Enabled = false;
            dtpFecha.Enabled = false;
        }

        public void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre from carnet, persona WHERE carnet.codigopersona = persona.codigopersona and persona.condicion = '1'", "consulta", grdAlumnos);
            cnegocio.funconsultarRegistrosCombo("cod_tipo_pago", "SELECT cod_tipo_pago as Codigo FROM tipo_pago WHERE descripcion = 'Pago unico' and condicion = '1'", "Codigo", cmbTipoPago);

        }
        string funCortadorID(string sDato)
        {
            sCadena = "";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCarnet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCarnet_MouseClick(object sender, MouseEventArgs e)
        {
            txtCarnet.Clear();
            txtNombre.Clear();
        }

        private void txtNombre_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Clear();
            txtCarnet.Clear();

        }

        private void txtCarnet_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre from carnet, persona WHERE carnet.codigopersona = persona.codigopersona and persona.condicion = '1' and carnet.codigoCarnet  LIKE '" + txtCarnet.Text + "%'", "consulta", grdAlumnos);
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre from carnet, persona WHERE carnet.codigopersona = persona.codigopersona and persona.condicion = '1' and persona.nombre  LIKE '" + txtNombre.Text + "%'", "consulta", grdAlumnos);
        }

        private void grdAlumnos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCarnet = grdAlumnos.Rows[grdAlumnos.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombre = grdAlumnos.Rows[grdAlumnos.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txtCarnet.Text = sCarnet;
            txtNombre.Text = sNombre;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtMonto.Clear();
            txtCarnet.Clear();
            txtNombre.Clear();

            txtMonto.Enabled = true;
            txtCarnet.Enabled = true;
            txtNombre.Enabled = true;
            dtpFecha.Enabled = true;
            
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            estado = "";


        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtMonto.Enabled = true;
            txtCarnet.Enabled = true;
            txtNombre.Enabled = true;
            dtpFecha.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            
            estado = "editar";


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            
            estado = "eliminar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            txtMonto.Clear();
            txtCarnet.Clear();
            txtNombre.Clear();

            txtMonto.Enabled = false;
            txtCarnet.Enabled = false;
            txtNombre.Enabled = false;
            dtpFecha.Enabled = false;


        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdAlumnos);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdAlumnos);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdAlumnos);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdAlumnos);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            string sTabla = "servicio";
            string sCodigo = "codigo_servicio";
            sTransac = funCortadorID(sTrans);
            txtTipoServicio.Text = sTransac;
            txtTipoPago.Text = cmbTipoPago.Text;
            txtfecha.Text = dtpFecha.Text;
            txtContrato.Text = null;



            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtTipoServicio, txtTipoPago, txtCarnet, txtMonto, txtfecha, txtEstado, txtCondicion };
                
                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {
               
                string sCampoEstado = "Condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCodigo, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtTipoServicio, txtTipoPago, txtCarnet, txtMonto, txtfecha, txtEstado, txtCondicion };
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }

            this.Close();
        }
    }
}
