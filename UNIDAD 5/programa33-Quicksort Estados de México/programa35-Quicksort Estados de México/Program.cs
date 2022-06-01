﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa_33
{
    class Program
    {
        class Quick
        {
            public int comparaciones, intercambios, pasadas;
            public String[] Capitales;
            int i, j;
            string x, w;
            public void Iniciar()
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
                Console.WriteLine("Estados de mexico");
                for (int o = 0; o < Capitales.Length; o++)
                {
                    Console.WriteLine("[" + (o+1) + "] = " + Capitales[o]);
                }
                Console.WriteLine("Presione Cualquier letra para continuar");
                Console.ReadKey();
            }
            public void ordenar(int L, int R)
            {
                i = L;
                j = R;
                x = Capitales[(L + R) / 2];
                pasadas++;
                do
                {
                    while (string.Compare(Capitales[i], x) < 0)
                    {
                        i = i + 1;
                        comparaciones++;
                    }
                    while (string.Compare(Capitales[j], x) > 0)
                    {
                        j = j - 1;
                        comparaciones++;
                    }
                    if (i <= j)
                    {
                        w = Capitales[i];
                        Capitales[i] = Capitales[j];
                        Capitales[j] = w;
                        i = i + 1;
                        j = j - 1;
                        intercambios++;
                    }
                }
                while (i < j);
                {
                    if (L < j)
                    {
                        ordenar(L, j);
                    }
                    if (i < R)
                    {
                        ordenar(i, R);
                    }
                }

            }
            ~Quick()
            {
                Console.WriteLine("Memoria del objeto Quick liberada correctamente");
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            long totalInicio = System.GC.GetTotalMemory(true);

            Quick obj = new Quick();
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("METODO DE QUICK DE CAPITALES\n");
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
                        obj.Iniciar();
                        break;
                    case 'b':
                        Console.WriteLine("\n");
                        obj.desplegar();
                        break;

                    case 'c':
                        Console.WriteLine("\n");
                        obj.ordenar(0, obj.Capitales.Length - 1);
                        Console.WriteLine("Arreglo ordenador correctamente");
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
