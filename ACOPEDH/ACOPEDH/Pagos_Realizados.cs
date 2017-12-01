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
    public partial class Pagos_Realizados : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Datos;
        Fonts F;
        #region Constructores
        //Solo iniciando
        public Pagos_Realizados()
        {
            InitializeComponent();
        }
        //Con código de préstamo
        public Pagos_Realizados(string datos)
        {
            InitializeComponent();
            Datos = datos;
            txtIDPréstamo.Text = Datos;
        }
        #endregion
        #region load
        private void Pagos_Realizados_Load(object sender, EventArgs e)
        {
            try
            {
                Procedimientos_select pro = new Procedimientos_select();
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                dgvPagosRealizados.DataSource = pro.llenar_DataTable("[Cargar Pagos]", Param);
                Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                pro.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Monto,FechaT,NCuotas,TipoP,Estado,Interés", Param, txtAsociado, txtCuotaMensual, txtMonto, txtOtorgamiento, txtPlazo, txtTipoPréstamo, txtEstado, txtTInterés);
                dgvPagosRealizados.Sort(dgvPagosRealizados.Columns[0], ListSortDirection.Ascending);
                dgvPagosRealizados.Columns[1].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[2].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[3].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[4].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[5].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Refresh();
                txtMonto.Text = Math.Round(Convert.ToDouble(txtMonto.Text),2).ToString("C2");
                txtCuotaMensual.Text = Math.Round(Convert.ToDouble(txtCuotaMensual.Text),2).ToString("C2");
                F = new Fonts(dgvPagosRealizados);
                F.Diseño();
            }
            catch { }
            Visible = true;
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Minimizar
        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //Cerrar
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Imprimir
        private void bttImprimir_Click(object sender, EventArgs e)
        {
#warning Imprimir el estado del préstamo
        }

        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
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
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 0), new Point(0, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, Height - 1), new Point(Width, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(Width - 1, 0), new Point(Width, Height));
        }
        #endregion
    }
}
