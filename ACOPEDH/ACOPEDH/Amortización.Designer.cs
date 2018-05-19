namespace ACOPEDH
{
    partial class Amortización
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Amortización));
            this.dgvAmortizar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtPlazo = new System.Windows.Forms.TextBox();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bttImprimir = new System.Windows.Forms.Button();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.bttMin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAmortizar
            // 
            this.dgvAmortizar.AllowUserToAddRows = false;
            this.dgvAmortizar.AllowUserToDeleteRows = false;
            this.dgvAmortizar.AllowUserToResizeRows = false;
            this.dgvAmortizar.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAmortizar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvAmortizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmortizar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Cuota,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvAmortizar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAmortizar.Location = new System.Drawing.Point(31, 137);
            this.dgvAmortizar.Name = "dgvAmortizar";
            this.dgvAmortizar.ReadOnly = true;
            this.dgvAmortizar.RowHeadersVisible = false;
            this.dgvAmortizar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAmortizar.Size = new System.Drawing.Size(643, 484);
            this.dgvAmortizar.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column1.HeaderText = "N° de Pago";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cuota
            // 
            this.Cuota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cuota.DefaultCellStyle = dataGridViewCellStyle24;
            this.Cuota.HeaderText = "Cuota";
            this.Cuota.Name = "Cuota";
            this.Cuota.ReadOnly = true;
            this.Cuota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column2.HeaderText = "Pago a interés";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle26;
            this.Column3.HeaderText = "Pago a Capital";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle27;
            this.Column4.HeaderText = "Saldo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle28;
            this.Column5.HeaderText = "Fecha de Pago";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(138, 81);
            this.txtMonto.Multiline = true;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(72, 33);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlazo
            // 
            this.txtPlazo.Location = new System.Drawing.Point(302, 81);
            this.txtPlazo.Multiline = true;
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.ReadOnly = true;
            this.txtPlazo.Size = new System.Drawing.Size(72, 33);
            this.txtPlazo.TabIndex = 2;
            this.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(456, 81);
            this.txtInteres.Multiline = true;
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.ReadOnly = true;
            this.txtInteres.Size = new System.Drawing.Size(72, 33);
            this.txtInteres.TabIndex = 3;
            this.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(51, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Monto del\r\nPréstamo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(228, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plazo en\r\nMeses: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(392, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Interés\r\nAnual:";
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F);
            this.BarraTítulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(2, 2);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(704, 30);
            this.BarraTítulo.TabIndex = 33;
            this.BarraTítulo.Text = "         ACOPEDH - Amortización del Préstamo";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarraTítulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BarraTítulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.BarraTítulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.pictureBox3.BackgroundImage = global::ACOPEDH.Properties.Resources.photo_sinlietras;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // bttImprimir
            // 
            this.bttImprimir.Location = new System.Drawing.Point(540, 73);
            this.bttImprimir.Name = "bttImprimir";
            this.bttImprimir.Size = new System.Drawing.Size(112, 50);
            this.bttImprimir.TabIndex = 40;
            this.bttImprimir.Text = "Imprimir";
            this.bttImprimir.UseVisualStyleBackColor = true;
            this.bttImprimir.Click += new System.EventHandler(this.bttImprimir_Click);
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Location = new System.Drawing.Point(675, 2);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 30);
            this.bttCer.TabIndex = 41;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            this.bttCer.MouseLeave += new System.EventHandler(this.bttCer_MouseLeave);
            this.bttCer.MouseHover += new System.EventHandler(this.bttCer_MouseHover);
            // 
            // bttMin
            // 
            this.bttMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.bttMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttMin.BackgroundImage")));
            this.bttMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttMin.Location = new System.Drawing.Point(643, 2);
            this.bttMin.Name = "bttMin";
            this.bttMin.Size = new System.Drawing.Size(30, 30);
            this.bttMin.TabIndex = 42;
            this.bttMin.TabStop = false;
            this.bttMin.Click += new System.EventHandler(this.bttMin_Click);
            // 
            // Amortización
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(182)))), ((int)(((byte)(194)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(708, 655);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.bttMin);
            this.Controls.Add(this.bttImprimir);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInteres);
            this.Controls.Add(this.txtPlazo);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.dgvAmortizar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(708, 655);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(708, 655);
            this.Name = "Amortización";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACOPEDH - Amortización del Préstamo";
            this.Load += new System.EventHandler(this.Amortización_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bordes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAmortizar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtPlazo;
        private System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button bttImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox bttMin;
    }
}