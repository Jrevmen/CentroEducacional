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
    public partial class frmPrincipalDocumentos : Form
    {
        public frmPrincipalDocumentos()
        {
            InitializeComponent();
            funActualizarGrid();
        }
        public void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("servicio", "SELECT servicio.codigo_servicio as Codigo, concat(tipo_servicio.codigo_tipo_servicio, '.', tipo_servicio.descripcion) as Transaccion, carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre, servicio.monto as Monto, servicio.fecha as Fecha, servicio.estado as Estado from servicio, tipo_servicio, persona, carnet WHERE servicio.codigo_tipo_servicio = tipo_servicio.codigo_tipo_servicio and servicio.codigoCarnet = carnet.codigoCarnet and carnet.codigopersona = persona.codigopersona and servicio.condicion = '1' and (tipo_servicio.descripcion = 'Documentos' )", "consulta", grdDocumentos);
        }


        private void frmPrincipalDocumentos_Load(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funPrimero(grdDocumentos);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funAnterior(grdDocumentos);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funSiguiente(grdDocumentos);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funUltimo(grdDocumentos);
        }

        private void grdDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodServicio = grdDocumentos.Rows[grdDocumentos.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sTransaccion = grdDocumentos.Rows[grdDocumentos.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sCarnet = grdDocumentos.Rows[grdDocumentos.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sNombre = grdDocumentos.Rows[grdDocumentos.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sMonto = grdDocumentos.Rows[grdDocumentos.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string sFecha = grdDocumentos.Rows[grdDocumentos.CurrentCell.RowIndex].Cells[5].Value.ToString();
            frmDocumentos temp = new frmDocumentos(sCodServicio, sTransaccion, sCarnet, sNombre, sMonto, sFecha);
            temp.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string fecha = Convert.ToString(DateTime.Now);
            frmDocumentos temp = new frmDocumentos("","","", "", "",fecha );
            temp.Show();
        }
    }
}
