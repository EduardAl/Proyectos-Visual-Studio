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
            if (nmCantidadRetiro.Value > 0)
            {
                DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de pago para la siguiente transacción?:\n$" + nmCantidadRetiro.Value + "\n N° Préstamo: " + txtNoCuenta.Text + "\nPersona Asociada: " + txtAsociado.Text, "Confirmar Pago", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Imprimir != DialogResult.Cancel)
                {
                    SqlParameter[] Parámetros = new SqlParameter[4];
                    Parámetros[0] = new SqlParameter("@Abono",nmCantidadRetiro.Value);
                    Parámetros[1] = new SqlParameter("@Fecha_Abono",DateTime.Now);
                    Parámetros[2] = new SqlParameter("@FK_Ahorro", Dato);
                    Parámetros[3] = new SqlParameter("@Id_Usuario",Globales.gbCodUsuario);
                    if (Imprimir == DialogResult.Yes)
                    {
#warning Añadir Imprimir
                    }
                    if (ingresar.llenar_tabla("[Abonar]", Parámetros) > 0)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
