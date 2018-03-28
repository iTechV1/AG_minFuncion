using System;
using System.Collections.Generic;
using System.Text;

namespace AG_minFuncion
{
    class Individuo
    {
        public Cromosoma cromosoma;
        private int valorMinimo, valorMaximo, particiones;

        //Constructor que recibe los valores minimos/maximos y numero de particiones, para inicializar el cromosoma
        public Individuo(int valorMinimo, int valorMaximo, int particiones)
        {
            this.valorMinimo = valorMinimo;
            this.valorMaximo = valorMaximo;
            this.particiones = particiones;
            cromosoma = new Cromosoma(valorMinimo,valorMaximo,particiones);
        }

        //Constructor que recibe los valores minimos/maximos y numero de particiones, el cromosoma ya esta inicializado, recibe un gene
        public Individuo(string genBinario, int valorMinimo, int valorMaximo, int particiones)
        {
            this.valorMinimo = valorMinimo;
            this.valorMaximo = valorMaximo;
            this.particiones = particiones;
            cromosoma = new Cromosoma(genBinario, valorMinimo, valorMaximo, particiones);
        }

        //Operador de AG: cruza, tipo: 1 punto
        //Cruza a este individuo con otro, intercalando apartir del punto de cruza una parte del cromosoma
        //Regresa dos individuos, uno más parecido el padre y otro mas parecido a la madre
        public Individuo[] CruzaPor1Punto(Individuo individuo, int puntoDeCruza)
        {
            Gene genePadre = this.cromosoma.getGene();
            Gene geneMadre = individuo.cromosoma.getGene();

            Individuo[] hijos = new Individuo[2];
            string hijo1 = genePadre.GetBinario().Substring(0, puntoDeCruza) + geneMadre.GetBinario().Substring(puntoDeCruza);
            string hijo2 = geneMadre.GetBinario().Substring(0, puntoDeCruza) + genePadre.GetBinario().Substring(puntoDeCruza);

            hijos[0] = new Individuo(hijo1,valorMinimo,valorMaximo,particiones);
            hijos[1] = new Individuo(hijo2,valorMinimo,valorMaximo,particiones);

            return hijos;
        }

        //Operados de AG: mutación, tipo: aleatoria
        //Elige aleatoriamente un bit de su Gene para remplazarlo(aleatoriamente) por un 0 o 1
        //Se remplaza este Gene mutado por el de este individuo
        public void mutar() {
            Random rand = new Random();
            int[] gene = this.cromosoma.getGene().get();
            int index = rand.Next(gene.Length-1);
            int mutacion = rand.Next(2);

            int original = gene[index];
            gene[index] = mutacion;
            //Console.WriteLine("bit mutado " + index);
            //Console.WriteLine("mutado de "+ original +" a " + mutacion);
            this.cromosoma.getGene().set(gene);
        }

        //Representación en AG de este individuo
        public override string ToString()
        {
            return cromosoma.ToString();
        }
    }
}
