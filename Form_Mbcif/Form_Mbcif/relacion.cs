using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class relacion
{
    string funcion;
    public regla Regla;

    public relacion(string Funcion)
    {
        funcion = Funcion;
        Regla = null;
    }


    public relacion(string Funcion, regla unaRegla)
    {
        funcion = Funcion;
        Regla = unaRegla;
    }

    public bool seCumpleRegla(double argumento) {
        if (Regla == null) return true;
        else
        {
            return Regla.seCumpleRegla(argumento);
        }
    }

    public double aplicarRelacion(double argumentoX, double argumentoY)
    {
        return new calculos().leerFuncion(funcion, argumentoX,argumentoY);
    }    

}
