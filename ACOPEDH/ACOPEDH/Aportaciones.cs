using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Aportaciones : Form
    {
        string Dato, Nombre;
        Procedimientos_select pro = new Procedimientos_select();
        Fonts F;
        public Aportaciones()
        {
            InitializeComponent();
        }
        public Aportaciones(string dato, string nombre)
        {
            InitializeComponent();
            Dato = dato;
            Nombre = nombre;
        }
        private void Cargar()
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Código_Asociado", Dato);
            dgvAportaciones.DataSource = pro.llenar_DataTable("[Cargar Aportaciones]", Param);
            Param[0] = new SqlParameter("@Código_Asociado", Dato);
            pro.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Param, txtSuma);
            txtSuma.Text = double.Parse(txtSuma.Text).ToString("C2");
            dgvAportaciones.Columns[0].DefaultCellStyle.Format = "C2";
            dgvAportaciones.Sort(dgvAportaciones.Columns[1], ListSortDirection.Ascending);
            dgvAportaciones.Refresh();
        }
        private void Aportaciones_Load(object sender, EventArgs e)
        {
            try
            {
                txtAsociado.Text = Nombre;
                txtCódigo.Text = Dato;
                Cargar();
                F = new Fonts(dgvAportaciones);
                F.Diseño();
            }
            catch { }
        }

        #region Eventos Botón Cerrar
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

        private void bttRealizarAportación_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de aportación para la siguiente transacción?", "Confirmar Aportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                SqlParameter[] Parámetros = new SqlParameter[3];
                Parámetros[0] = new SqlParameter("@Aportación", 5);
                Parámetros[1] = new SqlParameter("@ID_Asociado", Dato);
                Parámetros[2] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);
                if (pro.llenar_tabla("[Realizar Aportación]", Parámetros) > 0)
                {
                    if (Imprimir == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Imprimir Acción = new Imprimir(Dato, "Aportación");
                        Acción.ShowDialog();
                        Acción.Dispose();
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                    MessageBox.Show(Globales.gbError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }
                else
                    MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globales.gbError = "";
            }
            catch { }
        }

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
