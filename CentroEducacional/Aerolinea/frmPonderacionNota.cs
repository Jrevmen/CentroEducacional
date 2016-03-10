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
        Boolean[] permisos = claseUsuario.PermisosBotones(claseUsuario.varibaleUsuario, "frmZona");


        public frmPonderacionNota()
        {           
            InitializeComponent();            
        }

        public frmPonderacionNota(string sCodPaquete, string sNomCurso, string sSeccion)
        {
            InitializeComponent();

            this.Text = this.Text + " : " + sNomCurso + " Sección " + sSeccion;
            //this.MdiParent = frmMenu.ActiveForm;
            this.WindowState = 0;            
            //frmMenu.ActiveForm.UseWaitCursor = true;
            //frmMenu.ActiveForm.Cursor = Cursors.AppStarting;
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];

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
                MessageBox.Show("Error al obtener Codigo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sCadena;
        }

        public void funCargarNavegador()
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
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
            btnNuevo.Enabled = permisos[0];
            btnEditar.Enabled = permisos[1];
            btnEliminar.Enabled = permisos[2];
            btnIrPrimero.Enabled = true;
            btnIrUltimo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            cmbDescripcion.Enabled = false;
            cmbValor.Enabled = false;
            dtpFecha.Enabled = false;


        }
        public void funActualizarValor(string sestado)
        {
            Int32 iValorSuma, iValorPendiente = 0;
            try
            {
                _comando = new OdbcCommand(String.Format("SELECT sum(valor) FROM `tipo_nota` WHERE `ccodigo_paquete`= " + sCodForanea), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    iValorSuma = Convert.ToInt32(_reader[0]);
                    iValorPendiente = 100 - iValorSuma;
                    

                }
            }
            catch
            {
                MessageBox.Show("Error en Suma de Valor de Paquete", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _reader.Close();

            if (sestado == "editar")
                    {                        
                        iValorPendiente = iValorPendiente + Convert.ToInt32(cmbValor.Text);
                        //MessageBox.Show(Convert.ToString(iValorPendiente), "Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbValor.Items.Clear();
                        for (int i = iValorPendiente; i > 0;)
                        {
                            cmbValor.Items.Add(i);
                            i = i - 5;
                        }
                    }
                    else
                    {
                        if (iValorPendiente == 0)
                        {
                            cmbValor.Enabled = false;
                            cmbDescripcion.Enabled = false;
                            dtpFecha.Enabled = false;
                            funActualizarGrid();
                            MessageBox.Show("Curso con zona completa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        cmbValor.Items.Clear();
                        for (int i = iValorPendiente; i > 0;)
                        {
                            cmbValor.Items.Add(i);
                            i = i - 5;
                        }
                    }                           
   


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
            funActualizarValor("editar");
        }      
              
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbDescripcion.Text = "";
            cmbValor.Text = "";
            dtpFecha.Text = "";
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
            funActualizarValor("");


        }

        private void btnRefrescar_Click(object sender, EventArgs e)
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

            cmbDescripcion.Enabled = false;
            cmbValor.Enabled = false;
            dtpFecha.Enabled = false;
            funActualizarGrid();    
            
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
            //clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funPrimero(grdTipoNota);
            
          
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            //clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funAnterior(grdTipoNota);

            string sCodPaquete, sNombre, sSeccion;
            
            this.Close();
            frmMenu.ActiveForm.UseWaitCursor = true;
            frmMenu.ActiveForm.Cursor = Cursors.AppStarting;
            try
            {
                _comando = new OdbcCommand(String.Format("SELECT ccodigo_paquete as No, t2.nombre as Curso, t3.nombre_salon as Salon, t4.rangoHora as Horario, t5.nombre as Seccion FROM paquete AS t1 INNER JOIN curso as t2 ON t1.codigo_curso = t2.codigo_curso INNER JOIN salon as t3 ON t1.codigo_salon = t3.codigo_salon INNER JOIN horario as t4 ON t1.codigohorario = t4.codigohorario INNER JOIN seccion as t5 ON t1.codigo_seccion = t5.codigo_seccion WHERE t1.estado = 'ACTIVO' AND t1.condicion = '1' AND `ccodigo_paquete`< " + sCodForanea + " ORDER BY `ccodigo_paquete` DESC LIMIT 1"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    sCodPaquete = Convert.ToString(_reader[0]);
                    sNombre = Convert.ToString(_reader[1]);
                    sSeccion = Convert.ToString(_reader[4]);
                    frmPonderacionNota temp = new frmPonderacionNota(sCodPaquete, sNombre,/* sSalon, sHorario,*/ sSeccion);
                    //temp.MdiParent = this.MdiParent;   
                    frmMenu.ActiveForm.Cursor = Cursors.Arrow;
                    temp.Show();                    
                }
                _reader.Close();

            }
            catch
            {
                MessageBox.Show("Primer Registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //clasnegocio cnegocio = new clasnegocio();            
            //cnegocio.funSiguiente(grdTipoNota);            

            string sCodPaquete, sNombre, sSeccion;            
            this.Close();
            frmMenu.ActiveForm.UseWaitCursor = true;
            frmMenu.ActiveForm.Cursor = Cursors.AppStarting;
            try
            {
                _comando = new OdbcCommand(String.Format("SELECT ccodigo_paquete as No, t2.nombre as Curso, t3.nombre_salon as Salon, t4.rangoHora as Horario, t5.nombre as Seccion FROM paquete AS t1 INNER JOIN curso as t2 ON t1.codigo_curso = t2.codigo_curso INNER JOIN salon as t3 ON t1.codigo_salon = t3.codigo_salon INNER JOIN horario as t4 ON t1.codigohorario = t4.codigohorario INNER JOIN seccion as t5 ON t1.codigo_seccion = t5.codigo_seccion WHERE t1.estado = 'ACTIVO' AND t1.condicion = '1' AND `ccodigo_paquete`> " + sCodForanea + " ORDER BY `ccodigo_paquete` LIMIT 1"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    sCodPaquete = Convert.ToString(_reader[0]);
                    sNombre = Convert.ToString(_reader[1]);
                    sSeccion = Convert.ToString(_reader[4]);
                    frmPonderacionNota temp = new frmPonderacionNota(sCodPaquete, sNombre,/* sSalon, sHorario,*/ sSeccion);
                    //temp.MdiParent = this.MdiParent;  
                    frmMenu.ActiveForm.Cursor = Cursors.Arrow;
                    temp.Show();                    
                }
                _reader.Close();

            }
            catch
            {
                MessageBox.Show("Ultimo Registro ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnIrUltimo_Click(object sender, EventArgs e)
        {
            //clasnegocio cnegocio = new clasnegocio();
            //cnegocio.funUltimo(grdTipoNota);        
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
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
                
        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            frmMenu.ActiveForm.UseWaitCursor = true;
            frmMenu.ActiveForm.Cursor = Cursors.AppStarting;
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
                    MessageBox.Show("Error al editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error al registrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);
            }
            funActualizarGrid();
            cmbDescripcion.Text = "";
            cmbValor.Text = "";
            dtpFecha.Text = "";
            frmMenu.ActiveForm.Cursor = Cursors.Arrow;

        }
    }
}
