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
using Filtrado;

namespace Aerolinea
{
    public partial class frmSalones : Form
    {
        string estado = "";
        string sCod;
        public frmSalones()
        {
            InitializeComponent();
            funSedes();
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmSalones");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
        }

        public frmSalones(string sCodSalon, string sNombre, string sCupo, string sSede)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            funSedes();
            sCod = sCodSalon;
            txtNombre.Text = sNombre;
            txtCupo.Text = sCupo;

            int index = cmbSede.FindString(sSede);
            cmbSede.SelectedIndex = index;
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmSalones");
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

        void funSedes()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("codigo_sede", "SELECT concat(codigo_sede, '.', nombre) as Sede from sedes WHERE condicion='1'", "Sede", cmbSede);
            
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtCupo.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
            cnegocio.funactivarDesactivarTextbox(txtCupo, true);
            cnegocio.funactivarDesactivarCombobox(cmbSede,true);
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
            cnegocio.funactivarDesactivarTextbox(txtCupo, true);
            cnegocio.funactivarDesactivarCombobox(cmbSede, true);
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
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarTextbox(txtCupo, false);
            cn.funactivarDesactivarCombobox(cmbSede, false);
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

            txtSede.Text = funCortador(cmbSede.Text);
            System.Console.WriteLine("*************Cortador: "+txtSede.Text);

            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtNombre, txtCupo, txtSede };
                string sTabla = "salon";
                string sCodigo = "codigo_salon";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "salon";
                string sCampoLlavePrimaria = "codigo_salon";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtNombre, txtCupo, txtEstado, txtSede, txtCondicion };
                string sTabla = "salon";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }

            estado = "";
            txtNombre.Clear();
            txtCupo.Clear();
            cmbSede.SelectedIndex = -1;
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarTextbox(txtCupo, false);
            cn.funactivarDesactivarCombobox(cmbSede, false);
   
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
            cn.funactivarDesactivarTextbox(txtCupo, false);
            cn.funactivarDesactivarCombobox(cmbSede, false);
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            lblCupo.Visible = true;
            txtCupo.Visible = true;
            lblSede.Visible = true;
            cmbSede.Visible = true;
            txtNombre.Clear();
            txtCupo.Clear();
            cmbSede.SelectedIndex = -1;

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

        private void grdSalones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string sCampoCodigo = "codigo_sede";// nombre del campo del codigo 
            string sCampoDescripcion = "nombre";// nombre del campo del nombre o descripcion 
            string query = "Select codigo_sede, nombre from sedes where condicion='1'";// query que devuelve los
            //datos de codigoFacultad y nombre sin concatenar (Es el mismo query para llenar el combobox)
            frmFiltrado filtro = new frmFiltrado(query, sCampoCodigo, sCampoDescripcion);
            filtro.ShowDialog(this);
            int index = cmbSede.FindString(filtro.funResultado());
            cmbSede.SelectedIndex = index;//Selecciona el item del combobox 
        }

        
    }
}
