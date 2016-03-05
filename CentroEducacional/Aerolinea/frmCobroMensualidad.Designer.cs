namespace Aerolinea
{
    partial class frmCobroMensualidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobroMensualidad));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.Monto = new System.Windows.Forms.Label();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnIrUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnIrPrimero = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.txtContrato = new System.Windows.Forms.TextBox();
            this.txtTipoServicio = new System.Windows.Forms.TextBox();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtTipoPago = new System.Windows.Forms.TextBox();
            this.cmbTipoPago = new System.Windows.Forms.ComboBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbInscripcion = new System.Windows.Forms.ComboBox();
            this.btnServicio = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "yyyy-MM-dd";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(398, 152);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(141, 152);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(154, 20);
            this.txtMonto.TabIndex = 21;
            this.txtMonto.Tag = "monto";
            // 
            // Monto
            // 
            this.Monto.AutoSize = true;
            this.Monto.Location = new System.Drawing.Point(82, 155);
            this.Monto.Name = "Monto";
            this.Monto.Size = new System.Drawing.Size(37, 13);
            this.Monto.TabIndex = 20;
            this.Monto.Text = "Monto";
            // 
            // txtCarnet
            // 
            this.txtCarnet.Location = new System.Drawing.Point(141, 103);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(154, 20);
            this.txtCarnet.TabIndex = 17;
            this.txtCarnet.Tag = "codigoCarnet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Carnet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnInfo);
            this.panel1.Controls.Add(this.btnIrUltimo);
            this.panel1.Controls.Add(this.btnSiguiente);
            this.panel1.Controls.Add(this.btnAnterior);
            this.panel1.Controls.Add(this.btnIrPrimero);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnRefrescar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Location = new System.Drawing.Point(58, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 55);
            this.panel1.TabIndex = 24;
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Location = new System.Drawing.Point(393, 4);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(48, 42);
            this.btnInfo.TabIndex = 17;
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // btnIrUltimo
            // 
            this.btnIrUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnIrUltimo.Image")));
            this.btnIrUltimo.Location = new System.Drawing.Point(609, 4);
            this.btnIrUltimo.Name = "btnIrUltimo";
            this.btnIrUltimo.Size = new System.Drawing.Size(48, 42);
            this.btnIrUltimo.TabIndex = 16;
            this.btnIrUltimo.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.Location = new System.Drawing.Point(555, 4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(48, 42);
            this.btnSiguiente.TabIndex = 15;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(501, 4);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(48, 42);
            this.btnAnterior.TabIndex = 14;
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnIrPrimero
            // 
            this.btnIrPrimero.Image = ((System.Drawing.Image)(resources.GetObject("btnIrPrimero.Image")));
            this.btnIrPrimero.Location = new System.Drawing.Point(447, 4);
            this.btnIrPrimero.Name = "btnIrPrimero";
            this.btnIrPrimero.Size = new System.Drawing.Size(48, 42);
            this.btnIrPrimero.TabIndex = 13;
            this.btnIrPrimero.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(339, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(48, 42);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.Location = new System.Drawing.Point(285, 4);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(48, 42);
            this.btnRefrescar.TabIndex = 10;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(231, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(48, 42);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(177, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(48, 42);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(123, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(48, 42);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(69, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(48, 42);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(15, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(48, 42);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(398, 106);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 13);
            this.lblNombre.TabIndex = 25;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.Location = new System.Drawing.Point(301, 102);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(24, 20);
            this.btnFiltrar.TabIndex = 26;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cmbTipoServicio
            // 
            this.cmbTipoServicio.FormattingEnabled = true;
            this.cmbTipoServicio.Location = new System.Drawing.Point(16, 134);
            this.cmbTipoServicio.Name = "cmbTipoServicio";
            this.cmbTipoServicio.Size = new System.Drawing.Size(40, 21);
            this.cmbTipoServicio.TabIndex = 34;
            this.cmbTipoServicio.Visible = false;
            // 
            // txtContrato
            // 
            this.txtContrato.Location = new System.Drawing.Point(661, 184);
            this.txtContrato.Name = "txtContrato";
            this.txtContrato.Size = new System.Drawing.Size(55, 20);
            this.txtContrato.TabIndex = 33;
            this.txtContrato.Tag = "codigo_contrato";
            this.txtContrato.Visible = false;
            // 
            // txtTipoServicio
            // 
            this.txtTipoServicio.Location = new System.Drawing.Point(737, 153);
            this.txtTipoServicio.Name = "txtTipoServicio";
            this.txtTipoServicio.Size = new System.Drawing.Size(47, 20);
            this.txtTipoServicio.TabIndex = 32;
            this.txtTipoServicio.Tag = "codigo_tipo_servicio";
            this.txtTipoServicio.Visible = false;
            // 
            // txtCondicion
            // 
            this.txtCondicion.Location = new System.Drawing.Point(737, 180);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(31, 20);
            this.txtCondicion.TabIndex = 31;
            this.txtCondicion.Tag = "condicion";
            this.txtCondicion.Text = "1";
            this.txtCondicion.Visible = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(593, 184);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(48, 20);
            this.txtEstado.TabIndex = 30;
            this.txtEstado.Tag = "estado";
            this.txtEstado.Text = "ACTIVO";
            this.txtEstado.Visible = false;
            // 
            // txtTipoPago
            // 
            this.txtTipoPago.Location = new System.Drawing.Point(737, 100);
            this.txtTipoPago.Name = "txtTipoPago";
            this.txtTipoPago.Size = new System.Drawing.Size(47, 20);
            this.txtTipoPago.TabIndex = 29;
            this.txtTipoPago.Tag = "cod_tipo_pago";
            this.txtTipoPago.Visible = false;
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Location = new System.Drawing.Point(737, 126);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new System.Drawing.Size(47, 21);
            this.cmbTipoPago.TabIndex = 28;
            this.cmbTipoPago.Visible = false;
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(737, 70);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(47, 20);
            this.txtfecha.TabIndex = 27;
            this.txtfecha.Tag = "fecha";
            this.txtfecha.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Inscripcion";
            // 
            // cmbInscripcion
            // 
            this.cmbInscripcion.FormattingEnabled = true;
            this.cmbInscripcion.Location = new System.Drawing.Point(243, 184);
            this.cmbInscripcion.Name = "cmbInscripcion";
            this.cmbInscripcion.Size = new System.Drawing.Size(248, 21);
            this.cmbInscripcion.TabIndex = 36;
            // 
            // btnServicio
            // 
            this.btnServicio.Image = ((System.Drawing.Image)(resources.GetObject("btnServicio.Image")));
            this.btnServicio.Location = new System.Drawing.Point(497, 184);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(24, 20);
            this.btnServicio.TabIndex = 37;
            this.btnServicio.UseVisualStyleBackColor = true;
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // frmCobroMensualidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 224);
            this.Controls.Add(this.btnServicio);
            this.Controls.Add(this.cmbInscripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoServicio);
            this.Controls.Add(this.txtContrato);
            this.Controls.Add(this.txtTipoServicio);
            this.Controls.Add(this.txtCondicion);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtTipoPago);
            this.Controls.Add(this.cmbTipoPago);
            this.Controls.Add(this.txtfecha);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.Monto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarnet);
            this.Controls.Add(this.label1);
            this.Name = "frmCobroMensualidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobro Inscripcion";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label Monto;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnIrUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnIrPrimero;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cmbTipoServicio;
        private System.Windows.Forms.TextBox txtContrato;
        private System.Windows.Forms.TextBox txtTipoServicio;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtTipoPago;
        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbInscripcion;
        private System.Windows.Forms.Button btnServicio;
    }
}