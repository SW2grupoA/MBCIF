using System;
using System.Collections.Generic;


public class Sistema
{
    List <Nivel> niveles;
    string estado = "estable";
    public List<List<double>> valores;
    
	public Sistema ()
	{
        niveles = new List<Nivel>();
        valores = new List<List<double>>();
	}


    public void agregarNivel(Nivel nuevo) {
        niveles.Add(nuevo);
    }

    public void modificarNivel(int posicion, Nivel nivel) {
        niveles[posicion] = nivel;
    }

    public void quitarNivel(int posicion) {
        niveles.RemoveAt(posicion);    
    }

    public void iterar() {
        for (int i = 0; i < niveles.Count; i++) {
            aplicarIteracion(niveles[i]);            
        }
        registrarValores();
        actualizarEstado();
    }


    void registrarValores() { 
        valores.Add(new List<double>());

        for (int i = 0; i < niveles.Count; i++)
        {
            for (int j = 0; j < niveles[i].listaElementos.Count; j++)
            {
                valores[valores.Count - 1].Add(niveles[i].listaElementos[j].valor);
            }
        }

    }

    void actualizarEstado() {
        estado = "estable";
        int contadorDeCambios=0;

        if(valores.Count<2)return;

        for (int i = 0; i < valores[valores.Count - 1].Count; i++)
        {
            if (valores[valores.Count - 1][i] != valores[valores.Count - 2][i]) contadorDeCambios++;
        }



        if ((double)contadorDeCambios / (double)valores[valores.Count - 1].Count > 0.25) estado = "cambiante";
        if ((double)contadorDeCambios / (double)valores[valores.Count - 1].Count > 0.60) estado = "caotico";

        verSiEsOscilatorio();
        
    }


    void verSiEsOscilatorio() {
        int contador = 0;

        for (int i = 0; i < valores.Count; i++)
        {
            if (compararConElUltimoEstado(i)) contador++;
        }


        if (contador > 8) estado = "oscilatorio";
    }


    bool compararConElUltimoEstado(int k){
        int contadorDeCambios=0;

        for (int i = 0; i < valores[valores.Count - 1].Count; i++)
        {
            if (valores[valores.Count - 1][i] != valores[k][i]) contadorDeCambios++;
        }

        if ((double)contadorDeCambios / (double)valores[valores.Count - 1].Count < 0.10) return true;
        else return false;
    }

    void aplicarIteracion(Nivel unNivel)
    {        

        for (int i = 0; i < unNivel.listaElementos.Count; i++)
        {            
            for (int j = 0; j < unNivel.listaElementos.Count; j++)
            {
                
                if (unNivel.matriz[i][j] != null)
                {
                    if (unNivel.matriz[i][j].seCumpleRegla(unNivel.listaElementos[i].valor))
                        unNivel.listaElementos[j].valor = 
                            unNivel.matriz[i][j].aplicarRelacion(unNivel.listaElementos[i].valor, unNivel.listaElementos[j].valor);
                }
            }
        }
    }


    public string obtenerEstado()
    {
        return estado;
    }


    public void imprimirSistema() {
        for (int i = 0; i < niveles.Count; i++) {
            Console.WriteLine("Nivel: " + niveles[i].nombre + "\n");
            for (int j = 0; j < niveles[i].listaElementos.Count; j++)
            {
                Console.WriteLine(niveles[i].listaElementos[j].nombre + ":\t" + niveles[i].listaElementos[j].valor);
            }
            Console.WriteLine();
        }
    }


}