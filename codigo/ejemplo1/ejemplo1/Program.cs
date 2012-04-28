using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ejemplo1
{
    class Program
    {
        static void Main(string[] args)
        {
            sistema colectivo = new sistema();
            colectivo.nombre = "colectivo";
            colectivo.nivel = 0;

            sistema pasajeros, recorrido, precio, bencina, plata;

            pasajeros = new sistema("pasajeros", 1);
            recorrido = new sistema("recorrido", 1);
            precio = new sistema("precio", 1);
            bencina = new sistema("bencina", 1);
            plata = new sistema("plata", 1);


        }
    }
}
