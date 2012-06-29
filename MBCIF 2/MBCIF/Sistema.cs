using System;
using System.Collections.Generic;


public class Sistema
{
	public Sistema ()
	{
	}
}




class Elemento<T>{
	public string nombre;
	public T valor;
	Nivel subnivel;
	
	
	public Elemento(string nombreElemento){
		nombre=nombreElemento;
		valor=default(T);
		subnivel=null;
	}
	
	public Elemento(string nombreElemento, T valorInicio){
		nombre=nombreElemento;
		subnivel=null;		
		valor=valorInicio;
	}
	
	public Elemento(string nombreElemento, T valorInicio, Nivel subnivelElemento){
		nombre=nombreElemento;
		valor=valorInicio;
		subnivel=subnivelElemento;
	}
}


class Nivel{
	public List<Elemento<double>> listaElementos;
	public List<List<relacion>> matriz;
	int posicionElementoRepresentante;
	
	public Nivel(){
		listaElementos=new List<Elemento<double>>();
		matriz=new List<List<relacion>>();
	}
	
	public void agregarElemento(Elemento<double> elementoAgregado){
		listaElementos.Add(elementoAgregado);
		
		List<List<relacion>> temp=new List<List<relacion>>();
		for(int a=0;a<listaElementos.Count;a++){
			temp.Add(new List<relacion>());
			for(int b=0;b<listaElementos.Count;b++){
				temp[a].Add(null);
			}
		}
		
		
		//se copia la información que había en la matriz hasta ahora
		for(int i=0; i<matriz.Count;i++){			
			for(int j=0;j<matriz[i].Count;j++){
				temp[i][j]=matriz[i][j];
			}
		}				
		matriz=temp;
	}
	
	public void agregarRelacion(int x, int y,
			relacion relacionEntreElementos){
		matriz[x][y]=relacionEntreElementos;
	}
}


abstract class relacion{			
	abstract public double aplicarRelacion(Elemento<double> argumento);
}