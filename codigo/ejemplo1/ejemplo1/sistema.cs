using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ejemplo1
{
    class Sistema
    {
        public int id;
        public Sistema padre;
        public string nombre;
        public int nivel;
        List<Sistema> subSistemas;

        public Sistema() {
            subSistemas = new List<Sistema>(); 
        }

        public Sistema(int id, Sistema padre, string nombre, int nivel) {
            this.id = id;
            this.padre = padre;
            this.nombre = nombre;
            this.nivel = nivel;
            subSistemas = new List<Sistema>();
        }
        /*
         * Operaciones de Sistema
         */
        public void addSistema(Sistema sis) {
            subSistemas.Add(sis);
        }

        public void delSistema(Sistema sis) {
            subSistemas.Remove(sis);
        }

        public Sistema buscarSistema(int id) {
            return null;
        }

        public Sistema padreDelSistema() {
            return this.padre;
        }

        public void writeHijos() {
            foreach(Sistema sis in subSistemas){
                Console.WriteLine(sis.nombre);
            
            }
        
        }
    }
}
