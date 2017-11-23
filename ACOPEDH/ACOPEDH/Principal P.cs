using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ACOPEDH
{
    public partial class Principal_P : Form
    {
        /*
            *********************************
            *     Componentes iniciales     *
            ********************************* 
        */
        String dgvControl;
        DialogResult dr = DialogResult.Cancel;
        Color Original, Seleccionado;
        String Dato,Extra;
        Procedimientos_select Procedimientos_select = new Procedimientos_select();
        DataTable dsAhorro, dsPréstamo, dsAsociado;
        DataView filtro;
        Emailsistema enviarEmail = new Emailsistema();
        public static bool confirmación = false;
        public bool editpass = false;
        public bool editdata = false;
        #region Constructores
        public Principal_P()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void Principal_P_Load(object sender, EventArgs e)
        {
            LlenarDGV(ref dsAhorro, "[Ahorro DVG]");
            LlenarDGV(ref dsPréstamo, "[Préstamo DVG]");
            LlenarDGV(ref dsAsociado, "[Asociado DVG]");
            this.Cursor = Cursors.Default;
            Seleccionado = PInicio.BackColor;
            Original = PPréstamos.BackColor;
            MaximumSize = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width - 15, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 15);
            txtNuevaContraseña.UseSystemPasswordChar = true;
            txtConfContraseña.UseSystemPasswordChar = true;
            No_Editar();
        }
        #endregion

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
            dgvControl = "Ahorro";
            this.filtro = dsAhorro.DefaultView;
            this.dgvBúsqueda.DataSource = filtro;
            txtBúsqueda.Focus();
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
            dgvControl = "Préstamo";
            this.filtro = dsPréstamo.DefaultView;
            txtBúsqueda.Focus();
            this.dgvBúsqueda.DataSource = filtro;
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
            dgvControl = "Asociado";
            this.filtro = dsAsociado.DefaultView;
            txtBúsqueda.Focus();
            this.dgvBúsqueda.DataSource = filtro;
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
        #region Cargar Datos en nuevos forms
        private bool DatoR()
        {
            if (dgvBúsqueda.SelectedRows.Count == 1)
            {
                try
                {
                    Extra = "";
                    DataGridViewRow dgvv = null;
                    int i = dgvBúsqueda.CurrentCell.RowIndex;
                    dgvv = dgvBúsqueda.Rows[i];
                    Dato = dgvv.Cells[0].Value.ToString();
                    Extra = dgvv.Cells[1].Value.ToString();
                    if (!String.IsNullOrEmpty(Dato))
                        return true;
                }
                catch
                {
                }
            }
            return false;
        }
        #endregion
        #region Botones Principales (Ocultar cosas)
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
        #endregion
        #region Modificar datos de usuario
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
        #endregion
        #region Cargar datos en DGV
        public void LlenarDGV(ref DataTable dss, String tabla)
        {
            dgvBúsqueda.DataSource = null;
            dss = Procedimientos_select.llenar_DataTable(tabla);
        }
        #endregion

       /*
          *********************************
          *      Botones Secundarios      *
          ********************************* 
      */
        #region Botones de Acción
        private void bttAbonar_Click(object sender, EventArgs e)
        {
            if (DatoR())
            {
                Abonos Accion = new Abonos(Dato);
                Accion.ShowDialog();
                Accion.Dispose();
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
                Accion.Dispose();
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
                if (Accion.dr == DialogResult.Yes)
                {
                    LlenarDGV(ref dsAhorro, "[Ahorro DVG]");
                    dgvControl = "Ahorro";
                    this.filtro = dsAhorro.DefaultView;
                    txtBúsqueda.Focus();
                    this.dgvBúsqueda.DataSource = filtro;
                }
                Accion.Dispose();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttCrearCuenta_Click(object sender, EventArgs e)
        {
            Nuevo_Ahorro Accion = new Nuevo_Ahorro();
            Accion.ShowDialog();
            if (Accion.DialogResult == DialogResult.OK)
            {
                LlenarDGV(ref dsAhorro, "[Ahorro DVG]");
                dgvControl = "Ahorro";
                this.filtro = dsAhorro.DefaultView;
                txtBúsqueda.Focus();
                this.dgvBúsqueda.DataSource = filtro;
            }
            Accion.Dispose();
        }
        private void bttRealizarPago_Click(object sender, EventArgs e)
        {
            if (DatoR())
            {
                Pagos Accion = new Pagos(Dato);
                Accion.ShowDialog();
                if (Accion.DialogResult == DialogResult.OK)
                {
                    LlenarDGV(ref dsPréstamo, "[Préstamo DVG]");
                    dgvControl = "Préstamo";
                    this.filtro = dsPréstamo.DefaultView;
                    txtBúsqueda.Focus();
                    this.dgvBúsqueda.DataSource = filtro;
                }
                Accion.Dispose();
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
                Accion.Dispose();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttPagosRealizados_Click(object sender, EventArgs e)
        {
            if (DatoR())
            {
                Pagos_Realizados Accion = new Pagos_Realizados(Dato);
                Accion.Visible = false;
                Accion.ShowDialog();
                Accion.Dispose();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bttOtorgarPréstamo_Click(object sender, EventArgs e)
        {
            Otorgar_Préstamo Accion = new Otorgar_Préstamo();
            Accion.ShowDialog();
            if (Accion.DialogResult == DialogResult.OK)
            {
                LlenarDGV(ref dsPréstamo, "[Préstamo DVG]");
                dgvControl = "Préstamo";
                this.filtro = dsPréstamo.DefaultView;
                txtBúsqueda.Focus();
                this.dgvBúsqueda.DataSource = filtro;
            }
            Accion.Dispose();
        }
        private void bttDatosAsociado_Click(object sender, EventArgs e)
        {
            if (DatoR())
            {
                Datos_Asociado Accion = new Datos_Asociado(Dato);
                Accion.ShowDialog();
                if (Accion.dr== DialogResult.Yes)
                {
                    LlenarDGV(ref dsAsociado, "[Asociado DVG]");
                    dgvControl = "Asociado";
                    this.filtro = dsAsociado.DefaultView;
                    txtBúsqueda.Focus();
                    this.dgvBúsqueda.DataSource = filtro;
                }
                Accion.Dispose();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bttAportaciones_Click(object sender, EventArgs e)
        {
            if (DatoR()&&Extra!="")
            {
                Aportaciones Accion = new Aportaciones(Dato,Extra);
                Accion.ShowDialog();
                Accion.Dispose();
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bttNuevoAsociado_Click(object sender, EventArgs e)
        {
            Nuevo_asociado Accion = new Nuevo_asociado();
            Accion.ShowDialog();
            if (Accion.DialogResult == DialogResult.OK)
            {
                LlenarDGV(ref dsAsociado, "[Asociado DVG]");
                dgvControl = "Asociado";
                this.filtro = dsAsociado.DefaultView;
                txtBúsqueda.Focus();
                this.dgvBúsqueda.DataSource = filtro;
            }
            Accion.Dispose();
        }
        #endregion
        #region Barra Título
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

        /*
           *********************************
           *            Eventos            *
           ********************************* 
       */
        #region Cambio de tamaño
        private void Principal_P_SizeChanged(object sender, EventArgs e)
        {
            BarraTítulo.Size = new Size(Width, BarraTítulo.Size.Height);
            bttCer.Location = new Point(Width - 26, 0);
            bttMax.Location = new Point(bttCer.Location.X - 26, 0);
            bttMin.Location = new Point(bttMax.Location.X - 26, 0);
            //                          Elementos
            Titulo.Location = new Point((Width / 2) - (Titulo.Width / 2) + 93, 44);
            panelConfig.Width = Width - 285;
            panelConfig.Location = new Point((Width / 2) - (panelConfig.Width / 2) + 93, 122 /*panelConfig.Location.Y*/);
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
        #endregion
        #region Links
        public void LLEditar1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Editar();
        }
        public void lkConfirmar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataSet ds = new DataSet();
            if (
                Validaciones.IsNullOrEmty(ref txtNombreActual, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtApellidoActual, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtCorreoElectrónicoNuevo, ref errorProvider1) &&
                Validaciones.ValidarNomApe(ref txtNombreActual, ref errorProvider1) &&
                Validaciones.ValidarNomApe(ref txtApellidoActual, ref errorProvider1) &&
                Validaciones.validar_correo(ref txtCorreoElectrónicoNuevo, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtNuevaContraseña, ref errorProvider1) &&
                Validaciones.IsNullOrEmty(ref txtConfContraseña, ref errorProvider1) &&
                Validaciones.validar_contraseñas(txtNuevaContraseña, ref errorProvider1) &&
                Validaciones.claves_iguales(txtNuevaContraseña, txtConfContraseña, ref errorProvider1)
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
                                Validaciones.IsNullOrEmty(ref txtNuevaContraseña, ref errorProvider1) &&
                                Validaciones.IsNullOrEmty(ref txtConfContraseña, ref errorProvider1) &&
                                Validaciones.validar_contraseñas(txtNuevaContraseña, ref errorProvider1) &&
                                Validaciones.claves_iguales(txtNuevaContraseña, txtConfContraseña, ref errorProvider1)
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
                            Globales.gbError = "";
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
                            Globales.gbError = "";
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
        #endregion
        #region Pintar
        private void panelConfig_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Brushes.Black, 3), 10, 32, panelConfig.Width - 10, 32);//23
            e.Graphics.DrawLine(new Pen(Brushes.Black, 2), 10, 196, panelConfig.Width - 10, 196);//180
            e.Graphics.DrawLine(new Pen(Brushes.Black, 2), 10, 347, panelConfig.Width - 10, 347);//331
        }
        #endregion
        #region Visibilidad contraseña
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
        #endregion
        #region Validaciones
        private void txtNombreActual_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            Validaciones.ValidarNomApe(ref txtNombreActual, ref errorProvider1);
        }
        private void txtApellidoActual_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            Validaciones.ValidarNomApe(ref txtApellidoActual, ref errorProvider1);
        }
        private void txtCorreoElectrónicoNuevo_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            Validaciones.validar_correo(ref txtCorreoElectrónicoNuevo, ref errorProvider1);
        }
        private void txtNuevaContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            Validaciones.validar_contraseñas(txtNuevaContraseña, ref errorProvider1);
        }
        private void txtConfContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            Validaciones.claves_iguales(txtNuevaContraseña, txtConfContraseña, ref errorProvider1);
        }
        #endregion
        #region Búsqueda
        private void txtBúsqueda_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabra_busqueda = this.txtBúsqueda.Text.Split(' ');
            if (dgvControl == "Ahorro")
            {
                foreach (string palabra in palabra_busqueda)
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "(Dui LIKE '%" + palabra + "%' OR [Código de Ahorro] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Ahorro] LIKE '%" + palabra + "%')";
                    }
                    else
                    {
                        salida_datos += " AND(Dui LIKE '%" + palabra + "%' OR [Código de Ahorro] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Ahorro] LIKE '%" + palabra + "%')";
                    }
                }
                this.filtro.RowFilter = salida_datos;
            }
            if (dgvControl == "Préstamo")
            {
                foreach (string palabra in palabra_busqueda)
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "(Dui LIKE '%" + palabra + "%' OR [Código de Préstamo] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Préstamo] LIKE '%" + palabra + "%')";
                    }
                    else
                    {
                        salida_datos += " AND(Dui LIKE '%" + palabra + "%' OR [Código de Préstamo] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [Tipo de Préstamo] LIKE '%" + palabra + "%')";
                    }
                }
                this.filtro.RowFilter = salida_datos;
            }
            if (dgvControl == "Asociado")
            {
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
        }
        #endregion
        #region Closing
        private void Principal_P_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dr == DialogResult.Cancel)
            {
                DialogResult = MessageBox.Show("¿Está seguro que desea salir?", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Cancel)
                    e.Cancel = true;
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
        #region Sombra
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
   (
       int nLeftRect, // x-coordinate of upper-left corner
       int nTopRect, // y-coordinate of upper-left corner
       int nRightRect, // x-coordinate of lower-right corner
       int nBottomRect, // y-coordinate of lower-right corner
       int nWidthEllipse, // height of ellipse
       int nHeightEllipse // width of ellipse
    );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                const int CS_DROPSHADOW = 0x00000040;
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }
        
        #endregion

    }
}