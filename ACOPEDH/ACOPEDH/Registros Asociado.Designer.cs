namespace ACOPEDH
{
    partial class Registros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registros));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbTipoImagen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCancelados = new System.Windows.Forms.CheckBox();
            this.bttCer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.pictureBox3.BackgroundImage = global::ACOPEDH.Properties.Resources.photo_sinlietras;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(6, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 127;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarraTítulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BarraTítulo.Location = new System.Drawing.Point(2, 2);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(614, 30);
            this.BarraTítulo.TabIndex = 0;
            this.BarraTítulo.Text = "         ACOPEDH - Registros de Cuentas";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarraTítulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BarraTítulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.BarraTítulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 97);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(554, 369);
            this.dataGridView1.TabIndex = 129;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // cbTipoImagen
            // 
            this.cbTipoImagen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoImagen.FormattingEnabled = true;
            this.cbTipoImagen.Location = new System.Drawing.Point(123, 51);
            this.cbTipoImagen.Name = "cbTipoImagen";
            this.cbTipoImagen.Size = new System.Drawing.Size(213, 27);
            this.cbTipoImagen.TabIndex = 130;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 131;
            this.label2.Text = "Filtrar por:";
            // 
            // cbCancelados
            // 
            this.cbCancelados.AutoSize = true;
            this.cbCancelados.BackColor = System.Drawing.Color.Transparent;
            this.cbCancelados.Location = new System.Drawing.Point(359, 53);
            this.cbCancelados.Name = "cbCancelados";
            this.cbCancelados.Size = new System.Drawing.Size(246, 23);
            this.cbCancelados.TabIndex = 132;
            this.cbCancelados.Text = "Cuentas cerradas o canceladas";
            this.cbCancelados.UseVisualStyleBackColor = false;
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Location = new System.Drawing.Point(586, 3);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(29, 29);
            this.bttCer.TabIndex = 136;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            this.bttCer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttCer_MouseDown);
            this.bttCer.MouseLeave += new System.EventHandler(this.bttCer_MouseLeave);
            this.bttCer.MouseHover += new System.EventHandler(this.bttCer_MouseHover);
            // 
            // Registros
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(618, 495);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.cbCancelados);
            this.Controls.Add(this.cbTipoImagen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registros";
            this.Load += new System.EventHandler(this.Registros_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bordes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbTipoImagen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbCancelados;
        private System.Windows.Forms.PictureBox bttCer;
    }
}