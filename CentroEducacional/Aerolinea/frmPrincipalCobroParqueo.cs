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
    public partial class frmPrincipalCobroParqueo : Form
    {
        public frmPrincipalCobroParqueo()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("servicio", "SELECT servicio.codigo_servicio as Codigo, concat(tipo_servicio.codigo_tipo_servicio, '.', tipo_servicio.descripcion) as Transaccion, carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre, servicio.monto as Monto, servicio.fecha as Fecha, servicio.estado as Estado from servicio, tipo_servicio, persona, carnet WHERE servicio.codigo_tipo_servicio = tipo_servicio.codigo_tipo_servicio and servicio.codigoCarnet = carnet.codigoCarnet and carnet.codigopersona = persona.codigopersona and servicio.condicion = '1' and tipo_servicio.descripcion LIKE 'inscripcion%'", "consulta", grdCobroParqueo);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("servicio", "SELECT servicio.codigo_servicio as Codigo, concat(tipo_servicio.codigo_tipo_servicio, '.', tipo_servicio.descripcion) as Transaccion, carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre, servicio.monto as Monto, servicio.fecha as Fecha, servicio.estado as Estado from servicio, tipo_servicio, persona, carnet WHERE servicio.codigo_tipo_servicio = tipo_servicio.codigo_tipo_servicio and servicio.codigoCarnet = carnet.codigoCarnet and carnet.codigopersona = persona.codigopersona and servicio.condicion = '1' and tipo_servicio.descripcion = 'pago parqueo' and persona.nombre  LIKE '" + txtBuscar.Text + "%'", "consulta", grdCobroParqueo);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdCobroParqueo);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdCobroParqueo);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdCobroParqueo);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdCobroParqueo);
        }

        private void grdCobroParqueo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodServicio = grdCobroParqueo.Rows[grdCobroParqueo.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sTransaccion = grdCobroParqueo.Rows[grdCobroParqueo.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCarnet = grdCobroParqueo.Rows[grdCobroParqueo.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sNombre = grdCobroParqueo.Rows[grdCobroParqueo.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sMonto = grdCobroParqueo.Rows[grdCobroParqueo.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string sFecha = grdCobroParqueo.Rows[grdCobroParqueo.CurrentCell.RowIndex].Cells[5].Value.ToString();
            frmCobroParqueo temp = new frmCobroParqueo(sCodServicio, sTransaccion, sCarnet, sNombre, sMonto, sFecha);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCobroParqueo temp = new frmCobroParqueo();
            temp.Show();
        }
    }
}
