using System;

namespace ACOPEDH
{
    public class Globales
    {
        public static String gbCod_TipoUsuario;
        public static String gbTipo_Usuario = "InicioSesion";
        public static String gbClave_Tipo_Usuario = "In112358";
        public static String gbCorreo;
        public static String gbCodUsuario;
        public static String gbNombre_Usuario;
        public static String gbApellido_Usuario;
        public static String gbClaveUsuario;
        public static String gbError = "";
        public static String Servidor;
        public Globales()
        {
        }
        public static void Inicializar(String pCodUsuario, String pTipo_Cuenta, String pClaveCuenta, String pCorreo, String pNombreUsuario, String pApellidoUsuario, String pCod_TipoUsuario, String pClaveUsuario)
        {
            gbTipo_Usuario = pTipo_Cuenta;
            gbClave_Tipo_Usuario = pClaveCuenta;
            gbCorreo = pCorreo;
            gbCodUsuario = pCodUsuario;
            gbClaveUsuario = pClaveUsuario;
            gbCod_TipoUsuario = pCod_TipoUsuario;
            gbNombre_Usuario = pNombreUsuario;
            gbApellido_Usuario = pApellidoUsuario;
        }
    }
}

