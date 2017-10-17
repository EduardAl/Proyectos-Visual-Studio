using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

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
    }
}
