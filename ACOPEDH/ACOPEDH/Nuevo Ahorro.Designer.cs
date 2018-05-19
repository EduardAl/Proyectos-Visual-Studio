namespace ACOPEDH
{
    partial class Nuevo_Ahorro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nuevo_Ahorro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.labBuscar = new System.Windows.Forms.Label();
            this.dgvAsociado = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.nmAbono = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtOcupación = new System.Windows.Forms.TextBox();
            this.TxtInterés = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CBTipoAhorro = new System.Windows.Forms.ComboBox();
            this.TxtDUIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCódigoA = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtAsociadoP = new System.Windows.Forms.TextBox();
            this.bttAceptar = new System.Windows.Forms.Button();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.bttMin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsociado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmAbono)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.pictureBox3.BackgroundImage = global::ACOPEDH.Properties.Resources.photo_sinlietras;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(6, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F);
            this.BarraTítulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(2, 2);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(979, 30);
            this.BarraTítulo.TabIndex = 62;
            this.BarraTítulo.Text = "         ACOPEDH - Nueva Cuenta de Ahorros";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarraTítulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BarraTítulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.BarraTítulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // labBuscar
            // 
            this.labBuscar.AutoSize = true;
            this.labBuscar.BackColor = System.Drawing.Color.Transparent;
            this.labBuscar.Location = new System.Drawing.Point(24, 123);
            this.labBuscar.Name = "labBuscar";
            this.labBuscar.Size = new System.Drawing.Size(83, 19);
            this.labBuscar.TabIndex = 65;
            this.labBuscar.Text = "Búsqueda:";
            // 
            // dgvAsociado
            // 
            this.dgvAsociado.AllowUserToAddRows = false;
            this.dgvAsociado.AllowUserToDeleteRows = false;
            this.dgvAsociado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvAsociado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsociado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsociado.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAsociado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsociado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsociado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsociado.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAsociado.Location = new System.Drawing.Point(458, 51);
            this.dgvAsociado.Name = "dgvAsociado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsociado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAsociado.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Linotte-Light", 10F);
            this.dgvAsociado.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAsociado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsociado.Size = new System.Drawing.Size(452, 195);
            this.dgvAsociado.TabIndex = 1;
            this.dgvAsociado.CurrentCellChanged += new System.EventHandler(this.dgvAsociado_CurrentCellChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.label7.Location = new System.Drawing.Point(317, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 19);
            this.label7.TabIndex = 98;
            this.label7.Text = "Abono Inicial:";
            // 
            // nmAbono
            // 
            this.nmAbono.DecimalPlaces = 2;
            this.nmAbono.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.nmAbono.Location = new System.Drawing.Point(429, 156);
            this.nmAbono.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmAbono.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmAbono.Name = "nmAbono";
            this.nmAbono.Size = new System.Drawing.Size(93, 27);
            this.nmAbono.TabIndex = 3;
            this.nmAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmAbono.ThousandsSeparator = true;
            this.nmAbono.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 117);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(289, 31);
            this.textBox3.TabIndex = 0;
            this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtBúsqueda_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtOcupación);
            this.groupBox1.Controls.Add(this.TxtInterés);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CBTipoAhorro);
            this.groupBox1.Controls.Add(this.TxtDUIP);
            this.groupBox1.Controls.Add(this.nmAbono);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtCódigoA);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.TxtAsociadoP);
            this.groupBox1.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(50, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 207);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del Ahorro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 19);
            this.label8.TabIndex = 100;
            this.label8.Text = "Ocupación: ";
            // 
            // TxtOcupación
            // 
            this.TxtOcupación.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOcupación.Location = new System.Drawing.Point(120, 102);
            this.TxtOcupación.Multiline = true;
            this.TxtOcupación.Name = "TxtOcupación";
            this.TxtOcupación.ReadOnly = true;
            this.TxtOcupación.Size = new System.Drawing.Size(180, 29);
            this.TxtOcupación.TabIndex = 3;
            this.TxtOcupación.TabStop = false;
            // 
            // TxtInterés
            // 
            this.TxtInterés.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInterés.Location = new System.Drawing.Point(772, 102);
            this.TxtInterés.Multiline = true;
            this.TxtInterés.Name = "TxtInterés";
            this.TxtInterés.ReadOnly = true;
            this.TxtInterés.Size = new System.Drawing.Size(56, 29);
            this.TxtInterés.TabIndex = 15;
            this.TxtInterés.TabStop = false;
            this.TxtInterés.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(651, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 19);
            this.label10.TabIndex = 14;
            this.label10.Text = "Tasa de Interés: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(322, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tipo de Ahorro: ";
            // 
            // CBTipoAhorro
            // 
            this.CBTipoAhorro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipoAhorro.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTipoAhorro.FormattingEnabled = true;
            this.CBTipoAhorro.Location = new System.Drawing.Point(468, 102);
            this.CBTipoAhorro.Name = "CBTipoAhorro";
            this.CBTipoAhorro.Size = new System.Drawing.Size(156, 27);
            this.CBTipoAhorro.TabIndex = 2;
            this.CBTipoAhorro.SelectedIndexChanged += new System.EventHandler(this.CBTipoAhorro_SelectedIndexChanged);
            // 
            // TxtDUIP
            // 
            this.TxtDUIP.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDUIP.Location = new System.Drawing.Point(682, 40);
            this.TxtDUIP.Multiline = true;
            this.TxtDUIP.Name = "TxtDUIP";
            this.TxtDUIP.ReadOnly = true;
            this.TxtDUIP.Size = new System.Drawing.Size(146, 29);
            this.TxtDUIP.TabIndex = 2;
            this.TxtDUIP.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(639, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "DUI: ";
            // 
            // TxtCódigoA
            // 
            this.TxtCódigoA.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCódigoA.Location = new System.Drawing.Point(488, 40);
            this.TxtCódigoA.Multiline = true;
            this.TxtCódigoA.Name = "TxtCódigoA";
            this.TxtCódigoA.ReadOnly = true;
            this.TxtCódigoA.Size = new System.Drawing.Size(136, 29);
            this.TxtCódigoA.TabIndex = 1;
            this.TxtCódigoA.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(400, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 38);
            this.label14.TabIndex = 10;
            this.label14.Text = "Código de \r\nAsociación:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 38);
            this.label15.TabIndex = 10;
            this.label15.Text = "Persona\r\nAsociada:";
            // 
            // TxtAsociadoP
            // 
            this.TxtAsociadoP.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAsociadoP.Location = new System.Drawing.Point(98, 40);
            this.TxtAsociadoP.Multiline = true;
            this.TxtAsociadoP.Name = "TxtAsociadoP";
            this.TxtAsociadoP.ReadOnly = true;
            this.TxtAsociadoP.Size = new System.Drawing.Size(289, 31);
            this.TxtAsociadoP.TabIndex = 0;
            this.TxtAsociadoP.TabStop = false;
            // 
            // bttAceptar
            // 
            this.bttAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttAceptar.Location = new System.Drawing.Point(397, 515);
            this.bttAceptar.Name = "bttAceptar";
            this.bttAceptar.Size = new System.Drawing.Size(143, 57);
            this.bttAceptar.TabIndex = 4;
            this.bttAceptar.Text = "ACEPTAR";
            this.bttAceptar.UseVisualStyleBackColor = true;
            this.bttAceptar.Click += new System.EventHandler(this.bttAceptar_Click);
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Location = new System.Drawing.Point(946, 2);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 30);
            this.bttCer.TabIndex = 129;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            this.bttCer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttCer_MouseDown);
            this.bttCer.MouseLeave += new System.EventHandler(this.bttCer_MouseLeave);
            this.bttCer.MouseHover += new System.EventHandler(this.bttCer_MouseHover);
            // 
            // bttMin
            // 
            this.bttMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.bttMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttMin.BackgroundImage")));
            this.bttMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttMin.Location = new System.Drawing.Point(915, 2);
            this.bttMin.Name = "bttMin";
            this.bttMin.Size = new System.Drawing.Size(30, 30);
            this.bttMin.TabIndex = 130;
            this.bttMin.TabStop = false;
            this.bttMin.Click += new System.EventHandler(this.bttMin_Click);
            this.bttMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttMin_MouseDown);
            this.bttMin.MouseLeave += new System.EventHandler(this.bttMin_MouseLeave);
            this.bttMin.MouseHover += new System.EventHandler(this.bttMin_MouseHover);
            // 
            // Nuevo_Ahorro
            // 
            this.AcceptButton = this.bttAceptar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 618);
            this.Controls.Add(this.bttMin);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.bttAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dgvAsociado);
            this.Controls.Add(this.labBuscar);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(982, 618);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(982, 618);
            this.Name = "Nuevo_Ahorro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACOPEDH - NUEVO AHORRO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Nuevo_Ahorro_FormClosing);
            this.Load += new System.EventHandler(this.Nuevo_Ahorro_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Nuevo_Ahorro_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsociado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmAbono)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.Label labBuscar;
        private System.Windows.Forms.DataGridView dgvAsociado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmAbono;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtInterés;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CBTipoAhorro;
        private System.Windows.Forms.TextBox TxtDUIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCódigoA;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtAsociadoP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bttAceptar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtOcupación;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox bttMin;
    }
}