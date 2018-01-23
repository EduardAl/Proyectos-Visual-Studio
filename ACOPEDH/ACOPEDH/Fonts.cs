using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace ACOPEDH
{
    class Fonts
    {
        DataGridView dvg;
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
    }
}
