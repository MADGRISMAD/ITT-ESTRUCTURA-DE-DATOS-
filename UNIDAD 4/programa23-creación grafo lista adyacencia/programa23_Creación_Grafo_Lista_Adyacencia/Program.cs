using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace programa23_Creación_Grafo_Lista_Adyacencia
{
    class Grafo
    {
        public char vertice;
        public List<Grafo> Aristas;
        //constructor de la clase
        public Grafo(char vertice)
        {
            //asignación de valor al vértice
            this.vertice = vertice;
            //creación lista de adyacencia
            Aristas = new List<Grafo>();
        }
        //métodos de la clase
        public void crearAristas(Grafo gI, Grafo gF)
        {
            gI.Aristas.Add(gF);
        }
        public void muestraListaAdyacencia(Grafo gI, string sangria = "")
        {
            Console.WriteLine(sangria + gI.vertice);
            foreach (var g in gI.Aristas)
            {
                muestraListaAdyacencia(g, sangria + "\t");
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
            Grafo aGrafo = new Grafo('a');
            Grafo bGrafo = new Grafo('b');
            Grafo cGrafo = new Grafo('c');
            Grafo dGrafo = new Grafo('d');
            char op;
            do
            {
                Console.Clear();
                Console.WriteLine("Creacion de Grafo Lista Adyacencia");
                Console.WriteLine("a) Creacion de aristas");
                Console.WriteLine("b) Despliegue de Lista de Adyacencia");
                Console.WriteLine("c) Salir del programa");
                Console.Write("\nIntroduzca el numero de la operacion: ");
                op = Console.ReadKey().KeyChar;
                switch (op)
                {
                    case 'a':
                        Console.Clear();
                        aGrafo.crearAristas(aGrafo, cGrafo);
                        aGrafo.crearAristas(aGrafo, bGrafo);
                        bGrafo.crearAristas(bGrafo, cGrafo);
                        bGrafo.crearAristas(bGrafo, dGrafo);
                        cGrafo.crearAristas(cGrafo, dGrafo);
                        Console.WriteLine("Aristas creadas.");
                        Console.ReadLine();
                        break;
                    case 'b':
                        Console.Clear();
                        aGrafo.muestraListaAdyacencia(aGrafo);
                        Console.ReadLine();
                        break;
                    case 'c':
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
            } while (op != 'c');
        }
    }
}