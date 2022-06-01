using System;
using System.Diagnostics;

namespace programa15_suma_vector
{
    public class SumaVector
    {

        public int SumarE(int[] v, int n)
        {
            if (n == 0)
            {
                return 0;

            }
            else
            {
                return SumarE(v, n - 1) + v[n - 1];
            }
        }
        ~SumaVector()
        {
            Console.WriteLine("\n\nLa memoria de la clase fue liberada");
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

        public class CLASEMAIN
        {

            public static void Main()
            {

                // -- Objeto para el arreglo

                SumaVector Sv = new SumaVector();

                // -- Variables para el arreglo

                Random ale = new Random();
                int[] v = new int[0];
                int Datos;
                int Sum = 0;
                int n = 0;

                Stopwatch sw = new Stopwatch();

                //---- Inicia el contador de tiempo basandose en la duracion de utilizacion del programa:

                sw.Start();

                char OPS;

                do
                {

                    Console.Clear();

                    Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                    Console.Write("\n\na) Generar vector aleatoriamente. ");
                    Console.Write("\nb) Sumar el vector. ");
                    Console.Write("\nc) Desplegar vector y suma. ");
                    Console.Write("\nd) Salir Del Programa. ");

                    Console.Write("\n\nIngrese la opcion a ejecutar: ");


                    OPS = Char.Parse(Console.ReadLine());

                    switch (OPS)
                    {
                        case 'a':

                            Console.Clear();

                            Console.Write("\nIngresa el tamaño del vector para generarlo: ");
                            n = int.Parse(Console.ReadLine());
                            // Creacion de Arreglo
                            v = new int[n];

                            for (int i = 0; i < n; i++)
                            {
                                Datos = ale.Next(10);
                                v[i] = Datos;
                            }
                            Console.Write("\nVector Creado Correctamente");
                            Console.Write("\n\nPresiona Enter para Volver al menu");

                            Console.ReadKey();

                            break;

                        case 'b':

                            Console.Clear();

                            Sum = Sv.SumarE(v, n);
                            Console.Write("\n\nLa Suma fue realizada con Exito");
                            Console.Write("\n\nPresiona Enter para volver al menu");

                            Console.ReadKey();

                            break;

                        case 'c':

                            Console.Clear();

                            Console.Write("\n\nEl vector es el siguiente: ");
                            for (int i = 0; i < n; i++)
                            {
                                Console.Write("\nNumero[" + (i + 1) + "] = " + v[i]);
                            }
                            Console.Write("\n\nLa suma de los elementos del vector es: " + Sum);
                            Console.Write("\n\nPresiona volver al Menú");

                            Console.ReadKey();

                            break;

                        case 'd':

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

                } while (OPS != 'd');
            }

        }

    }
}
