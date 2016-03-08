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

namespace Aerolinea
{
    public partial class frmIngresoNotas : Form
    {
        public static OdbcCommand _comando;
        public static OdbcDataReader _reader;
        string sCPaquete;
        string sNomUsuario;
        string sCodigoEmpleado;
        string sCadena;

        public frmIngresoNotas()
        {
            InitializeComponent();                       
        }

        public frmIngresoNotas(string sCodPaquete)
        {
            InitializeComponent();
            sCPaquete = sCodPaquete;
            funLlenarCombo();
            funActualizarGrid();
            sNomUsuario = claseUsuario.varibaleUsuario;
            funCodEmpleado();
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

        string funCortadorCadena(string sDato)
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

        private void funActualizarGrid()
        {
            System.Console.WriteLine("EL CODIGO QUE TENGO ES//////--- " + sCPaquete);
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("asignacioncurso", "SELECT carnet.codigoCarnet AS CCAR, encabezado_incripcion.codigoInscripcion AS CINS, persona.nombre AS NOMBRE FROM asignacioncurso, paquete, encabezado_incripcion, carnet, persona WHERE persona.codigopersona=carnet.codigopersona AND encabezado_incripcion.codigoCarnet=carnet.codigoCarnet AND asignacioncurso.codigoInscripcion=encabezado_incripcion.codigoInscripcion AND paquete.ccodigo_paquete=asignacioncurso.ccodigo_paquete AND paquete.ccodigo_paquete='"+sCPaquete+"'", "consulta", grdIngresoNotas);
            grdIngresoNotas.Columns["NOMBRE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdIngresoNotas.Columns["Calificacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdIngresoNotas.Columns["CCAR"].ReadOnly = true;
            grdIngresoNotas.Columns["CINS"].ReadOnly = true;
            grdIngresoNotas.Columns["NOMBRE"].ReadOnly = true;
            grdIngresoNotas.Columns["Calificacion"].DisplayIndex = 3;
        }

        private void funLlenarCombo() 
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("tipo_nota", "SELECT concat(codig_tipo_nota, '.',tipo_nota.descripcion) AS Examenes FROM tipo_nota WHERE tipo_nota.ccodigo_paquete='" + sCPaquete + "' AND tipo_nota.condicion='1'", "Examenes", cmbDescripcion);
        }

        private void funCodEmpleado() {

            System.Console.WriteLine("-------EMPLEADO>> " + sNomUsuario);
            ///CONSULTA DE EL CODIGO DEL EMPLEADO
            _comando = new OdbcCommand(String.Format("SELECT empleado.codigo_empleado FROM usuario, persona, empleado WHERE empleado.codigopersona=persona.codigopersona AND persona.codigopersona=usuario.codigopersona AND usuario.nombre_usuario='" + sNomUsuario + "'"), ConexionODBC.Conexion.ObtenerConexion());
            _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                sCodigoEmpleado = _reader.GetString(0);
            }
            System.Console.WriteLine("-------CODIGO EMPLEADO>> " + sCodigoEmpleado);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //txtNombre.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarCombobox(cmbDescripcion, true);

            grdIngresoNotas.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void funPrimer()
        {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;
            //string sCodigo;
            TextBox txtCalificacion = new TextBox();
            txtCalificacion.Tag = "calificacion";

            TextBox txtDate = new TextBox();
            txtDate.Tag = "fecha";
            txtDate.Text = dtpFecha.Text;

            TextBox txtEstado = new TextBox();
            txtEstado.Tag = "estado";
            txtEstado.Text = "ACTIVO";

            TextBox txtCarnet = new TextBox();
            txtCarnet.Tag = "codigoCarnet";

            TextBox txtInscripcion = new TextBox();
            txtInscripcion.Tag = "codigoInscripcion";

            TextBox txtCondicion = new TextBox();
            txtCondicion.Tag = "condicion";
            txtCondicion.Text = "1";

            TextBox txtNota = new TextBox();
            txtNota.Tag = "nota";

            TextBox txtCodEncabezado = new TextBox();
            txtCodEncabezado.Tag = "codigo_encabezado_nota";

            TextBox txtCodEmpleado = new TextBox();
            txtCodEmpleado.Tag = "codigo_empleado";
            txtCodEmpleado.Text = sCodigoEmpleado;
            
            TextBox txtCodTipoNota = new TextBox();
            txtCodTipoNota.Tag = "codig_tipo_nota";
            txtCodTipoNota.Text = funCortadorID(cmbDescripcion.Text);                     

            for (int q = 0; q < grdIngresoNotas.Rows.Count-1; q++)
            {
                System.Console.WriteLine("-------FILAS>>>>> " + grdIngresoNotas.Rows.Count.ToString());
                System.Console.WriteLine("-------FILA>>>>> " + q.ToString());
                txtCarnet.Text = grdIngresoNotas.Rows[q].Cells[1].Value.ToString();
                txtInscripcion.Text = grdIngresoNotas.Rows[q].Cells[1].Value.ToString();
                System.Console.WriteLine("-------CODIGO DE CARNET>> " +txtCarnet.Text);
                txtNota.Text = grdIngresoNotas.Rows[q].Cells[0].Value.ToString();
                txtCalificacion.Text = grdIngresoNotas.Rows[q].Cells[0].Value.ToString();
                System.Console.WriteLine("-------NOTA INGRESADA>> " + txtNota.Text);
                
                /// INSERCION EN LA TABLA ENCABEZADO_NOTA
                System.Console.WriteLine("-------PARA ENCABEZADO NOTA---------- ");
                System.Console.WriteLine("-------CALIFICACION INGRESADA>> " + txtCalificacion.Text);
                System.Console.WriteLine("-------FECHA>> " + txtDate.Text);
                System.Console.WriteLine("-------ESTADO>> " + txtEstado.Text);
                System.Console.WriteLine("-------CARNET>> " + txtCarnet.Text);
                System.Console.WriteLine("-------INSCRIPCION>> " + txtInscripcion.Text);
                System.Console.WriteLine("-------CONDICION>> " + txtCondicion.Text);
                TextBox[] aDatos = { txtCalificacion, txtDate, txtEstado, txtCarnet, txtInscripcion, txtCondicion };
                string sTabla = "encabezado_nota";
                cn.AsignarObjetos(sTabla, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla);

                
                ///CONSULTA DE EL CODIGO QUE SE INSERTO EN EL BLOQUE DE ARRIBA
                _comando = new OdbcCommand(String.Format("SELECT MAX(codigo_encabezado_nota) FROM encabezado_nota"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    txtCodEncabezado.Text = _reader.GetString(0);
                }
                
                
                System.Console.WriteLine("-------PARA NOTA---------- ");
                System.Console.WriteLine("-------NOTA>> " + txtNota.Text);
                System.Console.WriteLine("-------CODIGO ENCABEZADO>> " + txtCodEncabezado.Text);
                System.Console.WriteLine("-------CODIGO EMPLEADO>> " + txtCodEmpleado.Text);
                System.Console.WriteLine("-------TIPO NOTA>> " + txtCodTipoNota.Text);
                System.Console.WriteLine("-------CONDICION>> " + txtCondicion.Text);
                System.Console.WriteLine("-------FECHA>> " + txtDate.Text);
                
                /// INSERCION EN LA TABLA NOTA
                TextBox[] aDatos2 = { txtNota, txtCodEncabezado, txtCodEmpleado, txtCodTipoNota, txtCondicion, txtDate };
                string sTabla2 = "nota";
                cn.AsignarObjetos(sTabla2, bPermiso, aDatos2);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla2);
                //this.Close();
            }
        }

        private void funSegundo() {
            clasnegocio cn = new clasnegocio();
            Boolean bPermiso = true;

            TextBox txtCondicion = new TextBox();
            txtCondicion.Tag = "condicion";
            txtCondicion.Text = "1";

            TextBox txtNota = new TextBox();
            txtNota.Tag = "nota";

            TextBox txtCodEncabezado = new TextBox();
            txtCodEncabezado.Tag = "codigo_encabezado_nota";

            TextBox txtCodEmpleado = new TextBox();
            txtCodEmpleado.Tag = "codigo_empleado";
            txtCodEmpleado.Text = sCodigoEmpleado;

            TextBox txtCodTipoNota = new TextBox();
            txtCodTipoNota.Tag = "codig_tipo_nota";
            txtCodTipoNota.Text = funCortadorID(cmbDescripcion.Text);

            TextBox txtEstado = new TextBox();
            txtEstado.Tag = "estado";
            txtEstado.Text = "ACTIVO";

            TextBox txtDate = new TextBox();
            txtDate.Tag = "fecha";
            txtDate.Text = dtpFecha.Text;

            TextBox txtCarnet = new TextBox();
            txtCarnet.Tag = "codigoCarnet";

            int iTNotaAnterior = Int32.Parse(txtCodTipoNota.Text) - 1;

            for (int q = 0; q < grdIngresoNotas.Rows.Count - 1; q++)
            {                
                ///CONSULTA DE EL ENCABEZADO NOTA QUE YA POSEE EL CURSO
                txtCarnet.Text = grdIngresoNotas.Rows[q].Cells[1].Value.ToString();
                _comando = new OdbcCommand(String.Format("SELECT nota.codigo_encabezado_nota FROM nota, encabezado_nota WHERE nota.codigo_encabezado_nota=encabezado_nota.codigo_encabezado_nota AND encabezado_nota.codigoCarnet='"+txtCarnet.Text+"' AND nota.codig_tipo_nota='"+iTNotaAnterior+"'"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    txtCodEncabezado.Text = _reader.GetString(0);
                }


                System.Console.WriteLine("-------PARA NOTA---------- ");
                System.Console.WriteLine("-------NOTA>> " + txtNota.Text);
                System.Console.WriteLine("-------CODIGO ENCABEZADO>> " + txtCodEncabezado.Text);
                System.Console.WriteLine("-------CODIGO EMPLEADO>> " + txtCodEmpleado.Text);
                System.Console.WriteLine("-------TIPO NOTA>> " + txtCodTipoNota.Text);
                System.Console.WriteLine("-------CONDICION>> " + txtCondicion.Text);
                System.Console.WriteLine("-------FECHA>> " + txtDate.Text);

                /// INSERCION EN LA TABLA NOTA
                TextBox[] aDatos2 = { txtNota, txtCodEncabezado, txtCodEmpleado, txtCodTipoNota, txtCondicion, txtDate };
                string sTabla2 = "nota";
                cn.AsignarObjetos(sTabla2, bPermiso, aDatos2);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla2);
                //this.Close();
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(funCortadorCadena(cmbDescripcion.Text).Equals("1er Parcial")){
                funPrimer();
                MessageBox.Show("Las notas fueron insertadas con exito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((funCortadorCadena(cmbDescripcion.Text).Equals("2do Parcial")) || (funCortadorCadena(cmbDescripcion.Text).Equals("Actividades")))
            {
                funSegundo();
                MessageBox.Show("Las notas fueron insertadas con exito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((funCortadorCadena(cmbDescripcion.Text).Equals("Final"))) { }                                                
        }

        
    }
}
