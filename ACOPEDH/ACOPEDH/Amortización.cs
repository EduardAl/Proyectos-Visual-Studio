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
    public partial class Amortización : Form
    {
#warning Preguntar si se debe añadir fecha

        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        public string CódigoPréstamo="";
        #region Constructores
        //Normal
        public Amortización()
        {
            InitializeComponent();
        }
        //Con un código
        public Amortización(string codigoPréstamo)
        {
            InitializeComponent();
            CódigoPréstamo = codigoPréstamo;
        }
        //Únicamente para generar
        public Amortización(double interes,double monto, int plazo)
        {
            InitializeComponent();
            txtInteres.Text = interes.ToString();
            txtMonto.Text = monto.ToString();
            txtPlazo.Text = plazo.ToString();
        }
        #endregion
        #region Load
        private void Amortización_Load(object sender, EventArgs e)
        {
            if (CódigoPréstamo != "")//Si se ha cargado desde código
            {
                Procedimientos_select pro = new Procedimientos_select();
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ID_Préstamo", CódigoPréstamo);
                pro.LlenarText("[Cargar Préstamo]", "Monto,NCuotas,Interés", Param, txtMonto, txtPlazo, txtInteres);
            }
            try
            {
                double interes = Convert.ToDouble(txtInteres.Text) / 1200;
                int plazo = Convert.ToInt32(txtPlazo.Text);
                double Fijo = Math.Pow(1 + interes, plazo);
                double Monto = Convert.ToDouble(txtMonto.Text);
                double cuota = Math.Round(Monto * ((Fijo * interes) / (Fijo - 1)),2);
                double inte;
                txtInteres.Text = txtInteres.Text + "%";
                txtMonto.Text = "$" + txtMonto.Text;
                for (int i = 1; i <= plazo; i++)
                {
                    if (i == plazo)
                        cuota = Math.Round(Monto * (1 + interes), 2);
                    dgvAmortizar.Rows.Add(i, "$" + cuota, "$" + (inte = Math.Round(interes * Monto, 2)), "$" + Math.Round(cuota - inte, 2), "$" + (Monto = Math.Round(Monto - cuota + inte, 2)));
                }
            }
            catch
            {

            }
        }

        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones          
        //Imprimir
        private void bttImprimir_Click(object sender, EventArgs e)
        {
#warning Falta Imprimir
        }
        //Cerrar
        private void bttCer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Minimizar
        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void Amortización_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
