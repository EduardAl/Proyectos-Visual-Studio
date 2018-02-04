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
        bool arreglandopago = false;
        double interes = 1, Monto = 0, Plazo = 1;
        DateTime Límite;

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
            if (nmCantidad.Value > 0)
            {
                DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de pago para la siguiente transacción?:\n$" + nmCantidad.Value + "\n N° Préstamo: " + txtIdPréstamo.Text + "\nPersona Asociada: " + txtNombre.Text, "Confirmar Pago", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Imprimir != DialogResult.Cancel)
                {
                    double inte = Math.Round(Convert.ToDouble(txtSaldo.Text) * interes, 2);
                    double Pago = Convert.ToDouble(nmCantidad.Value);
                    double Capi = Pago - inte;
                    double Mora = Convert.ToDouble(txtMora.Text);
                    Procedimientos_select ingresar = new Procedimientos_select();
                    SqlParameter[] Parámetros = new SqlParameter[8];
                    Parámetros[0] = new SqlParameter("@ID_Préstamo", Datos);
                    Parámetros[1] = new SqlParameter("@Pago", Pago + Mora);
                    Parámetros[2] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);
                    Parámetros[3] = new SqlParameter("@Intereses", inte);
                    Parámetros[4] = new SqlParameter("@Capital", Capi);
                    Parámetros[5] = new SqlParameter("@Saldo", Convert.ToDouble(txtSaldo.Text) - Capi);
                    Parámetros[6] = new SqlParameter("@Mora", Mora);
                    Parámetros[7] = new SqlParameter("@Fecha_Límite", Límite);

                    if (ingresar.llenar_tabla("[Realizar Pago]", Parámetros) > 0)
                    {
                        if (Imprimir == DialogResult.Yes)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            Imprimir Acción = new Imprimir(Datos, "Pago");
                            Acción.ShowDialog();
                            Acción.Dispose();
                        }
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
                }
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
            DataTable dt = new DataTable();
            try
            {
                Procedimientos_select pro = new Procedimientos_select();
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                dt = pro.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Monto,Interés", Param, txtNombre, txtMontoMinimo);
                Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                pro.LlenarText("[Cargar Saldo]", "Pago Mínimo", Param, txtSaldo);
                Param[0] = new SqlParameter("@Id_Préstamo", Datos);
                DataTable data = pro.llenar_DataTable("[Conseguir Límite]", Param);
                Límite = Convert.ToDateTime(data.Rows[0]["Límite"]).AddMonths(1);
                Límite = new DateTime(Límite.Year, Límite.Month, 23).AddMinutes(-5);
                txtIdPréstamo.Text = Datos;
            }
            catch { txtMontoMinimo.Text = "0.00"; }
            try
            {
                Monto = Math.Round(Convert.ToDouble(dt.Rows[0]["Monto"]),2);
                Plazo = Math.Round(Convert.ToDouble(dt.Rows[0]["NCuotas"]), 0);
                interes = Convert.ToDouble(dt.Rows[0]["Interés"])/1200;
                nmCantidad.Maximum = Convert.ToDecimal(Math.Round(Convert.ToDouble(txtSaldo.Text) * (1 + interes),2));
            }
            catch
            {
                nmCantidad.Maximum = Convert.ToDecimal(Math.Round(Monto * (1 + interes),2));
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
            if (Límite < DateTime.Now && !arreglandopago)
            {
                txtMora.Text = "2.00"/*Convert.ToString(Convert.ToDouble(txtMontoMinimo.Text) * interes)*/;
                lbMora.Visible = true;
            }
            else
                txtMora.Text = "0.00";
            nmCantidad.Value = nmCantidad.Minimum;
            txtPagoMax.Text = Math.Round(nmCantidad.Maximum, 2).ToString();
            txtMontoMinimo.Text = Math.Round(double.Parse(txtMontoMinimo.Text),2).ToString("C2");
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
