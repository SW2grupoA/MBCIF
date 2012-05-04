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
            Sistema colectivo = new Sistema(0, null, "colectivo", 0);

            Sistema pasajeros, recorrido, precio, bencina, plata;

            pasajeros = new Sistema(1, colectivo, "pasajeros", 1);
            recorrido = new Sistema(2, colectivo, "recorrido", 1);
            precio = new Sistema(3, colectivo, "precio", 1);
            bencina = new Sistema(4, colectivo, "bencina", 1);
            plata = new Sistema(5, colectivo, "plata", 1);
            colectivo.addSistema(pasajeros);
            colectivo.addSistema(recorrido);
            colectivo.addSistema(precio);
            colectivo.addSistema(bencina);
            colectivo.addSistema(plata);

            colectivo.writeHijos();
            Console.ReadKey();
        }
    }
}
