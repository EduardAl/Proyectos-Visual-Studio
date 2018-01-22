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
    public partial class Registros : Form
    {
        String Dato;

        public Registros(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }

        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Registros_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Abrir("");
        }

        private void Cargar()
        {
            try
            {

            }
            catch
            {

            }
        }
        private void Abrir(string Celda)
        {
            switch(Celda)
            {
                case "":
                    break;
                case "1":
                    break;
                case "2":
                    break;
                default:
                    break;
            }
        }
    }
}
