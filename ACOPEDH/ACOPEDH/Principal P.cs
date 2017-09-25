using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ACOPEDH
{
    public partial class Principal_P : Form
    {
        DialogResult dr = DialogResult.Cancel;
        Color Original, Seleccionado;
        String Dato;
        Procedimientos_select Procedimientos_select = new Procedimientos_select();
        Validaciones validar = new Validaciones();
        Emailsistema enviarEmail = new Emailsistema();
        public static bool confirmación = false;
        public bool editpass = false;
        public bool editdata = false;
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
            txtNuevaContraseña.UseSystemPasswordChar = true;
            txtConfContraseña.UseSystemPasswordChar = true;
            No_Editar();
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
        private bool DatoR()
        {
            if (dgvBúsqueda.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow dgvv = null;
                    int i = dgvBúsqueda.CurrentCell.RowIndex;
                    dgvv = dgvBúsqueda.Rows[i];
                    Dato = dgvv.Cells[0].Value.ToString();
                    if (!String.IsNullOrEmpty(Dato))
                        return true;
                }
                catch
                {
                }
            }
            return false;
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
            if (DatoR())
            {
                Abonos Accion = new Abonos(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
             
        }
        private void bttRetirar_Click(object sender, EventArgs e)
        {
            if (DatoR())
            {
                Retiros Accion = new Retiros(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bttVerEstados_Click(object sender, EventArgs e)
        {
            if (DatoR())
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
            if (DatoR())
            {
                Pagos Accion = new Pagos(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttAmortización_Click(object sender, EventArgs e)
        {
            if (DatoR())
            {
                Amortización Accion = new Amortización(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttPagosRealizados_Click(object sender, EventArgs e)
        {
            if (DatoR())
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
            if (DatoR())
            {
                Datos_Asociado Accion = new Datos_Asociado(Dato);
                Accion.ShowDialog();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bttAportaciones_Click(object sender, EventArgs e)
        {
            if (DatoR())
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
        private void Editar()
        {
            editdata = true;
            PBMostrar2.Visible = !false;
            PBMostrar3.Visible = !false;
            if (!editpass)
            {
                txtNombreActual.Text = Globales.gbNombre_Usuario;
                txtApellidoActual.Text = Globales.gbApellido_Usuario;
                txtCorreoElectrónicoNuevo.Text = Globales.gbCorreo;
                txtNuevaContraseña.Text = Globales.gbClaveUsuario;
                txtConfContraseña.Text = Globales.gbClaveUsuario;
            }
            lkCancelar.Visible = !false;
            lkConfirmar.Visible = !false;
            LLEditar1.Visible = !true;
            txtNombreActual.ReadOnly = !true;
            txtApellidoActual.ReadOnly = !true;
            txtCorreoElectrónicoNuevo.ReadOnly = !true;
            txtNombreActual.Visible = true;
            txtApellidoActual.Visible = true;
            lbNombre.Visible = false;
            lbApellido.Visible = false;
            lbCorreo.Visible = false;
            txtNombreActual.Focus();
            txtCorreoElectrónicoNuevo.Visible = true;
        }
        private void Editar(String palabra)
        {
            editpass = true;
            PBMostrar2.Visible = !false;
            PBMostrar3.Visible = !false;
            if (!editdata)
            {
                txtNombreActual.Text = Globales.gbNombre_Usuario;
                txtApellidoActual.Text = Globales.gbApellido_Usuario;
                txtCorreoElectrónicoNuevo.Text = Globales.gbCorreo;
            }
            txtNuevaContraseña.Text = "";
            txtConfContraseña.Text = "";
            lkCancelar.Visible = !false;
            lkConfirmar.Visible = !false;
            txtNuevaContraseña.ReadOnly = !true;
            txtConfContraseña.ReadOnly = !true;
            lbContraseña.Visible = false;
            txtConfContraseña.Visible = !false;
            txtNuevaContraseña.Visible = !false;
            lkContra.Visible = false;
        }
        private void No_Editar()
        {
            PBMostrar2.Visible = false;
            PBMostrar3.Visible = false;
            lbNombre.Text = Globales.gbNombre_Usuario;
            lbApellido.Text = Globales.gbApellido_Usuario;
            lbCorreo.Text = Globales.gbCorreo;
            lkCancelar.Visible = false;
            lkConfirmar.Visible = false;
            LLEditar1.Visible = true;
            txtNombreActual.Visible = !true;
            txtApellidoActual.Visible = !true;
            txtCorreoElectrónicoNuevo.ReadOnly = true;
            txtNuevaContraseña.ReadOnly = true;
            txtConfContraseña.ReadOnly = true;
            lbNombre.Visible = !false;
            lbApellido.Visible = !false;
            lbContraseña.Visible = !false;
            txtConfContraseña.Visible = false;
            txtNuevaContraseña.Visible = false;
            lbCorreo.Visible = true;
            txtCorreoElectrónicoNuevo.Visible = false;
            lkContra.Visible = true;
            editpass = false;
            editdata = false;
        }
        private void Principal_P_SizeChanged(object sender, EventArgs e)
        {
            BarraTítulo.Size = new Size(Width, BarraTítulo.Size.Height);
            bttCer.Location = new Point(Width - 26, 0);
            bttMax.Location = new Point(bttCer.Location.X - 26, 0);
            bttMin.Location = new Point(bttMax.Location.X - 26, 0);
            //                          Elementos
            Titulo.Location = new Point((Width / 2) - (Titulo.Width / 2) + 93, Titulo.Location.Y);
            panelConfig.Width = Width - 285;
            panelConfig.Location = new Point((Width / 2) - (panelConfig.Width / 2) + 93, panelConfig.Location.Y);
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

        public void LLEditar1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Editar();
        }

        public void lkConfirmar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataSet ds = new DataSet();
            if (
                validar.IsNullOrEmty(ref txtNombreActual, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtApellidoActual, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtCorreoElectrónicoNuevo, ref errorProvider1) &&
                validar.ValidarNomApe(ref txtNombreActual, ref errorProvider1) &&
                validar.ValidarNomApe(ref txtApellidoActual, ref errorProvider1) &&
                validar.validar_correo(ref txtCorreoElectrónicoNuevo, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtNuevaContraseña, ref errorProvider1) &&
                validar.IsNullOrEmty(ref txtConfContraseña, ref errorProvider1) &&
                validar.validar_contraseñas(txtNuevaContraseña, ref errorProvider1) &&
                validar.claves_iguales(txtNuevaContraseña, txtConfContraseña, ref errorProvider1)
                )
            {
                if (!(Globales.gbNombre_Usuario == txtNombreActual.Text.Trim() && Globales.gbApellido_Usuario == txtApellidoActual.Text.Trim() &&
                    Globales.gbCorreo == txtCorreoElectrónicoNuevo.Text.Trim() && (Globales.gbClaveUsuario == txtNuevaContraseña.Text.Trim() ||
                    Cifrado.desencriptar(txtNuevaContraseña.Text.Trim(), Globales.gbClaveUsuario))))
                {
                    SqlParameter[] parámetros = new SqlParameter[5];
                    parámetros[0] = new SqlParameter("@Id", Globales.gbCodUsuario);
                    parámetros[1] = new SqlParameter("@Correo", txtCorreoElectrónicoNuevo.Text);
                    parámetros[2] = new SqlParameter("@Nombre", txtNombreActual.Text);
                    parámetros[3] = new SqlParameter("@Apellido", txtApellidoActual.Text);
                    if (editpass)
                    {
                        if
                            (
                                validar.IsNullOrEmty(ref txtNuevaContraseña, ref errorProvider1) &&
                                validar.IsNullOrEmty(ref txtConfContraseña, ref errorProvider1) &&
                                validar.validar_contraseñas(txtNuevaContraseña, ref errorProvider1) &&
                                validar.claves_iguales(txtNuevaContraseña, txtConfContraseña, ref errorProvider1)
                            )
                        {
                            parámetros[4] = new SqlParameter("@Contraseña", Cifrado.encriptar(txtNuevaContraseña.Text));
                        }
                    }
                    else
                    {
                        parámetros[4] = new SqlParameter("@Contraseña", Globales.gbClaveUsuario);
                    }
                    Confirmación cf = new Confirmación();
                    cf.StartPosition = FormStartPosition.CenterParent;
                    cf.ShowDialog();
                    this.Cursor = Cursors.WaitCursor;
                    if (confirmación)
                    {
                        ds = Procedimientos_select.llenar_DataSet("ModificarDatos", parámetros);
                    }
                    else
                    {
                        goto etiqueta;
                    }
                    if (!(txtCorreoElectrónicoNuevo.Text.Trim() == lbCorreo.Text.Trim()))
                    {
                        if (ds.Tables["Usuarios"] != null)
                        {
                            if (editpass)
                            {
                                enviarEmail.EnviarEmail(txtCorreoElectrónicoNuevo, "ACOPEDH Cambio de vinculación de e-mail", ("Su cambio de e-mail para ACOPEDH se realizó con éxito.\n Su contraseña es: " + txtNuevaContraseña.Text + "\nEste correo se ha generado automáticamente, favor no responder."));
                            }
                            else
                            {
                                enviarEmail.EnviarEmail(txtCorreoElectrónicoNuevo, "ACOPEDH Cambio de vinculación de e-mail", ("Su cambio de e-mail para ACOPEDH se realizó con éxito.\n" + "\nEste correo se ha generado automáticamente, favor no responder."));
                            }
                            MessageBox.Show("Datos modificados exitosamente.\nEn necesario volver a introducir sus credenciales para continuar con la sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            dr = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        if (ds.Tables["Usuarios"] != null)
                        {
                            if (editpass)
                            {
                                enviarEmail.EnviarEmail(txtCorreoElectrónicoNuevo, "ACOPEDH Cambio de datos de la cuenta", ("Se han realizado cambios en la información de su cuenta.\n Su contraseña es: " + txtNuevaContraseña.Text + "\nEste correo se ha generado automáticamente, favor no responder."));
                            }
                            else
                            {
                                enviarEmail.EnviarEmail(txtCorreoElectrónicoNuevo, "ACOPEDH Cambio de datos de la cuenta", ("Se han realizado cambios en la información de su cuenta.\n" + "\nEste correo se ha generado automáticamente, favor no responder."));
                            }
                            MessageBox.Show("Datos modificados exitosamente.\nEn necesario volver a introducir sus credenciales para continuar con la sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            dr = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(Globales.gbError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    etiqueta:
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("No se han realizado cambios en los datos de la cuenta.\nLos datos se guardarán nuevamente como se encontraban.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    No_Editar();
                }
            }
        }

        public void lkCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            No_Editar();
        }
        private void lkContra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Editar("contraseña");
            txtNuevaContraseña.Focus();
        }

        private void panelConfig_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Brushes.Black,3), 10, 32, panelConfig.Width - 10, 32);//23
            e.Graphics.DrawLine(new Pen(Brushes.Black,2), 10, 196, panelConfig.Width - 10, 196);//180
            e.Graphics.DrawLine(new Pen(Brushes.Black,2), 10, 347, panelConfig.Width - 10, 347);//331
        }
        private void PBMostrar2_MouseDown(object sender, MouseEventArgs e)
        {
            txtNuevaContraseña.UseSystemPasswordChar = false;
        }

        private void PBMostrar2_MouseUp(object sender, MouseEventArgs e)
        {
            txtNuevaContraseña.UseSystemPasswordChar = true;
        }

        private void PBMostrar3_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfContraseña.UseSystemPasswordChar = false;
        }

        private void PBMostrar3_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfContraseña.UseSystemPasswordChar = true;
        }

        private void txtNombreActual_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            validar.ValidarNomApe(ref txtNombreActual, ref errorProvider1);
        }

        private void txtApellidoActual_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            validar.ValidarNomApe(ref txtApellidoActual, ref errorProvider1);
        }

        private void txtCorreoElectrónicoNuevo_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            validar.validar_correo(ref txtCorreoElectrónicoNuevo, ref errorProvider1);
        }

        private void txtNuevaContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            validar.validar_contraseñas(txtNuevaContraseña, ref errorProvider1);
        }

        private void txtConfContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            validar.claves_iguales(txtNuevaContraseña, txtConfContraseña, ref errorProvider1);
        }

        private void Principal_P_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dr == DialogResult.Cancel)
            {
                DialogResult = MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Cancel)
                    e.Cancel = true;
            }

        }

    }
}