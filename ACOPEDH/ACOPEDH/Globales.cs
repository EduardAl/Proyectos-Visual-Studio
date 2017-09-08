using System;

namespace ACOPEDH
{
    public class Globales
    {
        public static string gbTipo_Cuenta = "InicioSesion";
        public static string gbClaveCuenta = "In112358";
        public static string gbCorreo;
        public static string gbCodUsuario;
        public static string Servidor;
        public static string gbCod_TipoUsuario;
        public static string gbClaveUsuario;
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

