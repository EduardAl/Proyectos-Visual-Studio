using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ACOPEDH
{

    public partial class InicioSesión : Form
    {
        public static string MiServidor;
        Validaciones validar = new Validaciones();
        Cuentas cuenta = new Cuentas();
        Conexión con = new Conexión();
        Emailsistema enviarcorreo = new Emailsistema();
        String asunto = "Alerta de inicio de sesión.";
        String mensaje = "Se ha iniciado sesión en su cuenta el día " + DateTime.Now.Date.ToLongDateString() + " a las " + DateTime.Now.ToLongTimeString() + "\n\nSi usted no ha realizado ésta acción se le recomienda cambiar su clave de inicio de sesión.\nÉsto puede hacerlo en la opciones de configuración de su cuenta.\nSi ha sido usted, no realice ninguna acción.\n\n\nÉste correo se ha generado automáticamente, por favor, no responder.\n\nDesarrolladores.";
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
        public InicioSesión()
        {
            InitializeComponent();
        }
        private void InicioSesión_Load(object sender, EventArgs e)
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
                if (!cuenta.existe(txtCorreo.Text))
                {
                    errorProvider1.SetError(txtCorreo, "No se encontró ninguna cuenta asociada a ésta dirección E-Mail.");
                }
                else
                {
                    con = new Conexión();
                    SqlConnection cn = new SqlConnection(con.cadena);
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
                        if ((Cifrado.encriptar(ttpass.Text, seguridad) == dro["Contraseña"].ToString()))
                        {
                            //ttpass.Text = null;
                            //enviarcorreo.EnviarEmail(txtCorreo, ttpass, asunto, mensaje);
                            //Principal p = new Principal();
                            Globales.gbTUsuario = dro["FK Tipo Usuario"].ToString();
                            Globales.gbCorreo = dro["Correo"].ToString();
                            Globales.gbCodUsuario = dro["Id Usuario"].ToString();
                            SqlCommand cmd2 = new SqlCommand("select Nombre, Clave from [Tipo de Usuarios] where Correo= '" + Globales.gbTUsuario + "'", cn);
                            try
                            {
                                cn.Open();
                            }
                            catch (Exception ex)
                            {
                                cn.Close();
                                MessageBox.Show("Error al conectar.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                            cmd2.ExecuteNonQuery();
                            ds = new DataSet();
                            da = new SqlDataAdapter(cmd);
                            da.Fill(ds, "[Tipo de Usuarios]");
                            dro = ds.Tables["[Tipo de Usuarios]"].Rows[0];
                            Globales.gbUsuario = dro["Nombre"].ToString();
                            Globales.gbClave = dro["Clave"].ToString();
                            //this.Visible = false;
                            //p.ShowDialog();
                            //this.Visible = true;

                        }
                        else
                        {
                            cn.Close();
                            MessageBox.Show("Error al conectar.\nContraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                        }
                    }
                    else
                    {
                        cn.Close();
                        MessageBox.Show("Error al conectar.\nCorreo incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    cn.Close();

                }
            }
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                validar.validar_correo(ref txtCorreo, ref errorProvider1);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroUsuario p = new RegistroUsuario();
            this.Visible = false;
            p.ShowDialog();
            this.Visible = true;
        }
    }
}
