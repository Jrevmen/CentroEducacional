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
    public partial class frmIngresoNotas : Form
    {
        string sCPaquete;
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
        }

        private void funActualizarGrid()
        {
            System.Console.WriteLine("EL CODIGO QUE TENGO ES////// " + sCPaquete);
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistros("asignacioncurso", "SELECT carnet.codigoCarnet AS CodCarnet, encabezado_incripcion.codigoInscripcion AS CodInscripcion, persona.nombre AS NOMBRE FROM asignacioncurso, paquete, encabezado_incripcion, carnet, persona WHERE persona.codigopersona=carnet.codigopersona AND encabezado_incripcion.codigoCarnet=carnet.codigoCarnet AND asignacioncurso.codigoInscripcion=encabezado_incripcion.codigoInscripcion AND paquete.ccodigo_paquete=asignacioncurso.ccodigo_paquete AND paquete.ccodigo_paquete='"+sCPaquete+"'", "consulta", grdTipoNota);            
        }

        private void funLlenarCombo() 
        {
            clasnegocio cnegocio = new clasnegocio();
            cnegocio.funconsultarRegistrosCombo("tipo_nota", "SELECT concat(tipo_nota.descripcion,' (', tipo_nota.valor, ')') AS Examenes FROM tipo_nota WHERE tipo_nota.ccodigo_paquete='" + sCPaquete + "' AND tipo_nota.condicion='1'", "Examenes", cmbDescripcion);
        }
    }
}
