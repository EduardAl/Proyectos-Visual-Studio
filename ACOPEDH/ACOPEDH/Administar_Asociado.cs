using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ACOPEDH
{
    public partial class Administar_Asociado : Form
    {
        String Dato;
        Procedimientos_select Cargar = new Procedimientos_select();
        DataTable dtAsociado, dtAhorros,dtPréstamos;
        DataView filtro, filtro2, filtro3;
        Fonts F;
        SqlParameter[] Parámetros;

        public Administar_Asociado()
        {
            InitializeComponent();
        }
        public Administar_Asociado(String dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        private void Administar_Asociado_Load(object sender, EventArgs e)
        {
            //LLenando Textbox
            txtCódigo.Text = Dato;
            //Llenando el DataGridView
            Parámetros = new SqlParameter[1];
            Parámetros[0] = new SqlParameter("@Código",Dato);
            dtAsociado = Cargar.llenar_DataTable("[Transacciones por Asociado]", Parámetros);
            filtro = dtAsociado.DefaultView;
            dgvTrans.DataSource = filtro;
            //Llenando DataGridView Ahorros
            Parámetros = new SqlParameter[1];
            Parámetros[0] = new SqlParameter("@Código", Dato);
            dtAhorros = Cargar.llenar_DataTable("[Contar Ahorros]",Parámetros);
            filtro2 = dtAhorros.DefaultView;
            dgvAhorros.DataSource = filtro2;
            //Llenando DataGridView Préstamos
            Parámetros = new SqlParameter[1];
            Parámetros[0] = new SqlParameter("@Código", Dato);
            dtPréstamos = Cargar.llenar_DataTable("[Contar Préstamos]", Parámetros);
            filtro3 = dtPréstamos.DefaultView;
            dgvPréstamos.DataSource = filtro3;
            //Formato del DataGridView
            F = new Fonts(dgvTrans);
            F.Diseño();
            F = new Fonts(dgvAhorros);
            F.Diseño();
            F = new Fonts(dgvPréstamos);
            F.Diseño();
            dgvTrans.Refresh();
        }
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
        #region Cerrar
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.FromArgb(20, 25, 72);
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
    }
}
