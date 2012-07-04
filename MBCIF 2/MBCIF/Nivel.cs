using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Representa el nivel de un sistema
/// </summary>
public class Nivel
{
    public List<Elemento> listaElementos;
    public List<List<relacion>> matriz;
    public string nombre;

    public Nivel(string nombre)
    {
        listaElementos = new List<Elemento>();
        matriz = new List<List<relacion>>();
        this.nombre = nombre;
    }

    /// <summary>
    /// Agrega un elemento a la lista del nivel
    /// </summary>
    /// <param name="elementoAgregado">elemento a agregar</param>
    public void agregarElemento(Elemento elementoAgregado)
    {
        listaElementos.Add(elementoAgregado);

        List<List<relacion>> temp = new List<List<relacion>>();
        for (int a = 0; a < listaElementos.Count; a++)
        {
            temp.Add(new List<relacion>());
            for (int b = 0; b < listaElementos.Count; b++)
            {
                temp[a].Add(null);
            }
        }

        //se copia la información que había en la matriz hasta ahora
        for (int i = 0; i < matriz.Count; i++)
        {
            for (int j = 0; j < matriz[i].Count; j++)
            {
                temp[i][j] = matriz[i][j];
            }
        }
        matriz = temp;
    }

    public void modificarElemento(int posicion, Elemento elemento) {
        listaElementos[posicion] = elemento;
    }


    public void eliminarElemento(int posicion) {
        listaElementos.RemoveAt(posicion);


        //se debe crear una nueva matriz de relaciones, pero de menor tamaño debido a que se eliminó un elemento de ella.
        List<List<relacion>> temp = new List<List<relacion>>();
        for (int a = 0; a < listaElementos.Count; a++)
        {
            temp.Add(new List<relacion>());
            for (int b = 0; b < listaElementos.Count; b++)
            {
                temp[a].Add(null);
            }
        }

        //se copia la información que había en la matriz hasta ahora, quitando las relaciones del elemento eliminado
        for (int i = 0; i < matriz.Count; i++)
        {
            for (int j = 0; j < matriz[i].Count; j++)
            {
                if(i<posicion && j<posicion)temp[i][j] = matriz[i][j];
                if (i < posicion && j > posicion) temp[i][j-1] = matriz[i][j];
                if (i > posicion && j < posicion) temp[i-1][j] = matriz[i][j];
                if (i > posicion && j > posicion) temp[i-1][j-1] = matriz[i][j];
            }
        }
        //se copia la nueva matriz a la matriz de este nivel
        matriz = temp;
    }

    public void agregarRelacion(int x, int y,
            relacion relacionEntreElementos)
    {
        matriz[x][y] = relacionEntreElementos;
    }

    public void modificarRelacion(int x, int y,
            relacion relacionEntreElementos) {        
        matriz[x][y] = relacionEntreElementos;    
    }

    public void eliminarRelacion(int x, int y)
    {
        matriz[x][y] = null;
    }

    public int get_indice(string nom)
    {
        int i = 0;
        foreach(Elemento l in listaElementos){
            if (l.nombre.Equals(nom))
            {
                return i;
            }
            i++;
        }
        return -1;
    }
}