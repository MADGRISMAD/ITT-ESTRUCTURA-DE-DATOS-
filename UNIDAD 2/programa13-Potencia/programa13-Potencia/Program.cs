using System;
using System.Diagnostics;

namespace programa13_Potencia
{

    class Elevacion
    {
        public int Potencia(int b, int exp)
        {
            if (exp == 0)
            {
                return 1;
            }
            else
            {
                return b * Potencia(b, exp - 1);
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

        ~Elevacion()
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

                char OPS;

                do
                {

                    Console.Clear();

                    Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                    Console.Write("\n\na) Hacer el calculo de los movimientos. ");
                    Console.Write("\nb) Salir Del Programa. ");

                    Console.Write("\n\nIngrese la opcion a ejecutar: ");


                    OPS = Char.Parse(Console.ReadLine());

                    switch (OPS)
                    {
                        case 'a':

                            Console.Clear();

                            Console.Write("\nIngresa el Numero a elevar: ");
                            int Base = int.Parse(Console.ReadLine());
                            Console.Write("\nA que potencia desea elevarlo: ");
                            int Exponente = int.Parse(Console.ReadLine());

                            Elevacion e = new Elevacion();
                            Console.Write("\nEl Numero {0} elevado al exponente {1} es: {2} ", Base, Exponente, e.Potencia(Base, Exponente));

                            Console.Write("\n\nPresiona ENTER para volver al menu. ");

                            Console.ReadKey();

                            break;

                        case 'b':

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

                } while (OPS != 'b');
            }

        }
    }   
}
    
