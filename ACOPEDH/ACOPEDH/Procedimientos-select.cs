using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ACOPEDH
{
    public class Procedimientos_select
    {
        Conexión cn;
        SqlCommand Comando;
        public void llenar_tabla(string procedimiento, SqlParameter[] param)
        {
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conex = new SqlConnection(cn.cadena))
                {
                    conex.Open();
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = procedimiento;
                    SqlDataAdapter da = new SqlDataAdapter(Comando);
                    for (int x = 0; x < (param.Length); x++)
                        Comando.Parameters.Add(param[x]);
                    Comando.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al intentar extraer los datos." + ex);
            }
        }
#warning PROCEDIMIENTOS CON CONEXION SQL/YIYEL POR PRUEBAS 
        public DataTable llenar_DataTable(string procedimiento)
        {
            cn = new Conexión(Globales.gbTipo_Cuenta, Globales.gbClaveCuenta);
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conex = new SqlConnection(cn.cadena);
                conex.Open();
                Comando = new SqlCommand(procedimiento, conex);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                da.Fill(dt);
                da.Dispose();
                conex.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al intentar extraer los datos." + ex);
            }
            return dt;
        }        
        public DataTable llenar_DataTable(string procedimiento, SqlParameter[] param)
        {
            cn = new Conexión(Globales.gbTipo_Cuenta, Globales.gbClaveCuenta);
            DataTable dt = new DataTable();
            try
            {
               // SqlConnection conex = new SqlConnection(cn.cadena);
                SqlConnection conex = new SqlConnection(@"Data Source = GISSELLE-REYES\YIYEL501;Initial Catalog =ACOPEDH;User=sa;Password=1311");
                conex.Open();
                Comando = new SqlCommand(procedimiento, conex);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                for (int x = 0; x < (param.Length); x++)
                    Comando.Parameters.Add(param[x]);
                da.Fill(dt);
                da.Dispose();
                conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar extraer los datos.\n" + ex.Message);
            }
            return dt;
        }

        public void LlenarText(string procedimiento, string Rows, params String[] Text)
        {
            try
            {
                DataTable Llenado = llenar_DataTable(procedimiento);
                String[] Row = Rows.Split(',');
                DataRow row = Llenado.Rows[0];
                for (int j = 0; j < Text.Length; j++)
                {
                    Text[j] = Convert.ToString(row[Row[j]]);
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LlenarText(string procedimiento, string Rows,SqlParameter[] param, params String[] Text)
        {
            try
            {
                DataTable Llenado = llenar_DataTable(procedimiento, param);
                String[] Row = Rows.Split(',');
                DataRow row = Llenado.Rows[0];
                for(int j=0;j<Text.Length;j++)
                {
                    Text[j]= Convert.ToString(row[Row[j]]);
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<ComboBox_Llenado> LlenarCombo(string procedimiento, string Rows)
        {
            cn = new Conexión(Globales.gbTipo_Cuenta, Globales.gbClaveCuenta);
            List<ComboBox_Llenado> Retornar = new List<ComboBox_Llenado>();
            try
            {
                 //SqlConnection conex = new SqlConnection(cn.cadena);
                SqlConnection conex = new SqlConnection(@"Data Source = GISSELLE-REYES\YIYEL501;Initial Catalog =ACOPEDH;User=sa;Password=1311");
                conex.Open();
                Comando = new SqlCommand(procedimiento, conex);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader DataReader = Comando.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                string[] Row = Rows.Split(',');
                while (DataReader.Read())
                {
                    ComboBox_Llenado Dato = new ComboBox_Llenado();
                    Dato.Nombre = DataReader[Row[0]].ToString();
                    if (Row.Length > 1)
                        Dato.interes = Convert.ToDouble(DataReader[Row[1]]);
                    Retornar.Add(Dato);
                }
                conex.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Retornar;
        }


    }
}
