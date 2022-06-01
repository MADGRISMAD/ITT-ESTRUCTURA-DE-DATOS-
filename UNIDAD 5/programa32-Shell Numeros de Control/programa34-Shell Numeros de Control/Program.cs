using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa_32
{
    class Program
    {
        class Shell
        {
            public int comparaciones, intercambios, pasadas;
            int[] Arreglo = new int[50];
            int[] V = new int[10] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 };
            int incremento, H, i;
            int m;
            int k;
            public void generar()
            {
                Random numero = new Random();
                for (int i = 0; i < Arreglo.Length; i++)
                {
                    Arreglo[i] = numero.Next(20210000, 20219999);
                }
                Console.WriteLine("\nArreglo creado presione para continuar");
                Console.ReadKey();
            }
            public void desplegar()
            {
                for (int o = 0; o < Arreglo.Length; o++)
                {
                    Console.WriteLine("[" + (o+1) + "] = " + Arreglo[o]);
                }
                Console.WriteLine("Presione Cualquier letra para continuar");
                Console.ReadKey();
            }
            public void ordenar()
            {
                incremento = V.Length - 1;

                for (m = incremento; m >= 0; m--)
                {
                    pasadas++;
                    H = V[m];
                    for (int j = H; j <= Arreglo.Length - 1; j++)
                    {
                        i = j - H;
                        k = Arreglo[j];
                        comparaciones++;
                        while ((i > -1) && (k <= Arreglo[i]))
                        {
                            intercambios++;
                            Arreglo[i + H] = Arreglo[i];
                            i = i - H;

                        }
                        Arreglo[i + H] = k;
                        intercambios++;
                    }
                }
                Console.WriteLine("Arreglo ordenador correctamente");
                Console.ReadKey();
            }
            ~Shell()
            {
                Console.WriteLine("Memoria del objeto shell liberada correctamente");
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            long totalInicio = System.GC.GetTotalMemory(true);

            Shell obj = new Shell();
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("METODO DE SHELL DE NO.CONTROL\n");
                Console.WriteLine("Menú");
                Console.WriteLine("a.-generar el arreglo.");
                Console.WriteLine("b.-Desplegar el arreglo");
                Console.WriteLine("c.-Ordenar el arreglo");
                Console.WriteLine("d.-Salir");
                Console.Write("Elija una opción: ");
                opc = Console.ReadKey().KeyChar;

                switch (opc)
                {
                    case 'a':
                        obj.generar();
                        break;
                    case 'b':
                        Console.WriteLine("\n");
                        obj.desplegar();
                        break;

                    case 'c':
                        Console.WriteLine("\n");
                        obj.ordenar();
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
