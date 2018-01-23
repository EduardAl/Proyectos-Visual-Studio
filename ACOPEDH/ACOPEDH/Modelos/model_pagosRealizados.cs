using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACOPEDH.Modelos
{
    public class model_pagosRealizados
    {
        private int n_pagos;
        private double pago;
        private double pagoIntereses;
        private double pagoCapital;
        private double mora;
        private double saldo;
        private DateTime fechaPago;
        private DateTime fechaLimite;

        public int N_pagos { get => n_pagos; set => n_pagos = value; }
        public double Pago { get => pago; set => pago = value; }
        public double PagoIntereses { get => pagoIntereses; set => pagoIntereses = value; }
        public double PagoCapital { get => pagoCapital; set => pagoCapital = value; }
        public double Mora { get => mora; set => mora = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
    }
}
