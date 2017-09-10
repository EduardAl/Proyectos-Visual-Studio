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
        Validaciones validar = new Validaciones();
        public Nuevo_asociado()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttAceptar_Click(object sender, EventArgs e)
        {
#warning Añadir validaciones al escribir y el ingreso de teléfonos
            if (validar.ValidarNomApe(ref txtNombres,ref errorProvider1)&&
                validar.ValidarNomApe(ref txtApellidos, ref errorProvider1) &&
                validar.validar_DUI(ref txtDUI, ref errorProvider1) &&
                validar.validar_NIT(ref txtNIT, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtDirección, ref errorProvider1))
            {
                string datos = string.Format("Nombre: {0}\nApellidos: {1}\nDUI: {2}\n" +
                    "NIT: {3}\nFecha de Nacimiento: {4}\nLugar de Trabajo: {5}\nTipo de Asociación: " +
                    "{6}\nDirección: {7}",txtNombres.Text, txtApellidos.Text, txtDUI.Text, txtNIT.Text,
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
                        ingresar.llenar_tabla("[Insertar Asociado]", param);
                        foreach (DataGridViewRow row in dgvTeléfonos.Rows)
                        {
                            param = new SqlParameter[3];
                            param[0] = new SqlParameter("@Tipo_Teléfono", row.Cells[1].Value.ToString());
                            param[1] = new SqlParameter("@Teléfono", row.Cells[0].Value.ToString());
                            param[2] = new SqlParameter("@DUI", txtDUI.Text);
                            ingresar.llenar_tabla("[Insertar Teléfono]", param);
                        }
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show("Ocurrió un error en el ingreso de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Nuevo_asociado_Load(object sender, EventArgs e)
        {
            Procedimientos_select Cargar = new Procedimientos_select();
            List<ComboBox_Llenado> Cargando = new List<ComboBox_Llenado>();
            Cargando = Cargar.LlenarCombo("[Cargar Tipo Socio]", "TipoS");
            foreach (ComboBox_Llenado element in Cargando)
            {
                cbAsociación.Items.Add(element.Nombre);
            }
            Cargando = Cargar.LlenarCombo("[Cargar Ocupación]", "Trabajo");
            foreach (ComboBox_Llenado element in Cargando)
            {
                cbOcupación.Items.Add(element.Nombre);
            }
            Cargando = Cargar.LlenarCombo("[Cargar Tipo Teléfono]", "TipoT");
            foreach (ComboBox_Llenado element in Cargando)
            {
                cbTipoTeléfono.Items.Add(element.Nombre);
            }
            if (cbAsociación.Items.Count > 0)
                cbAsociación.SelectedIndex = 0;
            if (cbOcupación.Items.Count > 0)
                cbOcupación.SelectedIndex = 0;
            if (cbTipoTeléfono.Items.Count > 0)
                cbTipoTeléfono.SelectedIndex = 0;
            dtNacimiento.MinDate = DateTime.Today.AddYears(-200);
            dtNacimiento.MaxDate = DateTime.Now.AddYears(-18);
            dtNacimiento.Value = dtNacimiento.MaxDate;
        }

        private void Nuevo_asociado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "Cancelar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (validar.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea remover este número de teléfono de la información de contacto para esta persona asociada?", "Confirmar eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dgvTeléfonos.Rows.Remove(dgvTeléfonos.CurrentRow);
            }
        }

        private void dgvTeléfonos_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtTeléfono.Text = dgvTeléfonos.CurrentRow.Cells[0].Value.ToString();
                cbTipoTeléfono.SelectedIndex = cbTipoTeléfono.Items.IndexOf(dgvTeléfonos.CurrentRow.Cells[1].Value.ToString());
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
    }
}
