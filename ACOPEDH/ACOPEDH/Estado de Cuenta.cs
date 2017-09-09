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
    public partial class Estado_de_Cuenta : Form
    {
        string Dato;


        public Estado_de_Cuenta()
        {
            InitializeComponent();
        }
        public Estado_de_Cuenta(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttCerrarCuenta_Click(object sender, EventArgs e)
        {
            //Cerrar cuenta
        }
    }
}
