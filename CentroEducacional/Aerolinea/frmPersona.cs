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
    public partial class frmPersona : Form
    {

        string estado = "";
        string sCod;
        public frmPersona()
        {
            InitializeComponent();
        }

        public frmPersona(string sCodigoP, string sDPI, string sNombreP, string sApellidoP, string sFechaP, string sSexo, string sDireccionP, string sEmailP, string sTelefonoP)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            txtDpi.Text = sDPI;
            txtNombre.Text = sNombreP;
            txtApellido.Text = sApellidoP;
            dtpFecha.Value = Convert.ToDateTime(sFechaP);
            if (sSexo.Equals("Masculino"))
            {
                rbMasculino.Checked = true;
            }
            else if (sSexo.Equals("Femenino"))
            {
                rbFemenino.Checked = true;
            }

            txtDireccion.Text = sDireccionP;
            txtEmail.Text = sEmailP;
            txtTelefono.Text = sTelefonoP;
            sCod = sCodigoP;
        }


        void funObtenerCodigoPersona()
        {
            cmbObtenerCodigo.Items.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("codigopersona", "SELECT MAX(codigopersona) as Codigo from persona WHERE condicion='1'", "Codigo", cmbObtenerCodigo);
            txtInformacion.Text = cmbObtenerCodigo.Text;
           // cmbObtenerCodigo.SelectedIndex = 1;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtDpi, true);
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
            cnegocio.funactivarDesactivarTextbox(txtApellido, true);
            dtpFecha.Enabled = true;
            grupoSexo.Enabled = true;
            cnegocio.funactivarDesactivarTextbox(txtEmail, true);
            cnegocio.funactivarDesactivarTextbox(txtTelefono, true);
            cnegocio.funactivarDesactivarTextbox(txtDireccion, true);

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

            cnegocio.funactivarDesactivarTextbox(txtDpi, true);
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
            cnegocio.funactivarDesactivarTextbox(txtApellido, true);
            dtpFecha.Enabled = true;
            grupoSexo.Enabled = true;
            cnegocio.funactivarDesactivarTextbox(txtEmail, true);
            cnegocio.funactivarDesactivarTextbox(txtTelefono, true);
            cnegocio.funactivarDesactivarTextbox(txtDireccion, true);
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

            cn.funactivarDesactivarTextbox(txtDpi, false);
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarTextbox(txtApellido, false);
            dtpFecha.Enabled = false;
            grupoSexo.Enabled = false;
            cn.funactivarDesactivarTextbox(txtEmail, false);
            cn.funactivarDesactivarTextbox(txtTelefono, false);
            cn.funactivarDesactivarTextbox(txtDireccion, false);
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
            txtFecha.Text = dtpFecha.Text;
            if(rbMasculino.Checked){
                txtSexo.Text = "Masculino";
            }
            else if (rbFemenino.Checked){
                txtSexo.Text = "Femenino";
            }

            if (estado.Equals("editar"))
            {

                TextBox[] aDatosEdit = { txtNombre, txtApellido, txtFecha, txtDpi, txtSexo };
                string sTabla = "persona";
                string sCodigo = "codigopersona";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "persona";
                string sCampoLlavePrimaria = "codigopersona";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                System.Console.WriteLine("******PERSONA");
                TextBox[] aDatosPersona = { txtNombre, txtApellido, txtFecha, txtDpi, txtSexo, txtEstado, txtCondicion };
                string sTablaPersona = "persona";
                cn.AsignarObjetos(sTablaPersona, bPermiso, aDatosPersona);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTablaPersona);
                
                System.Console.WriteLine("******obtener");
                funObtenerCodigoPersona();
                System.Console.WriteLine("******TXTBOX: "+txtInformacion.Text);
                System.Console.WriteLine("******EMAIL");

                TextBox[] aDatosEmail = { txtEmail, txtEstado, txtInformacion, txtCondicion };
                string sTablaEmail = "email";
                cn.AsignarObjetos(sTablaEmail, bPermiso, aDatosEmail);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTablaEmail);

                System.Console.WriteLine("******TElefono");

                TextBox[] aDatosTelefono = { txtTelefono, txtEstado, txtInformacion, txtCondicion };
                string sTablaTelefono = "telefono";
                cn.AsignarObjetos(sTablaTelefono, bPermiso, aDatosTelefono);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTablaTelefono);

                TextBox[] aDatosDireccion = { txtDireccion, txtEstado, txtInformacion, txtCondicion };
                string sTablaDireccion = "direccion";
                cn.AsignarObjetos(sTablaDireccion, bPermiso, aDatosDireccion);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTablaDireccion);

                
            }

            estado = "";
            txtDpi.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            cn.funactivarDesactivarTextbox(txtDpi, false);
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarTextbox(txtApellido, false);
            dtpFecha.Enabled = false;
            grupoSexo.Enabled = false;
            cn.funactivarDesactivarTextbox(txtEmail, false);
            cn.funactivarDesactivarTextbox(txtTelefono, false);
            cn.funactivarDesactivarTextbox(txtDireccion, false);
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


            cn.funactivarDesactivarTextbox(txtDpi, false);
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarTextbox(txtApellido, false);
            dtpFecha.Enabled = false;
            grupoSexo.Enabled = false;
            cn.funactivarDesactivarTextbox(txtEmail, false);
            cn.funactivarDesactivarTextbox(txtTelefono, false);
            cn.funactivarDesactivarTextbox(txtDireccion, false);

            //txtBuscar.Visible = false;
            //lblBuscar.Visible = false;
            lblDpi.Visible = true;
            txtDpi.Visible = true;
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            lblApellido.Visible = true;
            txtApellido.Visible = true;
            lblFecha.Visible = true;
            dtpFecha.Visible = true;
            grupoSexo.Visible = true;
            lblEmail.Visible = true;
            txtEmail.Visible = true;
            lblTelefono.Visible = true;
            txtTelefono.Visible = true;
            lblDireccion.Visible = true;
            txtDireccion.Visible = true;

            txtDpi.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();


            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void grdPersona_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
