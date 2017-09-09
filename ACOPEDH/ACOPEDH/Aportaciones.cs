using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Aportaciones : Form
    {
        string Dato;
        public Aportaciones()
        {
            InitializeComponent();
        }
        public Aportaciones(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }
    }
}
