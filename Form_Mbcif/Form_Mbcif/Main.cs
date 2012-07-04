using System;

class MainClass
{

    public static void Main(string[] args)
    {
        /*uno=new Elemento("uno", 1);
        dos=new Elemento("dos", 2);
        Elemento tres = new Elemento("tres", 3);
        Elemento cuatro = new Elemento("cuatro", 4);	

        miNivel=new Nivel("Nivel Uno");
		
        miNivel.agregarElemento(uno);
        miNivel.agregarElemento(dos);

        
        miNivel.agregarRelacion(0,1,new relacion("4*x",new regla(1)));
        miNivel.agregarRelacion(1,0, new relacion("y-x", new regla(1)));

        miNivel.agregarElemento(tres);        

        miNivel.agregarRelacion(2, 0, new relacion("x/2", new regla(2)));        

        Nivel nivelDos = new Nivel("Nivel dos");

        nivelDos.agregarElemento(tres);
        nivelDos.agregarElemento(cuatro);
        nivelDos.agregarRelacion(1, 0, new relacion("x^2-2", new regla(2)));
        nivelDos.agregarRelacion(0, 1, new relacion("x+1", new regla(4)));
        nivelDos.agregarRelacion(0, 0, new relacion("3", new regla(50000, ">")));


        Sistema elSistema = new Sistema();

        elSistema.agregarNivel(miNivel);
        elSistema.agregarNivel(nivelDos);



        //*/

        //Console.WriteLine(new calculos().leerFuncion("(x^2/6000)+300", 1));
        //Console.ReadKey();

        Sistema unSistema = new Sistema();

        Nivel primerNivel = new Nivel("Primer nivel");
        primerNivel.agregarElemento(new Elemento("Colectivo", 0));
        primerNivel.agregarElemento(new Elemento("Microbus", 0));
        primerNivel.agregarElemento(new Elemento("Usuario", 0));
        primerNivel.agregarElemento(new Elemento("Combustible", 0));


        Nivel nivelColectivo = new Nivel("Colectivo");

        Elemento demandaColectivo = new Elemento("Demanda de clientes colectivo", 0);


        nivelColectivo.agregarElemento(primerNivel.listaElementos[0]);
        nivelColectivo.agregarElemento(new Elemento("Precio pasaje colectivo", 200));
        nivelColectivo.agregarElemento(new Elemento("Precio Bencina", 150));
        nivelColectivo.agregarElemento(demandaColectivo);
        nivelColectivo.agregarElemento(new Elemento("Ganancia", 2000));
        nivelColectivo.agregarElemento(new Elemento("Distancia recorrida", 1000));
        nivelColectivo.agregarElemento(new Elemento("Bencina ocupada", 10));

        //Relaciones
        //nivelColectivo.agregarRelacion(1, 3, new relacion("x*(6/13)", new regla(1)));
        nivelColectivo.agregarRelacion(1, 4, new relacion("x", new regla(1)));

        nivelColectivo.agregarRelacion(2, 1, new relacion("x*(6/7)", new regla(1)));
        nivelColectivo.agregarRelacion(2, 2, new relacion("y+5", new regla(10)));
        nivelColectivo.agregarRelacion(2, 3, new relacion("x*(1/10)", new regla(1)));
        nivelColectivo.agregarRelacion(2, 6, new relacion("x", new regla(1)));

        nivelColectivo.agregarRelacion(3, 4, new relacion("y*x", new regla(1)));
        nivelColectivo.agregarRelacion(3, 5, new relacion("x*10", new regla(1)));

        nivelColectivo.agregarRelacion(5, 6, new relacion("y*(x/12)", new regla(1)));
        nivelColectivo.agregarRelacion(6, 4, new relacion("y-x", new regla(1)));

        Nivel nivelMicrobus = new Nivel("Microbus");

        Elemento demandaMicrobus = new Elemento("Demanda de clientes microbus", 0);

        nivelMicrobus.agregarElemento(primerNivel.listaElementos[1]);
        nivelMicrobus.agregarElemento(new Elemento("Precio pasaje", 150));
        nivelMicrobus.agregarElemento(new Elemento("Precio petróleo", 140));
        nivelMicrobus.agregarElemento(demandaMicrobus);
        nivelMicrobus.agregarElemento(new Elemento("Ganancia", 0));
        nivelMicrobus.agregarElemento(new Elemento("Distancia recorrida", 1000));
        nivelMicrobus.agregarElemento(new Elemento("Petroleo ocupado", 200));

        //Relaciones:
        //nivelMicrobus.agregarRelacion(1, 3, new relacion("x", new regla(1)));
        nivelMicrobus.agregarRelacion(1, 4, new relacion("x", new regla(1)));

        nivelMicrobus.agregarRelacion(2, 1, new relacion("x*(4/7)", new regla(1)));
        nivelMicrobus.agregarRelacion(2, 2, new relacion("y+(48/10)", new regla(10)));
        nivelMicrobus.agregarRelacion(2, 3, new relacion("x*(1/10)", new regla(1)));
        nivelMicrobus.agregarRelacion(2, 6, new relacion("x", new regla(1)));

        nivelMicrobus.agregarRelacion(3, 4, new relacion("y*x", new regla(1)));
        nivelMicrobus.agregarRelacion(3, 5, new relacion("100", new regla(1)));

        nivelMicrobus.agregarRelacion(5, 6, new relacion("y*(x/12)", new regla(1)));
        nivelMicrobus.agregarRelacion(6, 4, new relacion("y-x", new regla(1)));




        Nivel nivelUsuario = new Nivel("Demanda usuarios");
        nivelUsuario.agregarElemento(primerNivel.listaElementos[2]);
        nivelUsuario.agregarElemento(demandaColectivo);
        nivelUsuario.agregarElemento(demandaMicrobus);


        //nivelUsuario.agregarRelacion(1, 2, new relacion("y-x/100", new regla(1)));
        


        unSistema.agregarNivel(primerNivel);
        unSistema.agregarNivel(nivelColectivo);
        unSistema.agregarNivel(nivelMicrobus);
        unSistema.agregarNivel(nivelUsuario);



        while (true)
        {
            Console.Clear();
            unSistema.iterar();
            unSistema.imprimirSistema();
            Console.WriteLine(unSistema.obtenerEstado() + "\n");
            System.Threading.Thread.Sleep(1000);
        }

        /*
        for(int j=0; j<elSistema.valores.Count;j++){
            for(int k=0; k< elSistema.valores[j].Count;k++){
                Console.Write(elSistema.valores[j][k]+ " ");
            }
            Console.WriteLine();
        }*/




    }

}