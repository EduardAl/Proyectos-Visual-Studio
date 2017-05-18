using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conejo
{
    public partial class Aportaciones : Form
    {
        /* ***************************
           *        Variables        *
           ***************************   */
        #region Variables
        Validaciones validar = new Validaciones();
        Mostrar_Datos Mostrar;
        String Asociado;
        #endregion

        /* ***************************
           *      Constructores      *
           ***************************     */
        #region Constructores
        public Aportaciones()
        {
            InitializeComponent();
            Búsqueda buscar = new Búsqueda(true);
            buscar.ShowDialog();
            if (buscar.DialogResult != DialogResult.OK)
                Close();
            Asociado = buscar.Dato;
            Mostrar = new Mostrar_Datos();
            Focus();
        }
        public Aportaciones(string Aso)
        {
            InitializeComponent();
            Asociado = Aso;
            Mostrar = new Mostrar_Datos();
            Focus();
        }
        #endregion

        /* ***************************
           *         Acciones        *
           ***************************     */
        #region Load
        private void Aportaciones_Load(object sender, EventArgs e)
        {
            try
            {
                txtAportaciones.Text = "$" + Math.Round(Mostrar.Suma("Aportación", "Aportaciones", "[FK Asociado]", Asociado),2).ToString();
                string query = "Select  Asociado.Nombres, Asociado.Apellidos from Asociado where[Código Asociado] ='" + Asociado + "'";
                Mostrar.LlenarTextBox(query, "Nombres,Apellidos", txtNombres, txtApellidos);
                query = "Select  [Fecha de Aportación],Aportación from Aportaciones where [FK Asociado]='" + Asociado + "' Order by [Fecha de Aportación]";
                Mostrar.CargarDatos(query, dgvAportaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bttAportar.Focus();
        }
        #endregion
        #region Click
        private void bttAportar_Click_1(object sender, EventArgs e)
        {
            Mostrar_Datos mostrando = new Mostrar_Datos();
            DateTime Prueba;
            if (mostrando.VerificarExiste("Month([Fecha de Aportación])", "MONTH(GetDate())", "Aportaciones", "AND [FK Asociado]='" + Asociado + "'", false))
                MessageBox.Show("Ya ha realizado una aportación este mes");
            else if (DateTime.TryParse(mostrando.ConseguirUno("Select [Fecha de Desasociación] from Asociado where [Código Asociado]='" + Asociado + "'", "Fecha de Desasociación"), out Prueba))
                MessageBox.Show("Esta persona ya no es un socio activo");
            else
            {
                if (mostrando.GuardarModificarEliminar("Insert into Aportaciones values(5,GETDATE(),'" + Asociado + "')"))
                {
                    MessageBox.Show("¡Datos almacenados correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar.CargarDatos("Select  [Fecha de Aportación],Aportación from Aportaciones where [FK Asociado]='" + Asociado + "' Order by [Fecha de Aportación]", dgvAportaciones);
                }
            }
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

    }
}
