using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACOPEDH.Modelos
{
    public class modelo_Abonos
    {
        private double monto;
        private double abonoComision;
        private DateTime fechaAbono;

        public double Monto { get => monto; set => monto = value; }
        public double AbonoComision { get => abonoComision; set => abonoComision = value; }
        public DateTime FechaAbono { get => fechaAbono; set => fechaAbono = value; }

    }
}
