using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ACOPEDH
{
    public partial class Gráfica : Form
    {
        /*
            *********************************
            *     Componentes Iniciales     *
            ********************************* 
        */
        #region Variables
        DateTime Validar1, Validar2;
        DataTable Data;
        DataTable DataOriginal;
        SqlParameter[] Parámetros = new SqlParameter[2];
        String[] Valores = new string[4];
        double value = 0;
        Procedimientos_select Cargar = new Procedimientos_select();
        #endregion
        #region Constructores
        public Gráfica()
        {
            InitializeComponent();
            SqlParameter[] Parámetros = new SqlParameter[2];
            Parámetros[0] = new SqlParameter("@Fecha_Inicial", DateTime.Today);
            Parámetros[1] = new SqlParameter("@Fecha_Final", DateTime.Today.AddDays(1).AddSeconds(-1));
            Data = DataOriginal = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
        }
        public Gráfica(DataTable data, DateTime Desde, DateTime Hasta)
        {
            InitializeComponent();
            chGráfica.DataSource = DataOriginal = Data = data;
            dtDesde.Value = Desde;
            dtHasta.Value = Hasta;
            GenerarOriginal();
        }
        #endregion
        #region Load
        private void Gráfica_Load(object sender, EventArgs e)
        {
            try
            {
                cbComparación.SelectedIndex =
                cbFechas.SelectedIndex = 0;
                chGráfica.Series[0].ChartType = SeriesChartType.Bubble;
                Validar1 = dtDesde.Value;
                Validar2 = dtHasta.Value;
                gbPersonalizado.Size = new Size(375, 280);
                gbPersonalizado.Location =
                    new Point((int)((chGráfica.Location.X - 375) / 2), (int)((Height + BarraTítulo.Height - 280) / 2));
                GenerarOriginal();
                chGráfica.Legends[0].Font = new Font("Linotte-Regular", 10F, FontStyle.Regular, GraphicsUnit.Point);
                chGráfica.Legends[0].IsTextAutoFit = true;
            }
            catch { }
        }
        #endregion

        /*
           *********************************
           *            Botones            *
           ********************************* 
       */
        #region Cerrar
        private void bttCer_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Graficar
        private void bttGraficar_Click(object sender, EventArgs e)
        {
            if (cbComparación.Text == "Generado")
            {
                GenerarOriginal();
            }
            else
            {
                try
                {
                    if (Validar1 != dtDesde.Value || Validar2 != dtHasta.Value)
                    {
                        SqlParameter[] Parámetros = new SqlParameter[2];
                        Parámetros[0] = new SqlParameter("@Fecha_Inicial", dtDesde.Value);
                        Parámetros[1] = new SqlParameter("@Fecha_Final", dtHasta.Value);
                        Data = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
                    }
                    GenerarComparaciones();
                }
                catch { }
            }
        }
        #endregion

        /*
       *********************************
       *            Métodos            *
       ********************************* 
   */
        #region Generar Gráfica
        private void GenerarOriginal()
        {
            chGráfica.Series.Clear();
            //Cargar el gráfico Original
            try
            {
                chGráfica.Series.Add("Datos Cooperativa");
                chGráfica.Series[0].ChartType = SeriesChartType.Pie;
                String[] Titles = new String[8];
                Double[] Values = new Double[8];
                //Títulos
                Titles[0] = Convert.ToString("Abonos a cuentas de ahorro");
                Titles[1] = Convert.ToString("Retiros en cuentas de ahorro");
                Titles[2] = Convert.ToString("Aportaciones realizadas");
                Titles[3] = Convert.ToString("Retiro de aportaciones");
                Titles[4] = Convert.ToString("Préstamos otorgados");
                Titles[5] = Convert.ToString("Pagos a capital de préstamos");
                Titles[6] = Convert.ToString("Ingresos por intereses");
                Titles[7] = Convert.ToString("Ingresos por mora");
                //Valores
                Double.TryParse(DataOriginal.Rows[0]["Abonos"].ToString(), out Values[0]);
                Double.TryParse(DataOriginal.Rows[0]["Retiros"].ToString(), out Values[1]);
                Double.TryParse(DataOriginal.Rows[0]["Aportaciones"].ToString(), out Values[2]);
                Double.TryParse(DataOriginal.Rows[0]["RetiroAportación"].ToString(), out Values[3]);
                Double.TryParse(DataOriginal.Rows[0]["Préstamos_Otorgados"].ToString(), out Values[4]);
                Double.TryParse(DataOriginal.Rows[0]["Pago_Capital"].ToString(), out Values[5]);
                Double.TryParse(DataOriginal.Rows[0]["Intereses_Pagados"].ToString(), out Values[6]);
                Double.TryParse(DataOriginal.Rows[0]["Mora_Pagada"].ToString(), out Values[7]);
                for (int i = 0; i < Titles.Length; i++)
                {
                    chGráfica.Series["Datos Cooperativa"].Points.AddXY(Titles[i], Values[i].ToString("C2"));
                    chGráfica.Series[0].Points[i].IsValueShownAsLabel = true;
                }
                chGráfica.Series[0].IsValueShownAsLabel = false;
                chGráfica.Series[0].Font = new Font("Linotte-Regular", 10F, FontStyle.Regular, GraphicsUnit.Point);
            }
            catch (Exception exe)
            {
                chGráfica.Series.Clear();
                MessageBox.Show(exe.Message, "Ocurrió un error durante la carga del gráfico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarComparaciones()
        {
            chGráfica.Series.Clear();
            switch (cbComparación.Text)
            {
                case "Comparar Ahorros":
                    Valores[0] = "Abonos";
                    Valores[1] = "Retiros";
                    Valores[2] = "Abonos";
                    Valores[3] = "Retiros";
                    break;
                case "Comparar Aportaciones":
                    Valores[0] = "Aportaciones";
                    Valores[1] = "RetiroAportación";
                    Valores[2] = "Aportaciones realizadas";
                    Valores[3] = "Retiro de aportaciones";
                    break;
                case "Comparar Préstamos":
                    Valores[0] = "Préstamos_Otorgados";
                    Valores[1] = "Pago_Capital";
                    Valores[2] = "Préstamos aprobados";
                    Valores[3] = "Pago a capital";
                    break;
                case "Comparar Ingresos":
                    Valores[0] = "Intereses_Pagados";
                    Valores[1] = "Mora_Pagada";
                    Valores[2] = "Intereses";
                    Valores[3] = "Mora cancelada";
                    break;
                default:
                    Valores[0] = "TotalP";
                    Valores[1] = "TotalN";
                    Valores[2] = "Transacciones de abonos y pagos";
                    Valores[3] = "Transacciones de préstamos y retiros";
                    break;
            }
            chGráfica.Series.Add(Valores[2]);
            chGráfica.Series.Add(Valores[3]);
            chGráfica.Series[0].ChartType = SeriesChartType.Column;
            chGráfica.Series[1].ChartType = SeriesChartType.Column;

            switch (cbFechas.Text)
            {
                case "Años":
                    try
                    {
                        for (int i = dtDesde.Value.Year; i <= dtHasta.Value.Year; i++)
                        {
                            value = 0;
                            Parámetros[0] = new SqlParameter("@Fecha_Inicial", new DateTime(i, 1, 1));
                            Parámetros[1] = new SqlParameter("@Fecha_Final", new DateTime(i, 12, 31, 11, 59, 59));
                            //Valores
                            Data = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
                            Double.TryParse(Data.Rows[0][Valores[0]].ToString(), out value);
                            chGráfica.Series[0].Points.AddXY(i, value.ToString("C2"));
                            value = 0;
                            Double.TryParse(Data.Rows[0][Valores[1]].ToString(), out value);
                            chGráfica.Series[1].Points.AddXY(i, value.ToString("C2"));
                        }
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, "Ocurrió un error durante la carga del gráfico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Meses":
                    try
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            value = 0;
                            Parámetros[0] = new SqlParameter("@Fecha_Inicial", new DateTime(dtHasta.Value.Year, i, 1));
                            Parámetros[1] = new SqlParameter("@Fecha_Final", new DateTime(dtHasta.Value.Year, i, DateTime.DaysInMonth(dtHasta.Value.Year, i), 11, 59, 59));
                            //Valores
                            Data = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
                            Double.TryParse(Data.Rows[0][Valores[0]].ToString(), out value);
                            chGráfica.Series[0].Points.AddXY(Mes(i),value);
                            value = 0;
                            Double.TryParse(Data.Rows[0][Valores[1]].ToString(), out value);
                            chGráfica.Series[1].Points.AddXY(Mes(i),value);
                        }
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, "Ocurrió un error durante la carga del gráfico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Año Pasado":
                    try
                    {
                        value = 0;
                        Parámetros[0] = new SqlParameter("@Fecha_Inicial", new DateTime(dtHasta.Value.Year, 1, 1));
                        Parámetros[1] = new SqlParameter("@Fecha_Final", new DateTime(dtHasta.Value.Year, 12, 31, 11, 59, 59));
                        //Valores
                        Data = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
                        Double.TryParse(Data.Rows[0][Valores[0]].ToString(), out value);
                        chGráfica.Series[0].Points.AddXY(dtHasta.Value.Year, value);
                        value = 0;
                        Double.TryParse(Data.Rows[0][Valores[1]].ToString(), out value);
                        chGráfica.Series[1].Points.AddXY(dtHasta.Value.Year, value);

                        value = 0;
                        Parámetros[0] = new SqlParameter("@Fecha_Inicial", new DateTime(dtHasta.Value.Year - 1, 1, 1));
                        Parámetros[1] = new SqlParameter("@Fecha_Final", new DateTime(dtHasta.Value.Year - 1, 12, 31, 11, 59, 59));
                        //Valores
                        Data = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
                        Double.TryParse(Data.Rows[0][Valores[0]].ToString(), out value);
                        chGráfica.Series[0].Points.AddXY(dtHasta.Value.Year - 1, value);
                        value = 0;
                        Double.TryParse(Data.Rows[0][Valores[1]].ToString(), out value);
                        chGráfica.Series[1].Points.AddXY(dtHasta.Value.Year - 1, value);
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, "Ocurrió un error durante la carga del gráfico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Mes Pasado":
                    try
                    {
                        DateTime ayuda = new DateTime(dtHasta.Value.Year, dtHasta.Value.Month, 1);

                        value = 0;
                        Parámetros[0] = new SqlParameter("@Fecha_Inicial", ayuda.AddMonths(-1));
                        Parámetros[1] = new SqlParameter("@Fecha_Final", ayuda.AddSeconds(-1));
                        //Valores
                        Data = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
                        Double.TryParse(Data.Rows[0][Valores[0]].ToString(), out value);
                        chGráfica.Series[0].Points.AddXY(Mes(ayuda.AddMonths(-1).Month), value);
                        value = 0;
                        Double.TryParse(Data.Rows[0][Valores[1]].ToString(), out value);
                        chGráfica.Series[1].Points.AddXY(Mes(ayuda.AddMonths(-1).Month), value);

                        value = 0;
                        Parámetros[0] = new SqlParameter("@Fecha_Inicial", ayuda);
                        Parámetros[1] = new SqlParameter("@Fecha_Final", ayuda.AddMonths(1).AddSeconds(-1));
                        //Valores
                        Data = Cargar.llenar_DataTable("[Conseguir Datos Cooperativa]", Parámetros);
                        Double.TryParse(Data.Rows[0][Valores[0]].ToString(), out value);
                        chGráfica.Series[0].Points.AddXY(Mes(ayuda.Month), value);
                        value = 0;
                        Double.TryParse(Data.Rows[0][Valores[1]].ToString(), out value);
                        chGráfica.Series[1].Points.AddXY(Mes(ayuda.Month), value);
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, "Ocurrió un error durante la carga del gráfico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    GenerarOriginal();
                    break;
            }
            chGráfica.Series[0].LabelAngle = 90;
            chGráfica.Series[1].LabelAngle = 90;
            chGráfica.Series[0].Font = new Font("Linotte-Regular", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chGráfica.Series[1].Font = new Font("Linotte-Regular", 10F, FontStyle.Regular, GraphicsUnit.Point);
        }
        #endregion
        #region Conseguir Mes
        public string Mes(int mes)
        {
            DateTimeFormatInfo dtinfo = CultureInfo.CurrentCulture.DateTimeFormat;
            return dtinfo.GetMonthName(mes);
        }
        #endregion

        /*
            *********************************
            *            Eventos            *
            ********************************* 
        */
        #region Cambio de index
        private void cbComparación_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFechas.Enabled = (cbComparación.Text != "Generado");
        }
        private void cbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtDesde.Enabled = (cbFechas.SelectedIndex==0||cbFechas.SelectedIndex==1)?true:false;
        }
        #endregion

    }
}
