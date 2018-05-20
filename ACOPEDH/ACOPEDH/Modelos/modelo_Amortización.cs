using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACOPEDH.Modelos
{
    public class modelo_Amortización
    {
        private int i;
        private double cuota;
        private double pagoInteres;
        private double pagoCapital;
        private double saldo;
        private DateTime fechaPago;

        public int I { get => i; set => i = value; }
        public double Cuota { get => cuota; set => cuota = value; }
        public double PagoInteres { get => pagoInteres; set => pagoInteres = value; }
        public double PagoCapital { get => pagoCapital; set => pagoCapital = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
    }
}

