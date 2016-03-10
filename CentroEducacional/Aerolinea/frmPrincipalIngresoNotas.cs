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
            
            clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funconsultarRegistros("paquete", "SELECT ccodigo_paquete as No, t2.nombre as Curso, t3.nombre_salon as Salon, t4.rangoHora as Horario, t5.nombre as Seccion FROM paquete AS t1 INNER JOIN curso as t2 ON t1.codigo_curso = t2.codigo_curso INNER JOIN salon as t3 ON t1.codigo_salon = t3.codigo_salon INNER JOIN horario as t4 ON t1.codigohorario = t4.codigohorario INNER JOIN seccion as t5 ON t1.codigo_seccion = t5.codigo_seccion WHERE t1.estado = 'ACTIVO' AND t1.condicion = '1' ", "consulta", grdCursos);
            cnegocio.funconsultarRegistros("paquete", "SELECT curso.nombre AS CURSO, carrera.nombre AS CARRERA, seccion.nombre AS SECCION, horario.rangoHora AS HORARIO FROM paquete, persona, curso, empleado, seccion, horario,carrera WHERE paquete.codigo_empleado=empleado.codigo_empleado AND empleado.codigopersona=persona.codigopersona AND paquete.codigo_curso=curso.codigo_curso AND paquete.codigoCarrera=carrera.codigoCarrera AND paquete.codigo_seccion=seccion.codigo_seccion AND paquete.codigoHorario=horario.codigoHorario AND paquete.codigo_empleado='"+sCodigoUsuario+"' AND paquete.condicion='1'", "consulta", grdCursos);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("paquete", "SELECT curso.nombre AS CURSO, carrera.nombre AS CARRERA, seccion.nombre AS SECCION, horario.rangoHora AS HORARIO FROM paquete, persona, curso, empleado, seccion, horario,carrera WHERE paquete.codigo_empleado=empleado.codigo_empleado AND empleado.codigopersona=persona.codigopersona AND paquete.codigo_curso=curso.codigo_curso AND paquete.codigoCarrera=carrera.codigoCarrera AND paquete.codigo_seccion=seccion.codigo_seccion AND paquete.codigoHorario=horario.codigoHorario AND paquete.codigo_empleado='"+sCodigoUsuario+"' AND paquete.condicion='1' AND curso.nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdCursos);
        }

        private void grdCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string sCodFacultad = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[0].Value.ToString();
            //string sFacultad = grdCursos.Rows[grdCursos.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmIngresoNotas temp = new frmIngresoNotas();
            temp.Show();
        }
    }
}
