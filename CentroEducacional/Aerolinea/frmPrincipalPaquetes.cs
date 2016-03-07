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
    public partial class frmPrincipalPaquetes : Form
    {
        public frmPrincipalPaquetes()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("paquete", "SELECT paquete.ccodigo_paquete as No_Horario,paquete.estado as Estado,CONCAT(curso.codigo_curso,'.',curso.nombre) as Curso,CONCAT(salon.codigo_salon,'.',salon.nombre_salon) as Salon, CONCAT(laboratorio.codigo_laboratorio,'.',laboratorio.nombre) as Laboratorio, CONCAT(horario.codigoHorario,'.',horario.rangoHora) as Horario, CONCAT(seccion.codigo_seccion,'.',seccion.nombre) as seccion,CONCAT(persona.codigopersona,'.',persona.nombre,' ',persona.apellido) as Catedratico,CONCAT(carrera.codigoCarrera,'.',carrera.nombre) as Carrera from paquete,curso,laboratorio,horario,salon,seccion,persona,empleado,carrera WHERE paquete.codigo_curso=curso.codigo_curso and paquete.codigo_salon=salon.codigo_salon and paquete.codigo_laboratorio=laboratorio.codigo_laboratorio and paquete.codigoHorario=horario.codigoHorario and paquete.codigo_seccion=seccion.codigo_seccion and paquete.codigo_empleado=empleado.codigo_empleado and empleado.codigopersona=persona.codigopersona and paquete.codigoCarrera=carrera.codigoCarrera", "consulta", grdPaquete);
        }

        private void grdPaquete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodigoPaquete = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sCurso = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sSalon = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sLaboratorio = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string sHorario = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[5].Value.ToString();
            string sSeccion = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[6].Value.ToString();
            string sCatedratico = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[7].Value.ToString();
            string sCarrera = grdPaquete.Rows[grdPaquete.CurrentCell.RowIndex].Cells[8].Value.ToString();
            string usu = claseUsuario.varibaleUsuario;
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "CONSULTA", "paquete");

            frmCreacionPaquetes temp = new frmCreacionPaquetes(sCodigoPaquete,sCurso,sSalon,sLaboratorio,sHorario,sSeccion,sCatedratico,sCarrera);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCreacionPaquetes temp = new frmCreacionPaquetes();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdPaquete);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdPaquete);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdPaquete);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdPaquete);
        }
    }
}
