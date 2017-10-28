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
                DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de retiro para la siguiente transacción?:\n$" + nCantidadRetiro.Value + "\n N° Préstamo: " + txtNoCuenta.Text + "\nPersona Asociada: " + txtAsociado.Text, "Confirmar Pago", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Imprimir != DialogResult.Cancel)
                {
                    SqlParameter[] Parámetros = new SqlParameter[4];
                    Parámetros[0] = new SqlParameter("@Retiro", nCantidadRetiro.Value);
                    Parámetros[1] = new SqlParameter("@Número_Cheque", "Generado");
                    Parámetros[2] = new SqlParameter("@FK_Ahorro", Dato);
                    Parámetros[3] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);
                    if (Imprimir == DialogResult.Yes)
                    {
#warning Añadir Imprimir
                    }
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
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 0), new Point(0, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, Height - 1), new Point(Width, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(Width - 1, 0), new Point(Width, Height));
        }
        #endregion
    }
}
