using System;

namespace ACOPEDH
{
    static class Globales
    {
        public static string gbUsuario;
        public static string gbClave;
        public static string gbCorreo;
        public static string gbCodUsuario;
        public static string Servidor;
        public static void Inicializar(String pCodUsuario, String pUsuario, String pClave, String pCorreo)
        {
            gbUsuario = pUsuario;
            gbClave = pClave;
            gbCorreo = pCorreo;
            gbCodUsuario = pCodUsuario;
        }
    }
}

