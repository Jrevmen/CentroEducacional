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
    public partial class frmPrincipalCobroMensualidad : Form
    {
        public frmPrincipalCobroMensualidad()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("servicio", "SELECT servicio.codigo_servicio as Codigo, concat(tipo_servicio.codigo_tipo_servicio, '.', tipo_servicio.descripcion) as Transaccion, carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre, servicio.monto as Monto, servicio.fecha as Fecha, servicio.estado as Estado from servicio, tipo_servicio, persona, carnet WHERE servicio.codigo_tipo_servicio = tipo_servicio.codigo_tipo_servicio and servicio.codigoCarnet = carnet.codigoCarnet and carnet.codigopersona = persona.codigopersona and servicio.condicion = '1' and tipo_servicio.descripcion LIKE 'inscripcion%'", "consulta", grdCobroMensualidad);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdCobroMensualidad);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdCobroMensualidad);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdCobroMensualidad);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {

            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdCobroMensualidad);
        }

        private void grdCobroMensualidad_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodServicio = grdCobroMensualidad.Rows[grdCobroMensualidad.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sTransaccion = grdCobroMensualidad.Rows[grdCobroMensualidad.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCarnet = grdCobroMensualidad.Rows[grdCobroMensualidad.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sNombre = grdCobroMensualidad.Rows[grdCobroMensualidad.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sMonto = grdCobroMensualidad.Rows[grdCobroMensualidad.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string sFecha = grdCobroMensualidad.Rows[grdCobroMensualidad.CurrentCell.RowIndex].Cells[5].Value.ToString();
            frmCobroMensualidad temp = new frmCobroMensualidad(sCodServicio, sTransaccion, sCarnet, sNombre, sMonto, sFecha);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCobroMensualidad temp = new frmCobroMensualidad();
            temp.Show();
        }
    }
}
