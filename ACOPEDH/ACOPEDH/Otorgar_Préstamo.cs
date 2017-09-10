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
    public partial class Otorgar_Préstamo : Form
    {
#warning FALTA TODO EL CÓDIGO
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        int Cuotas; double Monto, interes;
        List<ComboBox_Llenado> TipoPréstamo = new List<ComboBox_Llenado>();
        #region Constructores
        //Normal
        public Otorgar_Préstamo()
        {
            InitializeComponent();
        }
        #endregion        
        #region Load
        private void Otorgar_Préstamo_Load(object sender, EventArgs e)
        {
            Procedimientos_select Cargar = new Procedimientos_select();
            TipoPréstamo = Cargar.LlenarCombo("[Cargar Tipo Préstamo]", "TipoP,Interés");
            foreach (ComboBox_Llenado element in TipoPréstamo)
            {
                CBTipoPréstamo.Items.Add(element.Nombre);
            }
            if (CBTipoPréstamo.Items.Count > 0)
                CBTipoPréstamo.SelectedIndex = 0;
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Otorgar Préstamo
        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtCódigoP.Text != "")
            {
                //Otorgar Préstamo
            }
            else
                MessageBox.Show("No ha seleccionado a una persona asociada", "Persona Asociada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
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
        //Mostrar Amortización
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Amortización Acción = new Amortización(double.Parse(TxtInterés.Text), Monto, Cuotas);
                Acción.ShowDialog();
                Focus();
            }
            catch
            {
                MessageBox.Show("Aún no ha colocado los datos necesarios para generar una amortización");
            }
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region TextChanged
        //Generar Cuota
        private void txtNoCuota_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TxtMonto.Text, out Monto)
                && int.TryParse(txtNoCuota.Text, out Cuotas)
                && Cuotas > 0
                && double.TryParse(TxtInterés.Text, out interes))
            {
                interes = interes / 1200;
                double Fijo = Math.Pow(1 + interes, Cuotas);
                double cuota = Monto * ((Fijo * interes) / (Fijo - 1));
                txtCuotaMensual.Text = Math.Round(cuota, 2).ToString();
            }
            else
            {
                txtCuotaMensual.Text = "";
            }
        }
        //Búsqueda de Asociado
        private void TxtBúsqueda_TextChanged(object sender, EventArgs e)
        {

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
        #region Closing
        private void Otorgar_Préstamo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                if (MessageBox.Show("¿Desea salir sin guardar cambios?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
        }

        #endregion
        #region CurrentCell
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                TxtCódigoP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TxtAsociadoP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TxtDUIP.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                TxtOcupación.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
                TxtAsociadoP.Clear();
                TxtCódigoP.Clear();
                TxtDUIP.Clear();
                TxtOcupación.Clear();
            }
        }
        #endregion
        #region IndexChanged
        //Cambiar el tipo de préstamo
        private void CBTipoPréstamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtInterés.Text = ComboBox_Llenado.ConseguirInterés(TipoPréstamo, CBTipoPréstamo.Text).ToString();
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
