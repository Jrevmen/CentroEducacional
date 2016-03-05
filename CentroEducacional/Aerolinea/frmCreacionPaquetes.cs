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
    public partial class frmCreacionPaquetes : Form
    {
        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        string sCod;
        double tiempo = 0.5;

        string tomaCarrera, tomaCurso, tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaEmpleado,estado="ACTIVO";
        String coCurso, coSalon, coLaboratorio, coHorario, coSeccion, coCarrera,coEmpleado;
        string combinacionCurso, combinacionSalon, combinacionLaboratorio, combinacionHorario, combinacionSeccion, combinacioncarrera,combinacionEmpleado;

        public frmCreacionPaquetes()
        {
            InitializeComponent();
            //funLlenoCarreraNavegador();
            bloquearTodos();
        }

        public frmCreacionPaquetes(string sCodigoPaquete, string sCurso,string sSalon,string sLaboratorio,string sHorario,string sSeccion,string sCatedratrico,string sCarrera)
        {
            InitializeComponent();
            
            sCod = sCodigoPaquete;
            cmbCarrera.Text = sCarrera;
            cmbCatedratico.Text = sCatedratrico;
            cmbCurso.Text = sCurso;
            cmbSalon.Text = sSalon;
            cmbLaboratorio.Text = sLaboratorio;
            cmbHorario.Text = sHorario;
            cmbSeccion.Text = sSeccion;
            bloquearTodos();
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;
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
        }

        #region Funciones que permiten hacer la consulta para llenar los combobox
        public void funLlenarCarrera(String id){
            cmbCarrera.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigoCarrera,nombre FROM carrera WHERE nombre LIKE'" + id + "%' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbCarrera.Items.Add(codicarnet+"."+nombre);

            }
            cmbCarrera.DroppedDown = true;
            cmbCarrera.Select();
        
        }

        public void funLlenarEmpleado(String id)
        {
            cmbCatedratico.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT empleado.codigo_empleado, persona.nombre,persona.apellido FROM persona,empleado,puesto WHERE empleado.codigopersona=persona.codigopersona and empleado.codigoPuesto=puesto.codigoPuesto and puesto.nombre='Catedratico' and persona.nombre LIKE'"+id+"%'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                string apellido = _reader.GetString(2);
                cmbCatedratico.Items.Add(codicarnet+"."+nombre+" "+apellido);

            }
            cmbCatedratico.DroppedDown = true;
            cmbCatedratico.Select();

        }

        public void funLlenarCurso(String id)
        {
            cmbCurso.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigo_curso,nombre FROM curso WHERE nombre LIKE'" + id + "%' and estado='ACTIVO'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbCurso.Items.Add(codicarnet+"."+nombre);
            }
            cmbCurso.DroppedDown = true;
            cmbCurso.Select();

        }

        public void funLlenarSalon(String id)
        {
            cmbSalon.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigo_salon,nombre_salon FROM salon WHERE nombre_salon LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbSalon.Items.Add(codicarnet+"."+nombre);

            }
            cmbSalon.DroppedDown = true;
            cmbSalon.Select();

        }

        public void funLlenarLaboratorio(String id)
        {
            cmbLaboratorio.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigo_laboratorio,nombre FROM laboratorio WHERE nombre LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbLaboratorio.Items.Add(codicarnet+"."+nombre);

            }
            cmbLaboratorio.DroppedDown = true;
            cmbLaboratorio.Select();

        }

        public void funLlenarHorario(String id)
        {
            cmbHorario.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigoHorario,rangoHora FROM horario WHERE rangoHora LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbHorario.Items.Add(codicarnet+"."+nombre);

            }
            cmbHorario.DroppedDown = true;
            cmbHorario.Select();

        }

        public void funLlenarSeccion(String id)
        {
            cmbSeccion.Items.Clear();
            _comando = new OdbcCommand(String.Format("SELECT codigo_seccion,nombre FROM seccion WHERE nombre LIKE'" + id + "%' and estado='ACTIVO' "), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                string codicarnet = _reader.GetString(0);
                string nombre = _reader.GetString(1);
                cmbSeccion.Items.Add(codicarnet+"."+nombre);

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
            string id = cmbCarrera.Text;
            //String combo = cmbCarrera.Text;
            //string[] elemento = combo.Split('.');
            //string id = elemento[0];

            //System.Console.WriteLine("-------->  "+ id  );
            WaitSeconds(tiempo);
            funLlenarCarrera(id);
            cmbCarrera.Text = "";
        }

        private void cmbCatedratico_KeyUp(object sender, KeyEventArgs e)
        {
            string id = cmbCatedratico.Text;
            //System.Console.WriteLine("-------->  "+ id  );
            WaitSeconds(tiempo);
            funLlenarEmpleado(id);
            cmbCatedratico.Text = "";
            
        }

        private void cmbCurso_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbCurso.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(tiempo);
            funLlenarCurso(id);
            cmbCurso.Text = "";
        }

        private void cmbSalon_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbSalon.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(tiempo);
            funLlenarSalon(id);
            cmbSalon.Text = "";
        }

        private void cmbLaboratorio_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbLaboratorio.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(tiempo);
            funLlenarLaboratorio(id);
            cmbLaboratorio.Text = "";
        }

        private void cmbHorario_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbHorario.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(tiempo);
            funLlenarHorario(id);
            cmbHorario.Text = "";
        }

        private void cmbSeccion_KeyUp(object sender, KeyEventArgs e)
        {
            String id = cmbSeccion.Text;
            //System.Console.WriteLine("-------->  " + id);
            WaitSeconds(tiempo);
            funLlenarSeccion(id);
            cmbSeccion.Text = "";
        }
        #endregion

        #region funciones para que no se desaparezca el cursor cuando se despliegue la lista
        private void cmbCarrera_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        private void cmbCatedratico_DropDown(object sender, EventArgs e)
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
            cmbCatedratico.Items.Clear();
            cmbCatedratico.Text = "";
           // DataTable dt = grdHorario.DataSource as DataTable;
           // dt.Rows.Clear();

        }

            public void funtomarDatosCombos() {
                String[] cortCarrera = cmbCarrera.Text.Split('.');
                tomaCarrera = cortCarrera[0];//toma codigo seleccionado de combocarrera

                String[] cortEmpleado = cmbCatedratico.Text.Split('.');
                tomaEmpleado = cortEmpleado[0]; //toma codigo seleccionado de combo empleado

                String[] cortCurso = cmbCurso.Text.Split('.');
                tomaCurso = cortCurso[0];// toma codigo seleccionado de combo curso

                String[] cortSalon = cmbSalon.Text.Split('.');
                tomaSalon = cortSalon[0]; //toma codigo seleccionado de combo salon

                String[] cortLaboratorio = cmbLaboratorio.Text.Split('.');
                tomaLaboratorio = cortLaboratorio[0];//toma codigo seleccionado de combo laboratorio

                String[] cortHorario = cmbHorario.Text.Split('.');
                tomaHorario = cortHorario[0]; //toma codigo seleccionado de combo horario

                String[] cortSeccion = cmbSeccion.Text.Split('.');
                tomaSeccion = cortSeccion[0]; // codigo seleccionado de combo  seccion      
            }

            //public Boolean funvalidarHorarioActualizar(string valCurso, string valSalon, string valLaboratorio, string valHorario, string valSeccion, string valCarrera, string valEmpleado)
            //{

            //    //primera consulta-------------------------
            //    System.Console.WriteLine("se llego a validar" + valCurso + valSalon + valLaboratorio + valHorario + valSeccion + valCarrera + valEmpleado);
            //    Boolean HorarioCreado = false;
            //    //_comando = new OdbcCommand(String.Format("SELECT codigo_curso,codigo_salon,codigo_laboratorio,codigoHorario,codigo_seccion,codigoCarrera from paquete WHERE codigo_curso='"+valCurso+"' and codigo_salon='"+valSalon+"' and codigo_laboratorio='"+valLaboratorio+"' and codigoHorario='"+valHorario+"' and codigo_seccion='"+valSeccion+"' and codigoCarrera='"+valCarrera+"'"), ConexionODBC.Conexion.ObtenerConexion());
            //    _comando = new OdbcCommand(String.Format("SELECT codigo_curso,codigo_salon,codigo_laboratorio,codigoHorario,codigo_seccion,codigoCarrera,codigo_empleado from paquete"), ConexionODBC.Conexion.ObtenerConexion());
            //    _reader = _comando.ExecuteReader();
            //    while (_reader.Read())
            //    {
            //        combinacionCurso = _reader.GetString(0);//curso
            //        combinacionSalon = _reader.GetString(1);//salon
            //        combinacionLaboratorio = _reader.GetString(2);//lab
            //        combinacionHorario = _reader.GetString(3);//hora
            //        combinacionSeccion = _reader.GetString(4);//seccion
            //        combinacioncarrera = _reader.GetString(5);//carrera
            //        combinacionEmpleado = _reader.GetString(6);



            //        if (combinacionSalon == valSalon && combinacionHorario == valHorario)
            //        {
            //            HorarioCreado = true;
            //            MessageBox.Show("Elija un Horario y una seccion Distinta");
            //        }
            //        if (combinacionCurso == valCurso && combinacionSalon == valSalon && combinacionLaboratorio == valLaboratorio && combinacionHorario == valHorario && combinacionSeccion == valSeccion && combinacioncarrera == valCarrera)
            //        {
            //            HorarioCreado = true;
            //            MessageBox.Show("El horario ya existe");

            //        }

            //        if (combinacionHorario == valHorario && combinacionCurso == valCurso && combinacionEmpleado == valEmpleado)
            //        {
            //            HorarioCreado = true;
            //            MessageBox.Show("Este Catedratico ya esta asignado a un Horario en la misma hora y el mismo curso");
            //        }

            //        if (combinacionHorario == valHorario && combinacionEmpleado == valEmpleado)
            //        {
            //            HorarioCreado = true;
            //            MessageBox.Show("Este Catedratico ya imparte un Curso en el mismo horario");
            //        }



            //    }

            //    return HorarioCreado;
            //}
           
            public Boolean funvalidarHorario(string valCurso,string valSalon,string valLaboratorio,string valHorario,string valSeccion,string valCarrera,string valEmpleado)
            {

                //primera consulta-------------------------
                System.Console.WriteLine("se llego a validar" + valCurso + valSalon + valLaboratorio+ valHorario+valSeccion+valCarrera+valEmpleado);
                Boolean HorarioCreado = false;
                //_comando = new OdbcCommand(String.Format("SELECT codigo_curso,codigo_salon,codigo_laboratorio,codigoHorario,codigo_seccion,codigoCarrera from paquete WHERE codigo_curso='"+valCurso+"' and codigo_salon='"+valSalon+"' and codigo_laboratorio='"+valLaboratorio+"' and codigoHorario='"+valHorario+"' and codigo_seccion='"+valSeccion+"' and codigoCarrera='"+valCarrera+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _comando = new OdbcCommand(String.Format("SELECT codigo_curso,codigo_salon,codigo_laboratorio,codigoHorario,codigo_seccion,codigoCarrera,codigo_empleado from paquete"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read()) {
                    combinacionCurso= _reader.GetString(0);//curso
                    combinacionSalon = _reader.GetString(1);//salon
                    combinacionLaboratorio = _reader.GetString(2);//lab
                    combinacionHorario = _reader.GetString(3);//hora
                    combinacionSeccion = _reader.GetString(4);//seccion
                    combinacioncarrera = _reader.GetString(5);//carrera
                    combinacionEmpleado = _reader.GetString(6);

                    

                    if (combinacionSalon==valSalon && combinacionHorario==valHorario)
                    {
                        HorarioCreado = true;
                        //MessageBox.Show("Elija un Horario y una seccion Distinta");
                    }
                    if (combinacionCurso == valCurso && combinacionSalon == valSalon && combinacionLaboratorio == valLaboratorio && combinacionHorario == valHorario && combinacionSeccion == valSeccion && combinacioncarrera == valCarrera)
                    {
                        HorarioCreado = true;
                        //MessageBox.Show("El horario ya existe");

                    }

                    if (combinacionHorario==valHorario && combinacionCurso==valCurso && combinacionEmpleado==valEmpleado){
                        HorarioCreado = true;
                        //MessageBox.Show("Este Catedratico ya esta asignado a un Horario en la misma hora y el mismo curso");
                    }

                    if (combinacionHorario == valHorario && combinacionEmpleado == valEmpleado) { 
                     HorarioCreado = true;
                        //MessageBox.Show("Este Catedratico ya imparte un Curso en el mismo horario");
                    }
                    if (combinacioncarrera == valCarrera && combinacionSeccion == valSeccion && combinacionCurso==valCurso) {
                        HorarioCreado = true;
                    }

                    
                
                }

                return HorarioCreado;
            }

            public void funCodigosTomarCodigos(String tcodCurso, String tcodSalon, String tcodLaboratorio, String tcodHorario, String tcodSeccion, String tcodCarrera, String tcodEmpleado)
            {
                System.Console.WriteLine("LLEGO A FUNCION CODIGOS" + tcodCurso + tcodSalon + tcodLaboratorio + tcodHorario + tcodSeccion + tcodCarrera + tomaCarrera + tcodEmpleado);
                
                _comando = new OdbcCommand(String.Format("SELECT curso.codigo_curso,salon.codigo_salon,laboratorio.codigo_laboratorio, horario.codigoHorario, seccion.codigo_seccion, carrera.codigoCarrera, empleado.codigo_empleado from curso,salon,laboratorio,horario,seccion,carrera,empleado WHERE curso.codigo_curso='"+tcodCurso+"' and salon.codigo_salon='"+tcodSalon+"' AND laboratorio.codigo_laboratorio='"+tcodLaboratorio+"' AND horario.codigoHorario='"+tcodHorario+"' and seccion.codigo_seccion='"+tcodSeccion+"' and carrera.codigoCarrera='"+tcodCarrera+"' and empleado.codigo_empleado='"+tcodEmpleado+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read()) {
                    coCurso = _reader.GetString(0);
                    coSalon = _reader.GetString(1);
                    coLaboratorio = _reader.GetString(2);
                    coHorario = _reader.GetString(3);
                    coSeccion = _reader.GetString(4);
                    coCarrera = _reader.GetString(5);
                    coEmpleado = _reader.GetString(6);
                    //System.Console.WriteLine("toma de codigos=  " + coCurso +coEmpleado+ coSalon+coLaboratorio+coHorario+coSeccion+coCarrera);
                    //funvalidarHorario(coCurso, coSalon, coLaboratorio, coHorario, coSeccion, coCarrera);
                    ////MessageBox.Show("Se tomaron los codigos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                 
            }
            public void funTomarCodigosAGuardar(String tcodCurso,String tcodSalon, String tcodLaboratorio, String tcodHorario, String tcodSeccion, String tcodCarrera,String tcodEmpleado)
            {
                System.Console.WriteLine("LLEGO A FUNCION CODIGOS Guardar codigos" + tcodCurso + tcodSalon + tcodLaboratorio + tcodHorario + tcodSeccion + tcodCarrera + tomaCarrera + tcodEmpleado);
                
                _comando = new OdbcCommand(String.Format("SELECT curso.codigo_curso,salon.codigo_salon,laboratorio.codigo_laboratorio, horario.codigoHorario, seccion.codigo_seccion, carrera.codigoCarrera,empleado.codigo_Empleado from curso,salon,laboratorio,horario,seccion,carrera,empleado WHERE curso.codigo_curso='" + tcodCurso + "' and salon.codigo_salon='" + tcodSalon + "' AND laboratorio.codigo_laboratorio='" + tcodLaboratorio + "' AND horario.codigoHorario='" + tcodHorario + "' and seccion.codigo_seccion='" + tcodSeccion + "' and carrera.codigoCarrera='" + tcodCarrera + "' and empleado.codigo_Empleado='"+tcodEmpleado+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    coCurso = _reader.GetString(0);
                    coSalon = _reader.GetString(1);
                    coLaboratorio = _reader.GetString(2);
                    coHorario = _reader.GetString(3);
                    coSeccion = _reader.GetString(4);
                    coCarrera = _reader.GetString(5);
                    coEmpleado = _reader.GetString(6);
                    System.Console.WriteLine("toma de codigos=  " + coCurso + coSalon + coLaboratorio + coHorario + coSeccion + coCarrera+coEmpleado);
                    guardarDatos(coCurso,coSalon, coLaboratorio,coHorario,coSeccion,coEmpleado,coCarrera);
                    //MessageBox.Show("funcion tomar codigos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

         //public void funTomarCodigosActualizar(String tcodCurso,String tcodSalon, String tcodLaboratorio, String tcodHorario, String tcodSeccion, String tcodCarrera,String tcodEmpleado)
         //   {
         //       System.Console.WriteLine("LLEGO A FUNCION CODIGOS Guardar codigos" + tcodCurso + tcodSalon + tcodLaboratorio + tcodHorario + tcodSeccion + tcodCarrera + tomaCarrera + tcodEmpleado);
                
         //       _comando = new OdbcCommand(String.Format("SELECT curso.codigo_curso,salon.codigo_salon,laboratorio.codigo_laboratorio, horario.codigoHorario, seccion.codigo_seccion, carrera.codigoCarrera,empleado.codigo_Empleado from curso,salon,laboratorio,horario,seccion,carrera,empleado WHERE curso.codigo_curso='" + tcodCurso + "' and salon.codigo_salon='" + tcodSalon + "' AND laboratorio.codigo_laboratorio='" + tcodLaboratorio + "' AND horario.codigoHorario='" + tcodHorario + "' and seccion.codigo_seccion='" + tcodSeccion + "' and carrera.codigoCarrera='" + tcodCarrera + "' and empleado.codigo_Empleado='"+tcodEmpleado+"'"), ConexionODBC.Conexion.ObtenerConexion());
         //       _reader = _comando.ExecuteReader();
         //       while (_reader.Read())
         //       {
         //           coCurso = _reader.GetString(0);
         //           coSalon = _reader.GetString(1);
         //           coLaboratorio = _reader.GetString(2);
         //           coHorario = _reader.GetString(3);
         //           coSeccion = _reader.GetString(4);
         //           coCarrera = _reader.GetString(5);
         //           coEmpleado = _reader.GetString(6);
         //           System.Console.WriteLine("toma de codigos=  " + coCurso + coSalon + coLaboratorio + coHorario + coSeccion + coCarrera+coEmpleado);
         //           ActualizarDatos(coCurso,coSalon, coLaboratorio,coHorario,coSeccion,coEmpleado,coCarrera);
         //           //MessageBox.Show("funcion tomar codigos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
         //       }

         //   }

            
            public void guardarDatos(String gcurso,String gSalon,String glaboratorio,String ghorario, String gseccion,String gempleado,String gcarrera) {
                int condicion = 1;
                _comando = new OdbcCommand(String.Format("insert into paquete(estado,codigo_curso,codigo_salon,codigo_laboratorio,codigoHorario,codigo_seccion,codigo_empleado,condicion,codigoCarrera) values ('" + estado + "','" + gcurso + "','" + gSalon + "','" + glaboratorio + "','" + ghorario + "','" + gseccion + "','" + gempleado + "','"+condicion+"','" + gcarrera + "')"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
            }

            //public void ActualizarDatos(String gcurso, String gSalon, String glaboratorio, String ghorario, String gseccion, String gempleado, String gcarrera)
            //{
            //    //int condicion = 1;
            //    _comando = new OdbcCommand(String.Format("UPDATE paquete SET codigo_curso='"+gcurso+"',codigo_salon='"+gSalon+"',codigo_laboratorio='"+glaboratorio+"',codigoHorario='"+ghorario+"',codigo_seccion='"+gseccion+"',codigo_empleado='"+gempleado+"',codigoCarrera='"+gcarrera+"' WHERE ccodigo_paquete='"+sCod+"'"), ConexionODBC.Conexion.ObtenerConexion());
            //    _comando.ExecuteNonQuery();
            //}

            private void btnGuardar_Click(object sender, EventArgs e)
            {
                if (!cmbCarrera.Text.Equals("") && !cmbCurso.Text.Equals("") && !cmbSalon.Text.Equals("") && !cmbLaboratorio.Text.Equals("") && !cmbHorario.Text.Equals("") && !cmbSeccion.Text.Equals(""))
                {
                    //MessageBox.Show("entro al primer if");
                    funtomarDatosCombos();
                    System.Console.WriteLine("codigos de mierda"+tomaCurso + tomaEmpleado + tomaSalon + tomaLaboratorio + tomaHorario + tomaSeccion + tomaCarrera);
                    funCodigosTomarCodigos(tomaCurso,tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaCarrera,tomaEmpleado);
                    if (funvalidarHorario(coCurso, coSalon, coLaboratorio, coHorario, coSeccion, coCarrera,coEmpleado) == true)
                    {
                        MessageBox.Show("Lo sentimos El horario ya esta LLeno");
                    }
                    else
                    {
                        funtomarDatosCombos();
                        funTomarCodigosAGuardar(tomaCurso, tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaCarrera,tomaEmpleado);
                        string usu = claseUsuario.varibaleUsuario;
                        claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "INSERTAR", "paquete");
                        MessageBox.Show("El Horario se Guardo con Exito");
                        bloquearTodos();
                        funlimpiar();
                    }
                }
                else { MessageBox.Show("Todas las listas desplegables deben llenarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

            private void btnNuevo_Click(object sender, EventArgs e)
            {
                habilitarConNuevo();
            }

            private void btnCancelar_Click(object sender, EventArgs e)
            {
                funlimpiar();
                bloquearTodos();
            }

            private void btnEditar_Click(object sender, EventArgs e)
            {
                //if (!cmbCarrera.Text.Equals("") && !cmbCurso.Text.Equals("") && !cmbSalon.Text.Equals("") && !cmbLaboratorio.Text.Equals("") && !cmbHorario.Text.Equals("") && !cmbSeccion.Text.Equals(""))
                //{
                //    //MessageBox.Show("entro al primer if");
                //    funtomarDatosCombos();
                //    //System.Console.WriteLine("codigos de mierda"+tomaCurso + tomaEmpleado + tomaSalon + tomaLaboratorio + tomaHorario + tomaSeccion + tomaCarrera);
                //    funCodigosTomarCodigos(tomaCurso,tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaCarrera,tomaEmpleado);
                //    if (funvalidarHorarioActualizar(coCurso, coSalon, coLaboratorio, coHorario, coSeccion, coCarrera,coEmpleado) == true)
                //    {
                //        MessageBox.Show("Lo sentiomos El horario ya esta LLeno");
                //    }
                //    else
                //    {
                //        funtomarDatosCombos();
                //        funTomarCodigosActualizar(tomaCurso, tomaSalon, tomaLaboratorio, tomaHorario, tomaSeccion, tomaCarrera,tomaEmpleado);
                //        MessageBox.Show("El Horario se Actualizo con exito");
                //        funlimpiar();
                //    }
                //}
                //else { MessageBox.Show("Todas las listas desplegables deben llenarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
            }

            private void btnEliminar_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("¿Desea Eliminar El Horario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _comando = new OdbcCommand(String.Format("DELETE FROM paquete WHERE ccodigo_paquete = '" + sCod + "'"), ConexionODBC.Conexion.ObtenerConexion());
                    _comando.ExecuteNonQuery();
                    string usu = claseUsuario.varibaleUsuario;
                    claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "ELIMINAR", "paquete");
                    bloquearTodos();
                    funlimpiar();
                }
            }

           

           
        
       
    }
}
