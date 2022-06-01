using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa_37
{
    class Program
    {
        class InterSimple
        {
            public int comparaciones, intercambios, pasadas;
            int[] A, B;
            int[] C = new int[50];
            Random azar = new Random();

            public void Generar()
            {
                A = new int[25];
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = azar.Next(20210000, 20219999);
                }
                B = new int[25];
                for (int i = 0; i < B.Length; i++)
                {
                    B[i] = azar.Next(20210000, 20219999);
                }

                Console.WriteLine("\nLos Arreglos A y B han sido Generados");
            }
            public void Desplegar()
            {
                Console.WriteLine("Arreglo A Desplegado\n");
                for (int i = 0; i < A.Length; i++)
                {
                    Console.WriteLine(i + 1 + " : " + A[i]);
                }
                Console.WriteLine("\nArreglo B Desplegado\n");
                for (int i = 0; i < B.Length; i++)
                {
                    Console.WriteLine(i + 1 + " : " + B[i]);
                }
            }
            public void Ordenar()
            {
                for (int i = 0; i < A.Length; i++)
                {
                    pasadas++;
                    for (int j = i + 1; j < A.Length; j++)
                    {
                        comparaciones++;
                        int aux;
                        if (A[i] > A[j])
                        {
                            aux = A[i];
                            A[i] = A[j];
                            A[j] = aux;
                            intercambios++;
                        }
                    }
                }
                for (int i = 0; i < B.Length; i++)
                {
                    pasadas++;
                    for (int j = i + 1; j < B.Length; j++)
                    {
                        comparaciones++;
                        int aux;
                        if (B[i] > B[j])
                        {
                            aux = B[i];
                            B[i] = B[j];
                            B[j] = aux;
                            intercambios++;
                        }
                    }
                }
                Console.WriteLine("\nLos arreglos A y B se han Ordenado Correctamente");
            }
            public void Intercalar()
            {
                int i = 0, j = 0, k = 0;
                int N = A.Length, M = B.Length;
                pasadas++;
                while (i < N && j < M)
                {
                    comparaciones++;
                    if (A[i] <= B[j])
                    {
                        intercambios++;
                        C[k] = A[i];
                        i = i + 1;
                        k = k + 1;
                    }
                    else
                    {
                        C[k] = B[j];
                        j = j + 1;
                        k = k + 1;
                    }
                }
                if (i >= N)
                {
                    for (int x = j; x < M; x++)
                    {
                        intercambios++;
                        C[k] = B[x];
                        k = k + 1;
                    }
                }
                else
                {
                    for (int x = i; x < N; x++)
                    {
                        C[k] = A[x];
                        k = k + 1;
                        intercambios++;
                    }
                }
                Console.WriteLine("\nIntercalacion Correcta");
            }
            public void Desplegar_C()
            {
                Console.WriteLine("Arreglo C Desplegado\n");
                for (int c = 0; c < C.Length; c++)
                {
                    Console.WriteLine(" [{0}].- {1}", c + 1, C[c]);
                }
            }
            ~InterSimple()
            {
                Console.WriteLine("Memoria liberada con exito");
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            long TotalInicio = System.GC.GetTotalMemory(true);

            InterSimple obj = new InterSimple();
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU DE Intercalacion Simple");
                Console.WriteLine("a.Generar vectores A y B.");
                Console.WriteLine("b.Desplegar vectores A y B.");
                Console.WriteLine("c.Ordenar vectores A y B.");
                Console.WriteLine("d.Intercalar vectores A y B.");
                Console.WriteLine("e.Desplega vector C.");
                Console.WriteLine("f.Salir del programa.");
                Console.Write("Elija una opción: ");
                opc = Console.ReadKey().KeyChar;

                switch (opc)
                {
                    case 'a':
                        obj.Generar();
                        Console.ReadKey();
                        break;
                    case 'b':
                        Console.WriteLine("\n");
                        obj.Desplegar();
                        Console.ReadKey();
                        break;

                    case 'c':
                        Console.WriteLine("\n");
                        obj.Ordenar();
                        Console.ReadKey();
                        break;

                    case 'd':
                        Console.WriteLine("\n");
                        obj.Intercalar();
                        Console.ReadKey();
                        break;

                    case 'e':
                        Console.WriteLine("\n");
                        obj.Desplegar_C();
                        Console.ReadKey();
                        break;

                    case 'f':
                        Console.WriteLine("\nDESPLIEGUE DE COMPLEJIDADES");
                        long TotalFinal = System.GC.GetTotalMemory(true);
                        Console.WriteLine("\nMemoria total: {0} bytes", TotalFinal - TotalInicio);

                        timeMeasure.Stop();
                        Console.WriteLine("\nTIEMPO TRANSCURRIDO EN LA EJECUCION DEL PROGRAMA");
                        Console.WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalSeconds} segundos");

                        Console.WriteLine("Numero de pasadas: " + obj.pasadas);
                        Console.WriteLine("Numero de comparaciones: " + obj.comparaciones);
                        Console.WriteLine("Numero de intercambios: " + obj.intercambios);
                        Console.WriteLine("\nPresione cualquier tecla para terminar...");

                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida, intente otra vez.");
                        Console.ReadKey();
                        break;
                }
            } while (opc != 'f');
        }
    }
}