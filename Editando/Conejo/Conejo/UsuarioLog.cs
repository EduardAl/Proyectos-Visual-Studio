using System;
using System.Data.SqlClient;
using System.Data;
namespace Conejo
{
    public partial class UsuarioLog
    {
        public String Usuario;
        public String Cod_Tipo_Usuario;
        public String clave;
        public String correo;
        public Conexión conn = new Conexión();
        public UsuarioLog()
        {
        }
        public UsuarioLog(string email, string códigoUsuario)
        {
            this.correo = email;
            this.Cod_Tipo_Usuario = códigoUsuario;
            ObtenerUUsuario(códigoUsuario);
            Globales.Inicializar(códigoUsuario, Usuario, clave, correo);
        }
        public void ObtenerUUsuario(string código)
        {
            Conexión conn = new Conexión();
            SqlConnection cn = new SqlConnection(conn.conec("InicioSesion", "In112358"));
            SqlCommand cmd = new SqlCommand("select Nombre, Clave from [Tipo de Usuarios] where [Id Tipo Usuario]= '" + código + "'", cn);
            //try
         //   { 
                cn.Open();


                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tipo de Usuarios");
                DataRow dro;
                dro = ds.Tables["Tipo de Usuarios"].Rows[0];
                this.Usuario = dro["Nombre"].ToString();
                this.clave = dro["Clave"].ToString();
            //}
            //catch (Exception ex)
            //{
            //    cn.Close();
            //}
            cn.Close();
        }
    }
}