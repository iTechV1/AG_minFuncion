using System;
using System.Collections.Generic;
using System.Text;

namespace AG_minFuncion
{
    class Cromosoma
    {
        private Gene gene;
        public int min, max, P, size;
        private float dx;

        //Constructor que recibe el minimo y maximo de valores posibles y el numero de particiones
        //Se calcula la longitud del gen y el incremento entre intervalos
        //Se crea un gen de manera aleatoria
        public Cromosoma(int min, int max, int P){
            this.min = min;
            this.max = max;
            this.P = P;

            size =(int) Math.Ceiling(Math.Log(P, 2));

            dx = Math.Abs(min - max);
            dx = dx / P;

            gene = new Gene(size);
        }

        //Constructor que recibe el gene binario y el minimo/maximo de valores posibles y el numero de particiones
        //Se calcula el incremento entre intervalos
        //Se crea un gen ya inicializado
        public Cromosoma(string genBinario, int min, int max, int P) {
            this.min = min;
            this.max = max;
            this.P = P;

            dx = Math.Abs(min - max);
            dx = dx / P;

            gene = new Gene(genBinario);
        }

        //Se obtiene el valor real de la representacion del gene
        public float GetValorReal(){
            return min + dx * gene.GetDecimal();
        }

        //Regresa el gene del cromosoma
        public Gene getGene() {
            return gene;
        }

        //Representacion del cromosoma con formato: [CodigoGray]:[CodigoBinario]:[RepresentacionReal]
        public override string ToString(){
            string s = "Cromosoma:\n";
            s += "[" + gene.GetGrey() + "] : ["+gene.GetBinario()+"] : [" + GetValorReal() + "]\n";
            return s;
        }
    }
}
