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
using Filtrado;

namespace Aerolinea
{
    public partial class frmPrincipalIngresoNotas : Form
    {
        string sCodigoUsuario;
        public frmPrincipalIngresoNotas()
        {
            InitializeComponent();
            sCodigoUsuario = claseUsuario.varibaleUsuario;
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            System.Console.WriteLine("EL CODIGO QUE TENGO ES////// " +sCodigoUsuario);
            clasnegocio cnegocio = new clasnegocio();
<<<<<<< HEAD
            cnegocio.funconsultarRegistros("paquete", "SELECT paquete.ccodigo_paquete AS Paquete, carrera.nombre AS Carrera, curso.nombre AS Curso, horario.rangoHora AS Horario, salon.nombre_salon AS Salon, seccion.nombre AS Seccion FROM usuario, empleado, paquete, puesto, curso, horario, carrera, salon, seccion WHERE paquete.codigo_seccion=seccion.codigo_seccion AND paquete.codigo_salon=salon.codigo_salon AND paquete.codigoCarrera=carrera.codigoCarrera AND paquete.codigoHorario=horario.codigoHorario AND paquete.codigo_curso=curso.codigo_curso AND empleado.codigo_empleado=paquete.codigo_empleado AND puesto.codigoPuesto=empleado.codigoPuesto AND puesto.nombre='catedratico' AND usuario.codigopersona=empleado.codigopersona AND puesto.codigoPuesto=empleado.codigoPuesto AND usuario.nombre_usuario='" + sCodigoUsuario + "'", "consulta", grdCursos);
=======
            cnegocio.funconsultarRegistros("paquete", "SELECT paquete.ccodigo_paquete AS Paquete, carrera.nombre AS Carrera, curso.nombre AS Curso, horario.rangoHora AS Horario, salon.nombre_salon AS Salon, seccion.nombre AS Seccion FROM usuario, empleado, paquete, puesto, curso, horario, carrera, salon, seccion WHERE paquete.codigo_seccion=seccion.codigo_seccion AND paquete.codigo_salon=salon.codigo_salon AND paquete.codigoCarrera=carrera.codigoCarrera AND paquete.codigoHorario=horario.codigoHorario AND paquete.codigo_curso=curso.codigo_curso AND empleado.codigo_empleado=paquete.codigo_empleado AND puesto.codigoPuesto=empleado.codigoPuesto AND puesto.nombre='CATEDRATICO' AND usuario.codigopersona=empleado.codigopersona AND puesto.codigoPuesto=empleado.codigoPuesto AND usuario.nombre_usuario='" + sCodigoUsuario + "'", "consulta", grdCursos);
>>>>>>> a985cad4ab7322a97c80b6dedb47330c56863232
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("paquete", "SELECT paquete.ccodigo_paquete AS Paquete, carrera.nombre AS Carrera, curso.nombre AS Curso, horario.rangoHora AS Horario, salon.nombre_salon AS Salon, seccion.nombre AS Seccion FROM usuario, empleado, paquete, puesto, curso, horario, carrera, salon, seccion WHERE paquete.codigo_seccion=seccion.codigo_seccion AND paquete.codigo_salon=salon.codigo_salon AND paquete.codigoCarrera=carrera.codigoCarrera AND paquete.codigoHorario=horario.codigoHorario AND paquete.codigo_curso=curso.codigo_curso AND empleado.codigo_empleado=paquete.codigo_empleado AND puesto.codigoPuesto=empleado.codigoPuesto AND puesto.nombre='catedratico' AND usuario.codigopersona=empleado.codigopersona AND puesto.codigoPuesto=empleado.codigoPuesto AND usuario.nombre_usuario='" + sCodigoUsuario + "' AND paquete.condicion='1' AND curso.nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdCursos);
        }

        private void grdCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string sCodFacultad = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sCodPaquete = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[0].Value.ToString();
            frmIngresoNotas temp = new frmIngresoNotas(sCodPaquete);
            temp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sCampoCodigo = "codigoFacultad";// nombre del campo del codigo 
            string sCampoDescripcion = "nombre";// nombre del campo del nombre o descripcion 
            string query = "Select codigoFacultad, nombre from facultad where condicion='1'";// query que devuelve los
            //datos de codigoFacultad y nombre sin concatenar (Es el mismo querypara llenar el combobox)
            frmFiltrado filtro = new frmFiltrado(query, sCampoCodigo, sCampoDescripcion);
            filtro.ShowDialog(this);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdCursos);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdCursos);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdCursos);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdCursos);
        }
    }
}
