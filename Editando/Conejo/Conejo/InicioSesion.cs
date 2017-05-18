using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Conejo
{

    public partial class InicioSesion : Form
    {
        public static string MiServidor;
        Validaciones validar = new Validaciones();
        Cuentas cuenta = new Cuentas();
        Conexión conn = new Conexión();
        Emailsistema enviarcorreo = new Emailsistema();
        String asunto = "Alerta de inicio de sesión.";
        String mensaje = "Se ha iniciado sesión en su cuenta el día " + DateTime.Now.Date.ToLongDateString() + " a las " + DateTime.Now.ToLongTimeString() + "\n\nSi usted no ha realizado ésta acción se le recomienda cambiar su clave de inicio de sesión.\nÉsto puede hacerlo en la opciones de configuración de su cuenta.\nSi ha sido usted, no realice ninguna acción.\n\n\nÉste correo se ha generado automáticamente, por favor, no responder.\n\nDesarrolladores.";
        public InicioSesion()
        {
            InitializeComponent();
        }
        private void InicioSesion_Load(object sender, EventArgs e)
        {
            Servidor s = new Servidor();
        }
        private void btningresar_Click_1(object sender, EventArgs e)
        {
            if (
            validar.IsNullOrEmty(ref txtCorreo, ref errorProvider1) &&
            validar.IsNullOrEmty(ref ttpass, ref errorProvider1)
            )
            {
                //if (!cuenta.existe(txtCorreo.Text))
                //{
                //    errorProvider1.SetError(txtCorreo, "No se encontró ninguna cuenta asociada a ésta dirección E-Mail.");
                //}
                //else
                //{
                conn = new Conexión();
                conn.conec("InicioSesion", "In112358");
                SqlConnection cn = new SqlConnection(conn.cadena);
                SqlCommand cmd = new SqlCommand("select [Id Usuario], Correo, Contraseña, [FK Tipo Usuario], Seguridad from Usuarios where Correo= '" + txtCorreo.Text + "'", cn);
                try
                {
                    cn.Open();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show("Error al conectar.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                string seguridad;
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Usuarios");
                DataRow dro;
                dro = ds.Tables["Usuarios"].Rows[0];
                if (txtCorreo.Text == dro["Correo"].ToString())
                {
                    seguridad = dro["Seguridad"].ToString();
                    if ((cifrado.encriptar(ttpass.Text, seguridad) == dro["Contraseña"].ToString()))
                    {
                        ttpass.Text = null;
                        enviarcorreo.EnviarEmail(txtCorreo, ttpass, asunto, mensaje);
                        Principal p = new Principal();
                        p.código = dro["FK Tipo Usuario"].ToString();
                        p.CorreoInicio = dro["Correo"].ToString();
                        p.IdUsuario = dro["Id Usuario"].ToString();
                        this.Visible = false;
                        p.ShowDialog();
                        this.Visible = true;

                    }
                    else
                    {
                        cn.Close();
                        MessageBox.Show("Error al conectar.\nContraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    }
                }
                //else
                //{
                //    cn.Close();
                //    MessageBox.Show("Error al conectar.\nCorreo incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //}
                cn.Close();

            }
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {

            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                validar.validar_correo(ref txtCorreo, ref errorProvider1);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}

