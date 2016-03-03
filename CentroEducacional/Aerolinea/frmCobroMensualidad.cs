﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navegador;
using Filtrado;

namespace Aerolinea
{
    public partial class frmCobroMensualidad : Form
    {
        string sCod, estado, sTrans, sCadena, sTransac;

        public frmCobroMensualidad()
        {
            InitializeComponent();
            funCargarNavegador();
            funCargarCombo();

        }

        public frmCobroMensualidad(string sCodServicio, string sTransaccion, string sCarnet, string sNombre, string sMonto, string sFecha)
        {
            InitializeComponent();
            sCod = sCodServicio;
            sTrans = sTransaccion;
            txtCarnet.Text = sCarnet;
            txtMonto.Text = sMonto;
            lblNombre.Text = sNombre;
            dtpFecha.Value = Convert.ToDateTime(sFecha);
            sTransac = funCortadorID(sTrans);
            txtTipoServicio.Text = sTransac;
            funCargarCombo();
            funCargarNavegador();
        }

        public void funCargarCombo()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("cod_tipo_pago", "SELECT cod_tipo_pago as Codigo FROM tipo_pago WHERE descripcion = 'Pago unico' and condicion = '1'", "Codigo", cmbTipoPago);
            cnegocio.funconsultarRegistrosCombo("codigo_tipo_servicio", "SELECT concat(codigo_tipo_servicio, '.', descripcion) as servicio FROM tipo_servicio WHERE condicion = '1' and descripcion LIKE 'inscripcion%'", "servicio", cmbInscripcion);
            
        }
       

        public void funCargarNavegador()
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
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
            dtpFecha.Enabled = false;
            cmbInscripcion.Enabled = false;
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

        string funCortador(string sDato)
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
                    else if (sDato.Substring(i, 1) == ".")
                    {
                        sCadena = "";
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


        private void btnServicio_Click(object sender, EventArgs e)
        {
            string sCampoCodigo = "codigo_tipo_servicio";// nombre del campo del codigo 
            string sCampoDescripcion = "descripcion";// nombre del campo del nombre o descripcion 
            string query = "SELECT codigo_tipo_servicio as Codigo , descripcion as Descripcion FROM tipo_servicio WHERE condicion = '1' and codigo_tipo_servicio IN (SELECT codigo_tipo_servicio as cod from tipo_servicio WHERE condicion = '1' AND descripcion LIKE 'inscripcion%') ";// query que devuelve los
            //datos de codigoFacultad y nombre sin concatenar (Es el mismo query para llenar el combobox)
            frmFiltrado filtro = new frmFiltrado(query, sCampoCodigo, sCampoDescripcion);
            filtro.ShowDialog(this);

           int index = cmbInscripcion.FindString(filtro.funResultado());
           cmbInscripcion.SelectedIndex = index;//Selecciona el item del combobox
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtMonto.Clear();
            txtCarnet.Clear();
            lblNombre.Text = "";

            txtMonto.Enabled = true;
            txtCarnet.Enabled = false;
            dtpFecha.Enabled = true;
            cmbInscripcion.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            estado = "";

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtMonto.Enabled = true;
            txtCarnet.Enabled = false;
            dtpFecha.Enabled = true;
            cmbInscripcion.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;


            estado = "editar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;


            estado = "eliminar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            txtMonto.Clear();
            txtCarnet.Clear();
            lblNombre.Text = "";

            txtMonto.Enabled = false;
            txtCarnet.Enabled = false;
            dtpFecha.Enabled = false;
            cmbInscripcion.Enabled = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            string sTabla = "servicio";
            string sCodigo = "codigo_servicio";

            txtTipoPago.Text = cmbTipoPago.Text;
            txtfecha.Text = dtpFecha.Text;
            txtContrato.Text = null;

            string sCodServicio =funCortadorID(cmbInscripcion.Text);
            txtTipoServicio.Text = sCodServicio;



            try
            {
                if (estado.Equals("editar"))
                {

                    TextBox[] aDatosEdit = { txtTipoServicio, txtTipoPago, txtCarnet, txtMonto, txtfecha, txtEstado, txtCondicion };

                    cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCod, sCodigo);
                    claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);


                }
                else if (estado.Equals("eliminar"))
                {

                    string sCampoEstado = "Condicion";
                    //System.Console.WriteLine("----" + sCod);
                    cn.funeliminarRegistro(sTabla, sCod, sCodigo, sCampoEstado);
                    claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
                }
                else if (estado.Equals(""))
                {
                    TextBox[] aDatos = { txtTipoServicio, txtTipoPago, txtCarnet, txtMonto, txtfecha, txtEstado, txtCondicion };
                    cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                    claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
                }

            }
            catch
            {
                MessageBox.Show("Error, LLenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string sCampoCodigo = "codigoCarnet";// nombre del campo del codigo 
            string sCampoDescripcion = "apellido";// nombre del campo del nombre o descripcion 
            string query = "SELECT carnet.codigoCarnet as Carnet, concat(persona.nombre, ' ', persona.apellido) as Nombre from carnet, persona WHERE carnet.codigopersona = persona.codigopersona and persona.condicion = '1'";// query que devuelve los
            //datos de codigoFacultad y nombre sin concatenar (Es el mismo query para llenar el combobox)
            frmFiltrado filtro = new frmFiltrado(query, sCampoCodigo, sCampoDescripcion);
            filtro.ShowDialog(this);

            string resultado = filtro.funResultado();
            txtCarnet.Text = funCortadorID(resultado);
            lblNombre.Text = funCortador(resultado);
        }
    }
}
