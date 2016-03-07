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
        public frmIngresoNotas()
        {
            InitializeComponent();
            sNomUsuario = claseUsuario.varibaleUsuario;
        }

        public frmIngresoNotas(string sCodPaquete)
        {
            InitializeComponent();
            sCPaquete = sCodPaquete;
            funLlenarCombo();
            funActualizarGrid();
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

        string funCortadorCadena(string sDato)
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
            System.Console.WriteLine("EL CODIGO QUE TENGO ES////// " + sCPaquete);
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("asignacioncurso", "SELECT carnet.codigoCarnet AS CCAR, encabezado_incripcion.codigoInscripcion AS CINS, persona.nombre AS NOMBRE FROM asignacioncurso, paquete, encabezado_incripcion, carnet, persona WHERE persona.codigopersona=carnet.codigopersona AND encabezado_incripcion.codigoCarnet=carnet.codigoCarnet AND asignacioncurso.codigoInscripcion=encabezado_incripcion.codigoInscripcion AND paquete.ccodigo_paquete=asignacioncurso.ccodigo_paquete AND paquete.ccodigo_paquete='"+sCPaquete+"'", "consulta", grdTipoNota);
            grdTipoNota.Columns["NOMBRE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdTipoNota.Columns["Calificacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdTipoNota.Columns["CCAR"].ReadOnly = true;
            grdTipoNota.Columns["CINS"].ReadOnly = true;
            grdTipoNota.Columns["NOMBRE"].ReadOnly = true;
            grdTipoNota.Columns["Calificacion"].DisplayIndex = 3;
        }

        private void funLlenarCombo() 
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("tipo_nota", "SELECT concat(tipo_nota.descripcion,' (', tipo_nota.valor, ')') AS Examenes FROM tipo_nota WHERE tipo_nota.ccodigo_paquete='" + sCPaquete + "' AND tipo_nota.condicion='1'", "Examenes", cmbDescripcion);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //txtNombre.Clear();
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funactivarDesactivarCombobox(cmbDescripcion, true);

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
            //string sCodigo;
            TextBox txtNota = new TextBox();
            TextBox txtCarnet = new TextBox();
            TextBox txtCodEncabezado = new TextBox();
            TextBox txtCodEmpleado = new TextBox();
            TextBox txtCodDescripcion = new TextBox();
            txtCodDescripcion.Text = funCortador(cmbDescripcion.Text);

            int f=grdTipoNota.RowCount;

            for (int q = 0; q <= grdTipoNota.RowCount; q++)
            {
                txtCarnet.Text = grdTipoNota.Rows[q].Cells[0].Value.ToString();
                txtNota.Text = grdTipoNota.Rows[q].Cells[3].Value.ToString();

                /// INSERCION EN LA TABLA ENCABEZADO_NOTA
                TextBox[] aDatos = { txtNota, txtFecha, txtEstado, txtCarnet, txtCarnet, txtCondicion };
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

                ///CONSULTA DE EL CODIGO DEL EMPLEADO
                _comando = new OdbcCommand(String.Format("SELECT empleado.codigo_empleado FROM usuario, persona, empleado WHERE empleado.codigopersona=persona.codigopersona AND persona.codigopersona=usuario.codigopersona AND usuario.nombre_usuario='" + sNomUsuario + "'"), ConexionODBC.Conexion.ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    txtCodEmpleado.Text = _reader.GetString(0);
                }

                /// INSERCION EN LA TABLA NOTA
                TextBox[] aDatos2 = { txtNota, txtCodEncabezado, txtCodEmpleado, txtCodDescripcion, txtCondicion, txtFecha };
                string sTabla2 = "nota";
                cn.AsignarObjetos(sTabla2, bPermiso, aDatos);
                claseUsuario.funobtenerBitacora(claseUsuario.varibaleUsuario, "Insertar", sTabla2);
                this.Close();
            }

            
        }
    }
}
