using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    [Serializable]
    class conjuntoTriang
    {
        string nombreConjunto;
        double maximo;
        double minimo;
        double medio;

        public conjuntoTriang(string nombreConjunto, double maximo, double minimo)
        {
            this.nombreConjunto= nombreConjunto;
            this.maximo = maximo;
            this.minimo = minimo;
            this.medio = (maximo + minimo) / 2;
        }

        public double obtenerGradoPertenencia(double x)
        {
            if (x <= minimo)
                return 0.0;

            if ((x > minimo) && (x <= medio))
                return (x - minimo) / (medio - minimo);

            if ((x > medio) && (x < maximo))
                return (maximo - x) / (maximo - medio);

            if (x >= maximo)
                return 0.0;

            return 0.0;
        }

        public string obtenerNombre()
        {
            return (nombreConjunto);
        }
    }