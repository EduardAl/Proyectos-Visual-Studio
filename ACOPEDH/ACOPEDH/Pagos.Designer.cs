namespace ACOPEDH
{
    partial class Pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bttAceptar = new System.Windows.Forms.Button();
            this.txtIdPréstamo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtMontoMinimo = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.bttMin = new System.Windows.Forms.PictureBox();
            this.nmCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPagoMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbMora = new System.Windows.Forms.Label();
            this.txtMora = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Préstamo: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Persona\r\nAsociada: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto Mínimo: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Saldo: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cantidad de Pago: ";
            // 
            // bttAceptar
            // 
            this.bttAceptar.Font = new System.Drawing.Font("Folks-Light", 12F);
            this.bttAceptar.Location = new System.Drawing.Point(330, 230);
            this.bttAceptar.Name = "bttAceptar";
            this.bttAceptar.Size = new System.Drawing.Size(110, 45);
            this.bttAceptar.TabIndex = 1;
            this.bttAceptar.Text = "ACEPTAR";
            this.bttAceptar.UseVisualStyleBackColor = true;
            this.bttAceptar.Click += new System.EventHandler(this.bttAceptar_Click);
            // 
            // txtIdPréstamo
            // 
            this.txtIdPréstamo.Font = new System.Drawing.Font("Folks-Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPréstamo.Location = new System.Drawing.Point(137, 52);
            this.txtIdPréstamo.Multiline = true;
            this.txtIdPréstamo.Name = "txtIdPréstamo";
            this.txtIdPréstamo.ReadOnly = true;
            this.txtIdPréstamo.Size = new System.Drawing.Size(124, 25);
            this.txtIdPréstamo.TabIndex = 0;
            this.txtIdPréstamo.TabStop = false;
            this.txtIdPréstamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Folks-Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(109, 100);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(321, 25);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.TabStop = false;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMontoMinimo
            // 
            this.txtMontoMinimo.Font = new System.Drawing.Font("Folks-Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoMinimo.Location = new System.Drawing.Point(149, 146);
            this.txtMontoMinimo.Multiline = true;
            this.txtMontoMinimo.Name = "txtMontoMinimo";
            this.txtMontoMinimo.ReadOnly = true;
            this.txtMontoMinimo.Size = new System.Drawing.Size(76, 25);
            this.txtMontoMinimo.TabIndex = 8;
            this.txtMontoMinimo.TabStop = false;
            this.txtMontoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Font = new System.Drawing.Font("Folks-Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(302, 147);
            this.txtSaldo.Multiline = true;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(76, 25);
            this.txtSaldo.TabIndex = 9;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(4, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(470, 30);
            this.BarraTítulo.TabIndex = 37;
            this.BarraTítulo.Text = "         ACOPEDH .:. PAGO";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarraTítulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BarraTítulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.BarraTítulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // bttCer
            // 
            this.bttCer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(440, 0);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 26);
            this.bttCer.TabIndex = 39;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            // 
            // bttMin
            // 
            this.bttMin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bttMin.BackColor = System.Drawing.Color.Transparent;
            this.bttMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttMin.BackgroundImage")));
            this.bttMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttMin.Image = ((System.Drawing.Image)(resources.GetObject("bttMin.Image")));
            this.bttMin.Location = new System.Drawing.Point(410, 0);
            this.bttMin.Name = "bttMin";
            this.bttMin.Size = new System.Drawing.Size(30, 26);
            this.bttMin.TabIndex = 40;
            this.bttMin.TabStop = false;
            this.bttMin.Click += new System.EventHandler(this.bttMin_Click);
            // 
            // nmCantidad
            // 
            this.nmCantidad.DecimalPlaces = 2;
            this.nmCantidad.Location = new System.Drawing.Point(191, 233);
            this.nmCantidad.Name = "nmCantidad";
            this.nmCantidad.Size = new System.Drawing.Size(110, 27);
            this.nmCantidad.TabIndex = 0;
            this.nmCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPagoMax
            // 
            this.txtPagoMax.Font = new System.Drawing.Font("Folks-Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagoMax.Location = new System.Drawing.Point(149, 189);
            this.txtPagoMax.Multiline = true;
            this.txtPagoMax.Name = "txtPagoMax";
            this.txtPagoMax.ReadOnly = true;
            this.txtPagoMax.Size = new System.Drawing.Size(76, 25);
            this.txtPagoMax.TabIndex = 42;
            this.txtPagoMax.TabStop = false;
            this.txtPagoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 19);
            this.label6.TabIndex = 41;
            this.label6.Text = "Un solo pago:";
            // 
            // lbMora
            // 
            this.lbMora.AutoSize = true;
            this.lbMora.BackColor = System.Drawing.Color.Transparent;
            this.lbMora.Font = new System.Drawing.Font("Linotte-SemiBold", 10F);
            this.lbMora.Location = new System.Drawing.Point(85, 289);
            this.lbMora.Name = "lbMora";
            this.lbMora.Size = new System.Drawing.Size(273, 34);
            this.lbMora.TabIndex = 43;
            this.lbMora.Text = "* La fecha límite para este pago ha pasado,\r\nse aplica un recargo a la cantidad d" +
    "e Pago";
            this.lbMora.Visible = false;
            // 
            // txtMora
            // 
            this.txtMora.Font = new System.Drawing.Font("Folks-Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMora.Location = new System.Drawing.Point(302, 189);
            this.txtMora.Multiline = true;
            this.txtMora.Name = "txtMora";
            this.txtMora.ReadOnly = true;
            this.txtMora.Size = new System.Drawing.Size(76, 25);
            this.txtMora.TabIndex = 45;
            this.txtMora.TabStop = false;
            this.txtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(244, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 44;
            this.label7.Text = "Mora: ";
            // 
            // Pagos
            // 
            this.AcceptButton = this.bttAceptar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(470, 336);
            this.Controls.Add(this.txtMora);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbMora);
            this.Controls.Add(this.txtPagoMax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nmCantidad);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.bttMin);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.txtMontoMinimo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtIdPréstamo);
            this.Controls.Add(this.bttAceptar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-SemiBold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 336);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 336);
            this.Name = "Pagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACOPEDH - Pagos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pagos_FormClosing);
            this.Load += new System.EventHandler(this.Pagos_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bordes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bttAceptar;
        private System.Windows.Forms.TextBox txtIdPréstamo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtMontoMinimo;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox bttMin;
        private System.Windows.Forms.NumericUpDown nmCantidad;
        private System.Windows.Forms.TextBox txtPagoMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbMora;
        private System.Windows.Forms.TextBox txtMora;
        private System.Windows.Forms.Label label7;
    }
}