namespace ACOPEDH
{
    partial class Nueva_Imagen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nueva_Imagen));
            this.bttSeleccionar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoImagen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.RichTextBox();
            this.bttGuardar = new System.Windows.Forms.Button();
            this.pbNuevaImagen = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.odNuevaImagen = new System.Windows.Forms.OpenFileDialog();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.bttMax = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNuevaImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMax)).BeginInit();
            this.SuspendLayout();
            // 
            // bttSeleccionar
            // 
            this.bttSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bttSeleccionar.Font = new System.Drawing.Font("Linotte-Bold", 10F);
            this.bttSeleccionar.Location = new System.Drawing.Point(48, 24);
            this.bttSeleccionar.Name = "bttSeleccionar";
            this.bttSeleccionar.Size = new System.Drawing.Size(158, 31);
            this.bttSeleccionar.TabIndex = 0;
            this.bttSeleccionar.Text = "Seleccionar Imagen...";
            this.bttSeleccionar.UseVisualStyleBackColor = true;
            this.bttSeleccionar.Click += new System.EventHandler(this.bttSeleccionar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(86, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo Imagen";
            // 
            // cbTipoImagen
            // 
            this.cbTipoImagen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbTipoImagen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoImagen.FormattingEnabled = true;
            this.cbTipoImagen.Location = new System.Drawing.Point(21, 105);
            this.cbTipoImagen.Name = "cbTipoImagen";
            this.cbTipoImagen.Size = new System.Drawing.Size(213, 27);
            this.cbTipoImagen.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(44, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Comentarios (Opcional)";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtComentarios.Location = new System.Drawing.Point(21, 180);
            this.txtComentarios.MaxLength = 120;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(213, 70);
            this.txtComentarios.TabIndex = 2;
            this.txtComentarios.Text = "";
            // 
            // bttGuardar
            // 
            this.bttGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bttGuardar.Location = new System.Drawing.Point(88, 286);
            this.bttGuardar.Name = "bttGuardar";
            this.bttGuardar.Size = new System.Drawing.Size(95, 42);
            this.bttGuardar.TabIndex = 3;
            this.bttGuardar.Text = "Guardar";
            this.bttGuardar.UseVisualStyleBackColor = true;
            this.bttGuardar.Click += new System.EventHandler(this.bttGuardar_Click);
            // 
            // pbNuevaImagen
            // 
            this.pbNuevaImagen.BackColor = System.Drawing.Color.LightGray;
            this.pbNuevaImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbNuevaImagen.Location = new System.Drawing.Point(22, 49);
            this.pbNuevaImagen.Name = "pbNuevaImagen";
            this.pbNuevaImagen.Size = new System.Drawing.Size(293, 384);
            this.pbNuevaImagen.TabIndex = 0;
            this.pbNuevaImagen.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.pictureBox3.BackgroundImage = global::ACOPEDH.Properties.Resources.photo_sinlietras;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(6, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 124;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarraTítulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(2, 2);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(616, 30);
            this.BarraTítulo.TabIndex = 1;
            this.BarraTítulo.Text = "         ACOPEDH - Nueva Imagen";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarraTítulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BarraTítulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.BarraTítulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // odNuevaImagen
            // 
            this.odNuevaImagen.FileName = "openFileDialog1";
            this.odNuevaImagen.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png|Archivos GIF|.gif";
            this.odNuevaImagen.ShowHelp = true;
            this.odNuevaImagen.Title = "Seleccione una imagen...";
            // 
            // gbDatos
            // 
            this.gbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gbDatos.BackColor = System.Drawing.Color.Transparent;
            this.gbDatos.Controls.Add(this.bttGuardar);
            this.gbDatos.Controls.Add(this.txtComentarios);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.cbTipoImagen);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.bttSeleccionar);
            this.gbDatos.Location = new System.Drawing.Point(338, 49);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(254, 383);
            this.gbDatos.TabIndex = 127;
            this.gbDatos.TabStop = false;
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Location = new System.Drawing.Point(586, 2);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 30);
            this.bttCer.TabIndex = 128;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCancelar_Click);
            this.bttCer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttCer_MouseDown);
            this.bttCer.MouseLeave += new System.EventHandler(this.bttCer_MouseLeave);
            this.bttCer.MouseHover += new System.EventHandler(this.bttCer_MouseHover);
            // 
            // bttMax
            // 
            this.bttMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.bttMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttMax.BackgroundImage")));
            this.bttMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttMax.Location = new System.Drawing.Point(554, 2);
            this.bttMax.Name = "bttMax";
            this.bttMax.Size = new System.Drawing.Size(30, 30);
            this.bttMax.TabIndex = 129;
            this.bttMax.TabStop = false;
            this.bttMax.Click += new System.EventHandler(this.bttMax_Click);
            this.bttMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttMax_MouseDown);
            this.bttMax.MouseLeave += new System.EventHandler(this.bttMax_MouseLeave);
            this.bttMax.MouseHover += new System.EventHandler(this.bttMax_MouseHover);
            // 
            // Nueva_Imagen
            // 
            this.AcceptButton = this.bttGuardar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 448);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.bttMax);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.Controls.Add(this.pbNuevaImagen);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nueva_Imagen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Imagen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Nueva_Imagen_FormClosing);
            this.Load += new System.EventHandler(this.Nueva_Imagen_Load);
            this.SizeChanged += new System.EventHandler(this.Nueva_Imagen_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bordes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbNuevaImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNuevaImagen;
        private System.Windows.Forms.Button bttSeleccionar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoImagen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtComentarios;
        private System.Windows.Forms.Button bttGuardar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.OpenFileDialog odNuevaImagen;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox bttMax;
    }
}