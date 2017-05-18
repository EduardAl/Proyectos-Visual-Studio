using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Conejo
{
    public partial class Cuentas
    {
        Conexión conn = new Conexión();
        public int CrearCuentas(string pnombre, string papellido, string pcontraseña, string pcorreo, string pT_Usuario, string pseguridad)
        {
            if (pT_Usuario == "Master")
            {
                pT_Usuario = "TU001";
            }
            if (pT_Usuario == "Administrador")
            {
                pT_Usuario = "TU002";
            }
            if(pT_Usuario == "Usuario")
            {
                pT_Usuario = "TU003";
            }
            int resultado = 0;
            //conn.conec(Globales.gbUsuario, Globales.gbClave);
            SqlConnection cn = new SqlConnection(conn.conec("InicioSesion", "In112358"));
             SqlCommand cmd = new SqlCommand(string.Format("Insert into Usuarios values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", pnombre, papellido, cifrado.encriptar(pcontraseña, pseguridad), pcorreo, pT_Usuario, pseguridad), cn);
            try
            {
                cn.Open();
               resultado = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                SqlError Error = ex.Errors[0];
                MessageBox.Show("Código de error " + Error.Number + "\nMensaje\n"+Error.Message+"\nNivel de error "+Error.Class+"\nEstado "+Error.State, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            cn.Close();
            return resultado;
        }
        public bool existe(String pttcorreo)
        {
            bool exis = false;
            SqlConnection cn = new SqlConnection(conn.conec("InicioSesion", "In112358"));
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
                MessageBox.Show("Código de error: " + Error.Number + "\nMensaje\n" + Error.Message + "\nNivel de error " + Error.Class + "\nEstado " + Error.State, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            cn.Close();
            return exis;
        }
        public string devolverID(String pCorreo)
        {
            String ID = null;
            conn.conec("InicioSesion", "In112358");
            SqlConnection cn = new SqlConnection(conn.cadena);
            SqlCommand cmd;
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                SqlError Error = ex.Errors[0];
                MessageBox.Show("Código de error " + Error.Number + "\nMensaje\n" + Error.Message + "\nNivel de error " + Error.Class + "\nEstado " + Error.State, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            cmd = new SqlCommand("select [Id Usuario] from Usuarios where Correo= '" + pCorreo + "'", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
               ID = dr["Id Usuario"].ToString();
            }
            dr.Close();
            cn.Close();
            return ID;
        }
        public bool actualizar(string tabla, string campos, string condición)
        {
            SqlConnection cn = new SqlConnection(conn.cadena);
            SqlCommand cmd;
            try
            {
                cn.Open();
                string actualizar = "update " + tabla + " set " + campos + " where " + condición;
                cmd = new SqlCommand(actualizar, cn);
                int i = cmd.ExecuteNonQuery();
                cn.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
