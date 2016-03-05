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
using Navegador;

namespace Aerolinea
{
    public partial class frmcontrolUsuarios : Form
    {
        public frmcontrolUsuarios()
        {
            InitializeComponent();
            GridPrivilegios.Rows.Add("frmAsignParq", false, false, false, false);
            GridPrivilegios.Rows.Add("frmAsigOrd", false, false, false, false);
            GridPrivilegios.Rows.Add("frmBitacora", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCarrera", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCertificacion", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroDoc", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroInscrip", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroParqueo", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroReasig", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCreacionPaquete", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCreacionPensum", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCursos", false, false, false, false);
            GridPrivilegios.Rows.Add("frmEmpleado", false, false, false, false);
            GridPrivilegios.Rows.Add("frmFacultad", false, false, false, false);
            GridPrivilegios.Rows.Add("frmFamilia", false, false, false, false);
            GridPrivilegios.Rows.Add("frmHorario", false, false, false, false);
            GridPrivilegios.Rows.Add("frmJornada", false, false, false, false);
            GridPrivilegios.Rows.Add("frmLaboratorios", false, false, false, false);
            GridPrivilegios.Rows.Add("frmMensualidads", false, false, false, false);
            GridPrivilegios.Rows.Add("frmNotas", false, false, false, false);
            GridPrivilegios.Rows.Add("frmPagoEmpleado", false, false, false, false);
            GridPrivilegios.Rows.Add("frmPagosPendientes", false, false, false, false);
            GridPrivilegios.Rows.Add("frmParqueos", false, false, false, false);
            GridPrivilegios.Rows.Add("frmPensum", false, false, false, false);
            GridPrivilegios.Rows.Add("frmPersona", false, false, false, false);
            GridPrivilegios.Rows.Add("frmPuestos", false, false, false, false);
            GridPrivilegios.Rows.Add("frmReasignacion", false, false, false, false);
            GridPrivilegios.Rows.Add("frmReinscripcion", false, false, false, false);
            GridPrivilegios.Rows.Add("frmReporteCatalogos", false, false, false, false);
            GridPrivilegios.Rows.Add("frmRol", false, false, false, false);
            GridPrivilegios.Rows.Add("frmSalones", false, false, false, false);
            GridPrivilegios.Rows.Add("frmSeccion", false, false, false, false);
            GridPrivilegios.Rows.Add("frmSedes", false, false, false, false);
            GridPrivilegios.Rows.Add("frmSolvencias", false, false, false, false);
            GridPrivilegios.Rows.Add("frmTalonarios", false, false, false, false);
            GridPrivilegios.Rows.Add("frmTipoPago", false, false, false, false);
            GridPrivilegios.Rows.Add("frmTipoServicio", false, false, false, false);
            GridPrivilegios.Rows.Add("frmUsuario", false, false, false, false);
            GridPrivilegios.Rows.Add("frmZona", false, false, false, false);
            GridPrivilegios.Rows.Add("frmAsignaionRol", false, false, false, false);
            GridPrivilegios.Rows.Add("Alumnos", false, false, false, false);
        }

        DataSet dsResult = new DataSet();
        //DataTable dt = new DataTable();
        int ifilas2, iCodigoUsuario2, varInsertar, varConsultar, varEliminar;
        string recibe, codigoPrivilegio, pasoVariable, varCondicion;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelUser_Click(object sender, EventArgs e)
        {

        }

        private void frmControlUsuarios_Load(object sender, EventArgs e)
        {

           /* OdbcCommand cmd = new OdbcCommand("Select formulario  from privilegios", ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridPrivilegios.DataSource = dt;
            */
            cmbRolPre.Enabled = false;
            txtRol.Enabled = false;
            txtDesc.Enabled = false;

            funRol();
            funLlenarComboTipoUsuario();
            //funLlenarComboPersona();
            funllenarComboEliminarUsuario();
            // funLlenarComboPersona();
            //funbuscarUsuario();
        }
        private void funRol()
        {
            //string valor = cbMuestra.Text;
            OdbcCommand _comando = new OdbcCommand(String.Format(
            "SELECT  CONCAT(codigo_rol,' .', tipo),codigo_rol FROM ROL as campos"), ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
            cmbRolPre.Items.Clear();

            while (_reader.Read())
            {
                // MessageBox.Show("entrando a consulta2");
                cmbRolPre.Items.Add(_reader[0].ToString());
                cmbRolPre.ValueMember = "campos";
                txtGuarda2.Text = _reader["codigo_rol"].ToString();
            }
            _reader.Close();
        }
        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
        }
        private void funlimpiar()
        {

            txtUser.Text = "";
            txtPassword.Text = "";
        }
        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void funconsultarUsuario()
        {

        }
        private void funLlenarComboTipoUsuario()
        {
        }
        private void funbuscarUsuario()
        {

        }
        private void funllenarComboEliminarUsuario()
        {
            /*using (clasconexion.funobtenerConexion())
            {
                string squery = "SELECT codigo_persona, user FROM ce2016.USUARIO where estado='ACTIVO'";
                MySqlCommand cmdc = new MySqlCommand(squery, clasconexion.funobtenerConexion());
                DataTable dtDatos = new DataTable();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter(squery, clasconexion.funobtenerConexion());
                mdaDatos.Fill(dtDatos);
                cmbeliminarUsuario.ValueMember = "codigo_persona";
                cmbeliminarUsuario.DisplayMember = "user";
                cmbeliminarUsuario.DataSource = dtDatos;
                clasconexion.funobtenerConexion().Close();
            }*/
        }
        private void funeliminarUsuario()
        {
            /*using (clasconexion.funobtenerConexion())
            {
                try
                {
                    //string sfechaNacimiento = dtpasajero.Value.ToShortDateString();
                    //MessageBox.Show(sfechaNacimiento);
                    string seliminarUsuario = "UPDATE ce2016.USUARIO set estado = 'INACTIVO' where codigo_persona = '" + cmbeliminarUsuario.SelectedValue + "'"; 
                    MySqlCommand cmd2 = new MySqlCommand(seliminarUsuario, clasconexion.funobtenerConexion());
                    cmd2.ExecuteNonQuery();
                    //INGRESO BITACORA
                    claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Elimino Usuario", "Usuario");
                    //FIN INGRESO BITACORA
                    clasconexion.funobtenerConexion().Close();
                    funconsultarUsuario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/
        }

        private void cmbSeleccionartipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {

        }
        private void rEFRESCARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funconsultarUsuario();
            funllenarComboEliminarUsuario();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cmbseleccionarpersona_SelectedIndexChanged(object sender, EventArgs e)
        {



        }


        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void cbMuestra_SelectedIndexChanged(object sender, EventArgs e)
        {
              if (txtPassword.Text != txtRectificaPassword.Text)
                {


                    MessageBox.Show("Rectifique que la contraseña sea igual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
               

            string s = cbMuestra.SelectedItem.ToString();

            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                //MessageBox.Show("esto lleva split" + word);
                recibe = word;
                //  txtGuarda.Text = word;
                // MessageBox.Show("esto lleva split textbox" + word);
            }
        }
       
        public void funAgregaUsuario()
        {

            /*int ifilasSM;
            int iCodigoUsuarioSM;
            string squery2 = "SELECT COUNT(*) As Cant FROM USUARIO ";
            OdbcCommand cmdSM = new OdbcCommand(squery2, ConexionODBC.Conexion.ObtenerConexion());
            ifilasSM = Convert.ToInt32(cmdSM.ExecuteScalar());
            iCodigoUsuarioSM = ifilasSM + 1;
            MessageBox.Show("pasando consulta COUNT segunda" + iCodigoUsuarioSM);*/

            try
            {
                //string sInsertarUsuario = "INSERT INTO USUARIO  (codigo_usuario, nombre_usuario, password_usuario,estado, codigo_rol, codigopersona, condicion )values(" + iCodigoUsuario2 + ",'" + txtUser.Text + "','" + txtPassword.Text + "','" + "ACTIVO" + "','" + txtGuarda2.Text + "','" + txtGuarda.Text + "','" + "1" + "')";
                string sInsertarUsuario = "INSERT INTO USUARIO  (nombre_usuario, password_usuario,estado, codigo_rol, codigopersona, condicion )values('" + txtUser.Text + "','" + txtPassword.Text + "','" + "ACTIVO" + "','" + txtGuarda2.Text + "','" + txtGuarda.Text + "','" + "1" + "')";
            OdbcCommand cmd2 = new OdbcCommand(sInsertarUsuario, ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            MessageBox.Show("USUARIO REGISTRADO");
            ConexionODBC.Conexion.ObtenerConexion().Close();

            //INGRESO BITACORA 
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Ingreso Usuario", "USUARIO");
            //FIN iNGRESO bITACORA*/
        }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

         if (rdPre.Checked == true)
                    {
                        string squery = "SELECT COUNT(*) As Cant FROM USUARIO ";
                        OdbcCommand cmd = new OdbcCommand(squery, ConexionODBC.Conexion.ObtenerConexion());
                        ifilas2 = Convert.ToInt32(cmd.ExecuteScalar());
                        iCodigoUsuario2 = ifilas2 + 1;
                        funAgregaUsuario();
                        ConexionODBC.Conexion.ObtenerConexion().Close();
                      
                    }
                    else
                    {

                        if (rdNuevo.Checked == true)
                        {

                            int ifilasSM;
                            int iCodigoUsuarioSM;
                            /*string squery2 = "SELECT COUNT(*) As Cant FROM ROL ";
                            OdbcCommand cmdSM = new OdbcCommand(squery2, ConexionODBC.Conexion.ObtenerConexion());
                            ifilasSM = Convert.ToInt32(cmdSM.ExecuteScalar());
                            //iCodigoUsuarioSM = ifilasSM + 1;*/
                            //MessageBox.Show("pasando consulta COUNT segunda" + iCodigoUsuarioSM);

                            //string sInsertarUsuario = "INSERT INTO ROL  (codigo_rol,tipo,descripcion,estado, condicion )values(" + iCodigoUsuarioSM + ",'" + txtRol.Text + "','" + txtDesc.Text + "','" + "ACTIVO" + "','" + "1" + "')";
                            string sInsertarUsuario = "INSERT INTO ROL  (tipo,descripcion,estado, condicion )values('" + txtRol.Text + "','" + txtDesc.Text + "','" + "ACTIVO" + "','" + "1" + "')";
                            OdbcCommand cmd2 = new OdbcCommand(sInsertarUsuario, ConexionODBC.Conexion.ObtenerConexion());
                            OdbcDataReader MyReader;
                            MyReader = cmd2.ExecuteReader();
                            ConexionODBC.Conexion.ObtenerConexion().Close();
                            funAgregaUsuario();
                        }
                        
                    OdbcCommand _comando = new OdbcCommand(String.Format(
                   "select codigo_rol from rol"), ConexionODBC.Conexion.ObtenerConexion());
                    OdbcDataReader _readerN = _comando.ExecuteReader();
                    //cbMuestraPaciente.Items.Clear();
                    while (_readerN.Read())
                    {
                        txtXX.Text = _readerN["codigo_rol"].ToString();

                    }
                    _readerN.Close();
                    string cod = txtXX.Text;


                    string parametro;
          
                   
                  
       foreach (DataGridViewRow row in GridPrivilegios.Rows)
                    {
                        parametro = Convert.ToString(row.Cells[0].Value);

                        //if (GridPrivilegios.IsCurrentCellDirty == true)
                        if (Convert.ToBoolean(row.Cells[1].Value) == true)
                        {
                            varCondicion = "si";
                            //MessageBox.Show("esto tiene que llevar si" +varCondicion);
                        }
                        else
                        {
                            varCondicion = "no";
                            //MessageBox.Show("esto tiene que llevar no    " +varCondicion);
                        }
                        string query = "INSERT INTO PRIVILEGIOS (formulario,permiso,estado,codigo_rol,condicion) VALUES ('" + parametro + "','" +varCondicion + "','" + "ACTIVO" + "','" + cod + "','" + "1" + "')";
                        OdbcCommand cmdForm = new OdbcCommand(query, ConexionODBC.Conexion.ObtenerConexion());
                        cmdForm.Parameters.Clear();
                        /// String value = GridPrivilegios.Rows[1].Cells[1].ToString();
                        //cmdForm.Parameters.AddWithValue("@param", value);
                        //cmdForm.Parameters.AddWithValue(parametro, Convert.ToString(row.Cells[0].Value));
                        cmdForm.ExecuteNonQuery();
                        ConexionODBC.Conexion.ObtenerConexion().Close();
                        string query2 = "select max(codigo_privilegios) from privilegios";
                        OdbcCommand cmdForm2 = new OdbcCommand(query2, ConexionODBC.Conexion.ObtenerConexion());
                        OdbcDataReader _readerN2 = cmdForm2.ExecuteReader();
                        cmdForm2.Parameters.Clear();
                        ConexionODBC.Conexion.ObtenerConexion().Close();
                       
                        if (_readerN2.Read())
                        {
                            codigoPrivilegio = _readerN2.GetString(0);

                            //MessageBox.Show("privilegio  " + codigoPrivilegio);
                        }
                        if (Convert.ToBoolean(row.Cells[2].Value) == true)
                        {
                            varInsertar = 1;
                            //MessageBox.Show("esto tiene que llevar si" + varCondicion);
                        }
                        else
                        {
                            varInsertar = 0;
                            //MessageBox.Show("esto tiene que llevar no    " + varCondicion);
                        }
                        if (Convert.ToBoolean(row.Cells[3].Value) == true)
                        {
                            varConsultar = 1;
                            //MessageBox.Show("esto tiene que llevar si" + varCondicion);
                        }
                        else
                        {
                            varConsultar = 0;
                            //MessageBox.Show("esto tiene que llevar no    " + varCondicion);
                        }
                        if (Convert.ToBoolean(row.Cells[4].Value) == true)
                        {
                            varEliminar = 1;
                            //MessageBox.Show("esto tiene que llevar si" + varCondicion);
                        }
                        else
                        {
                            varEliminar = 0;
                            //MessageBox.Show("esto tiene que llevar no    " + varCondicion);
                        }
                        OdbcCommand cmdInsertar = new OdbcCommand("insert into permiso (nombre, validacion, estado, codigo_privilegios, condicion) values('INSERTAR', '" + varInsertar + "','ACTIVO','"+codigoPrivilegio+"','1')", ConexionODBC.Conexion.ObtenerConexion());
                        OdbcDataReader _rInsertar = cmdInsertar.ExecuteReader();
                        ConexionODBC.Conexion.ObtenerConexion().Close();
                        OdbcCommand cmdModificar = new OdbcCommand("insert into permiso (nombre, validacion, estado, codigo_privilegios, condicion) values('MODIFICAR', '" + varConsultar + "','ACTIVO','" + codigoPrivilegio + "','1')", ConexionODBC.Conexion.ObtenerConexion());
                        OdbcDataReader _rModificar = cmdModificar.ExecuteReader();
                        ConexionODBC.Conexion.ObtenerConexion().Close();
                        OdbcCommand cmdEliminar = new OdbcCommand("insert into permiso (nombre, validacion, estado, codigo_privilegios, condicion) values('ELIMINAR', '" + varEliminar + "','ACTIVO','" + codigoPrivilegio + "','1')", ConexionODBC.Conexion.ObtenerConexion());
                        OdbcDataReader _rEliminar = cmdEliminar.ExecuteReader();
                        ConexionODBC.Conexion.ObtenerConexion().Close();
                    }
            
                    string guarda = txtGuarda.Text + 1;
              try
            {
                string sInsertarUsuario = "INSERT INTO USUARIO  (codigo_usuario, nombre_usuario, password_usuario,estado, codigo_rol , codigopersona, condicion )values(" + iCodigoUsuario2 + ",'" + txtUser.Text + "','" + txtPassword.Text + "','" + "ACTIVO" + "','" + txtGuarda2.Text + "','" + txtGuarda.Text + "','" + "1" + "')";
            OdbcCommand cmd2 = new OdbcCommand(sInsertarUsuario, ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            MessageBox.Show("USUARIO REGISTRADO");
            //INGRESO BITACORA 
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Ingreso Usuario", "USUARIO");
           
          
                  }
                        catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                     


                    }
                        
                                 
            }
           
        
    

            

           

        


        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmmodificarUsuario modificar = new frmmodificarUsuario();
            modificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            funeliminarUsuario();
            funllenarComboEliminarUsuario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            funbuscarUsuario();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void gbPrivilegios_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtRectificaPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdPre_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPre.Checked == true)
            {
                rdNuevo.Enabled = false;
                txtRol.Enabled = false;
                cmbRolPre.Enabled = true;
                txtDesc.Enabled = false;


            }
        }

        private void rdNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNuevo.Checked == true)
            {
                rdPre.Enabled = false;
                cmbRolPre.Enabled = false;
                txtRol.Enabled = true;
                txtDesc.Enabled = true;

            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cmbRolPre.Enabled = false;
            txtRol.Enabled = false;

            rdNuevo.Enabled = true;
            rdPre.Enabled = true;

            rdNuevo.Checked = false;
            rdPre.Checked = false;


        }

        private void GridPrivilegios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void GridPrivilegios_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (GridPrivilegios.Columns["Privilegio"].Selected == true)
            {

                GridPrivilegios.Columns["Guardar"].Selected = false;
                GridPrivilegios.Columns["Editar"].ReadOnly = true;
                GridPrivilegios.Columns["Eliminar"].ReadOnly = true;
            }

        }

        private void txtBuscarPersona_TextChanged(object sender, EventArgs e)
        {

        }




        private void txtBuscarPersona(object sender, KeyEventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }

       

        private void cmbRolPre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ss = cmbRolPre.SelectedItem.ToString();

            string[] words2 = ss.Split(' ');
            foreach (string word2 in words2)
            {
                //MessageBox.Show("esto lleva split" + word);
                recibe = word2;
                //txtGuarda2.Text = word2;
                //MessageBox.Show("esto lleva split textbox" + word2);
            }
            string per = "si";
            string es = "ACTIVO";

            string squery = "SELECT formulario FROM PRIVILEGIOS WHERE codigo_rol like  " + "'" + txtGuarda.Text + "%'";
            OdbcCommand cmdc = new OdbcCommand(squery, ConexionODBC.Conexion.ObtenerConexion());
            DataTable dtDatos = new DataTable();
            OdbcDataAdapter mdaDatos = new OdbcDataAdapter(squery, ConexionODBC.Conexion.ObtenerConexion());
            mdaDatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            MessageBox.Show("formulario encontrado en la lista" + dtDatos);
            pasoVariable = txtGuarda.Text;




            frmFacultad form2 = new frmFacultad();

            form2.Visible = false;


        }








        private void cmbRolPre_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {


        }

        private void GridPrivilegios_ColumnToolTipTextChanged(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e)
        {

        }

        private void txtRectificaPassword_TextChanged_1(object sender, EventArgs e)
        {
           


            }

        private void txtGuarda2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMuestra_KeyUp_1(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            string valor = cbMuestra.Text;
            OdbcCommand _comando = new OdbcCommand(String.Format(
            "SELECT   CONCAT(codigopersona,' .', nombre,'  ',apellido),codigopersona FROM PERSONA as campos WHERE nombre like  " + "'" + valor + "%'"), ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
            cbMuestra.Items.Clear();

            while (_reader.Read())
            {
                // MessageBox.Show("entrando a consulta2");
                cbMuestra.Items.Add(_reader[0].ToString());
                cbMuestra.ValueMember = "campos";
                txtGuarda.Text = _reader["codigopersona"].ToString();
            }
            _reader.Close();

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
        }

        }
        }
    


        
        
  
