using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programa46__Búsqueda_Hash_Numeros_de_Control
{
    class BusquedaHash
    {
        public int[] K = new int[50];
        public int[] V = new int[50];
        public int comparaciones, pasadas, intercambios;
        public int pasadasB, comparacionesB;
        public int D, i, DX;
        public void Generar()
        {
            Random numero = new Random();
            for (int i = 0; i < K.Length; i++)
            {
                K[i] = numero.Next(20210000, 20219999);
                V[i] = 0;
            }
        }
        public void Desplegar()
        {
            for (int o = 0; o < K.Length; o++)
            {
                Console.WriteLine("[" + (o + 1) + "] " + K[o]);
            }
        }
        public void DesplegarV()
        {
            for (int o = 0; o < V.Length; o++)
            {
                Console.WriteLine("[" + (o + 1) + "] " + V[o]);
            }
        }
        public void Asignar()
        {
            int N = K.Length - 1;
            for (i = 0; i <= N; i++)
            {
                D = (K[i] % N) + 1;
                while (V[D] != 0)
                {
                    DX = D + 1;
                    if (DX > N)
                    {
                        D = 0;
                    }
                    else
                    {
                        D = DX;
                    }
                }
                V[D] = K[i];
                //intercambios
            }  
        }
        public void Busqueda()
        {
            int n = K.Length;
            Console.Write("\nIngrese un elemento a buscar: ");
            int key = int.Parse(Console.ReadLine());
            D = (key % (n-1)) + 1;
            if (V[D] == key)
            {
                Console.WriteLine("El elemento: "+key+ " Esta en la posicion: "+ (D + 1));
            }
            else
            {
                DX = D + 1;
                while ((DX <= (n - 1)) && (V[DX] != key) && (V[DX] != 0) && (DX != D))
                {
                    DX = DX + 1;
                    if (DX > (n - 1))
                    {
                        DX = 0;
                    }
                }
                if (V[DX] == key)
                {
                    Console.WriteLine("El elemento: " + key + " Esta en la posicion: "+(D + 1));
                }
                else
                {
                    Console.WriteLine("El elemento: "+key+" NO esta en el Arreglo");
                }
            }
        }


        ~BusquedaHash()
        {
            Console.WriteLine("Memoria BusquedaBinaria Liberada. . .");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch tiempo = new Stopwatch();
            long Inicio = System.GC.GetTotalMemory(true);
            tiempo.Start();
            BusquedaHash hash = new BusquedaHash();
            char op;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU Busqueda Binaria");
                Console.WriteLine("a) Generar Arreglo K y V.");
                Console.WriteLine("b) Desplegar Arreglo K");
                Console.WriteLine("c) Asignar Nuevas Direcciones.");
                Console.WriteLine("d) Desplegar Arreglo V Y Buscar Elementos.");
                Console.WriteLine("e) Salir del programa.");
                Console.Write("\nIntroduzca el numero de la operacion: ");
                op = Console.ReadKey().KeyChar;
                switch (op)
                {
                    case 'a':
                        Console.Clear();
                        hash.Generar();
                        Console.WriteLine("Arreglo Generado.");
                        Console.ReadLine();
                        break;
                    case 'b':
                        Console.Clear();
                        hash.Desplegar();
                        Console.ReadLine();
                        break;
                    case 'c':
                        Console.Clear();
                        hash.Asignar();
                        Console.WriteLine("Direcciones Asignadas");
                        Console.ReadLine();
                        break;
                    case 'd':
                        Console.Clear();
                        hash.DesplegarV();
                        hash.Busqueda();
                        Console.ReadLine();
                        break;
                    case 'e':
                        tiempo.Stop();
                        long Final = System.GC.GetTotalMemory(true);
                        TimeSpan ts = tiempo.Elapsed;
                        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                        Console.WriteLine("\n\nPrograma Finalizado.");
                        Console.WriteLine("\nTiempo de la ejecucion del programa: " + elapsedTime + " Milisegundos");
                        Console.WriteLine("\nMemoria Utlizada durante el programa: {0} bytes", (Final - Inicio));
                        Console.WriteLine("\n Complejidad de Ordenamiento");
                        Console.WriteLine("Numero de pasadas: " + hash.pasadas);
                        Console.WriteLine("Numero de comparaciones: " + hash.comparaciones);
                        Console.WriteLine("Numero de Intercambios: " + hash.intercambios);
                        Console.WriteLine("\n Complejidad de Busqueda");
                        Console.WriteLine("Numero de pasadas: " + hash.pasadasB);
                        Console.WriteLine("Numero de comparaciones: " + hash.comparacionesB);
                        Console.WriteLine("\nPresione cualquier tecla para salir del programa. . .");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("[ERROR] Opcion invalida - \nEnter para regresar al menu");
                        Console.ReadLine();
                        break;
                }
            } while (op != 'e');
        }
    }
}
