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

namespace Aerolinea
{
    public partial class frmPar : Form
    {
        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        String tomaCarnet, fecha;
        String sCod;

        public frmPar()
        {
            InitializeComponent();
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, " frmPar");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            btnNuevo.Select();
            bloquearTodos();
            tomarFecha();

        }
        public frmPar(string sCodParqueo, string sParqueo, string sCantidad)
        {
            InitializeComponent();
            
            sCod = sCodParqueo;
            txtparqueo.Text = sParqueo;
            textBox2.Text = sCantidad;
            bloquearTodos();
            llenarGrid();


        }
        #region funciones de validaciones y estados
        public void tomarDatos()
        {
            tomaCarnet = txtparqueo.Text; // toma el carnet de alumno 


        }
        public void limpiar()
        {

            txtparqueo.Text = "";
            DataTable dt = grdllenarParqueo.DataSource as DataTable;
            dt.Rows.Clear();

        }

        public void bloquearTodos()
        {
            //btnAnterior.Enabled = false;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnImprimir.Enabled = false;
            //btnIrPrimero.Enabled = false;
            //btnIrUltimo.Enabled = false;
            btnNuevo.Enabled = true; //boton principal de la funcion
            btnRefrescar.Enabled = false;
            //btnSiguiente.Enabled = false;
            txtparqueo.Enabled = false;
            textBox2.Enabled = false;
        }

        public void habilitarConNuevo()
        {
           // btnAnterior.Enabled = true;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = true;
            //btnIrPrimero.Enabled = true;
            //btnIrUltimo.Enabled = true;
            btnNuevo.Enabled = false; //boton principal de la funcion
            btnRefrescar.Enabled = false;
            //btnSiguiente.Enabled = true;
            txtparqueo.Enabled = false;
        }

        private void funActualizarGrid1()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("parqueo", "SELECT  parqueo.codigo_parqueo as NoParqueo,parqueo.numero_parqueo as NoParqueo, parqueo.estado as Estado,parqueo.ubicacion as Ubicacion, persona.nombre as Nombre, persona.apellido as Apellido   from parqueo, persona where codigopersona = '" + textBox1.Text +"' ", "consulta", grdllenarParqueo);
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "CONSULTA", " Parqueo");    
        }






        public void llenarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("parqueo", "SELECT parqueo.codigo_parqueo as NoParqueo,parqueo.numero_parqueo as NoParqueo, parqueo.estado as Estado,parqueo.ubicacion as Ubicacion  from parqueo ", "consulta", grdllenarParqueo);
           
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


    

    
 


    

       // private void btnGuardar_Click(object sender, EventArgs e)
        //{

         //   if (!txtparqueo.Text.Equals(""))
           // {
             //   if (funVerificaCarnet(txtparqueo.Text) == true)
               // {
                    //MessageBox.Show("alumno Registrado en Centro Educativo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //   if (funVerificaInscripcion(txtparqueo.Text) == true)
                   // {
                     //   MessageBox.Show("El alumno ya esta inscrito para un ciclo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                        //MessageBox.Show("Se procede a Inscribir al alumno", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      //  tomarDatos();
                        //funPreparacionCodigos(tomaCarnet);

                   // }
 //               }
   //             else
     //           {
       //             MessageBox.Show("El alumno no esta registrado en centro educativo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
         //       }
           // }
            //else { MessageBox.Show("El campo carnet debe llenarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            bloquearTodos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Decea Eliminar la asginacion parqueo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string elimina = "NOACTIVO";
                int condicion = 1;
                _comando = new OdbcCommand(String.Format("UPDATE asignacion_parqueo set estado='" + elimina + "' WHERE codigoCarnet='" + txtparqueo.Text + "'"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                limpiar();
                bloquearTodos();
            }
            else
            {
                limpiar();
                bloquearTodos();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Decea Reasignar el parqueo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Activar = "ACTIVO";
                //int condicion = 1;
                _comando = new OdbcCommand(String.Format("UPDATE encabezado_incripcion set estado='" + Activar + "' WHERE codigoCarnet='" + txtparqueo.Text + "'"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                limpiar();
                bloquearTodos();
            }
            else
            {
                limpiar();
                bloquearTodos();
            }
        }

        private void frmPrincipalPar_Load(object sender, EventArgs e)
        {

        }

        private void grdParqueo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
                if (MessageBox.Show("¿Asignar parqueo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                
                _comando = new OdbcCommand(String.Format("insert into asignacion_parqueo( codigo_parqueo, codigopersona) values ('" + txtparqueo.Text + "','" + textBox1.Text + "')"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();    
                MessageBox.Show("Se le asigno parqueo ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funActualizarGrid1();
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "INSERTAR", "Asignacion_parqueo");
                _comando = new OdbcCommand(String.Format("UPDATE parqueo SET cantidad = cantidad - '" + 1 + "' where numero_parqueo = '" + txtparqueo.Text + "' "), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();    
               
                    //funbuscarUsuario();
            }
            else
            {
                // error();
            }

   
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarConNuevo();
        }
        }
    }
