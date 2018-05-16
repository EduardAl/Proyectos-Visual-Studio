using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Nuevo_asociado : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        DataTable dt;
        #region Constructores
        public Nuevo_asociado()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }
        #endregion
        #region Load
        private void Nuevo_asociado_Load(object sender, EventArgs e)
        {
           
            //Llenar los ComboBox
            Procedimientos_select Cargar = new Procedimientos_select();
            dt = Cargar.llenar_DataTable("[Cargar Tipo Socio]");
            cbAsociación.DataSource = dt;
            cbAsociación.DisplayMember = "TipoS";
            dt = Cargar.llenar_DataTable("[Cargar Ocupaciones]");
            cbOcupación.DataSource = dt;
            cbOcupación.DisplayMember = "Trabajo";
            dt = Cargar.llenar_DataTable("[Cargar Tipo Teléfono]");
            cbTipoTeléfono.DataSource = dt;
            cbTipoTeléfono.DisplayMember = "TipoT";
            cbTipoTeléfono.ValueMember = "Cod";
            //Seleccionar un index
            if (cbAsociación.Items.Count > 0)
                cbAsociación.SelectedIndex = 0;
            if (cbOcupación.Items.Count > 0)
                cbOcupación.SelectedIndex = 0;
            if (cbTipoTeléfono.Items.Count > 0)
                cbTipoTeléfono.SelectedIndex = 0;
            //Establecer que no se pueda tener menos de 18 años
            dtNacimiento.MaxDate = DateTime.Now.AddYears(-18);
            dtNacimiento.Value = dtNacimiento.MaxDate;
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        // Ingresar Asociado
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarNomApe(ref txtNombres, ref errorProvider1) &&
                Validaciones.ValidarNomApe(ref txtApellidos, ref errorProvider1) &&
                Validaciones.validar_DUI(ref txtDUI, ref errorProvider1) &&
                Validaciones.validar_NIT(ref txtNIT, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtDirección, ref errorProvider1))
            {
                string datos = string.Format("Nombre: {0}\nApellidos: {1}\nDUI: {2}\n" +
                    "NIT: {3}\nFecha de Nacimiento: {4}\nLugar de Trabajo: {5}\nTipo de Asociación: " +
                    "{6}\nDirección: {7}", txtNombres.Text, txtApellidos.Text, txtDUI.Text, txtNIT.Text,
                    dtNacimiento.Text, cbOcupación.Text, cbAsociación.Text, txtDirección.Text);
                if (MessageBox.Show("¿Seguro de ingresar los siguientes datos?: \n" + datos, "Confirmar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        Procedimientos_select ingresar = new Procedimientos_select();
                        SqlParameter[] param = new SqlParameter[9];
                        param[0] = new SqlParameter("@FK_Tipo_Socio", cbAsociación.Text);
                        param[1] = new SqlParameter("@Nombres", txtNombres.Text);
                        param[2] = new SqlParameter("@Apellidos", txtApellidos.Text);
                        param[3] = new SqlParameter("@DUI", txtDUI.Text);
                        param[4] = new SqlParameter("@NIT", txtNIT.Text);
                        param[5] = new SqlParameter("@Residencia", txtDirección.Text);
                        param[6] = new SqlParameter("@Fecha_Nacimiento", dtNacimiento.Value);
                        param[7] = new SqlParameter("@Fecha_Asociación", DateTime.Now);
                        param[8] = new SqlParameter("@FK_Ocupacion", cbOcupación.Text);
                        if (ingresar.llenar_tabla("[Insertar Asociado]", param) > 0)
                        {
                            param = new SqlParameter[3];
                            int i= 0;
                            foreach (DataGridViewRow row in dgvTeléfonos.Rows)
                            {
                                cbTipoTeléfono.SelectedIndex = cbTipoTeléfono.FindString(row.Cells[1].Value.ToString());
                                param[0] = new SqlParameter("@Tipo_Teléfono", cbTipoTeléfono.SelectedValue);
                                param[1] = new SqlParameter("@Teléfono", row.Cells[0].Value.ToString());
                                param[2] = new SqlParameter("@DUI", txtDUI.Text);
                                if (ingresar.llenar_tabla("[Insertar Teléfono]", param) < 0)
                                {
                                    MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Globales.gbError = "";
                                    DialogResult = DialogResult.None;
                                    break;
                                }
                            }
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Globales.gbError = "";
                            DialogResult = DialogResult.None;
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        // Cancelar Ingreso
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Añadir Teléfono
        private void button1_Click(object sender, EventArgs e)
        {
            if (Validaciones.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
            {
                bool existe = false;
                foreach (DataGridViewRow row in dgvTeléfonos.Rows)
                {
                    if (row.Cells[0].Value.ToString() == txtTeléfono.Text)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    dgvTeléfonos.Rows.Add(txtTeléfono.Text, cbTipoTeléfono.Text);
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
                else
                    errorProvider1.SetError(txtTeléfono, "Ya existe ese número de teléfono para esta persona asociada");
            }
        }
        //Modificar Teléfono
        private void button2_Click(object sender, EventArgs e)
        {
            if (Validaciones.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
            {
                bool existe = false;
                if (txtTeléfono.Text != dgvTeléfonos.CurrentRow.Cells[0].Value.ToString())
                    foreach (DataGridViewRow row in dgvTeléfonos.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == txtTeléfono.Text)
                        {
                            existe = true;
                            break;
                        }
                    }
                if (!existe)
                {
                    dgvTeléfonos.CurrentRow.SetValues(txtTeléfono.Text, cbTipoTeléfono.Text);
                }
                else
                    errorProvider1.SetError(txtTeléfono, "Ya existe ese número de teléfono para esta persona asociada");
            }
        }
        //Eliminar Teléfono
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea remover este número de teléfono de la información de contacto para esta persona asociada?", "Confirmar eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dgvTeléfonos.Rows.Remove(dgvTeléfonos.CurrentRow);
            }
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region FormClosing
        private void Nuevo_asociado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)//Si se ingresaron bien los datos
                if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "Cancelar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    e.Cancel = true;
        }
        #endregion
        #region Cambio de celda
        private void dgvTeléfonos_CurrentCellChanged(object sender, EventArgs e)
        {
            //Si se cambia de selección
            try
            {
                txtTeléfono.Text = dgvTeléfonos.CurrentRow.Cells[0].Value.ToString();
                cbTipoTeléfono.SelectedIndex = cbTipoTeléfono.FindString(dgvTeléfonos.CurrentRow.Cells[1].Value.ToString());
                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch
            {
                txtTeléfono.Clear();
                cbTipoTeléfono.SelectedIndex = 0;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }
        #endregion
        #region Pintar Bordes
        private void Bordes_Paint(object sender, PaintEventArgs e)
        {
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 0), new Point(0, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(0, Height - 1), new Point(Width, Height));
            Linea.DrawLine(new Pen(Brushes.Black, 2), new Point(Width - 1, 0), new Point(Width, Height));
        }

        #endregion
        #region KeyUp
        private void txtNombres_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.ValidarNomApe (ref txtNombres, ref errorProvider1);
        }
        private void txtApellidos_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.ValidarNomApe(ref txtApellidos, ref errorProvider1);
        }
        private void txtDUI_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.validar_DUI(ref txtDUI, ref errorProvider1);
        }
        private void txtNIT_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.validar_NIT(ref txtNIT, ref errorProvider1);
        }
        private void txtTeléfono_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.validar_Teléfonos(ref txtTeléfono, ref errorProvider1);
        }
        #endregion

        private void txtDirección_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
