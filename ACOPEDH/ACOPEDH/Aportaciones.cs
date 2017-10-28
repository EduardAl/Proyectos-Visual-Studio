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
        string Dato;
        public Aportaciones()
        {
            InitializeComponent();
        }
        public Aportaciones(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }

        private void Aportaciones_Load(object sender, EventArgs e)
        {
            try
            {
                Procedimientos_select pro = new Procedimientos_select();
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@Código_Asociado", Dato);
                dgvAportaciones.DataSource = pro.llenar_DataTable("[Cargar Aportaciones]", Param);
                Param[0] = new SqlParameter("@Código_Asociado", Dato);
                pro.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Param, txtSuma);
                txtSuma.Text = double.Parse(txtSuma.Text).ToString("C2");
                dgvAportaciones.Sort(dgvAportaciones.Columns[1], ListSortDirection.Ascending);
                dgvAportaciones.Refresh();
            }
            catch { }
        }
    }
}
