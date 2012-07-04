using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

    public partial class difuso : Form
    {
        conjuntoDifuso newConjunto;
        public String nombreConjuntoMadurez;
        public String nombreConjuntoDefectos;

        public difuso()
        {
            InitializeComponent();
            this.Visible = true;
            nombreConjuntoMadurez = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Datos\\almacenamientoCDM\\Madurez";
            nombreConjuntoDefectos = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Datos\\almacenamientoCDD\\Defectos";
            string[] conjuntos = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory.ToString() + "Datos\\almacenamientoCDM");
            for (int i = 0; i < conjuntos.Length; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2[0, i].Value = conjuntos[i];
            }
            conjuntos = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory.ToString() + "Datos\\almacenamientoCDD");
            for (int i = 0; i < conjuntos.Length; i++)
            {
                dataGridView5.Rows.Add();
                dataGridView5[0, i].Value = conjuntos[i];
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                newConjunto = new conjuntoDifuso(textBox1.Text);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean operacion = false;
            if (radioButton3.Checked)
            {
                crearTriangular crearTriangule = new crearTriangular();
                DialogResult result = crearTriangule.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    operacion = newConjunto.agregarTriag(crearTriangule.textBox1.Text, double.Parse(crearTriangule.textBox2.Text), double.Parse(crearTriangule.textBox3.Text));
                    if (operacion)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, (dataGridView1.Rows.Count-1)].Value = crearTriangule.textBox1.Text;
                        dataGridView1[1, (dataGridView1.Rows.Count-1)].Value = "Triangular";
                    }
                    else
                    {
                        MessageBox.Show("El nombre del sub - conjunto ya existe");
                    }
                    crearTriangule.Dispose();
                }
            }
            if (radioButton4.Checked)
            {
                crearTrapezoidal crearTrapezoide = new crearTrapezoidal();
                if (crearTrapezoide.ShowDialog(this) == DialogResult.OK)
                {

                    operacion = newConjunto.agregarTrape(crearTrapezoide.textBox1.Text, double.Parse(crearTrapezoide.textBox2.Text), double.Parse(crearTrapezoide.textBox3.Text), double.Parse(crearTrapezoide.textBox4.Text), double.Parse(crearTrapezoide.textBox5.Text));
                    if (operacion)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = crearTrapezoide.textBox1.Text;
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = "Trapezoidal";
                    }
                    else
                    {
                        MessageBox.Show("El nombre del sub - conjunto ya existe");
                    }
                    crearTrapezoide.Dispose();
                }
            }
            if (radioButton5.Checked)
            {
                crearGaussiana crearGaussiano = new crearGaussiana();
                if (crearGaussiano.ShowDialog(this) == DialogResult.OK)
                {

                    operacion = newConjunto.agregarGauss(crearGaussiano.textBox1.Text, double.Parse(crearGaussiano.textBox2.Text), double.Parse(crearGaussiano.textBox3.Text));
                    if (operacion)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = crearGaussiano.textBox1.Text;
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = "Gaussiana";
                    }
                    else
                    {
                        MessageBox.Show("El nombre del sub - conjunto ya existe");
                    }
                    crearGaussiano.Dispose();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter f = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                FileStream writer;
                if (radioButton1.Checked)
                {
                    writer = new FileStream(AppDomain.CurrentDomain.BaseDirectory.ToString() + "Datos\\almacenamientoCDM\\" + textBox1.Text, FileMode.Create);
                }
                else
                {
                    writer = new FileStream(AppDomain.CurrentDomain.BaseDirectory.ToString() + "Datos\\almacenamientoCDD\\" + textBox1.Text, FileMode.Create);
                }
                f.Serialize(writer, newConjunto);
                writer.Close();
                MessageBox.Show("Almacenamiento satisfactorio de:" + textBox1.Text);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; 0 < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Selected)
                {
                    nombreConjuntoMadurez = "" + dataGridView2[0, i].Value.ToString();
                    MessageBox.Show("Se ha seleccionado el conjunto: " + nombreConjuntoMadurez + " satisfactoriamente");
                    break;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; 0 < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Selected)
                {
                    nombreConjuntoDefectos = "" + dataGridView5[0, i].Value.ToString();
                    MessageBox.Show("Se ha seleccionado el conjunto: " + nombreConjuntoDefectos + " satisfactoriamente");
                    break;
                }
            }
        }
    }