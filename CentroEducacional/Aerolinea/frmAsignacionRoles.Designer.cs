namespace Aerolinea
{
    partial class frmAsignacionRoles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacionRoles));
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardarUsuario = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rbEliminar = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.rbModificar = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.rbGuardar = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMuestraUser = new System.Windows.Forms.ComboBox();
            this.cbBuscaUsuario = new System.Windows.Forms.ComboBox();
            this.lblEliminar = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtPrueba = new System.Windows.Forms.TextBox();
            this.cbPrivilegios = new System.Windows.Forms.ComboBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(256, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Asignacion de Privilegios";
            // 
            // btnGuardarUsuario
            // 
            this.btnGuardarUsuario.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarUsuario.Image")));
            this.btnGuardarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarUsuario.Location = new System.Drawing.Point(270, 62);
            this.btnGuardarUsuario.Name = "btnGuardarUsuario";
            this.btnGuardarUsuario.Size = new System.Drawing.Size(134, 50);
            this.btnGuardarUsuario.TabIndex = 24;
            this.btnGuardarUsuario.Text = "Asingar Predeterminado";
            this.btnGuardarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarUsuario.UseVisualStyleBackColor = true;
            this.btnGuardarUsuario.Click += new System.EventHandler(this.btnGuardarUsuario_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 215);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asignando privilegios";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Formulario AsignacionRol",
            "Formulario AsignParq",
            "Formulario AsigOrd",
            "Formulario Bitacora",
            "Formulario Carrera",
            "Formulario Certificacion",
            "Formulario CobroDoc",
            "Formulario CobroInscrip",
            "Formulario CobroParqueo",
            "Formulario CobroReasig",
            "Formulario CreacionPaquete",
            "Formulario CreacionPensum",
            "Formulario Cursos",
            "Formulario Empleado",
            "Formulario Facultad",
            "Formulario Familia",
            "Formulario Horario",
            "Formulario Jornada",
            "Formulario Laboratorios",
            "Formulario Mensualidad",
            "Formulario Notas",
            "Formulario PagoEmpleado",
            "Formulario PagosPendientes",
            "Formulario Parqueos",
            "Formulario Parqueos",
            "Formulario Pensum",
            "Formulario Persona",
            "Formulario Puestos",
            "Formulario Reasignacion",
            "Formulario Reinscripcion",
            "Formulario ReporteCatalogos",
            "Formulario Rol",
            "Formulario Rol",
            "Formulario Salones",
            "Formulario Seccion",
            "Formulario Sedes",
            "Formulario Solvencias",
            "Formulario Talonarios",
            "Formulario TipoPago",
            "Formulario TipoServicio",
            "Formulario Usuario",
            "Formulario Zona"});
            this.checkedListBox1.Location = new System.Drawing.Point(16, 20);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(219, 180);
            this.checkedListBox1.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(32, 126);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(48, 42);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(288, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 211);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asignando permisos";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.rbEliminar);
            this.groupBox4.Location = new System.Drawing.Point(103, 110);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 72);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(7, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 42);
            this.button2.TabIndex = 15;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // rbEliminar
            // 
            this.rbEliminar.AutoSize = true;
            this.rbEliminar.Location = new System.Drawing.Point(71, 29);
            this.rbEliminar.Name = "rbEliminar";
            this.rbEliminar.Size = new System.Drawing.Size(71, 19);
            this.rbEliminar.TabIndex = 14;
            this.rbEliminar.TabStop = true;
            this.rbEliminar.Text = "Eliminar";
            this.rbEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnEditar);
            this.groupBox7.Controls.Add(this.rbModificar);
            this.groupBox7.Location = new System.Drawing.Point(170, 20);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(148, 72);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(6, 20);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(48, 42);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // rbModificar
            // 
            this.rbModificar.AutoSize = true;
            this.rbModificar.Location = new System.Drawing.Point(72, 32);
            this.rbModificar.Name = "rbModificar";
            this.rbModificar.Size = new System.Drawing.Size(76, 19);
            this.rbModificar.TabIndex = 13;
            this.rbModificar.TabStop = true;
            this.rbModificar.Text = "Modificar";
            this.rbModificar.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnGuardar);
            this.groupBox6.Controls.Add(this.rbGuardar);
            this.groupBox6.Location = new System.Drawing.Point(16, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(148, 72);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(6, 20);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(48, 45);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // rbGuardar
            // 
            this.rbGuardar.AutoSize = true;
            this.rbGuardar.Location = new System.Drawing.Point(72, 33);
            this.rbGuardar.Name = "rbGuardar";
            this.rbGuardar.Size = new System.Drawing.Size(70, 19);
            this.rbGuardar.TabIndex = 12;
            this.rbGuardar.TabStop = true;
            this.rbGuardar.Text = "Guardar";
            this.rbGuardar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMuestraUser);
            this.groupBox1.Controls.Add(this.cbBuscaUsuario);
            this.groupBox1.Controls.Add(this.lblEliminar);
            this.groupBox1.Controls.Add(this.lblBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 131);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionando usuario";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbMuestraUser
            // 
            this.cbMuestraUser.FormattingEnabled = true;
            this.cbMuestraUser.Location = new System.Drawing.Point(154, 93);
            this.cbMuestraUser.Name = "cbMuestraUser";
            this.cbMuestraUser.Size = new System.Drawing.Size(139, 23);
            this.cbMuestraUser.TabIndex = 6;
            this.cbMuestraUser.SelectedIndexChanged += new System.EventHandler(this.cbMuestraUser_SelectedIndexChanged);
            // 
            // cbBuscaUsuario
            // 
            this.cbBuscaUsuario.FormattingEnabled = true;
            this.cbBuscaUsuario.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbBuscaUsuario.Location = new System.Drawing.Point(154, 55);
            this.cbBuscaUsuario.Name = "cbBuscaUsuario";
            this.cbBuscaUsuario.Size = new System.Drawing.Size(139, 23);
            this.cbBuscaUsuario.TabIndex = 5;
            this.cbBuscaUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbeliminarUsuario_SelectedIndexChanged);
            // 
            // lblEliminar
            // 
            this.lblEliminar.AutoSize = true;
            this.lblEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEliminar.Location = new System.Drawing.Point(6, 96);
            this.lblEliminar.Name = "lblEliminar";
            this.lblEliminar.Size = new System.Drawing.Size(151, 20);
            this.lblEliminar.TabIndex = 4;
            this.lblEliminar.Text = "Seleccionar Usuario";
            this.lblEliminar.Click += new System.EventHandler(this.lblEliminar_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(6, 55);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(121, 20);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar por letra";
            // 
            // txtPrueba
            // 
            this.txtPrueba.Location = new System.Drawing.Point(121, 91);
            this.txtPrueba.Name = "txtPrueba";
            this.txtPrueba.Size = new System.Drawing.Size(137, 20);
            this.txtPrueba.TabIndex = 7;
            this.txtPrueba.Visible = false;
            // 
            // cbPrivilegios
            // 
            this.cbPrivilegios.FormattingEnabled = true;
            this.cbPrivilegios.Location = new System.Drawing.Point(467, 99);
            this.cbPrivilegios.Name = "cbPrivilegios";
            this.cbPrivilegios.Size = new System.Drawing.Size(139, 21);
            this.cbPrivilegios.TabIndex = 32;
            this.cbPrivilegios.Visible = false;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(469, 73);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(137, 20);
            this.txt3.TabIndex = 33;
            this.txt3.Visible = false;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(469, 47);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(137, 20);
            this.txt2.TabIndex = 34;
            this.txt2.Visible = false;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(469, 21);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(137, 20);
            this.txt1.TabIndex = 35;
            this.txt1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(440, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(121, 131);
            this.dataGridView1.TabIndex = 36;
            // 
            // frmAsignacionRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 530);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txtPrueba);
            this.Controls.Add(this.cbPrivilegios);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGuardarUsuario);
            this.Controls.Add(this.label2);
            this.Name = "frmAsignacionRoles";
            this.Text = "frmAsignacionRoles";
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.RadioButton rbEliminar;
        private System.Windows.Forms.RadioButton rbModificar;
        private System.Windows.Forms.RadioButton rbGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrueba;
        private System.Windows.Forms.ComboBox cbMuestraUser;
        private System.Windows.Forms.ComboBox cbBuscaUsuario;
        private System.Windows.Forms.Label lblEliminar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbPrivilegios;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}