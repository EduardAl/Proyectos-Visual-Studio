using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Crear_Base_de_Datos
{
    public partial class Servidores : Form
    {
        public static DataTable Instancias()
        {
            return SqlDataSourceEnumerator.Instance.GetDataSources();
        }
        public static string Servidor;
        public static string Servidor2;

        public Servidores()
        {
            InitializeComponent();
           
        }

        private void Servidores_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = Instancias();
            Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.No;
            DataGridViewRow dgvv = null;
            try
            {
                a:
                dgvv = dataGridView1.Rows[e.RowIndex];
                Servidor = dgvv.Cells[0].Value.ToString();
                Servidor2 = dgvv.Cells[0].Value.ToString() + @"\" + dgvv.Cells[1].Value.ToString();
                if (String.IsNullOrEmpty(Servidor)||String.IsNullOrEmpty(Servidor2))
                {
                    goto a;
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void Servidores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrEmpty(Servidor) || String.IsNullOrEmpty(Servidor2))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }
        private void Servidores_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            Application.Exit();
        }
    }
}