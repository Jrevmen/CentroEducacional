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
    public partial class frmCreacionPensum : Form
    {
        public frmCreacionPensum()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("creacion_pensum", "SELECT concat(carrera.codigoCarrera, '.', carrera.nombre) as Carrera, concat(pensum.codigo_pensum, '.', pensum.ano) as Pensum, concat(curso.codigo_curso, '.', curso.nombre) as Curso FROM carrera, curso, pensum, creacion_pensum WHERE creacion_pensum.codigo_pensum=pensum.codigo_pensum AND creacion_pensum.codigo_curso=curso.codigo_curso AND pensum.codigoCarrera=carrera.codigoCarrera AND creacion_pensum.condicion=1 ", "consulta", grdCreacionPensum);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("creacion_pensum", "SELECT concat(carrera.codigoCarrera, '.', carrera.nombre) as Carrera, concat(pensum.codigo_pensum, '.', pensum.ano) as Pensum, concat(curso.codigo_curso, '.', curso.nombre) as Curso FROM carrera, curso, pensum, creacion_pensum WHERE creacion_pensum.codigo_pensum=pensum.codigo_pensum AND creacion_pensum.codigo_curso=curso.codigo_curso AND pensum.codigoCarrera=carrera.codigoCarrera AND creacion_pensum.condicion=1 AND  carrera.nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdCreacionPensum);
        }

        private void grdCreacionPensum_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodCarrera = grdCreacionPensum.Rows[grdCreacionPensum.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sCodPensum = grdCreacionPensum.Rows[grdCreacionPensum.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCodCurso = grdCreacionPensum.Rows[grdCreacionPensum.CurrentCell.RowIndex].Cells[2].Value.ToString();
            frmCrearPensumSiguiente temp = new frmCrearPensumSiguiente(sCodCarrera, sCodPensum, sCodCurso);
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }
    }
}
