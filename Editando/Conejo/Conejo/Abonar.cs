using System;
using System.Windows.Forms;

namespace Conejo
{
    public partial class Abonar : Form
    {
        /* ***************************
           *        Variables        *
           ***************************   */
        string Asociado;
        Mostrar_Datos Mostrar = new Mostrar_Datos();
        Validaciones validar = new Validaciones();

        /* ***************************
           *      Constructores      *
           ***************************     */

        public Abonar(string CódigoAhorro, string Asocia)
        {
            InitializeComponent();
            DialogResult = DialogResult.No;
            Asociado = Asocia;
            txtAhorro.Text = CódigoAhorro;
            nInterés.Value = 0;
            Focus();
        }

        private void Abonar_Load_1(object sender, EventArgs e)
        {
            string query = "SELECT (Asociado.Nombres +' '+ Asociado.Apellidos) As Nombre"
                    + " FROM Ahorro"
                    + " INNER JOIN [Asociado] ON Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] where Ahorro.[id Ahorro] = '" + txtAhorro.Text + "'";
            Mostrar.LlenarTextBox(query, "Nombre", txtAsociado);

            nInterés.Value = decimal.Parse(Mostrar.ConseguirUno("Select [Tasa de Interés] from Ahorro inner Join[Tipo de Ahorro] on [FK Tipo Ahorro] =[id Tipo Ahorro] where[id Ahorro] = '" + txtAhorro.Text + "'", "Tasa de Interés"));

        }

        /* ***************************
           *         Acciones        *
           ***************************     */


        private void bttAbonar_Click(object sender, EventArgs e)
        {
            String cuenta = "Cuenta: " + txtAhorro.Text + "\nPropietario: " + txtAsociado.Text + "\nAbono: $" + nAbono.Value.ToString() + "\nAbono con interés: $" + nAbono.Value.ToString();

                if (nAbono.Value != 0)
                {
                DialogResult Select = MessageBox.Show("¿Desea imprimir una constancia del abono?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (Select == DialogResult.Yes || Select == DialogResult.No)
                    {
                        string query = "Insert into Abono values (" + nAbono.Value.ToString() + ",@Fecha,'"+txtAhorro.Text+"')";
                        if (Mostrar.PasarParametros(query, "@Fecha", DateTime.Now.ToString(), "date"))
                        {
                           
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
                else
                    MessageBox.Show("No ha elegido una cantidad a retirar", "Valor en cero", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
}

