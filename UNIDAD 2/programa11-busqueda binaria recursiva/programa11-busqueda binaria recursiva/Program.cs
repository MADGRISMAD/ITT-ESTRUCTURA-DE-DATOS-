using System;
using System.Diagnostics;

namespace programa11_busqueda_binaria_recursiva
{
    public class BusquedaBinaria
    {
        public int BusquedaBi(int[] A, int low, int high, int num)
        {
            if (low > high)
            {
                return -1;
            }

            // -- Aqui hacemos la llamada recursiva

            int mid = (low + high) / 2;

            if (num == A[mid])
            {
                return mid;
            }
            if (num < A[mid])
            {
            
                return BusquedaBi(A, low, mid - 1, num);
            }
            else
            {
 
                return BusquedaBi(A, mid + 1, high, num);
            }
        }

        public static void MakeSomeGarbage()
        {
            Version vt;

            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
            }
        }

        private const int maxGarbage = 1000;

        ~BusquedaBinaria()
        {
            Console.Clear();
            Console.WriteLine("\nLa memoria de la clase fibonacci fue liberada. ");

        }

        public class CLASEMAIN
        {

            public static void Main()
            {

                Stopwatch sw = new Stopwatch();

                //---- Inicia el contador de tiempo basandose en la duracion de utilizacion del programa:

                sw.Start();

                int[] A = new int[10];

                char OPS;

                do
                {

                    Console.Clear();

                    Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                    Console.Write("\n\na) Generar y ordenar un arreglo de 10 numeros. ");
                    Console.Write("\nb) Buscar un elemento en particular. ");
                    Console.Write("\nc) Salir Del Programa. ");

                    Console.Write("\n\nIngrese la opcion a ejecutar: ");


                    OPS = Char.Parse(Console.ReadLine());

                    switch (OPS)
                    {
                        case 'a':

                            Console.Clear();

                            int Datos;
                           
                            Random ale = new Random();

                            Console.WriteLine("\nArreglo de 10 Numeros: ");
                            for (int i = 0; i < 10; i++)
                            {
                                Datos = ale.Next(10, 99);
                                A[i] = Datos;
                                Console.Write("\nNumero[" + (i + 1) + "] = " + A[i]);
                            }

                            Console.WriteLine("\n\nEl Arreglo Ordenado es: ");
                            
                            Array.Sort(A);
                            for (int i = 0; i < 10; i++)
                            {
                                Console.Write("\nNumero[" + (i + 1) + "] = " + A[i]);
                            }

                            Console.ReadKey();

                            break;

                        case 'b':

                            Console.Clear();

                            Console.Write("\nIngresa el Numero a buscar: ");
                            int n = int.Parse(Console.ReadLine());
                            BusquedaBinaria x = new BusquedaBinaria();
                            var Numero = x.BusquedaBi(A, 0, 9, n) + 1;

                            for (int i = 0; i < 10; i++)
                            {
                                Console.WriteLine("El arreglo es: " + A[i]);
                            }

                            Console.Write("\nEl Numero se encontro en la pisicion numero: " + Numero);

                            Console.ReadKey();

                            break;

                        case 'c':

                            Console.Write("\nGracias por usar el programa, pulse ENTER para continuar. ");
                            Console.ReadKey();

                            Console.Clear();

                            sw.Stop();

                            TimeSpan ts = sw.Elapsed;

                            string formatoTiempo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                            Console.Write("\nTiempo del uso del programa: {0} segundos. ", formatoTiempo);

                            MakeSomeGarbage();
                            Console.Write("\n\nMemoria usada antes de la coleccion:       {0:N0} bytes", GC.GetTotalMemory(false));

                            // --- Muestra la cantidad de memoria utilizada por los objetos

                            GC.Collect();
                            Console.Write("\nMemoria usada despues de la coleccion:   {0:N0} bytes", GC.GetTotalMemory(true));

                            Console.Write("\n\nPulse ENTER para salir del programa. ");

                            Console.ReadKey();

                            break;


                        default:

                            Console.Clear();
                            Console.Write("\nLa opcion que eligio no es correcta, por favor intente de nuevo. ");
                            Console.Write("\nPresiona ENTER para volver al menu. ");

                            Console.ReadKey();
                            Console.Clear();

                            break;
                    }

                } while (OPS != 'c');
            }

        }

    }
}
