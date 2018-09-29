using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Nueva_Imagen : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Asociado="";
        bool Cambiado = false;
        Procedimientos_select Cargar = new Procedimientos_select();
        Img img;
        #region Constructores
        public Nueva_Imagen(Img cargar)
        {
            InitializeComponent();
            img = cargar;
            BarraTítulo.Text = "         ACOPEDH - Modificar Imagen";
            pbNuevaImagen.Image = Transformación(img.Imagen);
            pbNuevaImagen.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public Nueva_Imagen(string asociado)
        {
            InitializeComponent();
            Asociado = asociado;
        }
        #endregion
        #region Load
        private void Nueva_Imagen_Load(object sender, EventArgs e)
        {
            MaximumSize = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width - 15, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 15);
            //Llenado de los combobox
            cbTipoImagen.DataSource = Cargar.llenar_DataTable("[Cargar Tipo Imagen]");
            cbTipoImagen.DisplayMember = "TipoI";
            cbTipoImagen.ValueMember = "idI";
            if(Asociado=="")
            {
                cbTipoImagen.SelectedIndex = cbTipoImagen.FindString(img.TipoImagen);
            }
        }
        #endregion

        /*
           *********************************
           *            Botones            *
           ********************************* 
       */
        #region Acciones
        private void bttSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (odNuevaImagen.ShowDialog() == DialogResult.OK)
                {
                    Cambiado = true;
                    string dato = odNuevaImagen.FileName;
                    pbNuevaImagen.Image = Image.FromFile(odNuevaImagen.FileName);
                    pbNuevaImagen.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bttGuardar_Click(object sender, EventArgs e)
        {
            bool Modificando = (Asociado == "");
            string Mensaje = Modificando ? "¿Seguro que desea modificar la imagen?" : "¿Seguro que desea insertar la imagen?";
            string Procedimiento = Modificando ? "[Actualizar Imagen]" : "[Insertar Imagen]";
            if (MessageBox.Show(Mensaje, "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    string txt = txtComentarios.Text.Trim(' ');
                    SqlParameter[] Parámetros = new SqlParameter[4];
                    if (Modificando)
                    {
                        Asociado = img.Asociado;
                        Parámetros = new SqlParameter[5];
                        Parámetros[4] = new SqlParameter("@Id_Imagen", img.Id);
                    }
                    Parámetros[0] = new SqlParameter("@Persona_Asociada", int.Parse(Asociado));
                    if (!Cambiado)
                        Parámetros[1] = new SqlParameter("@Imagen", img.Imagen);
                    else
                        Parámetros[1] = new SqlParameter("@Imagen", Transformación(pbNuevaImagen.Image));
                    Parámetros[2] = new SqlParameter("@TipoImagen", cbTipoImagen.SelectedValue);
                    Parámetros[3] = new SqlParameter("@Comentarios", txt);
                    if (Cargar.llenar_tabla(Procedimiento, Parámetros) > 0)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
                }
                catch { }
            }
        }
        #endregion
        #region Botones Barra de Titulo
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.FromArgb(20, 25, 72); ;
        }
        private void bttCer_MouseHover(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.Red;
        }
        private void bttCer_MouseDown(object sender, MouseEventArgs e)
        {
            bttCer.BackColor = Color.DarkRed;
        }
        private void bttMax_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void bttMax_MouseDown(object sender, MouseEventArgs e)
        {
            bttMax.BackColor = Color.Blue;
        }

        private void bttMax_MouseHover(object sender, EventArgs e)
        {
            bttMax.BackColor = Color.FromArgb(35, 45, 129);
        }

        private void bttMax_MouseLeave(object sender, EventArgs e)
        {
            bttMax.BackColor = Color.FromArgb(20, 25, 72);
        }
        #endregion

        /*
           *********************************
           *            Métodos            *
           ********************************* 
       */
        #region Transformar Imagen
        static byte[] Transformación(Image Imagen)
        {
            byte[] ret= new byte[1];
            try
            {
                MemoryStream str = new MemoryStream();
                Imagen.Save(str, Imagen.RawFormat);
                ret = str.GetBuffer();
                str.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret;
        }
        static Image Transformación(byte[] Imagen)
        {
            MemoryStream str = new MemoryStream(Imagen);
            Image ret = Image.FromStream(str);
            str.Close();
            return ret;
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Closing
        private void Nueva_Imagen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                if (MessageBox.Show("¿Seguro que desea cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        #endregion
        #region Cambio de tamaño
        private void Nueva_Imagen_SizeChanged(object sender, EventArgs e)
        {
            pbNuevaImagen.Size = new Size(pbNuevaImagen.Width + (Height -pbNuevaImagen.Size.Height - 64) , Height-64);
            gbDatos.Location = new Point((int)((3*Width)/4 - (gbDatos.Width/2)),(int)((Height -gbDatos.Height+BarraTítulo.Height)/2));
            pbNuevaImagen.Location = new Point((int)((gbDatos.Location.X - pbNuevaImagen.Width)/2),pbNuevaImagen.Location.Y);
            Refresh();
        }
        #endregion
        #region Pintar Bordes
        private void Bordes_Paint(object sender, PaintEventArgs e)
        {
            Pen c = (new Pen(Brushes.Purple, 2));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width - 1, 0), new Point(Width - 1, Height - 2));
            Linea.DrawLine(c, new Point(1, 0), new Point(1, Height));
            Linea.DrawLine(c, new Point(0, Height - 1), new Point(Width, Height - 1));
            Linea.DrawLine(c, new Point(Width, 1), new Point(0, 1));
        }
        #endregion
        #region Sombra
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        #endregion
        #region Mover Form
        bool Empezarmover = false;
        int PosX;
        int PosY;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = true;
                PosX = e.X;
                PosY = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Empezarmover)
            {
                Point temp = new Point();
                temp.X = Location.X + (e.X - PosX);
                temp.Y = Location.Y + (e.Y - PosY);
                Location = temp;
            }
        }
        #endregion
    }
}
