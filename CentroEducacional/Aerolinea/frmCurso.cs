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
    public partial class frmCurso : Form
    {
        string estado = "";
        string sCod;
        public frmCurso()
        {
            InitializeComponent();
        }

        public frmCurso(string sCodCurso, string sNombre, string sValor, string sCreditos)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            sCod = sCodCurso;
            txtNombre.Text = sNombre;
            txtValor.Text = sValor;
            txtCreditos.Text = sCreditos;

            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmCursos");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtValor.Clear();
            txtCreditos.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNombre, true);
            cnegocio.funactivarDesactivarTextbox(txtValor, true);
            cnegocio.funactivarDesactivarTextbox(txtCreditos, true);
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
            cnegocio.funactivarDesactivarTextbox(txtValor, true);
            cnegocio.funactivarDesactivarTextbox(txtCreditos, true);
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
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarTextbox(txtNombre, false);
            cnegocio.funactivarDesactivarTextbox(txtValor, false);
            cnegocio.funactivarDesactivarTextbox(txtCreditos, false);
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

                TextBox[] aDatosEdit = { txtNombre, txtValor, txtCreditos};
                string sTabla = "curso";
                string sCodigo = "codigo_curso";

                cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);
                
                /* TextBox[] aDatosEditP = { txtNombre};
                string sTablaP = "prerequisito";
                string sCodigoP = "codigo_prerequisito";

                cn.EditarObjetos(sTablaP, bPermiso, aDatosEditP, sCod, sCodigoP);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);
                */

            }
            else if (estado.Equals("eliminar"))
            {
                string sTabla = "curso";
                string sCampoLlavePrimaria = "codigo_curso";
                string sCampoEstado = "condicion";
                //System.Console.WriteLine("----" + sCod);
                cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtNombre, txtValor, txtCreditos, txtEstado, txtCondicion };
                string sTabla = "curso";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);

                TextBox[] aDatosPrerequisito = { txtNombre, txtCondicion };
                string sTablaP = "prerequisito";
                cn.AsignarObjetos(sTablaP, bPermiso, aDatosPrerequisito);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTablaP);
            }

            estado = "";
            txtNombre.Clear();
            txtValor.Clear();
            txtCreditos.Clear();
            cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarTextbox(txtValor, false);
            cn.funactivarDesactivarTextbox(txtCreditos, false);
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
            cn.funactivarDesactivarTextbox(txtValor, false);
            cn.funactivarDesactivarTextbox(txtCreditos, false);

            txtNombre.Clear();
            txtValor.Clear();
            txtCreditos.Clear();
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
    }
}
