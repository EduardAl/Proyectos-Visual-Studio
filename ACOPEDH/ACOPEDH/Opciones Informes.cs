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
    public partial class Opciones_Informes : Form
    {
        Imprimir Acción;
        String Codigo;
        public Opciones_Informes(string cod)
        {
            InitializeComponent();
            Codigo = cod;
        }
        #region Botones
        //Constancia de Pago
        private void bttImprimir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Acción = new Imprimir(Codigo,"Carta");
            Acción.ShowDialog();
            Acción.Dispose();
            this.Cursor = Cursors.Default;
        }
        //Pagaré
        private void bttPagaré_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Acción = new Imprimir(Codigo, "Pagaré");
            Acción.ShowDialog();
            Acción.Dispose();
            this.Cursor = Cursors.Default;
        }
        //Hoja de Desembolso
        private void bttDesembolso_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Acción = new Imprimir(Codigo, "Desembolso");
            Acción.ShowDialog();
            Acción.Dispose();
            this.Cursor = Cursors.Default;
        }
        //Recibo de Préstamo
        private void bttRecibo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Acción = new Imprimir(Codigo, "Recibo");
            Acción.ShowDialog();
            Acción.Dispose();
            this.Cursor = Cursors.Default;
        }
        #endregion
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Opciones_Informes_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
