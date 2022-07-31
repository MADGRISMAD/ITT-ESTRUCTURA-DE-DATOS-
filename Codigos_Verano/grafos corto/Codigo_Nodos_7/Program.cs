using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Nodos_7
{
    class Program
    {
        //Funcion para agregar un vorde a un grafo no dirigido
        static void addEdge(LinkedList<int>[] adj, int u, int v)
        {
            adj[u].AddLast(v);
            adj[v].AddLast(u);
        }

        //Funcion para imprimir una lista adyacente de un grafo
        static void printGraph(LinkedList<int>[] adj)
        {
            for (int i = 0; i < adj.Length; i++)
            {
                Console.WriteLine("\nLista adyacente del vetice: " + i);
                Console.Write("head");

                foreach (var item in adj[i])
                {
                    Console.Write("  -> "+ item);
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // Crear una grafo con 5 vertices
            int v = 5;
            LinkedList<int>[] adj = new LinkedList<int>[v];

            for(int i = 0; i<v; i++)
            {
                adj[i] = new LinkedList<int>();
            }

            // Agregando boredes uno por uno
            addEdge(adj, 0, 1);
            addEdge(adj, 0, 4);
            addEdge(adj, 1, 2);
            addEdge(adj, 1, 3);
            addEdge(adj, 1, 4);
            addEdge(adj, 2, 3);
            addEdge(adj, 3, 4);

            printGraph(adj);
            Console.ReadKey(); 
        }
    }
}
