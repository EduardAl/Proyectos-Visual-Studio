using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ACOPEDH
{
    public partial class InicioSesión : Form
    {
        public InicioSesión()
        {
            InitializeComponent();
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

#warning Se cambiará para el host
        //Instancia para leer el servidor para tenerlo activo en todo el programa
        #region instancias y variables globales de clase
        Servidor server;
        Usuarios cuenta;
        Emailsistema enviarcorreo = new Emailsistema();
        String asunto = "Alerta de inicio de sesión.";
        String mensaje = "Se ha iniciado sesión en su cuenta el día " + DateTime.Now.Date.ToLongDateString() + " a las " + DateTime.Now.ToLongTimeString() + "\n\nSi usted no ha realizado ésta acción se le recomienda cambiar su clave de inicio de sesión.\nÉsto puede hacerlo en la opciones de configuración de su cuenta.\nSi ha sido usted, no realice ninguna acción.\n\n\nÉste correo se ha generado automáticamente, por favor, no responder.\n\nDesarrolladores.";
        #endregion
        private void InicioSesión_Load(object sender, EventArgs e)
        {
            txtCorreo.Text = Properties.Settings.Default.UsuariosG;
            server = new Servidor();
            server.server();
            MessageBox.Show(Globales.Servidor);
            this.MaximumSize = new Size(480, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 35);
            this.Height = SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 35;
            this.Visible = true;
            CenterToScreen();
        }
        private void btningresar_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Conexión con;
            con = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
            SqlConnection cn = new SqlConnection(con.cadena);
            if (Validaciones.IsNullOrEmty(ref txtCorreo, ref errorProvider1) && Validaciones.IsNullOrEmty(ref ttpass, ref errorProvider1))
            {
                Properties.Settings.Default.UsuariosG = txtCorreo.Text;
                Properties.Settings.Default.Save();
                cuenta = new Usuarios();
                this.Cursor = Cursors.WaitCursor;
                SqlParameter[] parámetros = new SqlParameter[1];
                parámetros[0] = new SqlParameter("@Correo", txtCorreo.Text);
                DataSet ds = new DataSet();
                Procedimientos_select select = new Procedimientos_select();
                ds = select.llenar_DataSet("InicioDeSesión", parámetros);
                if (ds.Tables["Usuarios"] != null)
                {
                    DataRow dro;
                    dro = ds.Tables["Usuarios"].Rows[0];
                    if (Cifrado.desencriptar(ttpass.Text, dro["Contraseña"].ToString()))
                    {
                        cn.Open();
                        Globales.gbCod_TipoUsuario = dro["FK Tipo Usuario"].ToString();
                        this.Cursor = Cursors.WaitCursor;
                        ttpass.Text = null;
                        enviarcorreo.EnviarEmail(txtCorreo, asunto, mensaje);
                        Principal_P p = new Principal_P();
                        SqlCommand cmd2 = new SqlCommand("select Nombre, Clave from [Tipo de Usuarios] where [Id Tipo Usuario]= '" + Globales.gbCod_TipoUsuario + "'", cn);
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd2.ExecuteNonQuery();
                        ds = new DataSet();
                        da = new SqlDataAdapter(cmd2);
                        da.Fill(ds, "[Tipo de Usuarios]");
                        DataRow dro1;
                        dro1 = ds.Tables["[Tipo de Usuarios]"].Rows[0];
                        Globales.Inicializar(dro["Id Usuario"].ToString(), dro1["Nombre"].ToString(), dro1["Clave"].ToString(), dro["Correo"].ToString(), dro["Nombres"].ToString(), dro["Apellidos"].ToString(), dro["FK Tipo Usuario"].ToString(), dro["Contraseña"].ToString());
                        this.Visible = false;
                        p.ShowDialog();
                        this.Cursor = Cursors.Default;
                        this.Visible = true;

                    }
                    else
                    {
                        cn.Close();
                        errorProvider1.SetError(ttpass, "Contraseña incorrecta.");
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    errorProvider1.SetError(txtCorreo, Globales.gbError);
                    Globales.gbError = "";
                }
            }
            Globales.ReiniciarValores();
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.validar_correo(ref txtCorreo, ref errorProvider1);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RegistroUsuario p = new RegistroUsuario();
            this.Visible = false;
            p.ShowDialog();
            this.Visible = true;
            this.Cursor = Cursors.Default;
        }
        private void InicioSesión_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void InicioSesión_AutoSizeChanged(object sender, EventArgs e)
        {
            CenterToScreen();
            PBACOPEDH.Location = new Point((Width - PBACOPEDH.Width) / 2, (label5.Location.Y - PBACOPEDH.Height + BarraTítulo.Height) / 2);
        }
        //Esto hace que aunque se intente maximizar, el formulario se mantenga en la misma posición en la que estaba y el mismo tamaño
        private void InicioSesión_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void PBMostrar1_MouseUp(object sender, MouseEventArgs e)
        {
            ttpass.UseSystemPasswordChar = true;
        }
        private void PBMostrar1_MouseDown(object sender, MouseEventArgs e)
        {
            ttpass.UseSystemPasswordChar = false;
        }

        private void LLOlvidoContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarCuenta RC = new RecuperarCuenta();
            this.Hide();
            RC.ShowDialog();
            this.Show();
        }
        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.FromArgb(20,25,72) ;
        }

        private void bttCer_MouseHover(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.Red;
        }

        private void bttCer_MouseDown(object sender, MouseEventArgs e)
        {
            bttCer.BackColor = Color.DarkRed;
        }
        private void PBMostrar1_Click(object sender, EventArgs e)
        {

        }
        #region Pintar Bordes
        private void Bordes_Paint(object sender, PaintEventArgs e)
        {
            Pen c = (new Pen(Brushes.LightBlue, 2));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width - 1, 0), new Point(Width - 1, Height - 2));
            Linea.DrawLine(c, new Point(1, 0), new Point(1, Height));
            Linea.DrawLine(c, new Point(0, Height - 1), new Point(Width, Height - 1));
            Linea.DrawLine(c, new Point(Width, 1), new Point(0, 1));
        }

        #endregion
    }
}