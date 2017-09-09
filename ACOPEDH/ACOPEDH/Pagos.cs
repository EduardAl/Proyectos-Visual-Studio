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
        string Datos, Monto;
        public Pagos()
        {
            InitializeComponent();
            txtMontoMinimo.Text = "1";
            txtSaldo.Text = "200";
        }
        public Pagos(string dato)
        {
            InitializeComponent();
            Datos=dato;
            TextBox txt = new TextBox();
            Procedimientos_select pro = new Procedimientos_select();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@ID_Préstamo", dato);
            pro.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Monto", Param, txtNombre, txtMontoMinimo,txt);
            Param[0] = new SqlParameter("@ID_Préstamo", dato);
            pro.LlenarText("[Cargar Saldo]", "Pago Mínimo", Param, txtSaldo);
            Monto = txt.Text;
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

        private void Pagos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult!=DialogResult.OK)
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            txtIdPréstamo.Text = Datos;
            try
            {
                nmCantidad.Maximum = Convert.ToDecimal(txtSaldo.Text);
            }
            catch
            {
                nmCantidad.Maximum= Convert.ToDecimal(Monto);
                txtSaldo.Text = Monto;
            }
            if (Convert.ToDecimal(txtMontoMinimo.Text) > nmCantidad.Maximum)
            {
                nmCantidad.Minimum = nmCantidad.Maximum;
                txtMontoMinimo.Text = txtSaldo.Text;
            }
            else
                nmCantidad.Minimum = Convert.ToDecimal(txtMontoMinimo.Text);
            nmCantidad.Value = nmCantidad.Minimum;
        }

        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
#warning Añadir Imprimir
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de pago para la siguiente transacción?:\n$" + nmCantidad.Value + "\n N° Préstamo: " + txtIdPréstamo.Text + "\nPersona Asociada: " + txtNombre.Text, "Confirmar Pago", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (Imprimir!= DialogResult.Cancel)
            {
                if(Imprimir==DialogResult.Yes)
                {
                    //Imprimir
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
