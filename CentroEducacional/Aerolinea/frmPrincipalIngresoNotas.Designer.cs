namespace Aerolinea
{
    partial class frmPrincipalIngresoNotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipalIngresoNotas));
            this.grdCursos = new System.Windows.Forms.DataGridView();
            this.grupoFiltrar = new System.Windows.Forms.GroupBox();
            this.btnIrUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnIrPrimero = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCursos)).BeginInit();
            this.grupoFiltrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCursos
            // 
            this.grdCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCursos.Location = new System.Drawing.Point(0, 0);
            this.grdCursos.Name = "grdCursos";
            this.grdCursos.ReadOnly = true;
            this.grdCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCursos.Size = new System.Drawing.Size(1014, 511);
            this.grdCursos.TabIndex = 7;
            this.grdCursos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCursos_CellDoubleClick);
            // 
            // grupoFiltrar
            // 
            this.grupoFiltrar.Controls.Add(this.btnIrUltimo);
            this.grupoFiltrar.Controls.Add(this.btnSiguiente);
            this.grupoFiltrar.Controls.Add(this.btnAnterior);
            this.grupoFiltrar.Controls.Add(this.btnIrPrimero);
            this.grupoFiltrar.Controls.Add(this.btnRefrescar);
            this.grupoFiltrar.Controls.Add(this.btnNuevo);
            this.grupoFiltrar.Controls.Add(this.lblDescripcion);
            this.grupoFiltrar.Controls.Add(this.txtBuscar);
            this.grupoFiltrar.Controls.Add(this.lblBuscar);
            this.grupoFiltrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grupoFiltrar.Location = new System.Drawing.Point(0, 450);
            this.grupoFiltrar.Name = "grupoFiltrar";
            this.grupoFiltrar.Size = new System.Drawing.Size(1014, 61);
            this.grupoFiltrar.TabIndex = 8;
            this.grupoFiltrar.TabStop = false;
            this.grupoFiltrar.Text = "Filtrar";
            // 
            // btnIrUltimo
            // 
            this.btnIrUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnIrUltimo.Image")));
            this.btnIrUltimo.Location = new System.Drawing.Point(581, 13);
            this.btnIrUltimo.Name = "btnIrUltimo";
            this.btnIrUltimo.Size = new System.Drawing.Size(48, 42);
            this.btnIrUltimo.TabIndex = 22;
            this.btnIrUltimo.UseVisualStyleBackColor = true;
            this.btnIrUltimo.Click += new System.EventHandler(this.btnIrUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.Location = new System.Drawing.Point(527, 13);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(48, 42);
            this.btnSiguiente.TabIndex = 21;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(473, 13);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(48, 42);
            this.btnAnterior.TabIndex = 20;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnIrPrimero
            // 
            this.btnIrPrimero.Image = ((System.Drawing.Image)(resources.GetObject("btnIrPrimero.Image")));
            this.btnIrPrimero.Location = new System.Drawing.Point(419, 13);
            this.btnIrPrimero.Name = "btnIrPrimero";
            this.btnIrPrimero.Size = new System.Drawing.Size(48, 42);
            this.btnIrPrimero.TabIndex = 19;
            this.btnIrPrimero.UseVisualStyleBackColor = true;
            this.btnIrPrimero.Click += new System.EventHandler(this.btnIrPrimero_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.Location = new System.Drawing.Point(365, 13);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(48, 42);
            this.btnRefrescar.TabIndex = 18;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(311, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(48, 42);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(709, 16);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(302, 42);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Ingreso de Notas";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(61, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(209, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(12, 28);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(47, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Nombre:";
            // 
            // frmPrincipalIngresoNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 511);
            this.Controls.Add(this.grupoFiltrar);
            this.Controls.Add(this.grdCursos);
            this.Name = "frmPrincipalIngresoNotas";
            this.Text = "Principal Ingreso Notas";
            ((System.ComponentModel.ISupportInitialize)(this.grdCursos)).EndInit();
            this.grupoFiltrar.ResumeLayout(false);
            this.grupoFiltrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCursos;
        private System.Windows.Forms.GroupBox grupoFiltrar;
        private System.Windows.Forms.Button btnIrUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnIrPrimero;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
    }
}