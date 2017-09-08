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
    }
}
