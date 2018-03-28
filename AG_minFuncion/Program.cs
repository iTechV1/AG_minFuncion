using System;

namespace AG_minFuncion
{
    class Program
    {
        public static int numeroIndividuos = 100; // Numero de individuos que tendra cada generación
        public static int generacion = 500; // Numero de generaciones de individuos
        public static Individuo[] individuos = new Individuo[numeroIndividuos]; // Arreglo de individuos
        public static Individuo[] hijos = new Individuo[numeroIndividuos]; // Arreglo de hijos de los individuos

        static void Main(string[] args)
        {
            //Se crea la primera generacion con las caracteristicas iniciales de los individuos
            for (int i = 0; i < numeroIndividuos; i++)
            {
                individuos[i] = new Individuo(-10, 10, 1024);
            }
            //Se inicia el ciclo de generaciones
            for (int generacion = 0; generacion < 500; generacion++)
            {
                //Se imprime la generación actual
                Console.WriteLine("Generacion "+generacion);
                for (int i = 0; i < numeroIndividuos; i++)
                {
                    Console.WriteLine(individuos[i]);
                }

                //Se crea una Ruleta, y se pasa como argumento los individuos a participar
                Ruleta ruleta = new Ruleta(individuos);
                Individuo[] seleccionados = ruleta.getSeleccionados();

                //Se imprimen los individuos seleccionados
                Console.WriteLine("Seleccionados");
                for (int i = 0; i < seleccionados.Length; i++)
                {
                    Console.WriteLine(seleccionados[i]);
                }

                //Se empieza a realizar la cruza de los individuos ya seleccionados
                //Se asigna a el arreglo de hijos, los dos hijos que dio como resultado la cruza
                for (int i = 0; i < seleccionados.Length; i += 2)
                {
                    Individuo[] hijo = seleccionados[i].CruzaPor1Punto(seleccionados[i + 1], 6);
                    hijos[i] = hijo[0];
                    hijos[i + 1] = hijo[1];
                }

                //Se imprimen los hijos de los individuos
                Console.WriteLine("Hijos");
                for (int i = 0; i < numeroIndividuos; i++)
                {
                    Console.WriteLine(hijos[i]);
                }

                //Se selecciona el 10% de los individuos al azar para ser mutados
                Random rand = new Random();
                for (int i = 0; i < (numeroIndividuos * 10) / 100; i++)
                {
                    int index = rand.Next(numeroIndividuos);
                    hijos[index].mutar();
                }

                //Se muestran los hijos con el 10% mutados
                Console.WriteLine("Hijos con mutación");
                for (int i = 0; i < numeroIndividuos; i++)
                {
                    Console.WriteLine(hijos[i]);
                }

                //Se hace que los hijos sean la siguiente generacion, se inicia el proceso nuevamente
                individuos = hijos;
            }
            Console.ReadLine();
        }
    }
}