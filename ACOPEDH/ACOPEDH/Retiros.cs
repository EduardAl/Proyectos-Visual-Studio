using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Retiros : Form
    {
#warning ¿Añadir el cheque?
       /*
           *********************************
           *     Componentes Iniciales     *
           ********************************* 
       */
        string Dato;
        public double Disponible = -1;
        private double aqui = 0;
        Procedimientos_select pro = new Procedimientos_select();
        #region Constructores
        //Normal
        public Retiros()
        {
            InitializeComponent();
        }
        //Con Código
        public Retiros(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        #endregion
        #region Load
        private void Retiros_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@Código_Ahorro", Dato);
                pro.LlenarText("[Cargar Ahorros]", "Nombre", Param, txtAsociado);
                txtNoCuenta.Text = Dato;
                Param[0] = new SqlParameter("@ID_Ahorro", Dato);
                double Abono = Convert.ToDouble(pro.llenar_DataTable("[Suma Abonos]", Param).Rows[0]["Suma de Abonos"]);
                Param[0] = new SqlParameter("@ID_Ahorro", Dato);
                double Retiro = Convert.ToDouble(pro.llenar_DataTable("[Suma Retiros]", Param).Rows[0]["Suma de Retiros"]);
                aqui = Math.Round(Abono - Retiro, 2);
                txtMontoDisponible.Text = aqui.ToString("C2");
                nCantidadRetiro.Maximum = Convert.ToDecimal(txtMontoDisponible.Text.Substring(1));

            }
            catch { }
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Cancelar retiro
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Efectuar retiro
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            if (nCantidadRetiro.Value > 0)
            {
                DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de retiro para la siguiente transacción?:\n$" + nCantidadRetiro.Value + "\n N° Préstamo: " + txtNoCuenta.Text + "\nPersona Asociada: " + txtAsociado.Text, "Confirmar Pago", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Imprimir != DialogResult.Cancel)
                {
                    SqlParameter[] Parámetros = new SqlParameter[4];
                    Parámetros[0] = new SqlParameter("@Retiro", nCantidadRetiro.Value);
                    Parámetros[1] = new SqlParameter("@Número_Cheque", txtCheque.Text);
                    Parámetros[2] = new SqlParameter("@FK_Ahorro", Dato);
                    Parámetros[3] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);

                    if (pro.llenar_tabla("[Realizar Retiros]", Parámetros) > 0)
                    {
                        Disponible = aqui - Convert.ToDouble(nCantidadRetiro.Value);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
                    if (Imprimir == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Imprimir Acción = new Imprimir(Dato, "Retiro");
                        Acción.ShowDialog();
                        Acción.Dispose();
                    }
                }
            }
            else
                MessageBox.Show("Ingrese una cantidad a retirar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Closing
        private void Retiros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                if (MessageBox.Show("¿Está seguro que desea salir sin retirar?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    e.Cancel = true;
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

        private void txtNoCuenta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
