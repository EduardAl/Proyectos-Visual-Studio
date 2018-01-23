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
using Microsoft.Reporting.WinForms;
using System.IO;
using ACOPEDH.Modelos;

namespace ACOPEDH
{
    public partial class Imprimir : Form
    {
        public string Datos, Opción;
        DataTable dt;
        Procedimientos_select seleccionar = new Procedimientos_select();
        SqlParameter[] Param = new SqlParameter[1];
        List<model_Amortización> lista = new List<model_Amortización>();
        Constancia_Aportación cons;

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
        //public Imprimir(List<model_Amortización> Lista, string op)
        //{
        //    lista = Lista;
        //    Opción = op;
        //}
        //private List<Modelos.model_abonos>returnList()
        //{
        //    List<model_abonos> Lista = new List<model_abonos>();
        //    Lista.Add(new model_abonos(25.10, 10.15));
        //    Lista.Add(new model_abonos(255.10, 30.25));
        //    Lista.Add(new model_abonos(205.10, 100.15));
        //    return Lista;
        //}
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
#warning Aun no está terminado
                case "Estado":
                    Estado info = new Estado();
                    //Mostrar Abonos y Retiros
                    Param[0] = new SqlParameter("@ID_AHORRO", Datos);
                    info.SetDataSource(seleccionar.ConsultaLista_Retiro("Cargar Retiros", Param));
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    info.SetDataSource(seleccionar.ConsultaLista_Abono("Cargar Abonos", Param));
                    //Datos generales del reporte
                    Param[0] = new SqlParameter("@Código_Ahorro", Datos);
                    dt = seleccionar.LlenarText("[Cargar Ahorros]", "Nombre,Código_A,TipoA", Param);
                    info.SetParameterValue("Nombre", dt.Rows[0]["Nombre"]);
                    info.SetParameterValue("P_Ahorro", Datos);
                    info.SetParameterValue("P_Código", dt.Rows[0]["Código_A"]);
                    info.SetParameterValue("P_Tipo_Ahorro", dt.Rows[0]["TipoA"]);
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    dt = seleccionar.LlenarText("[Suma Abonos]", "Suma de Abonos", Param);
                    info.SetParameterValue("P_Suma_Abonos", dt.Rows[0]["Suma de Abonos"]);
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    dt = seleccionar.LlenarText("Suma Retiros", "Suma de Retiros", Param);
                    info.SetParameterValue("P_Total_Retiros", dt.Rows[0]["Suma de Retiros"]);
                    crystalReportViewer1.ReportSource = info;
                    break;
                //Carta de Comunicación del Préstamo
                case "Carta":
                    Carta_Comunicación cc = new Carta_Comunicación();
                    Procedimiento();
                    cc.SetParameterValue("PNombre", dt.Rows[0]["Nombre"]);
                    cc.SetParameterValue("Apellido", dt.Rows[0]["Ape"]);
                    cc.SetParameterValue("PMonto", dt.Rows[0]["Monto"]);
                    cc.SetParameterValue("NoCuotas", dt.Rows[0]["NCuotas"]);
                    cc.SetParameterValue("Monto_Cuota", dt.Rows[0]["PCuotas"]);
                    cc.SetParameterValue("Tipo_Préstamo", dt.Rows[0]["TipoP"]);
                    cc.SetParameterValue("Forma_de_Pago", dt.Rows[0]["FormaP"]);
                    cc.SetParameterValue("Llamado", "Señor, Señora, Señorita");
                    cc.SetParameterValue("DUI", dt.Rows[0]["PDUI"]);
                    crystalReportViewer1.ReportSource = cc;
                    break;
                //Pagaré del Préstamo
                case "Pagaré":
                    Pagaré P = new Pagaré();
                    Procedimiento();
                    P.SetParameterValue("PNombre", dt.Rows[0]["Nombre"]);
                    P.SetParameterValue("DUI", dt.Rows[0]["PDUI"]);
                    P.SetParameterValue("Dirección", dt.Rows[0]["Dir"]);
                    P.SetParameterValue("Insertar Cantidad de Préstamo en Letras", "[Insertar Cantidad de Préstamo en Letras aquí]");
                    P.SetParameterValue("Teléfono", "7185-9632");
                    crystalReportViewer1.ReportSource = P;
                    break;
                //Carta de Desembolso del Préstamo
                case "Desembolso":
                    Hoja_Desembolso hd = new Hoja_Desembolso();
                    Procedimiento();
                    hd.SetParameterValue("PNombre", dt.Rows[0]["Nombre"]);
                    hd.SetParameterValue("Lugar de Trabajo", dt.Rows[0]["Trabajo"]);
                    hd.SetParameterValue("Préstamo", dt.Rows[0]["Préstamo"]);
                    hd.SetParameterValue("Tipo de Préstamo", dt.Rows[0]["TipoP"]);
                    hd.SetParameterValue("Tasa de Interés", dt.Rows[0]["Interés"]);
                    hd.SetParameterValue("Monto de Préstamo", dt.Rows[0]["Monto"]);
                    hd.SetParameterValue("Descuento", "—");
                    crystalReportViewer1.ReportSource = hd;
                    break;
                //Carta de Recibo del Préstamo
                case "Recibo":
                    Recibo r = new Recibo();
                    Procedimiento();
                    r.SetParameterValue("PNombre", dt.Rows[0]["Nombre"]);
                    r.SetParameterValue("Monto de Préstamo", dt.Rows[0]["Monto"]);
                    r.SetParameterValue("No de Cuotas", dt.Rows[0]["NCuotas"]);
                    r.SetParameterValue("Monto de Préstamo", dt.Rows[0]["Monto"]);
                    r.SetParameterValue("DUI", dt.Rows[0]["PDUI"]);
                    crystalReportViewer1.ReportSource = r;
                    break;
                //Tabla de Amortización
                case "Amortización":
                    Constancia_Amortización ca = new Constancia_Amortización();
                    ca.SetDataSource(lista);
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
                //Constancia de Aportación
                case "Aportación":
                    cons = new Constancia_Aportación();
                    Param[0] = new SqlParameter("@Código_Asociado", Datos);
                    dt = seleccionar.LlenarText("[Suma Aportaciones]", "Suma de Aportaciones", Param);
                    cons.SetParameterValue("Sumatoria",dt.Rows[0]["Suma de Aportaciones"]);
                    Param[0] = new SqlParameter("@Código_Asociado", Datos);
                    dt = seleccionar.LlenarText("[Cargar Asociados]", "Name,LName", Param);
                    cons.SetParameterValue("Nombre", dt.Rows[0]["Name"]);
                    cons.SetParameterValue("Apellido", dt.Rows[0]["LName"]);
                    cons.SetParameterValue("Codigo", Datos);
                    crystalReportViewer1.ReportSource = cons;
                    break;
                //Constancia de Abono
                case "Abono":
                    Constancia_de_Abono abono = new Constancia_de_Abono();
                    Param[0] = new SqlParameter("@ID_Ahorro",Datos);
                    dt = seleccionar.LlenarText("[Constancia Abono]", "Pid_Abono,PNombre,Código Asociado,Abono", Param);
                    abono.SetParameterValue("Código", dt.Rows[0]["Código Asociado"]);
                    abono.SetParameterValue("Nombre", dt.Rows[0]["PNombre"]);
                    abono.SetParameterValue("Abono", dt.Rows[0]["Abono"]);
                    abono.SetParameterValue("Id_Ahorro", Datos);
                    crystalReportViewer1.ReportSource= abono;
                    break;
                //Constancia Retiro
                case "Retiro":
#warning Aun no funciona
                    Constancia_de_Retiro retiro = new Constancia_de_Retiro();
                    crystalReportViewer1.ReportSource = retiro;
                    break;
            }
        }
        public void Procedimiento()
        {
            Param[0] = new SqlParameter("@Codigo", Datos);
            dt = seleccionar.LlenarText("[Informe Préstamo]", "Código_A,Nombre,Ape,Préstamo,Dir,Trabajo,FormaP,TipoP,PDUI,Interés,Monto,FechaT,NCuotas,PCuotas,Estado", Param);
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
        private void Imprimir_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = false;
            }
        }
        private void Imprimir_MouseMove(object sender, MouseEventArgs e)
        {
            if (Empezarmover)
            {
                Point temp = new Point();
                temp.X = Location.X + (e.X - PosX);
                temp.Y = Location.Y + (e.Y - PosY);
                Location = temp;
            }
        }
        private void Imprimir_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = true;
                PosX = e.X;
                PosY = e.Y;
            }
        }
        #endregion
    }
}
