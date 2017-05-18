using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Conejo
{
    class Fonts
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

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
