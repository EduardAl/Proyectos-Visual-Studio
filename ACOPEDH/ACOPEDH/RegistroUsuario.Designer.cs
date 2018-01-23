namespace ACOPEDH
{
    partial class RegistroUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroUsuario));
            this.label6 = new System.Windows.Forms.Label();
            this.cbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.bttCancelar = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.bttConfirmar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.PBMostrar1 = new System.Windows.Forms.PictureBox();
            this.PBMostrar2 = new System.Windows.Forms.PictureBox();
            this.PBACOPEDH = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBACOPEDH)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F);
            this.label6.Location = new System.Drawing.Point(126, 445);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 22);
            this.label6.TabIndex = 55;
            this.label6.Text = "Tipo de Usuario: ";
            // 
            // cbTipoUsuario
            // 
            this.cbTipoUsuario.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbTipoUsuario.BackColor = System.Drawing.Color.Gainsboro;
            this.cbTipoUsuario.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoUsuario.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F);
            this.cbTipoUsuario.FormattingEnabled = true;
            this.cbTipoUsuario.Items.AddRange(new object[] {
            "Usuario",
            "Administrador",
            "Master"});
            this.cbTipoUsuario.Location = new System.Drawing.Point(106, 468);
            this.cbTipoUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(178, 30);
            this.cbTipoUsuario.TabIndex = 6;
            this.cbTipoUsuario.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbTipoUsuario_DrawItem);
            // 
            // bttCancelar
            // 
            this.bttCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bttCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttCancelar.Font = new System.Drawing.Font("Linotte-Bold", 12.5F);
            this.bttCancelar.Location = new System.Drawing.Point(212, 506);
            this.bttCancelar.Margin = new System.Windows.Forms.Padding(0);
            this.bttCancelar.Name = "bttCancelar";
            this.bttCancelar.Size = new System.Drawing.Size(112, 49);
            this.bttCancelar.TabIndex = 8;
            this.bttCancelar.Text = "Cancelar";
            this.bttCancelar.UseVisualStyleBackColor = true;
            this.bttCancelar.Click += new System.EventHandler(this.bttCancelar_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCorreo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(67, 297);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(0);
            this.txtCorreo.MaxLength = 50;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(256, 22);
            this.txtCorreo.TabIndex = 3;
            this.txtCorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCorreo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCorreo_KeyUp);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPassword.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(67, 356);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(256, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // txtConfPassword
            // 
            this.txtConfPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtConfPassword.BackColor = System.Drawing.Color.Gainsboro;
            this.txtConfPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfPassword.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfPassword.Location = new System.Drawing.Point(67, 415);
            this.txtConfPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtConfPassword.Name = "txtConfPassword";
            this.txtConfPassword.Size = new System.Drawing.Size(256, 22);
            this.txtConfPassword.TabIndex = 5;
            this.txtConfPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConfPassword.UseSystemPasswordChar = true;
            this.txtConfPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfPassword_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F);
            this.label5.Location = new System.Drawing.Point(106, 391);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 22);
            this.label5.TabIndex = 49;
            this.label5.Text = "Confirmar contraseña: ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F);
            this.label4.Location = new System.Drawing.Point(143, 332);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 22);
            this.label4.TabIndex = 48;
            this.label4.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F);
            this.label3.Location = new System.Drawing.Point(159, 272);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 22);
            this.label3.TabIndex = 47;
            this.label3.Text = "Correo:";
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtApellido.BackColor = System.Drawing.Color.Gainsboro;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(67, 242);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(0);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(256, 22);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApellido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApellido_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F);
            this.label2.Location = new System.Drawing.Point(151, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 45;
            this.label2.Text = "Apellidos:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F);
            this.label1.Location = new System.Drawing.Point(155, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 44;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNombre.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Linotte-SemiBold", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(67, 183);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(256, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyUp);
            // 
            // bttConfirmar
            // 
            this.bttConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bttConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttConfirmar.Font = new System.Drawing.Font("Linotte-Bold", 12.5F);
            this.bttConfirmar.Location = new System.Drawing.Point(67, 506);
            this.bttConfirmar.Margin = new System.Windows.Forms.Padding(0);
            this.bttConfirmar.Name = "bttConfirmar";
            this.bttConfirmar.Size = new System.Drawing.Size(112, 49);
            this.bttConfirmar.TabIndex = 7;
            this.bttConfirmar.Text = "Crear Cuenta";
            this.bttConfirmar.UseVisualStyleBackColor = true;
            this.bttConfirmar.Click += new System.EventHandler(this.bttConfirmar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F);
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTítulo.Margin = new System.Windows.Forms.Padding(0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(391, 29);
            this.BarraTítulo.TabIndex = 56;
            this.BarraTítulo.Text = "         ACOPEDH - Registro de Usuario";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarraTítulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BarraTítulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.BarraTítulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(361, 1);
            this.bttCer.Margin = new System.Windows.Forms.Padding(0);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 26);
            this.bttCer.TabIndex = 58;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(3, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 29);
            this.pictureBox3.TabIndex = 61;
            this.pictureBox3.TabStop = false;
            // 
            // PBMostrar1
            // 
            this.PBMostrar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PBMostrar1.BackColor = System.Drawing.Color.Gainsboro;
            this.PBMostrar1.Image = global::ACOPEDH.Properties.Resources.show;
            this.PBMostrar1.Location = new System.Drawing.Point(298, 353);
            this.PBMostrar1.Margin = new System.Windows.Forms.Padding(2);
            this.PBMostrar1.Name = "PBMostrar1";
            this.PBMostrar1.Size = new System.Drawing.Size(25, 27);
            this.PBMostrar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBMostrar1.TabIndex = 63;
            this.PBMostrar1.TabStop = false;
            this.PBMostrar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBMostrar1_MouseDown);
            this.PBMostrar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBMostrar1_MouseUp);
            // 
            // PBMostrar2
            // 
            this.PBMostrar2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PBMostrar2.BackColor = System.Drawing.Color.Gainsboro;
            this.PBMostrar2.Image = global::ACOPEDH.Properties.Resources.show;
            this.PBMostrar2.Location = new System.Drawing.Point(298, 413);
            this.PBMostrar2.Margin = new System.Windows.Forms.Padding(2);
            this.PBMostrar2.Name = "PBMostrar2";
            this.PBMostrar2.Size = new System.Drawing.Size(25, 27);
            this.PBMostrar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBMostrar2.TabIndex = 64;
            this.PBMostrar2.TabStop = false;
            this.PBMostrar2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBMostrar2_MouseDown);
            this.PBMostrar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBMostrar2_MouseUp);
            // 
            // PBACOPEDH
            // 
            this.PBACOPEDH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PBACOPEDH.BackgroundImage = global::ACOPEDH.Properties.Resources.Photo_1;
            this.PBACOPEDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBACOPEDH.Location = new System.Drawing.Point(95, 50);
            this.PBACOPEDH.Margin = new System.Windows.Forms.Padding(2);
            this.PBACOPEDH.Name = "PBACOPEDH";
            this.PBACOPEDH.Size = new System.Drawing.Size(200, 181);
            this.PBACOPEDH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBACOPEDH.TabIndex = 65;
            this.PBACOPEDH.TabStop = false;
            // 
            // RegistroUsuario
            // 
            this.AcceptButton = this.bttConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttCancelar;
            this.ClientSize = new System.Drawing.Size(390, 592);
            this.Controls.Add(this.PBMostrar2);
            this.Controls.Add(this.PBMostrar1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.BarraTítulo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTipoUsuario);
            this.Controls.Add(this.bttCancelar);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtConfPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.bttConfirmar);
            this.Controls.Add(this.PBACOPEDH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "RegistroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoSizeChanged += new System.EventHandler(this.RegistroUsuario_AutoSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistroUsuario_FormClosing);
            this.Load += new System.EventHandler(this.RegistroUsuario_Load);
            this.SizeChanged += new System.EventHandler(this.RegistroUsuario_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBACOPEDH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTipoUsuario;
        private System.Windows.Forms.Button bttCancelar;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button bttConfirmar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox PBMostrar2;
        private System.Windows.Forms.PictureBox PBMostrar1;
        private System.Windows.Forms.PictureBox PBACOPEDH;
    }
}