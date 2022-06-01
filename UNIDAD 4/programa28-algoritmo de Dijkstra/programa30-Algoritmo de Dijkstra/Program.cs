using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace programa30_Algoritmo_de_Dijkstra
{
    class Grafo
    {
            // Campos de la clase
            string[] vertices;
            int[,] mAdyacencia;
            int[,] tablaDistancia;

            // Variables Auxiliares
            int nodos, distancia, actual, columna;

            // Constructor de la clase
            public Grafo(int nodos)
            {
                this.nodos = nodos;
                mAdyacencia = new int[nodos, nodos];
                vertices = new string[] { "Ciudad de Mexico ", "Cuernavaca ", "Puebla ", "Toluca ", "Tlaxcala " };
                tablaDistancia = new int[nodos, 3];
            }

            // Metodos de la clase
            public void CrearAristaPeso(int NodoInicio, int NodoFinal, int Peso)
            {
                mAdyacencia[NodoInicio, NodoFinal] = Peso;
            }

            public void MuestraMatrizAdyacencia()
            {
                int n = 0;
                int m = 0;

                for (n = 0; n < vertices.Length; n++)
                {
                    Console.Write(" \t{0} ", vertices[n]);
                }
                Console.WriteLine();

                for (n = 0; n < nodos; n++)
                {
                    Console.Write("{0} ", vertices[n]);

                    for (m = 0; m < nodos; m++)
                    {
                        Console.Write("\t{0, -4}", mAdyacencia[n, m]);
                    }
                    Console.WriteLine();
                }
            }

            public int ObtenAdyacencia(int Fila, int Columna)
            {
                return mAdyacencia[Fila, Columna];
            }

            public void CrearTablaDistancia(int Inicio)
            {
                // Inicializamos la tabla
                for (int n = 0; n < nodos; n++)
                {
                    tablaDistancia[n, 0] = 0;
                    tablaDistancia[n, 1] = int.MaxValue;
                    tablaDistancia[n, 2] = 0;
                }
                tablaDistancia[Inicio, 1] = 0;
            }

            public void MostrarTablaDistancia()
            {
                int n = 0;
                for (n = 0; n < tablaDistancia.GetLength(0); n++)
                {
                    Console.WriteLine("{0} --> \t\t{1}\t{2}\t{3}", n, tablaDistancia[n, 0], tablaDistancia[n, 1], tablaDistancia[n, 2]);
                }

                Console.WriteLine("------------------");
            }

            public void RutaCaminoMasCorto(int inicio, int final)
            {
                actual = inicio;

                do
                {
                    // Marcar nodo como visitado
                    tablaDistancia[actual, 0] = 1;

                    for (columna = 0; columna < nodos; columna++)
                    {
                        // Buscamos a quien se dirige
                        if (ObtenAdyacencia(actual, columna) != 0)
                        {
                            // Calculamos la distancia
                            distancia = ObtenAdyacencia(actual, columna) + tablaDistancia[actual, 1];

                            // Colocamos las distancias
                            if (distancia < tablaDistancia[columna, 1])
                            {
                                tablaDistancia[columna, 1] = distancia;

                                // Colocamos la informacion de padre
                                tablaDistancia[columna, 2] = actual;
                            }
                        }
                    }

                    int indiceMenor = -1;
                    int DistanciaMenor = int.MaxValue;

                    for (int x = 0; x < nodos; x++)
                    {
                        if (tablaDistancia[x, 1] < DistanciaMenor && tablaDistancia[x, 0] == 0)
                        {
                            indiceMenor = x;
                            DistanciaMenor = tablaDistancia[x, 1];
                        }
                    }
                    actual = indiceMenor;

                } while (actual != -1);

                MostrarTablaDistancia();

                List<int> ruta = new List<int>();
                int nodo = final;

                while (nodo != inicio)
                {
                    ruta.Add(nodo);
                    nodo = tablaDistancia[nodo, 2];
                }
                ruta.Add(inicio);

                ruta.Reverse();
                foreach (int posicion in ruta)
                    Console.Write("{0} --> ", posicion);

                Console.WriteLine();
            }

            ~Grafo()
            {
                Console.WriteLine("La memoria de la clase Fue Liberada");
            }


            // -- MENU DEL PROGRAMA

            // -- Se crea el metodo que se utiliza para poder medir la memoria utilizada en el codigo

            public static void MakeSomeGarbage()
            {
            Version vt;

            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
            }
            }


        // -- Usamos esta sentencia para darle un limite de memoria al programa

        private const int maxGarbage = 1000;


        // -- Se crea la clase para el main


        public static void Main()
        {


            // -- Objeto para utilizar nuestro contador de tiempo

            Stopwatch sw = new Stopwatch();

            //---- Inicia el contador de tiempo basandose en la duracion de utilizacion del programa:

            sw.Start();

            char OPS;

            // -------------


            // -- Objeto

            Grafo gf = null;
            int NodoTI, NodoTF;


            // -------------


            // -- Realizamos el ciclo para el menu

            do
            {

                // -- Hacemos nuestro menu de operaciones

                Console.Clear();

                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Añadir aristas con peso al Grafo. ");
                Console.Write("\n\nb) Despliegue de Matriz de Adyacencia. ");
                Console.Write("\n\nc) Crear y Desplegar Tabla Distancia entre Nodos. ");
                Console.Write("\n\nd) Calcular la ruta de camino mas corto con menor costo. ");
                Console.Write("\n\ne) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");


                // -- Creamos el switch que actuara como nuestro menu con los casos

                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {

                    case 'a':

                        Console.Clear();

                        Console.Write("\nEl Grafo Se creo Correctamente");

                        gf = new Grafo(5);

                        gf.CrearAristaPeso(0, 1, 90);
                        gf.CrearAristaPeso(0, 3, 100);
                        gf.CrearAristaPeso(1, 0, 90);
                        gf.CrearAristaPeso(1, 2, 100);
                        gf.CrearAristaPeso(2, 3, 350);
                        gf.CrearAristaPeso(2, 4, 20);
                        gf.CrearAristaPeso(3, 4, 340);
                        gf.CrearAristaPeso(3, 1, 150);
                        gf.CrearAristaPeso(3, 0, 100);
                        gf.CrearAristaPeso(3, 2, 350);

                        Console.Write("\nEl peso de las Aristas se Añadieron Correctamente");

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'b':

                        Console.Clear();

                        gf.MuestraMatrizAdyacencia();

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'c':

                        Console.Clear();

                        Console.Write("Ingresa el Indice de Nodo Inicial: ");
                        NodoTI = int.Parse(Console.ReadLine());

                        gf.CrearTablaDistancia(NodoTI);
                        gf.MostrarTablaDistancia();

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'd':

                        Console.Clear();

                        Console.Write("Ingresa el nodo de Inicio: ");
                        NodoTI = int.Parse(Console.ReadLine());
                        Console.Write("Ingresa el nodo de Final: ");
                        NodoTF = int.Parse(Console.ReadLine());

                        gf.RutaCaminoMasCorto(NodoTI, NodoTF);

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'e':

                        // -- Usamos este caso para dar cierre a nuestro programa 

                        Console.Write("\nGracias por usar el programa, pulse ENTER para continuar. ");
                        Console.ReadKey();

                        Console.Clear();

                        // -- Con esta sentencia detenemos el contador de tiempo

                        sw.Stop();

                        // -- Usamos esta sentencia para mostrar el tiempo transcurrido del programa

                        TimeSpan ts = sw.Elapsed;

                        string formatoTiempo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                        Console.Write("\nTiempo del uso del programa: {0} segundos. ", formatoTiempo);

                        // -- Muestra la cantidad de memoria antes de usar el programa

                        MakeSomeGarbage();
                        Console.Write("\n\nMemoria usada antes de la coleccion:       {0:N0} bytes", GC.GetTotalMemory(false));

                        // --- Muestra la cantidad de memoria utilizada por los objetos despues de usar el programa

                        GC.Collect();
                        Console.Write("\nMemoria usada despues de la coleccion:   {0:N0} bytes", GC.GetTotalMemory(true));

                        Console.Write("\n\nPulse ENTER para salir del programa. ");

                        Console.ReadKey();

                        break;

                    default:

                        // -- El default funciona para poder marcar un error si en el menu se pone un caracter incorrecto a los que se indica en el menu este lo mencionara

                        Console.Clear();
                        Console.Write("\nLa opcion que eligio no es correcta, por favor intente de nuevo. ");
                        Console.Write("\nPresiona ENTER para volver al menu. ");

                        Console.ReadKey();
                        Console.Clear();

                        break;
                }

                // -- Cerramos aqui el ciclo del programa agregando el caso donde queremos que el ciclo cierre completamente

            } while (OPS != 'e');
        }

    }
}
