using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using ACOPEDH.Modelos;

namespace ACOPEDH
{
    public class Procedimientos_select
    {
        Conexión cn;
        SqlCommand Comando;
        SqlConnection conex = new SqlConnection();
        public int llenar_tabla(string procedimiento, SqlParameter[] param)
        {
            int resultado = 0;
            cn = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
            try
            {
                conex = new SqlConnection(cn.cadena);
                conex.InfoMessage += new SqlInfoMessageEventHandler(Conex_InfoMessage);
                conex.Open();
                Comando = new SqlCommand(procedimiento, conex);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = procedimiento;
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                for (int x = 0; x < (param.Length); x++)
                    Comando.Parameters.Add(param[x]);
                resultado = Comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
            return resultado;
        }
        public DataTable llenar_DataTable(string procedimiento)
        {
            cn = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
            DataTable dt = new DataTable();
            try
            {
                conex = new SqlConnection(cn.cadena);
                conex.Open();
                Comando = new SqlCommand(procedimiento, conex);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                da.Fill(dt);
                da.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
            return dt;
        }
        public DataTable llenar_DataTable(string procedimiento, SqlParameter[] param)
        {
            cn = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
            DataTable dt = new DataTable();
            try
            {
                conex = new SqlConnection(cn.cadena);
                conex.Open();
                Comando = new SqlCommand(procedimiento, conex);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                for (int x = 0; x < (param.Length); x++)
                    Comando.Parameters.Add(param[x]);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar extraer los datos.\n" + ex.Message);
            }
            finally
            {
                conex.Close();
            }
            return dt;
        }
        public DataSet llenar_DataSet(string procedimiento, SqlParameter[] param)
        {
            cn = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
            DataSet ds = new DataSet();
            try
            {
                conex = new SqlConnection(cn.cadena);
                conex.Open();
                conex.InfoMessage += new SqlInfoMessageEventHandler(Conex_InfoMessage);
                Comando = new SqlCommand(procedimiento, conex);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                for (int x = 0; x < (param.Length); x++)
                    Comando.Parameters.Add(param[x]);
                int registro = da.Fill(ds, "Usuarios");

                da.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar extraer los datos.\n" + ex.Message);
            }
            finally
            {
                conex.Close();
            }
            return ds;
        }
        public DataSet llenar_DataSet(string procedimiento, SqlParameter[] param, String ptabla)
        {
            cn = new Conexión();
            DataSet ds = new DataSet();
            try
            {
                conex = new SqlConnection(cn.cadena);
                conex.InfoMessage += new SqlInfoMessageEventHandler(Conex_InfoMessage);
                conex.Open();
                Comando = new SqlCommand();
                Comando.Connection = conex;
                Comando.CommandText = procedimiento;
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Comando);
                for (int x = 0; x < (param.Length - 1); x++)
                {
                    Comando.Parameters.Add(param[x]);
                }
                Comando.Parameters.Add(param[param.Length - 1]).Direction = ParameterDirection.Output;
                int registro = da.Fill(ds, ptabla);
                da.SelectCommand = Comando;
                da.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar extraer los datos.\n" + ex.Message.ToString());
            }
            finally
            {
                conex.Close();
            }
            return ds;
        }
        public List<model_abonos> ConsultaLista_Abono(string procedimiento, SqlParameter[] param)
        {
            List<model_abonos> lista = new List<model_abonos>();
            try
            {
                cn = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
                conex = new SqlConnection(cn.cadena);
                conex.InfoMessage += new SqlInfoMessageEventHandler(Conex_InfoMessage);
                conex.Open();
                Comando = new SqlCommand();
                Comando.Connection = conex;
                Comando.CommandText = procedimiento;
                Comando.CommandType = CommandType.StoredProcedure;
                for (int x = 0; x < (param.Length); x++)
                    Comando.Parameters.Add(param[x]);
                SqlDataReader dr = (Comando.ExecuteReader());
                //Read the data and store them in the list
                while (dr.Read())
                {
                    model_abonos modelo = new model_abonos();
                    modelo.Monto = double.Parse(dr["Monto Abonado"].ToString());
                    modelo.AbonoComision = double.Parse(dr["Abono más Comisión"].ToString());
                    modelo.FechaRetiro =DateTime.Parse(dr["Fecha de Abono"].ToString());
                    lista.Add(modelo);
                }
                //close Data Reader
                dr.Close();
                //close Connection
                conex.Close();
                //return list to be displayed
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PROBLEMAS CON DATOS DE CONEXION" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lista;
            }
        }
        public List<model_retiros> ConsultaLista_Retiro(string procedimiento, SqlParameter[] param)
        {
            List<model_retiros> lista = new List<model_retiros>();
            try
            {
                cn = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
                conex = new SqlConnection(cn.cadena);
                conex.InfoMessage += new SqlInfoMessageEventHandler(Conex_InfoMessage);
                conex.Open();
                Comando = new SqlCommand();
                Comando.Connection = conex;
                Comando.CommandText = procedimiento;
                Comando.CommandType = CommandType.StoredProcedure;
                for (int x = 0; x < (param.Length); x++)
                    Comando.Parameters.Add(param[x]);
                SqlDataReader dr = (Comando.ExecuteReader());
                //Read the data and store them in the list
                while (dr.Read())
                {
                    model_retiros modelo = new model_retiros();
                    modelo.MontoRetiro= double.Parse(dr["Monto Retirado"].ToString());
                    modelo.Fecha_retiro = DateTime.Parse(dr["Fecha de Retiro"].ToString());
                    lista.Add(modelo);
                }
                //close Data Reader
                dr.Close();
                //close Connection
                conex.Close();
                //return list to be displayed
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PROBLEMAS CON DATOS DE CONEXION" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lista;
            }
        }
        public List<model_pagosRealizados> ConsultaLista_Pagos(string procedimiento, SqlParameter[] param)
        {
            List<model_pagosRealizados> lista = new List<model_pagosRealizados>();
            try
            {
                cn = new Conexión(Globales.gbTipo_Usuario, Globales.gbClave_Tipo_Usuario);
                conex = new SqlConnection(cn.cadena);
                conex.InfoMessage += new SqlInfoMessageEventHandler(Conex_InfoMessage);
                conex.Open();
                Comando = new SqlCommand();
                Comando.Connection = conex;
                Comando.CommandText = procedimiento;
                Comando.CommandType = CommandType.StoredProcedure;
                for (int x = 0; x < (param.Length); x++)
                    Comando.Parameters.Add(param[x]);
                SqlDataReader dr = (Comando.ExecuteReader());
                //Read the data and store them in the list
                while (dr.Read())
                {
                    model_pagosRealizados modelo = new model_pagosRealizados();
                    modelo.N_pagos = int.Parse(dr["No Pago"].ToString());
                    modelo.Pago = double.Parse(dr["Monto Cancelado"].ToString());
                    modelo.PagoIntereses = double.Parse(dr["Pago a Intereses"].ToString());
                    modelo.PagoCapital = double.Parse(dr["Pago a Capital"].ToString());
                    modelo.Mora = double.Parse(dr["Mora por retraso"].ToString());
                    modelo.Saldo = double.Parse(dr["Saldo restante"].ToString());
                    modelo.FechaPago = DateTime.Parse(dr["Fecha de Pago"].ToString());
                    modelo.FechaLimite = DateTime.Parse(dr["Fecha Límite de Pago"].ToString());
                    lista.Add(modelo);
                }
                //close Data Reader
                dr.Close();
                //close Connection
                conex.Close();
                //return list to be displayed
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PROBLEMAS CON DATOS DE CONEXION" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lista;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //   Obtinene los mensajes o errores de un procedimiento almacenado por medio de la cadena de conexión   //
        //   añadiendo .InfoMessage a la cadena y llamando a esta funcion ver el procedimiento "LlenarDataSet"   //
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Conex_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            String mensaje = "";
            if (e.Errors.Count > 0)
            {
                mensaje = e.Errors[0].Message;
            }
            Globales.gbError = mensaje;
        }

        #region Llamadas a internos
        public DataTable LlenarText(string procedimiento, string Rows, params String[] Text)
        {
            DataTable Llenado = new DataTable();
            try
            {
                Llenado = llenar_DataTable(procedimiento);
                String[] Row = Rows.Split(',');
                DataRow row = Llenado.Rows[0];
                for (int j = 0; j < Text.Length; j++)
                {
                    Text[j] = Convert.ToString(row[Row[j]]);
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error, por favor intentelo de nuevo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Llenado;
        }
        public DataTable LlenarText(string procedimiento, string Rows,SqlParameter[] param, params TextBox[] Text)
        {
            DataTable Llenado = new DataTable();
            try
            {
                Llenado = llenar_DataTable(procedimiento, param);
                String[] Row = Rows.Split(',');
                DataRow row = Llenado.Rows[0];
                int j = 0;
                foreach(TextBox text in Text)
                {
                    text.Text= Convert.ToString(row[Row[j]]); ;
                    j++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, por favor intentelo de nuevo más tarde" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Llenado;
        }
#endregion
    }
}
// SqlConnection conex = new SqlConnection(@"Data Source = GISSELLE-REYES\YIYEL501;Initial Catalog =ACOPEDH;User=sa;Password=1311");
