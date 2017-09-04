using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ACOPEDH
{
    #region esto se puede eliminar si se usa host
    class Servidor
    {
        //Clase que obtiene el servidor local
        SqlDataSourceEnumerator servidores;
        DataTable tablaServidores;
        List<String> listaServidores = new List<String>();
        public void server()
        {
            try
            {
                tablaServidores = new DataTable();
                servidores = SqlDataSourceEnumerator.Instance;
                if (tablaServidores.Rows.Count == 0)
                {
                    tablaServidores = servidores.GetDataSources();

                    foreach (DataRow rowServidor in tablaServidores.Rows)
                    {
                        if (String.IsNullOrEmpty(rowServidor["InstanceName"].ToString()))
                            listaServidores.Add(rowServidor["ServerName"].ToString());
                        else
                            listaServidores.Add(rowServidor["ServerName"] + "\\" + rowServidor["InstanceName"]);
                    }
                    Globales.Servidor = listaServidores[0];
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al conectar con el servidor.\n" + "Número del error: " + ex.Number + "\nCódigo del error: " + ex.ErrorCode + "\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
    #endregion
}
