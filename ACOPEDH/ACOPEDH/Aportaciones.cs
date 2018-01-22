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
    public partial class Aportaciones : Form
    {
        string Dato, Nombre;
        Procedimientos_select pro = new Procedimientos_select();

        public Aportaciones()
        {
            InitializeComponent();
        }
        public Aportaciones(string dato, string nombre)
        {
            InitializeComponent();
            Dato = dato;
            Nombre = nombre;
        }
        private void Cargar()
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Código_Asociado", Dato);
            dgvAportaciones.DataSource = pro.llenar_DataTable("[Cargar Aportaciones]", Param);
            Param[0] = new SqlParameter("@Código_Asociado", Dato);
            pro.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Param, txtSuma);
            txtSuma.Text = double.Parse(txtSuma.Text).ToString("C2");
            dgvAportaciones.Columns[0].DefaultCellStyle.Format = "C2";
            dgvAportaciones.Sort(dgvAportaciones.Columns[1], ListSortDirection.Ascending);
            dgvAportaciones.Refresh();
        }
        private void Aportaciones_Load(object sender, EventArgs e)
        {
            try
            {
                txtAsociado.Text = Nombre;
                txtCódigo.Text = Dato;
                Cargar();
            }
            catch { }
        }

        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttRealizarAportación_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] Parámetros = new SqlParameter[3];
                Parámetros[0] = new SqlParameter("@Aportación", 5);
                Parámetros[1] = new SqlParameter("@ID_Asociado", Dato);
                Parámetros[2] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);
                if (pro.llenar_tabla("[Realizar Aportación]", Parámetros) > 0)
                {
                    MessageBox.Show(Globales.gbError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }
                else
                    MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globales.gbError = "";
            }
            catch { }
        }
    }
}
