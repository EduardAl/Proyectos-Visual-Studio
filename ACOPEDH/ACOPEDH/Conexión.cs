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
        public string usuario = "InicioSesion";
        public string clave = "In112358";
        public string db = "ACOPEDH";
        public string cadena;
        /// <summary>
        /// Constructor de clase que contiene la cadena de conexión por defecto
        /// </summary>
        public Conexión()
        {
            cadena = @"Data Source = " + Globales.Servidor + ";Initial Catalog =" + db + ";User=" + usuario + ";Password=" + clave;
        }
        /// <summary>
        /// constructor de clase que contiene la cadena de conexión con parametros modificables
        /// </summary>
        /// <param name="pusuario">Nombre de usuario de base de datos</param>
        /// <param name="pclave">Contraseña de usuario</param>
        public Conexión(string pusuario, string pclave)
        {
            this.usuario = pusuario;
            this.clave = pclave;
            cadena = @"Data Source = " + Globales.Servidor + ";Initial Catalog =" + db + ";User=" + usuario + ";Password=" + clave;
        }
    }
}
