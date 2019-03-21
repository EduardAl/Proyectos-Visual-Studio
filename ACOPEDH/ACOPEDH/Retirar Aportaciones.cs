using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Retirar_Aportaciones : Form
    {
        string Dato;
        double suma;
        public bool enabled = false;
        Procedimientos_select pro = new Procedimientos_select();
        public DialogResult dr = DialogResult.Cancel;

        public Retirar_Aportaciones()
        {
            InitializeComponent();
        }
        public Retirar_Aportaciones(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        private void Retirar_Aportaciones_Load(object sender, EventArgs e)
        {
            try
            {
                txtCódigo.Text = Dato;
                SqlParameter[] Parámetro = new SqlParameter[1];
                Parámetro[0] = new SqlParameter("@Código_Asociado", Dato);
                pro.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Parámetro, txtSuma);
                suma = double.Parse(txtSuma.Text);
                txtSuma.Text = double.Parse(txtSuma.Text).ToString("C2");
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error cargando la suma de las Aportaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttRealizarAportación_Click(object sender, EventArgs e)
        {

            //double suma = Convert.ToDouble(txtSuma.Text);
            //MessageBox.Show(txtSuma.Text);
            SqlParameter[] Parámetros = new SqlParameter[3];
            Parámetros[0] = new SqlParameter("@Código_Asociado", Dato);
            Parámetros[1] = new SqlParameter("@No_Cheque", txtCheque.Text);
            Parámetros[2] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);
            if (pro.llenar_tabla("[Retirar Aportaciones]", Parámetros) > 0)
            {
                Parámetros = new SqlParameter[1];
                Parámetros[0] = new SqlParameter("@Código_Asociado", Dato);
                if (pro.llenar_tabla("[Desasociar]", Parámetros) > 0)
                {
                    DialogResult = DialogResult.OK;
                    enabled = true;
                    this.Cursor = Cursors.WaitCursor;
                    Imprimir Acción = new Imprimir(Dato, "Retiro Aportaciones");
                    Acción.ShowDialog();
                    Acción.Dispose();
                    Close();
                }
                else
                {
                    MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Globales.gbError = "";
                }
            }
            else
            {
                MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globales.gbError = "";
            }
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

        public bool Enabled1 { get => enabled; set => enabled = value; }
        public bool Enabled2 { get => enabled; set => enabled = value; }
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

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
