using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.Sql;

namespace ACOPEDH
{
    class Servidor
    {
        SqlDataSourceEnumerator servidores;
        DataTable tablaServidores;
        List<String> listaServidores = new List<String>();
        public Servidor()
        {
        }
        public void server()
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
    }
}
