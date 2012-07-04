using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Elemento
{
    public string nombre;
    public double valor;


    public Elemento(string nombreElemento)
    {
        nombre = nombreElemento;
        valor = 0.0;
    }

    public Elemento(string nombreElemento, double valorInicio)
    {
        nombre = nombreElemento;
        valor = valorInicio;
    }
}
