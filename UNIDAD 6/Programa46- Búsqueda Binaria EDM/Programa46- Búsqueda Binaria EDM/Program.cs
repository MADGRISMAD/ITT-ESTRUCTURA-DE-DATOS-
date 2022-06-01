using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa46__Búsqueda_Binaria_EDM
{
    class CLASEBASE
    {

        class BINARIA
        {
            string temp = string.Empty;
            public int N = 32;
            public int PASADAS = 0, PASADAS2 = 0;
            public int COMPARACIONES = 0, COMPARACIONES2 = 0;
            public int INTERCAMBIOS = 0;
            public bool found;
            string[] Arreglo = { "Morelos", "Michoacan", "Nayarit", "Estado de Mexico", "Aguascalientes", "Zacatecas", "Baja California", "Veracruz", "Yucatan", "Baja California Sur", "Ciudad de Mexico", "Campeche", "Chihuahua", "Chiapas", "Tabasco", "Tlaxcala", "Coahuila", "Sonora", "Colima", "Sinaloa", "Durango", "Guanajuato", "Quintana Roo", "San Luis Potosi", "Hidalgo", "Oaxaca", "Jalisco", "Nuevo Leon", "Tamaulipas", "Queretaro", "Puebla", "Durango" };

            Random random = new Random();

            public void GENERAR()
            {
                for (int i = 0; i < N; i++)
                {
                    int Gen = random.Next(Arreglo.Length);
                }
            }
            public void DESPLEGAR()
            {
                Console.WriteLine("Estados de México");

                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine((i + 1) + " {0}", Arreglo[i]);
                }
            }
            public void ORDENAR()
            {
                for (int a = 0; a < Arreglo.Length - 1; a++)
                {
                    PASADAS++;
                    for (int b = 0; b < Arreglo.Length - 1 - a; b++)
                    {
                        COMPARACIONES++;
                        if (Arreglo[b].CompareTo(Arreglo[b + 1]) > 0)
                        {
                            INTERCAMBIOS++;
                            temp = Arreglo[b];
                            Arreglo[b] = Arreglo[b + 1];
                            Arreglo[b + 1] = temp;
                        }
                    }
                }
            }

            public void BUSCAR(string key)
            {
                found = false;
                int low = 0;
                int mid = 0;
                int hi = N - 1;

                PASADAS2++;
                while (low <= hi && found == false)
                {
                    COMPARACIONES2++;
                    mid = (low + hi) / 2;

                    if (Arreglo[mid] == key)
                    {
                        found = true;
                    }
                    else
                    {
                        if (string.Compare(Arreglo[mid], key) > 0)
                        {
                            hi = mid - 1;
                        }
                        else
                        {
                            low = mid + 1;
                        }
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("No esta el elemento: " + key + " en el arreglo");
                }
                else
                {
                    Console.WriteLine("El elemento " + key + " esta en la posición: " + (mid + 1));
                }
            }
            ~BINARIA()
            {
                Console.WriteLine("Se ha liberado la clase BINARIA correctamente. ");
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

            BINARIA M = new BINARIA();

            // -- Realizamos el ciclo para el menu

            do
            {

                // -- Hacemos nuestro menu de operaciones

                Console.Clear();

                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Generar el Arreglo. ");
                Console.Write("\n\nb) Ordenar el Arreglo. ");
                Console.Write("\n\nc) Desplegar el Arreglo y buscar un Elemento. ");
                Console.Write("\n\nd) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");


                // -- Creamos el switch que actuara como nuestro menu con los casos

                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {

                    case 'a':

                        Console.Clear();

                        M.GENERAR();
                        Console.WriteLine("Valores generados correctamente. ");

                        Console.Write("\nPresione ENTER para volver al menu. ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'b':

                        Console.Clear();

                        M.ORDENAR();
                        Console.WriteLine("Valores ordenados correctamente. ");

                        Console.Write("\n\nPresione ENTER para volver al menu. ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'c':

                        Console.Clear();

                        M.DESPLEGAR();
                        Console.Write("\nIngrese el estado que desea encontrar: ");
                        string EST = Console.ReadLine();
                        M.BUSCAR(EST);


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

                        // --- Metodos

                        Console.WriteLine("\n\nMetodo de Ordenar");
                        Console.WriteLine("");
                        Console.WriteLine("Pasadas: " + M.PASADAS);
                        Console.WriteLine("Comparaciones: " + M.COMPARACIONES);
                        Console.WriteLine("Intercambios: " + M.INTERCAMBIOS);

                        Console.WriteLine("\n\nMetodo de busqueda");
                        Console.WriteLine("");
                        Console.WriteLine("Pasadas: " + M.PASADAS2);
                        Console.WriteLine("Comparaciones: " + M.COMPARACIONES2);

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
