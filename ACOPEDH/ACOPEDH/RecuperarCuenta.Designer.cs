namespace ACOPEDH
{
    partial class RecuperarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperarCuenta));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.bttConfirmar = new System.Windows.Forms.Button();
            this.PBACOPEDH = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBACOPEDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 36);
            this.pictureBox3.TabIndex = 64;
            this.pictureBox3.TabStop = false;
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(483, 1);
            this.bttCer.Margin = new System.Windows.Forms.Padding(0);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(40, 32);
            this.bttCer.TabIndex = 63;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(-9, 0);
            this.BarraTítulo.Margin = new System.Windows.Forms.Padding(0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(530, 36);
            this.BarraTítulo.TabIndex = 62;
            this.BarraTítulo.Text = "         ACOPEDH .:. RECUPERAR CONTRASEÑA";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(224, 369);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 68;
            this.label5.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.AccessibleDescription = "Usuario";
            this.txtCorreo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCorreo.AutoCompleteCustomSource.AddRange(new string[] {
            "Dijite un nombre"});
            this.txtCorreo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Linotte-Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(84, 403);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(351, 27);
            this.txtCorreo.TabIndex = 65;
            this.txtCorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCorreo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCorreo_KeyUp);
            // 
            // bttConfirmar
            // 
            this.bttConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bttConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttConfirmar.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttConfirmar.Location = new System.Drawing.Point(185, 447);
            this.bttConfirmar.Margin = new System.Windows.Forms.Padding(0);
            this.bttConfirmar.Name = "bttConfirmar";
            this.bttConfirmar.Size = new System.Drawing.Size(149, 60);
            this.bttConfirmar.TabIndex = 69;
            this.bttConfirmar.Text = "Confirmar";
            this.bttConfirmar.UseVisualStyleBackColor = true;
            this.bttConfirmar.Click += new System.EventHandler(this.bttConfirmar_Click);
            // 
            // PBACOPEDH
            // 
            this.PBACOPEDH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PBACOPEDH.BackgroundImage = global::ACOPEDH.Properties.Resources.Photo_1;
            this.PBACOPEDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBACOPEDH.Location = new System.Drawing.Point(126, 79);
            this.PBACOPEDH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PBACOPEDH.Name = "PBACOPEDH";
            this.PBACOPEDH.Size = new System.Drawing.Size(267, 223);
            this.PBACOPEDH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBACOPEDH.TabIndex = 70;
            this.PBACOPEDH.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 143);
            this.label1.TabIndex = 71;
            this.label1.Text = "Por favor, ingresa el correo electrónico con el que te registraste, una vez que l" +
    "o hayas hecho se te enviará un correo con tu nueva contraseña para que puedas in" +
    "gresar y recuperar tu cuenta.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // RecuperarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PBACOPEDH);
            this.Controls.Add(this.bttConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.BarraTítulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecuperarCuenta";
            this.Text = "RecuperarCuenta";
            this.Load += new System.EventHandler(this.RecuperarCuenta_Load);
            this.SizeChanged += new System.EventHandler(this.RecuperarCuenta_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBACOPEDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button bttConfirmar;
        private System.Windows.Forms.PictureBox PBACOPEDH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}