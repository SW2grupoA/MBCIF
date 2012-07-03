using System;
using System.Collections.Generic;


public class Sistema
{

    List <Nivel> niveles;
    
	public Sistema ()
	{
        niveles = new List<Nivel>();
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



}