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
    public partial class frmFacultad : Form
    {
        string sCod;
        string estado="";
        public frmFacultad()
        {
            InitializeComponent();
        }

        public frmFacultad(string sCodFacultad, string sFacultad)
        {
            InitializeComponent();
            /*
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmFacultad");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            */
            sCod = sCodFacultad;
            txtNombre.Text = sFacultad;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;

        }


        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            txtNombre.Clear();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;

            if (estado.Equals("editar"))
            {
                
                TextBox[] aDatosEdit = { txtNombre };
                string sTabla = "facultad";
                string sCodigo = "codigoFacultad";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);
                this.Close();


            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "facultad";
                string sCampoLlavePrimaria = "codigoFacultad";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
                this.Close();
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtNombre, txtEstado,txtCondicion };
                string sTabla = "facultad";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);

                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
                this.Close();
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            cn.funactivarDesactivarTextbox(txtNombre, false);
            txtNombre.Clear();
            //txtBuscar.Clear();

            /*
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmFacultad");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            */
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void grdSedes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (estado.Equals("editar"))
            {
                clasnegocio cn = new clasnegocio();
                cn.funactivarDesactivarTextbox(txtNombre, true);
                sCod = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[1].Value.ToString();
                

            } if (estado.Equals("eliminar"))
            {
                sCod = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }*/
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estado = "editar";
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
            //txtNombre.Clear();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            //funActualizarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombre.Visible = false;
            lblNombre.Visible = false;
            //txtBuscar.Visible = true;
            //lblBuscar.Visible = true;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
            string sTabla = "facultad";
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Busqueda", sTabla);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funPrimero(grdFacultad);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funAnterior(grdFacultad);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funSiguiente(grdFacultad);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funUltimo(grdFacultad);
        }
    }
}
