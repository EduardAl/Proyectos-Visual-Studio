using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Pagos_Realizados : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Datos;
        Fonts F;

        #region Constructores
        //Solo iniciando
        public Pagos_Realizados()
        {
            InitializeComponent();
        }
        //Con código de préstamo
        public Pagos_Realizados(string datos)
        {
            InitializeComponent();
            Datos = datos;
            txtIDPréstamo.Text = Datos;
        }
        #endregion
        #region load
        private void Pagos_Realizados_Load(object sender, EventArgs e)
        {
            try
            {
                Procedimientos_select pro = new Procedimientos_select();
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                dgvPagosRealizados.DataSource = pro.llenar_DataTable("[Cargar Pagos]", Param);
                Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                pro.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Monto,FechaT,NCuotas,TipoP,Estado,Interés", Param, txtAsociado, txtCuotaMensual, txtMonto, txtOtorgamiento, txtPlazo, txtTipoPréstamo, txtEstado, txtTInterés);
                dgvPagosRealizados.Sort(dgvPagosRealizados.Columns[0], ListSortDirection.Ascending);
                dgvPagosRealizados.Columns[1].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[2].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[3].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[4].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Columns[5].DefaultCellStyle.Format = "C2";
                dgvPagosRealizados.Refresh();
                txtMonto.Text = Math.Round(Convert.ToDouble(txtMonto.Text),2).ToString("C2");
                txtCuotaMensual.Text = Math.Round(Convert.ToDouble(txtCuotaMensual.Text),2).ToString("C2");
                F = new Fonts(dgvPagosRealizados);
                if (txtEstado.Text == "CANCELADO")
                    bttRefinanciar.Visible = false;
                F.Diseño();
            }
            catch { }
            Visible = true;
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Minimizar
        private void bttMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void bttMin_MouseHover(object sender, EventArgs e)
        {
            bttMin.BackColor = Color.FromArgb(35, 45, 129);
        }

        private void bttMin_MouseLeave(object sender, EventArgs e)
        {
            bttMin.BackColor = Color.FromArgb(20, 25, 72);
        }

        private void bttMin_MouseDown(object sender, MouseEventArgs e)
        {
            bttMin.BackColor = Color.Blue;
        }
        //Cerrar
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.FromArgb(20, 25, 72);
        }
        private void bttCer_MouseHover(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.Red;
        }
        private void bttCer_MouseDown(object sender, MouseEventArgs e)
        {
            bttCer.BackColor = Color.DarkRed;
        }
        //Imprimir
        private void bttImprimir_Click(object sender, EventArgs e)
        {
            Imprimir Acción = new Imprimir(Datos, "Pagos_Realizados");
            this.Cursor = Cursors.WaitCursor;
            Acción.ShowDialog();
            Acción.Dispose();
            this.Cursor = Cursors.Default;
        }
        //Refinanciar el Préstamo. 
        private void bttRefinanciar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea continuar con el procedimiento para refinanciar este préstamo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Procedimientos_select pro = new Procedimientos_select();
                SqlParameter[] Param = new SqlParameter[2];
                Param[0] = new SqlParameter("@Id_Préstamo", Datos);
                Param[1] = new SqlParameter("@Id_Usuario", Globales.gbCodUsuario);
                pro.llenar_tabla("[Cerrar Préstamo]", Param);
                Otorgar_Préstamo Acción = new Otorgar_Préstamo();
                //Abrimos el Form para otorgar un nuevo préstamo
                Acción.Show();
            }
        }

        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Mover Form
        bool Empezarmover = false;
        int PosX;
        int PosY;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = true;
                PosX = e.X;
                PosY = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Empezarmover)
            {
                Point temp = new Point();
                temp.X = Location.X + (e.X - PosX);
                temp.Y = Location.Y + (e.Y - PosY);
                Location = temp;
            }
        }
        #endregion
        #region Pintar Bordes
        private void Bordes_Paint(object sender, PaintEventArgs e)
        {
            Pen c = (new Pen(Brushes.Purple, 2));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width - 1, 0), new Point(Width - 1, Height - 2));
            Linea.DrawLine(c, new Point(1, 0), new Point(1, Height));
            Linea.DrawLine(c, new Point(0, Height - 1), new Point(Width, Height - 1));
            Linea.DrawLine(c, new Point(Width, 1), new Point(0, 1));
        }
        #endregion
        #region Sombra
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        #endregion


    }
}
