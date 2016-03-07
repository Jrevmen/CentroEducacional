using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using ConexionODBC;
using System.Net;
using System.Threading;

namespace Aerolinea
{
    class claseUsuario
    {
        public static string varibaleUsuario;
        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        public static void timeCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Thread.Sleep(5000);  // wait for a while
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public static Boolean Autentificar(String txtUsuario, String txtContra)
        {
            Boolean Encontre = false;
            _comando = new OdbcCommand(String.Format("select * from USUARIO where nombre_usuario = '{0}' and password_usuario = '{1}' and estado = 'ACTIVO' and condicion = 1", txtUsuario, txtContra), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                Encontre = true;
            return Encontre;
        }

        public static void funobtenerBitacora(String txtUsuario, String Accion, String table)
        {
            string ip = ObtenerIP();
            string codigo = "";
            _comando = new OdbcCommand(String.Format("select codigo_usuario from USUARIO where nombre_usuario = '{0}'", txtUsuario), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                codigo = _reader.GetString(0);

            _comando = new OdbcCommand(String.Format("INSERT INTO BITACORA (accion, tabla, fecha, hora, ip, codigo_usuario) VALUES('{0}','{1}',CURDATE(), DATE_FORMAT(CURTIME(), '%h:%i:%s'), '{2}','{3}')", Accion, table, ip, codigo), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
        }

        public static string ObtenerIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public static String ObtenerPermisosForm(String txtUsuario, String sForm)
        {
            string usuario = "", rol = "", permiso = "no";
            _comando = new OdbcCommand(String.Format("select codigo_usuario from USUARIO where nombre_usuario = '{0}'", txtUsuario), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
               usuario = _reader.GetString(0);
            _comando = new OdbcCommand(String.Format("select codigo_rol from USUARIO where codigo_usuario = '{0}'", usuario), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                rol = _reader.GetString(0);
            _comando = new OdbcCommand(String.Format("select permiso from PRIVILEGIOS where formulario = '{0}' and codigo_rol = '{1}'", sForm, rol), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                permiso = _reader.GetString(0);
            return permiso;
        }


       
        

        public static Boolean[] PermisosBotones(String txtUsuario, String formulario)
        {
            Boolean[] permisos = { false, false, false };
            string usuario = "", rol = "", privilegio = "";
            int i = 0;
            _comando = new OdbcCommand(String.Format("select codigo_usuario from USUARIO where nombre_usuario = '{0}'", txtUsuario), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                usuario = _reader.GetString(0);
            _comando = new OdbcCommand(String.Format("select codigo_rol from USUARIO where codigo_usuario = '{0}'", usuario), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if (_reader.Read())
                rol = _reader.GetString(0);
            _comando = new OdbcCommand(String.Format("select codigo_privilegios from PRIVILEGIOS where codigo_rol = '{0}' and formulario = '{1}'", rol,formulario), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            if(_reader.Read())
                privilegio = _reader.GetString(0);
            MessageBox.Show("Privilego: "+privilegio);
            _comando = new OdbcCommand(String.Format("select validacion from PERMISO where codigo_privilegios = '{0}'", privilegio), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                permisos[i] = _reader.GetBoolean(0);
                MessageBox.Show(i + " " + permisos[i]);
                i++;
            }
            return permisos;
        }
    }
}
