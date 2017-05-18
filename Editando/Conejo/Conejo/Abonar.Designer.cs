namespace Conejo
{
    partial class Abonar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abonar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.txtAhorro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nAbono = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nInterés = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nAbono)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nInterés)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asociado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código\r\nde Ahorro:";
            // 
            // txtAsociado
            // 
            this.txtAsociado.BackColor = System.Drawing.Color.White;
            this.txtAsociado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAsociado.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsociado.Location = new System.Drawing.Point(80, 32);
            this.txtAsociado.Multiline = true;
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.ReadOnly = true;
            this.txtAsociado.Size = new System.Drawing.Size(276, 20);
            this.txtAsociado.TabIndex = 20;
            // 
            // txtAhorro
            // 
            this.txtAhorro.BackColor = System.Drawing.Color.White;
            this.txtAhorro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAhorro.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAhorro.Location = new System.Drawing.Point(80, 68);
            this.txtAhorro.Multiline = true;
            this.txtAhorro.Name = "txtAhorro";
            this.txtAhorro.ReadOnly = true;
            this.txtAhorro.Size = new System.Drawing.Size(160, 20);
            this.txtAhorro.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Abono:     $";
            // 
            // nAbono
            // 
            this.nAbono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nAbono.DecimalPlaces = 2;
            this.nAbono.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nAbono.Location = new System.Drawing.Point(79, 29);
            this.nAbono.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nAbono.Name = "nAbono";
            this.nAbono.Size = new System.Drawing.Size(63, 19);
            this.nAbono.TabIndex = 23;
            this.nAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Interés:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "%";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Linotte-Regular", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(66, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Abonar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.bttAbonar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.nInterés);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nAbono);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(17, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 139);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ahorro";
            // 
            // nInterés
            // 
            this.nInterés.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nInterés.DecimalPlaces = 2;
            this.nInterés.Enabled = false;
            this.nInterés.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nInterés.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nInterés.Location = new System.Drawing.Point(79, 58);
            this.nInterés.Name = "nInterés";
            this.nInterés.Size = new System.Drawing.Size(63, 19);
            this.nInterés.TabIndex = 28;
            this.nInterés.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(240, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // Abonar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Conejo.Properties.Resources.light_blue_background_800x600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 263);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAhorro);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(395, 302);
            this.MinimumSize = new System.Drawing.Size(395, 302);
            this.Name = "Abonar";
            this.Text = "Abonar";
            this.Load += new System.EventHandler(this.Abonar_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.nAbono)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nInterés)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.TextBox txtAhorro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nAbono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nInterés;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}