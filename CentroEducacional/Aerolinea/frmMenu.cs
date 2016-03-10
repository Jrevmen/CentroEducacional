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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            
            this.UseWaitCursor = true;
            this.Cursor = Cursors.AppStarting;
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmPersona") == "no") { this.alumnosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmEmpleado") == "no") { this.empleadosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmFamilia") == "no") { this.familiaresToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmPuestos") == "no") { this.puestosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmSalones") == "no") { this.salonesToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCursos") == "no") { this.cursosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmParqueos") == "no") { this.parqueosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmLaboratorios") == "no") { this.laboratoriosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmPensum") == "no") { this.pensumToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmParqueos") == "no") { this.parqueosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmSedes") == "no") { this.sedesToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmTipoPago") == "no") { this.tipoPagoToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmTipoServicio") == "no") { this.tipoServicioToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCarrera") == "no") { this.facultadYCarreraToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmJornada") == "no") { this.jornadaToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmRol") == "no") { this.rolToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmHorario") == "no") { this.horarioToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmSeccion") == "no") { this.seccionToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmFacultad") == "no") { this.facultadToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmAsigOrd") == "no") { this.asignacionOrdinariaToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmReasignacion") == "no") { this.reasignacionesToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmAsigParq") == "no") { this.asignacionDeParqueoToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmReinscripcion") == "no") { this.reinscripcionesToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCreacionPensum") == "no") { this.creacionDePensumToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCreacionPaquete") == "no") { this.creacionDePaquetesToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmNotas") == "no") { this.mantenimientoToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmZona") == "no") { this.distribucionZonaToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCobroParqueo") == "no") { this.cobroDeParqueoToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmMensualidad") == "no") { this.cobroDeMensualidadToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCobroInscrip") == "no") { this.cobroDeInscripcionToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCobroReasig") == "no") { this.cobroReasignacionToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCobroDoc") == "no") { this.cobroDeDocumentosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmPagoEmpleado") == "no") { this.pagoEmpleadosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmUsuario") == "no") { this.creacionUsuariosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmRol") == "no") { this.rolToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmBitacora") == "no") { this.bitacoraToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmCertificacion") == "no") { this.certificacionDeCursosToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmTalonarios") == "no") { this.talonarioToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmPagosPendientes") == "no") { this.boletaDePagosPendientesToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmSolvencias") == "no") { this.solvenciasToolStripMenuItem.Enabled = false; }
            if (claseUsuario.ObtenerPermisosForm(claseUsuario.varibaleUsuario, "frmReporteCatalogos") == "no") { this.reportesDeCatalogosToolStripMenuItem.Enabled = false; }
            this.Cursor = Cursors.Arrow;
            this.UseWaitCursor = false;

        }

        private void cERRARSESSIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Esta seguro que desea cerrar session?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                frmLogin login = new frmLogin();
                login.Show();  
            }
        }

        
        private void aYUDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, "file://C:\\Aerolínea.chm");
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbitacora temp = new frmbitacora();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void creacionUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmPrincipalUsuarios temp = new frmPrincipalUsuarios();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void facultadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalFacultad temp = new frmPrincipalFacultad();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void salonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmPrincipalSalones temp = new frmPrincipalSalones();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void sedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalSedes temp = new frmPrincipalSedes();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void tipoPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalTipoPago temp = new frmPrincipalTipoPago();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void tipoServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalTipoServicio temp = new frmPrincipalTipoServicio();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void facultadYCarreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCarrera temp = new frmCarrera();
            //temp.Show();
            frmPrincipalCarrera temp = new frmPrincipalCarrera();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void pensumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalPensum temp = new frmPrincipalPensum();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalPersona temp = new frmPrincipalPersona();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void asignacionDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignacionRoles temp = new frmAsignacionRoles();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void reinscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInscripcionAlumno temp = new frmInscripcionAlumno();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void creacionDePaquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreacionPaquetes temp = new frmCreacionPaquetes();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void certificacionDeCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportesDeCatalogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 temp = new Form1();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalIngresoNotas temp = new frmPrincipalIngresoNotas();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void distribucionZonaToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            frmPrincipalPonderacionNota temp = new frmPrincipalPonderacionNota();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();                   
        }

        private void cobroDeParqueoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalCobroParqueo temp = new frmPrincipalCobroParqueo();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void asignacionDeParqueoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignacionparqueo temp = new frmAsignacionparqueo();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void cobroDeMensualidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalCobroMensualidad temp = new frmPrincipalCobroMensualidad();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalCursos temp = new frmPrincipalCursos();
            temp.WindowState = FormWindowState.Maximized;
            temp.MdiParent = this;
            pictureBox1.Visible = false;
            temp.Show();
        }
    }
}
