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
    public partial class frmRol : Form
    {
        string sCod;
        string estado = "";
        public frmRol( string sCodRol, string sTipo, string sDescripcion)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            txtTipo.Text = sTipo;
            txtDescripcion.Text = sDescripcion;
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtTipo, false);
            cnegocio.funactivarDesactivarTextbox(txtDescripcion, false);
            //funActualizargrid();
        }
        private void funActualizargrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("rol", "SELECT rol.codigo_rol as Codigo, rol.tipo as TipoRol, rol.descripcion as Descripcion, rol.estado as Estado from rol WHERE rol.estado = 'ACTIVO'", "consulta", grdRol);
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


        private void frmRol_Load(object sender, EventArgs e)
        {

        }

        private void grdRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (estado.Equals("editar"))
            {
                sCod = grdRol.Rows[grdRol.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtTipo.Text = grdRol.Rows[grdRol.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txtDescripcion.Text = grdRol.Rows[grdRol.CurrentCell.RowIndex].Cells[2].Value.ToString();


            } if (estado.Equals("eliminar"))
            {
                sCod = grdRol.Rows[grdRol.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;

            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtTipo, txtDescripcion };
                string sTabla = "rol";
                string sCodigo = "codigo_rol";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);

            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "rol";
                string sCampoLlavePrimaria = "codigo_rol";
                string sCampoEstado = "estado";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtTipo, txtDescripcion, txtEstado};
                string sTabla = "rol";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
            }
            estado = "";
            txtTipo.Clear();
            txtDescripcion.Clear();
            cn.funactivarDesactivarTextbox(txtTipo, false);
            cn.funactivarDesactivarTextbox(txtDescripcion, false);
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
            funActualizargrid();
           
    }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtTipo, true);
            cnegocio.funactivarDesactivarTextbox(txtDescripcion, true);
           
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
            cnegocio.funactivarDesactivarTextbox(txtTipo, true);
            cnegocio.funactivarDesactivarTextbox(txtDescripcion, true);
            
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
            cn.funactivarDesactivarTextbox(txtTipo, false);
            cn.funactivarDesactivarTextbox(txtDescripcion, false);
            txtBuscar.Visible = false;
            lblBuscar.Visible = false;
            lblTipo.Visible = true;
            txtTipo.Visible = true;
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
          
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
            cn.funactivarDesactivarTextbox(txtTipo, false);
            cn.funactivarDesactivarTextbox(txtDescripcion, false);
    
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
            //funActualizargrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //txtBuscar.Visible = true;
            //lblBuscar.Visible = true;
            lblTipo.Visible = false;
            txtTipo.Visible = false;
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;


            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
            string sTabla = "rol";
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Busqueda", sTabla);
        }
        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funPrimero(grdRol);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funAnterior(grdRol);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funSiguiente(grdRol);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funUltimo(grdRol);
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            //clasnegocio cnegocio = new clasnegocio();
            //negocio.funconsultarRegistros("rol", " SELECT rol.codigo_rol as Codigo, rol.tipo as TipoRol, rol.descripcion as Descripcion, rol.estado as Estado WHERE rol.estado = 'ACTIVO' rol.tipo LIKE '" + txtBuscar.Text + "%'", "consulta", grdRol);
        }
    }
}
