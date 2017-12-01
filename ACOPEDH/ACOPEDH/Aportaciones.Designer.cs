namespace ACOPEDH
{
    partial class Aportaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aportaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.dgvAportaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bttRealizarAportación = new System.Windows.Forms.Button();
            this.txtCódigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(813, 4);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(21, 21);
            this.bttCer.TabIndex = 84;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(4, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 83;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(838, 30);
            this.BarraTítulo.TabIndex = 82;
            this.BarraTítulo.Text = "         ACOPEDH - Aportaciones";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvAportaciones
            // 
            this.dgvAportaciones.AllowUserToAddRows = false;
            this.dgvAportaciones.AllowUserToDeleteRows = false;
            this.dgvAportaciones.AllowUserToOrderColumns = true;
            this.dgvAportaciones.AllowUserToResizeRows = false;
            this.dgvAportaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAportaciones.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAportaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAportaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAportaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAportaciones.Location = new System.Drawing.Point(378, 128);
            this.dgvAportaciones.Name = "dgvAportaciones";
            this.dgvAportaciones.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Linotte-Light", 10F);
            this.dgvAportaciones.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAportaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAportaciones.Size = new System.Drawing.Size(407, 351);
            this.dgvAportaciones.TabIndex = 85;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtSuma);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Linotte-Light", 9F);
            this.groupBox1.Location = new System.Drawing.Point(34, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 78);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información";
            // 
            // txtSuma
            // 
            this.txtSuma.Font = new System.Drawing.Font("Linotte-Bold", 10F);
            this.txtSuma.Location = new System.Drawing.Point(129, 27);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.ReadOnly = true;
            this.txtSuma.Size = new System.Drawing.Size(105, 23);
            this.txtSuma.TabIndex = 77;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Linotte-Bold", 10F);
            this.label8.Location = new System.Drawing.Point(11, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 34);
            this.label8.TabIndex = 74;
            this.label8.Text = "Suma de \r\nAportaciones:";
            // 
            // bttRealizarAportación
            // 
            this.bttRealizarAportación.Location = new System.Drawing.Point(111, 219);
            this.bttRealizarAportación.Name = "bttRealizarAportación";
            this.bttRealizarAportación.Size = new System.Drawing.Size(112, 50);
            this.bttRealizarAportación.TabIndex = 87;
            this.bttRealizarAportación.Text = "Realizar Aportación";
            this.bttRealizarAportación.UseVisualStyleBackColor = true;
            this.bttRealizarAportación.Click += new System.EventHandler(this.bttRealizarAportación_Click);
            // 
            // txtCódigo
            // 
            this.txtCódigo.Location = new System.Drawing.Point(664, 67);
            this.txtCódigo.Name = "txtCódigo";
            this.txtCódigo.ReadOnly = true;
            this.txtCódigo.Size = new System.Drawing.Size(135, 27);
            this.txtCódigo.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(515, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 19);
            this.label3.TabIndex = 92;
            this.label3.Text = "Código Asociación:";
            // 
            // txtAsociado
            // 
            this.txtAsociado.Location = new System.Drawing.Point(120, 70);
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.ReadOnly = true;
            this.txtAsociado.Size = new System.Drawing.Size(382, 27);
            this.txtAsociado.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(30, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 38);
            this.label1.TabIndex = 88;
            this.label1.Text = "Persona\r\nAsociada:";
            // 
            // Aportaciones
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 508);
            this.Controls.Add(this.txtCódigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttRealizarAportación);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAportaciones);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Aportaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aportaciones";
            this.Load += new System.EventHandler(this.Aportaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.DataGridView dgvAportaciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSuma;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bttRealizarAportación;
        private System.Windows.Forms.TextBox txtCódigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.Label label1;
    }
}