using System;

class MainClass
{
		static Elemento uno;
		static Elemento dos;
		static Nivel miNivel;
	
	public static void Main (string[] args)
	{
		uno=new Elemento("uno", 1);
		dos=new Elemento("dos", 2);
        Elemento tres = new Elemento("tres", 3);
        Elemento cuatro = new Elemento("cuatro", 4);	

		miNivel=new Nivel();
		
		miNivel.agregarElemento(uno);
		miNivel.agregarElemento(dos);

        
		miNivel.agregarRelacion(0,1,new relacion("4*x",new regla(1)));
        miNivel.agregarRelacion(1,0, new relacion("y-x", new regla(1)));

        miNivel.agregarElemento(tres);        

        miNivel.agregarRelacion(2, 0, new relacion("x/2", new regla(2)));        

        Nivel nivelDos = new Nivel();

        nivelDos.agregarElemento(tres);
        nivelDos.agregarElemento(cuatro);
        nivelDos.agregarRelacion(1, 0, new relacion("x^2-2", new regla(2)));
        nivelDos.agregarRelacion(0, 1, new relacion("x+1", new regla(4)));
        nivelDos.agregarRelacion(0, 0, new relacion("3", new regla(50000, ">")));


        Sistema elSistema = new Sistema();

        elSistema.agregarNivel(miNivel);
        elSistema.agregarNivel(nivelDos);


                
		Console.WriteLine(uno.valor + " - " + dos.valor + " - " + tres.valor + " - " + cuatro.valor);		
		
		for(int i=0;i<20;i++){
            elSistema.iterar();
            Console.WriteLine(uno.valor + " - " + dos.valor + " - " + tres.valor + " - " + cuatro.valor);
		}       
        
			
		Console.ReadKey();
	}	
	
}