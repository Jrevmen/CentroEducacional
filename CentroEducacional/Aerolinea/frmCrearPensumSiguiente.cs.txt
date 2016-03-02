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
    public partial class frmCrearPensumSiguiente : Form
    {
        string sCod;
        string estado = "";
        public frmCrearPensumSiguiente()
        {
            InitializeComponent();
        }

        public frmCrearPensumSiguiente(string sCodCarrera, string sCodPensum, string sCodCurso)
        {
            InitializeComponent();
            /*
            Boolean[] permisos;
            permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmFacultad");
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            */
            //txtNombre.Text = sFacultad;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            funCarrera();
            funCurso();
            funSeleccionar(sCodCarrera, sCodCurso);
            funPensum();
            
            
        }

        string funCortador(string sDato)
        {
            string sCadena = "";
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

        void funSeleccionar(string carrera, string curso) {
            int index = cmbCarrera.FindString(carrera);
            cmbCarrera.SelectedIndex = index;            

            int index3 = cmbCurso.FindString(curso);
            cmbCurso.SelectedIndex = index3;
        }
        void funCarrera()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("codigoCarrera", "SELECT concat(codigoCarrera, '.', nombre) as Carrera from carrera WHERE condicion='1'", "Carrera", cmbCarrera);
        }

        void funCurso()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("codigo_curso", "SELECT concat(codigo_curso, '.', nombre) as Curso from curso WHERE condicion='1'", "Curso", cmbCurso);
        }

        void funPensum()
        {
            System.Console.WriteLine("CADENA QUE LLEGA> " + cmbCarrera.SelectedIndex);
            string sCodCarrera = funCortador(cmbCarrera.Text);
            System.Console.WriteLine("Llego despues del cortador> " +sCodCarrera);
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("codigo_pensum", "SELECT concat(codigo_pensum, '.', ano) as Pensum from pensum WHERE codigoCarrera='"+sCodCarrera+"' AND condicion='1'", "Pensum", cmbPensum);
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            funPensum();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarCombobox(cmbCarrera, true);
            cnegocio.funactivarDesactivarCombobox(cmbPensum, true);
            cnegocio.funactivarDesactivarCombobox(cmbCurso, true);
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            //txtCarrera.Text = funCortador(cmbCarrera.Text);
            txtPensum.Text = funCortador(cmbPensum.Text);
            txtCurso.Text = funCortador(cmbCurso.Text);

            if (estado.Equals("editar"))
            {

                //TextBox[] aDatosEdit = { txtCarrera, txtPensum, txtCurso };
                //string sTabla = "carrera";
                //string sCodigo = "codigoCarrera";

                //cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);


            }
            else if (estado.Equals("eliminar"))
            {
                //string sTabla = "carrera";
                //string sCampoLlavePrimaria = "codigoCarrera";
                //string sCampoEstado = "estado";
                //System.Console.WriteLine("----" + sCod);
                //cn.funeliminarRegistro(sTabla, sCod, sCampoLlavePrimaria, sCampoEstado);
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtEstado, txtPensum, txtCurso };
                string sTabla = "creacion_pensum";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
            }

            estado = "";
            //txtNombre.Clear();
            cmbCarrera.SelectedIndex = 0;
            //cmbPensum.SelectedIndex = 0;
            cmbCurso.SelectedIndex = 0;
            //cn.funactivarDesactivarTextbox(txtNombre, false);
            cn.funactivarDesactivarCombobox(cmbCarrera, false);
            cn.funactivarDesactivarCombobox(cmbPensum, false);
            cn.funactivarDesactivarCombobox(cmbCurso, false);
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnBuscar.Enabled = true;
            btnAnterior.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnSiguiente.Enabled = true;
            btnIrUltimo.Enabled = true;
        }
    }
}
