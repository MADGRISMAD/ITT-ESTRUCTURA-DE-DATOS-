using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa32_Burbuja_Numeros_de_Control
{
    class CLASEBASE
    {
        class NumerosControl
        {

            int temp = 0;
            public int n = 50, pasadas = 0, comparaciones = 0, intercambios = 0;
            int[] arreglo = new int[50];
            private static int Length;

            // -- Objeto

            Random r = new Random();

            public void generar()
            {
                for (int i = 0; i < n; i++)
                {
                    arreglo[i] = r.Next(19210000, 19210100);
                }
            }

            public void desplegar()
            {
                
                Console.WriteLine("Numeros de control: ");
              

                for (int i = 0; i < arreglo.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.- {arreglo[i]}");
                }

            }

            public void ordenar()
            {
                for (int m = 0; m < arreglo.Length - 1; m++)
                {

                    pasadas++;

                    for (int x = 0; x < arreglo.Length - 1 - m; x++)
                    {
                        comparaciones++;

                        if (arreglo[x] > arreglo[x + 1])
                        {
                            intercambios++;

                            temp = arreglo[x];
                            arreglo[x] = arreglo[x + 1];
                            arreglo[x + 1] = temp;
                        }
                    }
                }
            }

            // --- Creamos el destructor de la clase

            ~NumerosControl()
            {
                Console.WriteLine("La memoria de la clase BURBUJA fue liberada. ");
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

            NumerosControl b = new NumerosControl();

            // -- Realizamos el ciclo para el menu

            do
            {

                // -- Hacemos nuestro menu de operaciones

                Console.Clear();

                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Inicializar el arreglo. ");
                Console.Write("\n\nb) Desplegar el arreglo. ");
                Console.Write("\n\nc) Ordenar el Arreglo. ");
                Console.Write("\n\nd) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");


                // -- Creamos el switch que actuara como nuestro menu con los casos

                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {

                    case 'a':

                        Console.Clear();

                        b = new NumerosControl();
                        b.generar();
                        Console.Write("\nEl arreglo se ha generado correctamente. ");

                        Console.Write("\n\nPresione ENTER para volver al menu. ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'b':

                        Console.Clear();

                        b.desplegar();

                        Console.Write("\n\nPresione ENTER para volver al menu. ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'c':

                        Console.Clear();

                        Console.Write("\nEl arreglo se ha generado correctamente. ");
                        b.ordenar();

                        Console.Write("\n\nPresione ENTER para volver al menu. ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'd':

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

                        Console.WriteLine($"Metodo de busqueda\nPasadas: {b.pasadas} \nComparaciones: {b.comparaciones} \nIntercambios: {b.intercambios}");

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

            } while (OPS != 'd');
        }
    }
}
