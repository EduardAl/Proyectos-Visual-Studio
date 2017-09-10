using System.Collections.Generic;

namespace ACOPEDH
{
    public class ComboBox_Llenado
    {
        public string Nombre;
        public double interes;
        public static double ConseguirInterés(List<ComboBox_Llenado> lleno,string hallar)
        {
            ComboBox_Llenado hallado = new ComboBox_Llenado();
            foreach(ComboBox_Llenado encontrar in lleno)
            {
                if(encontrar.Nombre==hallar)
                {
                    hallado = encontrar;
                    break;
                }
            }
            return hallado.interes;
        }
    }
}
