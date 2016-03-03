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
using System.Data.Odbc;
namespace Aerolinea
{
    public partial class frmCreacionCarnet : Form
    {

        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        string sCod;
        int contador;
        string fecha,tomaCarrera,tomaJornada,tomaPersona,tomaAnio;
        double tiempo = 0.5;

        public frmCreacionCarnet()
        {
            InitializeComponent();
            tomarFecha();
            bloquearTodos();
            cmbPersona.Select();
        }

         public frmCreacionCarnet(string sCodCarnet, string sNombre,string sCarrera,string sJornada,string sBoton)
        {
            InitializeComponent();
            bloquearTodos();
            if (sBoton == "ELIMINAR")
            {
                //btnEliminar.Enabled = true;
                System.Console.WriteLine("Eliminar");
            }
            else if (sBoton == "ACTUALIZAR")
            {
                //btnEditar.Enabled = true;
                System.Console.WriteLine("Actualizar");
            }
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            cmbPersona.Enabled = false;
            sCod = sCodCarnet;
            cmbPersona.Text = sNombre;
            cmbCarrera.Text = sCarrera;
            cmbJornada.Text = sJornada;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;

        }

        public void funlimpiar()
        {

            cmbCarrera.Items.Clear();
            cmbCarrera.Text = "";
            cmbJornada.Items.Clear();
            cmbJornada.Text = "";
            cmbPersona.Items.Clear();
            cmbPersona.Text = "";
        }

        public void habilitarConNuevo()
        {
            btnAnterior.Enabled = true;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = false;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnNuevo.Enabled = false; //boton principal de la funcion
            btnRefrescar.Enabled = false;
            btnSiguiente.Enabled = true;
            cmbPersona.Enabled = true;
            funlimpiar();
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
        }

        public void WaitSeconds(double nSecs)
        {
            // Esperar los segundos indicados

            // Crear la cadena para convertir en TimeSpan
            string s = "0.00:00:" + nSecs.ToString().Replace(",", ".");
            TimeSpan ts = TimeSpan.Parse(s);

            // Añadirle la diferencia a la hora actual
            DateTime t1 = DateTime.Now.Add(ts);

            // Esta asignación solo es necesaria
            // si la comprobación se hace al principio del bucle
            DateTime t2 = DateTime.Now;

            // Mientras no haya pasado el tiempo indicado
            while (t2 < t1)
            {
                // Un respiro para el sitema
                System.Windows.Forms.Application.DoEvents();
                // Asignar la hora actual
                t2 = DateTime.Now;
            }

        }

        public void funLlenarCarrera(String id)
        {
            cmbCarrera.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigoCarrera,nombre FROM carrera WHERE nombre LIKE'" + id + "%' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbCarrera.Items.Add(codicarnet + "." + nombre);

            }
            cmbCarrera.DroppedDown = true;
            cmbCarrera.Select();

        }

        public void funLlenarPersona(String id)
        {
            cmbPersona.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigopersona,nombre,apellido from persona WHERE nombre LIKE'" + id + "%' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                string apellido = _reader.GetString(2);
                cmbPersona.Items.Add(codicarnet + "." + nombre + " " + apellido);

            }
            cmbPersona.DroppedDown = true;
            cmbPersona.Select();

        }

        public void funLlenarJornada(String id)
        {
            cmbJornada.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigoJornada,nombre from jornada WHERE nombre LIKE'" + id + "%' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbJornada.Items.Add(codicarnet + "." + nombre);

            }
            cmbJornada.DroppedDown = true;
            cmbJornada.Select();

        }

        public void tomarFecha()
        {
            DateTime fe = DateTime.Today;
            string f = fe.Year +"-" + fe.Month + "-" + fe.Day;
            String[] corte = f.Split('-');
            string fecha = corte[0];
            lblAnio.Text = fecha;
        }

        private void cmbCarrera_KeyUp(object sender, KeyEventArgs e)
        {
            string id = cmbCarrera.Text;
            WaitSeconds(tiempo);
            funLlenarCarrera(id);
            cmbCarrera.Text = "";
        }

        public Boolean VerificarCarnet(string sCodPersona) {
            Boolean verificado = false;
            _comando = new OdbcCommand(String.Format("SELECT codigopersona from carnet WHERE codigopersona='"+sCodPersona+"'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read()) {
                string numcar = _reader.GetString(0);
                if(numcar==sCodPersona){
                verificado = true;
                }
            
            }
            return verificado;
        }

        private void cmbPersona_KeyUp(object sender, KeyEventArgs e)
        {
            string id = cmbPersona.Text;
            WaitSeconds(tiempo);
            funLlenarPersona(id);
            cmbPersona.Text = "";
        }

        private void cmbJornada_KeyUp(object sender, KeyEventArgs e)
        {
            string id = cmbJornada.Text;
            WaitSeconds(tiempo);
            funLlenarJornada(id);
            cmbJornada.Text = "";
        }

        public void funtomarDatosCombos()
        {
            String[] cortCarrera = cmbCarrera.Text.Split('.');
            tomaCarrera = cortCarrera[0];//toma codigo seleccionado de combocarrera

            String[] cortEmpleado = cmbPersona.Text.Split('.');
            tomaPersona = cortEmpleado[0]; //toma codigo seleccionado de combo empleado

            String[] cortCurso = cmbJornada.Text.Split('.');
            tomaJornada = cortCurso[0];// toma codigo seleccionado de combo curso

            String tomaAnio = lblAnio.Text;
              
        }

        private void cmbPersona_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbCarrera_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbJornada_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarConNuevo();
        }

        public void correlativo() {
            _comando = new OdbcCommand(String.Format("SELECT MAX(correlativo) as correl from carnet"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string valor = _reader.GetString(0);
                int numVal = Int32.Parse(valor);
                contador = numVal + 1;

            }
        }

        public void funGuardarDatos(){
            int condicion = 1;
                string estado = "ACTIVO";
                string fech = lblAnio.Text;
                correlativo();
                System.Console.WriteLine(contador);
                _comando = new OdbcCommand(String.Format("insert into carnet(ano,correlativo,estado,codigopersona,codigoJornada,codigoCarrera,condicion) Values('" + fech + "','" + contador + "','" + estado + "','" + tomaPersona + "','" + tomaJornada + "','" + tomaCarrera + "','" + condicion + "')"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                MessageBox.Show("Carnte Asignado a Alumno Correcatamente");
        }

        public void funActualizar() {
            if (MessageBox.Show("¿Desea Actualizar El Carnte?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                funtomarDatosCombos();
                _comando = new OdbcCommand(String.Format("UPDATE carnet set codigoCarrera='" + tomaCarrera + "',codigoJornada='" + tomaJornada + "',estado='ACTIVO' where codigocarnet='" + sCod + "'"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                MessageBox.Show("El Carnet Se ha Actualizado");
                bloquearTodos();
                funlimpiar();
            }
            else {
                bloquearTodos();
                funlimpiar();
            }
        }

        public void funEliminar()
        {
            if (MessageBox.Show("¿Desea Eliminar el Carnet?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                funtomarDatosCombos();
                _comando = new OdbcCommand(String.Format("UPDATE carnet set estado='NOACTIVO' where codigocarnet='"+sCod+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                MessageBox.Show("El Canet Se Ha Eliminado");
                bloquearTodos();
                funlimpiar();
            }
            else
            {
                bloquearTodos();
                funlimpiar();
            }
        }


      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            funtomarDatosCombos();
            if (VerificarCarnet(tomaPersona)==true)
            {
                MessageBox.Show("Esta Persona ya posee un carnet");
            }
            else {
                if (MessageBox.Show("¿Desea Crear El Carnet?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //----------implementacion de la bitacora----------
                    string usu = claseUsuario.varibaleUsuario;
                    claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "INSERTAR", "carnet");
                    //-------------------------------------------------
                    funtomarDatosCombos();
                    funGuardarDatos();
                    funlimpiar();
                    bloquearTodos();
                }
                else
                {
                    funlimpiar();
                    bloquearTodos();
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            funlimpiar();
            bloquearTodos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            funActualizar();
            string usu = claseUsuario.varibaleUsuario;
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "MODIFICACIO", "carnet");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            funEliminar();
            string usu = claseUsuario.varibaleUsuario;
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "ELIMINAR", "carnet");
        }

    }
}
