namespace ACOPEDH
{
    partial class Gráfica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gráfica));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.chGráfica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.bttGraficar = new System.Windows.Forms.Button();
            this.gbPersonalizado = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFechas = new System.Windows.Forms.ComboBox();
            this.cbComparación = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chGráfica)).BeginInit();
            this.gbPersonalizado.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(1034, 0);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 26);
            this.bttCer.TabIndex = 128;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(4, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 127;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(1064, 30);
            this.BarraTítulo.TabIndex = 0;
            this.BarraTítulo.Text = "         ACOPEDH - Gráfica";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chGráfica
            // 
            this.chGráfica.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.Name = "ChartArea1";
            this.chGráfica.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Linotte-Regular", 11F, System.Drawing.FontStyle.Bold);
            legend1.TitleSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.GradientLine;
            this.chGráfica.Legends.Add(legend1);
            this.chGráfica.Location = new System.Drawing.Point(413, 71);
            this.chGráfica.Name = "chGráfica";
            this.chGráfica.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chGráfica.Series.Add(series1);
            this.chGráfica.Size = new System.Drawing.Size(626, 494);
            this.chGráfica.TabIndex = 0;
            this.chGráfica.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desde:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hasta:";
            // 
            // dtDesde
            // 
            this.dtDesde.Location = new System.Drawing.Point(72, 37);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(286, 27);
            this.dtDesde.TabIndex = 3;
            // 
            // dtHasta
            // 
            this.dtHasta.Location = new System.Drawing.Point(72, 77);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(286, 27);
            this.dtHasta.TabIndex = 4;
            // 
            // bttGraficar
            // 
            this.bttGraficar.Location = new System.Drawing.Point(137, 220);
            this.bttGraficar.Name = "bttGraficar";
            this.bttGraficar.Size = new System.Drawing.Size(101, 41);
            this.bttGraficar.TabIndex = 134;
            this.bttGraficar.Text = "Graficar";
            this.bttGraficar.UseVisualStyleBackColor = true;
            this.bttGraficar.Click += new System.EventHandler(this.bttGraficar_Click);
            // 
            // gbPersonalizado
            // 
            this.gbPersonalizado.BackColor = System.Drawing.Color.Transparent;
            this.gbPersonalizado.Controls.Add(this.bttGraficar);
            this.gbPersonalizado.Controls.Add(this.label3);
            this.gbPersonalizado.Controls.Add(this.dtHasta);
            this.gbPersonalizado.Controls.Add(this.cbFechas);
            this.gbPersonalizado.Controls.Add(this.dtDesde);
            this.gbPersonalizado.Controls.Add(this.cbComparación);
            this.gbPersonalizado.Controls.Add(this.label6);
            this.gbPersonalizado.Controls.Add(this.label1);
            this.gbPersonalizado.Controls.Add(this.label2);
            this.gbPersonalizado.Location = new System.Drawing.Point(12, 124);
            this.gbPersonalizado.Name = "gbPersonalizado";
            this.gbPersonalizado.Size = new System.Drawing.Size(383, 287);
            this.gbPersonalizado.TabIndex = 137;
            this.gbPersonalizado.TabStop = false;
            this.gbPersonalizado.Text = "Personalizado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(8, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 133;
            this.label3.Text = "Fechas:";
            // 
            // cbFechas
            // 
            this.cbFechas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFechas.FormattingEnabled = true;
            this.cbFechas.Items.AddRange(new object[] {
            "Años",
            "Meses",
            "Año Pasado",
            "Mes Pasado"});
            this.cbFechas.Location = new System.Drawing.Point(138, 171);
            this.cbFechas.Name = "cbFechas";
            this.cbFechas.Size = new System.Drawing.Size(220, 27);
            this.cbFechas.TabIndex = 132;
            this.cbFechas.SelectedIndexChanged += new System.EventHandler(this.cbFechas_SelectedIndexChanged);
            // 
            // cbComparación
            // 
            this.cbComparación.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComparación.FormattingEnabled = true;
            this.cbComparación.Items.AddRange(new object[] {
            "Generado",
            "Comparar Ahorros",
            "Comparar Préstamos",
            "Comparar Aportaciones",
            "Comparar Ingresos"});
            this.cbComparación.Location = new System.Drawing.Point(138, 122);
            this.cbComparación.Name = "cbComparación";
            this.cbComparación.Size = new System.Drawing.Size(220, 27);
            this.cbComparación.TabIndex = 131;
            this.cbComparación.SelectedIndexChanged += new System.EventHandler(this.cbComparación_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(8, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 19);
            this.label6.TabIndex = 130;
            this.label6.Text = "Comparación:";
            // 
            // Gráfica
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1064, 599);
            this.Controls.Add(this.gbPersonalizado);
            this.Controls.Add(this.chGráfica);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gráfica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráfica";
            this.Load += new System.EventHandler(this.Gráfica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chGráfica)).EndInit();
            this.gbPersonalizado.ResumeLayout(false);
            this.gbPersonalizado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chGráfica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Button bttGraficar;
        private System.Windows.Forms.GroupBox gbPersonalizado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFechas;
        private System.Windows.Forms.ComboBox cbComparación;
        private System.Windows.Forms.Label label6;
    }
}