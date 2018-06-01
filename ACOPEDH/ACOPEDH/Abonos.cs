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
    public partial class Abonos : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Dato;
        double interes = 0;
        bool imprimir = false;
        Procedimientos_select ingresar = new Procedimientos_select();
        #region Constructores
        public Abonos()
        {
            InitializeComponent();
        }
        public Abonos(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        #endregion
        #region Load
        private void Abonos_Load(object sender, EventArgs e)
        {
            Procedimientos_select pro = new Procedimientos_select();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Código_Ahorro", Dato);
            pro.LlenarText("[Cargar Ahorros]", "Nombre,Interés", Param, txtAsociado,txtTasa);
            txtNoCuenta.Text = Dato;
            interes = Convert.ToDouble(txtTasa.Text);
            txtTasa.Text = txtTasa.Text + "%";
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Cancelar Abono
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();

        }
        //Realizar Abono
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            if (nmCantidadAbono.Value > 0)
            {
                DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de abono para la siguiente transacción?:\n$" + nmCantidadAbono.Value + "\n N° Préstamo: " + txtNoCuenta.Text + "\nPersona Asociada: " + txtAsociado.Text, "Confirmar Pago", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Imprimir != DialogResult.Cancel)
                {
                    double Convertir = Convert.ToDouble(nmCantidadAbono.Value);
                    double comision = Math.Round(Convertir * interes/100 + Convertir, 2);
                    SqlParameter[] Parámetros = new SqlParameter[4];
                    Parámetros[0] = new SqlParameter("@Abono",Convertir);
                    Parámetros[1] = new SqlParameter("@Comision",comision);
                    Parámetros[2] = new SqlParameter("@FK_Ahorro", Dato);
                    Parámetros[3] = new SqlParameter("@Id_Usuario",Globales.gbCodUsuario);
                    if (ingresar.llenar_tabla("[Abonar]", Parámetros) > 0)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                        imprimir = true;
                    }
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                        imprimir = false;
                    }
                    if (Imprimir == DialogResult.Yes && imprimir == true)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Imprimir Acción = new Imprimir(Dato, "Abono");
                        Acción.ShowDialog();
                        Acción.Dispose();
                    }
                }
            }
            else
                MessageBox.Show("Ingrese una cantidad a abonar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
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
