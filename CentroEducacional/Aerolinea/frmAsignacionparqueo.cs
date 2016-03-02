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
    public partial class frmAsignacionparqueo : Form
    {
        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        public frmAsignacionparqueo()
        {
            InitializeComponent();
        }
         
        private void funLlenarComboTipoUsuario()
        {
            string squery = "SELECT codigo_parqueo, ubicacion FROM parqueo";
            OdbcCommand cmdc = new OdbcCommand(squery, ConexionODBC.Conexion.ObtenerConexion());
            DataTable dtDatos = new DataTable();
            OdbcDataAdapter mdaDatos = new OdbcDataAdapter(squery, ConexionODBC.Conexion.ObtenerConexion());
            mdaDatos.Fill(dtDatos);
            comboBox1.ValueMember = "codigo_parqueo";
            comboBox1.DisplayMember = "ubicacion";
            comboBox1.DataSource = dtDatos;
        }


        private void funbuscarUsuario()
        {

            string squeryBuscarUsuario = "SELECT codigo_asignacion_parqueo as CodigoParqueo, codigo_parqueo as Parqueo, codigoCarnet as IdentificacionAlumno FROM asignaion_parqueo  where codigoCarnet='" + textBox1.Text + "'";
            OdbcCommand cmdc = new OdbcCommand(squeryBuscarUsuario, ConexionODBC.Conexion.ObtenerConexion());
            DataTable dtDat = new DataTable();
            OdbcDataAdapter mdaDat = new OdbcDataAdapter(squeryBuscarUsuario, ConexionODBC.Conexion.ObtenerConexion());
            mdaDat.Fill(dtDat);
            dataGridView1.DataSource = dtDat;




        }
        public static void insertarparqueo(String codigo_asignacion_parqueo, String codigo_parqueo, String codigo_carnet)
        {

            if (MessageBox.Show("¿Asignar parqueo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                string est = "ACTIVO";
                _comando = new OdbcCommand(String.Format("insert into asignacion_parqueo(codigo_asignacion_parqueo, codigo_parqueo, codigo_carnet) values ('"+ 1 +"','" + codigo_parqueo + "','" +  codigo_carnet +"')"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                MessageBox.Show("Alumno Correcatamente Inscrito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
               // limpiar();
                //bloquearTodos();
            }

   
        }
        private void frmAsignacionparqueo_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            funLlenarComboTipoUsuario();
        
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Asignar parqueo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                
                _comando = new OdbcCommand(String.Format("insert into asignacion_parqueo(codigo_asignacion_parqueo, codigo_parqueo, codigoCarnet) values ('" + 1 + "','" + comboBox1 + "','" + textBox1.Text + "')"), ConexionODBC.Conexion.ObtenerConexion());
                _comando.ExecuteNonQuery();
                MessageBox.Show("Se le asigno parqueo ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                funbuscarUsuario();
            }
            else
            {
                // error();
            }

   
        }
    }
}
