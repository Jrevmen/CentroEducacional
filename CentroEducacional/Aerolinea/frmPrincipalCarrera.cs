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
    public partial class frmPrincipalCarrera : Form
    {
        public frmPrincipalCarrera()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carrera", "SELECT carrera.codigoCarrera as Codigo,carrera.nombre as Nombre, concat(facultad.codigoFacultad,'.',facultad.nombre) as Facultad, concat(sedes.codigo_sede,'.',sedes.nombre) as Sede from carrera, facultad, sedes WHERE carrera.condicion = '1' AND carrera.codigoFacultad = facultad.codigoFacultad AND carrera.codigo_sede = sedes.codigo_sede", "consulta", grdCarrera);
        }

        private void grdSedes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCod = grdCarrera.Rows[grdCarrera.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sNombreCarrera = grdCarrera.Rows[grdCarrera.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sNombreFacultad = grdCarrera.Rows[grdCarrera.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sNombreSede = grdCarrera.Rows[grdCarrera.CurrentCell.RowIndex].Cells[3].Value.ToString();
            frmCarrera temp = new frmCarrera(sCod, sNombreCarrera, sNombreFacultad, sNombreSede);
            temp.Show();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("carrera", " SELECT carrera.codigoCarrera as Codigo,carrera.nombre as Nombre, concat(facultad.codigoFacultad,'.',facultad.nombre) as Facultad, concat(sedes.codigo_sede,'.',sedes.nombre) as Sede from carrera, facultad, sedes WHERE carrera.condicion = '1' AND carrera.codigoFacultad = facultad.codigoFacultad AND carrera.codigo_sede = sedes.codigo_sede AND carrera.nombre LIKE '" + txtBuscar.Text + "%'", "consulta", grdCarrera);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCarrera temp = new frmCarrera();
            temp.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdCarrera);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdCarrera);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdCarrera);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdCarrera);
        }
    }
}
