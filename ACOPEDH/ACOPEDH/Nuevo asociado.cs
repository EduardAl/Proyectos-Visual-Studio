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
    public partial class Nuevo_asociado : Form
    {
        public Nuevo_asociado()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttAceptar_Click(object sender, EventArgs e)
        {
            string datos = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
                txtNombres.Text, txtApellidos.Text, txtDUI.Text, txtNIT.Text,
                dtNacimiento.Text, cbOcupación.Text, cbAsociación.Text, txtDirección.Text);
            if (MessageBox.Show("¿Seguro de ingresar los siguientes datos?: \n" + datos, "Confirmar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Ingresar
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Nuevo_asociado_Load(object sender, EventArgs e)
        {
            if (cbAsociación.Items.Count > 0)
                cbAsociación.SelectedIndex = 0;
            if (cbOcupación.Items.Count > 0)
                cbOcupación.SelectedIndex = 0;
        }

        private void Nuevo_asociado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "Cancelar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    e.Cancel=true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(true)
            {
                
            }
        }
    }
}
