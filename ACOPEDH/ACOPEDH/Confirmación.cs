using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Confirmación : Form
    {
        public Confirmación()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validar_contraseñas(txtConfContraseña, ref errorProvider1))
                {
                if (Cifrado.desencriptar(txtConfContraseña.Text, Globales.gbClaveUsuario))
                {
                    Principal_P.confirmación = true;
                    this.Close();
                }
                else
                {
                    errorProvider1.SetError(txtConfContraseña, "Contraseña incorrecta");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal_P.confirmación = false;
            this.Close();
        }

        private void PBMostrar3_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfContraseña.UseSystemPasswordChar = false;
        }

        private void PBMostrar3_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfContraseña.UseSystemPasswordChar = true;
        }

        private void txtConfContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            Validaciones.validar_contraseñas(txtConfContraseña, ref errorProvider1);
        }

        private void Confirmación_Load(object sender, EventArgs e)
        {
            
        }
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
        #region Sombra
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        #endregion

    }
}
