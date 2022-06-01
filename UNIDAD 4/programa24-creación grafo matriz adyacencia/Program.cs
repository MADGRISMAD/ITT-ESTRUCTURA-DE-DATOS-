using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa24_Creación_Grafo_Matriz_Adyacencia
{
    class Grafo
    {
        //campos de la clase
        char[] vertices;
        int[,] mAdyacencia;
        int nodos;
        //constructor de la clase
        public Grafo(int numNodos)
        {
            nodos = numNodos;
            //creación de la matriz de adyacencia
            mAdyacencia = new int[nodos, nodos];
            //asignación de los nombres de los vertices
            vertices = new char[] { 'a', 'b', 'c', 'd', 'e' };
        }
        //métodos de la clase
        public void creaArista(int nodoInicio, int nodoFinal)
        {
            mAdyacencia[nodoInicio, nodoFinal] = 1;
        }
        public void muestraMatrizAdyacencia()
        {
            Console.Write("  ");
            for (int v = 0; v < 5; v++)
            {
                Console.Write(" " + vertices[v]);
            }
            Console.WriteLine("");
            for (int f = 0; f < 5; f++)
            {
                Console.Write(" " + vertices[f]);
                for (int c = 0; c < 5; c++)
                {
                    Console.Write(" " + mAdyacencia[f, c]);
                }
                Console.WriteLine();
            }
        }
        ~Grafo()
        {
            Console.WriteLine("Memoria Clase Grafo Liberada. . .");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch tiempo = new Stopwatch();
            long Inicio = System.GC.GetTotalMemory(true);
            tiempo.Start();
            Grafo grafo = null;
            char op;
            do
            {
                Console.Clear();
                Console.WriteLine("Creacion de Grafo Lista Adyacencia");
                Console.WriteLine("a) Creación del Grafo.");
                Console.WriteLine("b) Añadir Aristas al Grafo.");
                Console.WriteLine("c) Desplegar la Matriz de Adyacencia.");
                Console.WriteLine("d) Salir del programa");
                Console.Write("\nIntroduzca el numero de la operacion: ");
                op = Console.ReadKey().KeyChar;
                switch (op)
                {
                    case 'a':
                        Console.Clear();
                        grafo = new Grafo(5);
                        Console.WriteLine("Grafo creados.");
                        Console.ReadLine();
                        break;
                    case 'b':
                        Console.Clear();
                        grafo.creaArista(0, 1);
                        grafo.creaArista(0, 4);
                        grafo.creaArista(1, 2);
                        grafo.creaArista(1, 3);
                        grafo.creaArista(2, 3);
                        grafo.creaArista(3, 0);
                        Console.WriteLine("Aristas Creadas.");
                        Console.ReadLine();
                        break;
                    case 'c':
                        Console.Clear();
                        grafo.muestraMatrizAdyacencia();
                        Console.ReadLine();
                        break;
                    case 'd':
                        tiempo.Stop();
                        long Final = System.GC.GetTotalMemory(true);
                        TimeSpan ts = tiempo.Elapsed;
                        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                        Console.WriteLine("\n\nPrograma Finalizado.");
                        Console.WriteLine("\nTiempo de la ejecucion del programa: " + elapsedTime + " Milisegundos");
                        Console.WriteLine("\nMemoria Utlizada durante el programa: {0} bytes", (Final - Inicio));
                        Console.WriteLine("\nPresione cualquier tecla para salir del programa. . .");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("[ERROR] Opcion invalida - \nEnter para regresar al menu");
                        Console.ReadLine();
                        break;
                }
            } while (op != 'd');
        }
    }
}