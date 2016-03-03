using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using ConexionODBC;
using Navegador;

/*
 * Programador: Manuel Alejandro Chuquiej Buch.
 * Carnet: 0901-12-9129.
 * Curso: Ingenieria de Software.
 * Carrera: Ingenieria en Sistemas.
 * Asingado Por: Josue Revolorio.
 */

namespace Aerolinea
{
    public partial class frmInscripcionAlumno : Form
    {
        //-----------variables para conexiones odbc---------------------------------------------------

        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        //-----------final de declaraciones de variables odbc;

        //-------------------variables para tomar datos de campos de texto y combobox-----------------
        String tomaCarnet,fecha;
        String sCod;

        //-------------------final de variables para tomar datos de campos de texto y combobox--------
        public frmInscripcionAlumno()
        {
            InitializeComponent();
            btnNuevo.Select();
            bloquearTodos();
            tomarFecha();
        }

        public frmInscripcionAlumno(string sCodInscripcion, string sCarnet)
        {
            InitializeComponent();
            /*
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmFacultad");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            */
            sCod = sCodInscripcion;
            txtBuscarPersona.Text = sCarnet;
            bloquearTodos();
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            llenarGrid();


        }

        #region funciones de validaciones y estados
        public void tomarDatos()
        {
            tomaCarnet = txtBuscarPersona.Text; // toma el carnet de alumno 


        }
        public void limpiar()
        {

            txtBuscarPersona.Text = "";
            DataTable dt = grdLLenarAlumno.DataSource as DataTable;
            dt.Rows.Clear();

        }

        public void bloquearTodos()
        {
            btnAnterior.Enabled = false;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnImprimir.Enabled = false;
            btnIrPrimero.Enabled = false;
            btnIrUltimo.Enabled = false;
            btnNuevo.Enabled = true; //boton principal de la funcion
            btnRefrescar.Enabled = false;
            btnSiguiente.Enabled = false;
            txtBuscarPersona.Enabled = false;

        }

        public void habilitarConNuevo()
        {
            btnAnterior.Enabled = true;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnNuevo.Enabled = false; //boton principal de la funcion
            btnRefrescar.Enabled = false;
            btnSiguiente.Enabled = true;
            txtBuscarPersona.Enabled = true;
        }






        public void llenarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT carnet.codigoCarnet as Carnet,persona.nombre as Nombre, persona.apellido as Apellido,persona.fechaNacimiento as Nacimiento,carrera.nombre as Carrera, jornada.nombre as Jornada FROM carnet,persona,carrera,jornada WHERE carnet.codigopersona=persona.codigopersona and carnet.codigoCarrera=carrera.codigoCarrera and carnet.codigoJornada=jornada.codigoJornada and carnet.codigoCarnet LIKE'" + txtBuscarPersona.Text + "%'", "consulta", grdLLenarAlumno);
        }
        #endregion

       
        private void txtBuscarPersona_KeyUp(object sender, KeyEventArgs e)
        {
            llenarGrid();
        }

        




        public void tomarFecha()
        {
            DateTime fe = DateTime.Today;
            fecha = fe.Year + "-" + fe.Month + "-" + fe.Day;
        }


        public static Boolean funVerificaCarnet(String validar)
        {
            Boolean Encontre = false;
            _comando = new OdbcCommand(String.Format("select codigoCarnet from carnet where codigoCarnet='" + validar + "'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                Encontre = true;
            return Encontre;
        }

        public static Boolean funVerificaInscripcion(String verificarInscripcion)
        {
            Boolean Inscrito = false;
            _comando = new OdbcCommand(String.Format("select codigoCarnet from encabezado_incripcion where codigoCarnet='" + verificarInscripcion + "' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                Inscrito = true;
            return Inscrito;
        }

        public void funPreparacionCodigos(string codcarnet)
        {
            _comando = new OdbcCommand(String.Format("SELECT codigoCarnet FROM carnet WHERE codigoCarnet='"+codcarnet+"'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                funGuardarDatos(codicarnet);

            }

        }

        public void funGuardarDatos(string paramcarnet)
        {
            if (MessageBox.Show("¿Desea Inscribir al Alumno?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tomarFecha();
                string est = "ACTIVO";
                int condicion = 1;
                _comando = new OdbcCommand(String.Format("insert into encabezado_incripcion(fecha,codigoCarnet,estado,condicion) values ('" + fecha + "','" + paramcarnet + "','" + est + "','"+condicion+"')"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                MessageBox.Show("Alumno Correcatamente Inscrito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                bloquearTodos();
            }
            else
            {
                limpiar();
                bloquearTodos();
            }


        }






        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarConNuevo();


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!txtBuscarPersona.Text.Equals(""))
            {
                if (funVerificaCarnet(txtBuscarPersona.Text) == true)
                {
                    //MessageBox.Show("alumno Registrado en Centro Educativo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (funVerificaInscripcion(txtBuscarPersona.Text) == true)
                    {
                        MessageBox.Show("El alumno ya esta inscrito para un ciclo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("Se procede a Inscribir al alumno", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tomarDatos();
                        funPreparacionCodigos(tomaCarnet);
                        string usu = claseUsuario.varibaleUsuario;
                        claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "INSERTAR", "encabezado_incripcion");

                    }
                }
                else
                {
                    MessageBox.Show("El alumno no esta registrado en centro educativo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else { MessageBox.Show("El campo carnet debe llenarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            bloquearTodos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Decea Eliminar la Inscripcion del Alumno?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string elimina = "NOACTIVO";
                int condicion = 1;
                _comando = new OdbcCommand(String.Format("UPDATE encabezado_incripcion set estado='"+elimina+"' WHERE codigoCarnet='"+txtBuscarPersona.Text+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                //-----------utilizacion de bitacora----------------
                string usu = claseUsuario.varibaleUsuario;
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "ELIMINAR", "encabezado_incripcion");
                limpiar();
                bloquearTodos();
                
            }
            else {
                limpiar();
                bloquearTodos();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Decea Reinscribir al Alumno?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Activar = "ACTIVO";
                //int condicion = 1;
                _comando = new OdbcCommand(String.Format("UPDATE encabezado_incripcion set estado='" + Activar + "' WHERE codigoCarnet='" + txtBuscarPersona.Text + "'"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                string usu = claseUsuario.varibaleUsuario;
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "MODIFICACION", "encabezado_incripcion");
                limpiar();
                bloquearTodos();
            }
            else
            {
                limpiar();
                bloquearTodos();
            }
        }

    }
}
