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
    public partial class Otorgar_Préstamo : Form
    {
#warning FALTA GUARDAR EL PRÉSTAMO Y LA BÚSQUEDA

        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        public static DialogResult dr = DialogResult.Cancel;
        int Cuotas; double Monto, interes;
        DataTable dtAsociado;
        DataView filtro;
        Procedimientos_select Cargar = new Procedimientos_select();
        Fonts F;
        #region Constructores
        //Normal
        public Otorgar_Préstamo()
        {
            InitializeComponent();
        }
        public Otorgar_Préstamo(string dato)
        {
            InitializeComponent();

        }
        #endregion        
        #region Load
        private void Otorgar_Préstamo_Load(object sender, EventArgs e)
        {
            LlenarDGV(ref dtAsociado, "[Asociado DVG]");
            this.filtro = dtAsociado.DefaultView;
            dgvAsociado.DataSource = filtro;
            CBTipoPréstamo.DataSource = Cargar.llenar_DataTable("[Cargar Tipo Préstamo]");
            CBTipoPréstamo.DisplayMember = "TipoP";
            CBTipoPréstamo.ValueMember = "Interés";
            CBFormadePago.DataSource = Cargar.llenar_DataTable("[Cargar Tipo Pagos]");
            CBFormadePago.DisplayMember = "FormaP";
            CBFormadePago.ValueMember = "Id";
            if (CBTipoPréstamo.Items.Count > 0)
            {
                CBTipoPréstamo.SelectedIndex = 0;
                TxtInterés.Text = CBTipoPréstamo.SelectedValue.ToString();
            }
            if (CBFormadePago.Items.Count > 0)
                CBFormadePago.SelectedIndex = 0;
            dgvAsociado.Refresh();
            TxtBúsqueda.Focus();
            F = new Fonts(dgvAsociado);
            F.Diseño();
        }
        public void LlenarDGV(ref DataTable dss, String tabla)
        {
            dgvAsociado.DataSource = null;
            dss = Cargar.llenar_DataTable(tabla);
        }
        #endregion
        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones
        //Otorgar Préstamo
        private void button1_Click(object sender, EventArgs e)
        {
            //Verificando que todos los datos estén correctos
            if (Validaciones.IsNullOrEmty(ref TxtAsociadoP, ref Errores) &&
                Validaciones.IsNullOrEmty(ref txtCuotaMensual, ref Errores))
            {
                //Insertando los parametros
                SqlParameter[] Parámetros = new SqlParameter[7];
                Parámetros[0] = new SqlParameter("@FK_Tipo_Préstamo", CBTipoPréstamo.Text);
                Parámetros[1] = new SqlParameter("@FK_Asociado", TxtCódigoP.Text);
                Parámetros[2] = new SqlParameter("@Forma_Pago", CBFormadePago.SelectedValue);
                Parámetros[3] = new SqlParameter("@NCuotas", int.Parse(txtNoCuota.Text));
                Parámetros[4] = new SqlParameter("@Monto", double.Parse(TxtMonto.Text));
                Parámetros[5] = new SqlParameter("@Cuota", double.Parse(txtCuotaMensual.Text));
                Parámetros[6] = new SqlParameter("@Usuario", Globales.gbCodUsuario.ToString());
                //Verificar que todo esté bien
                if (Cargar.llenar_tabla("[Nuevo Préstamo]", Parámetros) > 0)
                {
                    MessageBox.Show("Préstamo guardado en la base de datos, procediendo a generar los documentos necesarios", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Imprimir Acción = new Imprimir(TxtCódigoP.Text, "Préstamo");
                    this.Cursor = Cursors.WaitCursor;
                    Acción.ShowDialog();
                    DialogResult = dr = DialogResult.OK;
                    Acción.Dispose();
                    Close();
                }
                else
                {
                    MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Globales.gbError = "";
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Falta de datos para proceder el registro", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }
        //Minimizar
        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void bttMin_MouseHover(object sender, EventArgs e)
        {
            bttMin.BackColor = Color.FromArgb(35, 45, 129);
        }

        private void bttMin_MouseLeave(object sender, EventArgs e)
        {
            bttMin.BackColor = Color.FromArgb(20, 25, 72);
        }

        private void bttMin_MouseDown(object sender, MouseEventArgs e)
        {
            bttMin.BackColor = Color.Blue;
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
        //Mostrar Amortización
        private void button2_Click(object sender, EventArgs e)
        {
            if (Validaciones.IsNullOrEmty(ref txtCuotaMensual,ref Errores))
            {
                Amortización Acción = new Amortización(double.Parse(TxtInterés.Text), Monto, Cuotas);
                Acción.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Aún no ha colocado los datos necesarios para generar una amortización","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.None;
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region TextChanged
        //Generar Cuota
        private void txtNoCuota_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TxtMonto.Text, out Monto)
                && int.TryParse(txtNoCuota.Text, out Cuotas)
                && Cuotas > 0
                && double.TryParse(TxtInterés.Text, out interes))
            {
                interes = interes / 1200;
                double Fijo = Math.Pow(1 + interes, Cuotas);
                double cuota = Monto * ((Fijo * interes) / (Fijo - 1));
                txtCuotaMensual.Text = Math.Round(cuota, 2).ToString();
            }
            else
            {
                txtCuotaMensual.Text = "";
            }
        }
        //Búsqueda de Asociado
        private void TxtBúsqueda_TextChanged(object sender, EventArgs e)
        {

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
        #region Closing
        private void Otorgar_Préstamo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dr == DialogResult.Cancel)
            {
                if (MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                { e.Cancel = true; }
            }
        }
        #endregion
        #region CurrentCell
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                TxtCódigoP.Text = dgvAsociado.CurrentRow.Cells[0].Value.ToString();
                TxtAsociadoP.Text = dgvAsociado.CurrentRow.Cells[1].Value.ToString();
                TxtDUIP.Text = dgvAsociado.CurrentRow.Cells[2].Value.ToString();
                TxtOcupación.Text = dgvAsociado.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
                TxtAsociadoP.Clear();
                TxtCódigoP.Clear();
                TxtDUIP.Clear();
                TxtOcupación.Clear();
            }
        }
        #endregion
        #region IndexChanged
        //Cambiar el tipo de préstamo
        private void CBTipoPréstamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtInterés.Text = CBTipoPréstamo.SelectedValue.ToString();
        }

        private void TxtBúsqueda_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabra_busqueda = this.TxtBúsqueda.Text.Split(' ');
            foreach (string palabra in palabra_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(Código LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR Dui LIKE '%" + palabra + "%' OR [Tipo Asociación] LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += " AND(Código LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR Dui LIKE '%" + palabra + "%' OR [Tipo Asociación] LIKE '%" + palabra + "%')";
                }
            }
            this.filtro.RowFilter = salida_datos;
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

    }
}
