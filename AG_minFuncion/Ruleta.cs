using System;
using System.Collections.Generic;
using System.Text;

namespace AG_minFuncion
{
    class Ruleta
    {

        Individuo[] individuos; // individuos
        int N = 0; // numero de individuos
        float[] aptitudes; // aptitudes de los individuos
        float sumaAptitudes = 0; // suma de todas las aptitudes
        float F = 0; // frecuencia esperada total
        float[] valoresEsperados;
        float Ve = 0; // valores esperados total
        Individuo[] seleccionados; // individuos que seran seleccionados

        //Constructor que recibe los individuos que participaran en la seleccion
        //Se instancian los arreglos necesarios para la seleccion
        public Ruleta(Individuo[] individuos) {
            this.individuos = individuos;
            N = individuos.Length;
            aptitudes = new float[N];
            valoresEsperados = new float[N];
            seleccionados = new Individuo[N];
            iniciar();
        }

        private void iniciar() {
            calcularAptitudes();
            calcularValoresEsperados();
            hacerSeleccion();
        }

        //Calculo de la aptitud relativa individual
        float calcularAptitud(float valorGen)
        {
            return (float)(Math.Cos(valorGen) * Math.Exp((-Math.PI * valorGen) / 100));
        }

        //Se calculan las aptitudes de todos los individuos, se realiza el siguente arreglo (1.5+(aptitud*(-1))), para que los individuos con mejor aptitud (para llegar al minimo) tengan más probabilidad de ser seleccionados
        //Se calcula la frecuencia esperada total
        void calcularAptitudes() {
            for (int i = 0; i < N; i++) {
                aptitudes[i] = (float)(1.5) + (calcularAptitud(individuos[i].cromosoma.GetValorReal())*-1);
                sumaAptitudes += aptitudes[i];
            }
            this.F = sumaAptitudes / N;
        }

        //Se calculan los valores esperados de cada individuo Ve = aptitud * F
        //Se calcula los Valores Esperados total
        void calcularValoresEsperados() {
            for (int i = 0; i < N; i++) {
                valoresEsperados[i] = aptitudes[i] * F;
                Ve += valoresEsperados[i];
            }
        }

        //Se optiene un numero aleatorio entre 0 y Ve
        float getAleatorio()
        {
            Random rand = new Random();
            return (float)((Ve) * rand.NextDouble());
        }

        //Se selecciona un individuo hasta que se cumpla la condicion de que la suma de los Ve de cada individuo sea mayor o igual al numero aleatorio generado
        Individuo seleccionar()
        {
            float r = getAleatorio();
            float suma = 0;
            for (int i = 0; i < N; i++) {
                suma += valoresEsperados[i];
                if (suma >= r) {
                    return individuos[i];
                }
            }
            Console.WriteLine("No se escontro individuo");
            return null;
        }
        //Se realiza la seleccion de individuos N veces
        void hacerSeleccion() {
            for (int i = 0; i < N; i++) {
                seleccionados[i] = seleccionar();
            }
        }

        //Regresa los individuos que han sido seleccionados
        public Individuo[] getSeleccionados() {
            return this.seleccionados;
        }
    }
}
