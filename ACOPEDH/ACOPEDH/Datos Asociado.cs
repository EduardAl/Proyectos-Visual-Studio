using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Datos_Asociado : Form
    {
        string Dato;
        public Datos_Asociado()
        {
            InitializeComponent();
        }
        public Datos_Asociado(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }

    }

}
