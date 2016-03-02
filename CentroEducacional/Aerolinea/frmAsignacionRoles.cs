using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionODBC;
using System.Data.Odbc;

namespace Aerolinea
{
    public partial class frmAsignacionRoles : Form
    {
        public frmAsignacionRoles()
        {
            InitializeComponent();
        }
        DataSet dsResult = new DataSet();
        DataTable dt = new DataTable();
        private void cmbeliminarUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = cbBuscaUsuario.SelectedItem.ToString();
            OdbcCommand _comando = new OdbcCommand(String.Format(
                //string sql = "SELECT CONCAT(vnombredoc,' ',vapellido, '      ', ' ',vdirecciondoc)  AS campos FROM madoctor";
            "SELECT CONCAT(nombre_usuario) FROM USUARIO as campos WHERE nombre_usuario like  " + "'" + valor + "%'"), ConexionODBC.Conexion.ObtenerConexion());
            //"SELECT nombre  FROM PERSONA WHERE nombre = " + valor + "'"), ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
           // cbMuestraUser.Items.Clear();




            while (_reader.Read())
            {
                //MessageBox.Show("entrando a consulta2");
                cbMuestraUser.Items.Add(_reader[0].ToString());

            }
            _reader.Close();
           // cbMuestraUser.Text = "";


        }
        /*public DataSet ConvertirLista(List<claseUsuario> lista)
        {
           

            //Creo un DataTable solo con las propiedades que quiero
            dt.Columns.Add("frmFacultad");
            dt.Columns.Add("frmPensum");
            dt.Columns.Add("frmmodificarUsuario");
          


            foreach (claseUsuario uni in lista)
            {
                DataRow row = dt.NewRow();
                // realizo las asignaciones correspondientes
                row["frmFacultad"] = uni.NombreForm;
                row["frmPensum"] = uni.NombreForm;
                row["frmmodificarUsuario"] = uni.NombreForm;
               
                dt.Rows.Add(row);
            }

            dsResult.Tables.Add(dt);
            return dsResult;
        }*/

        private void lblEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void cbMuestraUser_SelectedIndexChanged(object sender, EventArgs e)
        {



            string valor2 = cbBuscaUsuario.SelectedItem.ToString();
          
            OdbcCommand _comando = new OdbcCommand(String.Format(
           "SELECT codigo_rol FROM USUARIO  WHERE nombre_usuario like  " + "'" + valor2 + "%'"), ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
            cbMuestraUser.Items.Clear();
            while (_reader.Read())
            {
               // MessageBox.Show("entrando a consulta2");
                txtPrueba.Text = _reader["codigo_rol"].ToString();



            }
            _reader.Close();
           // cbMuestraUser.Text = "";

            string per= "si";
            string es= "ACTIVO";
            
            string squery = "SELECT formulario FROM PRIVILEGIOS WHERE codigo_rol like  " + "'" + txtPrueba.Text + "%'";
            OdbcCommand cmdc = new OdbcCommand(squery, ConexionODBC.Conexion.ObtenerConexion());
            DataTable dtDatos = new DataTable();
            OdbcDataAdapter mdaDatos = new OdbcDataAdapter(squery, ConexionODBC.Conexion.ObtenerConexion());
            mdaDatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            if (dt == dtDatos)
            {
                MessageBox.Show("formulario encontrado en la lista");
            }
            foreach (DataRow row in dtDatos.Rows)
            {
               
                string validando = "frmFacultad";
                string formx = row["formulario"].ToString();
                //string permisos= row["permiso"].ToString();
               // string status= row["estado"].ToString();
              //  MessageBox.Show("esto lleva string " +formx);
                
                  

                            ///String.Compare(formx, validando, true);
                           
                            
                                frmFacultad form2 = new frmFacultad();
                                
                                form2.Visible = false;
                                //MessageBox.Show("llegando a bloqueo");
                            
                            }
                        
                        
                        
                        }
                    
                    
                   
                    
                
               
               
               
            
           
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}