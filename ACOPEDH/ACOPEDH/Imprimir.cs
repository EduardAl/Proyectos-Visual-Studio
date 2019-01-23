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
using ACOPEDH.Modelos;

namespace ACOPEDH
{
    public partial class Imprimir : Form
    {
        public string Datos, Opción;
        private double aqui = 0, Abono = 0, Retiro = 0, Saldo = 0;
        DataTable dt;
        Procedimientos_select seleccionar = new Procedimientos_select();
        SqlParameter[] Param = new SqlParameter[1];
        public List<modelo_Amortización> ListaDatos;

        #region Constructores
        public Imprimir()
        {
            InitializeComponent();
        }
        public Imprimir(string dato, string op)
        {
            InitializeComponent();
            Datos = dato;
            Opción = op;
        }
        public Imprimir(List<modelo_Amortización> datos, string dato, string op)
        {
            InitializeComponent();
            ListaDatos = new List<modelo_Amortización>(datos);
            Datos = dato;
            Opción = op;
        }
        #endregion
        #region Load
        private void Imprimir_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            MaximumSize = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width - 15, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height - 15);
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //Procedimiento para imprimir
            Imprimiendo_Informes(Opción);
            crystalReportViewer1.Refresh();
            
        }
        #endregion
        #region Procedimientos
        public void Imprimiendo_Informes(string Opción)
        {
            switch (Opción)
            {
                //Constancia de Aportación
                case "Aportación":
                    Constancia_Aportación cons = new Constancia_Aportación();
                    //Cargamos la Suma de Aportaciones
                    Param[0] = new SqlParameter("@Código_Asociado", int.Parse(Datos));
                    dt = seleccionar.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Param);
                    cons.SetParameterValue("Sumatoria", dt.Rows[0]["Suma de Aportaciones"]);
                    //Cargamos los datos del Asociado en el reporte
                    Param[0] = new SqlParameter("@Código_Asociado", int.Parse(Datos));
                    dt = seleccionar.LlenarText("[Cargar Asociados]", "Name,LName", Param);
                    cons.SetParameterValue("Nombre", dt.Rows[0]["Name"]);
                    cons.SetParameterValue("Apellido", dt.Rows[0]["LName"]);
                    cons.SetParameterValue("Codigo", Datos);
                    //Cargamos aportaciones
                    Param[0] = new SqlParameter("@Código_Asociado", int.Parse(Datos));
                    dt = seleccionar.LlenarText("[Cargar Aportaciones]", "[Monto de la Aportación]", Param);
                    cons.SetParameterValue("Aportaciones", dt.Rows[0]["Monto de la Aportación"]);
                    crystalReportViewer1.ReportSource = cons;
                    BarraTítulo.Text = "         ACOPEDH - Constancia de Aportación";
                    break;
                //Constancia Retiro de Aportaciones
                case "Retiro Aportaciones":
                    Constancia_RetiroAportación retiro_ap = new Constancia_RetiroAportación();
                    Param[0] = new SqlParameter("@Código_Asociado", int.Parse(Datos));
                    dt = seleccionar.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Param);
                    retiro_ap.SetParameterValue("Suma", dt.Rows[0]["Suma de Aportaciones"]);
                    retiro_ap.SetParameterValue("Retiro", dt.Rows[0]["Suma de Aportaciones"]);
                    Param[0] = new SqlParameter("@Codigo", int.Parse(Datos));
                    dt = seleccionar.LlenarText("[Constancia Retiro Aportaciones]", "NombreP,EstadoP", Param);
                    retiro_ap.SetParameterValue("Cod",Datos);
                    retiro_ap.SetParameterValue("Nombre", dt.Rows[0]["NombreP"]);
                    retiro_ap.SetParameterValue("Estado", dt.Rows[0]["EstadoP"]);
                    crystalReportViewer1.ReportSource = retiro_ap;
                    BarraTítulo.Text = "         ACOPEDH - Constancia de Retiro de Aportaciones";
                    break;
                //Constancia de Pago
                case "Pago":
                    Constancia_Pago cp = new Constancia_Pago();
                    Param[0] = new SqlParameter("@Id_Préstamo", Datos);
                    dt = seleccionar.LlenarText("[Constancia Pago]", "Pid_Pago,PPréstamo,PNombre,Monto mínimo,Psaldo,PPago,Pmora,PFecha", Param);
                    cp.SetParameterValue("No_Pago", dt.Rows[0]["Pid_Pago"]);
                    cp.SetParameterValue("No_Préstamo", dt.Rows[0]["PPréstamo"]);
                    cp.SetParameterValue("Nombre", dt.Rows[0]["PNombre"]);
                    cp.SetParameterValue("Monto", dt.Rows[0]["Monto mínimo"]);
                    cp.SetParameterValue("Saldo", dt.Rows[0]["Psaldo"]);
                    cp.SetParameterValue("Pago", dt.Rows[0]["PPago"]);
                    cp.SetParameterValue("Mora", dt.Rows[0]["Pmora"]);
                    cp.SetParameterValue("Fecha", dt.Rows[0]["PFecha"]);
                    crystalReportViewer1.ReportSource = cp;
                    BarraTítulo.Text = "         ACOPEDH - Constancia de Pago";
                    break;
                //Constancia de Estado de Cuenta
                case "Estado":
                    Informe_EstadoCuenta info = new Informe_EstadoCuenta();
                    Estado_Abonos abonos = new Estado_Abonos();
                    Estado_Retiros retiros = new Estado_Retiros();
                    Retiro = 0; Saldo = 0; Abono = 0;
                    //Subinforme de Abonos
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    abonos.SetDataSource(seleccionar.ConsultaLista_Abono("[Cargar Abonos]", Param));
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    info.Subreports[0].SetDataSource(seleccionar.ConsultaLista_Abono("[Cargar Abonos]", Param));
                    //Subinforme de Retiros
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    retiros.SetDataSource(seleccionar.ConsultaLista_Retiro("[Cargar Retiros]",Param));
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    info.Subreports[1].SetDataSource(seleccionar.ConsultaLista_Retiro("[Cargar Retiros]",Param));
                    //Datos de Encabezado
                    Param[0] = new SqlParameter("@Código_Ahorro", Datos);
                    dt = seleccionar.LlenarText("[Cargar Ahorros]", "Nombre,Código_A,Est,TipoA,Interés", Param);
                    info.SetParameterValue("Nombre", dt.Rows[0]["Nombre"]);
                    info.SetParameterValue("Código", dt.Rows[0]["Código_A"]);
                    info.SetParameterValue("Estado", dt.Rows[0]["Est"]);
                    info.SetParameterValue("TipoAhorro", dt.Rows[0]["TipoA"]);
                    info.SetParameterValue("Interés", dt.Rows[0]["Interés"]);
                    info.SetParameterValue("No_Ahorro", Datos);
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    dt = seleccionar.LlenarText("[Suma Abonos]", "Suma de Abonos", Param);
                    Abono = Convert.ToDouble(dt.Rows[0]["Suma de Abonos"].ToString());
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    dt = seleccionar.LlenarText("[Suma Retiros]", "Suma de Retiros", Param);
                    Retiro = Convert.ToDouble(dt.Rows[0]["Suma de Retiros"].ToString());
                    Saldo = Math.Round(Abono - Retiro, 2);
                    info.SetParameterValue("AbonoIntereses", Abono);
                    info.SetParameterValue("TotalRetiros", Retiro);
                    info.SetParameterValue("SaldoActual", Saldo);
                    crystalReportViewer1.ReportSource = info;
                    BarraTítulo.Text = "         ACOPEDH - Estado de Cuenta";
                    break;
                //Constancia de Nuevo Préstamo
                case "Préstamo":
                    Informes_Préstamos P = new Informes_Préstamos();
                    ConversiónNúmeros conv = new ConversiónNúmeros();
                    string montoletras = ""; ;
                    Param[0] = new SqlParameter("@Codigo", int.Parse(Datos));
                    dt = seleccionar.LlenarText("[Informe Préstamo]", "Código_A,Nombre,Apellido,Préstamo,Dir,Trabajo,FormaP,TipoP,PDUI,Interés,Monto,FechaT,NCuotas,PCuotas,Estado", Param);
                    MessageBox.Show(dt.Rows[0]["Monto"].ToString());
                    montoletras = conv.Decimales(dt.Rows[0]["Monto"].ToString());
                    try
                    {
                        P.SetParameterValue("P_Nombre", dt.Rows[0]["Nombre"]);
                        P.SetParameterValue("P_Apellido", dt.Rows[0]["Apellido"]);
                        P.SetParameterValue("P_DUI", dt.Rows[0]["PDUI"]);
                        P.SetParameterValue("P_Dirección", dt.Rows[0]["Dir"]);
                        P.SetParameterValue("P_Lugar_de_Trabajo", dt.Rows[0]["Trabajo"]);
                        P.SetParameterValue("P_Cuota_Mensual", dt.Rows[0]["PCuotas"]);
                        P.SetParameterValue("P_NoCuotas", dt.Rows[0]["NCuotas"]);
                        P.SetParameterValue("P_Tipo_de_Préstamo", dt.Rows[0]["TipoP"]);
                        P.SetParameterValue("P_Forma_de_Pago", dt.Rows[0]["FormaP"]);
                        P.SetParameterValue("P_Monto_de_Préstamo", dt.Rows[0]["Monto"]);
                        P.SetParameterValue("P_Tasa_de_Interés", dt.Rows[0]["Interés"]);
                        P.SetParameterValue("No_Préstamo", dt.Rows[0]["Préstamo"]);
                        P.SetParameterValue("Llamado", "Señor, Señora, Señorita");
                        P.SetParameterValue("Presidenta", "Larissa Nataly Ventura");
                        P.SetParameterValue("Secretaria", "Beatriz Campos Ceballos");
                        P.SetParameterValue("MontoLetras", montoletras);
                        P.SetParameterValue("Descuento", "—");
                        crystalReportViewer1.ReportSource = P;
                    }
                    catch { }
                    BarraTítulo.Text = "         ACOPEDH - Nuevo Préstamo";
                    break;
                //Tabla de Amortización
                case "Amortización":
                    Constancia_Amortización ca = new Constancia_Amortización();
                    ca.SetDataSource(ListaDatos);
                    if (Datos != "")
                    {
                        Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                        dt = seleccionar.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Código_A,Monto,FechaT,NCuotas,TipoP,Estado,Interés", Param);
                        ca.SetParameterValue("Nombre", dt.Rows[0]["Nombre"]);
                        ca.SetParameterValue("Pago mensual", dt.Rows[0]["PCuotas"]);
                        ca.SetParameterValue("P_Código", dt.Rows[0]["Código_A"]);
                        ca.SetParameterValue("Monto", dt.Rows[0]["Monto"]);
                        ca.SetParameterValue("Fecha", dt.Rows[0]["FechaT"]);
                        ca.SetParameterValue("Plazo", dt.Rows[0]["NCuotas"]);
                        ca.SetParameterValue("Tipo préstamo", dt.Rows[0]["TipoP"]);
                        ca.SetParameterValue("PInterés", dt.Rows[0]["Interés"]);
                        ca.SetParameterValue("Estado", dt.Rows[0]["Estado"]);
                        ca.SetParameterValue("id_Préstamo", Datos);
                    }
                    else
                    {
                        ca.SetParameterValue("Nombre", "");
                        ca.SetParameterValue("Pago mensual", 0);
                        ca.SetParameterValue("P_Código", "");
                        ca.SetParameterValue("Monto", 0);
                        ca.SetParameterValue("Fecha", "");
                        ca.SetParameterValue("Plazo", "");
                        ca.SetParameterValue("Tipo préstamo", "");
                        ca.SetParameterValue("PInterés", 17);
                        ca.SetParameterValue("Estado", "");
                        ca.SetParameterValue("id_Préstamo", " ");
                    }
                    crystalReportViewer1.ReportSource = ca;
                    BarraTítulo.Text = "         ACOPEDH - Tabla de Amortización";
                    break;
                //Constancia de Pagos Realizados
                case "Pagos_Realizados":
                    MessageBox.Show(Datos);
                    Constancia_Pagos_Realizados pagos = new Constancia_Pagos_Realizados();
                    //Para mostrar los pagos realizados
                    Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                    pagos.SetDataSource(seleccionar.ConsultaLista_Pagos("Cargar Pagos", Param));
                    //Llenando Datos generales del Préstamo
                    Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                    dt = seleccionar.LlenarText("[Cargar Préstamo]", "Nombre,PCuotas,Monto,FechaT,NCuotas,TipoP,Estado,Interés", Param);
                    pagos.SetParameterValue("Nombre", dt.Rows[0]["Nombre"]);
                    pagos.SetParameterValue("Pago mensual", dt.Rows[0]["PCuotas"]);
                    pagos.SetParameterValue("Monto", dt.Rows[0]["Monto"]);
                    pagos.SetParameterValue("Fecha", dt.Rows[0]["FechaT"]);
                    pagos.SetParameterValue("Plazo", dt.Rows[0]["NCuotas"]);
                    pagos.SetParameterValue("Tipo préstamo", dt.Rows[0]["TipoP"]);
                    pagos.SetParameterValue("Tasa de Interés", dt.Rows[0]["Interés"]);
                    pagos.SetParameterValue("Estado", dt.Rows[0]["Estado"]);
                    pagos.SetParameterValue("ID_Préstamo", Datos);
                    crystalReportViewer1.ReportSource = pagos;
                    BarraTítulo.Text = "         ACOPEDH - Constancia de Pagos Realizados";
                    break;
                //Constancia de Abono
                case "Abono":
                    Constancia_Abono abono = new Constancia_Abono();
                    try
                    {
                        Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                        dt = seleccionar.LlenarText("[Constancia Abono]", "Pid_Abono,PNombre,PTipo,PInterés,Abono", Param);
                        abono.SetParameterValue("P_Nombre", dt.Rows[0]["PNombre"]);
                        abono.SetParameterValue("P_Tipo_Ahorro", dt.Rows[0]["PTipo"]);
                        abono.SetParameterValue("P_Interés", dt.Rows[0]["PInterés"]);
                        abono.SetParameterValue("P_Abono", dt.Rows[0]["Abono"]);
                        abono.SetParameterValue("No_Ahorro", Datos);
                        //Mostrar Monto disponible
                        Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                        double Abono = Convert.ToDouble(seleccionar.llenar_DataTable("[Suma Abonos]", Param).Rows[0]["Suma de Abonos"]);
                        Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                        double Retiro = Convert.ToDouble(seleccionar.llenar_DataTable("[Suma Retiros]", Param).Rows[0]["Suma de Retiros"]);
                        aqui = Math.Round(Abono - Retiro, 2);
                        abono.SetParameterValue("Disponible", aqui);
                        crystalReportViewer1.ReportSource = abono;
                        BarraTítulo.Text = "         ACOPEDH - Constancia de Abono";
                    }
                    catch { }
                    break;
                //Constancia de Retiro
                case "Retiro":
                    Constancia_de_Retiro retiro = new Constancia_de_Retiro();
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    dt = seleccionar.LlenarText("[Constancia Retiro]", "CantidadRetiro,idRetiro,Nombre,Tipo,Interés,Código,Cheque,Estado", Param);
                    retiro.SetParameterValue("Retiro", dt.Rows[0]["CantidadRetiro"]);
                    retiro.SetParameterValue("Nombre", dt.Rows[0]["Nombre"]);
                    retiro.SetParameterValue("Codigo", dt.Rows[0]["Código"]);
                    retiro.SetParameterValue("Cheque", dt.Rows[0]["Cheque"]);
                    retiro.SetParameterValue("Estado", dt.Rows[0]["Estado"]);
                    retiro.SetParameterValue("id_Ahorro", Datos);
                    //Mostrar Monto disponible
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    Abono = Convert.ToDouble(seleccionar.llenar_DataTable("[Suma Abonos]", Param).Rows[0]["Suma de Abonos"]);
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    Retiro = Convert.ToDouble(seleccionar.llenar_DataTable("[Suma Retiros]", Param).Rows[0]["Suma de Retiros"]);
                    aqui = Math.Round(Abono - Retiro, 2);
                    retiro.SetParameterValue("Disponible",aqui);
                    crystalReportViewer1.ReportSource = retiro;
                    BarraTítulo.Text = "         ACOPEDH - Constancia de Retiro";
                    break;
                //Constancia de Nuevo Ahorro
                case "Nuevo Ahorro":
                    Constancia_Nuevo_Ahorro ahorro = new Constancia_Nuevo_Ahorro();
                    Param[0] = new SqlParameter("@ID_Asociado",int.Parse(Datos));
                    dt = seleccionar.LlenarText("[Constancia Nuevo Ahorro]","Nombre,id_Ahorro,Tipo,Interés,Abono,Pid_Abono",Param);
                    ahorro.SetParameterValue("P_Nombre", dt.Rows[0]["Nombre"]);
                    ahorro.SetParameterValue("P_Tipo_Ahorro", dt.Rows[0]["Tipo"]);
                    ahorro.SetParameterValue("P_Interés", dt.Rows[0]["Interés"]);
                    ahorro.SetParameterValue("P_Abono", dt.Rows[0]["Abono"]);
                    ahorro.SetParameterValue("No_Ahorro",dt.Rows[0]["id_Ahorro"]);
                    crystalReportViewer1.ReportSource = ahorro;
                    BarraTítulo.Text = "         ACOPEDH - Constancia de Nuevo Ahorro";
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region Barra de Título
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttMax_Click(object sender, EventArgs e)
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

        private void Imprimir_SizeChanged(object sender, EventArgs e)
        {
            BarraTítulo.Size = new Size(Width, BarraTítulo.Size.Height);
        }

        private void bttMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
        #region Efecto botones barra título
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
            bttMax.BackColor = Color.FromArgb(20, 25, 72);
        }

        private void bttCer_MouseLeave(object sender, EventArgs e)
        {
            bttCer.BackColor = Color.FromArgb(20,25,72);
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
