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

namespace Aerolinea
{
    public partial class frmPrincipalCarnet : Form
    {
        public frmPrincipalCarnet()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdCarnet);
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT carnet.codigoCarnet as carnet,CONCAT(persona.codigopersona,'.',persona.nombre,' ',persona.apellido) as Estudiante, CONCAT(carrera.codigoCarrera,'.',carrera.nombre) as Carrera, CONCAT(jornada.codigoJornada,'.',jornada.nombre) as Jornada,carnet.estado as Estado from carnet,persona,carrera,jornada WHERE carnet.codigopersona=persona.codigopersona and carnet.codigoCarrera=carrera.codigoCarrera and carnet.codigoJornada=jornada.codigoJornada", "consulta", grdCarnet);
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdCarnet);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdCarnet);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdCarnet);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCreacionCarnet temp = new frmCreacionCarnet();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void grdCarnet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string habilitar;
             //------------Aqui busca la condicion Eduardo----si esta activo boton d
            string sCodCarnet = grdCarnet.Rows[grdCarnet.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombre = grdCarnet.Rows[grdCarnet.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCarrera = grdCarnet.Rows[grdCarnet.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sJornada = grdCarnet.Rows[grdCarnet.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sBoton = grdCarnet.Rows[grdCarnet.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string usu = claseUsuario.varibaleUsuario;
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "CONSULTA", "carnet");

            if (sBoton == "ACTIVO")
            {
                habilitar = "ELIMINAR";
            }
            else { habilitar = "ACTUALIZAR"; }

            frmCreacionCarnet temp = new frmCreacionCarnet(sCodCarnet, sNombre, sCarrera, sJornada,habilitar);
            temp.Show();
        }
    }
}
