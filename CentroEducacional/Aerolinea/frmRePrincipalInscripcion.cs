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
using System.Data.SqlClient;
namespace Aerolinea
{
    public partial class frmRePrincipalInscripcion : Form
    {
        

        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        //se valida el actvo
        public static string ACTIVO;
        public frmRePrincipalInscripcion()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carnet", "SELECT encabezado_incripcion.codigoInscripcion as NoIsncripcion,encabezado_incripcion.codigoCarnet as Carnet, encabezado_incripcion.estado as Estado,persona.nombre as Nombre, persona.apellido as Apellido, carrera.nombre as Carrera,jornada.nombre as Jornada from encabezado_incripcion,persona,carnet,carrera,jornada WHERE encabezado_incripcion.codigoCarnet=carnet.codigoCarnet and carnet.codigopersona=persona.codigopersona and carnet.codigoCarrera=carrera.codigoCarrera and carnet.codigoJornada=jornada.codigoJornada", "consulta", grdInscripcion);
//textBox1.Text = grdInscripcion.Rows[codigoInscripcion.RowIndex].Cells[0].Value.ToString();
           }
        

       // private void funionactivo() {
         //   string comand;
           // clasnegocio cnegocio1 = new clasnegocio();

            //cnegocio1.funconsultarRegistros("carnet", "SELECT encabezado_incripcion.codigoInscripcion as NoIsncripcion,encabezado_incripcion.codigoCarnet as Carnet, encabezado_incripcion.estado as Estado,persona.nombre as Nombre, persona.apellido as Apellido, carrera.nombre as Carrera,jornada.nombre as Jornada from encabezado_incripcion,persona,carnet,carrera,jornada WHERE encabezado_incripcion.codigoCarnet=carnet.codigoCarnet and carnet.codigopersona=persona.codigopersona and carnet.codigoCarrera=carrera.codigoCarrera and carnet.codigoJornada=jornada.codigoJornada", "consulta", grdInscripcion);
            //SqlCommand cmd = new SqlCommand(comand, cnegocio1);
       // }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmReInscripcionAlumno temp = new frmReInscripcionAlumno();
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

            //se extraen datos para comparacion

            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Consulta", "Alumno");
            textBox1.Text = grdInscripcion.CurrentRow.Cells["Estado"].Value.ToString();

            string sCodInscripcion = grdInscripcion.Rows[grdInscripcion.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sCarnet = grdInscripcion.Rows[grdInscripcion.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmReInscripcionAlumno temp = new frmReInscripcionAlumno(sCodInscripcion, sCarnet);
            //condicional para habilitar botones para rescripcion
            if (textBox1.Text == textBox2.Text)
            {

                temp.btnEditar.Enabled = true;
                temp.btnEliminar.Enabled = false;
                temp.Show();
            }
            else {

                temp.btnEditar.Enabled = false;
                temp.btnEliminar.Enabled = true;
                temp.Show();
            }

              
               
            
            
        }

        private void grdInscripcion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void grupoFiltrar_Enter(object sender, EventArgs e)
        {

        }

        private void frmRePrincipalInscripcion_Load(object sender, EventArgs e)
        {

        }
        
    }
}
