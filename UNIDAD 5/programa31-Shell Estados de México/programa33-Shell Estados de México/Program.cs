using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa_31
{
    class Program
    {
        class Shell
        {
            public int comparaciones, intercambios, pasadas;
            string[] Capitales;
            int[] V = new int[7] { 1, 2, 3, 5, 7, 11, 13 };
            int incremento, H, i;
            string k;
            public void iniciar()
            {
                Capitales = new string[] {"Aguascalientes", "Mexicali", "La Paz", "Campeche", "Tuxtla Gutiérrez", "Chihuahua",
                    "Ciudad de México", "Saltillo", "Colima", "Durango", "Toluca", "Guanajuato", "Chilpancingo", "Pachuca",
                    "Guadalajara", "Morelia", "Cuernavaca", "Tepic", "Monterrey", "Oaxaca", "Puebla", "Querétaro", "Chetumal",
                    "San Luis Potosí", "Culiacán", "Hermosillo", "Villahermosa", "Ciudad Victoria", "Tlaxcala", "Xalapa", "Mérida", "Zacatecas" };
                Console.WriteLine("\nArreglo creado presione para continuar");
                Console.ReadKey();
            }
            public void desplegar()
            {
                for (int o = 0; o < Capitales.Length; o++)
                {
                    Console.WriteLine("[" + (o+1) + "] = " + Capitales[o]);
                }
                Console.WriteLine("Presione Cualquier letra para continuar");
                Console.ReadKey();
            }
            public void ordenar()
            {
                incremento = V.Length - 1;

                for (int m = incremento; m >= 0; m--)
                {
                    pasadas++;
                    H = V[m];
                    for (int j = H; j <= Capitales.Length - 1; j++)
                    {
                        i = j - H;
                        k = Capitales[j];
                        comparaciones++;
                        while (i >= 0 && string.Compare(k, Capitales[i]) <= 0)
                        {
                            intercambios++;
                            Capitales[i + H] = Capitales[i];
                            i = i - H;

                        }
                        Capitales[i + H] = k;
                        intercambios++;
                    }
                }
                Console.WriteLine("Arreglo ordenador correctamente");
                Console.ReadKey();
            }
            ~Shell()
            {
                Console.WriteLine("Memoria del objeto shell liberada correctamente");
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            long totalInicio = System.GC.GetTotalMemory(true);

            Shell obj = new Shell();
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("METODO DE SHELL DE CAPITALES\n");
                Console.WriteLine("Menú");
                Console.WriteLine("a.-iniciar el arreglo.");
                Console.WriteLine("b.-Desplegar el arreglo");
                Console.WriteLine("c.-Ordenar el arreglo");
                Console.WriteLine("d.-Salir");
                Console.Write("Elija una opción: ");
                opc = Console.ReadKey().KeyChar;

                switch (opc)
                {
                    case 'a':
                        obj.iniciar();
                        break;
                    case 'b':
                        Console.WriteLine("\n");
                        obj.desplegar();
                        break;

                    case 'c':
                        Console.WriteLine("\n");
                        obj.ordenar();
                        break;

                    case 'd':
                        Console.WriteLine("\n\nDESPLIEGUE DE COMPLEJIDADES");
                        long totalFinal = System.GC.GetTotalMemory(true);
                        Console.WriteLine("\nLa memoria utilizada en bytes es de {0} ", totalFinal - totalInicio);

                        timeMeasure.Stop();
                        Console.WriteLine("\nTIEMPO TRANSCURRIDO EN LA EJECUCION DEL PROGRAMA");
                        Console.WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalSeconds} segundos");

                        Console.WriteLine("Numero de pasadas: " + obj.pasadas);
                        Console.WriteLine("Numero de comparaciones: " + obj.comparaciones);
                        Console.WriteLine("Numero de intercambios: " + obj.intercambios);
                        Console.WriteLine("\nPresione cualquier tecla para terminar...");

                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida, intente otra vez.");
                        Console.ReadKey();
                        break;
                }
            } while (opc != 'd');
        }
    }
}