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
    public partial class Nuevo_Ahorro : Form
    {

        public Nuevo_Ahorro()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bttCrear_Click(object sender, EventArgs e)
        {

        }

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        private void Nuevo_Ahorro_Paint(object sender, PaintEventArgs e)
        {
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), 40, 300, 833, 300);
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0,0),new Point(0,Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0,Height-1),new Point(Width,Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(Width-1,0),new Point(Width,Height));
        }
    }
}
