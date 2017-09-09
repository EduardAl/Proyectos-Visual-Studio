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
        string Datos;
        public Pagos_Realizados()
        {
            InitializeComponent();
        }
        public Pagos_Realizados(string datos)
        {
            InitializeComponent();
            Datos = datos;
            txtIDPréstamo.Text = Datos;
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

        private void Pagos_Realizados_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
      
        private void Pagos_Realizados_Load(object sender, EventArgs e)
        {
            Procedimientos_select pro = new Procedimientos_select();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@ID_Préstamo", Datos);
            dgvPagosRealizados.DataSource = pro.llenar_DataTable("[Cargar Pagos]",Param);
            Param[0] = new SqlParameter("@ID_Préstamo", Datos);
            pro.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Monto,FechaT,NCuotas,TipoP", Param, txtAsociado, txtCuotaMensual, txtMonto, txtOtorgamiento, txtPlazo, txtTipoPréstamo);
            dgvPagosRealizados.Refresh();
        }

        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
