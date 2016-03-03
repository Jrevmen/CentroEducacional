using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace ConexionODBC
{
    public class Conexion
    {

        public static OdbcConnection conn;
        public static OdbcConnection ObtenerConexion()
        {
            conn = new OdbcConnection();
            conn.ConnectionString = "Dsn=seguridadv1.0;uid=root";
            conn.Open();
            return conn;
        }
        public static void CerrarConexion()
        {
            conn.Close();
        }


    }
}
