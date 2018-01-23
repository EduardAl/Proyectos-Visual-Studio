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
                    if (Imprimir == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Imprimir Acción = new Imprimir(Dato, "Abono");
                        Acción.ShowDialog();
                        Acción.Dispose();
                    }
                    if (ingresar.llenar_tabla("[Abonar]", Parámetros) > 0)
                    {
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
