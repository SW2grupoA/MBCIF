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
    public partial class Form_Elementos : Form
    {
        Sistema sistema;

        public Form_Elementos(Sistema sistema)
        {
            InitializeComponent();
            this.sistema = sistema;
           
        }
        //Al cargar la ventana.
        private void Form_Elementos_Load(object sender, EventArgs e)
        {
            set_combobox_niveles();
            set_List_elementos();
        }
        //A presionar aceptar guarda y se sale.
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
          
        }
        //Al presionar cancelar se cierra.
        private void button2_Click(object sender, EventArgs e)
        {
            //guardar los datos de la tabla

            foreach (Nivel n in sistema.niveles)
            {
                if (n.nombre.Equals(comboBox1.SelectedItem.ToString()))
                {
                    Elemento elemento = new Elemento(textBox1.Text, double.Parse(textBox2.Text));
                    n.agregarElemento(elemento);
                }
            }
            limpia_text(sender, e);
           
        }

        private void limpia_text(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedItem = null;
            Form_Elementos_Load(sender, e);
        }
        private void set_combobox_niveles()
        {
            comboBox1.Items.Clear();
            foreach (Nivel x in sistema.niveles)
            {
                comboBox1.Items.Add(x.nombre);
            }
        }

        private void set_List_elementos()
        {
            listBox1.Items.Clear();
            foreach (Nivel x in sistema.niveles)
            {
                foreach (Elemento y in x.listaElementos)
                {
                    listBox1.Items.Add(y.nombre);
                }
                
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           MessageBox.Show(""+ listBox1.SelectedItem.ToString());
            string elemento_value = listBox1.SelectedItem.ToString();
           foreach (Nivel x in sistema.niveles)
           {
               foreach (Elemento l in x.listaElementos)
               {
                   if(l.nombre.Equals(elemento_value))
                   {
                       textBox1.Text = elemento_value;
                       textBox2.Text = l.valor.ToString();
                   }
               }
           }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (comboBox1.SelectedItem != null)
            {
                string nombre = comboBox1.SelectedItem.ToString();
                foreach (Nivel n in sistema.niveles)
                {
                    if (n.nombre.Equals(nombre))
                    {
                        foreach (Elemento l in n.listaElementos)
                        {
                            listBox2.Items.Add(l.nombre);
                        }
                    }

                }
            }
        }

      
    }
}
