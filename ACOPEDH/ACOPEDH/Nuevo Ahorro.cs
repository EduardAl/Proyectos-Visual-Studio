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

        private void cbBúsqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            labBuscar.Text = cbBúsqueda.Text + ":";
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

        private void Nuevo_Ahorro_Load(object sender, EventArgs e)
        {
            cbBúsqueda.SelectedIndex = 0;
        }

        private void Nuevo_Ahorro_Paint(object sender, PaintEventArgs e)
        {
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), 40, 300, 833, 300);
        }
    }
}
