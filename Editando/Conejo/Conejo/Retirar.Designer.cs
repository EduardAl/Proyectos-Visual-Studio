namespace Conejo
{
    partial class Retirar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Retirar));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nRetirar = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.bttRetirar = new System.Windows.Forms.Button();
            this.nDisponible = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAhorro = new System.Windows.Forms.TextBox();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nRetirar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(98, 112);
            this.textBox1.MaxLength = 8;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 62;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(23, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 61;
            this.label5.Text = "N° Cheque:";
            // 
            // nRetirar
            // 
            this.nRetirar.BackColor = System.Drawing.Color.White;
            this.nRetirar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nRetirar.DecimalPlaces = 2;
            this.nRetirar.Location = new System.Drawing.Point(115, 183);
            this.nRetirar.Name = "nRetirar";
            this.nRetirar.Size = new System.Drawing.Size(63, 19);
            this.nRetirar.TabIndex = 60;
            this.nRetirar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 32);
            this.label4.TabIndex = 59;
            this.label4.Text = "Dinero a\r\nretirar:          $";
            // 
            // bttRetirar
            // 
            this.bttRetirar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.bttRetirar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttRetirar.Font = new System.Drawing.Font("Linotte-Regular", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttRetirar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bttRetirar.Location = new System.Drawing.Point(257, 126);
            this.bttRetirar.Name = "bttRetirar";
            this.bttRetirar.Size = new System.Drawing.Size(106, 40);
            this.bttRetirar.TabIndex = 58;
            this.bttRetirar.Text = "Realizar retiro";
            this.bttRetirar.UseVisualStyleBackColor = false;
            this.bttRetirar.Click += new System.EventHandler(this.bttRetirar_Click_1);
            // 
            // nDisponible
            // 
            this.nDisponible.BackColor = System.Drawing.Color.White;
            this.nDisponible.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nDisponible.DecimalPlaces = 2;
            this.nDisponible.Enabled = false;
            this.nDisponible.Location = new System.Drawing.Point(115, 147);
            this.nDisponible.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nDisponible.Name = "nDisponible";
            this.nDisponible.Size = new System.Drawing.Size(63, 19);
            this.nDisponible.TabIndex = 57;
            this.nDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(22, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Disponible:  $";
            // 
            // txtAhorro
            // 
            this.txtAhorro.BackColor = System.Drawing.Color.White;
            this.txtAhorro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAhorro.Location = new System.Drawing.Point(98, 72);
            this.txtAhorro.Multiline = true;
            this.txtAhorro.Name = "txtAhorro";
            this.txtAhorro.ReadOnly = true;
            this.txtAhorro.Size = new System.Drawing.Size(160, 20);
            this.txtAhorro.TabIndex = 55;
            this.txtAhorro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAsociado
            // 
            this.txtAsociado.BackColor = System.Drawing.Color.White;
            this.txtAsociado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAsociado.Location = new System.Drawing.Point(98, 37);
            this.txtAsociado.Multiline = true;
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.ReadOnly = true;
            this.txtAsociado.Size = new System.Drawing.Size(276, 20);
            this.txtAsociado.TabIndex = 54;
            this.txtAsociado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 32);
            this.label2.TabIndex = 53;
            this.label2.Text = "Código\r\nde Ahorro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Asociado:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Retirar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Conejo.Properties.Resources.light_blue_background_800x600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(406, 255);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nRetirar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bttRetirar);
            this.Controls.Add(this.nDisponible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAhorro);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(422, 294);
            this.MinimumSize = new System.Drawing.Size(422, 294);
            this.Name = "Retirar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retirar";
            this.Load += new System.EventHandler(this.Retirar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nRetirar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nRetirar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttRetirar;
        private System.Windows.Forms.NumericUpDown nDisponible;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAhorro;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}