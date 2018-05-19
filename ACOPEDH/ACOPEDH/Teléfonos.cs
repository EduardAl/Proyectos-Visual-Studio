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
    public partial class Teléfonos : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        Procedimientos_select Cargar = new Procedimientos_select();
        string Asociado = "";
        string DUI = "";
        #region Constructores
        public Teléfonos(string asociado,string Dui)
        {
            InitializeComponent();
            Asociado = asociado;
            DUI = Dui;
        }
        #endregion
        #region Load
        private void Teléfonos_Load(object sender, EventArgs e)
        {
            CargarTel();
        }
        #endregion

        /*
            *********************************
            *            Botones            *
            ********************************* 
        */
        #region Botones Principales
        private void bttAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
                {
                    SqlParameter[] Parámetros = new SqlParameter[3];
                    Parámetros[0] = new SqlParameter("@Tipo_Teléfono", cbTipoTeléfono.SelectedValue);
                    Parámetros[1] = new SqlParameter("@Teléfono", txtTeléfono.Text);
                    Parámetros[2] = new SqlParameter("@DUI", DUI);
                    if (Cargar.llenar_tabla("[Insertar Teléfono]", Parámetros) > 0)
                    {
                        CargarTel();
                        bttModificar.Enabled = bttEliminar.Enabled =true;
                    }
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
                }
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bttModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones.validar_Teléfonos(ref txtTeléfono, ref errorProvider1))
                {
                    SqlParameter[] Parámetros = new SqlParameter[5];
                    Parámetros[0] = new SqlParameter("@Tipo_TeléfonoA", dgvTeléfonos.CurrentRow.Cells[1].Value.ToString());
                    Parámetros[1] = new SqlParameter("@Tipo_TeléfonoN", cbTipoTeléfono.Text);
                    Parámetros[2] = new SqlParameter("@TeléfonoA", dgvTeléfonos.CurrentRow.Cells[0].Value.ToString());
                    Parámetros[3] = new SqlParameter("@TeléfonoN", txtTeléfono.Text);
                    Parámetros[4] = new SqlParameter("@DUI", DUI);
                    if (Cargar.llenar_tabla("[Modificar Teléfono]", Parámetros) > 0)
                        CargarTel();
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bttEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                    SqlParameter[] Parámetros = new SqlParameter[2];
                    Parámetros[0] = new SqlParameter("@Teléfono", dgvTeléfonos.CurrentRow.Cells[0].Value.ToString());
                    Parámetros[1] = new SqlParameter("@DUI", DUI);
                    if (Cargar.llenar_tabla("[Eliminar Teléfono]", Parámetros) > 0)
                        CargarTel();
                    else
                    {
                        MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globales.gbError = "";
                    }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.FromArgb(20, 25, 72);
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
        #region Cargar Teléfonos
        private void CargarTel()
        {
            try
            {
                cbTipoTeléfono.DataSource = Cargar.llenar_DataTable("[Cargar Tipo Teléfono]");
                cbTipoTeléfono.DisplayMember = "TipoT";
                cbTipoTeléfono.ValueMember = "Cod";

                //Cargar los registros en su respectivo DGV
                SqlParameter[] Parámetros = new SqlParameter[1];
                Parámetros[0] = new SqlParameter("@Código_Asociado", Asociado);
                dgvTeléfonos.DataSource = Cargar.llenar_DataTable("[Cargar Teléfonos]", Parámetros);
                dgvTeléfonos.Refresh();
            }
            catch { }
        }
        #endregion
        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region  KeyUp
        private void txtTeléfono_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Right))
                Validaciones.validar_Teléfonos(ref txtTeléfono, ref errorProvider1);
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

        private void dgvTeléfonos_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtTeléfono.Text = dgvTeléfonos.CurrentRow.Cells[0].Value.ToString();
                cbTipoTeléfono.SelectedIndex = cbTipoTeléfono.FindString(dgvTeléfonos.CurrentRow.Cells[1].Value.ToString());
                bttModificar.Enabled = 
                bttEliminar.Enabled = true;
            }
            catch
            {
                txtTeléfono.Clear();
                cbTipoTeléfono.SelectedIndex = 0;
                bttModificar.Enabled = 
                bttEliminar.Enabled = false;
            }
        }
    }
}
