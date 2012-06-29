using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class regla
{
    int contador = 0;
    double valor;
    string operador;
    int iteracion;
    Random random = new Random();

    public regla(double Valor, string Operador, int Iteracion)
    {
        valor = Valor;
        operador = Operador;
        iteracion = Iteracion;


    }

    public regla(int Iteracion)
    {
        valor = 0;
        operador = null;
        iteracion = Iteracion;
    }


    public regla(double Valor, string Operador)
    {
        valor = Valor;
        operador = Operador;
        iteracion = 1;
    }


    public bool seCumpleRegla(double argumento)
    {
        contador++;
        if (contador % iteracion != 0)
        return false;

        if (operador == null) return true;

        if (operador.Equals("="))
        {
            if (argumento == valor) return true;
        }
        else if (operador.Equals("<"))
        {
            if (argumento < valor) return true;
        }
        else if (operador.Equals(">"))
        {
            if (argumento > valor)
            {
                return true;
            }
        }
        else if (operador.Equals("<="))
        {
            if (argumento <= valor) return true;
        }
        else if (operador.Equals(">="))
        {
            if (argumento >= valor) return true;
        }
        return false;
    }

}