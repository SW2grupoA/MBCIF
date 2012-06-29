using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Esta clase es la misma que usamos en el anterior trabajo, pero leerfuncion usa un valor de Y y de t
//En el trabajo anterior usaba solo un valor de X
class calculos{

    /*Funcion para obtener el resultado de una funcion en algun valor de x.
     Funcionamiento: Funciona obteniendo una operacion despues de otra, pero
     desde la ultima a la primera a menos que esta tenga parentesis.
     Es decir. si se le ingresa 4*X+2 con X=2 nos devolvera 16 (X+2=4 primero y luego 4*4=16).
     */
    public Double leerFuncion(String funcion, double valorX, double valorY, double valorV)
    {
        double resultado = 0;
        char[] caracter = funcion.ToCharArray();
        String cadena = "";
        int i = 0;
        //Se lee la primera parte de la funcion entregada:

        /*Si el primer caracter es un parentesis '(' se debe obtener la funcion hasta
         el cierre de parentesis, para resolver esa parte y sumarla a resultado*/
        if (caracter[0] == '(')
        {
            int contador = 0;
            //Se obtienen todos los caracteres siguientes hasta el cierre de parentes
            for (i = 1; i < caracter.Length; i++)
            {
                if (caracter[i] == '(') contador++;
                if (caracter[i] == ')')
                {
                    if (contador == 0) break;
                    contador--;
                }
                cadena += caracter[i];
            }
            //Si se leyeron todos los caracteres y no hubo un cierre de parentesis, se retorna error
            if (i == caracter.Length) return 0;
            else
            {
                resultado += leerFuncion(cadena, valorX, valorY, valorV);
                i++;
            }
        }
        //Si el primer caracter no es un parentesis
        else
        {
            if (caracter[0] == '+' || caracter[0] == '-')
            {
                resultado = 0;
            }
            //Si es X se suma el valor de valorX
            else if (caracter[0] == 'y' || caracter[0] == 'y')
            {
                //Se añade el valor de U al resultado
                resultado += valorY;
                i++;
                //Si el siguiente caracter es el signo '^' se ve el siguiente numero
                if (i < caracter.Length && caracter[i] == '^')
                {
                    i++;
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                    resultado = potencia(resultado, double.Parse(cadena));
                }
            }
            else if (caracter[0] == 'x' || caracter[0] == 'x')
            {
                //Se añade el valor de T al resultado
                resultado += valorX;
                i++;
                //Si el siguiente caracter es el signo '^' se ve el siguiente numero
                if (i < caracter.Length && caracter[i] == '^')
                {
                    i++;
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                    resultado = potencia(resultado, double.Parse(cadena));
                }
            }
            else if (caracter[0] == 'V' || caracter[0] == 'v')
            {
                //Se añade el valor de V al resultado
                resultado += valorV;
                i++;
                //Si el siguiente caracter es el signo '^' se ve el siguiente numero
                if (i < caracter.Length && caracter[i] == '^')
                {
                    i++;
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                    resultado = potencia(resultado, double.Parse(cadena));
                }
            }
            //Si el primer caracter es una l(para logaritmos):
            else if (caracter[0] == 'l')
            {
                //El segundo caracter debe ser una n (para ln: log natural) o una o (para log)
                i++;
                if (caracter[i] == 'n')
                {
                    i++;
                    //Si a continuacion no hay un numero o X, se retorna 0.0
                    if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x' && caracter[i] != 'x') return 0;

                    //Si el siguiente caracter es Y, se asigna su valor a cadena
                    if (caracter[i] == 'y' || caracter[0] == 'y')
                    {
                        cadena = valorY.ToString();
                        i++;
                    }
                    else if (caracter[i] == 'x' || caracter[i] == 'x')
                    {
                        cadena = valorX.ToString();
                        i++;
                    }
                    else if (caracter[i] == 'V' || caracter[i] == 'v')
                    {
                        cadena = valorV.ToString();
                        i++;
                    }
                    else
                    {
                        //En caso contrario, se calcula el siguiente numero
                        while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                        {
                            cadena += caracter[i];
                            i++;
                        }
                    }
                    //Y se calcula el resultado
                    resultado = Math.Log(double.Parse(cadena));
                }
                else if (caracter[i] == 'o' && caracter[i + 1] == 'g')
                {
                    i += 2;
                    //Si a continuacion no hay un numero se retorna 0.0
                    if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x') return 0.0;

                    //Si el siguiente caracter es Y, se asigna su valor a cadena
                    if (caracter[i] == 'y' || caracter[0] == 'y')
                    {
                        cadena = valorY.ToString();
                        i++;
                    }
                    //Si el siguiente caracter es T, se asigna su valor a cadena
                    else if (caracter[i] == 'x' || caracter[i] == 'x')
                    {
                        cadena = valorX.ToString();
                        i++;
                    }
                    else if (caracter[i] == 'V' || caracter[i] == 'v')
                    {
                        cadena = valorV.ToString();
                        i++;
                    }
                    else
                    {
                        //En caso contrario, se calcula el siguiente numero
                        while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                        {
                            cadena += caracter[i];
                            i++;
                        }
                    }
                    //Y se calcula el resultado:
                    resultado = Math.Log10(double.Parse(cadena));
                }
                else return 0.0;
            }
            //Si lo primero en la cadena es sen(funcion seno):
            else if (caracter[0] == 's' && caracter[1] == 'e' && caracter[2] == 'n')
            {
                i += 3;
                //Si a continuacion no hay un numero o la X se retorna 0.0
                if (!(caracter[i] >= '0' && caracter[i] <= '9') && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.'))) return 0.0;

                //Si el siguiente caracter es X, se asigna su valor a cadena
                if (caracter[i] == 'y' || caracter[0] == 'y')
                {
                    cadena = valorY.ToString();
                    i++;
                }
                //Si el siguiente caracter es T, se asigna su valor a cadena
                else if (caracter[i] == 'x' || caracter[i] == 'x')
                {
                    cadena = valorX.ToString();
                    i++;
                }
                else if (caracter[i] == 'V' || caracter[i] == 'v')
                {
                    cadena = valorV.ToString();
                    i++;
                }
                else
                {
                    //En caso contrario, se calcula el siguiente numero
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                }
                //Y se calcula el resultado:
                resultado = Math.Sin(double.Parse(cadena));

            }
            //Si lo primero en la cadena es cos(funcion seno):
            else if (caracter[0] == 'c' && caracter[1] == 'o' && caracter[2] == 's')
            {
                i += 3;
                //Si a continuacion no hay un numero o la X se retorna 0.0
                if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x') return 0.0;

                //Si el siguiente caracter es X, se asigna su valor a cadena
                if (caracter[i] == 'y' || caracter[0] == 'y')
                {
                    cadena = valorY.ToString();
                    i++;
                }
                //Si el siguiente caracter es T, se asigna su valor a cadena
                else if (caracter[i] == 'x' || caracter[i] == 'x')
                {
                    cadena = valorX.ToString();
                    i++;
                }
                else if (caracter[i] == 'V' || caracter[i] == 'v')
                {
                    cadena = valorV.ToString();
                    i++;
                }
                else
                {
                    //En caso contrario, se calcula el siguiente numero
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                }
                //Y se calcula el resultado:
                resultado = Math.Cos(double.Parse(cadena));

            }

            //En caso de que el primer elemento entregado sea un numero, se agrega este valor
            else if (caracter[0] >= '0' && caracter[0] <= '9')
            {
                while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                {
                    cadena += caracter[i];
                    i++;
                }
                resultado += double.Parse(cadena);
            }
            else return 0.0;
        }

        //Siluego de calcular el primer elemento llegamos al final de la funcion, se retorna el valor obtenido
        if (i >= caracter.Length)
        {
            return resultado;
        }

        //Si no, se verifica la siguiente operacion matematica (+ - * /)
        if (caracter[i] != '+' && caracter[i] != '-' && caracter[i] != '*' && caracter[i] != '/') return 0.0;
        char operacion = caracter[i];
        i++;

        //Se aplica el metodo al siguiente elemento:
        String siguiente = "";
        for (int j = i; j < caracter.Length; j++) siguiente += caracter[j];
        Double siguienteElemento = leerFuncion(siguiente, valorX, valorY, valorV);

        if (siguienteElemento == 0.0) return 0;
        if (operacion == '+') resultado = resultado + (double)siguienteElemento;
        else if (operacion == '-') resultado = resultado - siguienteElemento;
        else if (operacion == '*') resultado = resultado * siguienteElemento;
        else
        {
            //Si hay una division por cero, se retorna 0.0
            if (siguienteElemento == 0) return 0;
            resultado = resultado / siguienteElemento;
        }
        return resultado;
    }

    public Double leerFuncion(String funcion, double valorX, double valorY)
    {
        double resultado = 0;
        char[] caracter = funcion.ToCharArray();
        String cadena = "";
        int i = 0;
        //Se lee la primera parte de la funcion entregada:

        /*Si el primer caracter es un parentesis '(' se debe obtener la funcion hasta
         el cierre de parentesis, para resolver esa parte y sumarla a resultado*/
        if (caracter[0] == '(')
        {
            int contador = 0;
            //Se obtienen todos los caracteres siguientes hasta el cierre de parentes
            for (i = 1; i < caracter.Length; i++)
            {
                if (caracter[i] == '(') contador++;
                if (caracter[i] == ')')
                {
                    if (contador == 0) break;
                    contador--;
                }
                cadena += caracter[i];
            }
            //Si se leyeron todos los caracteres y no hubo un cierre de parentesis, se retorna error
            if (i == caracter.Length) return 0;
            else
            {
                resultado += leerFuncion(cadena, valorX, valorY);
                i++;
            }
        }
        //Si el primer caracter no es un parentesis
        else
        {
            if (caracter[0] == '+' || caracter[0] == '-')
            {
                resultado = 0;
            }
            //Si es X se suma el valor de valorX
            else if (caracter[0] == 'y' || caracter[0] == 'y')
            {
                //Se añade el valor de U al resultado
                resultado += valorY;
                i++;
                //Si el siguiente caracter es el signo '^' se ve el siguiente numero
                if (i < caracter.Length && caracter[i] == '^')
                {
                    i++;
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                    resultado = potencia(resultado, double.Parse(cadena));
                }
            }
            else if (caracter[0] == 'x' || caracter[0] == 'x')
            {
                //Se añade el valor de T al resultado
                resultado += valorX;
                i++;
                //Si el siguiente caracter es el signo '^' se ve el siguiente numero
                if (i < caracter.Length && caracter[i] == '^')
                {
                    i++;
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                    resultado = potencia(resultado, double.Parse(cadena));
                }
            }
            //Si el primer caracter es una l(para logaritmos):
            else if (caracter[0] == 'l')
            {
                //El segundo caracter debe ser una n (para ln: log natural) o una o (para log)
                i++;
                if (caracter[i] == 'n')
                {
                    i++;
                    //Si a continuacion no hay un numero o X, se retorna 0.0
                    if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x' && caracter[i] != 'x') return 0;

                    //Si el siguiente caracter es Y, se asigna su valor a cadena
                    if (caracter[i] == 'y' || caracter[0] == 'y')
                    {
                        cadena = valorY.ToString();
                        i++;
                    }
                    else if (caracter[i] == 'x' || caracter[i] == 'x')
                    {
                        cadena = valorX.ToString();
                        i++;
                    }
                    else
                    {
                        //En caso contrario, se calcula el siguiente numero
                        while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                        {
                            cadena += caracter[i];
                            i++;
                        }
                    }
                    //Y se calcula el resultado
                    resultado = Math.Log(double.Parse(cadena));
                }
                else if (caracter[i] == 'o' && caracter[i + 1] == 'g')
                {
                    i += 2;
                    //Si a continuacion no hay un numero se retorna 0.0
                    if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x') return 0.0;

                    //Si el siguiente caracter es Y, se asigna su valor a cadena
                    if (caracter[i] == 'y' || caracter[0] == 'y')
                    {
                        cadena = valorY.ToString();
                        i++;
                    }
                    //Si el siguiente caracter es T, se asigna su valor a cadena
                    else if (caracter[i] == 'x' || caracter[i] == 'x')
                    {
                        cadena = valorX.ToString();
                        i++;
                    }
                    else
                    {
                        //En caso contrario, se calcula el siguiente numero
                        while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                        {
                            cadena += caracter[i];
                            i++;
                        }
                    }
                    //Y se calcula el resultado:
                    resultado = Math.Log10(double.Parse(cadena));
                }
                else return 0.0;
            }
            //Si lo primero en la cadena es sen(funcion seno):
            else if (caracter[0] == 's' && caracter[1] == 'e' && caracter[2] == 'n')
            {
                i += 3;
                //Si a continuacion no hay un numero o la X se retorna 0.0
                if (!(caracter[i] >= '0' && caracter[i] <= '9') && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.'))) return 0.0;

                //Si el siguiente caracter es X, se asigna su valor a cadena
                if (caracter[i] == 'y' || caracter[0] == 'y')
                {
                    cadena = valorY.ToString();
                    i++;
                }
                //Si el siguiente caracter es T, se asigna su valor a cadena
                else if (caracter[i] == 'x' || caracter[i] == 'x')
                {
                    cadena = valorX.ToString();
                    i++;
                }
                else
                {
                    //En caso contrario, se calcula el siguiente numero
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                }
                //Y se calcula el resultado:
                resultado = Math.Sin(double.Parse(cadena));

            }
            //Si lo primero en la cadena es cos(funcion seno):
            else if (caracter[0] == 'c' && caracter[1] == 'o' && caracter[2] == 's')
            {
                i += 3;
                //Si a continuacion no hay un numero o la X se retorna 0.0
                if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x') return 0.0;

                //Si el siguiente caracter es X, se asigna su valor a cadena
                if (caracter[i] == 'y' || caracter[0] == 'y')
                {
                    cadena = valorY.ToString();
                    i++;
                }
                //Si el siguiente caracter es T, se asigna su valor a cadena
                else if (caracter[i] == 'x' || caracter[i] == 'x')
                {
                    cadena = valorX.ToString();
                    i++;
                }
                else
                {
                    //En caso contrario, se calcula el siguiente numero
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                }
                //Y se calcula el resultado:
                resultado = Math.Cos(double.Parse(cadena));

            }

            //En caso de que el primer elemento entregado sea un numero, se agrega este valor
            else if (caracter[0] >= '0' && caracter[0] <= '9')
            {
                while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                {
                    cadena += caracter[i];
                    i++;
                }
                resultado += double.Parse(cadena);
            }
            else return 0.0;
        }

        //Siluego de calcular el primer elemento llegamos al final de la funcion, se retorna el valor obtenido
        if (i >= caracter.Length)
        {
            return resultado;
        }

        //Si no, se verifica la siguiente operacion matematica (+ - * /)
        if (caracter[i] != '+' && caracter[i] != '-' && caracter[i] != '*' && caracter[i] != '/') return 0.0;
        char operacion = caracter[i];
        i++;

        //Se aplica el metodo al siguiente elemento:
        String siguiente = "";
        for (int j = i; j < caracter.Length; j++) siguiente += caracter[j];
        Double siguienteElemento = leerFuncion(siguiente, valorX, valorY);

        if (siguienteElemento == 0.0) return 0;
        if (operacion == '+') resultado = resultado + (double)siguienteElemento;
        else if (operacion == '-') resultado = resultado - siguienteElemento;
        else if (operacion == '*') resultado = resultado * siguienteElemento;
        else
        {
            //Si hay una division por cero, se retorna 0.0
            if (siguienteElemento == 0) return 0;
            resultado = resultado / siguienteElemento;
        }
        return resultado;
    }

    public Double leerFuncion(String funcion, double valorX)
    {
        double resultado = 0;
        char[] caracter = funcion.ToCharArray();
        String cadena = "";
        int i = 0;
        //Se lee la primera parte de la funcion entregada:

        /*Si el primer caracter es un parentesis '(' se debe obtener la funcion hasta
         el cierre de parentesis, para resolver esa parte y sumarla a resultado*/
        if (caracter[0] == '(')
        {
            int contador = 0;
            //Se obtienen todos los caracteres siguientes hasta el cierre de parentes
            for (i = 1; i < caracter.Length; i++)
            {
                if (caracter[i] == '(') contador++;
                if (caracter[i] == ')')
                {
                    if (contador == 0) break;
                    contador--;
                }
                cadena += caracter[i];
            }
            //Si se leyeron todos los caracteres y no hubo un cierre de parentesis, se retorna error
            if (i == caracter.Length) return 0;
            else
            {
                resultado += leerFuncion(cadena, valorX);
                i++;
            }
        }
        //Si el primer caracter no es un parentesis
        else
        {
            if (caracter[0] == '+' || caracter[0] == '-')
            {
                resultado = 0;
            }
            //Si es X se suma el valor de valorX
            else if (caracter[0] == 'x' || caracter[0] == 'x')
            {
                //Se añade el valor de T al resultado
                resultado += valorX;
                i++;
                //Si el siguiente caracter es el signo '^' se ve el siguiente numero
                if (i < caracter.Length && caracter[i] == '^')
                {
                    i++;
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                    resultado = potencia(resultado, double.Parse(cadena));
                }
            }
            //Si el primer caracter es una l(para logaritmos):
            else if (caracter[0] == 'l')
            {
                //El segundo caracter debe ser una n (para ln: log natural) o una o (para log)
                i++;
                if (caracter[i] == 'n')
                {
                    i++;
                    //Si a continuacion no hay un numero o X, se retorna 0.0
                    if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x' && caracter[i] != 'x') return 0;

                    //Si el siguiente caracter es Y, se asigna su valor a cadena
                    else if (caracter[i] == 'x' || caracter[i] == 'x')
                    {
                        cadena = valorX.ToString();
                        i++;
                    }
                    else
                    {
                        //En caso contrario, se calcula el siguiente numero
                        while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                        {
                            cadena += caracter[i];
                            i++;
                        }
                    }
                    //Y se calcula el resultado
                    resultado = Math.Log(double.Parse(cadena));
                }
                else if (caracter[i] == 'o' && caracter[i + 1] == 'g')
                {
                    i += 2;
                    //Si a continuacion no hay un numero se retorna 0.0
                    if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x') return 0.0;

                    //Si el siguiente caracter es Y, se asigna su valor a cadena
                    //Si el siguiente caracter es T, se asigna su valor a cadena
                    else if (caracter[i] == 'x' || caracter[i] == 'x')
                    {
                        cadena = valorX.ToString();
                        i++;
                    }
                    else
                    {
                        //En caso contrario, se calcula el siguiente numero
                        while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                        {
                            cadena += caracter[i];
                            i++;
                        }
                    }
                    //Y se calcula el resultado:
                    resultado = Math.Log10(double.Parse(cadena));
                }
                else return 0.0;
            }
            //Si lo primero en la cadena es sen(funcion seno):
            else if (caracter[0] == 's' && caracter[1] == 'e' && caracter[2] == 'n')
            {
                i += 3;
                //Si a continuacion no hay un numero o la X se retorna 0.0
                if (!(caracter[i] >= '0' && caracter[i] <= '9') && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.'))) return 0.0;

                //Si el siguiente caracter es X, se asigna su valor a cadena
                //Si el siguiente caracter es T, se asigna su valor a cadena
                else if (caracter[i] == 'x' || caracter[i] == 'x')
                {
                    cadena = valorX.ToString();
                    i++;
                }
                else
                {
                    //En caso contrario, se calcula el siguiente numero
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                }
                //Y se calcula el resultado:
                resultado = Math.Sin(double.Parse(cadena));

            }
            //Si lo primero en la cadena es cos(funcion seno):
            else if (caracter[0] == 'c' && caracter[1] == 'o' && caracter[2] == 's')
            {
                i += 3;
                //Si a continuacion no hay un numero o la X se retorna 0.0
                if (!(caracter[i] >= '0' && caracter[i] <= '9') && caracter[i] != 'x') return 0.0;

                //Si el siguiente caracter es T, se asigna su valor a cadena
                else if (caracter[i] == 'x' || caracter[i] == 'x')
                {
                    cadena = valorX.ToString();
                    i++;
                }
                else
                {
                    //En caso contrario, se calcula el siguiente numero
                    while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                    {
                        cadena += caracter[i];
                        i++;
                    }
                }
                //Y se calcula el resultado:
                resultado = Math.Cos(double.Parse(cadena));

            }

            //En caso de que el primer elemento entregado sea un numero, se agrega este valor
            else if (caracter[0] >= '0' && caracter[0] <= '9')
            {
                while (i < caracter.Length && ((caracter[i] >= '0' && caracter[i] <= '9') || (caracter[i] == '.')))
                {
                    cadena += caracter[i];
                    i++;
                }
                resultado += double.Parse(cadena);
            }
            else return 0.0;
        }

        //Siluego de calcular el primer elemento llegamos al final de la funcion, se retorna el valor obtenido
        if (i >= caracter.Length)
        {
            return resultado;
        }

        //Si no, se verifica la siguiente operacion matematica (+ - * /)
        if (caracter[i] != '+' && caracter[i] != '-' && caracter[i] != '*' && caracter[i] != '/') return 0.0;
        char operacion = caracter[i];
        i++;

        //Se aplica el metodo al siguiente elemento:
        String siguiente = "";
        for (int j = i; j < caracter.Length; j++) siguiente += caracter[j];
        Double siguienteElemento = leerFuncion(siguiente, valorX);

        if (siguienteElemento == 0.0) return 0;
        if (operacion == '+') resultado = resultado + (double)siguienteElemento;
        else if (operacion == '-') resultado = resultado - siguienteElemento;
        else if (operacion == '*') resultado = resultado * siguienteElemento;
        else
        {
            //Si hay una division por cero, se retorna 0.0
            if (siguienteElemento == 0) return 0;
            resultado = resultado / siguienteElemento;
        }
        return resultado;
    }

    double potencia(double bas, double exponente){
        double resultado=bas;
        for(int i=1;i<exponente;i++)resultado*=bas;
        return resultado;
    }
}