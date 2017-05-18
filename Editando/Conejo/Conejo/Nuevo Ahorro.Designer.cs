namespace Conejo
{
    partial class Nuevo_Ahorro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nuevo_Ahorro));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.bttCrear = new System.Windows.Forms.Button();
            this.bttCancelar = new System.Windows.Forms.Button();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterés = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(54, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Asociado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(54, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 69;
            this.label2.Text = "Tipo de Cuenta:";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(167, 159);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(196, 24);
            this.cbTipo.TabIndex = 2;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // bttCrear
            // 
            this.bttCrear.Font = new System.Drawing.Font("Linotte-Regular", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttCrear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttCrear.Location = new System.Drawing.Point(57, 258);
            this.bttCrear.Name = "bttCrear";
            this.bttCrear.Size = new System.Drawing.Size(104, 30);
            this.bttCrear.TabIndex = 4;
            this.bttCrear.Text = "Crear Cuenta";
            this.bttCrear.UseVisualStyleBackColor = true;
            this.bttCrear.Click += new System.EventHandler(this.bttCrear_Click);
            // 
            // bttCancelar
            // 
            this.bttCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttCancelar.Font = new System.Drawing.Font("Linotte-Regular", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttCancelar.Location = new System.Drawing.Point(207, 258);
            this.bttCancelar.Name = "bttCancelar";
            this.bttCancelar.Size = new System.Drawing.Size(104, 30);
            this.bttCancelar.TabIndex = 5;
            this.bttCancelar.Text = "Cancelar";
            this.bttCancelar.UseVisualStyleBackColor = true;
            this.bttCancelar.Click += new System.EventHandler(this.bttCancelar_Click);
            // 
            // txtAsociado
            // 
            this.txtAsociado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAsociado.Enabled = false;
            this.txtAsociado.Location = new System.Drawing.Point(167, 126);
            this.txtAsociado.Multiline = true;
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.Size = new System.Drawing.Size(296, 20);
            this.txtAsociado.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(56, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "Interés:";
            // 
            // txtInterés
            // 
            this.txtInterés.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInterés.Enabled = false;
            this.txtInterés.Location = new System.Drawing.Point(167, 199);
            this.txtInterés.Multiline = true;
            this.txtInterés.Name = "txtInterés";
            this.txtInterés.Size = new System.Drawing.Size(96, 20);
            this.txtInterés.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Linotte-Regular", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(480, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nuevo_Ahorro
            // 
            this.AcceptButton = this.bttCrear;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Conejo.Properties.Resources.light_blue_background_800x600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.bttCancelar;
            this.ClientSize = new System.Drawing.Size(609, 322);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtInterés);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.bttCancelar);
            this.Controls.Add(this.bttCrear);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Nuevo_Ahorro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo_Ahorro";
            this.Load += new System.EventHandler(this.Nuevo_Ahorro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button bttCrear;
        private System.Windows.Forms.Button bttCancelar;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInterés;
        private System.Windows.Forms.Button button1;
    }
}