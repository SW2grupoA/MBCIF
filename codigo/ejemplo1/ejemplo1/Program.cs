using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ejemplo1
{
    class Program
    {
        
        private static Sistema crearSistema() {
            Sistema colectivo = new Sistema(null, "colectivo", 0);

            Sistema cantidadDePasajeros, recorridoDelColectivo, precioDelPasaje, precioDeLaBencina, cantidadDeBencina, plataDelPasajero;

            cantidadDePasajeros = new Sistema(colectivo, "cantidad de pasajeros", 1);
            plataDelPasajero = new Sistema(colectivo, "plata del pasajero", 1);
            recorridoDelColectivo = new Sistema(colectivo, "recorrido del colectivo", 1);
            precioDelPasaje = new Sistema(colectivo, "precio del pasaje", 1);
            precioDeLaBencina = new Sistema(colectivo, "precio de la bencina", 1);
            cantidadDeBencina = new Sistema(colectivo, "cantidad de bencina", 1);

            colectivo.addSistema(cantidadDePasajeros);
            colectivo.addSistema(plataDelPasajero);
            colectivo.addSistema(recorridoDelColectivo);
            colectivo.addSistema(precioDelPasaje);
            colectivo.addSistema(precioDeLaBencina);
            colectivo.addSistema(cantidadDeBencina);

            return colectivo;
        }


        static void Main(string[] args)
        {
            Sistema colectivo = crearSistema();
            /**
             * #0 cantidadDePasajeros
             * #1  plataDelPasajero
             * #2  recorridoDelColectivo (km)
             * #3  precioDelPasaje 
             * #4  precioDeLaBencina
             * #5  cantidadDeBencina
             * x afecta a y
             * Ej: si aumenta la cantidadDePasajeros, aumenta en 0.3 el recorridoDelColectivo
            */
            double [,] relaciones  = {
                                     {1.0, 1.0, 1.1, 1.0, 1.0, 0.95}, 
                                     {1.0, 1.0 , 1.0, 1.0, 1.0, 1.0}, 
                                     {1.0, 0.95 , 1.0, 1.0, 1.0, 0.987},
                                     {0.99, 0.96 , 0.967, 1.0, 1.0, 1.0}, 
                                     {0.93, 0.92 , 1.0, 1.111, 1.0, 0.92}, 
                                     {1.1, 1.3 , 1.0, 1.0, 1.0, 1.0},
                                     };

            double[] V = { 100.0, 2000.0, 1500.0, 200.0, 800.0, 4000.0 };

            for (int k = 0; k < 8; k++)
            {
                Console.WriteLine("Iteración {0} :", k);
                for (int i = 0; i < V.Length; i++)
                {


                    V[i] = relaciones[i, 0] * V[i];
                    V[i] = relaciones[i, 1] * V[i];
                    V[i] = relaciones[i, 2] * V[i];
                    V[i] = relaciones[i, 3] * V[i];
                    V[i] = relaciones[i, 4] * V[i];
                    V[i] = relaciones[i, 5] * V[i];

                    Console.WriteLine("i: " + i + " valor: " + V[i]);

                }

            }
            

                //Print relaciones

                //Print sistema
                //colectivo.writeHijos();
            Console.ReadKey();
        }
    }
}
