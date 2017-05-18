namespace Conejo
{
    public partial class Conexión
    {
        public string servidor = Globales.Servidor;
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
        }
        // función que tendrá la cadena de conexión
        public string conec(string Pusuario, string Pclave)
        {
            this.usuario = Pusuario;
            this.clave = Pclave;
            this.servidor = Globales.Servidor;
            return cadena = @"Data Source = " + servidor + ";Initial Catalog =" + db + ";User=" + usuario+";Password=" + clave;
        }
        public void reset()
        {
         servidor = "EDUARD-PC";
         usuario = "InicioSesion";
        clave = "In112358";
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + db;
        }
    }
}