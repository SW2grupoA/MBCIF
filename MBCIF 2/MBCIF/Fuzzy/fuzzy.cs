using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class fuzzy
    {
        /// <summary>
        /// Evalua el valor de x en la funcion triangular
        /// </summary>
        /// <param name="x">el valor a comparar con la función</param>
        /// <param name="a">min de la funcion</param>
        /// <param name="m">punto medio de la funcion</param>
        /// <param name="b">maximo de la función</param>
        /// <returns>el valor de pertenencia a la función</returns>
        double funcionTriangular(double x, double a, double m, double b)
        {
            if (x <= a)
                return 0.0;

            if ((x > a) && (x <= m))
                return (x - a) / (m - a);

            if ((x > m) && (x < b))
                return (b - x) / (b - m);

            if (x >= b)
                return 0.0;

            return 0.0;
        }


        /// <summary>
        /// Función gaussiana
        /// </summary>
        /// <param name="x">valor</param>
        /// <param name="k">anchura de la campana: k mayor es más estrecha la campana</param>
        /// <param name="m">valor medio de la funcion</param>
        /// <returns>el valor de pertenencia a la funcion</returns>
        double funcionGausiana(double x, double k, double m)
        {
            return Math.Exp(-k * Math.Pow((x - m), 2));
        }

        /// <summary>
        /// Función trapezoidal
        /// </summary>
        /// <param name="x">valor a ingresar</param>
        /// <param name="a">min de la funcion</param>
        /// <param name="b">min del nucleo</param>
        /// <param name="c">max del nucleo</param>
        /// <param name="d">max de la funcion</param>
        /// <returns>el valor de pertenencia a la función</returns>
        double funcionTrapezoidal(double x, double a, double b, double c, double d)
        {
            if ((x <= a) || (x >= d))
                return 0.0;

            if ((x > a) && (x <= b))
                return (x - a) / (b - a);

            if ((x > b) && (x < c))
                return 1.0;

            if ((x > b) && (x < d))
                return (d - x) / (d - c);

            return 0.0;
        }
}