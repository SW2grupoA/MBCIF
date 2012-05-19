using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ejemplo1
{
    class Program
    {
        
        private static Sistema crearSistema() {
            Sistema colectivo = new Sistema(0, null, "colectivo", 0);

            Sistema cantidadDePasajeros, recorridoDelColectivo, precioDelPasaje, precioDeLaBencina, cantidadDeBencina, plataDelPasajero;

            cantidadDePasajeros = new Sistema(1, colectivo, "cantidad de pasajeros", 1);
            plataDelPasajero = new Sistema(2, colectivo, "plata del pasajero", 1);
            recorridoDelColectivo = new Sistema(3, colectivo, "recorrido del colectivo", 1);
            precioDelPasaje = new Sistema(4, colectivo, "precio del pasaje", 1);
            precioDeLaBencina = new Sistema(5, colectivo, "precio de la bencina", 1);
            cantidadDeBencina = new Sistema(6, colectivo, "cantidad de bencina", 1);

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
             * #1 cantidadDePasajeros
             * #2  plataDelPasajero 
             * #3  recorridoDelColectivo
             * #4  precioDelPasaje
             * #5  precioDeLaBencina
             * #6  cantidadDeBencina
             * x afecta a y
             * Ej: si aumenta la cantidadDePasajeros, aumenta en 0.3 el recorridoDelColectivo
            */
            double [,] relaciones  = {
                                     {0.0, 0.0, 0.3, 0.0, 0.0, -0.6}, 
                                     {0.0, 0.0 , 0.0, 0.0, 0.0, 0.0}, 
                                     {0.0, -0.4 , 0.0, 0.0, 0.0, -0.4},
                                     {-0.2, -0.2 , -0.3, 0.0, 0.0, 0.0}, 
                                     {-0.6, -0.3 , 0.0, 0.3, 0.0, -0.1}, 
                                     {0.6, 0.3 , 0.0, 0.0, 0.0, 0.0},
                                     };

            //Print relaciones

            //Print sistema
            colectivo.writeHijos();
            Console.ReadKey();
        }
    }
}
