﻿using System;
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
    public partial class Pagos : Form
    {
        string Dato;
        public Pagos()
        {
            InitializeComponent();
        }
        public Pagos(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }

        private void Pagos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void Pagos_Load(object sender, EventArgs e)
        {

        }
    }
}
