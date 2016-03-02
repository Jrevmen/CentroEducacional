using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Aerolinea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void funconsultarTablas()
        {
            /*using (clasconexion.funobtenerConexion())
            {
                string squery = "SHOW FULL TABLES FROM centro_educacional";
                OdbcCommand cmdc = new OdbcCommand(squery, clasconexion.funobtenerConexion());
                DataTable dtDatos = new DataTable();
                OdbcDataAdapter mdaDatos = new OdbcDataAdapter(squery, clasconexion.funobtenerConexion());
                mdaDatos.Fill(dtDatos);
                dataGridView1.DataSource = dtDatos;
                clasconexion.funobtenerConexion().Close();
            }*/
        }

        public void funactivarDesactivarGrid(DataGridView tb, Boolean status) { tb.Enabled = status; }


        private void Form1_Load(object sender, EventArgs e)
        {
            funconsultarTablas();
            funactivarDesactivarGrid(dataGridView1, false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String valor = null;
            try
            {
                valor = comboBox1.SelectedValue.ToString();
                if (valor == "Catalogos")
                {
                    funactivarDesactivarGrid(dataGridView1, true);
                }
            }catch(Exception exp){

            }
        }
    }
}
