namespace Conejo
{
    partial class Búsqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Búsqueda));
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(17)))), ((int)(((byte)(2)))));
            this.label6.Location = new System.Drawing.Point(133, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(513, 38);
            this.label6.TabIndex = 69;
            this.label6.Text = "Asociación Cooperativa De Ahorro, Crédito Y Consumo Del\r\nPersonal De La Procuradu" +
    "ría Para La Defensa De Los Derechos Humanos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(36, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Linotte-Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(156, 123);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(362, 23);
            this.txtBusca.TabIndex = 70;
            this.txtBusca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(72, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 71;
            this.label1.Text = "Búsqueda:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(75, 164);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(553, 273);
            this.dgv.TabIndex = 73;
            this.dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // Búsqueda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Conejo.Properties.Resources.light_blue_background_800x600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(712, 505);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Linotte-SemiBold", 9.749999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Búsqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda";
            this.Load += new System.EventHandler(this.Búsqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
    }
}