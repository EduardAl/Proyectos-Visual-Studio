using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conejo
{
    public partial class Retirar : Form
    {
        /* ***************************
           *        Variables        *
           ***************************   */
        string Asociado;
        Mostrar_Datos Mostrar = new Mostrar_Datos();
        Validaciones Validar = new Validaciones();

        /* ***************************
           *      Constructores      *
           ***************************     */

        public Retirar(string CódigoAhorro, string Asocia, bool todo)
        {
            InitializeComponent();
            DialogResult = DialogResult.No;
            Asociado = Asocia;
            nRetirar.Maximum = nDisponible.Value;
            txtAhorro.Text = CódigoAhorro;
            if (todo)
                nRetirar.Enabled = false;
            Focus();
        }
        private void Retirar_Load(object sender, EventArgs e)
        {
            string query = "SELECT (Asociado.Nombres +' '+ Asociado.Apellidos) As Nombre"
                     + " FROM Ahorro"
                     + " INNER JOIN [Asociado] ON Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] where Ahorro.[id Ahorro] = '" + txtAhorro.Text + "'";
            Mostrar.LlenarTextBox(query, "Nombre", txtAsociado);
            decimal tru = 0;
            tru =
                Mostrar.Suma("Aportaciones.Aportación", "Aportaciones", "Aportaciones.[FK Asociado]", Asociado)
              + Mostrar.Suma("Abono.Abono", "Abono", "Abono.[FK Ahorro]", txtAhorro.Text)
              - Mostrar.Suma("Retiros.Retiro", "Retiros", "Retiros.[FK Ahorro]", txtAhorro.Text);

            nDisponible.Value = tru;
            nRetirar.Maximum = tru;
            if (nDisponible.Value == 0)
            {
                MessageBox.Show("No hay cantidad disponible para retirar", "No hay fondos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            if (!nRetirar.Enabled)
                nRetirar.Value = nDisponible.Value;
        }

        /* ***************************
           *         Acciones        *
           ***************************     */
        #region Click
        private void bttRetirar_Click_1(object sender, EventArgs e)
        {
            String cuenta = "Cuenta: " + txtAhorro.Text + "\nPropietario: " + Asociado + "\nRetiro: $" + nRetirar.Value.ToString();
            if (nRetirar.Value != 0)
            {
                if (Validar.validar_Cheque(ref textBox1, ref errorProvider1))
                {
                    DialogResult Select = MessageBox.Show("¿Desea imprimir una constancia de retiro? \n" + cuenta, "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (Select == DialogResult.Yes || Select == DialogResult.No)
                    {
                        string query = "Insert into Retiros values (" + nRetirar.Value.ToString() + ",@Fecha," + textBox1.Text + ",'" + txtAhorro.Text + "')";
                        if (Mostrar.PasarParametros(query, "@Fecha", DateTime.Now.ToString(), "date"))
                        {
                            if (!nRetirar.Enabled)
                            {
                                query = "Update Ahorro set Estado = 'I' where [id Ahorro]= '" + txtAhorro.Text + "'";
                                Mostrar.GuardarModificarEliminar(query);
                            }
                            if (Select == DialogResult.Yes)
                            {
#warning Imprimir
                            }
                            MessageBox.Show("¡Cambios guardados!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                }
            }
            else
                MessageBox.Show("No ha elegido una cantidad a retirar", "Valor en cero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
        #region Código Para Mover
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

    }
}
