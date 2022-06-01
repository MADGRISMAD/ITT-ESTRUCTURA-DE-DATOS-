using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa_38
{
    class Program
    {
        public class Nodo
        {
            public int info;
            public int next;
            public Nodo(int i, int n)
            {
                info = i;
                next = n;
            }
            ~Nodo()
            {
                Console.WriteLine("Memoria del objeto nodo liberada");
            }
        }
        public class Radix
        {
            public int intercambios, pasadas, i;
            int[] rear = new int[10]; //Arreglo cola final
            int[] front = new int[11]; //Aregglo cola frente
            Nodo[] node = new Nodo[50]; //Arreglo de nodos
            int[] X = new int[50]; //arreglo original de numeros

            //Variable auxiliar
            int M = 8; //numero de digitos de los numeros de control
            //Constructor de la clase radix y creacion de la lista enlazada de nodos
            public Radix()
            {
                for (int C = 0; C <= node.Length - 1; C++)
                {
                    node[C] = new Nodo(0, C + 1);
                }
                node[node.Length - 1] = new Nodo(0, -1);
            }
            // metodos de la clase
            public void Iniciar()
            {

                Random numero = new Random();
                for (int i = 0; i < X.Length; i++)
                {
                    X[i] = numero.Next(20210000, 20219999);
                }
                Console.WriteLine("\nArreglo creado presione para continuar");
                Console.ReadKey();
            }
            public void desplegar()
            {
                Console.WriteLine("Numeros de control");
                for (int o = 0; o < X.Length; o++)
                {
                    Console.WriteLine("[" + (o+1) + "] = " + X[o]);
                }
                Console.WriteLine("Presione Cualquier letra para continuar");
                Console.ReadKey();
            }
            public void ordenar()
            {
                int p, k, y, expon, q;
                int N = 50, M = 8, j = 0, first = 0;
                pasadas = intercambios = 0;
                for (i = 0; i != N; i++)
                {
                    node[i].info = X[i];
                    node[i].next = i + 1;
                    intercambios++;
                }
                node[N - 1].info = X[N - 1];
                node[N - 1].next = -1;
                intercambios++;
                for (k = 1; k <= M; k++)
                {
                    pasadas++;
                    for (i = 0; i <= 9; i++)
                    {
                        rear[i] = -1;
                    }
                    for (i = 0; i <= 10; i++)
                    {
                        front[i] = -1;
                    }
                    while (first != -1)
                    {
                        p = first;
                        first = node[first].next;
                        y = node[p].info;
                        expon = 1;

                        for (i = 1; i != k; i++)
                        {
                            expon = expon * 10;
                        }
                        j = (y / expon % 10);
                        q = rear[j];
                        if (q == -1)
                        {
                            front[j] = p;
                        }
                        else
                        {
                            node[q].next = p;
                        }
                        rear[j] = p;
                    }
                    j = 0;
                    while (j <= 9 && front[j] == -1)
                    {
                        j = j + 1;
                    }
                    first = front[j];
                    p = j;
                    while (j <= 9)
                    {
                        i = j + 1;
                        while (i <= 9 && front[i] == -1)
                        {
                            i = i + 1;
                        }
                        if (i <= 9)
                        {
                            p = i;
                            node[rear[j]].next = front[i];
                        }
                        j = i;
                    }
                    node[rear[p]].next = -1;
                }
                for (i = 0; i <= N - 1; i++)
                {
                    X[i] = node[first].info;
                    first = node[first].next;
                }
                pasadas++;
            }
            // destructor de la clase
            ~Radix()
            {
                Console.WriteLine("Memoria del objeto radix liberada correctamente");
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            long totalInicio = System.GC.GetTotalMemory(true);

            Radix obj = new Radix();
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("METODO RADIX PARA NUMEROS DE CONTROL\n");
                Console.WriteLine("Menú");
                Console.WriteLine("a.-Generar el arreglo.");
                Console.WriteLine("b.-Desplegar el arreglo");
                Console.WriteLine("c.-Ordenar el arreglo");
                Console.WriteLine("d.-Salir");
                Console.Write("Elija una opción: ");
                opc = Console.ReadKey().KeyChar;

                switch (opc)
                {
                    case 'a':
                        obj.Iniciar();
                        break;
                    case 'b':
                        Console.WriteLine("\n");
                        obj.desplegar();
                        break;

                    case 'c':
                        Console.WriteLine("\n");
                        obj.ordenar();
                        Console.WriteLine("Arreglo ordenador correctamente");
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
