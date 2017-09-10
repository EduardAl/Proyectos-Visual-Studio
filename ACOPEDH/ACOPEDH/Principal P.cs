using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Principal_P : Form
    {
        Color Original, Seleccionado;
        String Dato;
        Procedimientos_select Procedimientos_select = new Procedimientos_select();
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
        public Principal_P()
        {
            InitializeComponent();
        }
        private void Principal_P_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            Seleccionado = PInicio.BackColor;
            Original = PPréstamos.BackColor;
            MaximumSize = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width - 15, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 15);
        }

        /*
            *********************************
            *      Botones Principales      *
            ********************************* 
        */
#region Botones
        private void PInicio_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PInicio.BackColor = Seleccionado;
        }
        private void PAhorros_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PAhorros.BackColor = Seleccionado;

            // Mostrando
            labBuscar.Visible = true;
            txtBúsqueda.Visible = true;
            dgvBúsqueda.Visible = true;
            bttAbonar.Visible = true;
            bttRetirar.Visible = true;
            bttVerEstados.Visible = true;
            bttCrearCuenta.Visible = true;
            //Lenado de Datos
            dgvBúsqueda.DataSource = Procedimientos_select.llenar_DataTable("[Cargar Ahorros]");
            dgvBúsqueda.Refresh();
        }
        private void PPréstamos_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PPréstamos.BackColor = Seleccionado;

            // Mostrando
            labBuscar.Visible = true;
            txtBúsqueda.Visible = true;
            dgvBúsqueda.Visible = true;
            bttAmortización.Visible = true;
            bttOtorgarPréstamo.Visible = true;
            bttPagosRealizados.Visible = true;
            bttRealizarPago.Visible = true;
            //Lenado de Datos
            dgvBúsqueda.DataSource = Procedimientos_select.llenar_DataTable("[Préstamo DVG]");
            dgvBúsqueda.Refresh();
        }
        private void PAsociados_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PAsociados.BackColor = Seleccionado;
            DataView dv = new DataView();
            //Mostrando
            labBuscar.Visible = true;
            txtBúsqueda.Visible = true;
            dgvBúsqueda.Visible = true;
            bttNuevoAsociado.Visible = true;
            bttDatosAsociado.Visible = true;
            bttAportaciones.Visible = true;
            //Lenado de Datos
            dgvBúsqueda.DataSource = Procedimientos_select.llenar_DataTable("[Asociado DVG]");
            dgvBúsqueda.Refresh();
        }
        private void PConfiguración_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PConfiguración.BackColor = Seleccionado;
            DataView dv = new DataView();
            //Mostrando
            panelConfig.Visible = true;
        }
        private void PEstadoAsociación_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PEstadoAsociación.BackColor = Seleccionado;
        }
        private void PCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        /*
            *********************************
            *   Funciones y Procedimientos  *
            ********************************* 
        */
        private void DatoR()
        {
            if (dgvBúsqueda.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow dgvv = null;
                    int i = dgvBúsqueda.CurrentCell.RowIndex;
                    dgvv = dgvBúsqueda.Rows[i];
                    Dato = dgvv.Cells[0].Value.ToString();
                    if (String.IsNullOrEmpty(Dato))
                        DialogResult = DialogResult.Cancel;
                    else
                        DialogResult = DialogResult.OK;
                }
                catch { }
            }
        }
        public void Ocultar()
        {
            //Colorear
            PInicio.BackColor = Original;
            PAhorros.BackColor = Original;
            PPréstamos.BackColor = Original;
            PAsociados.BackColor = Original;
            PConfiguración.BackColor = Original;
            PEstadoAsociación.BackColor = Original;

            //Búsqueda
            labBuscar.Visible = false;
            txtBúsqueda.Visible = false;
            dgvBúsqueda.Visible = false;

            //Botones
            bttAmortización.Visible = false;
            bttOtorgarPréstamo.Visible = false;
            bttPagosRealizados.Visible = false;
            bttRealizarPago.Visible = false;
            bttAbonar.Visible = false;
            bttRetirar.Visible = false;
            bttVerEstados.Visible = false;
            bttCrearCuenta.Visible = false;
            bttAportaciones.Visible = false;
            bttNuevoAsociado.Visible = false;
            bttDatosAsociado.Visible = false;

            //Configuración
            panelConfig.Visible = false;
        }
        /*
           *********************************
           *      Botones Secundarios      *
           ********************************* 
       */
        #region Botones
        //Acciones
        private void bttAbonar_Click(object sender, EventArgs e)
        {
            DatoR();
            if (DialogResult == DialogResult.OK)
            {
            Abonos Accion = new Abonos(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
             
        }
        private void bttRetirar_Click(object sender, EventArgs e)
        {
            DatoR();
            if (DialogResult == DialogResult.OK)
            {
                Retiros Accion = new Retiros(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bttVerEstados_Click(object sender, EventArgs e)
        {
            DatoR();
            if (DialogResult == DialogResult.OK)
            {
            Estado_de_Cuenta Accion = new Estado_de_Cuenta(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttCrearCuenta_Click(object sender, EventArgs e)
        {
            Nuevo_Ahorro Accion = new Nuevo_Ahorro();
            Accion.ShowDialog();
        }
        private void bttRealizarPago_Click(object sender, EventArgs e)
        {
            DatoR();

            if (DialogResult == DialogResult.OK)
            {
                Pagos Accion = new Pagos(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttAmortización_Click(object sender, EventArgs e)
        {
            DatoR();
            if (DialogResult == DialogResult.OK)
            {
                Amortización Accion = new Amortización(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttPagosRealizados_Click(object sender, EventArgs e)
        {
            DatoR();
            if (DialogResult == DialogResult.OK)
            {
                Pagos_Realizados Accion = new Pagos_Realizados(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttOtorgarPréstamo_Click(object sender, EventArgs e)
        {
            
            Otorgar_Préstamo Accion = new Otorgar_Préstamo();
            Accion.ShowDialog();
        }
        private void bttDatosAsociado_Click(object sender, EventArgs e)
        {
            DatoR();
            if (DialogResult == DialogResult.OK)
            {
            Datos_Asociado Accion = new Datos_Asociado(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bttAportaciones_Click(object sender, EventArgs e)
        {
            DatoR();
            if (DialogResult == DialogResult.OK)
            {
                Aportaciones Accion = new Aportaciones();
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bttNuevoAsociado_Click(object sender, EventArgs e)
        {
            Nuevo_asociado Accion = new Nuevo_asociado();
            Accion.ShowDialog();
        }
        //Barta Título
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                toolTip1.SetToolTip(bttMax, "Maximizar");
            }
            else
            {
                toolTip1.SetToolTip(bttMax, "Restaurar a tamaño normal");
                WindowState = FormWindowState.Maximized;
            }
        }
      
        #endregion
        private void Principal_P_SizeChanged(object sender, EventArgs e)
        {
            BarraTítulo.Size = new Size(Width, BarraTítulo.Size.Height);
            bttCer.Location = new Point(Width - 26, 0);
            bttMax.Location = new Point(bttCer.Location.X - 26, 0);
            bttMin.Location = new Point(bttMax.Location.X - 26, 0);
            //                          Elementos
            Titulo.Location = new Point((Width / 2) - (Titulo.Width / 2) + 93, Titulo.Location.Y);
            dgvBúsqueda.Width = Width - dgvBúsqueda.Location.X - 87;
            dgvBúsqueda.Height = Height - dgvBúsqueda.Location.Y - 116;

            //Botones
            bttOtorgarPréstamo.Location = new Point(dgvBúsqueda.Width - bttOtorgarPréstamo.Width + dgvBúsqueda.Location.X, dgvBúsqueda.Location.Y - bttOtorgarPréstamo.Height - 23);
            bttCrearCuenta.Location = bttOtorgarPréstamo.Location;
            bttNuevoAsociado.Location = bttOtorgarPréstamo.Location;
            bttPagosRealizados.Location = new Point(dgvBúsqueda.Width - bttPagosRealizados.Width + dgvBúsqueda.Location.X, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            bttVerEstados.Location = bttPagosRealizados.Location;
            bttAportaciones.Location = bttPagosRealizados.Location;
            bttAmortización.Location = new Point(bttPagosRealizados.Location.X - bttAmortización.Width - 89, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            bttRetirar.Location = bttAmortización.Location;
            bttDatosAsociado.Location = bttAmortización.Location;
            bttRealizarPago.Location = new Point(bttAmortización.Location.X - bttRealizarPago.Width - 89, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            bttAbonar.Location = bttRealizarPago.Location;
            Refresh();
        }
        
        private void Principal_P_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                e.Cancel = true;
        }

    }
}
