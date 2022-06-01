using System;
using System.Diagnostics;

namespace programa26_Orden_Topológico_de_un_Grafo
{
    class Grafo
    {
        // Campos de la clase
        char[] vertices;
        int[,] mAdyacencia;
        int[] indegree;
        int nodos;

        // Constructor de la clase
        public Grafo(int nodos)
        {
            this.nodos = nodos;
            mAdyacencia = new int[nodos, nodos];
            indegree = new int[nodos];
            vertices = new char[] { '0', '1', '2', '3', '4', '5', '6' };
        }

        // Metodos de la clase
        public void CrearArista(int NodoInicio, int NodoFinal)
        {
            mAdyacencia[NodoInicio, NodoFinal] = 1;
        }

        public void MuestraMatrizAdyacencia()
        {
            int n = 0;
            int m = 0;

            for (n = 0; n < vertices.Length; n++)
            {
                Console.Write("\t{0,-7}", vertices[n]);
            }
            Console.WriteLine();

            for (n = 0; n < nodos; n++)
            {
                Console.Write("{0}", vertices[n]);

                for (m = 0; m < nodos; m++)
                {
                    Console.Write("\t{0,-7}", mAdyacencia[n, m]);
                }
                Console.WriteLine();
            }
        }

        public void CalcularIndegree()
        {
            int n = 0;
            int m = 0;

            for (n = 0; n < nodos; n++)
            {
                for (m = 0; m < nodos; m++)
                {
                    if (mAdyacencia[m, n] == 1)
                    {
                        indegree[n]++;
                    }
                }
            }
        }

        public void MuestraIndegree()
        {
            int n = 0;
            for (n = 0; n < nodos; n++)
            {
                Console.WriteLine("Nodo: {0},{1}", n, indegree[n]);
            }
        }

        public int EncuentraIndegree()
        {
            bool Encontrado = false;
            int n = 0;
            for (n = 0; n < nodos; n++)
            {
                if (indegree[n] == 0)
                {
                    Encontrado = true;
                    break;
                }
            }

            if (Encontrado)
                return n;

            // Indica que no se ha encontrado
            else
                return -1;
        }

        public void DecrementaIndegree(int Nodo)
        {
            indegree[Nodo] = -1;

            int n = 0;
            for (n = 0; n < nodos; n++)
            {
                if (mAdyacencia[Nodo, n] == 1)
                {
                    indegree[n]--;
                }
            }
        }

        public void OrdenamientoTopologico()
        {
            int nodo = 0;

            do
            {
                nodo = EncuentraIndegree();

                if (nodo != -1)
                {
                    //Imprimimos el nodo
                    Console.Write("{0} --> ", nodo);

                    // Decrementamos los indegrees 
                    DecrementaIndegree(nodo);
                }

            } while (nodo != -1);
            Console.WriteLine();
        }

        // Destructor
        ~Grafo()
        {
            Console.WriteLine("\nLa Memoria de la Clase Fue Liberada ");
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

            // Objeto
            Grafo gf = null;

            // -------------


            // -- Realizamos el ciclo para el menu

            do
            {

                // -- Hacemos nuestro menu de operaciones

                Console.Clear();

                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Añadir Aristas al Grafo. ");
                Console.Write("\n\nb) Desplegar la Matriz de Adyacencia. ");
                Console.Write("\n\nc) Calcular y Desplegar el Indegre. ");
                Console.Write("\n\nd) Realizar Ordenamiento Topologico. ");
                Console.Write("\n\ne) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");


                // -- Creamos el switch que actuara como nuestro menu con los casos

                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {

                    case 'a':

                        Console.Clear();

                        gf = new Grafo(7);
                        Console.Write("\nEl Grafo Se creo Correctamente");

                        gf.CrearArista(0, 2);
                        gf.CrearArista(0, 1);
                        gf.CrearArista(0, 3);

                        gf.CrearArista(1, 3);
                        gf.CrearArista(2, 3);

                        gf.CrearArista(2, 4);
                        gf.CrearArista(3, 5);
                        gf.CrearArista(4, 5);



                        Console.Write("\nLas Arsitas se Añadieron Correctamente");

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

                        gf.CalcularIndegree();
                        gf.MuestraIndegree();

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'd':

                        Console.Clear();

                        gf.OrdenamientoTopologico();

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
