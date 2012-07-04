using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Form_Mbcif.Forms
{
    public partial class Form_Relaciones : Form
    {
        Sistema sistema;

        //Inicializa los component
        public Form_Relaciones(Sistema sistema)
        {
            InitializeComponent();
            this.sistema = sistema;
        }
        //carga los componentes.
        private void Form_Relaciones_Load(object sender, EventArgs e)
        {
            set_combobox_nivel();
        }

        //Al presionar cancelar se sale sin hacer cambios, ni guardar datos.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //AL presionar aceptar
        //guarda los valores y se sale.
        private void button1_Click(object sender, EventArgs e)
        {
            //que guade las relaciones
            this.Close();
        }

        private void set_combobox_nivel()
        {
            foreach (Nivel x in sistema.niveles)
            {
                comboBox1.Items.Add(x.nombre);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Nivel x in sistema.niveles)
            {
                if (x.nombre.Equals(comboBox1.SelectedItem.ToString()))
                {
                    foreach (Elemento l in x.listaElementos)
                    {
                        comboBox2.Items.Add(l.nombre);
                    }
                }
            }
        }


    }
}