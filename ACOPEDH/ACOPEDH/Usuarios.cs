using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Usuarios
    {
        Conexión con = new Conexión(Globales.gbTipo_Cuenta, Globales.gbClaveCuenta);

        public int CrearCuentas(string pnombre, string papellido, string pcontraseña, string pcorreo, string pT_Usuario)
        {
            if (pT_Usuario == "Master")
            {
                pT_Usuario = "TU001";
            }
            if (pT_Usuario == "Administrador")
            {
                pT_Usuario = "TU002";
            }
            if (pT_Usuario == "Usuario")
            {
                pT_Usuario = "TU003";
            }
            int resultado = 0;
            SqlConnection cn = new SqlConnection(con.cadena);
            SqlCommand cmd = new SqlCommand(string.Format("Insert into Usuarios values ('{0}', '{1}', '{2}', '{3}', '{4}' )", pnombre, papellido, Cifrado.encriptar(pcontraseña), pcorreo, pT_Usuario), cn);
            try
            {
                cn.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                SqlError Error = ex.Errors[0];
                MessageBox.Show("Código de error " + Error.Number + "\nMensaje\n" + Error.Message + "\nNivel de error " + Error.Class + "\nEstado " + Error.State, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            cn.Close();
            return resultado;
        }
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
