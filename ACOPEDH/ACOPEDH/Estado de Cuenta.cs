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
            Cargar_Datos();

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
            try
            {
                if (Convert.ToDouble(txtSaldo.Text.Substring(1)) == 0)
                {
                    if (MessageBox.Show("¿Seguro que desea cerrar la cuenta?","Cerrar Cuenta",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        CerrarCuenta();
                    }
                }
                else
                {
                    if(MessageBox.Show("La persona cuenta con dinero disponible en la cuenta\n ¿Desea Retirar la cantidad de $"+txtSaldo.Text+"?","Cuenta de Ahorro",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        Retiros Acción = new Retiros(Dato);
                        Acción.ShowDialog();
                        MessageBox.Show(Acción.DialogResult.ToString());
                        if (Acción.DialogResult == DialogResult.OK)
                        {
                            Cargar_Datos();
                            if (Acción.Disponible == 0)
                            {
                                CerrarCuenta();
                            }
                            else
                                MessageBox.Show("Aún queda dinero disponible en la cuenta, no se puede cerrar","Dinero",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        Acción.Dispose();
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        /*
            *********************************
            *      Métodos y Funciones      *
            ********************************* 
        */
        #region Métodos
        private void CerrarCuenta()
        {
            try
            {
                Procedimientos_select Cargar = new Procedimientos_select();
                SqlParameter[] Parámetros = new SqlParameter[1];

                //Cargar los datos de la cuenta
                Parámetros[0] = new SqlParameter("@Id_Ahorro", Dato);
                if (Cargar.llenar_tabla("Cerrar Ahorro", Parámetros) > 0)
                {
                    MessageBox.Show("La cuenta ha sido cerrada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar_Datos();
                    dr = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Globales.gbError = "";
                }

            }
            catch { }
        }
        private void Cargar_Datos()
        {
            try
            {
                Procedimientos_select Cargar = new Procedimientos_select();
                SqlParameter[] Parámetros = new SqlParameter[1];

                //Cargar los datos de la cuenta
                Parámetros[0] = new SqlParameter("@Código_Ahorro", Dato);
                Cargar.LlenarText("[Cargar Ahorros]", "Nombre,Código_A,Est,TipoA", Parámetros, txtAsociado, txtCódigo, txtEstado, txtTipoA);
                Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);

                //Cargar los registros de Abonos y Retiros a sus respectivos DGV
                dgvAbonos.DataSource = Cargar.llenar_DataTable("[Cargar Abonos]", Parámetros);
                dgvAbonos.Columns[0].DefaultCellStyle.Format = "C2";
                dgvAbonos.Columns[1].DefaultCellStyle.Format = "C2";
                dgvAbonos.Refresh();
                Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);
                dgvRetiros.DataSource = Cargar.llenar_DataTable("[Cargar Retiros]", Parámetros);
                dgvRetiros.Columns[0].DefaultCellStyle.Format = "C2";
                dgvRetiros.Refresh();
                txtCuenta.Text = Dato;

                //Cargar la suma de Abonos y Retiros
                Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);
                Cargar.LlenarText("[Suma Abonos]", "Suma de Abonos", Parámetros, txtAbonos);
                Parámetros[0] = new SqlParameter("@ID_Ahorro", Dato);
                Cargar.LlenarText("[Suma Retiros]", "Suma de Retiros", Parámetros, txtRetiros);
                txtSaldo.Text = Math.Round((double.Parse(txtAbonos.Text) - double.Parse(txtRetiros.Text)), 2).ToString("C2");
                txtAbonos.Text = Math.Round(double.Parse(txtAbonos.Text), 2).ToString("C2");
                txtRetiros.Text = Math.Round(double.Parse(txtRetiros.Text), 2).ToString("C2");
            }
            catch { }
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
