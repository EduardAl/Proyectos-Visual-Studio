namespace ACOPEDH
{
    partial class Teléfonos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teléfonos));
            this.cbTipoTeléfono = new System.Windows.Forms.ComboBox();
            this.bttEliminar = new System.Windows.Forms.Button();
            this.bttModificar = new System.Windows.Forms.Button();
            this.bttAñadir = new System.Windows.Forms.Button();
            this.txtTeléfono = new System.Windows.Forms.TextBox();
            this.dgvTeléfonos = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTítulo = new System.Windows.Forms.Label();
            this.bttCer = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeléfonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTipoTeléfono
            // 
            this.cbTipoTeléfono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoTeléfono.FormattingEnabled = true;
            this.cbTipoTeléfono.Location = new System.Drawing.Point(99, 92);
            this.cbTipoTeléfono.Name = "cbTipoTeléfono";
            this.cbTipoTeléfono.Size = new System.Drawing.Size(178, 27);
            this.cbTipoTeléfono.TabIndex = 116;
            // 
            // bttEliminar
            // 
            this.bttEliminar.Enabled = false;
            this.bttEliminar.Font = new System.Drawing.Font("Linotte-Bold", 10F);
            this.bttEliminar.Location = new System.Drawing.Point(372, 93);
            this.bttEliminar.Name = "bttEliminar";
            this.bttEliminar.Size = new System.Drawing.Size(75, 23);
            this.bttEliminar.TabIndex = 115;
            this.bttEliminar.TabStop = false;
            this.bttEliminar.Text = "Eliminar";
            this.bttEliminar.UseVisualStyleBackColor = true;
            this.bttEliminar.Click += new System.EventHandler(this.bttEliminar_Click);
            // 
            // bttModificar
            // 
            this.bttModificar.Enabled = false;
            this.bttModificar.Font = new System.Drawing.Font("Linotte-Bold", 10F);
            this.bttModificar.Location = new System.Drawing.Point(295, 93);
            this.bttModificar.Name = "bttModificar";
            this.bttModificar.Size = new System.Drawing.Size(75, 23);
            this.bttModificar.TabIndex = 114;
            this.bttModificar.TabStop = false;
            this.bttModificar.Text = "Modificar";
            this.bttModificar.UseVisualStyleBackColor = true;
            this.bttModificar.Click += new System.EventHandler(this.bttModificar_Click);
            // 
            // bttAñadir
            // 
            this.bttAñadir.Font = new System.Drawing.Font("Linotte-Bold", 10F);
            this.bttAñadir.Location = new System.Drawing.Point(333, 64);
            this.bttAñadir.Name = "bttAñadir";
            this.bttAñadir.Size = new System.Drawing.Size(75, 23);
            this.bttAñadir.TabIndex = 113;
            this.bttAñadir.TabStop = false;
            this.bttAñadir.Text = "Añadir";
            this.bttAñadir.UseVisualStyleBackColor = true;
            this.bttAñadir.Click += new System.EventHandler(this.bttAñadir_Click);
            // 
            // txtTeléfono
            // 
            this.txtTeléfono.Location = new System.Drawing.Point(99, 59);
            this.txtTeléfono.MaxLength = 9;
            this.txtTeléfono.Name = "txtTeléfono";
            this.txtTeléfono.Size = new System.Drawing.Size(178, 27);
            this.txtTeléfono.TabIndex = 110;
            this.txtTeléfono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTeléfono_KeyUp);
            // 
            // dgvTeléfonos
            // 
            this.dgvTeléfonos.AllowUserToAddRows = false;
            this.dgvTeléfonos.AllowUserToDeleteRows = false;
            this.dgvTeléfonos.AllowUserToResizeColumns = false;
            this.dgvTeléfonos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTeléfonos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeléfonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeléfonos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTeléfonos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeléfonos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeléfonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeléfonos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeléfonos.Location = new System.Drawing.Point(99, 134);
            this.dgvTeléfonos.MultiSelect = false;
            this.dgvTeléfonos.Name = "dgvTeléfonos";
            this.dgvTeléfonos.ReadOnly = true;
            this.dgvTeléfonos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeléfonos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTeléfonos.RowHeadersVisible = false;
            this.dgvTeléfonos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTeléfonos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTeléfonos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTeléfonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeléfonos.Size = new System.Drawing.Size(348, 141);
            this.dgvTeléfonos.TabIndex = 112;
            this.dgvTeléfonos.TabStop = false;
            this.dgvTeléfonos.CurrentCellChanged += new System.EventHandler(this.dgvTeléfonos_CurrentCellChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(12, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 19);
            this.label10.TabIndex = 111;
            this.label10.Text = "Teléfono:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(4, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 118;
            this.pictureBox3.TabStop = false;
            // 
            // BarraTítulo
            // 
            this.BarraTítulo.BackColor = System.Drawing.Color.Transparent;
            this.BarraTítulo.Font = new System.Drawing.Font("Gotham Narrow Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraTítulo.Image = ((System.Drawing.Image)(resources.GetObject("BarraTítulo.Image")));
            this.BarraTítulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTítulo.Name = "BarraTítulo";
            this.BarraTítulo.Size = new System.Drawing.Size(506, 30);
            this.BarraTítulo.TabIndex = 117;
            this.BarraTítulo.Text = "         ACOPEDH - Teléfonos de la Persona Asociada";
            this.BarraTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bttCer
            // 
            this.bttCer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCer.BackColor = System.Drawing.Color.Transparent;
            this.bttCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttCer.BackgroundImage")));
            this.bttCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttCer.Image = ((System.Drawing.Image)(resources.GetObject("bttCer.Image")));
            this.bttCer.Location = new System.Drawing.Point(476, 0);
            this.bttCer.Name = "bttCer";
            this.bttCer.Size = new System.Drawing.Size(30, 26);
            this.bttCer.TabIndex = 119;
            this.bttCer.TabStop = false;
            this.bttCer.Click += new System.EventHandler(this.bttCer_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Teléfonos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::ACOPEDH.Properties.Resources.Fondo_Lalalala;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(506, 311);
            this.Controls.Add(this.bttCer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BarraTítulo);
            this.Controls.Add(this.cbTipoTeléfono);
            this.Controls.Add(this.bttEliminar);
            this.Controls.Add(this.bttModificar);
            this.Controls.Add(this.bttAñadir);
            this.Controls.Add(this.txtTeléfono);
            this.Controls.Add(this.dgvTeléfonos);
            this.Controls.Add(this.label10);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Linotte-Bold", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Teléfonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teléfonos";
            this.Load += new System.EventHandler(this.Teléfonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeléfonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bttCer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipoTeléfono;
        private System.Windows.Forms.Button bttEliminar;
        private System.Windows.Forms.Button bttModificar;
        private System.Windows.Forms.Button bttAñadir;
        private System.Windows.Forms.TextBox txtTeléfono;
        private System.Windows.Forms.DataGridView dgvTeléfonos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BarraTítulo;
        private System.Windows.Forms.PictureBox bttCer;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}