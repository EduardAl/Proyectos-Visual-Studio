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
#warning FALTA GUARDAR EL AHORRO Y LA BÚSQUEDA
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        public static DialogResult dr = DialogResult.Cancel;
        #region Constructores
        public Nuevo_Ahorro()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void Nuevo_Ahorro_Load(object sender, EventArgs e)
        {
            Procedimientos_select Cargar = new Procedimientos_select();
            dgvAsociado.DataSource = Cargar.llenar_DataTable("[Asociado DVG]");
            dgvAsociado.Refresh();
            CBTipoAhorro.DataSource = Cargar.llenar_DataTable("[Cargar Tipo Ahorro]");
            CBTipoAhorro.ValueMember = "Interés";
            CBTipoAhorro.DisplayMember = "TipoA";
            if (CBTipoAhorro.Items.Count > 0)
            {
                CBTipoAhorro.SelectedIndex = 0;
                TxtInterés.Text = CBTipoAhorro.SelectedValue.ToString();
            }
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            if (nmAbono.Value > 0)
            {
                if (string.IsNullOrEmpty(TxtCódigoA.Text))
                {

                    dr = DialogResult.OK;
                }
                else
                    MessageBox.Show("No ha seleccionado a una persona asociada para crear la cuenta\n\n Si no encuentra a la persona, es posible que no posea una cuenta o que haya sido desasociada", "Falta de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("No se puede crear una cuenta de ahorro sin algun abono", "Falta de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        /*
           *********************************
           *            Eventos            *
           ********************************* 
       */
        #region Pintar Bordes
        private void Nuevo_Ahorro_Paint(object sender, PaintEventArgs e)
        {
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 0), new Point(0, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, Height - 1), new Point(Width, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(Width - 1, 0), new Point(Width, Height));
        }
        #endregion
        #region Cambio de Index
        private void CBTipoAhorro_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtInterés.Text = CBTipoAhorro.SelectedValue.ToString();
        }
        #endregion
        #region Cambio de Celda
        private void dgvAsociado_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                TxtCódigoA.Text = dgvAsociado.CurrentRow.Cells[0].Value.ToString();
                TxtAsociadoP.Text = dgvAsociado.CurrentRow.Cells[1].Value.ToString();
                TxtDUIP.Text = dgvAsociado.CurrentRow.Cells[2].Value.ToString();
                TxtOcupación.Text = dgvAsociado.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
                TxtAsociadoP.Clear();
                TxtCódigoA.Clear();
                TxtDUIP.Clear();
                TxtOcupación.Clear();
            }
        }
        #endregion
        #region Closing
        private void Nuevo_Ahorro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dr == DialogResult.Cancel)
                if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "Nuevo Ahorro Cancelado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    e.Cancel=true;
        }
        #endregion

        
    }
}
