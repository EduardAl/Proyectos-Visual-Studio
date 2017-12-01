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
                txtSuma.Text = double.Parse(txtSuma.Text).ToString();
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
            try
            {
                DialogResult Imprimir = MessageBox.Show("¿Desea imprimir una constancia de retiro para la siguiente transacción?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Imprimir == DialogResult.Yes || Imprimir == DialogResult.No)
                {
                    if (!String.IsNullOrEmpty(txtCheque.Text))
                    {
                        SqlParameter[] Parámetros = new SqlParameter[4];
                        Parámetros[0] = new SqlParameter("@Código_Asociado", Dato);
                        Parámetros[1] = new SqlParameter("@Total_Retiro", double.Parse(txtSuma.Text));
                        Parámetros[2] = new SqlParameter("No_Cheque", txtCheque.Text);
                        Parámetros[3] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);
                        if (Imprimir == DialogResult.Yes)
                        {
#warning Añadir Imprimir
                        }
                        if (pro.llenar_tabla("[Retirar Aportaciones]", Parámetros) > 0)
                        {
                            Close();
                        }
                        else
                            MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error en la transacción.Inténtelo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
