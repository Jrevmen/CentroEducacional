using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class frmCobroMensualidad : Form
    {
        string sCod, estado, sTrans, sCadena, sTransac;

        public frmCobroMensualidad()
        {
            InitializeComponent();
            funCargarNavegador();
        }

        public frmCobroMensualidad(string sCodServicio, string sTransaccion, string sCarnet, string sNombre, string sMonto, string sFecha)
        {
            InitializeComponent();
            sCod = sCodServicio;
            sTrans = sTransaccion;
            txtCarnet.Text = sCarnet;
            txtMonto.Text = sMonto;
            txtNombre.Text = sNombre;
            dtpFecha.Value = Convert.ToDateTime(sFecha);
            funCargarNavegador();
        }

        public void funCargarNavegador()
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            txtMonto.Enabled = false;
            txtCarnet.Enabled = false;
            txtNombre.Enabled = false;
            dtpFecha.Enabled = false;
        }

        string funCortadorID(string sDato)
        {
            sCadena = "";
            try
            {
                for (int i = 0; i < sDato.Length; i++)
                {
                    if (sDato.Substring(i, 1) != ".")
                    {
                        sCadena = sCadena + sDato.Substring(i, 1);
                    }
                    else
                    {
                        break;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error al obtener Codigo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return sCadena;
        }
    }
}
