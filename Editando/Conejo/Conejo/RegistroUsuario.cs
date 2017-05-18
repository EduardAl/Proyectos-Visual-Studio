using System;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Conejo
{
    public partial class RegistroUsuario : Form
    {
        Conexión conn = new Conexión();
        SqlConnection cn;
        Validaciones validar = new Validaciones();
        Cuentas NewAcount = new Cuentas();
        Emailsistema enviaremail = new Emailsistema();
        public RegistroUsuario()
        {
            InitializeComponent();
            Focus();
            cn = new SqlConnection(conn.cadena);
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
            cbTipoUsuario.SelectedIndex = 0;
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                validar.ValidarNomApe(ref txtNombre, ref errorProvider1);
        }

        private void txtApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                validar.ValidarNomApe(ref txtApellido, ref errorProvider1);
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                validar.validar_correo(ref txtCorreo, ref errorProvider1);
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            validar.validar_contraseñas(txtPassword, ref errorProvider1);
        }

        private void txtConfPassword_KeyUp(object sender, KeyEventArgs e)
        {
            validar.claves_iguales(txtPassword, txtConfPassword, ref errorProvider1);
        }

        private void bttConfirmar_Click(object sender, EventArgs e)
        {
            String asunto = "Bienvenido a ACOPEDH";
            String mensaje = "Éste correo se ha generado automáticamente, por favor, no responder\n\nBienvenido a ACOPEDH.\n\nDesde éste momento puede ingresar a su cuenta.\n\n\nSu usuario: " + txtCorreo.Text + "\nSu clave: " + txtPassword.Text;
            string seguridad = cifrado.CreateRandomPassword(32);
            if (
                validar.IsNullOrEmty(ref txtNombre, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtApellido, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtCorreo, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtPassword, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtConfPassword, ref errorProvider1)
                )
            {
                if (NewAcount.existe(txtCorreo.Text) == true)
                {
                    errorProvider1.SetError(txtCorreo, "Ya existe una cuenta regstrada con ésta dirección de correo electrónico");
                }
                else
                {
                    errorProvider1.Clear();
                    if (NewAcount.CrearCuentas(txtNombre.Text, txtApellido.Text, txtConfPassword.Text, txtCorreo.Text, cbTipoUsuario.Text, seguridad) == 1)
                    {
                        enviaremail.EnviarEmail(txtCorreo, txtPassword, asunto, mensaje);
                        MessageBox.Show("Cuenta creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }

                }
            }
        }

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}