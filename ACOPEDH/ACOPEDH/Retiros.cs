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
#warning ¿Añadir el cheque?
        /*
           *********************************
           *     Componentes Iniciales     *
           ********************************* 
       */
        string Dato;
        #region Constructores
        //Normal
        public Retiros()
        {
            InitializeComponent();
        }
        //Con Código
        public Retiros(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        #endregion
        #region Load
        private void Retiros_Load(object sender, EventArgs e)
        {
#warning Cargar datos del retiro a efectuar
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Cancelar retiro
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Efectuar retiro
        private void bttAceptar_Click(object sender, EventArgs e)
        {
#warning falta código efectuar el retiro
#warning añadir para imprimir constancia
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Closing
        private void Retiros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                if (MessageBox.Show("¿Está seguro que desea salir sin retirar?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    e.Cancel = true;
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
