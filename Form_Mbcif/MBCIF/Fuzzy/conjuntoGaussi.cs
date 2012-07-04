using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    [Serializable]
    class conjuntoGaussi
    {
        string nombreConjunto;
        double anchoCampana;
        double medio;

        public conjuntoGaussi(string nombreConjunto, double anchoCampana, double medio)
        {
            this.nombreConjunto = nombreConjunto;
            this.anchoCampana = anchoCampana;
            this.medio = medio;
        }

        public double obtenerGradoPertenencia(double x)
        {
            return Math.Exp(-anchoCampana * Math.Pow((x - medio), 2));
        }

        public string obtenerNombre()
        {
            return(nombreConjunto);
        }
    }