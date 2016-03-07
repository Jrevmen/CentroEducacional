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
    public partial class frmPrincipalInscripcion : Form
    {
        public frmPrincipalInscripcion()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT encabezado_incripcion.codigoInscripcion as NoIsncripcion,encabezado_incripcion.codigoCarnet as Carnet, encabezado_incripcion.estado as Estado,persona.nombre as Nombre, persona.apellido as Apellido, carrera.nombre as Carrera,jornada.nombre as Jornada from encabezado_incripcion,persona,carnet,carrera,jornada WHERE encabezado_incripcion.codigoCarnet=carnet.codigoCarnet and carnet.codigopersona=persona.codigopersona and carnet.codigoCarrera=carrera.codigoCarrera and carnet.codigoJornada=jornada.codigoJornada", "consulta", grdInscripcion);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmInscripcionAlumno temp = new frmInscripcionAlumno();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdInscripcion);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdInscripcion);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdInscripcion);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdInscripcion);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT encabezado_incripcion.codigoInscripcion as NoIsncripcion,encabezado_incripcion.codigoCarnet as Carnet, encabezado_incripcion.estado as Estado,persona.nombre as Nombre, persona.apellido as Apellido, carrera.nombre as Carrera,jornada.nombre as Jornada from encabezado_incripcion,persona,carnet,carrera,jornada WHERE encabezado_incripcion.codigoCarnet=carnet.codigoCarnet and carnet.codigopersona=persona.codigopersona and carnet.codigoCarrera=carrera.codigoCarrera and carnet.codigoJornada=jornada.codigoJornada and encabezado_incripcion.codigoCarnet='" + txtBuscar.Text + "'", "consulta", grdInscripcion);
        }

        private void grdInscripcion_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //------------Aqui busca la condicion Eduardo----si esta activo boton d
            string sCodInscripcion = grdInscripcion.Rows[grdInscripcion.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sCarnet = grdInscripcion.Rows[grdInscripcion.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmInscripcionAlumno temp = new frmInscripcionAlumno(sCodInscripcion, sCarnet);
            string usu = claseUsuario.varibaleUsuario;
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "CONSULTA", "encabezado_incripcion");
            temp.Show();
        }
        
    }
}
