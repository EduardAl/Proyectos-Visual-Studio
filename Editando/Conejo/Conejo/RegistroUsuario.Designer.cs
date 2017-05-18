namespace Conejo
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 26);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tipo de\r\nUsuario:";
            // 
            // cbTipoUsuario
            // 
            this.cbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoUsuario.FormattingEnabled = true;
            this.cbTipoUsuario.Items.AddRange(new object[] {
            "Usuario",
            "Administrador",
            "Master"});
            this.cbTipoUsuario.Location = new System.Drawing.Point(32, 258);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(198, 21);
            this.cbTipoUsuario.TabIndex = 40;
            // 
            // bttCancelar
            // 
            this.bttCancelar.Location = new System.Drawing.Point(142, 289);
            this.bttCancelar.Name = "bttCancelar";
            this.bttCancelar.Size = new System.Drawing.Size(88, 23);
            this.bttCancelar.TabIndex = 39;
            this.bttCancelar.Text = "Cancelar";
            this.bttCancelar.UseVisualStyleBackColor = true;
            this.bttCancelar.Click += new System.EventHandler(this.bttCancelar_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(32, 119);
            this.txtCorreo.MaxLength = 50;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(198, 20);
            this.txtCorreo.TabIndex = 38;
            this.txtCorreo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCorreo_KeyUp);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(32, 157);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(198, 20);
            this.txtPassword.TabIndex = 37;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // txtConfPassword
            // 
            this.txtConfPassword.Location = new System.Drawing.Point(32, 208);
            this.txtConfPassword.Name = "txtConfPassword";
            this.txtConfPassword.PasswordChar = '*';
            this.txtConfPassword.Size = new System.Drawing.Size(198, 20);
            this.txtConfPassword.TabIndex = 36;
            this.txtConfPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfPassword_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 26);
            this.label5.TabIndex = 35;
            this.label5.Text = "Confirmar\r\nContraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Correo:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(32, 74);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(198, 20);
            this.txtApellido.TabIndex = 32;
            this.txtApellido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApellido_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Apellidos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(32, 32);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(198, 20);
            this.txtNombre.TabIndex = 29;
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyUp);
            // 
            // bttConfirmar
            // 
            this.bttConfirmar.Location = new System.Drawing.Point(32, 289);
            this.bttConfirmar.Name = "bttConfirmar";
            this.bttConfirmar.Size = new System.Drawing.Size(88, 23);
            this.bttConfirmar.TabIndex = 28;
            this.bttConfirmar.Text = "Crear Cuenta";
            this.bttConfirmar.UseVisualStyleBackColor = true;
            this.bttConfirmar.Click += new System.EventHandler(this.bttConfirmar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 337);
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
            this.Name = "RegistroUsuario";
            this.Text = "RegistroUsuario";
            this.Load += new System.EventHandler(this.RegistroUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
    }
}