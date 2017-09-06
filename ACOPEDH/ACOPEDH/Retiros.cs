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
    public partial class Retiros : Form
    {
        public Retiros()
        {
            InitializeComponent();
        }

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttAceptar_Click(object sender, EventArgs e)
        {

        }

        private void Retiros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir sin retirar?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
