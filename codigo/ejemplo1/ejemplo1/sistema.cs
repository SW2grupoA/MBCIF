using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ejemplo1
{
    class sistema
    {
        public string nombre;
        public int nivel;
        List<sistema> subsistemas;

        public sistema() {
            subsistemas = new List<sistema>();
        }

        public sistema(string nombre, int nivel) {
            this.nombre = nombre;
            this.nivel = nivel;
        }

        public void addSubsistema(sistema sis) {
            subsistemas.Add(sis);
        }

    }
}
