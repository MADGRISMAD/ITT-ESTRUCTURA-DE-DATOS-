using System;
using System.Diagnostics;

namespace programa25_GrafoPonderado
{
    class Program
    {
        class Grafo
        {
            //campos de la clase
            public char[] vertices;
            int[,] mAdyacencia;
            int nodos;
            //constructor de la clase
            public Grafo(int nodos)
            {
                this.nodos = nodos;
                //creación de la matriz de adyacencia
                mAdyacencia = new int[nodos, nodos];
                //asignación de nombres a los vertices
                vertices = new char[] { 'A', 'B', 'C', 'D', 'E' };
            }
            //métodos de la clase
            public void añadirPeso(int nodoInicio, int nodoFinal, int peso)
            {
                mAdyacencia[nodoInicio, nodoFinal] = peso;
            }
            public void muestraMatrizAdyacencia()
            {
                //desplegar matriz de adyacencia incluyendo nombre de los vertices
                // y pesos de las aristas
                for (int f = 0; f < nodos; f++)//HORIZONTAL
                {
                    Console.Write("\t*" + vertices[f] + "*");
                }
                Console.WriteLine("\n\n");
                for (int f = 0; f < nodos; f++)
                {
                    Console.Write("*" + vertices[f] + "* ");//VERTICAL
                    for (int c = 0; c < nodos; c++)
                    {

                        Console.Write("\t " + mAdyacencia[f, c]);

                    }
                    Console.WriteLine();
                }
            }
            //destructor de la clase
            ~Grafo()
            {
                Console.WriteLine("\nMemoria Liberada Objeto Clase Grafo.\n");
            }
        }
        static void Main(string[] args)
        {
            //Complejidad del tiempo y espacio - INICIO
            Stopwatch tiempo = new Stopwatch();
            var inicio = System.GC.GetTotalMemory(true);
            tiempo.Start();
            Grafo migrafo = null;
            char op = 'x';
            do
            {
                Console.Clear();
                Console.WriteLine("\n\tMENÚ GRAFO PONDERADO");
                Console.WriteLine("\na) Creación del Grafo.");
                Console.WriteLine("b) Añadir Peso a las Aristas.");
                Console.WriteLine("c) Despliegue Matriz de Adyacencia con Pesos.");
                Console.WriteLine("d) Salir del Programa.");
                Console.Write("Ingrese una opción: ");
                op = char.Parse(Console.ReadLine());

                switch (op)
                {
                    case 'a':
                        Console.Clear();
                        Console.WriteLine("\nCREACIÓN DEL GRAFO");
                        migrafo = new Grafo(5);
                        Console.WriteLine("\nCreando grafo. . .");
                        Console.WriteLine("\nCOMPLETADO CON ÉXITO.");
                        Console.WriteLine("\nPresione <ENTER> para regresar al MENÚ. . .");
                        Console.ReadKey();
                        break;
                    case 'b':
                        Console.Clear();
                        migrafo.añadirPeso(0, 1, 12);
                        migrafo.añadirPeso(0, 3, 87);
                        migrafo.añadirPeso(1, 4, 11);
                        migrafo.añadirPeso(2, 0, 19);
                        migrafo.añadirPeso(3, 1, 23);
                        migrafo.añadirPeso(3, 2, 10);
                        migrafo.añadirPeso(4, 3, 43);

                        Console.WriteLine("\nAÑADIR PESO A LAS ARISTAS");
                        Console.WriteLine("\nArista " + migrafo.vertices[0] + " → " + migrafo.vertices[1] + " = 12");
                        Console.WriteLine("Arista " + migrafo.vertices[0] + " → " + migrafo.vertices[3] + " = 87");
                        Console.WriteLine("Arista " + migrafo.vertices[1] + " → " + migrafo.vertices[4] + " = 11");
                        Console.WriteLine("Arista " + migrafo.vertices[2] + " → " + migrafo.vertices[0] + " = 19");
                        Console.WriteLine("Arista " + migrafo.vertices[3] + " → " + migrafo.vertices[1] + " = 23");
                        Console.WriteLine("Arista " + migrafo.vertices[3] + " → " + migrafo.vertices[2] + " = 10");
                        Console.WriteLine("Arista " + migrafo.vertices[4] + " → " + migrafo.vertices[3] + " = 43");
                        Console.WriteLine("\nCOMPLETADO CON ÉXITO. . .");
                        Console.WriteLine("\nPresione <ENTER> para regresar al MENÚ. . .");
                        Console.ReadKey();
                        break;
                    case 'c':
                        Console.Clear();
                        Console.WriteLine("\nMATRIZ DE ADYACENCIA CON PESOS\n");
                        migrafo.muestraMatrizAdyacencia();
                        Console.WriteLine("\n\nPresione <ENTER> para regresar al MENÚ. . .");
                        Console.ReadKey();
                        break;
                    case 'd':
                        Console.Clear();
                        Console.WriteLine("\nSALIENDO. . .");

                        //Complejidad del tiempo y espacio - FINAL
                        var fin = System.GC.GetTotalMemory(true);
                        tiempo.Stop();
                        Console.WriteLine($"\nComplejidad Temporal: {tiempo.Elapsed.TotalMilliseconds} ms");
                        Console.WriteLine("\nComplejidad Espacial: " + (fin - inicio) + " bytes\n");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nOPCIÓN NO VÁLIDA.");
                        Console.WriteLine("\nPor favor, inténtelo de nuevo.");
                        Console.WriteLine("\nPresione <ENTER> para regresar al MENÚ. . .");
                        Console.ReadKey();
                        break;

                }
            }
            while (op != 'd');
        }
    }
}