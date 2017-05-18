using System;
using System.Drawing;
using System.Windows.Forms;


namespace Conejo
{
    public partial class Nuevo_Asociado : Form
    {
        Validaciones validar = new Validaciones();
        Mostrar_Datos Mostrar = new Mostrar_Datos();

        public Nuevo_Asociado()
        {
            InitializeComponent();
            DateTime hoy = DateTime.Now;
            dateBirth.MinDate = hoy.AddYears(-120);
            dateBirth.MaxDate = hoy.AddYears(-18);
            Focus();
        }

        private void Nuevo_Usuario_Load(object sender, EventArgs e)
        {
            try
            {
                Mostrar.LlenarCombo(ref cbLugarTrabajo, "Nombre de la Empresa", "Ocupación",false);
                Mostrar.LlenarCombo(ref cbTipoAsociado, "Nombre Tipo Socio", "[Tipo de Socio]",false);
                cbLugarTrabajo.SelectedIndex = 0;
                cbTipoAsociado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtNombre.Focus();
        }

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Close();
            }
        }

        private void bttGuardar_Click(object sender, EventArgs e)
        {
            txtDirección.Text = txtDirección.Text.Trim(' ');
            if (
                validar.validar_nombre(ref txtNombre, ref errorProvider1) &&
                validar.validar_nombre(ref txtApellidos, ref errorProvider1) &&
                validar.validar_DUI(ref txtDUI, ref errorProvider1) &&
                validar.validar_NIT(ref txtNIT, ref errorProvider1)
                )
            {
                if (!(Mostrar.VerificarExiste("DUI", txtDUI.Text, "Asociado", "", true)
                    || Mostrar.VerificarExiste("NIT", txtNIT.Text, "Asociado", "", true)))
                {
                    if (MessageBox.Show("¿Desea guardar los datos?\nAlgunos datos no podrán modificarse", "Guardar datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string query1 = "Select [Id Ocupación] From Ocupación where [Nombre de la Empresa]='" + cbLugarTrabajo.Text + "'";
                        string query2 = "Select [id Tipo de Socio] From [Tipo de Socio] where [Nombre Tipo Socio]='" + cbTipoAsociado.Text + "'";
                        string query = "Insert into Asociado([FK Tipo Socio],Nombres,Apellidos,DUI,NIT,Dirección,[Fecha de Nacimiento],[Fecha de Asociación],[FK Ocupación]) values('" + Mostrar.ConseguirUno(query2, "id Tipo de Socio") + "','" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtDUI.Text + "','" + txtNIT.Text + "','" + txtDirección.Text + "',@nacimiento,@asociado,'" + Mostrar.ConseguirUno(query1, "Id Ocupación") + "')";

                        if (Mostrar.PasarParametros(query, "@nacimiento,@asociado", dateBirth.Value.ToShortDateString() + "," + DateTime.Now.ToShortDateString(), "date,date"))
                        {
                            query = "Select [Código Asociado] From Asociado where DUI='" + txtDUI.Text + "'";
                            foreach (string value in lbTeléfonos.Items)
                            {
                                if (value != "Añadir")
                                    Mostrar.GuardarModificarEliminar("Insert into Teléfonos values ('" + value + "','" + Mostrar.ConseguirUno(query, "Código Asociado") + "')");
                            }
                            int i = 5;
                            i = cbTipoAsociado.Text == "Fundador" ? 40 : 5;
                            query2 = "Insert into Aportaciones values(" + i + ",@Fecha,'" + Mostrar.ConseguirUno(query, "Código Asociado") + "')";
                            Mostrar.PasarParametros(query2, "@Fecha", DateTime.Now.ToShortDateString(), "date");
                            MessageBox.Show("¡Datos guardados correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema con los datos\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Ya ha registrado un asociado con ese DUI o ese NIT", "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MessageBox.Show("Error");
        }


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

        #region KeyUp
        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                if (validar.validar_nombre(ref txtNombre, ref errorProvider1))
                    errorProvider1.Clear();
        }

        private void txtApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                if (validar.validar_nombre(ref txtApellidos, ref errorProvider1))
                    errorProvider1.Clear();
        }

        private void txtDUI_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                if (validar.validar_DUI(ref txtDUI, ref errorProvider1))
                    errorProvider1.Clear();
        }

        private void txtNIT_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                if (validar.validar_NIT(ref txtNIT, ref errorProvider1))
                    errorProvider1.Clear();
        }

        private void txtTeléfono_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                if (validar.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
                    errorProvider1.Clear();
        }
        #endregion


        private void lbTeléfonos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lbTeléfonos.Text != "Añadir")
            {
                bttTelefono.Enabled = false;
                bttEliminar.Enabled = true;
                bttTelModificar.Enabled = true;
                txtTeléfono.Text = lbTeléfonos.Text;

            }
            else
            {
                bttTelefono.Enabled = true;
                bttEliminar.Enabled = false;
                bttTelModificar.Enabled = false;
                txtTeléfono.Clear();
            }
        }

        private void bttTelefono_Click(object sender, EventArgs e)
        {
            if (validar.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
            {
                lbTeléfonos.Items.Add(txtTeléfono.Text);
                lbTeléfonos.SelectedIndex = lbTeléfonos.FindString(txtTeléfono.Text);
                bttTelefono.Enabled = !true;
                bttTelModificar.Enabled = true;
                bttEliminar.Enabled = false;
            }
        }

        private void bttTelModificar_Click(object sender, EventArgs e)
        {
            if (validar.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
            {
                string Teléfono = txtTeléfono.Text;
                lbTeléfonos.Items.Add(Teléfono);
                lbTeléfonos.Items.RemoveAt(lbTeléfonos.SelectedIndex);
                lbTeléfonos.SelectedIndex = lbTeléfonos.FindString(Teléfono);
            }
        }

        private void bttEliminar_Click(object sender, EventArgs e)
        {
            lbTeléfonos.Items.RemoveAt(lbTeléfonos.SelectedIndex);
            lbTeléfonos.SelectedIndex = 0;
        }
        
    }


}
