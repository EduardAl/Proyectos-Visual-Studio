using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ACOPEDH
{
    class Conexión
    {
        Servidor server = new Servidor();
        public string usuario = "InicioSesion";
        public string clave = "In112358";
        public string db = "ACOPEDH";
        public string cadena;
        public Conexión()
        {
            cadena = @"Data Source = " + Globales.Servidor + ";Initial Catalog =" + db + ";User=" + usuario + ";Password=" + clave;
        }
        public Conexión(string pusuario, string pclave)
        {
            this.usuario = pusuario;
            this.clave = pclave;
            cadena = @"Data Source = " + Globales.Servidor + ";Initial Catalog =" + db + ";User=" + usuario + ";Password=" + clave;
        }
    }
}
