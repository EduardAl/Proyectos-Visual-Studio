using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Conejo
{
    class Mostrar_Datos
    {
        DataTable DatTable = new DataTable();
        SqlDataAdapter DataAdapt = new SqlDataAdapter();
        SqlDataReader DataReader;
        SqlCommand cmd;
        SqlConnection cn;
        Conexión conn = new Conexión();

        public Mostrar_Datos()
        {
            conn.conec("sa", "1311");
#warning Aqui modifique
            //  conn.conec(Globales.gbUsuario, Globales.gbClave);
            cn = new SqlConnection(conn.cadena);
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
        }
        public bool GuardarModificarEliminar(string query)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
            return false;
        }
        public bool PasarParametros(string query, string value, string tipos, string conv)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                String[] Valores = value.Split(',');
                String[] Tipos = tipos.Split(',');
                String[] Convertir = conv.Split(',');
                int i = 0;
                foreach (string val in Valores)
                {
                    if (Convertir[i] == "date")
                    {
                        cmd.Parameters.AddWithValue(Valores[i], String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Tipos[i])));
                    }
                    else
                        cmd.Parameters.AddWithValue(Valores[i], Tipos[i]);
                    i++;
                }
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool VerificarExiste(string buscar, string comparar, string Tabla, string And, bool esletra)
        {
            int i = 0;
            try
            {
                cn.Open();
                comparar = esletra ? "'" + comparar + "' " : comparar;
                cmd = new SqlCommand("Select* From " + Tabla + " where " + buscar + " = " + comparar + And, cn);
                DataReader = cmd.ExecuteReader();
                while (DataReader.Read())
                {
                    i++;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
            if (i > 0)
                return true;
            return false;
        }
        public void CargarDatos(string query, DataGridView dgv)
        {
            try
            {
                cn.Open();
                dgv.DataSource = null;
                DatTable = new DataTable();
                DataAdapt = new SqlDataAdapter(query, cn);
                DataAdapt.Fill(DatTable);
                dgv.DataSource = DatTable;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
        }

        public void CargarDesasociación(string query, DateTimePicker dateDesasociación, Button btt, Label lab)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                DataReader = cmd.ExecuteReader();
                cn.Close();
                DataAdapt = new SqlDataAdapter(cmd);
                DatTable = new DataTable();
                DataAdapt.Fill(DatTable);
                DataRow row = DatTable.Rows[0];
                DateTime proof;
                if (DateTime.TryParse(row["Fecha de Desasociación"].ToString(), out proof))
                {
                    dateDesasociación.Value = proof;
                    dateDesasociación.Visible = true;
                    btt.Visible = false;
                    lab.Visible = true;
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }
        public string ConseguirUno(string Query, string hallar)
        {
            string hallado = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                if (reader.Read())
                    hallado = Convert.ToString(reader[hallar]);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
            return hallado;

        }
        public string[] ConseguirVarios(string Query, string hallar)
        {
            string hallado = "";
            string[] Devolver = new string[1];
            Devolver[0] = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Query, cn);
                DataReader = cmd.ExecuteReader();
                DataAdapt = new SqlDataAdapter(cmd);
                int i = 0;
                while (DataReader.Read())
                {
                    hallado = i == 0 ? (DataReader[hallar].ToString()) : hallado + "," + (DataReader[hallar].ToString());
                    i++;
                }
                cn.Close();
                if (i > 0)
                {
                    return hallado.Split(',');
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
            return Devolver;

        }
        public void LlenarCombo(ref ComboBox cb, string datoeditado, string nuevodato, string tabla, bool sin)
        {
            try
            {
                string query = sin ? "Select " + datoeditado + " From " + tabla : "Select " + nuevodato + " From " + tabla;
                cn.Open();
                cmd = new SqlCommand(query, cn);
                DataReader = cmd.ExecuteReader();
                DatTable = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                while (DataReader.Read())
                {
                    cb.Items.Add(DataReader[nuevodato].ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }
        public void LlenarCombo(ref ComboBox cb, string dato, string tabla, bool sin)
        {
            try
            {
                string query = sin ? "Select " + dato + " From " + tabla : "Select [" + dato + "] From " + tabla;
                cn.Open();
                cmd = new SqlCommand(query, cn);
                DataReader = cmd.ExecuteReader();
                DatTable = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                while (DataReader.Read())
                {
                    cb.Items.Add(DataReader[dato].ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }

        public void LlenarList(ref ListBox cb, string query, string dato)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                DataReader = cmd.ExecuteReader();
                DatTable = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                while (DataReader.Read())
                {
                    cb.Items.Add(DataReader[dato].ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }
        public decimal Suma(string Campo, string Tabla, string Comparar, string codigo)
        {
            decimal i = 0;
            try
            {
                string query = "SELECT Sum(" + Campo + ") AS 'Retornar' FROM " + Tabla + " where " + Comparar + "= '" + codigo + "'";
                cn.Open();
                cmd = new SqlCommand(query, cn);
                DataReader = cmd.ExecuteReader();
                cn.Close();
                DataAdapt = new SqlDataAdapter(cmd);
                DatTable = new DataTable();
                DataAdapt.Fill(DatTable);
                DataRow row = DatTable.Rows[0];
                row = DatTable.Rows[0];
                decimal.TryParse(row["Retornar"].ToString(), out i);
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show("Error N°: " + ex.ErrorCode + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return i;
        }
        public bool LlenarTextBox(string query, string rows, params TextBox[] Text)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                cn.Close();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                DataRow row = dt.Rows[0];
                int i = 0;
                String[] Row = rows.Split(',');
                foreach (TextBox Texto in Text)
                {
                    Texto.Text = Convert.ToString(row[Row[i]]);
                    i++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        public bool LlenarTextBox(string query, string rows, string rowsextra, ref ComboBox cb, params TextBox[] Text)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                cn.Close();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                DataRow row = dt.Rows[0];
                int i = 0;
                String[] Row = rows.Split(',');
                String[] RowExtra = rowsextra.Split(',');
                foreach (TextBox Texto in Text)
                {
                    Text[i].Text = Convert.ToString(row[Row[i]]);
                    i++;
                }

                cb.SelectedIndex = cb.FindString(row[RowExtra[0]].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        public bool LlenarTextBox(string query, string rows, string rowsextra, ref ComboBox cb, ref DateTimePicker dtB, ref DateTimePicker dtA, params TextBox[] Text)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                cn.Close();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                DataRow row = dt.Rows[0];
                int i = 0;
                String[] Row = rows.Split(',');
                String[] RowExtra = rowsextra.Split(',');
                foreach (TextBox Texto in Text)
                {
                    Text[i].Text = Convert.ToString(row[Row[i]]);
                    i++;
                }

                cb.SelectedIndex = cb.FindString(row[RowExtra[0]].ToString());
                dtB.Text = Convert.ToString(row[RowExtra[1]]);
                dtA.Text = Convert.ToString(row[RowExtra[2]]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

    }
}
