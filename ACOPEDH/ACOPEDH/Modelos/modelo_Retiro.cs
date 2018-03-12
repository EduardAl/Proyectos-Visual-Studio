using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACOPEDH.Modelos
{
    public class modelo_Retiro
    {
        private double montoRetiro;
        private DateTime fecha_retiro;

        public double MontoRetiro { get => montoRetiro; set => montoRetiro = value; }
        public DateTime Fecha_retiro { get => fecha_retiro; set => fecha_retiro = value; }
    }
}
