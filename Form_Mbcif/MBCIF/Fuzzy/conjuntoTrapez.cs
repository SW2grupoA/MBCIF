using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    [Serializable]
    class conjuntoTrapez
    {
        string nombreConjunto;
        double maximo;
        double minimo;
        double maximoNucleo;
        double minimoNucleo;

        public conjuntoTrapez(string nombreConjunto,double maximo,double minimo, double maximoNucleo, double minimoNucleo)
        {
            this.nombreConjunto = nombreConjunto;
            this.maximo = maximo;
            this.minimo = minimo;
            this.maximoNucleo = maximoNucleo;
            this.minimoNucleo = minimoNucleo;
        }

        public double obtenerGradoPertenencia(double x)
        {
            if ((x <= minimo) || (x >= maximo))
                return 0.0;

            if ((x > minimo) && (x <= minimoNucleo))
                return (x - minimo) / (minimoNucleo - minimo);

            if ((x > minimoNucleo) && (x < maximoNucleo))
                return 1.0;

            if ((x > minimoNucleo) && (x < maximo))
                return (maximo - x) / (maximo - maximoNucleo);

            return 0.0;
        }

        public string obtenerNombre()
        {
            return (nombreConjunto);
        }

    }