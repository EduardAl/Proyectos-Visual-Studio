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
    public partial class Abonos : Form
    {
        string Dato;

        public string Dato1 { get => Dato; set => Dato = value; }

        public Abonos()
        {
            InitializeComponent();
        }
        public Abonos(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void bttAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
