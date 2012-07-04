using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    [Serializable]
    class conjuntoDifuso
    {
        List<conjuntoTriang> conjuntoTriangular;
        List<conjuntoTrapez> conjuntoTrapezoidal;
        List<conjuntoGaussi> conjuntoGaussiana;
        double valorDifuso;
        string nombre;

        public conjuntoDifuso(string nombre)
        {
            conjuntoTriangular = new List<conjuntoTriang>();
            conjuntoTrapezoidal = new List<conjuntoTrapez>();
            conjuntoGaussiana = new List<conjuntoGaussi>();
            this.nombre = nombre;
        }

        public Boolean agregarTriag(string nombreConjunto, double maximo, double minimo)
        {
            if (!existeConjuntoT(nombreConjunto))
            {
                this.conjuntoTriangular.Add(new conjuntoTriang(nombreConjunto, maximo, minimo));
                return(true);
            }
            return (false);
        }

        public Boolean agregarTrape(string nombreConjunto, double maximo, double maximoNucleo, double minimo, double minimoNucleo)
        {
            if (!existeConjuntoTrap(nombreConjunto))
            {
                this.conjuntoTrapezoidal.Add(new conjuntoTrapez(nombreConjunto, maximo, maximoNucleo, minimo, minimoNucleo));
                return (true);
            }
            return (false);
        }

        public Boolean agregarGauss(string nombreConjunto, double anchoCampana, double medio)
        {
            if (!existeConjuntoG(nombreConjunto))
            {
                this.conjuntoGaussiana.Add(new conjuntoGaussi(nombreConjunto, anchoCampana, medio));
                return (true);
            }
            return (false);
        }

        public List<valoresVP> obtenerVP(double x)
        {
            List<valoresVP> valores = new List<valoresVP>(); 
            conjuntoTriang[] r = conjuntoTriangular.ToArray();
            for (int i = 0; i < r.Length; i++)
            {
                if (r[i].obtenerGradoPertenencia(x) > 0)
                {
                    valores.Add(new valoresVP(r[i].obtenerNombre(),r[i].obtenerGradoPertenencia(x)));
                }
            }
            conjuntoTrapez[] g = conjuntoTrapezoidal.ToArray();
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i].obtenerGradoPertenencia(x) > 0)
                {
                    valores.Add(new valoresVP(g[i].obtenerNombre(), g[i].obtenerGradoPertenencia(x)));
                }
            }
            conjuntoGaussi[] b = conjuntoGaussiana.ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].obtenerGradoPertenencia(x) > 0)
                {
                    valores.Add(new valoresVP(b[i].obtenerNombre(), b[i].obtenerGradoPertenencia(x)));
                }
            }
            this.valorDifuso = x;
            return(valores);
        }

        Boolean existeConjuntoT(string nombreConjunto)
        {
            conjuntoTriang[] r= conjuntoTriangular.ToArray();
            for (int i = 0; i < r.Length; i++)
            {
                if(r[i].obtenerNombre()==nombreConjunto)
                    return(true);
            }
            return (false);
        }

        Boolean existeConjuntoTrap(string nombreConjunto)
        {
            conjuntoTrapez[] r = conjuntoTrapezoidal.ToArray();
            for (int i = 0; i < r.Length; i++)
            {
                if (r[i].obtenerNombre() == nombreConjunto)
                    return (true);
            }
            return (false);
        }

        Boolean existeConjuntoG(string nombreConjunto)
        {
            conjuntoGaussi[] r = conjuntoGaussiana.ToArray();
            for (int i = 0; i < r.Length; i++)
            {
                if (r[i].obtenerNombre() == nombreConjunto)
                    return (true);
            }
            return (false);
        }

    }