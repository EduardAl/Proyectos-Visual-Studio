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
        }
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

        /*
           *********************************
           *      Botones Secundarios      *
           ********************************* 
       */
#region Botones
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

        private void Principal_P_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                e.Cancel=true;
        }

        private void bttOtorgarPréstamo_Click(object sender, EventArgs e)
        {
            /*
            Otorgar_Préstamo Accion = new Otorgar_Préstamo(Dato());
            Accion.ShowDialog();
            */
        }
#endregion
    }
}
