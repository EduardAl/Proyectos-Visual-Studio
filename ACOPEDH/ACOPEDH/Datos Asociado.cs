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
#warning FALTA TODO EL CÓDIGO
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Dato;
        #region Constructores
        //Normal
        public Datos_Asociado()
        {
            InitializeComponent();
        }
        //Con Código Asociado
        public Datos_Asociado(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Ingresar Número
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //Modificar Número
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //Eliminar Número
        private void button3_Click(object sender, EventArgs e)
        {

        }
        //Verificar si modificó y cerrar
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            if (!bttModificar.Enabled)
            {

            }
            Close();
        }
        //Cancelar Modificación
        private void bttCancelar_Click(object sender, EventArgs e)
        {

        }
        //Habilitar Modificaciones
        private void bttModificar_Click(object sender, EventArgs e)
        {

        }
        //Desasociar
        private void bttDesasociar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Closing
        private void Datos_Asociado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)//Si se cancelo la modificación
                if (MessageBox.Show("¿Salir sin guardar cambios?", "Cancelar cambios", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    e.Cancel = true;
        }
        #endregion
        #region Cambio de celda
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Pintar Bordes
        private void Bordes_Paint(object sender, PaintEventArgs e)
        {
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 0), new Point(0, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, Height - 1), new Point(Width, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(Width - 1, 0), new Point(Width, Height));
        }
        #endregion
    }

}
