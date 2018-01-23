namespace ACOPEDH
{
    partial class Opciones_Informes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opciones_Informes));
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbMora = new System.Windows.Forms.Label();
            this.bttConstanciaPago = new System.Windows.Forms.Button();
            this.bttPagaré = new System.Windows.Forms.Button();
            this.bttDesembolso = new System.Windows.Forms.Button();
            this.bttRecibo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bttCer
            // 
            this.bttCer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(333, 2);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 26);
            this.bttCer.TabIndex = 42;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(-76, 142);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 41;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(-1, 0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(365, 30);
            this.BarraTítulo.TabIndex = 40;
            this.BarraTítulo.Text = "         ACOPEDH - Documentos para Préstamo";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // lbMora
            // 
            this.lbMora.AutoSize = true;
            this.lbMora.BackColor = System.Drawing.Color.Transparent;
            this.lbMora.Font = new System.Drawing.Font("Linotte-SemiBold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMora.Location = new System.Drawing.Point(24, 61);
            this.lbMora.Name = "lbMora";
            this.lbMora.Size = new System.Drawing.Size(308, 18);
            this.lbMora.TabIndex = 44;
            this.lbMora.Text = "Seleccione el documento que desea imprimir";
            this.lbMora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttConstanciaPago
            // 
            this.bttConstanciaPago.Font = new System.Drawing.Font("Linotte-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttConstanciaPago.Location = new System.Drawing.Point(26, 109);
            this.bttConstanciaPago.Name = "bttConstanciaPago";
            this.bttConstanciaPago.Size = new System.Drawing.Size(144, 61);
            this.bttConstanciaPago.TabIndex = 84;
            this.bttConstanciaPago.Text = "Carta de Comunicación\r\n";
            this.bttConstanciaPago.UseVisualStyleBackColor = true;
            this.bttConstanciaPago.Click += new System.EventHandler(this.bttImprimir_Click);
            // 
            // bttPagaré
            // 
            this.bttPagaré.Font = new System.Drawing.Font("Linotte-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttPagaré.Location = new System.Drawing.Point(26, 189);
            this.bttPagaré.Name = "bttPagaré";
            this.bttPagaré.Size = new System.Drawing.Size(144, 61);
            this.bttPagaré.TabIndex = 85;
            this.bttPagaré.Text = "Pagaré";
            this.bttPagaré.UseVisualStyleBackColor = true;
            this.bttPagaré.Click += new System.EventHandler(this.bttPagaré_Click);
            // 
            // bttDesembolso
            // 
            this.bttDesembolso.Font = new System.Drawing.Font("Linotte-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttDesembolso.Location = new System.Drawing.Point(190, 109);
            this.bttDesembolso.Name = "bttDesembolso";
            this.bttDesembolso.Size = new System.Drawing.Size(141, 61);
            this.bttDesembolso.TabIndex = 86;
            this.bttDesembolso.Text = "Hoja de\r\nDesembolso";
            this.bttDesembolso.UseVisualStyleBackColor = true;
            this.bttDesembolso.Click += new System.EventHandler(this.bttDesembolso_Click);
            // 
            // bttRecibo
            // 
            this.bttRecibo.Font = new System.Drawing.Font("Linotte-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttRecibo.Location = new System.Drawing.Point(190, 189);
            this.bttRecibo.Name = "bttRecibo";
            this.bttRecibo.Size = new System.Drawing.Size(141, 61);
            this.bttRecibo.TabIndex = 87;
            this.bttRecibo.Text = "Recibo de Préstamo";
            this.bttRecibo.UseVisualStyleBackColor = true;
            this.bttRecibo.Click += new System.EventHandler(this.bttRecibo_Click);
            // 
            // Opciones_Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.ClientSize = new System.Drawing.Size(364, 301);
            this.Controls.Add(this.bttRecibo);
            this.Controls.Add(this.bttDesembolso);
            this.Controls.Add(this.bttPagaré);
            this.Controls.Add(this.bttConstanciaPago);
            this.Controls.Add(this.lbMora);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Opciones_Informes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opciones_Informes";
            this.Load += new System.EventHandler(this.Opciones_Informes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbMora;
        private System.Windows.Forms.Button bttConstanciaPago;
        private System.Windows.Forms.Button bttPagaré;
        private System.Windows.Forms.Button bttDesembolso;
        private System.Windows.Forms.Button bttRecibo;
    }
}