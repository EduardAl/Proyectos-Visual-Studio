using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ACOPEDH
{
    public partial class RecuperarCuenta : Form
    {
        Usuarios usuarios = new Usuarios();
        Conexión con = new Conexión();
        Procedimientos_select ps = new Procedimientos_select();
        static String contraseña;
        static String contraseñac;
        static String Asunto = "ACOPEDH - Recuperar cuenta";
        public RecuperarCuenta()
        {
            InitializeComponent();
        }

        private void RecuperarCuenta_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(480, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 35);
            this.Height = SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 35;
            this.Visible = true;
            CenterToScreen();
        }

        private void RecuperarCuenta_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void bttCer_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void bttConfirmar_Click(object sender, EventArgs e)
        {
            contraseña = Cifrado.CreateRandomPassword(8);
            contraseñac = Cifrado.encriptar(contraseña);
            if (Validaciones.validar_correo(ref txtCorreo, ref errorProvider1))
            {
                if (usuarios.existe(txtCorreo.Text))
                {
                    try
                    {
                        SqlParameter[] parámetros = new SqlParameter[2];
                        parámetros[0] = new SqlParameter("@Correo", txtCorreo.Text);
                        parámetros[1] = new SqlParameter("@Contraseña", contraseñac);
                        String Mensaje = "Su nueva contraseña: " + contraseña + "\n\nEste correo ha sido generado automáticamente.\nPor favor, no responder.";
                        MessageBox.Show(contraseña);
                        ps.llenar_tabla("Recuperar Contraseña", parámetros);
                        Emailsistema ES = new Emailsistema();
                        ES.EnviarEmail(txtCorreo, Asunto, Mensaje);
                        MessageBox.Show("Se ha enviado un mensaje a " + txtCorreo.Text + " con su nueva contraseña.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ha habido un problema al intetar recuperar su cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    errorProvider1.SetError(txtCorreo, "No se ha encontrado ninguna cuenta con esta dirección de correo electrónico");
                }
            }
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            Validaciones.validar_correo(ref txtCorreo, ref errorProvider1);
        }
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
    }
}
