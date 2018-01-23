namespace ACOPEDH
{
    partial class Imágenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Imágenes));
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.bttAceptar = new System.Windows.Forms.Button();
            this.bttModificar = new System.Windows.Forms.Button();
            this.bttEliminar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(680, 0);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 26);
            this.bttCer.TabIndex = 122;
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
            this.pictureBox3.TabIndex = 121;
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
            this.BarraTítulo.Size = new System.Drawing.Size(710, 30);
            this.BarraTítulo.TabIndex = 120;
            this.BarraTítulo.Text = "         ACOPEDH - Imágenes";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bttAceptar
            // 
            this.bttAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttAceptar.Location = new System.Drawing.Point(510, 283);
            this.bttAceptar.Name = "bttAceptar";
            this.bttAceptar.Size = new System.Drawing.Size(112, 50);
            this.bttAceptar.TabIndex = 3;
            this.bttAceptar.Text = "Añadir";
            this.bttAceptar.UseVisualStyleBackColor = true;
            this.bttAceptar.Click += new System.EventHandler(this.bttAceptar_Click);
            // 
            // bttModificar
            // 
            this.bttModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttModificar.Enabled = false;
            this.bttModificar.Location = new System.Drawing.Point(454, 227);
            this.bttModificar.Name = "bttModificar";
            this.bttModificar.Size = new System.Drawing.Size(112, 50);
            this.bttModificar.TabIndex = 1;
            this.bttModificar.Text = "Modificar";
            this.bttModificar.UseVisualStyleBackColor = true;
            this.bttModificar.Click += new System.EventHandler(this.bttModificar_Click);
            // 
            // bttEliminar
            // 
            this.bttEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttEliminar.Enabled = false;
            this.bttEliminar.Location = new System.Drawing.Point(572, 227);
            this.bttEliminar.Name = "bttEliminar";
            this.bttEliminar.Size = new System.Drawing.Size(112, 50);
            this.bttEliminar.TabIndex = 2;
            this.bttEliminar.Text = "Eliminar";
            this.bttEliminar.UseVisualStyleBackColor = true;
            this.bttEliminar.Click += new System.EventHandler(this.bttEliminar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(23, 56);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(417, 394);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(463, 79);
            this.txtFecha.MaxLength = 50;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(213, 27);
            this.txtFecha.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(519, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 123;
            this.label1.Text = "Comentarios";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(463, 134);
            this.txtComentarios.MaxLength = 120;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.ReadOnly = true;
            this.txtComentarios.Size = new System.Drawing.Size(213, 70);
            this.txtComentarios.TabIndex = 124;
            this.txtComentarios.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(501, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 19);
            this.label3.TabIndex = 125;
            this.label3.Text = "Fecha de Subida";
            // 
            // Imágenes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(710, 488);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComentarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bttEliminar);
            this.Controls.Add(this.bttModificar);
            this.Controls.Add(this.bttAceptar);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Imágenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imágenes";
            this.Load += new System.EventHandler(this.Imágenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.Button bttAceptar;
        private System.Windows.Forms.Button bttModificar;
        private System.Windows.Forms.Button bttEliminar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtComentarios;
        private System.Windows.Forms.Label label3;
    }
}