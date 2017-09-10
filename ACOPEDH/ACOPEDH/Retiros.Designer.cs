namespace ACOPEDH
{
    partial class Retiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Retiros));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoCuenta = new System.Windows.Forms.TextBox();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMontoDisponible = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nCantidadRetiro = new System.Windows.Forms.NumericUpDown();
            this.bttAceptar = new System.Windows.Forms.Button();
            this.bttCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCantidadRetiro)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(4, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 42;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(487, 30);
            this.BarraTítulo.TabIndex = 41;
            this.BarraTítulo.Text = "         ACOPEDH .:. RETIROS";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 45;
            this.label1.Text = "No Cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 46;
            this.label2.Text = "Asociado:";
            // 
            // txtNoCuenta
            // 
            this.txtNoCuenta.Location = new System.Drawing.Point(115, 47);
            this.txtNoCuenta.Name = "txtNoCuenta";
            this.txtNoCuenta.ReadOnly = true;
            this.txtNoCuenta.Size = new System.Drawing.Size(100, 27);
            this.txtNoCuenta.TabIndex = 0;
            // 
            // txtAsociado
            // 
            this.txtAsociado.Location = new System.Drawing.Point(115, 80);
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.ReadOnly = true;
            this.txtAsociado.Size = new System.Drawing.Size(321, 27);
            this.txtAsociado.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(219, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 38);
            this.label3.TabIndex = 49;
            this.label3.Text = "Monto\r\nDisponible:";
            // 
            // txtMontoDisponible
            // 
            this.txtMontoDisponible.Location = new System.Drawing.Point(312, 124);
            this.txtMontoDisponible.Name = "txtMontoDisponible";
            this.txtMontoDisponible.ReadOnly = true;
            this.txtMontoDisponible.Size = new System.Drawing.Size(124, 27);
            this.txtMontoDisponible.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "Cantidad a Retirar:";
            // 
            // nCantidadRetiro
            // 
            this.nCantidadRetiro.DecimalPlaces = 2;
            this.nCantidadRetiro.Location = new System.Drawing.Point(191, 164);
            this.nCantidadRetiro.Name = "nCantidadRetiro";
            this.nCantidadRetiro.Size = new System.Drawing.Size(96, 27);
            this.nCantidadRetiro.TabIndex = 3;
            this.nCantidadRetiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bttAceptar
            // 
            this.bttAceptar.Location = new System.Drawing.Point(103, 214);
            this.bttAceptar.Name = "bttAceptar";
            this.bttAceptar.Size = new System.Drawing.Size(112, 50);
            this.bttAceptar.TabIndex = 4;
            this.bttAceptar.Text = "Aceptar";
            this.bttAceptar.UseVisualStyleBackColor = true;
            this.bttAceptar.Click += new System.EventHandler(this.bttAceptar_Click);
            // 
            // bttCancelar
            // 
            this.bttCancelar.Location = new System.Drawing.Point(274, 214);
            this.bttCancelar.Name = "bttCancelar";
            this.bttCancelar.Size = new System.Drawing.Size(112, 50);
            this.bttCancelar.TabIndex = 5;
            this.bttCancelar.Text = "Cancelar";
            this.bttCancelar.UseVisualStyleBackColor = true;
            this.bttCancelar.Click += new System.EventHandler(this.bttCancelar_Click);
            // 
            // Retiros
            // 
            this.AcceptButton = this.bttAceptar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(487, 295);
            this.Controls.Add(this.bttCancelar);
            this.Controls.Add(this.bttAceptar);
            this.Controls.Add(this.nCantidadRetiro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMontoDisponible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.txtNoCuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(487, 295);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(487, 295);
            this.Name = "Retiros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACOPEDH - RETIROS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Retiros_FormClosing);
            this.Load += new System.EventHandler(this.Retiros_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bordes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCantidadRetiro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoCuenta;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMontoDisponible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nCantidadRetiro;
        private System.Windows.Forms.Button bttAceptar;
        private System.Windows.Forms.Button bttCancelar;
    }
}