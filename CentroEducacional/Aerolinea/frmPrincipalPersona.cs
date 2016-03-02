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
    public partial class frmPrincipalPersona : Form
    {
        public frmPrincipalPersona()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("persona", "SELECT dpi as DPI, persona.codigopersona as Codigo,nombre as Nombre, apellido as Apellido, fechaNacimiento as Fecha, sexo as Sexo, persona.estado as Estado, direccion as Direccion, email.email as Email, telefono.telefono as Telefono from persona, direccion, email, telefono WHERE persona.condicion = '1'AND direccion.codigopersona = persona.codigopersona AND email.codigopersona = persona.codigopersona AND telefono.codigopersona = persona.codigopersona", "consulta", grdPersona);
        }

        private void grdPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdPersona_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodPersona = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sDpi = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombre = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sApellido = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sFecha = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string sSexo = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[5].Value.ToString();
            string sDireccion = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[7].Value.ToString();
            string sEmail = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[8].Value.ToString();
            string sTelefono = grdPersona.Rows[grdPersona.CurrentCell.RowIndex].Cells[9].Value.ToString();
            frmPersona temp = new frmPersona(sCodPersona, sDpi, sNombre, sApellido, sFecha, sSexo, sDireccion, sEmail, sTelefono);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPersona temp = new frmPersona();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdPersona);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdPersona);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdPersona);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdPersona);
        }
    }
}
