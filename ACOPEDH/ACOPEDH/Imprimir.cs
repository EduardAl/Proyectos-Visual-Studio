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

namespace ACOPEDH
{
    public partial class Imprimir : Form
    {
        public string Datos, Opción;
        DataTable dt;
        Procedimientos_select seleccionar = new Procedimientos_select();
        SqlParameter[] Param = new SqlParameter[1];

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
                    Estado info = new Estado();
                    DataSet ds = new DataSet();
                    info.DataSourceConnections[0].SetConnection(Globales.Servidor, "ACOPEDH", Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
                    Param[0] = new SqlParameter("@ID_Ahorro", Datos);
                    ds = seleccionar.llenar_DataSet("[Cargar Abonos]", Param,"Abono");
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
    }
}
