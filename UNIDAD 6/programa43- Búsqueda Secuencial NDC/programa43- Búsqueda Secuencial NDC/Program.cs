using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa43__Búsqueda_Secuencial_NDC
{
    class CLASEBASE
    {
        class SECUENCIAL
        {
            int[] arreglo = new int[50];
            int N = 50;
            public bool found;
            public int PASADAS = 0;
            public int COMPARACIONES = 0;
            Random rnd = new Random();

            public void GENERAR()
            {
                for (int i = 0; i < 50; i++)
                {
                    arreglo[i] = rnd.Next(19210000, 19210100);
                }
            }
            public void DESPLEGAR()
            {
                for (int i = 0; i < arreglo.Length; i++)
                {
                    Console.WriteLine((i + 1) + " " + arreglo[i]);
                }
            }

            public void BUSCAR(int key)
            {
                found = false;
                int I = 0;

                PASADAS++;
                while (I < N && found == false)
                {
                    COMPARACIONES++;
                    if (key == arreglo[I])
                    {
                        found = true;
                    }
                    else
                    {
                        I = I + 1;
                    }
                }

                if (found == false)
                {
                    Console.WriteLine("No esta el elemento " + key + " en el arreglo");
                }
                else
                {
                    Console.WriteLine("El elemento " + key + " esta en la posicion: " + (I + 1));
                }
            }

            // --- Destructor

            ~SECUENCIAL()
            {
                Console.WriteLine("\nLa Memoria del metodo BUSCAR fue Liberada");
            }

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

            // -- Objeto para el Menu

            SECUENCIAL M = new SECUENCIAL();

            // -- Realizamos el ciclo para el menu

            do
            {

                // -- Hacemos nuestro menu de operaciones

                Console.Clear();

                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Generar el Arreglo. ");
                Console.Write("\n\nb) Desplegar el Arreglo y buscar un Elemento. ");
                Console.Write("\n\nc) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");


                // -- Creamos el switch que actuara como nuestro menu con los casos

                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {

                    case 'a':

                        Console.Clear();

                        M.GENERAR();
                        Console.WriteLine("Los numeros de control fueron generados con exito. ");

                        Console.Write("\nPresione ENTER para volver al menu. ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'b':

                        Console.Clear();

                        int N;
                        M.DESPLEGAR();

                        Console.Write("\nIngrese el numero de control que desea buscar: ");
                        N = int.Parse(Console.ReadLine());
                        M.BUSCAR(N);

                        Console.Write("\n\nPresione ENTER para volver al menu. ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'c':

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

                        // --- Metodo de busqueda

                        Console.WriteLine("\nEl Numero de Pasadas en total es de: " + M.PASADAS);
                        Console.WriteLine("El Numero de Comparaciones en total es de: " + M.COMPARACIONES);

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

            } while (OPS != 'c');
        }





    }
}
