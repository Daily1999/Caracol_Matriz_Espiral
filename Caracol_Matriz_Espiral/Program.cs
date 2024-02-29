using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace caracol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la cantidad de filas: ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la cantidad de columnas: ");
            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            int[,] matriz = new int[m, n];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = rnd.Next(10);
                    Console.Write(matriz[i, j] + "  ");
                }
                Console.WriteLine();
            }

            int[] vector = new int[m * n];
            int contador = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    vector[contador++] = matriz[i, j];
                }
            }

            Console.Write("\nVector:  ");

            foreach (var i in vector)
            {
                Console.Write(i + "  ");
            }

            int aux = 0;

            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = 0; j < vector.Length - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        aux = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = aux;
                    }
                }
            }

            Console.Write("\n\nVector ordenado:  ");


            foreach (var i in vector)
            {
                Console.Write(i + "  ");
            }

            Console.WriteLine("\n\nMatriz ordenada en forma de espiral: \n");

            MAtrizOrdenada(vector, m, n);

            Console.ReadKey();
        }

        static void MAtrizOrdenada(int[] vector, int filas, int columnas)
        {
            int[,] ordenada = new int[filas, columnas];
            int inicioFila = 0, finFila = filas - 1;
            int inicioColumna = 0, finColumna = columnas - 1;
            int contador = 0;

            while (inicioFila <= finFila && inicioColumna <= finColumna)
            {
                for (int i = inicioColumna; i <= finColumna; i++)
                {
                    ordenada[inicioFila, i] = vector[contador++];
                }
                inicioFila++;

                for (int i = inicioFila; i <= finFila; i++)
                {
                    ordenada[i, finColumna] = vector[contador++];
                }
                finColumna--;

                if (inicioFila <= finFila)
                {
                    for (int i = finColumna; i >= inicioColumna; i--)
                    {
                        ordenada[finFila, i] = vector[contador++];
                    }
                    finFila--;
                }

                if (inicioColumna <= finColumna)
                {
                    for (int i = finFila; i >= inicioFila; i--)
                    {
                        ordenada[i, inicioColumna] = vector[contador++];
                    }
                    inicioColumna++;
                }
            }

            for (int i = 0; i < ordenada.GetLength(0); i++)
            {
                for (int j = 0; j < ordenada.GetLength(1); j++)
                {
                    Console.Write(ordenada[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
