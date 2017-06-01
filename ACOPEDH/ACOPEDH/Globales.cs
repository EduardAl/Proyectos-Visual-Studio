using System;

namespace ACOPEDH
{
    static class Globales
    {
        public static string gbUsuario = "InicioSesion";
        public static string gbClave = "In112358";
        public static string gbCorreo;
        public static string gbCodUsuario;
        public static string Servidor;
        public static string gbTUsuario;
        public static void Inicializar(String pCodUsuario, String pUsuario, String pClave, String pCorreo)
        {
            gbUsuario = pUsuario;
            gbClave = pClave;
            gbCorreo = pCorreo;
            gbCodUsuario = pCodUsuario;
        }
    }
}

