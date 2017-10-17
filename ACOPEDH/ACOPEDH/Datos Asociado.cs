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
#warning FALTA TODO EL CÓDIGO
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        string Dato;
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
                    DialogResult = DialogResult.OK;
                }
            }
            Close();
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
        }
        public void CargarDatos()
        {
            //Carga de Parámetros
            SqlParameter[] Param = new SqlParameter[1];
            //Llenado del datatable (y de los TextBox)
            DataTable dt = Cargar.LlenarText("[Cargar Asociados]", "Name,LName,Residencia,DDui,DNit", Param, txtNombres, txtApellidos, txtDirección, txtDUI, txtNIT);
            Param[0] = new SqlParameter("@Código_Asociado", Dato);
            dtNacimiento.Value = DateTime.Parse(dt.Rows[0]["FNacimiento"].ToString());
            dtAso.Value = DateTime.Parse(dt.Rows[0]["FAsociación"].ToString());
            if (dt.Rows[0]["Est"].ToString() !="ACTIVO")
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
            if (DialogResult != DialogResult.OK)//Si se cancelo la modificación
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
