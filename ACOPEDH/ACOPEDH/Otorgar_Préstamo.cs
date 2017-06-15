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
    public partial class Otorgar_Préstamo : Form
    {
        public Otorgar_Préstamo()
        {
            InitializeComponent();
        }
        //Evento que pregunta antes de salir del formulario.
        private void Otorgar_Préstamo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir sin guardar cambios?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true; 
        }

        private void Otorgar_Préstamo_Load(object sender, EventArgs e)
        {

        }
    }
}
