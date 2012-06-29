using System;

class MainClass
{
		static Elemento<double>uno;
		static Elemento<double>dos;
		static Nivel miNivel;
	
	public static void Main (string[] args)
	{
		uno=new Elemento<double>("uno", 1);
		dos=new Elemento<double>("dos", 2);	
		miNivel=new Nivel();
		
		miNivel.agregarElemento(uno);
		miNivel.agregarElemento(dos);

		miNivel.agregarRelacion(0,1,new relacionUnoADos());
		miNivel.agregarRelacion(1,0,new relacionDosAUno());
		
		Console.WriteLine(uno.valor + " - " + dos.valor);		
		
		for(int i=0;i<10;i++){		
			aplicarIteracion();
			Console.WriteLine(uno.valor + " - " + dos.valor);		
		}
				
		
			
		Console.ReadKey();
	}	
	
	static void aplicarIteracion(){
		for(int i=0;i<miNivel.listaElementos.Count;i++){
			for(int j=0;j<miNivel.listaElementos.Count;j++){
				if(miNivel.matriz[i][j]!=null){
					miNivel.listaElementos[j].valor=miNivel.matriz[i][j].aplicarRelacion(miNivel.listaElementos[i]);
				}
			}
		}		
	}
	
}



class relacionUnoADos:relacion{
	public override double aplicarRelacion(Elemento<double> argumento)
	{
		return argumento.valor*4;
	}	
}

class relacionDosAUno:relacion{
	public override double aplicarRelacion(Elemento<double> argumento)
	{
		return argumento.valor-1;
	}	
}