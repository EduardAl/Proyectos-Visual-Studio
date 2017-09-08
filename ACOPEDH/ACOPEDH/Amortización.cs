using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Amortización : Form
    {
        public Amortización()
        {
            InitializeComponent();
        }
        public Amortización(string CodigoAhorro)
        {
            InitializeComponent();
        }
        public Amortización(double interes,double monto, int plazo)
        {
            InitializeComponent();
            txtInteres.Text = (interes).ToString();
            txtMonto.Text = monto.ToString();
            txtPlazo.Text = plazo.ToString();
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

        private void Amortización_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void Amortización_Load(object sender, EventArgs e)
        {
            double interes = Convert.ToDouble(txtInteres.Text) / 12;
            int plazo = Convert.ToInt32(txtPlazo.Text);
            double Fijo = Math.Pow(1 + interes, plazo);
            double Monto = Convert.ToInt32(txtMonto.Text);
            double cuota = Monto * ((Fijo * interes) / (Fijo - 1));
            double inte;
            txtInteres.Text = (double.Parse(txtInteres.Text)*100).ToString()+"%";
            txtMonto.Text = "$"+txtMonto.Text;
            for(int i=1;i<=plazo;i++)
            {
                dgvAmortizar.Rows.Add(i, "$" + Math.Round(inte = interes * Monto, 2), "$" + Math.Round(cuota - inte, 2), "$" + Math.Round(Monto = Monto - cuota + inte, 2));
            }
        }

        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bttImprimir_Click(object sender, EventArgs e)
        {

        }

        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
