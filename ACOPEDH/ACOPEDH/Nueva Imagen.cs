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
                    Parámetros[0] = new SqlParameter("@Persona_Asociada", Asociado);
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
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bttMax_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
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
    }
}
