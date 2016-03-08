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
    public partial class frmReasignacion : Form
    {
        string sCodSer,sTrans;
        public frmReasignacion(string sCodServicio,string sTransaccion,string sCarnet,string sNombre,string sMonto,string sFecha)
        {
            InitializeComponent();
            sCodSer = sCodServicio;
            sTrans = sTransaccion;
            txtCarnet.Text = sCarnet;
            txtNombre.Text = sNombre;
            dtFecha.Value = Convert.ToDateTime(sFecha);
        }

        private void frmReasignacion_Load(object sender, EventArgs e)
        {
            clasnegocio cneg = new clasnegocio();
            cneg.funactivarDesactivarBoton(btnNuevo, true);
            cneg.funactivarDesactivarBoton(btnEditar,false);
            cneg.funactivarDesactivarBoton(btnGuardar, false);
            cneg.funactivarDesactivarBoton(btnEliminar, false);
            cneg.funactivarDesactivarBoton(btnAnterior, true);
            cneg.funactivarDesactivarBoton(btnIrPrimero, true);
            cneg.funactivarDesactivarBoton(btnIrUltimo, true);
            cneg.funactivarDesactivarBoton(btnSiguiente, true);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
