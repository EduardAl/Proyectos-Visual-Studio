namespace ACOPEDH
{
    partial class Imprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Imprimir));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.bttMin = new System.Windows.Forms.PictureBox();
            this.bttMax = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMax)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(7, 37);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(913, 513);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(895, 1);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(33, 26);
            this.bttCer.TabIndex = 42;
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
            this.pictureBox3.Size = new System.Drawing.Size(33, 30);
            this.pictureBox3.TabIndex = 41;
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
            this.BarraTítulo.Size = new System.Drawing.Size(927, 30);
            this.BarraTítulo.TabIndex = 40;
            this.BarraTítulo.Text = "         ACOPEDH - Pago";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarraTítulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BarraTítulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.BarraTítulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // bttMin
            // 
            this.bttMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttMin.BackColor = System.Drawing.Color.Transparent;
            this.bttMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttMin.BackgroundImage")));
            this.bttMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttMin.Image = ((System.Drawing.Image)(resources.GetObject("bttMin.Image")));
            this.bttMin.Location = new System.Drawing.Point(841, 1);
            this.bttMin.Name = "bttMin";
            this.bttMin.Size = new System.Drawing.Size(30, 26);
            this.bttMin.TabIndex = 44;
            this.bttMin.TabStop = false;
            this.bttMin.Click += new System.EventHandler(this.bttMin_Click);
            // 
            // bttMax
            // 
            this.bttMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttMax.BackColor = System.Drawing.Color.Transparent;
            this.bttMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttMax.BackgroundImage")));
            this.bttMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttMax.Image = ((System.Drawing.Image)(resources.GetObject("bttMax.Image")));
            this.bttMax.Location = new System.Drawing.Point(869, 1);
            this.bttMax.Name = "bttMax";
            this.bttMax.Size = new System.Drawing.Size(30, 26);
            this.bttMax.TabIndex = 43;
            this.bttMax.TabStop = false;
            this.bttMax.Click += new System.EventHandler(this.bttMax_Click);
            // 
            // Imprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(182)))), ((int)(((byte)(11)))));
            this.ClientSize = new System.Drawing.Size(927, 558);
            this.Controls.Add(this.bttMin);
            this.Controls.Add(this.bttMax);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.Controls.Add(this.crystalReportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Imprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.Imprimir_Load);
            this.SizeChanged += new System.EventHandler(this.Imprimir_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bordes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.PictureBox bttMin;
        private System.Windows.Forms.PictureBox bttMax;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}