using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ACOPEDH
{
    public class Img
    {
        public byte[] Imagen;
        public DateTime FechaSubida;
        public string Id;
        public string Asociado;
        public string TipoImagen;
        public string Comentarios;

        public Img()
        {

        }
        public Img(byte[] Imagen, DateTime FechaSubida, string Id,string Asociado, string TipoImagen,string Comentarios)
        {
            this.Imagen = Imagen;
            this.FechaSubida = FechaSubida;
            this.Id = Id;
            this.Asociado = Asociado;
            this.TipoImagen = TipoImagen;
            this.Comentarios = Comentarios;
            this.Comentarios = Comentarios;
        }
        public static Img ConseguirDatos(List<Img> cons, string buscar)
        {
            foreach(Img c in cons)
            {
                if (c.Id == buscar)
                    return c;
            }
            return null;
        }

    }
}
