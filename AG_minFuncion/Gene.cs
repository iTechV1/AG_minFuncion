using System;
using System.Collections.Generic;
using System.Text;

namespace AG_minFuncion
{
    class Gene
    {
        private int[] gene;

        //Constructor que recibe la longitud del gene, e inicializa de manera aleatoria
        public Gene(int size)
        {
            gene = new int[size];
            Random random = new Random();
            for (int x = 0; x < size; x++)
            {
                gene[x] = random.Next(2);
            }
        }

        //Constructor que recibe un gen en binario, ya está inicializado
        public Gene(string genBinario) {
            gene = new int[genBinario.Length];
            char[] bits = genBinario.ToCharArray();
            for (int i = 0; i < genBinario.Length; i++) {
                if (bits[i] == '1') gene[i] = 1;
                else gene[i] = 0;
            }
        }

        //Representacion en codigo Binario del gene
        public string GetBinario()
        {
            string s = "";
            for (int i = 0; i < gene.Length; i++)
            {
                s += gene[i];
            }
            return s;
        }

        //Representacion en codigo Gray del gene
        public string GetGrey()
        {
            string s = "";
            for (int i = 1; i < gene.Length; i++)
            {
                s += gene[i - 1] ^ gene[i];
            }
            return gene[0] + s;
        }

        //Representacion en decimal del gene
        public int GetDecimal()
        {
            int valor = 0;
            for (int x = 0; x < gene.Length; x++)
            {
                valor += gene[x] * (int) Math.Pow(2, gene.Length - x - 1);
            }
            return valor;
        }

        //Regresa el arreglo de enteros del gene
        public int[] get() {
            return gene;
        }

        //Cambia el arreglo de enteros del gene
        public void set(int[] gene) {
            this.gene = gene;
        }
    }
}
