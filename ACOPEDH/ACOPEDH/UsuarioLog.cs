﻿using System;
using System.Data.SqlClient;
using System.Data;
namespace ACOPEDH
{
    public partial class UsuarioLog
    {
        public String Usuario;
        public String Cod_Tipo_Usuario;
        public String clave;
        public String correo;
        public UsuarioLog()
        {
        }
        public UsuarioLog(string email, string códigoUsuario)
        {
            this.correo = email;
            this.Cod_Tipo_Usuario = códigoUsuario;
            ObtenerUsuario(códigoUsuario);
            Globales.Inicializar(códigoUsuario, Usuario, clave, correo);
        }
        public void ObtenerUsuario(string código)
        {
            Conexión con = new Conexión("InicioSesión", "In112358");
            SqlConnection cn = new SqlConnection(con.cadena);
            SqlCommand cmd = new SqlCommand("select Nombre, Clave from [Tipo de Usuarios] where [Id Tipo Usuario]= '" + código + "'", cn);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tipo de Usuarios");
                DataRow dro;
                dro = ds.Tables["Tipo de Usuarios"].Rows[0];
                this.Usuario = dro["Nombre"].ToString();
                this.clave = dro["Clave"].ToString();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
            cn.Close();
        }
    }
}