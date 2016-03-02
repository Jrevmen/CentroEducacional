using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (claseUsuario.Autentificar(txtUser.Text, txtPass.Text) == true)
            {
                claseUsuario.varibaleUsuario = txtUser.Text;
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Inicio Secion", "Usuario");
                this.Hide();
                frmMenu Menu = new frmMenu();
                Menu.Show();
                Menu.toolStripStatusLabel2.Text = "Usuario: " + txtUser.Text;
                Menu.toolStripStatusLabel.Text = DateTime.Now.ToString();
                //MessageBox.Show("Bienvenid@:  " + claseUsuario.user(txtUser.Text, txtPass.Text) + ":" + claseUsuario.varibaleUsuario);
            }
            else
            {
                MessageBox.Show("Usuario o Password Incorrecto, Si el problema persiste su Usuario esta Inactivo");
                txtUser.Clear();
                txtPass.Clear();
            }
        }
    }
}
