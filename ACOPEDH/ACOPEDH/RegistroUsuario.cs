using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ACOPEDH
{
    public partial class RegistroUsuario : Form
    {
        Usuarios NewAcount;
        Emailsistema enviaremail;
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

        public RegistroUsuario()
        {
            InitializeComponent();
            Focus();
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(509, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 35);
            this.Height = SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 35;
            this.Visible = true;
            this.Cursor = Cursors.Default;
            cbTipoUsuario.SelectedIndex = 0;
            CenterToScreen();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.ValidarNomApe(ref txtNombre, ref errorProvider1);
        }

        private void txtApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.ValidarNomApe(ref txtApellido, ref errorProvider1);
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.validar_correo(ref txtCorreo, ref errorProvider1);
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            Validaciones.validar_contraseñas(txtPassword, ref errorProvider1);
        }

        private void txtConfPassword_KeyUp(object sender, KeyEventArgs e)
        {
            Validaciones.claves_iguales(txtPassword, txtConfPassword, ref errorProvider1);
        }

        private void bttConfirmar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            enviaremail = new Emailsistema();
            String asunto = "Bienvenido a ACOPEDH";
            String mensaje = "Éste correo se ha generado automáticamente, por favor, no responder\n\nBienvenido a ACOPEDH.\n\nDesde éste momento puede ingresar a su cuenta.\n\n\nSu usuario: " + txtCorreo.Text + "\nSu clave: " + txtPassword.Text;
            if (
                Validaciones.IsNullOrEmty(ref txtNombre, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtApellido, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtCorreo, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtPassword, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtConfPassword, ref errorProvider1) &&
                Validaciones.ValidarNomApe(ref txtNombre, ref errorProvider1) &&
                Validaciones.ValidarNomApe(ref txtApellido, ref errorProvider1) &&
                Validaciones.validar_contraseñas(txtPassword, ref errorProvider1) &&
                Validaciones.claves_iguales(txtPassword, txtConfPassword, ref errorProvider1) &&
                Validaciones.validar_correo(ref txtCorreo, ref errorProvider1)
                )
            {
                errorProvider1.Clear();
                Procedimientos_select procedimientos_Select = new Procedimientos_select();
                SqlParameter[] parámetros = new SqlParameter[5];
                parámetros[0] = new SqlParameter("@Correo", txtCorreo.Text);
                parámetros[1] = new SqlParameter("@Nombre", txtNombre.Text);
                parámetros[2] = new SqlParameter("@Apellido", txtApellido.Text);
                parámetros[3] = new SqlParameter("@Contraseña", Cifrado.encriptar(txtPassword.Text));
                String tipo = "";
                if (cbTipoUsuario.Text == "Master")
                    tipo = "TU001";
                if (cbTipoUsuario.Text == "Administrador")
                    tipo = "TU002";
                if (cbTipoUsuario.Text == "Usuario")
                    tipo = "TU003";
                parámetros[4] = new SqlParameter("@Tipo_Usuario", tipo);
                if (procedimientos_Select.llenar_tabla("Nuevo Usuario", parámetros) == 1)
                {
                    enviaremail.EnviarEmail(txtCorreo, asunto, mensaje);
                    MessageBox.Show("Cuenta creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    errorProvider1.SetError(txtCorreo, Globales.gbError);
                }
            }
            this.Cursor = Cursors.Default;
        }
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RegistroUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                if (MessageBox.Show("¿Está seguro que desea salir sin guardar su cuenta?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    e.Cancel = true;
        }
        private void RegistroUsuario_AutoSizeChanged(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void RegistroUsuario_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void bttCer_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        //Método solo para centrar el texto de un ComboBox
        private void cbTipoUsuario_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                StringFormat st = new StringFormat();
                st.LineAlignment = StringAlignment.Center;
                st.Alignment = StringAlignment.Center;
                Brush brush = new SolidBrush(Color.Black);
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    brush = SystemBrushes.HighlightText;
                e.Graphics.DrawString(cbTipoUsuario.Items[e.Index].ToString(), cbTipoUsuario.Font, brush, e.Bounds, st);
            }
        }
        private void PBMostrar1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void PBMostrar1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void PBMostrar2_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfPassword.UseSystemPasswordChar = true;
        }

        private void PBMostrar2_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfPassword.UseSystemPasswordChar = false;
        }
    }
}