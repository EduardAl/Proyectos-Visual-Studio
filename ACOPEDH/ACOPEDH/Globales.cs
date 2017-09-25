using System;

namespace ACOPEDH
{
    public class Globales
    {
        public static String gbTipo_Cuenta = "InicioSesion";
        public static String gbClaveCuenta = "In112358";
        public static String gbCorreo;
        public static String gbCodUsuario;
        public static String Servidor;
        public static String gbCod_TipoUsuario;
        public static String gbClaveUsuario;
        public static String gbError = "";
        public Globales()
        {
        }
        public void Inicializar(String pCodUsuario, String pTipo_Cuenta, String pClaveCuenta, String pCorreo, String pCod_TipoUsuario, String pClaveUsuario)
        {
            gbTipo_Cuenta = pTipo_Cuenta;
            gbClaveCuenta = pClaveCuenta;
            gbCorreo = pCorreo;
            gbCodUsuario = pCodUsuario;
            gbClaveUsuario = pClaveUsuario;
            gbCod_TipoUsuario = pCod_TipoUsuario;

        }
    }
}

