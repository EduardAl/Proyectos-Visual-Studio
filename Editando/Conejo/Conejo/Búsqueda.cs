using System;
using System.Data;
using System.Drawing;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Conejo
{
    public partial class Búsqueda : Form
    {
        Mostrar_Datos Mostrar = new Mostrar_Datos();
        DataSet dsprincipal = new DataSet();
        DataView mifiltro;
        SqlConnection cn = new SqlConnection();
        bool Asoci =false;
        public string Dato = "";
        public Búsqueda(bool Asocia)
        {
            InitializeComponent();
            Asoci = Asocia;
            DialogResult = DialogResult.Abort;
        }

        private void Búsqueda_Load(object sender, EventArgs e)
        {
            txtBusca.Focus();
            string query, tabla;
            if (!Asoci)
            {
                query = "select Ahorro.[id Ahorro] as 'Código de Ahorro', Ahorro.Estado as 'Estado', [Tipo de Ahorro].nombre as 'Tipo de Ahorro', concat(Asociado.Nombres,' ', Asociado.Apellidos) as 'Nombre del Asociado' from Ahorro inner join Asociado on Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] inner join [Tipo de Ahorro] on [Tipo de Ahorro].[id Tipo Ahorro] = Ahorro.[FK Tipo Ahorro]";
                tabla = "Ahorro";
            }
            else
            {
                query = "select Asociado.[Código Asociado], [Tipo de Socio].[Nombre Tipo Socio] as 'Tipo de Socio', concat(Asociado.Nombres,' ', Asociado.Apellidos) as 'Nombre del Asociado', Asociado.DUI from Asociado inner join [Tipo de Socio] on Asociado.[FK Tipo Socio]=[Tipo de Socio].[id Tipo de Socio]";
                tabla = "Asociado";
            }
            Conexión conn = new Conexión("sa", "1311");
            try
            {
                conn.conec("sa", "1311");
                SqlConnection cn = new SqlConnection(conn.cadena);
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsprincipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            mifiltro = ((DataTable)dsprincipal.Tables[tabla]).DefaultView;
            dgv.DataSource = mifiltro;
        }
            private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvv = null;
            try
            {
                a:
                dgvv = dgv.Rows[e.RowIndex];
                Dato = dgvv.Cells[0].Value.ToString();
                if (String.IsNullOrEmpty(Dato))
                {
                    goto a;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabra_busqueda = txtBusca.Text.Split(' ');
            foreach (string palabra in palabra_busqueda)
            {
                if (Asoci)
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "([Nombre del Asociado] LIKE '%" + palabra + "%' OR [Código Asociado] LIKE '%" + palabra + "%' OR DUI LIKE '%" + palabra + "%')";
                    }
                    else
                    {
                        salida_datos += " AND([Nombre del Asociado] LIKE '%" + palabra + "%' OR [Código Asociado] LIKE '%" + palabra + "%' OR DUI LIKE '%" + palabra + "%')";
                    }
                }
                else
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "([Código de Ahorro] LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR [Tipo de Ahorro] LIKE '%" + palabra + "%' OR [Nombre del Asociado] LIKE '%" + palabra + "%')";
                    }
                    else
                    {
                        salida_datos += " AND([Código de Ahorro] LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR [Tipo de Ahorro] LIKE '%" + palabra + "%' OR [Nombre del Asociado] LIKE '%" + palabra + "%')";
                    }
                }
            }
           this.mifiltro.RowFilter = salida_datos;
        }
    }
}
