using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace ACOPEDH
{
    class Emailsistema
    {
        public MailMessage correo = new MailMessage();
        public void EnviarEmail(TextBox pcorreo, TextBox pcontra, string pasunto, string pmensaje)
        {
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential("developersacopedh@gmail.com", "AUREO112358");
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            correo = new MailMessage();
            String[] addr = pcorreo.Text.Split(',');
            try
            {
                correo.From = new MailAddress("developersacopedh@gmail.com",
                "Developers", System.Text.Encoding.UTF8);
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    correo.To.Add(addr[i]);
                correo.Subject = pasunto;
                correo.Body = (pmensaje);
                correo.ReplyTo = new MailAddress(pcorreo.Text);
                SmtpServer.Send(correo);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Código de error " + ex.StatusCode + "\nMensaje\n" + ex.Message + "\nNivel de error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }
    }
}
