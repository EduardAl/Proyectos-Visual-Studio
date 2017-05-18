using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conejo
{
    public partial class Asociado : Form
    {

        /* ***************************
           *        Variables        *
           ***************************   */
        #region Variables
        Validaciones validar = new Validaciones();
        Mostrar_Datos Mostrar = new Mostrar_Datos();
        #endregion

        /* ***************************
           *      Constructores      *
           ***************************     */
        #region Constructores

        public Asociado()
        {
            InitializeComponent();
            Búsqueda buscar = new Búsqueda(true);
            buscar.ShowDialog();
            if (buscar.DialogResult != DialogResult.OK)
                Close();
            txtCódigoAsociado.Text = buscar.Dato;
            dateBirth.MinDate = DateTime.Today.AddYears(-120);
            dateBirth.MaxDate = DateTime.Today.AddYears(-18);
            Focus();
        }

        public Asociado(string Asociado)
        {
            InitializeComponent();
            txtCódigoAsociado.Text = Asociado;
            dateBirth.MinDate = DateTime.Today.AddYears(-120);
            dateBirth.MaxDate = DateTime.Today.AddYears(-18);
            Focus();
        }
        #endregion

        /* ***************************
           *         Acciones        *
           ***************************     */
        #region Click

        private void bttModificar_Click_1(object sender, EventArgs e)
        {
            if (Erroresnulos())
            {
                errorProvider1.Clear();
                DialogResult Answer = MessageBox.Show("¿Desea guardar los cambios realizados?", "Guardar cambios", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Answer == DialogResult.Yes)
                {
                    try
                    {
#warning Hace falta añadir el guardado de Teléfonos
                        string query = "Select [Id Ocupación] From Ocupación where [Nombre de la Empresa]='" + cbLugarTrabajo.Text + "'";
                        string hallado = Mostrar.ConseguirUno(query, "Id Ocupación");
                        query = "Update Asociado set Nombres='" + txtNombre.Text + "' ,Apellidos='" + txtApellidos.Text + "', Dirección= '" + txtDirección.Text + "',[FK Ocupación]='" + hallado + "', DUI='" + txtDUI.Text + "', NIT='" + txtNIT.Text + "',[Fecha de Nacimiento]=@nac where [Código Asociado]='" + txtCódigoAsociado.Text + "'";
                        if (!(Mostrar.VerificarExiste("NIT", txtNIT.Text, "Asociado", "AND [Código Asociado]!='" + txtCódigoAsociado.Text + "'", true) || Mostrar.VerificarExiste("DUI", txtDUI.Text, "Asociado", "AND [Código Asociado]!='" + txtCódigoAsociado.Text + "'", true)))
                        {
                            if (Mostrar.PasarParametros(query, "@nac", String.Format("{0:MM/dd/yyyy}", dateBirth.Value), ""))
                            {
                                MessageBox.Show("¡Cambios guardados!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            else
                                MessageBox.Show("¡Cambios no guardados!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("¡Ya existe un DUI o NIT registrado así!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (Answer == DialogResult.No)
                {
                    Close();
                }
            }
        }

        private void bttAceptar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void bttDesasociar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la asociación de este asociado? se realizarán los retiros correspondientes", "Quitar Asociado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                DialogResult Y = DialogResult.No;
                string query = "Select [id Ahorro] From Ahorro where [FK Código de Asociado]='" + txtCódigoAsociado.Text + "' AND Estado='A'";
                if (Mostrar.ConseguirUno(query, "id Ahorro") != "")
                {
                    foreach (string element in Mostrar.ConseguirVarios(query, "id Ahorro"))
                    {
                        Retirar Total = new Retirar(element, txtCódigoAsociado.Text, true);
                        Enabled = false;
                        Y = Total.ShowDialog();
                        Enabled = true;
                        if (Y != DialogResult.OK)
                            goto u;
                    }
                }
            u:
                if (Y == DialogResult.OK)
                {
                    query = "Update Asociado set [Fecha de Desasociación] = @desasociado where [Código Asociado] = '" + txtCódigoAsociado.Text + "'";
                    if (Mostrar.PasarParametros(query, "@desasociado", String.Format("{0:MM/dd/yyyy}", DateTime.Now), ""))
                    {
                        Mostrar.GuardarModificarEliminar(query);
                        MessageBox.Show("Usuario Desasociado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        query = "Select [Fecha de Desasociación] from Asociado where [Código Asociado] ='" + txtCódigoAsociado.Text + "'";
                        Mostrar.CargarDesasociación(query, dateDesasociación, bttDesasociar, labelDesasociacion);
                    }
                    else
                        MessageBox.Show("No se pudo desasociar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("No se pudo desasociar ya que no se realizo el retiro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttTelefono_Click(object sender, EventArgs e)
        {
            if (validar.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
            {
                string query = "Insert into Teléfonos values('" + txtTeléfono.Text + "','" + txtCódigoAsociado.Text + "')";
                if (Mostrar.GuardarModificarEliminar(query))
                {
                    lbTeléfonos.Items.Add(txtTeléfono.Text);
                    MessageBox.Show("¡Datos Guardados!", "Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbTeléfonos.SelectedIndex = lbTeléfonos.FindString(txtTeléfono.Text);
                    bttTelefono.Enabled = false;
                    bttModificar.Enabled = true;
                    bttEliminar.Enabled = true;
                }
            }
        }

        private void bttTelModificar_Click(object sender, EventArgs e)
        {
            if (validar.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
            {
                string query = "Update Teléfonos set Teléfono='" + txtTeléfono.Text + "' where [FK Código Asociado]='" + txtCódigoAsociado.Text + "'";
                if (Mostrar.GuardarModificarEliminar(query))
                {
                    string Teléfono = txtTeléfono.Text;
                    lbTeléfonos.Items.Add(Teléfono);
                    lbTeléfonos.Items.RemoveAt(lbTeléfonos.SelectedIndex);
                    lbTeléfonos.SelectedIndex = lbTeléfonos.FindString(Teléfono);
                    MessageBox.Show("¡Datos Modificados!", "Modificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bttEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar este número?", "Modificados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "Delete from Teléfonos where Teléfono='" + txtTeléfono.Text + "' And [FK Código Asociado]='" + txtCódigoAsociado.Text + "'";
                if (Mostrar.GuardarModificarEliminar(query))
                {
                    lbTeléfonos.Items.RemoveAt(lbTeléfonos.SelectedIndex);
                    lbTeléfonos.SelectedIndex = 0;
                }
            }
        }
        #endregion
        #region KeyUp
        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                if (validar.ValidarNomApe(ref txtNombre, ref errorProvider1))
                    errorProvider1.Clear();
        }

        private void txtApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                if (validar.ValidarNomApe(ref txtApellidos, ref errorProvider1))
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
        #endregion
        #region SelectedIndex
        private void lbTeléfonos_SelectedIndexChanged(object sender, EventArgs e)
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
        #endregion


        #region Load
        private void Usuario_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT Teléfono FROM dbo.Teléfonos Where [FK Código Asociado]='" + txtCódigoAsociado.Text + "'";
                Mostrar.LlenarList(ref lbTeléfonos, query, "Teléfono");
                dateDesasociación.Value = DateTime.Today;
                Mostrar.LlenarCombo(ref cbLugarTrabajo, "Nombre de la Empresa", "Ocupación",false);
                query = "SELECT Asociado.Nombres, Asociado.Apellidos, Asociado.DUI, Asociado.NIT, Asociado.Dirección, Asociado.[Fecha de Nacimiento], Asociado.[Fecha de Asociación], Asociado.[Fecha de Desasociación],Ocupación.[Nombre de la Empresa], ([Tipo de Socio].[Nombre Tipo Socio])AS You"
                     + " FROM Asociado"
                     + " INNER JOIN[Tipo de Socio] ON Asociado.[FK Tipo Socio] = [Tipo de Socio].[Id Tipo de Socio]"
                     + " INNER JOIN Ocupación ON Asociado.[FK Ocupación] = Ocupación.[Id Ocupación] where [Código Asociado] ='" + txtCódigoAsociado.Text + "'";
                Mostrar.LlenarTextBox(query, "Apellidos,Dirección,DUI,NIT,Nombres,You", "Nombre de la Empresa,Fecha de Nacimiento,Fecha de Asociación", ref cbLugarTrabajo, ref dateBirth, ref dateAsociación, txtApellidos, txtDirección, txtDUI, txtNIT, txtNombre, txtTipoAsociación);
                Mostrar.CargarDesasociación(query, dateDesasociación, bttDesasociar, labelDesasociacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lbTeléfonos.SelectedIndex = 0;
            bttAceptar.Focus();
        }
        #endregion
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

        /* ***************************
           *   Métodos y Funciones   *
           ***************************     */
        #region Funciones
        private bool Erroresnulos()
        {
            if (validar.ValidarNomApe(ref txtNombre, ref errorProvider1) &&
             validar.ValidarNomApe(ref txtApellidos, ref errorProvider1) &&
             validar.validar_DUI(ref txtDUI, ref errorProvider1) &&
             validar.validar_NIT(ref txtNIT, ref errorProvider1))
                return true;
            else
                return false;
        }

        #endregion
        
    }
}
