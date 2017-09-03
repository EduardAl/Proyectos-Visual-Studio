using System;

namespace ACOPEDH
{
    public class Globales
    {
        public static string gbTipo_Usuario = "InicioSesion";
        public static string gbClave = "In112358";
        public static string gbCorreo;
        public static string gbCodUsuario;
        public static string Servidor;
        public static string gbCod_TUsuario;
        public Globales()
        {
        }
        public static void Inicializar(String pCodUsuario, String pUsuario, String pClave, String pCorreo)
        {
            gbTipo_Usuario = pUsuario;
            gbClave = pClave;
            gbCorreo = pCorreo;
            gbCodUsuario = pCodUsuario;
        }
    }
}

