namespace Conejo
{
    partial class Asociado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Asociado));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.bttTelModificar = new System.Windows.Forms.Button();
            this.bttDesasociar = new System.Windows.Forms.Button();
            this.lbTeléfonos = new System.Windows.Forms.ListBox();
            this.bttModificar = new System.Windows.Forms.Button();
            this.bttEliminar = new System.Windows.Forms.Button();
            this.bttAceptar = new System.Windows.Forms.Button();
            this.txtTeléfono = new System.Windows.Forms.TextBox();
            this.bttTelefono = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTipoAsociación = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLugarTrabajo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateBirth = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDUI = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNIT = new System.Windows.Forms.TextBox();
            this.dateDesasociación = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateAsociación = new System.Windows.Forms.DateTimePicker();
            this.labelDesasociacion = new System.Windows.Forms.Label();
            this.txtCódigoAsociado = new System.Windows.Forms.TextBox();
            this.txtDirección = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(43, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 32);
            this.label12.TabIndex = 57;
            this.label12.Text = "Lugar de\r\nTrabajo:";
            // 
            // bttTelModificar
            // 
            this.bttTelModificar.Enabled = false;
            this.bttTelModificar.Font = new System.Drawing.Font("Linotte-Regular", 9F, System.Drawing.FontStyle.Bold);
            this.bttTelModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttTelModificar.Location = new System.Drawing.Point(389, 379);
            this.bttTelModificar.Name = "bttTelModificar";
            this.bttTelModificar.Size = new System.Drawing.Size(75, 25);
            this.bttTelModificar.TabIndex = 67;
            this.bttTelModificar.TabStop = false;
            this.bttTelModificar.Text = "Modificar";
            this.bttTelModificar.UseVisualStyleBackColor = true;
            this.bttTelModificar.Click += new System.EventHandler(this.bttTelModificar_Click);
            // 
            // bttDesasociar
            // 
            this.bttDesasociar.Font = new System.Drawing.Font("Linotte-Regular", 11.25F, System.Drawing.FontStyle.Bold);
            this.bttDesasociar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttDesasociar.Location = new System.Drawing.Point(548, 451);
            this.bttDesasociar.Name = "bttDesasociar";
            this.bttDesasociar.Size = new System.Drawing.Size(187, 49);
            this.bttDesasociar.TabIndex = 58;
            this.bttDesasociar.TabStop = false;
            this.bttDesasociar.Text = "Desasociar";
            this.bttDesasociar.UseVisualStyleBackColor = true;
            this.bttDesasociar.Click += new System.EventHandler(this.bttDesasociar_Click_1);
            // 
            // lbTeléfonos
            // 
            this.lbTeléfonos.BackColor = System.Drawing.Color.White;
            this.lbTeléfonos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTeléfonos.FormattingEnabled = true;
            this.lbTeléfonos.ItemHeight = 16;
            this.lbTeléfonos.Items.AddRange(new object[] {
            "Añadir"});
            this.lbTeléfonos.Location = new System.Drawing.Point(136, 331);
            this.lbTeléfonos.Name = "lbTeléfonos";
            this.lbTeléfonos.Size = new System.Drawing.Size(120, 112);
            this.lbTeléfonos.TabIndex = 66;
            this.lbTeléfonos.SelectedIndexChanged += new System.EventHandler(this.lbTeléfonos_SelectedIndexChanged);
            // 
            // bttModificar
            // 
            this.bttModificar.Font = new System.Drawing.Font("Linotte-Regular", 11.25F, System.Drawing.FontStyle.Bold);
            this.bttModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttModificar.Location = new System.Drawing.Point(548, 129);
            this.bttModificar.Name = "bttModificar";
            this.bttModificar.Size = new System.Drawing.Size(187, 49);
            this.bttModificar.TabIndex = 38;
            this.bttModificar.Text = "Guardar y Salir";
            this.bttModificar.UseVisualStyleBackColor = true;
            this.bttModificar.Click += new System.EventHandler(this.bttModificar_Click_1);
            // 
            // bttEliminar
            // 
            this.bttEliminar.Enabled = false;
            this.bttEliminar.Font = new System.Drawing.Font("Linotte-Regular", 9F, System.Drawing.FontStyle.Bold);
            this.bttEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttEliminar.Location = new System.Drawing.Point(346, 405);
            this.bttEliminar.Name = "bttEliminar";
            this.bttEliminar.Size = new System.Drawing.Size(75, 25);
            this.bttEliminar.TabIndex = 65;
            this.bttEliminar.TabStop = false;
            this.bttEliminar.Text = "Eliminar";
            this.bttEliminar.UseVisualStyleBackColor = true;
            this.bttEliminar.Click += new System.EventHandler(this.bttEliminar_Click);
            // 
            // bttAceptar
            // 
            this.bttAceptar.Font = new System.Drawing.Font("Linotte-Regular", 11.25F, System.Drawing.FontStyle.Bold);
            this.bttAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttAceptar.Location = new System.Drawing.Point(548, 192);
            this.bttAceptar.Name = "bttAceptar";
            this.bttAceptar.Size = new System.Drawing.Size(187, 49);
            this.bttAceptar.TabIndex = 39;
            this.bttAceptar.Text = "Salir";
            this.bttAceptar.UseVisualStyleBackColor = true;
            this.bttAceptar.Click += new System.EventHandler(this.bttAceptar_Click_1);
            // 
            // txtTeléfono
            // 
            this.txtTeléfono.BackColor = System.Drawing.Color.White;
            this.txtTeléfono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTeléfono.Location = new System.Drawing.Point(338, 353);
            this.txtTeléfono.MaxLength = 9;
            this.txtTeléfono.Multiline = true;
            this.txtTeléfono.Name = "txtTeléfono";
            this.txtTeléfono.Size = new System.Drawing.Size(100, 23);
            this.txtTeléfono.TabIndex = 64;
            // 
            // bttTelefono
            // 
            this.bttTelefono.Font = new System.Drawing.Font("Linotte-Regular", 9F, System.Drawing.FontStyle.Bold);
            this.bttTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttTelefono.Location = new System.Drawing.Point(308, 379);
            this.bttTelefono.Name = "bttTelefono";
            this.bttTelefono.Size = new System.Drawing.Size(75, 25);
            this.bttTelefono.TabIndex = 63;
            this.bttTelefono.TabStop = false;
            this.bttTelefono.Text = "Ingresar";
            this.bttTelefono.UseVisualStyleBackColor = true;
            this.bttTelefono.Click += new System.EventHandler(this.bttTelefono_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(43, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Nombres:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(43, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 62;
            this.label8.Text = "Teléfonos:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Location = new System.Drawing.Point(136, 113);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 23);
            this.txtNombre.TabIndex = 41;
            // 
            // txtTipoAsociación
            // 
            this.txtTipoAsociación.BackColor = System.Drawing.Color.White;
            this.txtTipoAsociación.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTipoAsociación.Enabled = false;
            this.txtTipoAsociación.Location = new System.Drawing.Point(136, 450);
            this.txtTipoAsociación.Multiline = true;
            this.txtTipoAsociación.Name = "txtTipoAsociación";
            this.txtTipoAsociación.Size = new System.Drawing.Size(119, 23);
            this.txtTipoAsociación.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(43, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Apellidos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(43, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 61;
            this.label3.Text = "Tipo de\r\nAsociación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(43, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Dirección:";
            // 
            // cbLugarTrabajo
            // 
            this.cbLugarTrabajo.BackColor = System.Drawing.Color.White;
            this.cbLugarTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLugarTrabajo.FormattingEnabled = true;
            this.cbLugarTrabajo.Location = new System.Drawing.Point(136, 304);
            this.cbLugarTrabajo.Name = "cbLugarTrabajo";
            this.cbLugarTrabajo.Size = new System.Drawing.Size(229, 24);
            this.cbLugarTrabajo.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(264, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "NIT:";
            // 
            // dateBirth
            // 
            this.dateBirth.Location = new System.Drawing.Point(136, 183);
            this.dateBirth.Name = "dateBirth";
            this.dateBirth.Size = new System.Drawing.Size(229, 23);
            this.dateBirth.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(43, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "DUI:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(43, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 32);
            this.label7.TabIndex = 60;
            this.label7.Text = "Fecha de\r\nNacimiento:";
            // 
            // txtDUI
            // 
            this.txtDUI.BackColor = System.Drawing.Color.White;
            this.txtDUI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDUI.Location = new System.Drawing.Point(136, 216);
            this.txtDUI.MaxLength = 10;
            this.txtDUI.Multiline = true;
            this.txtDUI.Name = "txtDUI";
            this.txtDUI.Size = new System.Drawing.Size(119, 23);
            this.txtDUI.TabIndex = 44;
            // 
            // txtApellidos
            // 
            this.txtApellidos.BackColor = System.Drawing.Color.White;
            this.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellidos.Location = new System.Drawing.Point(136, 145);
            this.txtApellidos.MaxLength = 50;
            this.txtApellidos.Multiline = true;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(229, 23);
            this.txtApellidos.TabIndex = 42;
            // 
            // txtNIT
            // 
            this.txtNIT.BackColor = System.Drawing.Color.White;
            this.txtNIT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNIT.Location = new System.Drawing.Point(308, 216);
            this.txtNIT.MaxLength = 17;
            this.txtNIT.Multiline = true;
            this.txtNIT.Name = "txtNIT";
            this.txtNIT.Size = new System.Drawing.Size(176, 23);
            this.txtNIT.TabIndex = 47;
            // 
            // dateDesasociación
            // 
            this.dateDesasociación.Enabled = false;
            this.dateDesasociación.Location = new System.Drawing.Point(136, 534);
            this.dateDesasociación.Name = "dateDesasociación";
            this.dateDesasociación.Size = new System.Drawing.Size(229, 23);
            this.dateDesasociación.TabIndex = 53;
            this.dateDesasociación.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(43, 479);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 32);
            this.label10.TabIndex = 54;
            this.label10.Text = "Fecha de\r\nAsociación:";
            // 
            // dateAsociación
            // 
            this.dateAsociación.Enabled = false;
            this.dateAsociación.Location = new System.Drawing.Point(136, 487);
            this.dateAsociación.Name = "dateAsociación";
            this.dateAsociación.Size = new System.Drawing.Size(229, 23);
            this.dateAsociación.TabIndex = 52;
            // 
            // labelDesasociacion
            // 
            this.labelDesasociacion.AutoSize = true;
            this.labelDesasociacion.BackColor = System.Drawing.Color.Transparent;
            this.labelDesasociacion.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.labelDesasociacion.ForeColor = System.Drawing.Color.Navy;
            this.labelDesasociacion.Location = new System.Drawing.Point(43, 526);
            this.labelDesasociacion.Name = "labelDesasociacion";
            this.labelDesasociacion.Size = new System.Drawing.Size(92, 32);
            this.labelDesasociacion.TabIndex = 56;
            this.labelDesasociacion.Text = "Fecha de\r\nDesasociación:";
            this.labelDesasociacion.Visible = false;
            // 
            // txtCódigoAsociado
            // 
            this.txtCódigoAsociado.BackColor = System.Drawing.Color.White;
            this.txtCódigoAsociado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCódigoAsociado.Enabled = false;
            this.txtCódigoAsociado.Location = new System.Drawing.Point(136, 580);
            this.txtCódigoAsociado.Multiline = true;
            this.txtCódigoAsociado.Name = "txtCódigoAsociado";
            this.txtCódigoAsociado.Size = new System.Drawing.Size(86, 23);
            this.txtCódigoAsociado.TabIndex = 55;
            // 
            // txtDirección
            // 
            this.txtDirección.BackColor = System.Drawing.Color.White;
            this.txtDirección.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDirección.Location = new System.Drawing.Point(136, 249);
            this.txtDirección.Multiline = true;
            this.txtDirección.Name = "txtDirección";
            this.txtDirección.Size = new System.Drawing.Size(348, 46);
            this.txtDirección.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(43, 574);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 32);
            this.label13.TabIndex = 59;
            this.label13.Text = "Código de\r\nAsociación:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(17)))), ((int)(((byte)(2)))));
            this.label9.Location = new System.Drawing.Point(133, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(513, 38);
            this.label9.TabIndex = 69;
            this.label9.Text = "Asociación Cooperativa De Ahorro, Crédito Y Consumo Del\r\nPersonal De La Procuradu" +
    "ría Para La Defensa De Los Derechos Humanos";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(36, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // Asociado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(783, 651);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bttTelModificar);
            this.Controls.Add(this.bttDesasociar);
            this.Controls.Add(this.lbTeléfonos);
            this.Controls.Add(this.bttModificar);
            this.Controls.Add(this.bttEliminar);
            this.Controls.Add(this.bttAceptar);
            this.Controls.Add(this.txtTeléfono);
            this.Controls.Add(this.bttTelefono);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtTipoAsociación);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbLugarTrabajo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateBirth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDUI);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNIT);
            this.Controls.Add(this.dateDesasociación);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateAsociación);
            this.Controls.Add(this.labelDesasociacion);
            this.Controls.Add(this.txtCódigoAsociado);
            this.Controls.Add(this.txtDirección);
            this.Controls.Add(this.label13);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Light", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Asociado";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bttTelModificar;
        private System.Windows.Forms.Button bttDesasociar;
        private System.Windows.Forms.ListBox lbTeléfonos;
        private System.Windows.Forms.Button bttModificar;
        private System.Windows.Forms.Button bttEliminar;
        private System.Windows.Forms.Button bttAceptar;
        private System.Windows.Forms.TextBox txtTeléfono;
        private System.Windows.Forms.Button bttTelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTipoAsociación;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLugarTrabajo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateBirth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDUI;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNIT;
        private System.Windows.Forms.DateTimePicker dateDesasociación;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateAsociación;
        private System.Windows.Forms.Label labelDesasociacion;
        private System.Windows.Forms.TextBox txtCódigoAsociado;
        private System.Windows.Forms.TextBox txtDirección;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}