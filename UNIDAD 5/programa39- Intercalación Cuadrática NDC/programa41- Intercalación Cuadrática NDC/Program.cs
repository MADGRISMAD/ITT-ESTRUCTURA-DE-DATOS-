using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa_39
{
    class Program
    {
        class IntercalacionCuadratica
        {
            public int[] AUX = new int[50];
            public int[] X = new int[50];
            public int pasadas, comparaciones, intercambios;
            Random azar = new Random();
            public void Generar()
            {
                X = new int[50];
                for (int i = 0; i < X.Length; i++)
                {
                    X[i] = azar.Next(20210000, 20219999);
                }
                AUX = new int[50];
                Console.WriteLine("\nArreglo creado presione para continuar");
            }
            public void Mostrar()
            {
                for (int o = 0; o < X.Length; o++)
                {
                    Console.WriteLine("[" + o + "] = " + X[o]);
                }
                Console.WriteLine("Presione Cualquier letra para continuar");
            }
            public void IntercalacionD()
            {

                int N = X.Length;
                int I, J, K;
                int M1, M2;
                int L1, L2;

                int p = 1;

                while (p < N)
                {
                    pasadas++;
                    L1 = 0;
                    K = 0;

                    while (L1 + p <= N)
                    {
                        L2 = L1 + p;
                        M1 = L2 - 1;

                        if ((L2 + p) - 1 <= N)
                        {
                            M2 = (L2 + p) - 1;
                        }
                        else
                        {
                            M2 = N - 1;
                        }

                        I = L1;
                        J = L2;

                        while (I <= M1 && J <= M2)
                        {
                            comparaciones++;
                            if (X[I] <= X[J])
                            {
                                AUX[K] = X[I];
                                I++;
                                K++;
                                intercambios++;
                            }
                            else
                            {
                                AUX[K] = X[J];
                                J++;
                                K++;
                                intercambios++;
                            }
                        }

                        if (I > M1)
                        {
                            for (int y = J; y <= M2; y++)
                            {
                                AUX[K] = X[y];
                                K++;
                                intercambios++;
                            }
                            L1 = M2 + 1;
                        }
                        else
                        {
                            for (int y = I; y <= M1; y++)
                            {
                                AUX[K] = X[y];
                                K++;
                                intercambios++;
                            }
                            L1 = M2 + 1;
                        }
                    }
                    for (I = L1; K < N; I++)
                    {
                        AUX[K] = X[I];
                        K++;
                        intercambios++;
                    }
                    for (I = 0; I < N; I++)
                    {
                        X[I] = AUX[I];
                        intercambios++;
                    }
                    p = p * 2;
                }
            }
            ~IntercalacionCuadratica()
            {
                Console.WriteLine("Memoria del objeto Intercalacion Cuadratica eliminada");
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            long totalInicio = System.GC.GetTotalMemory(true);

            IntercalacionCuadratica obj = new IntercalacionCuadratica();
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU DE Intercalacion cuadratica");
                Console.WriteLine("a.Generar arreglo");
                Console.WriteLine("b.Desplegar arreglo.");
                Console.WriteLine("c.Intercalar arreglo.");
                Console.WriteLine("d.Salir del programa.");
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
                        obj.Mostrar();
                        Console.ReadKey();
                        break;

                    case 'c':
                        Console.WriteLine("\n");
                        obj.IntercalacionD();
                        Console.WriteLine("intercalacion realizada correctamente");
                        Console.ReadKey();
                        break;

                    case 'd':
                        Console.WriteLine("\n\nDESPLIEGUE DE COMPLEJIDADES");
                        long totalFinal = System.GC.GetTotalMemory(true);
                        Console.WriteLine("\nLa memoria utilizada en bytes es de {0} ", totalFinal - totalInicio);

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
            } while (opc != 'd');
        }
    }
}
