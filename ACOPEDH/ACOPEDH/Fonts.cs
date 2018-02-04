using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace ACOPEDH
{
    class Fonts
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        DataGridView dvg;
        FontFamily FontFam;
        Font Fonty;

        public Fonts()
        {
            Iniciar();
        }
        public Fonts(byte[] CargarFuente)
        {
            Iniciar(CargarFuente);
        }
        public Fonts(DataGridView dvgBúsqueda)
        {
            dvg = dvgBúsqueda;
        }
        //Procedimiento para el diseño del DataGridView
        public void Diseño()
        {
            dvg.BorderStyle = BorderStyle.None;
            dvg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dvg.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dvg.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dvg.DefaultCellStyle.SelectionForeColor = Color.Black;
            dvg.BackgroundColor = Color.White;
            dvg.EnableHeadersVisualStyles = false;
            dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dvg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dvg.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dvg.ColumnHeadersDefaultCellStyle.Font = new Font("Linotte-SemiBold", 12);
            dvg.DefaultCellStyle.Font = new Font("Linotte-Light", 12);
        }
        private void Iniciar()
        {
            byte[] FontArray = Properties.Resources.Folks_Light;
            int DataLenght = Properties.Resources.Folks_Light.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(DataLenght);
            Marshal.Copy(FontArray, 0, ptrData, DataLenght);

            uint cFont = 0;
            AddFontMemResourceEx(ptrData, (uint)FontArray.Length, IntPtr.Zero, ref cFont);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, DataLenght);

            Marshal.FreeCoTaskMem(ptrData);

            FontFam = pfc.Families[0];
            Fonty = new Font(FontFam, 15f, FontStyle.Bold);

        }
        private bool Iniciar(byte[] CargarFuente)
        {
            try
            {
                byte[] FontArray = CargarFuente;
                int DataLenght = CargarFuente.Length;

                IntPtr ptrData = Marshal.AllocCoTaskMem(DataLenght);
                Marshal.Copy(FontArray, 0, ptrData, DataLenght);

                uint cFont = 0;

                AddFontMemResourceEx(ptrData, (uint)FontArray.Length, IntPtr.Zero, ref cFont);

                PrivateFontCollection pfc = new PrivateFontCollection();

                pfc.AddMemoryFont(ptrData, DataLenght);

                Marshal.FreeCoTaskMem(ptrData);

                FontFam = pfc.Families[0];
                Fonty = new Font(FontFam, 15f, FontStyle.Bold);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Font Fuente(float size, FontStyle Style)
        {
            return new Font(FontFam, size, Style);
        }
        public Font Fuente(float size, FontStyle Style, byte[] Fuente)
        {
            Iniciar(Fuente);
            return new Font(FontFam, size, Style);
        }
    }
}
