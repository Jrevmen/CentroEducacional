using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;
using Navegador;


namespace Aerolinea
{
    public partial class frmPonderacionNota : Form
    {
        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        string sCodForanea, sCodPrimaria;
        string estado = "";

        public frmPonderacionNota()
        {
            InitializeComponent();
        }

        public frmPonderacionNota(string sCodPaquete)
        {
            InitializeComponent();

            sCodForanea = sCodPaquete;
            

            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("tipo_nota", "SELECT codig_tipo_nota as No, Descripcion, Valor, Fecha FROM tipo_nota as t1 WHERE t1.ccodigo_paquete = '" + sCodForanea + "'AND t1.estado='ACTIVO' AND t1.condicion = '1' ", "consulta", grdTipoNota);            

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

        public void funCargarNavegador()
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            cmbDescripcion.Enabled = false;
            cmbValor.Enabled = false;
            dtpFecha.Enabled = false;

        }

        public void funActualizarGrid()
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("tipo_nota", "SELECT codig_tipo_nota as No, Descripcion, Valor, Fecha FROM tipo_nota as t1 WHERE t1.ccodigo_paquete = '" + sCodForanea + "'AND t1.estado='ACTIVO' AND t1.condicion = '1' ", "consulta", grdTipoNota);
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            cmbDescripcion.Enabled = false;
            cmbValor.Enabled = false;
            dtpFecha.Enabled = false;

        }
                    
        private void grdTipoNota_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodig_Tipo_Nota = grdTipoNota.Rows[grdTipoNota.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string sDescripcion = grdTipoNota.Rows[grdTipoNota.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string sValor = grdTipoNota.Rows[grdTipoNota.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string sfecha = grdTipoNota.Rows[grdTipoNota.CurrentCell.RowIndex].Cells[3].Value.ToString();
            txtCodigTipoNota.Text = sCodig_Tipo_Nota;
            sCodPrimaria = sCodig_Tipo_Nota;
            cmbDescripcion.Text = sDescripcion;
            cmbValor.Text = sValor;
            dtpFecha.Text = sfecha;
            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }      
              
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbDescripcion.Enabled = true;
            cmbValor.Enabled = true;
            dtpFecha.Enabled = true;
            
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            estado = "";


        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;            
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

            cmbDescripcion.Enabled = false;
            cmbValor.Enabled = false;
            dtpFecha.Enabled = false;
            funActualizarGrid();    
            this.UseWaitCursor = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cmbDescripcion.Enabled = true;
            cmbValor.Enabled = true;
            dtpFecha.Enabled = true;

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
            cmbDescripcion.Enabled = false;
            cmbValor.Enabled = false;
            dtpFecha.Enabled = false;

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
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;
            
            cmbDescripcion.Enabled = false;
            cmbValor.Enabled = false;
            dtpFecha.Enabled = false;


        }

        private void btnIrPrimero_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funPrimero(grdTipoNota);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funAnterior(grdTipoNota);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();            
            cnegocio.funSiguiente(grdTipoNota);            
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funUltimo(grdTipoNota);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;            
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            string sTabla = "tipo_nota";
            
            
            txtDescripcion.Text = cmbDescripcion.Text;
            txtValor.Text = cmbValor.Text;
            txtfecha.Text = dtpFecha.Text;
            txtCodigopaquete.Text = sCodForanea;
            txtCodigTipoNota.Text = sCodPrimaria;

            if (estado.Equals("editar"))
            {
                string sCodigo = "codig_tipo_nota";
                //TextBox[] aDatosEdit = { txtCodigTipoNota, txtDescripcion, txtValor, txtEstado, txtCondicion, txtfecha };
                //cn.EditarObjetos(sTabla, bPermiso, aDatosEdit, sCodPrimaria, sCodigo);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Editar", sTabla);
                try
                {
                    _comando = new OdbcCommand(String.Format("UPDATE tipo_nota SET descripcion = '{0}', valor = '{1}', fecha ='{2}' WHERE codig_tipo_nota = {3}", txtDescripcion.Text, txtValor.Text, txtfecha.Text, txtCodigTipoNota.Text), ConexionODBC.Conexion.ObtenerConexion());
                    _reader = _comando.ExecuteReader();

                }
                catch
                {
                    MessageBox.Show("Error al editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (estado.Equals("eliminar"))
            {
                string sCodigo = "codig_tipo_nota";
                string sCampoEstado = "Condicion";                
                cn.funeliminarRegistro(sTabla, sCodPrimaria, sCodigo, sCampoEstado);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Eliminar", sTabla);
                
            }
            else if (estado.Equals(""))
            {
                TextBox[] aDatos = { txtDescripcion, txtValor, txtEstado, txtCodigopaquete, txtCondicion, txtfecha };
                //TextBox[] aDatos = { txtEstado, txtCodPaquete,  txtfecha };
                //cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                try
                { 
                    _comando = new OdbcCommand(String.Format("INSERT INTO `tipo_nota`(`descripcion`, `valor`, `estado`, `ccodigo_paquete`, `condicion`, `fecha`) VALUES('{0}','{1}','{2}','"+ txtCodigopaquete.Text +"','{3}','{4}')", txtDescripcion.Text, txtValor.Text, txtEstado.Text, txtCondicion.Text, txtfecha.Text), ConexionODBC.Conexion.ObtenerConexion());
                    _reader = _comando.ExecuteReader();                  
                                   
                }
                catch
                {
                    MessageBox.Show("Error al registrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }
            funActualizarGrid();
            cmbDescripcion.Text = "";
            cmbValor.Text = "";
            dtpFecha.Text = "";
            this.UseWaitCursor = false;

        }
    }
}
