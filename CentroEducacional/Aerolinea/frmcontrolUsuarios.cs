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
using Aerolinea.Properties;


namespace Aerolinea
{
    public partial class frmcontrolUsuarios : Form
    {
        int varInsertar, varConsultar, varEliminar, check = 0;
        string codigoPrivilegio, varCondicion;
        
        public frmcontrolUsuarios()
        {
            InitializeComponent();
            llenarGrid();
            this.cmbModulos.SelectedItem = "Todos";
        }

        public frmcontrolUsuarios(string usuario, string password, string rol, string estado, string nombre, string apellido)
        {
            InitializeComponent();
            txtUser.Text = usuario;
            txtPassword.Text = password;
            cmbRolPre.Text= rol;
            cbMuestra.Text  = nombre;
            this.cmbModulos.SelectedItem = "Todos";
            llenarGrid();
        }

        public void llenarGrid()
        {
            GridPrivilegios.Rows.Add("frmAsignParq", false, false, false, false);
            GridPrivilegios.Rows.Add("frmAsigOrd", false, false, false, false);
            GridPrivilegios.Rows.Add("frmBitacora", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCarrera", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCertificacion", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroDoc", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroInscrip", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroParqueo", false, false, false, false);
            GridPrivilegios.Rows.Add("frmCobroReasig", false, false, false, false);
            GridPrivilegios.Rows.Add("frmcontrolUsuarios", false, false, false, false);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void labelUser_Click(object sender, EventArgs e)
        {

        }
        
        private void frmControlUsuarios_Load(object sender, EventArgs e)
        {
            claseUsuario.timeCursor();
            cmbRolPre.Enabled = false;
            txtRol.Enabled = false;
            txtDesc.Enabled = false;
            funRol();

        }
        
        private void funRol()
        {
            OdbcCommand _comando = new OdbcCommand(String.Format(
            "SELECT  CONCAT(codigo_rol,' .', tipo),codigo_rol FROM ROL as campos"), ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
            cmbRolPre.Items.Clear();
            while (_reader.Read())
            {
                cmbRolPre.Items.Add(_reader[0].ToString());
                cmbRolPre.ValueMember = "campos";
                txtGuarda2.Text = _reader["codigo_rol"].ToString();
            }
            ConexionODBC.Conexion.ObtenerConexion().Close();
            _reader.Close();
        }
          
        private void cbMuestra_SelectedIndexChanged(object sender, EventArgs e)
        {
              if (txtPassword.Text != txtRectificaPassword.Text)
                {
                  MessageBox.Show("Rectifique que la contraseña sea igual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
        }

        public void funAgregaUsuario()
        {
            string sInsertarUsuario = "INSERT INTO USUARIO  (nombre_usuario, password_usuario,estado, codigo_rol, codigopersona, condicion )values('" + txtUser.Text + "','" + txtPassword.Text + "','" + "ACTIVO" + "','" + txtGuarda2.Text + "','" + txtGuarda.Text + "','" + "1" + "')";
            OdbcCommand cmd2 = new OdbcCommand(sInsertarUsuario, ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader MyReader = cmd2.ExecuteReader();
            ConexionODBC.Conexion.ObtenerConexion().Close();

            //INGRESO BITACORA 
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Ingreso Usuario", "USUARIO");
            //FIN iNGRESO bITACORA*/

    }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            claseUsuario.timeCursor();
            if (rdPre.Checked == true){
                funAgregaUsuario();
            }
            else if (rdNuevo.Checked == true){
                string sInsertarUsuario = "INSERT INTO ROL  (tipo,descripcion,estado, condicion )values('" + txtRol.Text + "','" + txtDesc.Text + "','" + "ACTIVO" + "','" + "1" + "')";
                OdbcCommand cmd2 = new OdbcCommand(sInsertarUsuario, ConexionODBC.Conexion.ObtenerConexion());
                OdbcDataReader MyReader = cmd2.ExecuteReader();
                ConexionODBC.Conexion.ObtenerConexion().Close();
                funAgregaUsuario();

                OdbcCommand _comando = new OdbcCommand(String.Format("select codigo_rol from rol"), ConexionODBC.Conexion.ObtenerConexion());
                OdbcDataReader _readerN = _comando.ExecuteReader();
                while (_readerN.Read())
                {
                    txtXX.Text = _readerN["codigo_rol"].ToString();
                }
                _readerN.Close();
                ConexionODBC.Conexion.ObtenerConexion().Close();
                string cod = txtXX.Text;
                string parametro;
                foreach (DataGridViewRow row in GridPrivilegios.Rows)
                {
                    parametro = Convert.ToString(row.Cells[0].Value);
                    if (Convert.ToBoolean(row.Cells[1].Value) == true){
                        varCondicion = "si";
                    }else{
                        varCondicion = "no";
                    }
                    
                    string query = "INSERT INTO PRIVILEGIOS (formulario,permiso,estado,codigo_rol,condicion) VALUES ('" + parametro + "','" + varCondicion + "','" + "ACTIVO" + "','" + cod + "','" + "1" + "')";
                    OdbcCommand cmdForm = new OdbcCommand(query, ConexionODBC.Conexion.ObtenerConexion());
                    cmdForm.ExecuteNonQuery();
                    ConexionODBC.Conexion.ObtenerConexion().Close();
                                
                    string query2 = "select max(codigo_privilegios) from privilegios";
                    OdbcCommand cmdForm2 = new OdbcCommand(query2, ConexionODBC.Conexion.ObtenerConexion());
                    OdbcDataReader _readerN2 = cmdForm2.ExecuteReader();
                    if (_readerN2.Read()){
                        codigoPrivilegio = _readerN2.GetString(0);
                    }
                    ConexionODBC.Conexion.ObtenerConexion().Close();

                    if (Convert.ToBoolean(row.Cells[2].Value) == true){
                        varInsertar = 1;
                    }
                    else{
                        varInsertar = 0;
                    }
                                
                    if (Convert.ToBoolean(row.Cells[3].Value) == true){
                        varConsultar = 1;
                    }else{
                        varConsultar = 0;
                    }
                                
                    if (Convert.ToBoolean(row.Cells[4].Value) == true){
                        varEliminar = 1;
                    }else{
                        varEliminar = 0;
                    }
                                
                    OdbcCommand cmdInsertar = new OdbcCommand("insert into permiso (nombre, validacion, estado, codigo_privilegios, condicion) values('INSERTAR', '" + varInsertar + "','ACTIVO','" + codigoPrivilegio + "','1')", ConexionODBC.Conexion.ObtenerConexion());
                    OdbcDataReader _rInsertar = cmdInsertar.ExecuteReader();
                    ConexionODBC.Conexion.ObtenerConexion().Close();
                    OdbcCommand cmdModificar = new OdbcCommand("insert into permiso (nombre, validacion, estado, codigo_privilegios, condicion) values('MODIFICAR', '" + varConsultar + "','ACTIVO','" + codigoPrivilegio + "','1')", ConexionODBC.Conexion.ObtenerConexion());
                    OdbcDataReader _rModificar = cmdModificar.ExecuteReader();
                    ConexionODBC.Conexion.ObtenerConexion().Close();
                    OdbcCommand cmdEliminar = new OdbcCommand("insert into permiso (nombre, validacion, estado, codigo_privilegios, condicion) values('ELIMINAR', '" + varEliminar + "','ACTIVO','" + codigoPrivilegio + "','1')", ConexionODBC.Conexion.ObtenerConexion());
                    OdbcDataReader _rEliminar = cmdEliminar.ExecuteReader();
                    ConexionODBC.Conexion.ObtenerConexion().Close();
                }
                MessageBox.Show("USUARIO REGISTRADO  :)");
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Ingreso Usuario", "USUARIO");
                desseleccionar();
                limpiar();
            }
        }

        private void desseleccionar()
        {
            foreach (DataGridViewRow row in GridPrivilegios.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells[2];
                chk2.Value = !(chk2.Value == null ? false : (bool)chk2.Value);
                DataGridViewCheckBoxCell chk3 = (DataGridViewCheckBoxCell)row.Cells[3];
                chk3.Value = !(chk3.Value == null ? false : (bool)chk3.Value);
                DataGridViewCheckBoxCell chk4 = (DataGridViewCheckBoxCell)row.Cells[4];
                chk4.Value = !(chk4.Value == null ? false : (bool)chk4.Value);
            }
            
        }

        private void limpiar()
        {
            cmbModulos.SelectedItem = "Todos";
            txtPassword.Text = txtRectificaPassword.Text = txtUser.Text = txtRol.Text = txtDesc.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmmodificarUsuario modificar = new frmmodificarUsuario();
            modificar.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void gbPrivilegios_Enter(object sender, EventArgs e)
        {

        }

        private void rdPre_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPre.Checked == true)
            {
                txtRol.Enabled = false;
                cmbRolPre.Enabled = true;
                txtDesc.Enabled = false;
                GridPrivilegios.Enabled = false;
                lblTodo.Enabled = false;
                btnTodo.Enabled = false;
                rdNuevo.Checked = false;
                cmbModulos.Enabled = false;
                lblModulos.Enabled = false;
            }
        }

        private void rdNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNuevo.Checked == true)
            {
                cmbRolPre.Enabled = false;
                txtRol.Enabled = true;
                txtDesc.Enabled = true;
                GridPrivilegios.Enabled = true;
                lblTodo.Enabled = true;
                btnTodo.Enabled = true;
                rdPre.Checked = false;
                cmbModulos.Enabled = true;
                lblModulos.Enabled = true;
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            claseUsuario.timeCursor();
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

        private void cmbRolPre_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        
        }
        
        void cmbRolPre_KeyUp(object sender, KeyEventArgs e)
        {
            string valorRol = cmbRolPre.Text;
            OdbcCommand _comandoRol = new OdbcCommand(String.Format(
            "SELECT   CONCAT(codigo_rol,' .', tipo),codigo_rol FROM ROL as camposRol WHERE tipo like  " + "'" + valorRol + "%'"), ConexionODBC.Conexion.ObtenerConexion());
            OdbcDataReader _readerRol = _comandoRol.ExecuteReader();
            cbMuestra.Items.Clear();
            while (_readerRol.Read())
            {
                cmbRolPre.Items.Add(_readerRol[0].ToString());
                cmbRolPre.ValueMember = "camposRol";
                txtGuarda2.Text = _readerRol["codigo_rol"].ToString();
            }
            _readerRol.Close();
            ConexionODBC.Conexion.ObtenerConexion().Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            ConexionODBC.Conexion.ObtenerConexion().Close();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            if (check == 0)
            {
                foreach (DataGridViewRow row in GridPrivilegios.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                }
                this.btnTodo.Image = Resources._1457297125_stock_form_checkbox;
                check = 1;
            }
            else
            {
                foreach (DataGridViewRow row in GridPrivilegios.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                    chk.Value = !(chk.Value == null ? true : (bool)chk.Value);
                }
                this.btnTodo.Image = Resources._unchecked;
                check = 0;
            }
            
        }

        private void cmbModulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridPrivilegios.Rows.Clear();
            switch (cmbModulos.SelectedItem.ToString())
            {
                case "Todos":
                    llenarGrid();
                break;
                case "Catalogos":
                    GridPrivilegios.Rows.Add("frmCarrera", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmCursos", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmEmpleado", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmFacultad", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmFamilia", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmHorario", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmJornada", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmLaboratorios", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmParqueos", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmPensum", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmPersona", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmPuestos", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmRol", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmSalones", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmSeccion", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmSedes", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmTipoPago", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmTipoServicio", false, false, false, false);
                    GridPrivilegios.Rows.Add("Alumnos", false, false, false, false);
                break;
                case "Administracion":
                    GridPrivilegios.Rows.Add("frmAsignParq", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmAsigOrd", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmCreacionPaquete", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmCreacionPensum", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmReasignacion", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmReinscripcion", false, false, false, false);
                break;
                case "Notas":
                    GridPrivilegios.Rows.Add("frmNotas", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmZona", false, false, false, false);
                break;
                case "Tesoreria":
                    GridPrivilegios.Rows.Add("frmCobroDoc", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmCobroInscrip", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmCobroParqueo", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmCobroReasig", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmPagoEmpleado", false, false, false, false);
                break;
                case "Seguridad":
                    GridPrivilegios.Rows.Add("frmBitacora", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmcontrolUsuarios", false, false, false, false);
                break;
                case "Reportes":
                    GridPrivilegios.Rows.Add("frmPagosPendientes", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmSolvencias", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmTalonarios", false, false, false, false);
                    GridPrivilegios.Rows.Add("frmReporteCatalogos", false, false, false, false);
                break;
            }
        }
    }
}
    


        
        
  
