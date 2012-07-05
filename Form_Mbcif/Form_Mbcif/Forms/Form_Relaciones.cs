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
        DataGridView tablaElementos, tablaRelaciones;

        //Inicializa los component
        public Form_Relaciones(Sistema sistema, DataGridView tablaElementos, DataGridView tablaRelaciones)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.listarniveles();
            this.tablaElementos = tablaElementos;
            this.tablaRelaciones = tablaRelaciones;
                        
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

            string nombr_iteracion = comboBox5.SelectedItem.ToString();
            int iteracion = int.Parse(nombr_iteracion);


            //obtiene el nombre de los elementos seleccionados
            string elemento1 = comboBox2.SelectedItem.ToString();
            string elemento2 = comboBox3.SelectedItem.ToString();


            if (comboBox4.SelectedItem.ToString().Equals("Sin Restriccion"))
            {
                relacion relacion_nueva = new relacion(textBox1.Text, new regla(iteracion));

                foreach (Nivel x in sistema.niveles)
                {
                    if (x.nombre.Equals(comboBox1.SelectedItem.ToString()))
                    {
                       int index1 = x.get_indice(elemento1);
                       int index2 = x.get_indice(elemento2);
                       x.agregarRelacion(index1, index2, relacion_nueva);
                    }
                }
            }
            else
            {
                double valor = double.Parse(textBox2.Text);
                string signo = comboBox4.SelectedItem.ToString();
                relacion relacion_nueva = new relacion(textBox1.Text, new regla(valor,signo,iteracion));
           
                foreach (Nivel x in sistema.niveles)
                {
                    if (x.nombre.Equals(comboBox1.SelectedItem.ToString()))
                    {
                        int index1 = x.get_indice(elemento1);
                        int index2 = x.get_indice(elemento2);
                        x.agregarRelacion(index1, index2, relacion_nueva);
                    }
                }
                 }

            listarniveles();
            limpiartextbox();

            llenarTablas();
        }

        public void llenarTablas()
        {

            tablaElementos.Rows.Clear();
            //llenar tabla elementos
            for (int i = 0; i < sistema.niveles.Count; i++)
            {
                tablaElementos.Rows.Add("Nivel " + i + " :" + sistema.niveles[i].nombre, " ",
                           " ");
                for (int j = 0; j < sistema.niveles[i].listaElementos.Count; j++)
                {
                    tablaElementos.Rows.Add(sistema.niveles[i].nombre, sistema.niveles[i].listaElementos[j].nombre,
                        sistema.niveles[i].listaElementos[j].valor);
                }

            }

            tablaRelaciones.Rows.Clear();
            //llenar tabla relaciones
            for (int a = 0; a < sistema.niveles.Count; a++)
            {
                tablaRelaciones.Rows.Add("Nivel " + a + " :" + sistema.niveles[a].nombre, " ",
                           " ");
                for (int b = 0; b < sistema.niveles[a].matriz.Count; b++)
                {
                    for (int c = 0; c < sistema.niveles[a].matriz[b].Count; c++)
                        if (sistema.niveles[a].matriz[b][c] != null)
                            if (sistema.niveles[a].matriz[b][c].Regla.operador != null)
                                tablaRelaciones.Rows.Add(sistema.niveles[a].nombre,
                                sistema.niveles[a].listaElementos[b].nombre, sistema.niveles[a].listaElementos[c].nombre,
                                sistema.niveles[a].matriz[b][c].funcion, sistema.niveles[a].matriz[b][c].Regla.iteracion,
                                sistema.niveles[a].matriz[b][c].Regla.operador + sistema.niveles[a].matriz[b][c].Regla.valor);
                            else
                                tablaRelaciones.Rows.Add(sistema.niveles[a].nombre,
                                sistema.niveles[a].listaElementos[b].nombre, sistema.niveles[a].listaElementos[c].nombre,
                                sistema.niveles[a].matriz[b][c].funcion, sistema.niveles[a].matriz[b][c].Regla.iteracion,
                                "-");
                }
            }

        }

        private void limpiartextbox()
        {
            foreach (Control c in this.Controls)
            {
                if (c is ComboBox)
                {
                    c.Text ="";
                }
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void set_combobox_nivel()
        {
            comboBox1.Items.Clear();
            foreach (Nivel x in sistema.niveles)
            {
                comboBox1.Items.Add(x.nombre);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            foreach (Nivel x in sistema.niveles)
            {
                if (x.nombre.Equals(comboBox1.SelectedItem.ToString()))
                {
                    foreach (Elemento l in x.listaElementos)
                    {
                        comboBox2.Items.Add(l.nombre);
                        comboBox3.Items.Add(l.nombre);
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString().Equals("Sin Restriccion"))
            {
                textBox2.Enabled = false;
            }
            else 
            {
                textBox2.Enabled = true;
            }
        }

        public void listarniveles()
        {
            dataGridView1.Rows.Clear();
            List<Nivel> l = sistema.returnnivel();
            foreach (Nivel niv in l)
            {
                for(int i=0; i< niv.matriz.Count;i++)
                {
                    for(int j=0; j<niv.matriz[i].Count;j++)
                    {
                        if (niv.matriz[i][j] != null)
                        {
                            dataGridView1.Rows.Add(niv.nombre,niv.listaElementos[i].nombre, niv.listaElementos[j].nombre, niv.matriz[i][j].funcion, niv.matriz[i][j].Regla.iteracion);
                        }
                    }
                }
            }
        }
    }
}