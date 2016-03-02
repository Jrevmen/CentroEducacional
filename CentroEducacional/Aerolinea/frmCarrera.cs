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
using System.Windows.Forms;
//using Filtrado;

namespace Aerolinea
{
    public partial class frmCarrera : Form
    {

        string sCod;
        string estado = "";
        public frmCarrera()
        {
            InitializeComponent();
            funSedes();
            funFacultad();
        }


        public frmCarrera(string sCodCarrera, string sNombreCarrera, string sNombreFacultad, string sNombreSede)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            sCod = sCodCarrera;

            funSedes();
            funFacultad();


            txtNombre.Text = sNombreCarrera;
            int index = cmbFacultad.FindString(sNombreFacultad);
            cmbFacultad.SelectedIndex = index;
            index = cmbSede.FindString(sNombreSede);
            cmbSede.SelectedIndex = index;
            /*
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmCarrera");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            */

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
            cnegocio.funconsultarRegistrosCombo("codigo_sede", "SELECT concat(TRIM(codigo_sede), '.', TRIM(nombre)) as Sede from sedes WHERE condicion='1'", "Sede", cmbSede);

        }

        void funFacultad()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("codigoFacultad", "SELECT concat(codigoFacultad, '.', nombre) as Facultad from facultad WHERE condicion='1'", "Facultad", cmbFacultad);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
            cnegocio.funactivarDesactivarCombobox(cmbFacultad, true);
            cnegocio.funactivarDesactivarCombobox(cmbSede, true);
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
            cnegocio.funactivarDesactivarCombobox(cmbFacultad, true);
            cnegocio.funactivarDesactivarCombobox(cmbSede, true);
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            txtFacultad.Text = funCortador(cmbFacultad.Text);
            txtSede.Text = funCortador(cmbSede.Text);

            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtNombre, txtFacultad,txtSede };
                string sTabla = "carrera";
                string sCodigo = "codigoCarrera";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "carrera";
                string sCampoLlavePrimaria = "codigoCarrera";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtNombre, txtEstado, txtFacultad, txtSede, txtCondicion};
                string sTabla = "carrera";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }

            estado = "";
            txtNombre.Clear();
            cmbFacultad.SelectedIndex = -1;
            cmbSede.SelectedIndex = -1;
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarCombobox(cmbFacultad, false);
            cn.funactivarDesactivarCombobox(cmbSede, false);
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();

            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarCombobox(cmbFacultad, false);
            cn.funactivarDesactivarCombobox(cmbSede, false);
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            lblFacultad.Visible = true;
            cmbFacultad.Visible = true;
            lblSede.Visible = true;
            cmbSede.Visible = true;
            txtNombre.Clear();

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

        private void grdCarrera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
           string op1 = "codigoFacultad";
           string op2 = "nombre";
           string query = "Select codigoFacultad, nombre from facultad where condicion='1'";
           /*frmFiltrado filtro = new frmFiltrado(query, op1, op2);
           filtro.Show();
           System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!:" + filtro.funResultado());
           
            while(filtro.funCondicion()==false){
                int index = cmbFacultad.FindString(filtro.funResultado());
                cmbFacultad.SelectedIndex = index;*/
            }
           

           

           
           
        }

 
    
}
