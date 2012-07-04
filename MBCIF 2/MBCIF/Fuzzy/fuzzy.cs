using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class fuzzy
    {
        //   Función De Pertenencia
        /** 
         *  a min
         *  m medio
         *  b max
         */
        public string getGradoMadurez(double gradoBrix,String funcion)
        {
            if (funcion == "triangular")
                return gradoMadurezTriangular(gradoBrix);
            else if (funcion == "trapezoidal")
                return gradoMadurezTrapezoidal(gradoBrix);
            else
                return null;

        }
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

        /**
         *  Variable linguistica del máximo entre 3 valores   
         */
         string max(double uno, double dos, double tres) 
        {
            double maximo = uno; string varLinguistica="Inmadura";

             if (dos > maximo)
             {
                 maximo = dos;
                 varLinguistica = "Normal";
             }

             if (tres > maximo)
             { 
                maximo = tres;
                varLinguistica = "Madura";
             }

            return varLinguistica;
        }

        /**
         * variable linguistica Madurez
         *  
         * baja 8.5-10.5
         * media 9.5-11.5
         * alta 11-14.5
         */
         string gradoMadurezTriangular(double gradoMadurez)
        {
            double minBaja = 8.5,
                   maxBaja = 10.5,
                   minMedia = 9.5,
                   maxMedia = 11.5,
                   minAlta = 11,
                   maxAlta = 14.5;

            double nucleoBaja = (maxBaja + minBaja) / 2,
                   nucleoMedia = (maxMedia + minMedia) / 2,
                   nucleoAlta = (maxAlta + minAlta) / 2;


            
           return max(funcionTriangular(gradoMadurez, minBaja, nucleoBaja, maxBaja),  
                      funcionTriangular(gradoMadurez, minMedia, nucleoMedia, maxMedia), 
                      funcionTriangular(gradoMadurez, minAlta, nucleoAlta, maxAlta));
        }



         string gradoMadurezTriangular(double gradoMadurez,double minBaja,double maxBaja,
                                            double minMedia, double maxMedia, double minAlta, double maxAlta)
        {
            double nucleoBaja = (maxBaja + minBaja) / 2,
                   nucleoMedia = (maxMedia + minMedia) / 2,
                   nucleoAlta = (maxAlta + minAlta) / 2;

            return max(funcionTriangular(gradoMadurez, minBaja, nucleoBaja, maxBaja),
                       funcionTriangular(gradoMadurez, minMedia, nucleoMedia, maxMedia),
                       funcionTriangular(gradoMadurez, minAlta, nucleoAlta, maxAlta));
        }


        /**
         * variable linguistica Madurez con funcion trapezoidal
        */
         string gradoMadurezTrapezoidal(double gradoMadurez)
        {
            double minBaja = 8.5,
                  minNucleoBaja = 9,
                  maxNucleoBaja = 10,
                  maxBaja = 10.2,

                  minMedia = 9.5,
                  minNucleoMedia = 10.5,
                  maxNucleoMedia = 11.2,
                  maxMedia = 11.5,

                  minAlta = 11,
                  minNucleoAlta = 12,
                  maxNucleoAlta = 13.5,
                  maxAlta = 14.5;


            return max(funcionTrapezoidal(gradoMadurez, minBaja, minNucleoBaja, maxNucleoBaja, maxBaja),
                       funcionTrapezoidal(gradoMadurez, minMedia, minNucleoMedia, maxNucleoMedia, maxMedia),
                       funcionTrapezoidal(gradoMadurez, minAlta, minNucleoAlta, maxNucleoAlta, maxAlta));

        }

        /**
         * variable linguistica Madurez con funcion trapezoidal
        */
        string gradoMadurezTrapezoidal(double gradoMadurez, double minBaja, double minNucleoBaja, double maxNucleoBaja,
            double maxBaja, double minMedia, double minNucleoMedia, double maxNucleoMedia, double maxMedia,
            double minAlta, double minNucleoAlta, double maxNucleoAlta, double maxAlta)
        {

            return max(funcionTrapezoidal(gradoMadurez, minBaja, minNucleoBaja, maxNucleoBaja, maxBaja),
                       funcionTrapezoidal(gradoMadurez, minMedia, minNucleoMedia, maxNucleoMedia, maxMedia),
                       funcionTrapezoidal(gradoMadurez, minAlta, minNucleoAlta, maxNucleoAlta, maxAlta));

        }

        
    }