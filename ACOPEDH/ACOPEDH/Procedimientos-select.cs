using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ACOPEDH
{
    public class Procedimientos_select
    {
        SqlCommand Comando = new SqlCommand();
        public void llenar_tabla(string procedimiento, SqlParameter[] param)
        {
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conex = new SqlConnection(Conexión.cadena))
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
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conex = new SqlConnection(Conexión.cadena))
                {
                    conex.Open();
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = procedimiento;
                    SqlDataAdapter da = new SqlDataAdapter(Comando);
                    da.Fill(dt);
                    da.Dispose();
                    conex.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al intentar extraer los datos." + ex);
            }

            return dt;
        }
    }
}
