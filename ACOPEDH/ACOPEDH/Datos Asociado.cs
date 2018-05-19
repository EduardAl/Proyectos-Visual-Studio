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
        string Dato, Dato2;
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
        //Verificar si modificó
        private void bttAceptar_Click(object sender, EventArgs e)
        {
            if (!bttModificar.Enabled)
            {
               
                    if (Validaciones.ValidarNomApe(ref txtNombres, ref errorProvider1) &&
                        Validaciones.ValidarNomApe(ref txtApellidos, ref errorProvider1) &&
                        Validaciones.validar_DUI(ref txtDUI, ref errorProvider1) &&
                        Validaciones.validar_NIT(ref txtNIT, ref errorProvider1) &&
                        Validaciones.IsNullOrEmty(ref txtDirección, ref errorProvider1))
                    {
                    if (MessageBox.Show("¿Desea guardar los cambios?", "Modificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                                Modificar(false);
                                dr = DialogResult.Yes;
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
            DialogResult Desasociar = MessageBox.Show("¿Desea desasociar a "+txtNombres.Text +" ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Desasociar != DialogResult.No)
            {
                Retirar_Aportaciones Acción = new Retirar_Aportaciones(Dato);
                Acción.ShowDialog();
                SqlParameter[] Parámetros = new SqlParameter[1];
                Parámetros[0] = new SqlParameter("@Código_Asociado", Dato);
                if (Desasociar == DialogResult.Yes)
                {
                    if (Cargar.llenar_tabla("[Desasociar]", Parámetros) > 0)
                    {
                        dtDesaso.Value = DateTime.Now;
                        dtDesaso.Visible = true;
                        lbDesa.Visible = true;
                        bttDesasociar.Visible = false;
                        dr = DialogResult.Yes;
                    }
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
                }
                Acción.Dispose();
            }
        }
        //Mostrar Teléfonos
        private void bttTeléfonos_Click(object sender, EventArgs e)
        {
            Teléfonos Accion = new Teléfonos(Dato, Dato2);
            Accion.ShowDialog();
            Accion.Dispose();
        }
        //Mostrar Imágenes
        private void bttImágenes_Click(object sender, EventArgs e)
        {
            Imágenes Accion = new Imágenes(Dato);
            Accion.ShowDialog();
            Accion.Dispose();
        }
        //Cerrar
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.FromArgb(20, 25, 72); ;
        }
        private void bttCer_MouseHover(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.Red;
        }
        private void bttCer_MouseDown(object sender, MouseEventArgs e)
        {
            bttCer.BackColor = Color.DarkRed;
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
            bttModificar.Enabled = !enabled;
            bttAceptar.Enabled=bttCancelar.Enabled = enabled;
            errorProvider1.Clear();
        }
        public void CargarDatos()
        {
            try
            {
                //Carga de Parámetros
                SqlParameter[] Param = new SqlParameter[1];
                //Llenado del datatable (y de los TextBox)
                Param[0] = new SqlParameter("@Código_Asociado", Dato);
                DataTable dt = Cargar.LlenarText("[Cargar Asociados]", "Name,LName,DDui,DNit", Param, txtNombres, txtApellidos, txtDUI, txtNIT);
                dtNacimiento.Value = DateTime.Parse(dt.Rows[0]["FNacimiento"].ToString());
                dtAso.Value = DateTime.Parse(dt.Rows[0]["FAsociación"].ToString());
                txtDirección.Text = dt.Rows[0]["Residencia"].ToString();
                if (dt.Rows[0]["Est"].ToString() != "ACTIVO")
                {
                    dtDesaso.Value = DateTime.Parse(dt.Rows[0]["FDesasociación"].ToString());
                    dtDesaso.Visible = true;
                    lbDesa.Visible = true;
                    bttDesasociar.Visible = false;
                }
                Dato2 = txtDUI.Text;
            }
            catch { }
        }
        public void RetirarAportaciones()
        {

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
            Pen c = (new Pen(Brushes.Purple, 2));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width - 1, 0), new Point(Width - 1, Height - 2));
            Linea.DrawLine(c, new Point(1, 0), new Point(1, Height));
            Linea.DrawLine(c, new Point(0, Height - 1), new Point(Width, Height - 1));
            Linea.DrawLine(c, new Point(Width, 1), new Point(0, 1));
        }
        #endregion
        #region KeyUp
        private void txtNombres_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.ValidarNomApe(ref txtNombres, ref errorProvider1);
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


    }
}
