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
    public partial class Pagos : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Datos;
        bool arreglandopago=false;
        public static double interes = 0.02;
        #region Constructores
        //Normal
        public Pagos()
        {
            InitializeComponent();
            txtMontoMinimo.Text = "1";
            txtSaldo.Text = "200";
        }
        //Con Código Préstamo
        public Pagos(string dato)
        {
            InitializeComponent();
            Datos = dato;
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
        //Pagar e Imprimir
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de pago para la siguiente transacción?:\n$" + nmCantidad.Value + "\n N° Préstamo: " + txtIdPréstamo.Text + "\nPersona Asociada: " + txtNombre.Text, "Confirmar Pago", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (Imprimir != DialogResult.Cancel)
            {
                Procedimientos_select ingresar = new Procedimientos_select();
                if (Imprimir == DialogResult.Yes)
                {
#warning Añadir Imprimir
                }

                DialogResult = DialogResult.OK;
                Close();
            }
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
        #region Closing
        private void Pagos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)//Si no ha efectuado el pago
                if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
        }
        #endregion
        #region Load

        private void Pagos_Load(object sender, EventArgs e)
        {
            double interes = 1, Monto = 1;
            TextBox Monto1 = new TextBox();
            TextBox interes1 = new TextBox();
            Procedimientos_select pro = new Procedimientos_select();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@ID_Préstamo", Datos);
            pro.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Monto,Interés", Param, txtNombre, txtMontoMinimo, Monto1, interes1);
            Param[0] = new SqlParameter("@ID_Préstamo", Datos);
            pro.LlenarText("[Cargar Saldo]", "Pago Mínimo", Param, txtSaldo);
            Param[0] = new SqlParameter("@Id_Préstamo", Datos);
            DataTable dt = pro.llenar_DataTable("[Conseguir Límite]", Param);
            DateTime time = Convert.ToDateTime(dt.Rows[0]["Límite"]).AddMonths(1);
            txtIdPréstamo.Text = Datos;
            try
            {
                Monto = double.Parse(Monto1.Text);
                interes = double.Parse(interes1.Text);
                nmCantidad.Maximum = Convert.ToDecimal(txtSaldo.Text) * (Convert.ToDecimal(interes) / 1200);
            }
            catch
            {
                nmCantidad.Maximum = Convert.ToDecimal(Monto) * (1 + (Convert.ToDecimal(interes) / 1200));
                txtSaldo.Text = Monto.ToString();
            }
            if (Convert.ToDecimal(txtMontoMinimo.Text) > nmCantidad.Maximum)
            {
                nmCantidad.Minimum = nmCantidad.Maximum;
                txtMontoMinimo.Text = txtSaldo.Text;
            }
            else
            {
                nmCantidad.Minimum = Convert.ToDecimal(txtMontoMinimo.Text);
            }
            //Verificar esto
            if(time<=DateTime.Now&&!arreglandopago)
            {
                nmCantidad.Minimum = Convert.ToDecimal(Convert.ToDouble(txtMontoMinimo.Text) * interes);
            }
            nmCantidad.Value = nmCantidad.Minimum;
            txtPagoMax.Text =Math.Round(nmCantidad.Maximum, 2).ToString();
            txtMontoMinimo.Text = "$" + Math.Round(double.Parse(txtMontoMinimo.Text),2);
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
