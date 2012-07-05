using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Form_Mbcif.Forms
{
    public partial class Forms : Form
    {
        #region Variables
        TreeNode nodo;
        Form_Elementos elemento;
        Form_Relaciones relaciones;
        Form form;
        Sistema sistema;
        #endregion


        DataGridView tablaElementos, tablaRelaciones;
        public Forms(Form form, Sistema sistema, DataGridView tablaElementos, DataGridView tablaRelaciones)
        {
            InitializeComponent();
            this.form = form;
            this.sistema = sistema;
            this.tablaElementos = tablaElementos;
            this.tablaRelaciones = tablaRelaciones;


            this.BringToFront();
        }

        private void Forms_Load(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        //Funcion que al apretar sobre un nodo me permite agregar, editar o borrar.
        //Ver sus relaciones, y sus elementos
        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             nodo = treeView.SelectedNode;
             label1.Text = nodo.Text;
             panel1.Visible = true;
             nombre_textBox.Text = nodo.Text;

             if (nodo.Text.Equals("Nuevo_Subnivel"))
             {
                 comboBox1.Visible = true;
                 set_combobox();
                 label3.Visible = true;

                 if (comboBox1.Items.Count == 0)
                 {
                     nombre_textBox.Enabled = false;
                     Ingresar_button.Enabled = false;
                     Eliminar_button.Enabled = false;
                 }
                 else
                 {
                     nombre_textBox.Enabled = true;
                     Ingresar_button.Enabled = true;
                     Eliminar_button.Enabled = true;
                 }

             }
             else
             {
                 nombre_textBox.Enabled = true;
                 Ingresar_button.Enabled = true;
                 Eliminar_button.Enabled = true;
                 comboBox1.Visible = false;
                 label3.Visible = false;
             }
     
        }
        //Al presionar el boton aceptar me cambia el nombre ingresado en el arbol.
        //Y crea la opcion de ingresar un nuevo SUbSistema(o subnivel)
        private void button1_Click(object sender, EventArgs e)
        {
            

            Nivel nivel  = new Nivel(nombre_textBox.Text);
            if (existe() == false)
            {
                repetidoStripStatusLabel1.Text = "";
                sistema.agregarNivel(nivel);
                nivelesStripStatusLabel1.Text = "Niveles :" + sistema.niveles.Count;
                update_tree();
                Forms_Load(sender, e);
            }

            llenarTablas();
 
        }

        private bool existe()
        {
            foreach (Nivel n in sistema.niveles)
            {
                if (n.nombre.Equals(nombre_textBox.Text))
                {
                    repetidoStripStatusLabel1.Text = "Elemento Repetido";
                    return true;
                }
            }
            repetidoStripStatusLabel1.Text = "";
            return false;
        }
        //Al presionar el boton aceptar me cambia el nombre ingresado en el arbol.
        //Y crea la opcion de ingresar un nuevo SUbSistema(o subnivel)
        private void update_tree()
        {
            int id = nodo.Index;

            if (nodo.Text.Equals("Nuevo_nivel"))
            {
                string nombre = nombre_textBox.Text;
                nodo.Text = nombre_textBox.Text;

                TreeNode padre = nodo.Parent;
                padre.Nodes.Add("Nuevo_nivel");

                nodo.Nodes.Add("Nuevo_Subnivel");
            }

            if (nodo.Text.Equals("Nuevo_Subnivel"))
            {
                string nombre = nombre_textBox.Text;
                nodo.Text = nombre_textBox.Text;

                TreeNode padre = nodo.Parent;
                padre.Nodes.Add("Nuevo_Subnivel");

                nodo.Nodes.Add("Nuevo_Subnivel");
            }

            nombre_textBox.Clear();
            panel1.Visible = false;

        }
        //Si se desea eliminar pregunta si se esta seguro de hacerlo.
        //si responde que si se elimina el valor seleccionado.
        private void button3_Click(object sender, EventArgs e)
        {
           DialogResult result =  MessageBox.Show("Seguro que desea eliminar","Eliminar",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
           if (nodo.Text != "Sistema")
           {
               if (DialogResult.Yes == result)
               {
                   sistema.quitarNivel(sistema.get_posicion(nombre_textBox.Text));
                   //Eliminar el nodo del sistema
                   nodo.Remove();
                   nombre_textBox.Clear();
                   panel1.Visible = false;

               }
           }
        }
        //al presionar cancelar se sale del panel de edicion.
        private void button2_Click(object sender, EventArgs e)
        {
            nombre_textBox.Clear();
            panel1.Visible = false;
        }
   

        private void elementosToolStripButton_Click(object sender, EventArgs e)
        {
            elemento = new Form_Elementos(sistema, tablaElementos, tablaRelaciones);
            elemento.MdiParent = form;
            elemento.Show();

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
            for(int a=0; a< sistema.niveles.Count; a++){
                tablaElementos.Rows.Add("Nivel " + a + " :" + sistema.niveles[a].nombre, " ",
                           " ");
                for (int b = 0; b < sistema.niveles[a].matriz.Count; b++) {
                    for (int c = 0; c < sistema.niveles[a].matriz[b].Count; c++)
                        if (sistema.niveles[a].matriz[b][c] != null) tablaRelaciones.Rows.Add(sistema.niveles[a],
                                sistema.niveles[a].listaElementos[b], sistema.niveles[a].listaElementos[c],
                                sistema.niveles[a].matriz[b][c].funcion, sistema.niveles[a].matriz[b][c].Regla.iteracion,
                                sistema.niveles[a].matriz[b][c].Regla.operador + sistema.niveles[a].matriz[b][c].Regla.valor);
                }
            }

        }

        private void relacionesToolStripButton_Click(object sender, EventArgs e)
        {
            relaciones = new Form_Relaciones(sistema, tablaElementos, tablaRelaciones);
            relaciones.MdiParent = form;
            relaciones.Show();
        }

        private void set_combobox()
        {
            comboBox1.Items.Clear();

            foreach (Nivel x in sistema.niveles)
                {
                    if (x.nombre.Equals(nodo.Parent.Text))
                    {
                        foreach (Elemento l in x.listaElementos)
                        {
                            comboBox1.Items.Add(l.nombre);
                        }
                    }
                    
                }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          nombre_textBox.Text = comboBox1.SelectedItem.ToString();
          nombre_textBox.Enabled = false;
        }

    }
}
