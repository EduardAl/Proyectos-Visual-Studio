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
        DataTable dt;
        Procedimientos_select seleccionar = new Procedimientos_select();
        SqlParameter[] Param = new SqlParameter[1];
        List<modelo_Amortización> lista = new List<modelo_Amortización>();

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
        #endregion
        #region Load
        private void Imprimir_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //Procedimiento para imprimir
            Imprimiendo_Informes(Opción);
            crystalReportViewer1.Refresh();
            //Prueba
            //CrystalDecisions.CrystalReports.Engine.ReportDocument reporte = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            
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
                    Param[0] = new SqlParameter("@Código_Asociado", Datos);
                    dt = seleccionar.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Param);
                    cons.SetParameterValue("Sumatoria", dt.Rows[0]["Suma de Aportaciones"]);
                    Param[0] = new SqlParameter("@Código_Asociado", Datos);
                    dt = seleccionar.LlenarText("[Cargar Asociados]", "Name,LName", Param);
                    cons.SetParameterValue("Nombre", dt.Rows[0]["Name"]);
                    cons.SetParameterValue("Apellido", dt.Rows[0]["LName"]);
                    cons.SetParameterValue("Codigo", Datos);
                    Param[0] = new SqlParameter("@Código_Asociado",Datos);
                    dt = seleccionar.LlenarText("[Cargar Aportaciones]","[Monto de la Aportación]",Param);
                    cons.SetParameterValue("Aportaciones",dt.Rows[0]["Monto de la Aportación"]);
                    crystalReportViewer1.ReportSource = cons;
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
                    break;
#warning Aquí me da problemas mostrar los datos del DVG Abonos y Retiros
                case "Estado":
                    Informe_EstadoCuenta info = new Informe_EstadoCuenta();
                    DataSet ds = new DataSet();
                    info.DataSourceConnections[0].SetConnection(Globales.Servidor, "ACOPEDH", Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    ds = seleccionar.llenar_DataSet("[Cargar Abonos]", Param, "Abono");
                    info.Database.Tables["Abonos"].SetDataSource(ds);
                    crystalReportViewer1.ReportSource = info;
                    //dt = seleccionar.llenar_DataTable("[Cargar Abonos]", Param);
                    //info.Database.Tables["Abonos"].SetDataSource(dt);
                    //crystalReportViewer1.ReportSource = info;
                    //Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    //dtt = seleccionar.llenar_DataTable("[Cargar Retiros]", Param);
                    //info.Database.Tables["Retiros"].SetDataSource(dtt);
                    //crystalReportViewer1.ReportSource = info;
                    break;
                case "Préstamo":
                    Informes_Préstamos P = new Informes_Préstamos();
                    ConversiónNúmeros conv = new ConversiónNúmeros();
                    string montoletras = ""; ;
                    Param[0] = new SqlParameter("@Codigo", Datos);
                    dt = seleccionar.LlenarText("[Informe Préstamo]", "Código_A,Nombre,Apellido,Préstamo,Dir,Trabajo,FormaP,TipoP,PDUI,Interés,Monto,FechaT,NCuotas,PCuotas,Estado", Param);
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
                        P.SetParameterValue("MontoLetras", montoletras);
                        P.SetParameterValue("Descuento", "—");
                        crystalReportViewer1.ReportSource = P;
                    }
                    catch { }
                    break;
                //Tabla de Amortización
                case "Amortización":
                    Constancia_Amortización ca = new Constancia_Amortización();
                    //Mostrando la tabla de amortización
                    ca.SetDataSource(seleccionar.);
                    //Mostrando los datos del encabezado
                    Param[0] = new SqlParameter("@ID_Préstamo", Datos);
                    dt = seleccionar.LlenarText("[Cargar Préstamo]","Nombre,Monto,PCuotas,Código_A,NCuotas,Interés,FechaT",Param);
                    ca.SetParameterValue("Nombre", dt.Rows[0]["Nombre"]);
                    ca.SetParameterValue("Monto", dt.Rows[0]["Monto"]);
                    ca.SetParameterValue("Pago mensual", dt.Rows[0]["PCuotas"]);
                    ca.SetParameterValue("P_Código", dt.Rows[0]["Código_A"]);
                    ca.SetParameterValue("Plazo", dt.Rows[0]["NCuotas"]);
                    ca.SetParameterValue("Interés", dt.Rows[0]["Interés"]);
                    ca.SetParameterValue("Fecha", dt.Rows[0]["FechaT"]);
                    ca.SetParameterValue("ID_Préstamo", Datos);
                    crystalReportViewer1.ReportSource = ca;
                    break;
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
                    break;
                case "Abono":
                    Constancia_Abono abono = new Constancia_Abono();
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    dt = seleccionar.LlenarText("[Constancia Abono]", "Pid_Abono,PNombre,PTipo,PInterés,Abono", Param);
                    abono.SetParameterValue("No_Abono", dt.Rows[0]["Pid_Abono"]);
                    abono.SetParameterValue("P_Nombre", dt.Rows[0]["PNombre"]);
                    abono.SetParameterValue("P_Tipo_Ahorro", dt.Rows[0]["PTipo"]);
                    abono.SetParameterValue("P_Interés", dt.Rows[0]["PInterés"]);
                    abono.SetParameterValue("P_Abono", dt.Rows[0]["Abono"]);
                    abono.SetParameterValue("No_Ahorro", Datos);
                    crystalReportViewer1.ReportSource = abono;
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
