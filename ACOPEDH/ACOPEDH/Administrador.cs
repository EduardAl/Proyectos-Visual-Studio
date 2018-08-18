using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ACOPEDH
{
    public partial class Administrador : Form
    {
        /*
            *********************************
            *     Componentes iniciales     *
            ********************************* 
        */
        #region Variables
        Fonts F;
        String dgvControl;
        DialogResult dr = DialogResult.Cancel;
        Color Original, Seleccionado, Fuente, FuenteO;
        String Dato,Extra;
        Procedimientos_select Cargar = new Procedimientos_select();
        DataTable dsAhorro, dsPréstamo, dsAsociado,dsTransacciones;
        DataView filtro,filtro1;
        DataTable Gráfica;
        Emailsistema enviarEmail = new Emailsistema();
        bool Cargando = true; 
        public static bool confirmación = false;
        public bool editpass = false;
        public bool editdata = false;
        #endregion
        #region Constructores
        public Administrador()
        {
            InitializeComponent();
            Fuente = PPersonas.ForeColor;
            FuenteO = PPréstamos.ForeColor;
            Seleccionado = PPersonas.BackColor;
            Original = PPréstamos.BackColor;
            Ocultar(PPersonas);
        }
        #endregion

        /*
            *********************************
            *      Botones Principales      *
            ********************************* 
        */
        #region Botones
        private void PPersonas_Click(object sender, EventArgs e)
        {
            if (PPersonas.BackColor != Seleccionado)
            {
                Ocultar(PPersonas);
            }
        }
        private void PAhorros_Click(object sender, EventArgs e)
        {
            if (PAhorros.BackColor != Seleccionado)
            {
                Ocultar(PAhorros);
            }
        }
        private void PPréstamos_Click(object sender, EventArgs e)
        {
            if (PPréstamos.BackColor != Seleccionado)
            {
                Ocultar(PPréstamos);
            }
        }
        private void PUsuarios_Click(object sender, EventArgs e)
        {
            if (PUsuarios.BackColor != Seleccionado)
            {
                Ocultar(PUsuarios);
            }
        }
        private void PVariables_Click(object sender, EventArgs e)
        {
            if (PVariables.BackColor != Seleccionado)
            {
                Ocultar(PVariables);
            }
        }
        #endregion

        /*
            *********************************
            *   Funciones y Procedimientos  *
            ********************************* 
        */
        #region Cargar Datos en nuevos forms
        private bool DatoR()
        {
            if (dgvBúsqueda.SelectedRows.Count == 1)
            {
                try
                {
                    Extra = "";
                    DataGridViewRow dgvv = null;
                    int i = dgvBúsqueda.CurrentCell.RowIndex;
                    dgvv = dgvBúsqueda.Rows[i];
                    Dato = dgvv.Cells[0].Value.ToString();
                    Extra = dgvv.Cells[1].Value.ToString();
                    if (!String.IsNullOrEmpty(Dato))
                        return true;
                }
                catch
                {
                }
            }
            return false;
        }
        #endregion
        #region Botones Principales (Ocultar cosas)
        public void Ocultar(Button botonSelec)
        {
            bool si = false;
            panel2.Visible = false;
            //Colorear
            for (int i = 0; i < panel1.Controls.Count-1; i++)
            {
                panel1.Controls[i].BackColor = Original;
                panel1.Controls[i].ForeColor = FuenteO;
                panel1.Controls[i].Location = (i == 0) ? panel1.Controls[i].Location : (si) ? new Point(panel1.Controls[i].Location.X, panel2.Location.Y + panel2.Height) : new Point(panel1.Controls[i].Location.X, panel1.Controls[i - 1].Location.Y + panel1.Controls[i].Height);
                if (panel1.Controls[i] != botonSelec)
                {
                    si = false;
                }
                else
                {
                    panel2.Location = new Point(panel1.Controls[i].Location.X, botonSelec.Location.Y + botonSelec.Height);
                    si = true;
                }
            }
            botonSelec.BackColor = Seleccionado;
            botonSelec.ForeColor = Fuente;
            panel2.Visible = true;
            //Búsqueda
            labBuscar.Visible = false;
            txtBúsqueda.Visible = false;
            dgvBúsqueda.Visible = false;

            //Botones
            bttRealizarPago.Visible = false;
            bttVerEstados.Visible = false;
            bttDatosAsociado.Visible = false;

            dgvTransacciones.Visible = false;
        }
        #endregion

        /*
           *********************************
           *      Botones Secundarios      *
           ********************************* 
       */
        #region Barra Título
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                toolTip1.SetToolTip(bttMax, "Maximizar");
            }
            else
            {
                toolTip1.SetToolTip(bttMax, "Restaurar a tamaño normal");
                WindowState = FormWindowState.Maximized;
            }
        }
        #endregion

        /*
           *********************************
           *            Eventos            *
           ********************************* 
       */
        #region Cambio de tamaño
        private void Principal_P_SizeChanged(object sender, EventArgs e)
        {
            //Elementos
            Titulo.Location = new Point((Width / 2) - (Titulo.Width / 2) + 93, Titulo.Location.Y);
            dgvBúsqueda.Width = Width - dgvBúsqueda.Location.X - 87;
            dgvBúsqueda.Height = Height - dgvBúsqueda.Location.Y - 116;

            //Botones
            Refresh();
        }
        #endregion
        #region Pintar
        private void Bordes_Paint(object sender, PaintEventArgs e)
        {
            Pen c= (new Pen(Brushes.Purple,2));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width-1, 0), new Point(Width-1, Height-2));
            Linea.DrawLine(c, new Point(1, 0), new Point(1, Height));
            Linea.DrawLine(c, new Point(0, Height-1), new Point(Width, Height-1));
            Linea.DrawLine(c, new Point(Width, 1), new Point(0,1));
        }
        #endregion
        #region Búsqueda
        private void txtBúsqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string salida_datos = "";
                string[] palabra_busqueda = this.txtBúsqueda.Text.Split(' ');
                if (dgvControl == "Ahorro")
                {
                    foreach (string palabra in palabra_busqueda)
                    {
                        if (salida_datos.Length == 0)
                        {
                            salida_datos = "(Dui LIKE '%" + palabra + "%' OR [Código de Ahorro] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Ahorro] LIKE '%" + palabra + "%')";
                        }
                        else
                        {
                            salida_datos += " AND(Dui LIKE '%" + palabra + "%' OR [Código de Ahorro] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Ahorro] LIKE '%" + palabra + "%')";
                        }
                    }
                    this.filtro.RowFilter = salida_datos;
                }
                if (dgvControl == "Préstamo")
                {
                    foreach (string palabra in palabra_busqueda)
                    {
                        if (salida_datos.Length == 0)
                        {
                            salida_datos = "(Dui LIKE '%" + palabra + "%' OR [Código de Préstamo] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Préstamo] LIKE '%" + palabra + "%')";
                        }
                        else
                        {
                            salida_datos += " AND(Dui LIKE '%" + palabra + "%' OR [Código de Préstamo] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Préstamo] LIKE '%" + palabra + "%')";
                        }
                    }
                    this.filtro.RowFilter = salida_datos;
                }
                if (dgvControl == "Asociado")
                {
                    foreach (string palabra in palabra_busqueda)
                    {
                        if (salida_datos.Length == 0)
                        {
                            salida_datos = "(Código LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR Dui LIKE '%" + palabra + "%' OR [Tipo Asociación] LIKE '%" + palabra + "%')";
                        }
                        else
                        {
                            salida_datos += " AND(Código LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR Dui LIKE '%" + palabra + "%' OR [Tipo Asociación] LIKE '%" + palabra + "%')";
                        }
                    }
                    this.filtro.RowFilter = salida_datos;
                }
            }
            catch { }
        }
        #endregion
        #region Closing
        private void Principal_P_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dr == DialogResult.Cancel)
            {
                DialogResult = MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        #endregion
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
        #region Sombra
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
   (
       int nLeftRect, // x-coordinate of upper-left corner
       int nTopRect, // y-coordinate of upper-left corner
       int nRightRect, // x-coordinate of lower-right corner
       int nBottomRect, // y-coordinate of lower-right corner
       int nWidthEllipse, // height of ellipse
       int nHeightEllipse // width of ellipse
    );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                const int CS_DROPSHADOW = 0x00000040;
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }
        #endregion
        #region Efecto botones barra título
        private void bttMin_MouseHover(object sender, EventArgs e)
        {
            bttMin.BackColor = Color.FromArgb(35, 45, 129);
        }

        private void dgvBúsqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bttMin_MouseLeave(object sender, EventArgs e)
        {
            bttMin.BackColor = Seleccionado;
        }

        private void bttMin_MouseDown(object sender, MouseEventArgs e)
        {
            bttMin.BackColor = Color.Blue;
        }

        private void bttMax_MouseDown(object sender, MouseEventArgs e)
        {
            bttMax.BackColor = Color.Blue;
        }

        private void bttMax_MouseHover(object sender, EventArgs e)
        {
            bttMax.BackColor = Color.FromArgb(35, 45, 129);
        }

        private void bttMax_MouseLeave(object sender, EventArgs e)
        {
            bttMax.BackColor = Seleccionado;
        }

        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Seleccionado;
        }

        private void bttCer_MouseHover(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.Red;
        }

        private void bttCer_MouseDown(object sender, MouseEventArgs e)
        {
            bttCer.BackColor = Color.DarkRed;
        }
        #endregion

    }
}