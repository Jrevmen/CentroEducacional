namespace Aerolinea
{
    partial class frmcontrolUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcontrolUsuarios));
            this.groupBoxDatosUsuario = new System.Windows.Forms.GroupBox();
            this.txtGuarda = new System.Windows.Forms.TextBox();
            this.txtRectificaPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMuestra = new System.Windows.Forms.ComboBox();
            this.lbPersona = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbPrivilegios = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GridPrivilegios = new System.Windows.Forms.DataGridView();
            this.rdNuevo = new System.Windows.Forms.RadioButton();
            this.cmbRolPre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdPre = new System.Windows.Forms.RadioButton();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.txtGuarda2 = new System.Windows.Forms.TextBox();
            this.txtXX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreForm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Insertar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBoxDatosUsuario.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbPrivilegios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrivilegios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDatosUsuario
            // 
            this.groupBoxDatosUsuario.Controls.Add(this.txtGuarda);
            this.groupBoxDatosUsuario.Controls.Add(this.txtRectificaPassword);
            this.groupBoxDatosUsuario.Controls.Add(this.label3);
            this.groupBoxDatosUsuario.Controls.Add(this.cbMuestra);
            this.groupBoxDatosUsuario.Controls.Add(this.lbPersona);
            this.groupBoxDatosUsuario.Controls.Add(this.txtPassword);
            this.groupBoxDatosUsuario.Controls.Add(this.txtUser);
            this.groupBoxDatosUsuario.Controls.Add(this.labelUser);
            this.groupBoxDatosUsuario.Controls.Add(this.labelPass);
            this.groupBoxDatosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDatosUsuario.Location = new System.Drawing.Point(16, 113);
            this.groupBoxDatosUsuario.Name = "groupBoxDatosUsuario";
            this.groupBoxDatosUsuario.Size = new System.Drawing.Size(362, 152);
            this.groupBoxDatosUsuario.TabIndex = 0;
            this.groupBoxDatosUsuario.TabStop = false;
            this.groupBoxDatosUsuario.Text = "Datos de Usuario";
            this.groupBoxDatosUsuario.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtGuarda
            // 
            this.txtGuarda.Location = new System.Drawing.Point(8, 245);
            this.txtGuarda.Name = "txtGuarda";
            this.txtGuarda.Size = new System.Drawing.Size(10, 21);
            this.txtGuarda.TabIndex = 183;
            // 
            // txtRectificaPassword
            // 
            this.txtRectificaPassword.Location = new System.Drawing.Point(160, 82);
            this.txtRectificaPassword.Name = "txtRectificaPassword";
            this.txtRectificaPassword.PasswordChar = '*';
            this.txtRectificaPassword.Size = new System.Drawing.Size(191, 21);
            this.txtRectificaPassword.TabIndex = 13;
            this.txtRectificaPassword.TextChanged += new System.EventHandler(this.txtRectificaPassword_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Repetir Contraseña";
            // 
            // cbMuestra
            // 
            this.cbMuestra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMuestra.FormattingEnabled = true;
            this.cbMuestra.Location = new System.Drawing.Point(160, 115);
            this.cbMuestra.Name = "cbMuestra";
            this.cbMuestra.Size = new System.Drawing.Size(191, 24);
            this.cbMuestra.TabIndex = 11;
            this.cbMuestra.SelectedIndexChanged += new System.EventHandler(this.cbMuestra_SelectedIndexChanged);
            this.cbMuestra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbMuestra_KeyUp_1);
            // 
            // lbPersona
            // 
            this.lbPersona.AutoSize = true;
            this.lbPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersona.Location = new System.Drawing.Point(6, 115);
            this.lbPersona.Name = "lbPersona";
            this.lbPersona.Size = new System.Drawing.Size(68, 20);
            this.lbPersona.TabIndex = 10;
            this.lbPersona.Text = "Persona";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(160, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(191, 21);
            this.txtPassword.TabIndex = 7;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(160, 29);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(191, 21);
            this.txtUser.TabIndex = 6;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(6, 30);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(68, 20);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "Usuario:";
            this.labelUser.Click += new System.EventHandler(this.labelUser_Click);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(6, 56);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(92, 20);
            this.labelPass.TabIndex = 1;
            this.labelPass.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registro de Usuarios";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnRefrescar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Location = new System.Drawing.Point(275, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 58);
            this.panel1.TabIndex = 183;
            // 
            // gbPrivilegios
            // 
            this.gbPrivilegios.Controls.Add(this.label4);
            this.gbPrivilegios.Controls.Add(this.txtDesc);
            this.gbPrivilegios.Controls.Add(this.dataGridView1);
            this.gbPrivilegios.Controls.Add(this.GridPrivilegios);
            this.gbPrivilegios.Controls.Add(this.rdNuevo);
            this.gbPrivilegios.Controls.Add(this.label1);
            this.gbPrivilegios.Controls.Add(this.txtRol);
            this.gbPrivilegios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPrivilegios.Location = new System.Drawing.Point(399, 105);
            this.gbPrivilegios.Name = "gbPrivilegios";
            this.gbPrivilegios.Size = new System.Drawing.Size(535, 342);
            this.gbPrivilegios.TabIndex = 184;
            this.gbPrivilegios.TabStop = false;
            this.gbPrivilegios.Text = "Asignando Privilegios";
            this.gbPrivilegios.Enter += new System.EventHandler(this.gbPrivilegios_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 189;
            this.label4.Text = "Descripcion";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(338, 35);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(168, 21);
            this.txtDesc.TabIndex = 188;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(556, 356);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(10, 10);
            this.dataGridView1.TabIndex = 187;
            this.dataGridView1.Visible = false;
            // 
            // GridPrivilegios
            // 
            this.GridPrivilegios.AllowUserToOrderColumns = true;
            this.GridPrivilegios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPrivilegios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nom,
            this.NombreForm,
            this.Insertar,
            this.Modificar,
            this.Eliminar});
            this.GridPrivilegios.Location = new System.Drawing.Point(0, 95);
            this.GridPrivilegios.Name = "GridPrivilegios";
            this.GridPrivilegios.Size = new System.Drawing.Size(529, 218);
            this.GridPrivilegios.TabIndex = 185;
            this.GridPrivilegios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPrivilegios_CellContentClick);
            this.GridPrivilegios.ColumnToolTipTextChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.GridPrivilegios_ColumnToolTipTextChanged);
            this.GridPrivilegios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridPrivilegios_KeyPress);
            this.GridPrivilegios.MouseCaptureChanged += new System.EventHandler(this.gbPrivilegios_Enter);
            // 
            // rdNuevo
            // 
            this.rdNuevo.AutoSize = true;
            this.rdNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNuevo.Location = new System.Drawing.Point(31, 37);
            this.rdNuevo.Name = "rdNuevo";
            this.rdNuevo.Size = new System.Drawing.Size(91, 19);
            this.rdNuevo.TabIndex = 186;
            this.rdNuevo.TabStop = true;
            this.rdNuevo.Text = "Nuevo Rol";
            this.rdNuevo.UseVisualStyleBackColor = true;
            this.rdNuevo.CheckedChanged += new System.EventHandler(this.rdNuevo_CheckedChanged);
            // 
            // cmbRolPre
            // 
            this.cmbRolPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRolPre.FormattingEnabled = true;
            this.cmbRolPre.Location = new System.Drawing.Point(165, 42);
            this.cmbRolPre.Name = "cmbRolPre";
            this.cmbRolPre.Size = new System.Drawing.Size(191, 24);
            this.cmbRolPre.TabIndex = 184;
            this.cmbRolPre.SelectedIndexChanged += new System.EventHandler(this.cmbRolPre_SelectedIndexChanged);
            this.cmbRolPre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbRolPre_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // rdPre
            // 
            this.rdPre.AutoSize = true;
            this.rdPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPre.Location = new System.Drawing.Point(6, 42);
            this.rdPre.Name = "rdPre";
            this.rdPre.Size = new System.Drawing.Size(154, 19);
            this.rdPre.TabIndex = 185;
            this.rdPre.TabStop = true;
            this.rdPre.Text = "Rol Predeterminado";
            this.rdPre.UseVisualStyleBackColor = true;
            this.rdPre.CheckedChanged += new System.EventHandler(this.rdPre_CheckedChanged);
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(150, 36);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(168, 21);
            this.txtRol.TabIndex = 1;
            this.txtRol.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtGuarda2
            // 
            this.txtGuarda2.Location = new System.Drawing.Point(24, 271);
            this.txtGuarda2.Name = "txtGuarda2";
            this.txtGuarda2.Size = new System.Drawing.Size(343, 20);
            this.txtGuarda2.TabIndex = 185;
            this.txtGuarda2.Visible = false;
            this.txtGuarda2.TextChanged += new System.EventHandler(this.txtGuarda2_TextChanged);
            // 
            // txtXX
            // 
            this.txtXX.Location = new System.Drawing.Point(1115, 36);
            this.txtXX.Name = "txtXX";
            this.txtXX.Size = new System.Drawing.Size(10, 20);
            this.txtXX.TabIndex = 187;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdPre);
            this.groupBox1.Controls.Add(this.cmbRolPre);
            this.groupBox1.Location = new System.Drawing.Point(16, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 150);
            this.groupBox1.TabIndex = 190;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(393, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(48, 42);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(231, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(48, 42);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.UseVisualStyleBackColor = true;
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
            this.btnEliminar.Tag = "Tfacultad";
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(830, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 191;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // nom
            // 
            this.nom.HeaderText = "Nombre Formulario";
            this.nom.Name = "nom";
            this.nom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NombreForm
            // 
            this.NombreForm.HeaderText = "Privilegio";
            this.NombreForm.Name = "NombreForm";
            this.NombreForm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NombreForm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Insertar
            // 
            this.Insertar.HeaderText = "Insertar";
            this.Insertar.Name = "Insertar";
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            // 
            // frmcontrolUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 489);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtXX);
            this.Controls.Add(this.txtGuarda2);
            this.Controls.Add(this.gbPrivilegios);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxDatosUsuario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmcontrolUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONTROL USUARIOS";
            this.Load += new System.EventHandler(this.frmControlUsuarios_Load);
            this.groupBoxDatosUsuario.ResumeLayout(false);
            this.groupBoxDatosUsuario.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbPrivilegios.ResumeLayout(false);
            this.gbPrivilegios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrivilegios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBoxDatosUsuario;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPersona;
        public System.Windows.Forms.ComboBox cbMuestra;
        private System.Windows.Forms.TextBox txtRectificaPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGuarda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.GroupBox gbPrivilegios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.RadioButton rdNuevo;
        private System.Windows.Forms.RadioButton rdPre;
        public System.Windows.Forms.ComboBox cmbRolPre;
        private System.Windows.Forms.DataGridView GridPrivilegios;
        private System.Windows.Forms.TextBox txtGuarda2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtXX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NombreForm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Insertar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Modificar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        

    }
}