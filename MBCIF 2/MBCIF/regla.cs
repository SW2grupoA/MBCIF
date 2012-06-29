using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Esta clase sirve para crear reglas en las cuales actúan las relaciones.
/// </summary>
public class regla
{
    int contador = 0;
    double valor;
    string operador;
    int iteracion;

    /// <summary>
    /// Constructor que permite crear una regla
    /// </summary>
    /// <param name="Valor">valor utilizado en conjunto con el operador. p.e: mayor que X valor.</param>
    /// <param name="Operador">Puede ser mayor, menor, mayor igual, etc. </param>
    /// <param name="Iteracion">Cada cuantas iteraciones es aplicada la regla</param>
    public regla(double Valor, string Operador, int Iteracion)
    {
        valor = Valor;
        operador = Operador;
        iteracion = Iteracion;
    }

    /// <summary>
    /// Constructor que permite crear una regla
    /// </summary>
    /// <param name="Iteracion">Cada cuantas iteraciones es aplicada la regla</param>
    public regla(int Iteracion)
    {
        valor = 0;
        operador = null;
        iteracion = Iteracion;
    }

    /// <summary>
    /// Constructor que permite crear una regla
    /// </summary>
    /// <param name="Valor">valor utilizado en conjunto con el operador. p.e: mayor que X valor.</param>
    /// <param name="Operador">Puede ser mayor, menor, mayor igual, etc. </param>
    public regla(double Valor, string Operador)
    {
        valor = Valor;
        operador = Operador;
        iteracion = 1;
    }

    /// <summary>
    /// Verifica si se cumple la regla del operador y/o la iteración. 
    /// Si es que se cumple permite que se aplique la relación.
    /// </summary>
    /// <param name="argumento">valor a comprar en la regla del operador</param>
    /// <returns></returns>
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