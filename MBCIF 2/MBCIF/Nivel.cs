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

    public Nivel()
    {
        listaElementos = new List<Elemento>();
        matriz = new List<List<relacion>>();
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

    public void agregarRelacion(int x, int y,
            relacion relacionEntreElementos)
    {
        matriz[x][y] = relacionEntreElementos;
    }
}