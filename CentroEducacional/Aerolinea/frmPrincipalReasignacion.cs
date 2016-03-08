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
    public partial class frmPrincipalReasignacion : Form
    {
        public frmPrincipalReasignacion()
        {
            InitializeComponent();
            funActualizarGrid();
        }

        private void funActualizarGrid() {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("servicio", "SELECT servicio.codigo_servicio as Codigo, concat(tipo_servicio.codigo_tipo_servicio, '.', tipo_servicio.descripcion) as Transaccion, carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre, servicio.monto as Monto, servicio.fecha as Fecha, servicio.estado as Estado from servicio, tipo_servicio, persona, carnet WHERE servicio.codigo_tipo_servicio = tipo_servicio.codigo_tipo_servicio and servicio.codigoCarnet = carnet.codigoCarnet and carnet.codigopersona = persona.codigopersona and servicio.condicion = '1' and tipo_servicio.descripcion = 'reasignacion'", "consulta", grdReasignacion);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funPrimero(grdReasignacion);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funAnterior(grdReasignacion);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funSiguiente(grdReasignacion);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funUltimo(grdReasignacion);
        }

        private void grdReasignacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            string sCodServicio = grdReasignacion.Rows[grdReasignacion.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sTransaccion = grdReasignacion.Rows[grdReasignacion.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCarnet = grdReasignacion.Rows[grdReasignacion.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sNombre = grdReasignacion.Rows[grdReasignacion.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sMonto = grdReasignacion.Rows[grdReasignacion.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string sFecha = grdReasignacion.Rows[grdReasignacion.CurrentCell.RowIndex].Cells[5].Value.ToString();
            frmReasignacion temp = new frmReasignacion(sCodServicio,sTransaccion,sCarnet,sNombre,sMonto,sFecha);
            temp.Show();
        }

       

    }
}
