using System;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conejo
{
    public partial class RevisarEstados : Form
    {
        Mostrar_Datos Mostrar = new Mostrar_Datos();

        public RevisarEstados()
        {
            InitializeComponent();
            Focus();
            Búsqueda buscar = new Búsqueda(false);
            buscar.ShowDialog();
            if (buscar.DialogResult != DialogResult.OK)
                Close();
            txtCodigoAhorro.Text = buscar.Dato;
        }
        public RevisarEstados(string Código)
        {
            InitializeComponent();
            Focus();
            txtCodigoAhorro.Text = Código;
        }

        private void RevisarEstados_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void bttVerdatos_Click_1(object sender, EventArgs e)
        {
            Asociado aso = new Asociado(txtAsociación.Text);
            Visible = false;
            aso.ShowDialog();
            Visible = true;
            cargar();
        }

        private void bttRegistros_Click_1(object sender, EventArgs e)
        {
            Aportaciones Aporto = new Aportaciones(txtAsociación.Text);
            Visible = false;
            Aporto.ShowDialog();
            Visible = true;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
#warning Añadir Imprimir
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
        private void cargar()
        {
            string query = "SELECT Asociado.Nombres, Asociado.Apellidos, Asociado.[Código Asociado],"
                           + " Ahorro.Estado, [Tipo de Ahorro].[Nombre] FROM Ahorro"
                           + " INNER JOIN[Asociado] ON Ahorro.[FK Código de Asociado]= Asociado.[Código Asociado]"
                           + " INNER JOIN[Tipo de Ahorro] ON Ahorro.[FK Tipo Ahorro]=[Tipo de Ahorro].[id Tipo Ahorro]"
                           + " where Ahorro.[id Ahorro] = '" + txtCodigoAhorro.Text + "'";
            Mostrar.LlenarTextBox(query, "Nombres,Apellidos,Código Asociado,Nombre,Estado", txtNombres, txtApellidos, txtAsociación, txtTipoAhorro, txtEstadoAhorro);

            if (txtEstadoAhorro.Text == "A")
                txtEstadoAhorro.Text = "Activo";
            else if (txtEstadoAhorro.Text == "I")
                txtEstadoAhorro.Text = "Inactivo";
            decimal i, j, k;
            i = Mostrar.Suma("Aportaciones.Aportación", "Aportaciones", "Aportaciones.[FK Asociado]", txtAsociación.Text);
            j = Mostrar.Suma("Abono.Abono", "Abono", "Abono.[FK Ahorro]", txtCodigoAhorro.Text);
            k = Mostrar.Suma("Retiros.Retiro", "Retiros", "Retiros.[FK Ahorro]", txtCodigoAhorro.Text);
            txtTotalAportaciones.Text = "$" + Math.Round(i, 2).ToString();
            txtAbonos.Text ="$"+ Math.Round(j,2).ToString();
            txtRetiros.Text = "$" + Math.Round(k, 2).ToString();
            txtSaldo.Text = Math.Round(i + j - k,2 ).ToString();
            query = "Select [Fecha de Abono], Abono From Abono where [FK Ahorro]='" + txtCodigoAhorro.Text + "' Order by [Fecha de Abono]";
            Mostrar.CargarDatos(query, dgvAhorros);
            query = "Select [Fecha de Retiro], Retiro From Retiros where [FK Ahorro]='" + txtCodigoAhorro.Text + "' Order by [Fecha de Retiro]";
            Mostrar.CargarDatos(query, dgvRetiros);
        }
        
    }
}
