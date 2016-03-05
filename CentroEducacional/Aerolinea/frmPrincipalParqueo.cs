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

using System.Data.Odbc;
using System.Data.SqlClient;

namespace Aerolinea
{
    public partial class frmPrincipalParqueo : Form
    {
        public frmPrincipalParqueo()
        {
            InitializeComponent();
            funActualizarGrid();

        }
        private void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("parqueo", "SELECT parqueo.codigo_parqueo as NoParqueo,parqueo.numero_parqueo as NoParqueo, parqueo.estado as Estado,parqueo.ubicacion as Ubicacion  from parqueo ", "consulta", grdParqueo);
        }

       
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            funActualizarGrid();
        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdParqueo);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdParqueo);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdParqueo);
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdParqueo);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("parqueo", "SELECT parqueo.codigo_parqueo as NoParqueo,parqueo.numero_parqueo as ControlParqueo, parqueo.estado as Estado,parqueo.ubicacion as Ubicacion  from parqueo ", "consulta", grdParqueo);

        }

//        private void grdParqueo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
  //      {
    //        claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Consulta", "Parqueo");
      //      string sCodParqueo = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[0].Value.ToString();
        //    string sParqueo = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[1].Value.ToString();
          //  frmPar temp = new frmPar(sCodParqueo, sParqueo);
            //temp.Show();




        //}
        private void grdInscripcion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void grupoFiltrar_Enter(object sender, EventArgs e)
        {

        }

      //  private void grdParqueo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{


          ///string sCodParqueo = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[0].Value.ToString();
            //string sParqueo = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[1].Value.ToString();
            //frmPar temp = new frmPar(sCodParqueo, sParqueo);
            //temp.Show();

//}
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            frmPar temp = new frmPar();
            temp.Show();
       
         }

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            funActualizarGrid();
       
        }

        private void grdParqueo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Consulta", "Parqueo");
            string sCodParqueo = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sParqueo = grdParqueo.Rows[grdParqueo.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmPar temp = new frmPar(sCodParqueo, sParqueo);
            temp.Show();

        }

    }
}