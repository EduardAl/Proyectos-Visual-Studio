using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Usuarios
    {
        Conexión con = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
        public bool existe(String pttcorreo)
        {
            bool exis = false;
            SqlConnection cn = new SqlConnection(con.cadena);
            SqlCommand cmd;
            try
            {
                cn.Open();
                cmd = new SqlCommand("select * from Usuarios where Correo= '" + pttcorreo + "'", cn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exis = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                SqlError Error = ex.Errors[0];
                MessageBox.Show("Error al conectar.\n" + "Número del error: " + ex.Number + "\nCódigo del error: " + ex.ErrorCode + "\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            cn.Close();
            return exis;
        }
    }
}
