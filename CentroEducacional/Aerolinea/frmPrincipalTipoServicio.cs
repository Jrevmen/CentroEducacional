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
    public partial class frmPrincipalTipoServicio : Form
    {
        public frmPrincipalTipoServicio()
        {
            InitializeComponent();
            funActualizarGrid();
        }
           private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("tipo_servicio", "SELECT codigo_tipo_servicio as Codigo, descripcion as Descripcion, fecha_corte as Cierre, monto as Monto, accion as Accion  from tipo_servicio WHERE condicion = '1'", "consulta", grdTipoServicio);
        }

           private void grdTipoServicio_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
           {
               string sCodServicio = grdTipoServicio.Rows[grdTipoServicio.CurrentCell.RowIndex].Cells[0].Value.ToString();
               string sDescripcion = grdTipoServicio.Rows[grdTipoServicio.CurrentCell.RowIndex].Cells[1].Value.ToString();
               string sFecha = grdTipoServicio.Rows[grdTipoServicio.CurrentCell.RowIndex].Cells[2].Value.ToString();
               string sMonto = grdTipoServicio.Rows[grdTipoServicio.CurrentCell.RowIndex].Cells[3].Value.ToString();
               string sAccion = grdTipoServicio.Rows[grdTipoServicio.CurrentCell.RowIndex].Cells[4].Value.ToString();
               frmTipoServicio temp = new frmTipoServicio(sCodServicio, sDescripcion, sFecha, sMonto, sAccion);
               temp.Show();
           }

           private void btnNuevo_Click(object sender, EventArgs e)
           {
               frmTipoServicio temp = new frmTipoServicio();
               temp.Show();
           }

           private void btnRefrescar_Click(object sender, EventArgs e)
           {
               funActualizarGrid();
           }

           private void btnIrPrimero_Click(object sender, EventArgs e)
           {
               clasnegocio cnegocio = new clasnegocio();
               cnegocio.funPrimero(grdTipoServicio);
           }

           private void btnAnterior_Click(object sender, EventArgs e)
           {
               clasnegocio cnegocio = new clasnegocio();
               cnegocio.funAnterior(grdTipoServicio);
           }

           private void btnSiguiente_Click(object sender, EventArgs e)
           {
               clasnegocio cnegocio = new clasnegocio();
               cnegocio.funSiguiente(grdTipoServicio);
           }

           private void btnIrUltimo_Click(object sender, EventArgs e)
           {
               clasnegocio cnegocio = new clasnegocio();
               cnegocio.funUltimo(grdTipoServicio);
           }
        
    }
}
