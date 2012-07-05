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
            tablaElementos.SendToBack();
            tablaRelaciones.SendToBack();

            Forms.Ventana_tablas ventanaTablas =
                new Forms.Ventana_tablas(this, sistema, this.tablaElementos, this.tablaRelaciones);
            ventanaTablas.MdiParent = this;
            ventanaTablas.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra ventana de ingreso de arbol.
            Forms.Forms ingreso_sistema = new Forms.Forms(this, sistema, this.tablaElementos, this.tablaRelaciones);
            ingreso_sistema.MdiParent = this;
            guardarToolStripMenuItem.Enabled = true;
            ingreso_sistema.Show();            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        public void cargarEjemploColectivo() {
            Elemento gananciaColectivo = new Elemento("Ganancia colectivo", 2000);
            Elemento gananciaMicro = new Elemento("Ganancia microbus", 0);
            Elemento precioPasajeColectivo = new Elemento("Precio pasaje colectivo", 200);
            Elemento precioPasajeMicro = new Elemento("Precio pasaje micro", 150);
            Elemento cantidadTotalUsuarios = new Elemento("Cantidad total de usuarios", 0);
            Elemento precioPetroleo = new Elemento("Precio petróleo", 140);
            Elemento precioBencina = new Elemento("Precio bencina", 0);
            Elemento gananciaDiariaColectivero = new Elemento("Ganancia diaria colectivero", 0);


            Nivel primerNivel = new Nivel("Primer nivel");
            primerNivel.agregarElemento(gananciaDiariaColectivero);
            primerNivel.agregarElemento(new Elemento("Ganancia diaria conductor microbús", 0));
            primerNivel.agregarElemento(gananciaColectivo);
            primerNivel.agregarElemento(gananciaMicro);
            primerNivel.agregarElemento(new Elemento("Número de vueltas al día colectivo", 20));
            primerNivel.agregarElemento(new Elemento("Número de vueltas al día microbús", 10));
            primerNivel.agregarElemento(precioPasajeColectivo);
            primerNivel.agregarElemento(precioPasajeMicro);
            primerNivel.agregarElemento(cantidadTotalUsuarios);


            primerNivel.agregarRelacion(2, 0, new relacion("x", new regla(1)));
            primerNivel.agregarRelacion(3, 1, new relacion("x", new regla(1)));
            primerNivel.agregarRelacion(4, 0, new relacion("y*x", new regla(1)));
            primerNivel.agregarRelacion(5, 1, new relacion("y*x", new regla(1)));


            Nivel nivelColectivo = new Nivel("Colectivo");

            Elemento demandaColectivo = new Elemento("Demanda de clientes colectivo", 40);


            nivelColectivo.agregarElemento(precioPasajeColectivo);
            nivelColectivo.agregarElemento(precioBencina);
            nivelColectivo.agregarElemento(demandaColectivo);
            nivelColectivo.agregarElemento(gananciaColectivo);
            nivelColectivo.agregarElemento(new Elemento("Distancia recorrida", 1000));
            nivelColectivo.agregarElemento(new Elemento("Bencina ocupada", 10));
            nivelColectivo.agregarElemento(new Elemento("Perdida por desgaste", 0));
            nivelColectivo.agregarElemento(new Elemento("Perdida por reparacion", 0));
            nivelColectivo.agregarElemento(new Elemento("Desgaste (Kilometraje acumulado)", 0));

            //Relaciones
            //nivelColectivo.agregarRelacion(1, 3, new relacion("x*(6/13)", new regla(1)));
            nivelColectivo.agregarRelacion(0, 3, new relacion("x", new regla(1)));
            nivelColectivo.agregarRelacion(0, 2, new relacion("logx*(x/35)", new regla(1)));

            nivelColectivo.agregarRelacion(1, 0, new relacion("x*(6/7)", new regla(1)));
            nivelColectivo.agregarRelacion(1, 5, new relacion("x", new regla(1)));

            nivelColectivo.agregarRelacion(2, 3, new relacion("y*x", new regla(1)));
            nivelColectivo.agregarRelacion(2, 4, new relacion("x*10", new regla(1)));

            nivelColectivo.agregarRelacion(4, 5, new relacion("y*(x/14)", new regla(1)));
            nivelColectivo.agregarRelacion(4, 8, new relacion("y+x", new regla(1)));

            nivelColectivo.agregarRelacion(5, 3, new relacion("y-x", new regla(1)));

            nivelColectivo.agregarRelacion(6, 3, new relacion("y-x", new regla(1)));

            nivelColectivo.agregarRelacion(7, 3, new relacion("y-x", new regla(1)));

            nivelColectivo.agregarRelacion(8, 6, new relacion("x/15", new regla(1)));
            nivelColectivo.agregarRelacion(8, 7, new relacion("x/25", new regla(350, ">")));
            nivelColectivo.agregarRelacion(8, 8, new relacion("0", new regla(500, ">=")));

            Nivel nivelMicrobus = new Nivel("Microbus");

            Elemento demandaMicrobus = new Elemento("Demanda de clientes microbus", 0);

            nivelMicrobus.agregarElemento(precioPasajeMicro);
            nivelMicrobus.agregarElemento(precioPetroleo);
            nivelMicrobus.agregarElemento(demandaMicrobus);
            nivelMicrobus.agregarElemento(gananciaMicro);
            nivelMicrobus.agregarElemento(new Elemento("Distancia recorrida", 40));
            nivelMicrobus.agregarElemento(new Elemento("Petroleo ocupado", 200));
            nivelMicrobus.agregarElemento(new Elemento("Perdida por desgaste", 0));
            nivelMicrobus.agregarElemento(new Elemento("Perdida por reparacion", 0));
            nivelMicrobus.agregarElemento(new Elemento("Desgaste (Kilometraje acumulado)", 0));

            //Relaciones:
            //nivelMicrobus.agregarRelacion(1, 3, new relacion("x", new regla(1)));
            nivelMicrobus.agregarRelacion(0, 3, new relacion("x", new regla(1)));
            nivelMicrobus.agregarRelacion(0, 2, new relacion("logx*(x/6)", new regla(1)));

            nivelMicrobus.agregarRelacion(1, 0, new relacion("logx*(x/5)", new regla(1)));
            nivelMicrobus.agregarRelacion(1, 5, new relacion("x", new regla(1)));

            nivelMicrobus.agregarRelacion(2, 3, new relacion("y*x", new regla(1)));

            nivelMicrobus.agregarRelacion(4, 5, new relacion("y*(x/6)", new regla(1)));
            nivelMicrobus.agregarRelacion(4, 8, new relacion("y+x", new regla(1)));

            nivelMicrobus.agregarRelacion(5, 3, new relacion("y-x", new regla(1)));

            nivelMicrobus.agregarRelacion(6, 3, new relacion("y-x", new regla(1)));

            nivelMicrobus.agregarRelacion(7, 3, new relacion("y-x", new regla(1)));

            nivelMicrobus.agregarRelacion(8, 6, new relacion("x/10", new regla(1)));
            nivelMicrobus.agregarRelacion(8, 7, new relacion("x/15", new regla(350, ">")));
            nivelMicrobus.agregarRelacion(8, 8, new relacion("0", new regla(500, ">=")));



            Nivel nivelUsuario = new Nivel("Demanda usuarios");
            nivelUsuario.agregarElemento(cantidadTotalUsuarios);
            nivelUsuario.agregarElemento(demandaColectivo);
            nivelUsuario.agregarElemento(demandaMicrobus);

            nivelUsuario.agregarRelacion(1, 0, new relacion("x", new regla(1)));
            nivelUsuario.agregarRelacion(2, 0, new relacion("y+x", new regla(1)));


            Nivel petroleo = new Nivel("Indicadores economicos");

            Elemento inflacion = new Elemento("Inflación económica", 1);
            Elemento deuda = new Elemento("Deuda familiar acumulada del mes", 7000);
            Elemento gastoDiario = new Elemento("Gasto familiar diario", 6000);

            petroleo.agregarElemento(precioPetroleo);
            petroleo.agregarElemento(precioBencina);
            petroleo.agregarElemento(inflacion);
            petroleo.agregarElemento(gastoDiario);

            petroleo.agregarRelacion(0, 1, new relacion("x*(15/10)", new regla(1)));
            petroleo.agregarRelacion(0, 2, new relacion("y-2", new regla(3)));

            petroleo.agregarRelacion(1, 2, new relacion("y+4", new regla(5)));

            petroleo.agregarRelacion(2, 0, new relacion("((x/100)+1)*y", new regla(30)));
            petroleo.agregarRelacion(2, 2, new relacion("y*(-1)", new regla(0, "<", 5)));
            petroleo.agregarRelacion(2, 3, new relacion("((x/100)+1)*y", new regla(30)));


            Elemento ahorro = new Elemento("Ahorro familiar", 0);
            Nivel familiaColectivero = new Nivel("Familia colectivero");

            familiaColectivero.agregarElemento(gananciaDiariaColectivero);
            familiaColectivero.agregarElemento(gastoDiario);
            familiaColectivero.agregarElemento(ahorro);
            familiaColectivero.agregarElemento(deuda);


            familiaColectivero.agregarRelacion(0, 2, new relacion("y+x", new regla(1)));

            familiaColectivero.agregarRelacion(1, 3, new relacion("y+x", new regla(1)));

            //Si el ahorro es mayor a 120000 pesos, la familia comienza a gastar más dinero
            familiaColectivero.agregarRelacion(2, 3, new relacion("(x/20)+y", new regla(120000, ">")));

            familiaColectivero.agregarRelacion(3, 2, new relacion("y-x", new regla(30)));
            familiaColectivero.agregarRelacion(3, 3, new relacion("0", new regla(30)));



            sistema.agregarNivel(primerNivel);
            sistema.agregarNivel(nivelColectivo);
            sistema.agregarNivel(nivelMicrobus);
            sistema.agregarNivel(nivelUsuario);
            sistema.agregarNivel(petroleo);
            sistema.agregarNivel(familiaColectivero);        
        }

        private void cargarEjemploToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sistema.niveles.Clear();
            cargarEjemploColectivo();
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

        private void aplicarIteraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sistema.iterar();
            llenarTablas();
        }

        
       
    }
}
