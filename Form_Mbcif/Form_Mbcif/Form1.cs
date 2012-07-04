using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Form_Mbcif
{
    public partial class Form1 : Form
    {
        Sistema sistema;
        public Form1()
        {
            InitializeComponent();
            sistema = new Sistema();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra ventana de ingreso de arbol.
            Forms.Forms ingreso_sistema = new Forms.Forms(this, sistema);
            ingreso_sistema.MdiParent = this;
            guardarToolStripMenuItem.Enabled = true;
            ingreso_sistema.Show();
        }

        
       
        

       
    }
}
