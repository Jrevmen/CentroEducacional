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
    public partial class frmPensum : Form
    {
        string sCod;
        string estado = "";
        public frmPensum()
        {
            InitializeComponent();
            funCarrera();

            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmPensum");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];

        }

        public frmPensum(string sCodPensum, string sAno, string sCarrera)
        {
            InitializeComponent();
            funCarrera();
            sCod = sCodPensum;
            txtAno.Text = sAno;
            System.Console.WriteLine("******Carrera: " + sCarrera);
            int index = cmbCarrera.FindString(sCarrera);
            cmbCarrera.SelectedIndex = index;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmPensum");
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

        void funCarrera()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("codigoCarrera", "SELECT concat(codigoCarrera, '.', nombre) as Carrera from carrera WHERE condicion='1'", "Carrera", cmbCarrera);
            //cnegocio.funconsultarRegistrosCombo("codigoCarrera", "SELECT concat(codigoCarrera, '.', nombre) as Carrera from carrera WHERE estado='ACTIVO'", "Carrera", cmbBuscar);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtAno.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtAno, true);
            cnegocio.funactivarDesactivarCombobox(cmbCarrera, true);
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
            cnegocio.funactivarDesactivarTextbox(txtAno, true);
            cnegocio.funactivarDesactivarCombobox(cmbCarrera, true);
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
            cn.funactivarDesactivarTextbox(txtAno, false);
            cn.funactivarDesactivarCombobox(cmbCarrera, false);
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
            txtCarrera.Text = funCortador(cmbCarrera.Text);

            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtAno, txtCarrera };
                string sTabla = "pensum";
                string sCodigo = "codigo_pensum";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "pensum";
                string sCampoLlavePrimaria = "codigo_pensum";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtAno, txtEstado, txtCarrera, txtCondicion};
                string sTabla = "pensum";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }

            estado = "";
            txtAno.Clear();
            cmbCarrera.SelectedIndex = -1;
            cn.funactivarDesactivarTextbox(txtAno, false);
            cn.funactivarDesactivarCombobox(cmbCarrera, false);
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

            cn.funactivarDesactivarTextbox(txtAno, false);
            cn.funactivarDesactivarCombobox(cmbCarrera, false);
            lblAno.Visible = true;
            txtAno.Visible = true;
            lblCarrera.Visible = true;
            cmbCarrera.Visible = true;
            txtAno.Clear();
            //txtBuscar.Clear();


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

        private void grdPensum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmPensum_Load(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string sCampoCodigo = "codigoCarrera";// nombre del campo del codigo 
            string sCampoDescripcion = "nombre";// nombre del campo del nombre o descripcion 
            string query = "Select codigoCarrera, nombre from carrera where condicion='1'";// query que devuelve los
            //datos de codigoFacultad y nombre sin concatenar (Es el mismo query para llenar el combobox)
            frmFiltrado filtro = new frmFiltrado(query, sCampoCodigo, sCampoDescripcion);
            filtro.ShowDialog(this);
            int index = cmbCarrera.FindString(filtro.funResultado());
            cmbCarrera.SelectedIndex = index;//Selecciona el item del combobox 
        }
    }
}
