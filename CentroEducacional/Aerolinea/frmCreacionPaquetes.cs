using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //maneja hilos
using Navegador;
using ConexionODBC;
using System.Data.Odbc;

namespace Aerolinea
{
    public partial class frmCreacionPaquetes : Form
    {
        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;

        string tomaCarrera, tomaCurso, tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaEmpleado,estado="ACTIVO";
        String coCurso, coSalon, coLaboratorio, coHorario, coSeccion, coCarrera;
        string combinacionCurso, combinacionSalon, combinacionLaboratorio, combinacionHorario, combinacionSeccion, combinacioncarrera;

        public frmCreacionPaquetes()
        {
            InitializeComponent();
            //funLlenoCarreraNavegador();
        }

        #region Funciones que permiten hacer la consulta para llenar los combobox
        public void funLlenarCarrera(String id){
            cmbCarrera.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT nombre FROM carrera WHERE nombre LIKE'" + id + "%' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                cmbCarrera.Items.Add(codicarnet);

            }
            cmbCarrera.DroppedDown = true;
            cmbCarrera.Select();
        
        }

        public void funLlenarCurso(String id)
        {
            cmbCurso.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT nombre FROM curso WHERE nombre LIKE'" + id + "%' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                cmbCurso.Items.Add(codicarnet);

            }
            cmbCurso.DroppedDown = true;
            cmbCurso.Select();

        }

        public void funLlenarSalon(String id)
        {
            cmbSalon.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT nombre_salon FROM salon WHERE nombre_salon LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                cmbSalon.Items.Add(codicarnet);

            }
            cmbSalon.DroppedDown = true;
            cmbSalon.Select();

        }

        public void funLlenarLaboratorio(String id)
        {
            cmbLaboratorio.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT nombre FROM laboratorio WHERE nombre LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                cmbLaboratorio.Items.Add(codicarnet);

            }
            cmbLaboratorio.DroppedDown = true;
            cmbLaboratorio.Select();

        }

        public void funLlenarHorario(String id)
        {
            cmbHorario.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT rangoHora FROM horario WHERE rangoHora LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                cmbHorario.Items.Add(codicarnet);

            }
            cmbHorario.DroppedDown = true;
            cmbHorario.Select();

        }

        public void funLlenarSeccion(String id)
        {
            cmbSeccion.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT nombre FROM seccion WHERE nombre LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                cmbSeccion.Items.Add(codicarnet);

            }
            cmbSeccion.DroppedDown = true;
            cmbSeccion.Select();

        }
        #endregion

        #region Funciones que permiten llenar el combobox y funcion de retraso
        public  void WaitSeconds(double nSecs)
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
       
        private void cmbCarrera_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbCarrera.Text;
            //System.Console.WriteLine("-------->  "+ id  );
            WaitSeconds(0.7);
            funLlenarCarrera(id);
            cmbCarrera.Text = "";
        }

        private void cmbCurso_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbCurso.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(0.7);
            funLlenarCurso(id);
            cmbCurso.Text = "";
        }

        private void cmbSalon_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbSalon.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(0.7);
            funLlenarSalon(id);
            cmbSalon.Text = "";
        }

        private void cmbLaboratorio_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbLaboratorio.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(0.7);
            funLlenarLaboratorio(id);
            cmbLaboratorio.Text = "";
        }

        private void cmbHorario_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbHorario.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(0.7);
            funLlenarHorario(id);
            cmbHorario.Text = "";
        }

        private void cmbSeccion_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbSeccion.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(0.7);
            funLlenarSeccion(id);
            cmbSeccion.Text = "";
        }
        #endregion

        #region funciones para que no se desaparezca el cursor cuando se despliegue la lista
        private void cmbCarrera_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbCurso_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbSalon_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbLaboratorio_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbHorario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbSeccion_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        #endregion 

            public void funlimpiar(){

            cmbCarrera.Items.Clear();
            cmbCarrera.Text = "";
            cmbCurso.Items.Clear();
            cmbCurso.Text = "";
            cmbSalon.Items.Clear();
            cmbSalon.Text = "";
            cmbLaboratorio.Items.Clear();
            cmbLaboratorio.Text = "";
            cmbHorario.Items.Clear();
            cmbHorario.Text = "";
            cmbSeccion.Items.Clear();
            cmbSeccion.Text = "";
            DataTable dt = grdHorario.DataSource as DataTable;
            dt.Rows.Clear();

        }

            public void funtomarDatosCombos() {
                tomaCarrera = cmbCarrera.Text;
                tomaCurso = cmbCurso.Text;
                tomaSalon = cmbSalon.Text;
                tomaLaboratorio = cmbLaboratorio.Text;
                tomaHorario = cmbHorario.Text;
                tomaSeccion = cmbSeccion.Text;
                tomaEmpleado = lblEmpleado.Text;
                
                
            }
           
            public Boolean funvalidarHorario(string valCurso,string valSalon,string valLaboratorio,string valHorario,string valSeccion,string valCarrera)
            {

                //primera consulta-------------------------
                System.Console.WriteLine("se llego a validar" + valCurso + valSalon + valLaboratorio+ valHorario+valSeccion+valCarrera);
                Boolean HorarioCreado = false;
                _comando = new OdbcCommand(String.Format("SELECT codigo_curso,codigo_salon,codigo_laboratorio,codigoHorario,codigo_seccion,codigoCarrera from paquete WHERE codigo_curso='"+valCurso+"' and codigo_salon='"+valSalon+"' and codigo_laboratorio='"+valLaboratorio+"' and codigoHorario='"+valHorario+"' and codigo_seccion='"+valSeccion+"' and codigoCarrera='"+valCarrera+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read()) {
                    combinacionCurso= _reader.GetString(0);//curso
                    combinacionSalon = _reader.GetString(1);//salon
                    combinacionLaboratorio = _reader.GetString(2);//lab
                    combinacionHorario = _reader.GetString(3);//hora
                    combinacionSeccion = _reader.GetString(4);//seccion
                    combinacionSeccion = _reader.GetString(5);//carrera

                    HorarioCreado = true;
                
                }

                return HorarioCreado;
            }

            public void funCodigosTomarCodigos(String tcodCurso,String tcodSalon,String tcodLaboratorio,String tcodHorario,String tcodSeccion,String tcodCarrera) {
                
                _comando = new OdbcCommand(String.Format("SELECT curso.codigo_curso,salon.codigo_salon,laboratorio.codigo_laboratorio, horario.codigoHorario, seccion.codigo_seccion, carrera.codigoCarrera from curso,salon,laboratorio,horario,seccion,carrera WHERE curso.nombre='"+tcodCurso+"' and salon.nombre_salon='"+tcodSalon+"' AND laboratorio.nombre='"+tcodLaboratorio+"' AND horario.rangoHora='"+tcodHorario+"' and seccion.nombre='"+tcodSeccion+"' and carrera.nombre='"+tcodCarrera+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read()) {
                    coCurso = _reader.GetString(0);
                    coSalon = _reader.GetString(1);
                    coLaboratorio = _reader.GetString(2);
                    coHorario = _reader.GetString(3);
                    coSeccion = _reader.GetString(4);
                    coCarrera = _reader.GetString(5);
                    System.Console.WriteLine("toma de codigos=  " + coCurso + coSalon+coLaboratorio+coHorario+coSeccion+coCarrera);
                    //funvalidarHorario(coCurso, coSalon, coLaboratorio, coHorario, coSeccion, coCarrera);
                    MessageBox.Show("Se tomaron los codigos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                 
            }
            public void funTomarCodigosAGuardar(String tcodCurso, String tcodSalon, String tcodLaboratorio, String tcodHorario, String tcodSeccion, String tcodCarrera)
            {

                _comando = new OdbcCommand(String.Format("SELECT curso.codigo_curso,salon.codigo_salon,laboratorio.codigo_laboratorio, horario.codigoHorario, seccion.codigo_seccion, carrera.codigoCarrera from curso,salon,laboratorio,horario,seccion,carrera WHERE curso.nombre='" + tcodCurso + "' and salon.nombre_salon='" + tcodSalon + "' AND laboratorio.nombre='" + tcodLaboratorio + "' AND horario.rangoHora='" + tcodHorario + "' and seccion.nombre='" + tcodSeccion + "' and carrera.nombre='" + tcodCarrera + "'"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    coCurso = _reader.GetString(0);
                    coSalon = _reader.GetString(1);
                    coLaboratorio = _reader.GetString(2);
                    coHorario = _reader.GetString(3);
                    coSeccion = _reader.GetString(4);
                    coCarrera = _reader.GetString(5);
                    System.Console.WriteLine("toma de codigos=  " + coCurso + coSalon + coLaboratorio + coHorario + coSeccion + coCarrera);
                    guardarDatos(coCurso,coSalon, coLaboratorio,coHorario,coSeccion,lblEmpleado.Text,coCarrera);
                    MessageBox.Show("Se tomaron los codigos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            
            public void guardarDatos(String gcurso,String gSalon,String glaboratorio,String ghorario, String gseccion,String gempleado,String gcarrera) {
                _comando = new OdbcCommand(String.Format("insert into paquete(estado,codigo_curso,codigo_salon,codigo_laboratorio,codigoHorario,codigo_seccion,codigo_empleado,codigoCarrera) values ('" + estado + "','" + gcurso + "','" + gSalon + "','" + glaboratorio + "','" + ghorario + "','" + gseccion + "','" + gempleado + "','" + gcarrera + "')"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
            }

            private void btnGuardar_Click(object sender, EventArgs e)
            {
                if (!cmbCarrera.Text.Equals("") && !cmbCurso.Text.Equals("") && !cmbSalon.Text.Equals("") && !cmbLaboratorio.Text.Equals("") && !cmbHorario.Text.Equals("") && !cmbSeccion.Text.Equals(""))
                {
                    //MessageBox.Show("entro al primer if");
                    funtomarDatosCombos();
                    funCodigosTomarCodigos(tomaCurso, tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaCarrera);
                    if (funvalidarHorario(coCurso, coSalon, coLaboratorio, coHorario, coSeccion, coCarrera) == true)
                    {
                        //MessageBox.Show("horario existe");
                    }else{
                        funtomarDatosCombos();
                        funTomarCodigosAGuardar(tomaCurso, tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaCarrera);
                        MessageBox.Show("Horario Guardado");
                    }
                }
                else { MessageBox.Show("Todas las listas desplegables deben llenarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        
       
    }
}
