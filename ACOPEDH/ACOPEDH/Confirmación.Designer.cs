namespace ACOPEDH
{
    partial class Confirmación
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirmación));
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.PBMostrar3 = new System.Windows.Forms.PictureBox();
            this.txtConfContraseña = new System.Windows.Forms.TextBox();
            this.labCConfirmar = new System.Windows.Forms.Label();
            this.btningresar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F);
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(-1, -1);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(491, 30);
            this.BarraTítulo.TabIndex = 33;
            this.BarraTítulo.Text = "         ACOPEDH - Confirmación";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(3, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // PBMostrar3
            // 
            this.PBMostrar3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PBMostrar3.BackColor = System.Drawing.Color.White;
            this.PBMostrar3.Image = global::ACOPEDH.Properties.Resources.show;
            this.PBMostrar3.Location = new System.Drawing.Point(327, 159);
            this.PBMostrar3.Margin = new System.Windows.Forms.Padding(2);
            this.PBMostrar3.Name = "PBMostrar3";
            this.PBMostrar3.Size = new System.Drawing.Size(35, 26);
            this.PBMostrar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBMostrar3.TabIndex = 112;
            this.PBMostrar3.TabStop = false;
            this.PBMostrar3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBMostrar3_MouseDown);
            this.PBMostrar3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBMostrar3_MouseUp);
            // 
            // txtConfContraseña
            // 
            this.txtConfContraseña.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtConfContraseña.BackColor = System.Drawing.Color.White;
            this.txtConfContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfContraseña.Font = new System.Drawing.Font("Linotte-Light", 13F);
            this.txtConfContraseña.Location = new System.Drawing.Point(103, 159);
            this.txtConfContraseña.Margin = new System.Windows.Forms.Padding(0);
            this.txtConfContraseña.Name = "txtConfContraseña";
            this.txtConfContraseña.Size = new System.Drawing.Size(259, 21);
            this.txtConfContraseña.TabIndex = 110;
            this.txtConfContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConfContraseña.UseSystemPasswordChar = true;
            this.txtConfContraseña.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfContraseña_KeyUp);
            // 
            // labCConfirmar
            // 
            this.labCConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labCConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.labCConfirmar.Location = new System.Drawing.Point(37, 35);
            this.labCConfirmar.Name = "labCConfirmar";
            this.labCConfirmar.Size = new System.Drawing.Size(419, 125);
            this.labCConfirmar.TabIndex = 111;
            this.labCConfirmar.Text = "Por motivos de seguridad es necesario que ingrese nuevamente su contraseña actual" +
    " para confirmar los cambios\r\n";
            this.labCConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btningresar
            // 
            this.btningresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btningresar.AutoSize = true;
            this.btningresar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btningresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btningresar.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btningresar.ForeColor = System.Drawing.Color.Black;
            this.btningresar.Location = new System.Drawing.Point(103, 204);
            this.btningresar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btningresar.Name = "btningresar";
            this.btningresar.Size = new System.Drawing.Size(111, 43);
            this.btningresar.TabIndex = 113;
            this.btningresar.TabStop = false;
            this.btningresar.Text = "Confirmar";
            this.btningresar.UseVisualStyleBackColor = false;
            this.btningresar.Click += new System.EventHandler(this.btningresar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(251, 204);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 43);
            this.button1.TabIndex = 114;
            this.button1.TabStop = false;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Confirmación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(488, 269);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btningresar);
            this.Controls.Add(this.PBMostrar3);
            this.Controls.Add(this.txtConfContraseña);
            this.Controls.Add(this.labCConfirmar);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Confirmación";
            this.Text = "Confirmación";
            this.Load += new System.EventHandler(this.Confirmación_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox PBMostrar3;
        private System.Windows.Forms.TextBox txtConfContraseña;
        private System.Windows.Forms.Label labCConfirmar;
        private System.Windows.Forms.Button btningresar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}