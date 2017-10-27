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
    public partial class Datos_Asociado : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Dato;
        public DialogResult dr = DialogResult.Cancel;
        Procedimientos_select Cargar = new Procedimientos_select();
        #region Constructores
        //Normal
        public Datos_Asociado()
        {
            InitializeComponent();
        }
        //Con Código Asociado
        public Datos_Asociado(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
        #endregion
        #region Load
        private void Datos_Asociado_Load(object sender, EventArgs e)
        {
#warning Actualizar y luego verificar este procedimiento

            //Llenado de los combobox
            cbAsociación.DataSource = Cargar.llenar_DataTable("[Cargar Tipo Socio]");
            cbAsociación.DisplayMember = "TipoS";
            cbOcupación.DataSource = Cargar.llenar_DataTable("[Cargar Ocupaciones]");
            cbOcupación.DisplayMember = "Trabajo";
            cbTipoTeléfono.DataSource = Cargar.llenar_DataTable("[Cargar Tipo Teléfono]");
            cbTipoTeléfono.DisplayMember = "TipoT";
            //Código Asociado
            lbCódigo.Text = "Código de Asociación: " + Dato;
            CargarDatos();
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Ingresar Número
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //Modificar Número
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //Eliminar Número
        private void button3_Click(object sender, EventArgs e)
        {

        }
        //Verificar si modificó y cerrar
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            if (!bttModificar.Enabled)
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", "Modificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                        if (MessageBox.Show("¿Seguro de modificar los siguientes datos?: \n" + datos, "Confirmar modificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            try
                            {
                                Procedimientos_select modificar = new Procedimientos_select();
                                SqlParameter[] param = new SqlParameter[10];
                                param[0] = new SqlParameter("@Codigo_Asociado", Dato);
                                param[1] = new SqlParameter("@FK_Tipo_Socio", cbAsociación.Text);
                                param[2] = new SqlParameter("@Nombres", txtNombres.Text);
                                param[3] = new SqlParameter("@Apellidos", txtApellidos.Text);
                                param[4] = new SqlParameter("@DUI", txtDUI.Text);
                                param[5] = new SqlParameter("@NIT", txtNIT.Text);
                                param[6] = new SqlParameter("@Residencia", txtDirección.Text);
                                param[7] = new SqlParameter("@Fecha_Nacimiento", dtNacimiento.Value);
                                param[8] = new SqlParameter("@Fecha_Asociación", dtAso.Value);
                                param[9] = new SqlParameter("@FK_Ocupacion", cbOcupación.Text);
                                modificar.llenar_tabla("[Actualizar Asociado]", param);
                              //  DialogResult = DialogResult.OK;
                                dr = DialogResult.Yes;
                                Close();
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
            else
            {
              //  DialogResult = DialogResult.OK;
                dr = DialogResult.OK;
                Close();
            }
        }
        //Cancelar Modificación
        private void bttCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Cancelar la modificación?","Cancelar Modificación",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                Modificar(false);
                CargarDatos();
            }
        }
        //Habilitar Modificaciones
        private void bttModificar_Click(object sender, EventArgs e)
        {
            Modificar(true);
            
        }
        //Desasociar
        private void bttDesasociar_Click(object sender, EventArgs e)
        {
            dr = DialogResult.Yes;
        }
        #endregion
        /*
            *********************************
            *            Métodos            *
            ********************************* 
        */
        #region Métodos
        public void Modificar(bool enabled)
        {
#warning Verificar cuales datos se pueden cambiar y cuales no
            dr = enabled?DialogResult.Cancel:DialogResult.OK;
            txtApellidos.Enabled = enabled;
            txtDirección.Enabled = enabled;
            txtDUI.Enabled = enabled;
            txtNIT.Enabled = enabled;
            txtNombres.Enabled = enabled;
            dtAso.Enabled = enabled;
            dtDesaso.Enabled = enabled;
            dtNacimiento.Enabled = enabled;
            cbTipoTeléfono.Enabled = enabled;
            bttModificar.Enabled = !enabled;
            bttCancelar.Enabled = enabled;
        }
        public void CargarDatos()
        {
            //Carga de Parámetros
            SqlParameter[] Param = new SqlParameter[1];
            //Llenado del datatable (y de los TextBox)
            Param[0] = new SqlParameter("@Código_Asociado", Dato);
            DataTable dt = Cargar.LlenarText("[Cargar Asociados]", "Name,LName,Residencia,DDui,DNit", Param, txtNombres, txtApellidos, txtDirección, txtDUI, txtNIT);
            dtNacimiento.Value = DateTime.Parse(dt.Rows[0]["FNacimiento"].ToString());
            dtAso.Value = DateTime.Parse(dt.Rows[0]["FAsociación"].ToString());
            if (dt.Rows[0]["Est"].ToString() != "ACTIVO")
            {
                dtDesaso.Value = DateTime.Parse(dt.Rows[0]["FDesasociación"].ToString());
                dtDesaso.Visible = true;
                lbDesa.Visible = true;
                bttDesasociar.Visible = false;
            }
        }
        #endregion
        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Closing
        private void Datos_Asociado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dr != DialogResult.OK&&dr!=DialogResult.Yes)//Si se cancelo la modificación
                if (MessageBox.Show("¿Salir sin guardar cambios?", "Cancelar cambios", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    e.Cancel = true;
        }
        #endregion
        #region Cambio de celda
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

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
    }
}
