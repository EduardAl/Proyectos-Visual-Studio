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
        private DateTime fechaRetiro;
        private modelo_Retiro Modelo;
        private double montoRetiro;
        private DateTime fecha_Retiro;
        public modelo_Abonos()
        {
            monto = 0;
            AbonoComision = 0;
            montoRetiro = 0;
            fechaRetiro = new DateTime();
            fecha_Retiro = new DateTime();
            Modelo = new modelo_Retiro();
        }
        public modelo_Abonos(double monto, double abono)
        {
            this.monto = monto;
            AbonoComision = abono;
            fechaRetiro = new DateTime();
            Modelo = new modelo_Retiro();
        }
        public double Monto { get => monto; set => monto = value; }
        public double AbonoComision { get => abonoComision; set => abonoComision = value; }
        public DateTime FechaRetiro { get => fechaRetiro; set => fechaRetiro = value; }
        public modelo_Retiro Modelo1 { get => Modelo; set => Modelo = value; }
        public DateTime Fecha_Retiro { get => fecha_Retiro; set => fecha_Retiro = value; }
        public double MontoRetiro { get => montoRetiro; set => montoRetiro = value; }
    }
}
