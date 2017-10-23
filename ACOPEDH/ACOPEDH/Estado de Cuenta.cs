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
    public partial class Estado_de_Cuenta : Form
    {
#warning Falta implementar el cerrado de la cuenta
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Dato;
        DataTable dt;
        public DialogResult dr = DialogResult.Cancel;
        #region Componentes
        public Estado_de_Cuenta()
        {
            InitializeComponent();
        }
        public Estado_de_Cuenta(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        #endregion
        #region Load
        private void Estado_de_Cuenta_Load(object sender, EventArgs e)
        {
            Procedimientos_select Cargar = new Procedimientos_select();
            SqlParameter[] Parámetros = new SqlParameter[1];

            //Cargar los datos de la cuenta
            Parámetros[0] = new SqlParameter("@Código_Ahorro", Dato);
            Cargar.LlenarText("[Cargar Ahorros]","Nombre,Código_A,Est,TipoA",Parámetros,txtAsociado,txtCódigo,txtEstado,txtTipoA);
            Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);

            //Cargar los registros de Abonos y Retiros a sus respectivos DGV
            dgvAbonos.DataSource = Cargar.llenar_DataTable("[Cargar Abonos]",Parámetros);
            dgvAbonos.Refresh();
            Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);
            dgvRetiros.DataSource = Cargar.llenar_DataTable("[Cargar Retiros]",Parámetros);
            dgvRetiros.Refresh();
            txtCuenta.Text = Dato;

            //Cargar la suma de Abonos y Retiros
            try
            {
                Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);
                Cargar.LlenarText("[Suma Abonos]", "Suma de Abonos", Parámetros, txtAbonos);
                Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);
                Cargar.LlenarText("[Suma Retiros]", "Suma de Retiros", Parámetros, txtRetiros);
                txtSaldo.Text = "$" + (Math.Round((double.Parse(txtAbonos.Text) - double.Parse(txtRetiros.Text)),2));
                txtAbonos.Text = "$" + Math.Round(double.Parse(txtAbonos.Text),2);
                txtRetiros.Text = "$" + Math.Round(double.Parse(txtRetiros.Text), 2);
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
        //Cerrar
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Cerrar Cuenta
        private void bttCerrarCuenta_Click(object sender, EventArgs e)
        {
            dr = DialogResult.Yes;
            //Cerrar cuenta
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
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 0), new Point(0, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, Height - 1), new Point(Width, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(Width - 1, 0), new Point(Width, Height));
        }
        #endregion

    }
}
