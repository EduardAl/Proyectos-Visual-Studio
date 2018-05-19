namespace ACOPEDH
{
    partial class Abonos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abonos));
            this.bttCancelar = new System.Windows.Forms.Button();
            this.bttAceptar = new System.Windows.Forms.Button();
            this.nmCantidadAbono = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.txtNoCuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidadAbono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bttCancelar
            // 
            this.bttCancelar.Location = new System.Drawing.Point(274, 184);
            this.bttCancelar.Name = "bttCancelar";
            this.bttCancelar.Size = new System.Drawing.Size(112, 50);
            this.bttCancelar.TabIndex = 57;
            this.bttCancelar.Text = "Cancelar";
            this.bttCancelar.UseVisualStyleBackColor = true;
            this.bttCancelar.Click += new System.EventHandler(this.bttCancelar_Click);
            // 
            // bttAceptar
            // 
            this.bttAceptar.Location = new System.Drawing.Point(103, 184);
            this.bttAceptar.Name = "bttAceptar";
            this.bttAceptar.Size = new System.Drawing.Size(112, 50);
            this.bttAceptar.TabIndex = 56;
            this.bttAceptar.Text = "Aceptar";
            this.bttAceptar.UseVisualStyleBackColor = true;
            this.bttAceptar.Click += new System.EventHandler(this.bttAceptar_Click);
            // 
            // nmCantidadAbono
            // 
            this.nmCantidadAbono.DecimalPlaces = 2;
            this.nmCantidadAbono.Location = new System.Drawing.Point(115, 145);
            this.nmCantidadAbono.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmCantidadAbono.Name = "nmCantidadAbono";
            this.nmCantidadAbono.Size = new System.Drawing.Size(96, 27);
            this.nmCantidadAbono.TabIndex = 55;
            this.nmCantidadAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 38);
            this.label4.TabIndex = 63;
            this.label4.Text = "Cantidad \r\na Abonar:";
            // 
            // txtAsociado
            // 
            this.txtAsociado.Location = new System.Drawing.Point(115, 93);
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.ReadOnly = true;
            this.txtAsociado.Size = new System.Drawing.Size(321, 27);
            this.txtAsociado.TabIndex = 53;
            // 
            // txtNoCuenta
            // 
            this.txtNoCuenta.Location = new System.Drawing.Point(115, 51);
            this.txtNoCuenta.Name = "txtNoCuenta";
            this.txtNoCuenta.ReadOnly = true;
            this.txtNoCuenta.Size = new System.Drawing.Size(100, 27);
            this.txtNoCuenta.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(21, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 38);
            this.label2.TabIndex = 61;
            this.label2.Text = "Persona\r\nAsociada:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 60;
            this.label1.Text = "No Cuenta:";
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(303, 144);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.ReadOnly = true;
            this.txtTasa.Size = new System.Drawing.Size(100, 27);
            this.txtTasa.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(234, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 38);
            this.label3.TabIndex = 65;
            this.label3.Text = "Tasa de\r\nInterés:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-243, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 34);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 70;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.label6.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(2, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(483, 35);
            this.label6.TabIndex = 69;
            this.label6.Text = "         ACOPEDH - Abonos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.label6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.label6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // Abonos
            // 
            this.AcceptButton = this.bttAceptar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(487, 258);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.bttCancelar);
            this.Controls.Add(this.bttAceptar);
            this.Controls.Add(this.nmCantidadAbono);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.txtNoCuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(487, 258);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(487, 258);
            this.Name = "Abonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACOPEDH - ABONOS";
            this.Load += new System.EventHandler(this.Abonos_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bordes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidadAbono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttCancelar;
        private System.Windows.Forms.Button bttAceptar;
        private System.Windows.Forms.NumericUpDown nmCantidadAbono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.TextBox txtNoCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
    }
}