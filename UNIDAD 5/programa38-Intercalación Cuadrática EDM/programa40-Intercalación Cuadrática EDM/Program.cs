using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa_38
{
    class Program
    {
        class IntercalacionCuadratica
        {
            public string[] AUX = new string[32];
            public string[] X;
            public int pasadas, comparaciones, intercambios;
            public void Generar()
            {
                X = new string[] { "Aguascalientes", "Mexicali", "La Paz", "Campeche", "Tuxtla Gutiérrez", "Chihuahua",
                    "Ciudad de México", "Saltillo", "Colima", "Durango", "Toluca", "Guanajuato", "Chilpancingo", "Pachuca",
                    "Guadalajara", "Morelia", "Cuernavaca", "Tepic", "Monterrey", "Oaxaca", "Puebla", "Querétaro", "Chetumal",
                    "San Luis Potosí", "Culiacán", "Hermosillo", "Villahermosa", "Ciudad Victoria", "Tlaxcala", "Xalapa", "Mérida", "Zacatecas" };
                AUX = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                Console.WriteLine("\nArreglo creado presione para continuar");
            }
            public void Mostrar()
            {
                for (int o = 0; o < X.Length; o++)
                {
                    Console.WriteLine("[" + o + "] = " + X[o]);
                }
                Console.WriteLine("Presione Cualquier letra para continuar");
            }
            public void IntercalacionD()
            {
                int P = 1;
                int L1, K, L2, M1, M2, I, J;
                while (P < X.Length - 1)
                {
                    pasadas++;
                    L1 = 0;
                    K = 0;
                    while ((L1 + P) <= X.Length - 1)
                    {
                        L2 = L1 + P;
                        M1 = L2 - 1;
                        if ((L2 + P) - 1 <= X.Length - 1)
                        {
                            M2 = (L2 + P) - 1;
                        }
                        else
                        {
                            M2 = X.Length - 1;
                        }
                        I = L1;
                        J = L2;
                        while (I <= M1 && J <= M2)
                        {
                            comparaciones++;
                            if (string.Compare(X[I], X[J]) <= 0)
                            {
                                AUX[K] = X[I];
                                I = I + 1;
                                K = K + 1;
                                intercambios++;
                            }
                            else
                            {
                                AUX[K] = X[J];
                                J = J + 1;
                                K = K + 1;
                                intercambios++;
                            }
                        }
                        if (I > M1)
                        {
                            for (int Y = J; Y <= M2; Y++)
                            {
                                AUX[K] = X[Y];
                                K = K + 1;
                                intercambios++;
                            }
                        }
                        else
                        {

                            for (int Y = I; Y <= M1; Y++)
                            {
                                AUX[K] = X[Y];
                                K = K + 1;
                                intercambios++;
                            }
                        }
                        L1 = M2 + 1;
                    }
                    for (I = L1; K <= X.Length - 1; I++)
                    {
                        AUX[K] = X[I];
                        K = K = 1;
                        intercambios++;
                    }
                    for (I = 0; I <= X.Length - 1; I++)
                    {
                        X[I] = AUX[I];
                        intercambios++;
                    }
                    P = (P * 2);
                }
            }
            ~IntercalacionCuadratica()
            {
                Console.WriteLine("Memoria del objeto Intercalacion Cuadratica eliminada");
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            long totalInicio = System.GC.GetTotalMemory(true);

            IntercalacionCuadratica obj = new IntercalacionCuadratica();
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU DE Intercalacion cuadratica");
                Console.WriteLine("a.Inicializar arreglo");
                Console.WriteLine("b.Desplegar arreglo.");
                Console.WriteLine("c.Intercalar arreglo.");
                Console.WriteLine("d.Salir del programa.");
                Console.Write("Elija una opción: ");
                opc = Console.ReadKey().KeyChar;

                switch (opc)
                {
                    case 'a':
                        obj.Generar();
                        Console.ReadKey();
                        break;
                    case 'b':
                        Console.WriteLine("\n");
                        obj.Mostrar();
                        Console.ReadKey();
                        break;

                    case 'c':
                        Console.WriteLine("\n");
                        obj.IntercalacionD();
                        Console.WriteLine("intercalacion realizada correctamente");
                        Console.ReadKey();
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
