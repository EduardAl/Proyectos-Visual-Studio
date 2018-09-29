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
    public partial class Imágenes : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Asociado;
        Procedimientos_select Cargar = new Procedimientos_select();
        List<Img> cargando = new List<Img>();
        #region Constructores
        public Imágenes()
        {
            InitializeComponent();
        }
        public Imágenes(string asociado)
        {
            InitializeComponent();
            Asociado = asociado;
        }
        #endregion
        #region Load
        private void Imágenes_Load(object sender, EventArgs e)
        {
            CargarImágenes();
        }
        #endregion

        /*
           *********************************
           *            Botones            *
           ********************************* 
       */
        #region Acciones
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            Nueva_Imagen nueva = new Nueva_Imagen(Asociado);
            if (nueva.ShowDialog() == DialogResult.OK)
                CargarImágenes();
            nueva.Dispose();
        }
        private void bttModificar_Click(object sender, EventArgs e)
        {
            Nueva_Imagen Accion = new Nueva_Imagen(Img.ConseguirDatos(cargando, listView1.SelectedItems[0].Name));
            if(Accion.ShowDialog()==DialogResult.OK)
            {
                CargarImágenes();
            }
            Accion.Dispose();
        }
        private void bttEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea quitar esta imagen?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlParameter[] Parámetros = new SqlParameter[1];
                Parámetros[0] = new SqlParameter("@Id_Imagen", listView1.SelectedItems[0].Name);
                if(Cargar.llenar_tabla("[Eliminar Imagen]",Parámetros)>0)
                    CargarImágenes();
                else
                {
                    MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Globales.gbError = "";
                }
            }
        }

        #endregion
        #region Cerrrar
        private void bttCer_Click(object sender, EventArgs e)
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
        #endregion

        /*
           *********************************
           *            Métodos            *
           ********************************* 
       */
        #region Métodos
        private void CargarImágenes()
        {
            listView1.Clear();
            cargando.Clear();
            imageList1 = new ImageList();
            listView1.Columns.Add("Imagen", 150);
#warning Verificar la visualización de las imágenes
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.None);
            imageList1.ImageSize = new Size(150, 150);
            try
            {
                SqlParameter[] Parámetros = new SqlParameter[1];
                Parámetros[0] = new SqlParameter("@Persona_Asociada", int.Parse(Asociado));
                DataSet set = Cargar.llenar_DataSet("[Conseguir Imágenes]", Parámetros);
                int i = 0;
                listView1.LargeImageList = imageList1;
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    Img añadir = new Img((byte[])row["img"], Convert.ToDateTime(row["fecha"]),
                        Convert.ToString(row["id"]), Asociado, Convert.ToString(row["tipo"]), Convert.ToString(row["comment"]));
                    MemoryStream str = new MemoryStream(añadir.Imagen);
                    imageList1.Images.Add(Image.FromStream(str));
                    str.Close();
                    listView1.Items.Add(añadir.Id, añadir.TipoImagen, i);
                    cargando.Add(añadir);
                    i++;
                }
                listView1.Refresh();
            }
            catch
            {
                MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globales.gbError = "";
            }
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Cambio de Index
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Img c = Img.ConseguirDatos(cargando, listView1.SelectedItems[0].Name);
                bttEliminar.Enabled = bttModificar.Enabled = true;
                txtComentarios.Text = c.Comentarios;
                txtFecha.Text = c.FechaSubida.ToString();
            }
            catch
            {
                bttEliminar.Enabled = bttModificar.Enabled = false;
                txtComentarios.Text = "";
                txtFecha.Text = "";
            }
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
    }
}
