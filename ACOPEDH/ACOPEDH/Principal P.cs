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
        #region Variables
        Fonts F;
        String dgvControl;
        DialogResult dr = DialogResult.Cancel;
        Color Original, Seleccionado, Fuente, FuenteO;
        String Dato,Extra;
        Procedimientos_select Cargar = new Procedimientos_select();
        DataTable dsAhorro, dsPréstamo, dsAsociado,dsTransacciones, dsPersonas, dsUsuarios, dsVariableAhorro, dsVariablePrestamo;
        DataView filtro, filtro1, filtro2, filtro3, filtro4, filtro5;
        DataTable Gráfica;
        Emailsistema enviarEmail = new Emailsistema();
        bool Cargando = true; 
        public static bool confirmación = false;
        public bool editpass = false;
        public bool editdata = false;
        #endregion
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
            Fuente = PInicio.ForeColor;
            FuenteO = PPréstamos.ForeColor;
            Seleccionado = PInicio.BackColor;
            Original = PPréstamos.BackColor;
            panelConfig.BackColor = Original;
            pictureBox3.BackColor = 
            bttMin.BackColor=bttMax.BackColor=bttCer.BackColor=
            BarraTítulo.BackColor = Seleccionado;
            MaximumSize = new Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height - SystemInformation.MenuBarButtonSize.Height);
            txtNuevaContraseña.UseSystemPasswordChar = true;
            txtConfContraseña.UseSystemPasswordChar = true;
            dtDesde.Value = new DateTime(2008, 1, 1);
            dtHasta.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
            dtHasta.MinDate = dtDesde.MinDate = dtDesde.Value;
            dtHasta.MaxDate = dtDesde.MaxDate = dtHasta.Value;
            cbTransacción.SelectedIndex = 0;
            No_Editar();
            F = new Fonts(dgvBúsqueda);
            F.Diseño();
            F = new Fonts(dgvTransacciones);
            F.Diseño();
            F = new Fonts(dgvPersonasA);
            F.Diseño();
            F = new Fonts(dgvUsuarios);
            F.Diseño();
            F = new Fonts(dgvVariableAhorros);
            F.Diseño();
            F = new Fonts(dvgVariablePrestamo);
            F.Diseño();
            PAdministrar.Visible = (Globales.gbTipo_Usuario=="Master_ACOPEDH"||Globales.gbTipo_Usuario=="Administrador") ?true:false;
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
            if (PInicio.BackColor != Seleccionado)
            {
                Ocultar();
                //Colorear
                PInicio.BackColor = Seleccionado;
                PInicio.ForeColor = Fuente;
            }
        }
        private void PAhorros_Click(object sender, EventArgs e)
        {
            if (PAhorros.BackColor != Seleccionado)
            {
                Ocultar();
                //Colorear
                PAhorros.BackColor = Seleccionado;
                PAhorros.ForeColor = Fuente;

                // Mostrando
                labBuscar.Visible = true;
                txtBúsqueda.Visible = true;
                dgvBúsqueda.Visible = true;
                bttAbono.Visible = true;
                bttRetirar.Visible = true;
                bttVerEstados.Visible = true;
                bttCrearCuenta.Visible = true;
                //Lenado de Datos
                dgvControl = "Ahorro";
                this.filtro = dsAhorro.DefaultView;
                this.dgvBúsqueda.DataSource = filtro;
                txtBúsqueda.Focus();
            }
        }
        private void PPréstamos_Click(object sender, EventArgs e)
        {
            if (PPréstamos.BackColor != Seleccionado)
            {
                Ocultar();
                //Colorear
                PPréstamos.BackColor = Seleccionado;
                PPréstamos.ForeColor = Fuente;

                // Mostrando
                labBuscar.Visible = true;
                txtBúsqueda.Visible = true;
                dgvBúsqueda.Visible = true;
                bttAmortizacion.Visible = true;
                bttOtorgarPréstamo.Visible = true;
                bttPagosRealizados.Visible = true;
                bttRealizarPago.Visible = true;
                //Lenado de Datos
                dgvControl = "Préstamo";
                this.filtro = dsPréstamo.DefaultView;
                txtBúsqueda.Focus();
                this.dgvBúsqueda.DataSource = filtro;
            }
        }
        private void PAsociados_Click(object sender, EventArgs e)
        {
            if (PAsociados.BackColor != Seleccionado)
            {
                Ocultar();
                //Colorear
                PAsociados.BackColor = Seleccionado;
                PAsociados.ForeColor = Fuente;

                //Mostrando
                labBuscar.Visible = true;
                txtBúsqueda.Visible = true;
                dgvBúsqueda.Visible = true;
                bttAgregarAsociado.Visible = true;
                bttDatosAsociado.Visible = true;
                bttAportar.Visible = true;
                //Lenado de Datos
                dgvControl = "Asociado";
                this.filtro = dsAsociado.DefaultView;
                txtBúsqueda.Focus();
                this.dgvBúsqueda.DataSource = filtro;
            }
        }
        private void PConfiguración_Click(object sender, EventArgs e)
        {
            if (PConfiguración.BackColor != Seleccionado)
            {
                Ocultar();
                //Colorear
                PConfiguración.BackColor = Seleccionado;
                PConfiguración.ForeColor = Fuente;
                //Mostrando
                panelConfig.Visible = true;
                //bttSalir.Visible = true;
            }
        }
        private void PEstadoAsociación_Click(object sender, EventArgs e)
        {
            if (PEstadoAsociación.BackColor != Seleccionado)
            {
                Ocultar();
                //Colorear
                PEstadoAsociación.BackColor = Seleccionado;
                PEstadoAsociación.ForeColor = Fuente;

                //Mostrando
                bttGráfica.Visible = true;
                cbTransacción.Visible = true;
                labDesde.Visible = true;
                labHasta.Visible = true;
                labTTran.Visible = true;
                dtDesde.Visible = true;
                dtHasta.Visible = true;
                dgvTransacciones.Visible = true;
                gbAhorros.Visible = true;
                gbAportaciones.Visible = true;
                gbPréstamos.Visible = true;
                //Cargando
                if (Cargando)
                {
                    Cargando_Datos_DGV();
                    Cargando_Datos_Text();
                    Cargando = false;
                }
            }
        }
        private void PAdministrador_Click(object sender, EventArgs e)
        {
            // if (Globales.gbCod_TipoUsuario=="")
            // {
            //Administrador Accion = new Administrador();
            //Visible = false;
            //Accion.ShowDialog();
            //Visible = true;
            //Accion.Dispose();
            //Cargando = true;
            //}
            if (PAdministrar.BackColor != Seleccionado)
            {
                Ocultar();
                //Colorear
                PAdministrar.BackColor = Seleccionado;
                PAdministrar.ForeColor = Fuente;
                //Mostrando
                tabControlAdmin.Visible = true;
                Page_Asociados();
                Page_Usuarios();
                Page_Variables();
            }
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
        private bool DatoA()
        {
            if (dgvPersonasA.SelectedRows.Count == 1)
            {
                try
                {
                    Extra = "";
                    DataGridViewRow dgvv = null;
                    int i = dgvPersonasA.CurrentCell.RowIndex;
                    dgvv = dgvPersonasA.Rows[i];
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
            PAdministrar.BackColor = Original;
            PInicio.ForeColor = FuenteO;
            PAhorros.ForeColor = FuenteO;
            PPréstamos.ForeColor = FuenteO;
            PAsociados.ForeColor = FuenteO;
            PConfiguración.ForeColor = FuenteO;
            PEstadoAsociación.ForeColor = FuenteO;
            PAdministrar.ForeColor = FuenteO;

            //Búsqueda
            labBuscar.Visible = false;
            txtBúsqueda.Visible = false;
            dgvBúsqueda.Visible = false;

            //Botones
            bttAmortizacion.Visible = false;
            bttOtorgarPréstamo.Visible = false;
            bttPagosRealizados.Visible = false;
            bttRealizarPago.Visible = false;
            bttAbono.Visible = false;
            bttRetirar.Visible = false;
            bttVerEstados.Visible = false;
            bttCrearCuenta.Visible = false;
            bttAportar.Visible = false;
            bttAgregarAsociado.Visible = false;
            bttDatosAsociado.Visible = false;
            //bttSalir.Visible = false;

            //Configuración
            panelConfig.Visible = false;

            //Administración
            tabControlAdmin.Visible = false;

            //Estado Asociación
            bttGráfica.Visible = false;
            cbTransacción.Visible = false;
            labDesde.Visible = false;
            labHasta.Visible = false;
            labTTran.Visible = false;
            dtDesde.Visible = false;
            dtHasta.Visible = false;
            dgvTransacciones.Visible = false;
            gbAhorros.Visible = false;
            gbAportaciones.Visible = false;
            gbPréstamos.Visible = false;
        }
        #endregion
        #region Modificar datos de usuario
        private void Editar()
        {
            editdata = true;
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
            labCNueva.Visible = !false;
            labCConfirmar.Visible = !false;
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
            labCNueva.Visible = false;
            labCConfirmar.Visible = false;
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
            dss = Cargar.llenar_DataTable(tabla);
        }
        //private void LlenarDGVPersonas(ref DataTable dss, String tabla)
        //{
        //    dgvPersonasA.DataSource = null;
        //    dss = Cargar.llenar_DataTable(tabla);
        //}
        #endregion
        #region Cargar Transacciones
        private void Cargando_Datos_Text()
        {
            double mora = 0, intereses = 0, ingresos = 0, capital = 0, pago = 0, prestamos = 0;
            double abono = 0, retiros = 0;
            double aportaciones = 0, retirado_A = 0;
            SqlParameter[] Parámetros = new SqlParameter[2];

            //Cargar los datos de la cuenta
            Parámetros[0] = new SqlParameter("@Fecha_Inicial", dtDesde.Value);
            Parámetros[1] = new SqlParameter("@Fecha_Final", dtHasta.Value);

            Gráfica = Cargar.LlenarText("[Conseguir Datos Cooperativa]", "Abonos,Retiros,Aportaciones," +
                  "RetiroAportación,Préstamos_Otorgados,Pago_Capital,Intereses_Pagados,Mora_Pagada", Parámetros,
                  txtAbonos_Ahorro, txtRetiros_Ahorros, txtAbonos_Aportaciones, txtRetiros_Aportaciones,
                  txtPréstamos, txtCapital, txtIntereses, txtMora);
            Parámetros[0] = new SqlParameter("@Fecha_Inicial", dtDesde.Value);
            Parámetros[1] = new SqlParameter("@Fecha_Final", dtHasta.Value);
            //Conversiones

            double.TryParse(txtAbonos_Ahorro.Text, out abono);
            double.TryParse(txtAbonos_Aportaciones.Text, out aportaciones);
            double.TryParse(txtCapital.Text, out capital);
            double.TryParse(txtIntereses.Text, out intereses);
            double.TryParse(txtMora.Text, out mora);
            double.TryParse(txtPago.Text, out pago);
            double.TryParse(txtPréstamos.Text, out prestamos);
            double.TryParse(txtRetiros_Ahorros.Text, out retiros);
            double.TryParse(txtRetiros_Aportaciones.Text, out retirado_A);

            ingresos = mora + intereses;
            pago = ingresos * 0.125;

            //TextBox a formato
            txtAbonos_Ahorro.Text = abono.ToString("C2");
            txtAbonos_Aportaciones.Text = aportaciones.ToString("C2");
            txtCapital.Text = capital.ToString("C2");
            txtIngresos.Text = ingresos.ToString("C2");
            txtIntereses.Text = intereses.ToString("C2");
            txtMora.Text = mora.ToString("C2");
            txtPago.Text = pago.ToString("C2");
            txtPréstamos.Text = prestamos.ToString("C2");
            txtRetiros_Ahorros.Text = retiros.ToString("C2");
            txtRetiros_Aportaciones.Text = retirado_A.ToString("C2");
        }
        private void Cargando_Datos_DGV()
        {
            //Cargar los registros en su respectivo DGV
            SqlParameter[] Parámetros = new SqlParameter[3];
            Parámetros[0] = new SqlParameter("@Fecha_Inicial", dtDesde.Value);
            Parámetros[1] = new SqlParameter("@Fecha_Final", dtHasta.Value);
            Parámetros[2] = new SqlParameter("@Tipo_Transaccion", cbTransacción.Text);
            dsTransacciones= Cargar.llenar_DataTable("[Conseguir Transacciones]", Parámetros);
            filtro1 = dsTransacciones.DefaultView;
            dgvTransacciones.DataSource = filtro1;
            dgvTransacciones.Refresh();
        }
        #endregion
        #region Cargar Administración
        private void Page_Asociados()
        {
            dgvPersonasA.DataSource = null;
            dsPersonas = Cargar.llenar_DataTable("[Administrar Asociados]");
            this.filtro2 = dsPersonas.DefaultView;
            this.dgvPersonasA.DataSource = filtro2;
        }
        private void Page_Usuarios()
        {
            dgvUsuarios.DataSource = null;
            dsUsuarios = Cargar.llenar_DataTable("[Administrar Usuarios]");
            this.filtro3 = dsUsuarios.DefaultView;
            this.dgvUsuarios.DataSource = filtro3;
        }
        private void Page_Variables()
        {
            dgvVariableAhorros.DataSource = null;
            dsVariableAhorro = Cargar.llenar_DataTable("[Cargar Tipo Ahorro]");
            dsVariableAhorro.Columns[0].ColumnName = "Tipo de Ahorro";
            this.filtro4 = dsVariableAhorro.DefaultView;
            this.dgvVariableAhorros.DataSource = filtro4;
            dvgVariablePrestamo.DataSource = null;
            dsVariablePrestamo = Cargar.llenar_DataTable("[Cargar Tipo Préstamo]");
            dsVariablePrestamo.Columns[0].ColumnName = "Tipo de PRéstamo";
            this.filtro5 = dsVariablePrestamo.DefaultView;
            this.dvgVariablePrestamo.DataSource = filtro5;
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
                Cargando = true;
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
                Cargando = true;
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
                Cargando = true;
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
                Cargando = true;
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
                Cargando = true;
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
                Cargando = true;
            }
            Accion.Dispose();
        }
        private void bttRegistros_Click(object sender, EventArgs e)
        {

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
                Cargando = true;
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
                Cargando = true;
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
                Cargando = true;
            }
            Accion.Dispose();
        }
        private void bttGráfica_Click(object sender, EventArgs e)
        {
            Gráfica Accion = new Gráfica(Gráfica,dtDesde.Value,dtHasta.Value);
            Accion.ShowDialog();
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
            //Elementos
            Titulo.Location = new Point(((Width - (pictureBox1.Height + pictureBox1.Location.X)) / 2) - (Titulo.Width / 2) + pictureBox1.Width +
                pictureBox1.Location.X, pictureBox1.Location.Y + 40);
            bttAgregarAsociado.Location = new Point(bttAgregarAsociado.Location.X, Titulo.Location.Y + (Titulo.Size.Height * 3));
     bttCrearCuenta.Location = new Point(bttAgregarAsociado.Location.X, Titulo.Location.Y + (Titulo.Size.Height * 3)); 
            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    PInicio.Location = new Point(pictureBox1.Location.X, PInicio.Location.Y);
            //    PConfiguración.Location = new Point(pictureBox1.Location.X, PConfiguración.Location.Y);
            //    PPréstamos.Location = new Point(pictureBox1.Location.X, PPréstamos.Location.Y);
            //    PAhorros.Location = new Point(pictureBox1.Location.X, PAhorros.Location.Y);
            //    PEstadoAsociación.Location = new Point(pictureBox1.Location.X, PEstadoAsociación.Location.Y);
            //    PAdministrar.Location = new Point(pictureBox1.Location.X, PAdministrar.Location.Y);
            //    PAsociados.Location = new Point(pictureBox1.Location.X, PAsociados.Location.Y);
            //    panelConfig.Width = (this.Width * 3) / 4;
            //    panelConfig.Height = PInicio.Size.Height * 8;
            //    panelConfig.Location = new Point(((Width - (pictureBox1.Height + pictureBox1.Location.X)) / 2) - (panelConfig.Width / 2) +
            //        pictureBox1.Width + pictureBox1.Location.X, PInicio.Location.Y - PInicio.Height - 8);
            //}
            //else
            //{
            //    PInicio.Location = new Point(pictureBox1.Location.X + 30, PInicio.Location.Y);
            //    PConfiguración.Location = new Point(pictureBox1.Location.X + 30, PConfiguración.Location.Y);
            //    PPréstamos.Location = new Point(pictureBox1.Location.X + 30, PPréstamos.Location.Y);
            //    PAhorros.Location = new Point(pictureBox1.Location.X + 30, PAhorros.Location.Y);
            //    PEstadoAsociación.Location = new Point(pictureBox1.Location.X + 30, PEstadoAsociación.Location.Y);
            //    PAdministrar.Location = new Point(pictureBox1.Location.X + 30, PAdministrar.Location.Y);
            //    PAsociados.Location = new Point(pictureBox1.Location.X + 30, PAsociados.Location.Y);
            //    panelConfig.Width = (this.Width * 3) / 4;
            //    panelConfig.Height = (this.Height - Titulo.Height - Titulo.Location.Y - 100);
            //    panelConfig.Location = new Point(((Width - (pictureBox1.Height + pictureBox1.Location.X)) / 2) - (panelConfig.Width / 2) +
            //    pictureBox1.Width + pictureBox1.Location.X, Titulo.Location.Y + Titulo.Height + 45);
            //    dgvBúsqueda.Size = new Size(panelConfig.Size.Width -50, panelConfig.Size.Height -50);
            //    dgvBúsqueda.Location = panelConfig.Location;
            //}

            PInicio.Location = new Point(pictureBox1.Location.X + 30, PInicio.Location.Y);
            PConfiguración.Location = new Point(pictureBox1.Location.X + 30, PConfiguración.Location.Y);
            PPréstamos.Location = new Point(pictureBox1.Location.X + 30, PPréstamos.Location.Y);
            PAhorros.Location = new Point(pictureBox1.Location.X + 30, PAhorros.Location.Y);
            PEstadoAsociación.Location = new Point(pictureBox1.Location.X + 30, PEstadoAsociación.Location.Y);
            PAdministrar.Location = new Point(pictureBox1.Location.X + 30, PAdministrar.Location.Y);
            PAsociados.Location = new Point(pictureBox1.Location.X + 30, PAsociados.Location.Y);
            panelConfig.Width = (this.Width * 3) / 4;
            panelConfig.Height = (this.Height - Titulo.Height - Titulo.Location.Y - 100);
            panelConfig.Location = new Point(((Width - (pictureBox1.Height + pictureBox1.Location.X)) / 2) - (panelConfig.Width / 2) +
            pictureBox1.Width + pictureBox1.Location.X, Titulo.Location.Y + Titulo.Height + 45);
            dgvBúsqueda.Size = new Size(panelConfig.Size.Width - 100 + bttNuevoAsociado.Width, panelConfig.Size.Height - 100);
            txtBúsqueda.Width = dgvBúsqueda.Width - (bttNuevoAsociado.Width + labBuscar.Width + 15);
            dgvBúsqueda.Location = new Point(labBuscar.Location.X, txtBúsqueda.Location.Y + (txtBúsqueda.Height * 2));
            dvgVariablePrestamo.Height = (dvgVariablePrestamo.Height * 2);
            groupBox1.Height = tabControlAdmin.Height/2 - 50;
            groupBox2.Height = tabControlAdmin.Height/2 - 50;
            
            
            //dvgVariablesPrestamos.Location = dgvBús,queda.Location;
            //dvgVariablesPrestamos.Size = new Size(dgvBúsqueda.Size.Width, dgvBúsqueda.Size.Height);
            panelConfig.Location = dgvBúsqueda.Location;
            panelConfig.Size = new Size(dgvBúsqueda.Size.Width, (PAdministrar.Location.Y + PAdministrar.Height) - dgvBúsqueda.Location.Y);
            //}
            tabControlAdmin.Size = new Size(panelConfig.Size.Width - 50, dgvBúsqueda.Size.Height);
            tabControlAdmin.Location = dgvBúsqueda.Location;
            //dgvPersonasA.Height = 668;y
            //Botones
            labHasta.Location = new Point(labDesde.Location.X + dtDesde.Width + 5, labDesde.Location.Y);
            dtHasta.Location = new Point(labHasta.Location.X, dtDesde.Location.Y);
            bttOtorgarPréstamo.Location = new Point(dgvBúsqueda.Width - bttOtorgarPréstamo.Width + dgvBúsqueda.Location.X, bttOtorgarPréstamo.Location.Y);
            bttCrearCuenta.Location = bttAgregarAsociado.Location = bttOtorgarPréstamo.Location;
            bttPagosRealizados.Location = new Point(dgvBúsqueda.Width - bttPagosRealizados.Width + dgvBúsqueda.Location.X, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            bttVerEstados.Location = bttAportar.Location = bttPagosRealizados.Location;
            bttAmortizacion.Location = new Point(dgvBúsqueda.Location.X + (dgvBúsqueda.Width - bttAmortizacion.Width) / 2, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            bttRetirar.Location = bttDatosAsociado.Location = bttAmortizacion.Location;
            bttRealizarPago.Location = new Point(dgvBúsqueda.Location.X, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            bttAbono.Location = bttRealizarPago.Location;
            bttGráfica.Location = new Point(bttCrearCuenta.Location.X, labDesde.Location.Y);
            gbAportaciones.Location = new Point(bttGráfica.Location.X + bttGráfica.Width - gbAportaciones.Width, bttGráfica.Location.Y + (bttGráfica.Height *2));
            gbPréstamos.Location = new Point(gbAportaciones.Location.X + gbAportaciones.Width - gbPréstamos.Width, gbAportaciones.Location.Y + gbAportaciones.Height + 10);
            gbAhorros.Location = new Point(gbPréstamos.Location.X, gbAportaciones.Location.Y);
            cbTransacción.Location = new Point(gbAhorros.Location.X, bttGráfica.Location.Y + bttGráfica.Height + 10);
            labTTran.Location = new Point(cbTransacción.Location.X, cbTransacción.Location.Y - cbTransacción.Height);
            dgvTransacciones.Location = new Point(dtDesde.Location.X, cbTransacción.Location.Y);
            dgvTransacciones.Size = new Size(labTTran.Location.X - dgvTransacciones.Location.X -20, dgvBúsqueda.Height);
            if(this.WindowState == FormWindowState.Normal)
            {
                tabControlAdmin.Size = new Size(panelConfig.Size.Width, (PAdministrar.Location.Y + PAdministrar.Size.Height) - dgvBúsqueda.Location.Y);
                dgvTransacciones.Size = new Size(labTTran.Location.X - dgvTransacciones.Location.X - 20, (PAdministrar.Location.Y + PAdministrar.Size.Height) - PInicio.Location.Y);
            }
            //bttSalir.Location = bttRealizarPago.Location;
            //bttSalir.Size = bttRealizarPago.Size;
            Refresh();

            //tabControlAdmin.Size = new Size(panelConfig.Size.Width - 50, panelConfig.Size.Height -50);
            //tabControlAdmin.Location = panelConfig.Location;
            //dgvTransacciones.Width = gbAhorros.Location.X - dgvTransacciones.Location.X - 30;
            //dgvPersonasA.Height = 668;
            //gbAhorros.Height = this.Width * (8 / 10);
            ////Botones
            //bttOtorgarPréstamo.Location = new Point(dgvBúsqueda.Width - bttOtorgarPréstamo.Width + dgvBúsqueda.Location.X, bttOtorgarPréstamo.Location.Y);
            //bttCrearCuenta.Location = bttAgregarAsociado.Location = bttOtorgarPréstamo.Location;
            //bttPagosRealizados.Location = new Point(dgvBúsqueda.Width - bttPagosRealizados.Width + dgvBúsqueda.Location.X, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            //bttVerEstados.Location = bttAportar.Location = bttPagosRealizados.Location;
            //bttAmortizacion.Location = new Point(dgvBúsqueda.Location.X+(dgvBúsqueda.Width-bttAmortizacion.Width)/2, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            //bttRetirar.Location = bttDatosAsociado.Location = bttAmortizacion.Location;
            //bttRealizarPago.Location = new Point(dgvBúsqueda.Location.X, dgvBúsqueda.Location.Y + dgvBúsqueda.Height + 18);
            //bttAbono.Location = bttRealizarPago.Location;
            //Refresh();
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
                Validaciones.IsNullOrEmpty(ref txtNombreActual, ref errorProvider1) &&
                Validaciones.IsNullOrEmpty(ref txtApellidoActual, ref errorProvider1) &&
                Validaciones.IsNullOrEmpty(ref txtCorreoElectrónicoNuevo, ref errorProvider1) &&
                Validaciones.ValidarNomApe(ref txtNombreActual, ref errorProvider1) &&
                Validaciones.ValidarNomApe(ref txtApellidoActual, ref errorProvider1) &&
                Validaciones.validar_correo(ref txtCorreoElectrónicoNuevo, ref errorProvider1) &&
                Validaciones.IsNullOrEmpty(ref txtNuevaContraseña, ref errorProvider1) &&
                Validaciones.IsNullOrEmpty(ref txtConfContraseña, ref errorProvider1) &&
                Validaciones.validar_contraseñas(txtNuevaContraseña, ref errorProvider1) &&
                Validaciones.claves_iguales(txtNuevaContraseña, txtConfContraseña, ref errorProvider1))   

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
                                Validaciones.IsNullOrEmpty(ref txtNuevaContraseña, ref errorProvider1) &&
                                Validaciones.IsNullOrEmpty(ref txtConfContraseña, ref errorProvider1) &&
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
                        ds = Cargar.llenar_DataSet("ModificarDatos", parámetros);
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
            //e.Graphics.DrawLine(new Pen(Brushes.Black, 3), 10, 32, panelConfig.Width - 10, 32);//23
            //e.Graphics.DrawLine(new Pen(Brushes.Black, 2), 10, 196, panelConfig.Width - 10, 196);//180
            //e.Graphics.DrawLine(new Pen(Brushes.Black, 2), 10, 347, panelConfig.Width - 10, 347);//331
        }
        private void Bordes_Paint(object sender, PaintEventArgs e)
        {
            Pen c= (new Pen(Brushes.Purple,2));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width-1, 0), new Point(Width-1, Height-2));
            Linea.DrawLine(c, new Point(1, 0), new Point(1, Height));
            Linea.DrawLine(c, new Point(0, Height-1), new Point(Width, Height-1));
            Linea.DrawLine(c, new Point(Width, 1), new Point(0,1));
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
            try
            {
                string salida_datos = "";
                string[] palabra_busqueda = this.txtBúsqueda.Text.Split(' ');
                if (dgvControl == "Ahorro")
                {
                    foreach (string palabra in palabra_busqueda)
                    {
                        if (salida_datos.Length == 0)
                        {
                            salida_datos = "(Dui LIKE '%" + palabra + "%' OR [Código de Ahorro] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [TipoA] LIKE '%" + palabra + "%')";
                        }
                        else
                        {
                            salida_datos += " AND(Dui LIKE '%" + palabra + "%' OR [Código de Ahorro] LIKE '%" + palabra + "%' OR [Persona Asociada] LIKE '%" + palabra + "%' OR [TipoA] LIKE '%" + palabra + "%')";
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
            catch { }
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
        #region Cambio de Fecha
        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;
            Cargando_Datos_DGV();
            Cargando_Datos_Text();
        }

        private void lbContraseña_Click(object sender, EventArgs e)
        {

        }

        private void dgvPersonasA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bttSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labContraseña_Click(object sender, EventArgs e)
        {

        }

        private void lbContraseña_Click_1(object sender, EventArgs e)
        {

        }

        private void labCNueva_Click(object sender, EventArgs e)
        {

        }

        private void labCConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void txtConfContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNuevaContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void PBMostrar2_Click(object sender, EventArgs e)
        {

        }

        private void PBMostrar3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            dtDesde.MaxDate = dtHasta.Value;
            Cargando_Datos_DGV();
            Cargando_Datos_Text();
        }
        #endregion
        #region Cambio Index
        private void cbTransacción_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string salida_datos = "";
                if (cbTransacción.SelectedIndex != 0)
                {
                    string palabras = cbTransacción.Text;
                    salida_datos = "(Transacción LIKE '%" + palabras + "%')";
                }
                this.filtro1.RowFilter = salida_datos;
            }
            catch { }
        }

        private void dgvPersonasA_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DatoA())
            {
                Administar_Asociado Admin = new Administar_Asociado(Dato);
                Admin.ShowDialog();
                Admin.Dispose();
                //Cargando = true;
            }
            else
                MessageBox.Show("No ha seleccionado un registro válido", "Carga de datos fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
        #region Efecto botones barra título
        private void bttMin_MouseHover(object sender, EventArgs e)
        {
            bttMin.BackColor = Color.FromArgb(35, 45, 129);
        }



        private void bttMin_MouseLeave(object sender, EventArgs e)
        {
            bttMin.BackColor = Seleccionado;
        }

        private void bttMin_MouseDown(object sender, MouseEventArgs e)
        {
            bttMin.BackColor = Color.Blue;
        }

        private void bttMax_MouseDown(object sender, MouseEventArgs e)
        {
            bttMax.BackColor = Color.Blue;
        }

        private void bttMax_MouseHover(object sender, EventArgs e)
        {
            bttMax.BackColor = Color.FromArgb(35, 45, 129);
        }

        private void bttMax_MouseLeave(object sender, EventArgs e)
        {
            bttMax.BackColor = Seleccionado;
        }

        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Seleccionado;
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

    }
}