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
    public partial class Ventana_tablas : Form
    {
        Form form;
        Sistema sistema;
        DataGridView tablaRelaciones, tablaElementos;

        public Ventana_tablas(Form form, Sistema sistema, DataGridView tablaElementos, DataGridView tablaRelaciones)
        {
            this.tablaElementos = tablaElementos;
            this.tablaRelaciones = tablaRelaciones;
            tablas();
            InitializeComponent();            
            this.form = form;
            this.sistema = sistema;

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            string numeroIteraciones = textBoxCantidadIteraciones.Text;
            int iteraciones = Int32.Parse(numeroIteraciones);

            for (int i = 0; i < iteraciones; i++ )
            {
                sistema.iterar();
                llenarTablas();
                estadoSistema.Text = sistema.obtenerEstado();
                System.Threading.Thread.Sleep(1);
            }
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
                        if (sistema.niveles[a].matriz[b][c] != null )
                            if(sistema.niveles[a].matriz[b][c].Regla.operador!=null)
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

        private void Ventana_tablas_Load(object sender, EventArgs e)
        {

        }
        
    }
}
