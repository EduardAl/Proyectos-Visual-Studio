using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

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
#warning Se cambiará para el host
        //Instancia para leer el servidor para tenerlo activo en todo el programa
        #region instancias y variables globales de clase
        Servidor server;
        Validaciones validar;
        Usuarios cuenta;
        Conexión con;
        Emailsistema enviarcorreo = new Emailsistema();
        Globales glb = new Globales();
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
            validar = new Validaciones();
            if (validar.IsNullOrEmty(ref txtCorreo, ref errorProvider1) && validar.IsNullOrEmty(ref ttpass, ref errorProvider1))
            {
                Properties.Settings.Default.UsuariosG = txtCorreo.Text;
                Properties.Settings.Default.Save();
            cuenta = new Usuarios();
                if (!cuenta.existe(txtCorreo.Text))
                {
                    errorProvider1.SetError(txtCorreo, "No se encontró ninguna cuenta asociada a ésta dirección E-Mail.");
                }
                else
                {
                this.Cursor = Cursors.WaitCursor;
                    con = new Conexión();
                    SqlConnection cn = new SqlConnection(con.cadena);
                    SqlCommand cmd = new SqlCommand("select [Id Usuario], Correo, Contraseña, [FK Tipo Usuario], Seguridad from Usuarios where Correo= '" + txtCorreo.Text + "'", cn);
                    try
                    {
                        cn.Open();
                    }
                    catch (SqlException ex)
                    {
                        cn.Close();
                        MessageBox.Show("Error al conectar.\n" + "Número del error: "+ex.Number+"\nCódigo del error: "+ex.ErrorCode+"\nError: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                            Globales.gbCod_TipoUsuario = dro["FK Tipo Usuario"].ToString();
                            this.Cursor = Cursors.WaitCursor;
                            ttpass.Text = null;
                            enviarcorreo.EnviarEmail(txtCorreo, asunto, mensaje);
                            Principal_P p = new Principal_P();
                            MessageBox.Show(Globales.gbCod_TipoUsuario);
                            SqlCommand cmd2 = new SqlCommand("select Nombre, Clave from [Tipo de Usuarios] where [Id Tipo Usuario]= '" + Globales.gbCod_TipoUsuario + "'", cn);
                            cmd2.ExecuteNonQuery();
                            cn.Close();
                            ds = new DataSet();
                            da = new SqlDataAdapter(cmd2);
                            da.Fill(ds, "[Tipo de Usuarios]");
                            DataRow dro1;
                            dro1 = ds.Tables["[Tipo de Usuarios]"].Rows[0];
                            glb.Inicializar(dro["Id Usuario"].ToString(), dro1["Nombre"].ToString(), dro1["Clave"].ToString(), dro["Correo"].ToString(), dro["FK Tipo Usuario"].ToString(), dro["Contraseña"].ToString());
                            this.Visible = false;
                            p.ShowDialog();
                            this.Cursor = Cursors.Default;
                            this.Visible = true;

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
                }
            }
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            validar = new Validaciones();
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                validar.validar_correo(ref txtCorreo, ref errorProvider1);
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
    }
}