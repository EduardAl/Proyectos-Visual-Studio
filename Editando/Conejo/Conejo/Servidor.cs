using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.Sql;

namespace Conejo
{
    class Servidor
    {
        SqlDataSourceEnumerator servidores;
        DataTable tablaServidores;
        List<String> listaServidores = new List<String>();
        public Servidor()
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
                Globales.Servidor = listaServidores[1];
            }
        }
        public bool elegido(int row)
        {
            try
            {
                Globales.Servidor = listaServidores[row];
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
