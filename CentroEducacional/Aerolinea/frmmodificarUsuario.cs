using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//PROGRAMADOR Y ANALISTA: Pamela Selman


namespace Aerolinea
{
    public partial class frmmodificarUsuario : Form
    {
        public frmmodificarUsuario()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmcontrolUsuarios regresar = new frmcontrolUsuarios();
            regresar.Show();
        }

        private void funLlenarComboTipoUsuarioModificar()
        {
            /*using (clasconexion.funobtenerConexion())
            {

                string squery = "SELECT codigo_persona, descripcion FROM ce2016.ROL";
                MySqlCommand cmdc = new MySqlCommand(squery, clasconexion.funobtenerConexion());
                DataTable dtDatos = new DataTable();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter(squery, clasconexion.funobtenerConexion());
                mdaDatos.Fill(dtDatos);
                cmbSeleccionartipoModificar.ValueMember = "codigo_persona";
                cmbSeleccionartipoModificar.DisplayMember = "descripcion";
                cmbSeleccionartipoModificar.DataSource = dtDatos;
                clasconexion.funobtenerConexion().Close();
            }*/
        }
        private void funLlenarComboSeleccionarUsuarioModificar()
        {
            /*using (clasconexion.funobtenerConexion())
            {

                string squery = "SELECT codigo_persona, user FROM ce2016.USUARIO";
                MySqlCommand cmdc = new MySqlCommand(squery, clasconexion.funobtenerConexion());
                DataTable dtDatos = new DataTable();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter(squery, clasconexion.funobtenerConexion());
                mdaDatos.Fill(dtDatos);
                cmbusuarioModificar.ValueMember = "codigo_persona";
                cmbusuarioModificar.DisplayMember = "user";
                cmbusuarioModificar.DataSource = dtDatos;
                clasconexion.funobtenerConexion().Close();
            }*/
        }
        private void funLlenarTextBox()
        {
            /*using (clasconexion.funobtenerConexion())
            {
                string squeryBuscarUsuario = "SELECT codigo_persona, nombre_usuario, apellido, user, password_usuario, estado, codigo_rol FROM ce2016.USUARIO where user = '" + cmbusuarioModificar.Text+ "';";
                MySqlCommand cmdc = new MySqlCommand(squeryBuscarUsuario, clasconexion.funobtenerConexion());
                MySqlDataReader drdr = cmdc.ExecuteReader();
                if (drdr.Read())
                {
                    txtNombreModificar.Text= Convert.ToString(drdr["nombre_usuario"]);
                    txtApellidoModificar.Text= Convert.ToString(drdr["apellido"]);
                    txtUserModificar.Text = Convert.ToString(drdr["user"]);
                    txtPasswordModificar.Text = Convert.ToString(drdr["password_usuario"]);
                    cmbModificarEstado.Text = Convert.ToString(drdr["estado"]);
                    cmbSeleccionartipoModificar.Text= Convert.ToString(drdr["codigo_rol"]);
                }
            }*/
        }
        private void funguardarModificacion() {
            /*using (clasconexion.funobtenerConexion())
            {
                string modificarNombre= "UPDATE USUARIO SET nombre_usuario = " + "'" + txtNombreModificar.Text + "'" + " WHERE codigo_persona = '" + cmbusuarioModificar.SelectedValue + "'";
                string modificarApellido = "UPDATE USUARIO SET apellido     = " + "'" + txtApellidoModificar.Text + "'" + " WHERE codigo_persona= '" + cmbusuarioModificar.SelectedValue + "'";
                string modificarUser = "UPDATE USUARIO SET   user = " + "'" + txtUserModificar.Text + "'" + " WHERE codigo_persona = '" + cmbusuarioModificar.SelectedValue + "'";
                string modificarPass = "UPDATE USUARIO SET   password_usuario = " + "'" + txtPasswordModificar.Text + "'" + " WHERE codigo_persona = '" + cmbusuarioModificar.SelectedValue + "'";
                string modificarTipo = "UPDATE USUARIO SET   codigo_rol = " + "'" + cmbSeleccionartipoModificar.SelectedValue + "'" + " WHERE codigo_persona = '" + cmbusuarioModificar.SelectedValue + "'";
                MySqlConnection cn7 = new MySqlConnection();
                cn7 = clasconexion.funobtenerConexion();
                MySqlCommand cmd2 = new MySqlCommand(modificarNombre, clasconexion.funobtenerConexion());
                MySqlCommand cmd3 = new MySqlCommand(modificarApellido, clasconexion.funobtenerConexion());
                MySqlCommand cmd4 = new MySqlCommand(modificarUser, clasconexion.funobtenerConexion());
                MySqlCommand cmd5 = new MySqlCommand(modificarPass, clasconexion.funobtenerConexion());
                MySqlCommand cmd6 = new MySqlCommand(modificarTipo, clasconexion.funobtenerConexion());
                MySqlCommand cmd7 = new MySqlCommand();
                MySqlDataReader MyReader;
                MyReader = cmd2.ExecuteReader();
                MyReader = cmd3.ExecuteReader();
                MyReader = cmd4.ExecuteReader();
                MyReader = cmd5.ExecuteReader();
                MyReader = cmd6.ExecuteReader();
                cmd7.Connection = cn7;
                cmd7.CommandText = "UPDATE USUARIO SET   estado = " + "'" + cmbModificarEstado.SelectedItem + "'" + " WHERE codigo_persona = '" + cmbusuarioModificar.SelectedValue + "'";
                int numRowsUpdated2 = cmd7.ExecuteNonQuery();
                MessageBox.Show("USUARIO MODIFICADO");
                //INGRESO BITACORA
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Modifico Usaurio", "Usuario");
                //FIN INGRESO BITACORA
                clasconexion.funobtenerConexion().Close();
            }*/
        }
        private void frmmodificarUsuario_Load(object sender, EventArgs e)
        {
            funLlenarComboTipoUsuarioModificar();
            funLlenarComboSeleccionarUsuarioModificar();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            funLlenarTextBox();
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            funguardarModificacion();
            this.Close();
            frmcontrolUsuarios usuarios = new frmcontrolUsuarios();
            usuarios.Show();
        }
    }
}
