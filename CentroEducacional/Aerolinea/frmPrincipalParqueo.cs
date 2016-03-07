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
            cnegocio.funconsultarRegistros("parqueo", "SELECT parqueo.codigo_parqueo as NoParqueo,parqueo.numero_parqueo as NoParqueo, parqueo.estado as Estado,parqueo.ubicacion as Ubicacion, parqueo.cantidad as Cantidad  from parqueo ", "consulta", grdFacultad);
        }

      

       

        private void frmPrincipalParqueo_Load(object sender, EventArgs e)
        {

        }

       // private void grdFacultad_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
          //  string sCodParqueo = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[0].Value.ToString();
           // string sParqueo = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[1].Value.ToString();
            //frmPar temp = new frmPar(sCodParqueo, sParqueo);
           // temp.Show();
        
       // }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmPar temp = new frmPar();
            temp.Show();
       
        }

        private void btnRefrescarClic_Click(object sender, EventArgs e)
        {
            funActualizarGrid();

        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdFacultad);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funSiguiente(grdFacultad);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdFacultad);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdFacultad);
        }

             private void grdFacultad_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodParqueo = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sParqueo = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[1].Value.ToString();
           string sCantidad = grdFacultad.Rows[grdFacultad.CurrentCell.RowIndex].Cells[4].Value.ToString();
            frmPar temp = new frmPar(sCodParqueo, sParqueo, sCantidad);
            temp.Show();
        }
        
      

    }
}
