using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Conejo
{
    public partial class Principal : Form
    {
        public String código = "";
        public String CorreoInicio = "";
        public String IdUsuario = "";
        DataSet resultado = new DataSet();
        DataView mifiltro;
        Conexión conn = new Conexión();
        RevisarEstados rev;
        StringBuilder sb = new StringBuilder(5000);
        Validaciones validar = new Validaciones();
        UsuarioLog UserLog;
        Cuentas cuenta = new Cuentas();
        public Principal()
        {
            InitializeComponent();
            Focus();
            reset();
            BttInicio.Select();
        }
        private void reset()
        {
            grupoEstados.Visible = false;
            grupoInicio.Visible = true;
            grupoAsociados.Visible = false;
            grupoConfiguación.Visible = false;
            grupoUsuarios.Visible = false;
            grupoTransacciones.Visible = false;
            grupoInicio.Size = new Size(658, 407);
            grupoInicio.Location = new Point(122, 54);
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            BttInicio.Focus();
            UserLog = new UsuarioLog(CorreoInicio, código);
        }
        public void leer(string query, ref DataSet dsprincipal, string tabla)
        {
            try
            {
                conn.conec(Globales.gbUsuario, Globales.gbClave);
                SqlConnection cn = new SqlConnection(conn.cadena);
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsprincipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       

        private void BttInicio_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void BttEstadosDeCuentas_Click(object sender, EventArgs e)
        {
            reset();
            grupoInicio.Visible = false;
            grupoEstados.Visible = true;
            grupoEstados.Size = new Size(658, 407);
            grupoEstados.Location = new Point(122, 54);
        }

        private void BttTransacciones_Click(object sender, EventArgs e)
        {
            reset();
            grupoInicio.Visible = false;
            grupoTransacciones.Visible = true;
            grupoTransacciones.Size = new Size(658, 407);
            grupoTransacciones.Location = new Point(122, 54);
        }

        private void BttOpcionesAsociados_Click(object sender, EventArgs e)
        {
            reset();
            grupoInicio.Visible = false;
            grupoAsociados.Visible = true;
            grupoAsociados.Size = new Size(658, 407);
            grupoAsociados.Location = new Point(122, 54);
        }

        private void BttOpcionesUsuarios_Click(object sender, EventArgs e)
        {
            reset();
            grupoInicio.Visible = false;
            grupoUsuarios.Visible = true;
            grupoUsuarios.Size = new Size(658, 407);
            grupoUsuarios.Location = new Point(122, 54);
        }

        private void BttConfiguración_Click(object sender, EventArgs e)
        {
            txtConficorreo.ReadOnly = true;
            txtConfiNombre.ReadOnly = true;
            txtConfiApelllido.ReadOnly = true;
            grupocontraseña.Visible = false;
            reset();
            grupoInicio.Visible = false;
            grupoConfiguación.Visible = true;
            grupoConfiguación.Size = new Size(658, 407);
            grupoConfiguación.Location = new Point(122, 54);
            try
            {
                conn.conec(Globales.gbUsuario, Globales.gbClave);
                SqlConnection cn = new SqlConnection(conn.cadena);
                SqlCommand cmd = new SqlCommand("SELECT Nombres, Apellidos, Correo from Usuarios where [Id Usuario] = '" + IdUsuario + "'", cn);
                cn.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                if (leer.Read() == true)
                {
                    txtConfiNombre.Text = leer["Nombres"].ToString();
                    txtConfiApelllido.Text = leer["Apellidos"].ToString();
                    txtConficorreo.Text = leer["Correo"].ToString();
                }
                MessageBox.Show(Globales.gbCodUsuario.Trim());
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                validar.validar_correo(ref txtConficorreo, ref errorProvider1);
        }
        private void txtClavenueva_KeyUp(object sender, KeyEventArgs e)
        {
            validar.validar_contraseñas(txtConficlavenueva, ref errorProvider1);
        }

        private void Bttguardar_Click(object sender, EventArgs e)
        {
            string seguridad = cifrado.CreateRandomPassword(32);
            if (validar.claves_iguales(txtConficlavenueva, txtConfiConficlavlenueva, ref errorProvider1))
            {
                if (cuenta.existe(txtConficorreo.Text))
                {
                    if (cuenta.devolverID(txtConficorreo.Text) != Globales.gbCodUsuario)
                    {
                        MessageBox.Show("Ya existe otra cuenta que está asociada a la dirección de correo.\nPor favor, introduzca otra dirección de correo válida.");
                    }
                    else
                    {

                        string actualizar = " Nombres = '" + txtConfiNombre.Text + "', Apellidos= '" + txtConfiApelllido.Text + "', Contraseña = '" + cifrado.encriptar(txtConfiConficlavlenueva.Text, seguridad) + "', Seguridad= '" + seguridad + "', Correo = '" + txtConficorreo + "'";
                        if (cuenta.actualizar("Usuarios", actualizar, "[Id Usuario] = '" + Globales.gbCodUsuario + "' "))
                            MessageBox.Show("Datos actualizados correctamente", "Éxito al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void linkModificar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkModificar.Visible = false;
            grupocontraseña.Visible = true;
            txtConfiNombre.ReadOnly = false;
            txtConfiApelllido.ReadOnly = false;
            txtConficorreo.ReadOnly = false;
            txtConficlaveactual.ReadOnly = false;
            txtConfiApelllido.Enabled = true;
            txtConficorreo.Enabled = true;
            txtConfiNombre.Enabled = true;
            txtConficlaveactual.Enabled = true;
            txtConficlaveactual.Text = "";
        }

        private void Bttcancelarguardar_Click(object sender, EventArgs e)
        {
            txtConficorreo.ReadOnly = true;
            txtConfiNombre.ReadOnly = true;
            txtConfiApelllido.ReadOnly = true;
            grupocontraseña.Visible = false;

            txtConficorreo.Enabled = false;
            txtConfiNombre.Enabled = false;
            txtConficlaveactual.Enabled = false;
            txtConfiApelllido.Enabled = false;
            reset();
            grupoInicio.Visible = false;
            grupoConfiguación.Visible = true;
            grupoConfiguación.Size = new Size(658, 407);
            grupoConfiguación.Location = new Point(122, 54);
        }
        
        private void BttNuevoAhorro_Click(object sender, EventArgs e)
        {
            Nuevo_Ahorro Ahorro = new Nuevo_Ahorro();
            Enabled = false;
            try
            {
                Ahorro.ShowDialog();
            }catch{ }
            Enabled = true;
            Focus();
        }

        private void BttAhorros_Click(object sender, EventArgs e)
        {
            RevisarEstados estado = new RevisarEstados();
            Enabled = false;
            try
            {
                estado.ShowDialog();
            }
            catch { }
            Enabled = true;
            Focus();
        }

        private void BttRetiro_Click(object sender, EventArgs e)
        {
            Focus();
        }

        private void BttAportaciones_Click(object sender, EventArgs e)
        {
            Aportaciones Aportar = new Aportaciones();
            Enabled = false;
            try
            {
                Aportar.ShowDialog();
            }
            catch { }
            Enabled = true;
            Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RevisarEstados estado = new RevisarEstados();
            Enabled = false;
            try
            {
                estado.ShowDialog();
            }catch{ }
            Enabled = true;
            Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistroUsuario Usuario = new RegistroUsuario();
            Enabled = false;
            try
            {
                Usuario.ShowDialog();
            }
            catch { }
            Enabled = true;
            Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
#warning Este no es para editar un usuario
            Asociado Usuario = new Asociado();
            Enabled = false;
            try
            {
                Usuario.ShowDialog();
            }
            catch { }
            Enabled = true;
            Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nuevo_Asociado Asociado = new Nuevo_Asociado();
            Enabled = false;
            try
            {
                Asociado.ShowDialog();
            }
            catch { }
            Enabled = true;
            Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Asociado Asociado = new Asociado();
            Enabled = false;
            try
            {
                Asociado.ShowDialog();
            }
            catch { }
            Enabled = true;
            Focus();
        }
    }
}

