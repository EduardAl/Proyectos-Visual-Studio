using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conejo
{
    public partial class Nuevo_Ahorro : Form
    {
        Mostrar_Datos Mostrar = new Mostrar_Datos();
        Búsqueda buscar = new Búsqueda(true);
        string CódigoAsociado = "";
        public Nuevo_Ahorro()
        {
            InitializeComponent();
        }

        private void Nuevo_Ahorro_Load(object sender, EventArgs e)
        {
            Mostrar.LlenarTextBox("Select Nombre, [Tasa de Interés] From [Tipo de Ahorro]","Tasa de Interés","Nombre",ref cbTipo,txtInterés);
            Mostrar.LlenarTextBox("Select (Nombres +' '+Apellidos)AS NAME from Asociado where [Código Asociado]='" + CódigoAsociado + "'", "NAME", txtAsociado);
            cbTipo.SelectedIndex = 0;
        }

        private void bttCrear_Click(object sender, EventArgs e)
        {
            string query2 = "Select [id Tipo Ahorro] From [Tipo de Ahorro] where Nombre='" + cbTipo.Text + "'";
            string query = "Insert into Ahorro values ('A','" + Mostrar.ConseguirUno(query2, "FK Tipo de Ahorro") + "','" + CódigoAsociado + "')";
            if (Mostrar.ConseguirUno("Select [FK Tipo Ahorro] from Ahorro where [FK Tipo Ahorro]='" + Mostrar.ConseguirUno(query2, "FK Tipo Ahorro") + "' AND [FK Código de Asociado]='" + CódigoAsociado + "'", "") == "")
            {
                if (Mostrar.GuardarModificarEliminar(query))
                {
                    MessageBox.Show("¡Datos Almacenados Correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                    MessageBox.Show("No se pudieron guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El usuario ya tiene una cuenta de este tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bttCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            buscar.ShowDialog();
            Visible = true;
            CódigoAsociado = buscar.Dato;
            Mostrar.LlenarTextBox("Select (Nombres +' '+Apellidos)AS NAME from Asociado where [Código Asociado]='" + CódigoAsociado + "'", "NAME", txtAsociado);
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInterés.Text = Mostrar.ConseguirUno("Select [Tasa de Interés] From [Tipo de Ahorro] where Nombre='" + cbTipo.Text + "'","[Tasa de Interés]");
        }
    }
}
