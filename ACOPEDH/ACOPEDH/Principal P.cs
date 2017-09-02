using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Principal_P : Form
    {
        Color Original, Seleccionado;
        Point Lock;

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
            cbBúsqueda.SelectedIndex = 0;
            Seleccionado = PInicio.BackColor;
            Original = PPréstamos.BackColor;
        }
        private void cbBúsqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            labBuscar.Text = cbBúsqueda.Text+":";
            txtBúsqueda.Clear();
            txtBúsqueda.Focus();
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
            lab1.Visible = true;
            labBuscar.Visible = true;
            cbBúsqueda.Visible = true;
            txtBúsqueda.Visible = true;
            dgvBúsqueda.Visible = true;
            bttAbonar.Visible = true;
            bttRetirar.Visible = true;
            bttVerEstados.Visible = true;
            bttCrearCuenta.Visible = true;
        }
        private void PPréstamos_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PPréstamos.BackColor = Seleccionado;

            // Mostrando
            lab1.Visible = true;
            labBuscar.Visible = true;
            cbBúsqueda.Visible = true;
            txtBúsqueda.Visible = true;
            dgvBúsqueda.Visible = true;
            bttAmortización.Visible = true;
            bttOtorgarPréstamo.Visible = true;
            bttPagosRealizados.Visible = true;
            bttRealizarPago.Visible = true;
        }
        private void PAsociados_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PAsociados.BackColor = Seleccionado;

            //Mostrando
            lab1.Visible = true;
            labBuscar.Visible = true;
            cbBúsqueda.Visible = true;
            txtBúsqueda.Visible = true;
            dgvBúsqueda.Visible = true;
            bttNuevoAsociado.Visible = true;
            bttDatosAsociado.Visible = true;
            bttAportaciones.Visible = true;
        }
        private void PConfiguración_Click(object sender, EventArgs e)
        {
            Ocultar();
            //Colorear
            PConfiguración.BackColor = Seleccionado;
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
#warning Elegir si cambiar a groupbox
     
        #endregion
#warning Modificando tener una opción seleccionada
      

        /*
            *********************************
            *   Funciones y Procedimientos  *
            ********************************* 
        */
#warning Verificar si funciona
        private string Dato()
        {
            string Datos = "";
            if (dgvBúsqueda.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow dgvv = null;
                    int i = dgvBúsqueda.SelectedRows[0].Index;
                    dgvv = dgvBúsqueda.Rows[i];
                    Datos = dgvv.Cells[0].Value.ToString();
                    if (String.IsNullOrEmpty(Datos) || i == 0)
                        DialogResult = DialogResult.Cancel;
                    else
                        DialogResult = DialogResult.OK;
                }
                catch { }
            }
            return DialogResult == DialogResult.OK ? Datos : "";
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
            lab1.Visible = false;
            labBuscar.Visible = false;
            cbBúsqueda.Visible = false;
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
            /*
                if (DialogResult == DialogResult.OK)
                    {
                        Abonar Accion = new Abonar(Dato());
                        Accion.ShowDialog();
                    }
                    else
                        MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             */
        }
        private void bttRetirar_Click(object sender, EventArgs e)
        {
            /*
                if (DialogResult == DialogResult.OK)
                    {
                        Retirar Accion = new Retirar(Dato());
                        Accion.ShowDialog();
                    }
                    else
                        MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             */
        }
        private void bttVerEstados_Click(object sender, EventArgs e)
        {
            /*  
               if (DialogResult == DialogResult.OK)
                   {
                       Ver_Estados Accion = new Ver_Estados(Dato());
                       Accion.ShowDialog();
                   }
                   else
                       MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
            */
        }
        private void bttCrearCuenta_Click(object sender, EventArgs e)
        {
            /*  
            Crear_Cuenta Accion = new Crear_Cuenta(Dato());
            Accion.ShowDialog();

            */
        }
        private void bttRealizarPago_Click(object sender, EventArgs e)
        {
            /*
               if (DialogResult == DialogResult.OK)
                   {
                       Realizar_Pago Accion = new Realizar_Pago(Dato());
                       Accion.ShowDialog();
                   }
                   else
                       MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
            */
        }
        private void bttAmortización_Click(object sender, EventArgs e)
        {
            /*
               if (DialogResult == DialogResult.OK)
                   {
                       Amortización Accion = new Amortización(Dato());
                       Accion.ShowDialog();
                   }
                   else
                       MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
            */
        }
        private void bttPagosRealizados_Click(object sender, EventArgs e)
        {
            /*
               if (DialogResult == DialogResult.OK)
                   {
                       Pagos_Realizados Accion = new Pagos_Realizados(Dato());
                       Accion.ShowDialog();
                   }
                   else
                       MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
            */
        }
        private void bttOtorgarPréstamo_Click(object sender, EventArgs e)
        {
            /*
            Otorgar_Préstamo Accion = new Otorgar_Préstamo(Dato());
            Accion.ShowDialog();
            */
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
            if (Size.Width == SystemInformation.PrimaryMonitorMaximizedWindowSize.Width - 15
             && Size.Height == SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 15)
            {
                Location = Lock;
                Size = new Size(980, 705);
                toolTip1.SetToolTip(bttMax, "Maximizar");
            }
            else
            {
                Lock = Location;
                Location = new Point(0, 0);
                Size = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width - 15, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 15);
                toolTip1.SetToolTip(bttMax, "Restaurar a tamaño normal");
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
            ////if (MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            ////    e.Cancel=true;
        }

    }
}
