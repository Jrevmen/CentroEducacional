﻿namespace Aerolinea
{
    partial class frmRePrincipalInscripcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRePrincipalInscripcion));
            this.grupoFiltrar = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnIrUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnIrPrimero = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.grdInscripcion = new System.Windows.Forms.DataGridView();
            this.grupoFiltrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInscripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // grupoFiltrar
            // 
            this.grupoFiltrar.Controls.Add(this.textBox2);
            this.grupoFiltrar.Controls.Add(this.textBox1);
            this.grupoFiltrar.Controls.Add(this.btnIrUltimo);
            this.grupoFiltrar.Controls.Add(this.btnSiguiente);
            this.grupoFiltrar.Controls.Add(this.btnAnterior);
            this.grupoFiltrar.Controls.Add(this.btnIrPrimero);
            this.grupoFiltrar.Controls.Add(this.btnRefrescar);
            this.grupoFiltrar.Controls.Add(this.btnNuevo);
            this.grupoFiltrar.Controls.Add(this.label1);
            this.grupoFiltrar.Controls.Add(this.txtBuscar);
            this.grupoFiltrar.Controls.Add(this.lblBuscar);
            this.grupoFiltrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grupoFiltrar.Location = new System.Drawing.Point(0, 508);
            this.grupoFiltrar.Name = "grupoFiltrar";
            this.grupoFiltrar.Size = new System.Drawing.Size(1046, 61);
            this.grupoFiltrar.TabIndex = 3;
            this.grupoFiltrar.TabStop = false;
            this.grupoFiltrar.Text = "Filtrar";
            this.grupoFiltrar.Enter += new System.EventHandler(this.grupoFiltrar_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(99, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 24;
            this.textBox2.Text = "ACTIVO";
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(205, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.Visible = false;
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
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(708, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mant. Re-inscripcion";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(61, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(209, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
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
            // grdInscripcion
            // 
            this.grdInscripcion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdInscripcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInscripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInscripcion.Location = new System.Drawing.Point(0, 0);
            this.grdInscripcion.Name = "grdInscripcion";
            this.grdInscripcion.ReadOnly = true;
            this.grdInscripcion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInscripcion.Size = new System.Drawing.Size(1046, 569);
            this.grdInscripcion.TabIndex = 2;
            this.grdInscripcion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInscripcion_CellContentClick);
            this.grdInscripcion.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInscripcion_CellContentDoubleClick);
            // 
            // frmRePrincipalInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1046, 569);
            this.Controls.Add(this.grupoFiltrar);
            this.Controls.Add(this.grdInscripcion);
            this.Name = "frmRePrincipalInscripcion";
            this.Text = "frmPrincipalInscripcion";
            this.grupoFiltrar.ResumeLayout(false);
            this.grupoFiltrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInscripcion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoFiltrar;
        private System.Windows.Forms.Button btnIrUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnIrPrimero;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView grdInscripcion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}