using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACOPEDH
{
    class ConversiónNúmeros
    {
        private string Letter;
        public string Letter1
        {
            get
            {
                return Letter;
            }
            set
            {
                Letter = value;
            }
        }
        public string Decimales(string num)
        {
            string dec="", res;
            double nro;
            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }
            int entero = Convert.ToInt32(Math.Truncate(nro));
            int decimales = Convert.ToInt32(Math.Round((nro - entero)*100,2));
            if(decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }
            res = Convertir(Convert.ToInt32(entero)).ToUpper() + dec;
            return res;
        }
        public string Convertir(int value)//Para convertir numeros
        {
            //Para valores especificos...
            if (value == 0) Letter = "cero";
            else if (value == 1) Letter = "uno";
            else if (value == 2) Letter = "dos";
            else if (value == 3) Letter = "tres";
            else if (value == 4) Letter = "cuatro";
            else if (value == 5) Letter = "cinco";
            else if (value == 6) Letter = "seis";
            else if (value == 7) Letter = "siete";
            else if (value == 8) Letter = "ocho";
            else if (value == 9) Letter = "nueve";
            else if (value == 10) Letter = "diez";
            else if (value == 11) Letter = "once";
            else if (value == 12) Letter = "doce";
            else if (value == 13) Letter = "trece";
            else if (value == 14) Letter = "catorce";
            else if (value == 15) Letter = "quince";
            //Si esta entre 16-19 se añade el dieci y se usa recursividad para el siguiente numero
            else if (value < 20) Letter = "dieci" + Convertir(value - 10);
            else if (value == 20) Letter = "veinte";
            //Si esta entre 21-29 se añade el veinti y se usa recursividad para el siguiente numero
            else if (value < 30) Letter = "veinti" + Convertir(value - 20);
            else if (value == 30) Letter = "treinta";
            else if (value == 40) Letter = "cuarenta";
            else if (value == 50) Letter = "cincuenta";
            else if (value == 60) Letter = "sesenta";
            else if (value == 70) Letter = "setenta";
            else if (value == 80) Letter = "ochenta";
            else if (value == 90) Letter = "noventa";
            else if (value < 100)
            {
                int u = value % 10;//u es el residuo de una division exacta
                Letter = string.Format("{0} y {1}", Convertir(value - u), (Convertir(u)));
                //El primer objeto es para convertir el numero en un multiplo de 10, simplemente restar u para eso
                //El segundo objeto es para el residuo, lo convierte a letras
            }
            else if (value == 100) Letter = "cien";
            else if (value < 200) Letter = "ciento " + Convertir((value - 100));
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800))
                Letter = Convertir(value / 100) + "cientos";
            else if (value == 500) Letter = "quinientos";
            else if (value == 700) Letter = "setecientos";
            else if (value == 900) Letter = "novecientos";
            else if (value < 1000) Letter = string.Format("{0} {1}", Convertir(((value / 100) * 100)), Convertir((value % 100)));
            else if (value == 1000) Letter = "mil";
            return Letter;
        }
    }
}
