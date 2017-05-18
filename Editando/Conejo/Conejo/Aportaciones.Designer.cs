namespace Conejo
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
            this.bttAportar = new System.Windows.Forms.Button();
            this.dgvAportaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtAportaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bttAportar
            // 
            this.bttAportar.Location = new System.Drawing.Point(83, 263);
            this.bttAportar.Name = "bttAportar";
            this.bttAportar.Size = new System.Drawing.Size(187, 30);
            this.bttAportar.TabIndex = 22;
            this.bttAportar.Text = "Realizar aportación Mensual";
            this.bttAportar.UseVisualStyleBackColor = true;
            this.bttAportar.Click += new System.EventHandler(this.bttAportar_Click_1);
            // 
            // dgvAportaciones
            // 
            this.dgvAportaciones.AllowUserToAddRows = false;
            this.dgvAportaciones.AllowUserToDeleteRows = false;
            this.dgvAportaciones.AllowUserToOrderColumns = true;
            this.dgvAportaciones.AllowUserToResizeColumns = false;
            this.dgvAportaciones.AllowUserToResizeRows = false;
            this.dgvAportaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvAportaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAportaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAportaciones.Location = new System.Drawing.Point(386, 112);
            this.dgvAportaciones.Name = "dgvAportaciones";
            this.dgvAportaciones.Size = new System.Drawing.Size(274, 239);
            this.dgvAportaciones.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtApellidos);
            this.groupBox1.Controls.Add(this.txtAportaciones);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNombres);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 149);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // txtApellidos
            // 
            this.txtApellidos.BackColor = System.Drawing.Color.White;
            this.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellidos.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(79, 70);
            this.txtApellidos.Multiline = true;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.ReadOnly = true;
            this.txtApellidos.Size = new System.Drawing.Size(229, 20);
            this.txtApellidos.TabIndex = 24;
            this.txtApellidos.TabStop = false;
            this.txtApellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAportaciones
            // 
            this.txtAportaciones.BackColor = System.Drawing.Color.White;
            this.txtAportaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAportaciones.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAportaciones.Location = new System.Drawing.Point(99, 103);
            this.txtAportaciones.Multiline = true;
            this.txtAportaciones.Name = "txtAportaciones";
            this.txtAportaciones.ReadOnly = true;
            this.txtAportaciones.Size = new System.Drawing.Size(86, 20);
            this.txtAportaciones.TabIndex = 20;
            this.txtAportaciones.TabStop = false;
            this.txtAportaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellidos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Aportaciones:";
            // 
            // txtNombres
            // 
            this.txtNombres.BackColor = System.Drawing.Color.White;
            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombres.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(79, 44);
            this.txtNombres.Multiline = true;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(229, 20);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.TabStop = false;
            this.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres:";
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
            this.label9.TabIndex = 67;
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
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // Aportaciones
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Conejo.Properties.Resources.light_blue_background_800x600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(728, 383);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bttAportar);
            this.Controls.Add(this.dgvAportaciones);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(696, 378);
            this.Name = "Aportaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aportaciones";
            this.Load += new System.EventHandler(this.Aportaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttAportar;
        private System.Windows.Forms.DataGridView dgvAportaciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtAportaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}