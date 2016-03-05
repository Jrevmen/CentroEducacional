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

namespace Aerolinea
{
    public partial class frmPrincipalUsuarios : Form
    {
        public frmPrincipalUsuarios()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("usuario", "SELECT usuario.codigo_usuario as Codigo, usuario.nombre_usuario as Username, usuario.password_usuario as Password, rol.tipo as Rol, usuario.estado as Estado, persona.nombre as Nombre, persona.apellido as Apellido from usuario, persona, rol where usuario.codigo_rol = rol.codigo_rol", "consulta", grdUsuarios);
            
        }
        
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmcontrolUsuarios user = new frmcontrolUsuarios();
            user.Show();
        }

        private void frmPrincipalUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void grdFacultad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string codUsuario = grdUsuarios.Rows[grdUsuarios.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string susuario = grdUsuarios.Rows[grdUsuarios.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmFacultad temp = new frmFacultad(codUsuario, susuario);
            temp.Show();
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("usuario", "SELECT codigo_usuario as Codigo,nombre_usuario as Nombre, estado as Estado,codigo_rol as Rol   from usuario WHERE condicion = '1' AND nombre_usuario LIKE '" + txtBuscar.Text + "%'", "consulta", grdUsuarios);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdUsuarios);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdUsuarios);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdUsuarios);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdUsuarios);
        }
    }
}
