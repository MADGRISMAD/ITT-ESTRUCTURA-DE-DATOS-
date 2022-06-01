using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa_17
{
    class Program
    {
        public class colas
        {
            int Max, Frente, Final, Apuntador;
            float[] cola;
            public colas(int tamaño)
            {
                Max = tamaño;
                Frente = -1;
                Final = -1;
                cola = new float[tamaño];
                Console.WriteLine("la cola ha sido creada con exito.");
                Console.WriteLine("presione <enter> para continuar.");
            }

            public void encolar(float elemento)
            {
                if (Frente == 0 && Final == (Max - 1))
                {
                    Console.WriteLine("la cola esta llena");

                }
                else
                {
                    if (Frente == -1)
                    {
                        Frente = 0;
                        Final = 0;

                    }
                    else
                    {
                        Final = Final + 1;

                    }
                    cola[Final] = elemento;
                }
            }
            public void desencolar()
            {
                if (Frente != -1)
                {
                    Console.WriteLine("eliminando el dato: " + cola[Frente]);
                    cola[Frente] = 0;
                    if (Frente == Final)
                    {
                        Frente = -1;
                        Final = -1;
                    }
                    else
                    {
                        Frente = Frente + 1;
                    }

                }
                else
                {
                    Console.WriteLine("la cola esta vacia");
                }
            }

            public void recorrido()
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while (Apuntador <= Final)
                    {
                        Console.WriteLine("Elemento: " + cola[Apuntador] + " Posicion: " + Apuntador);
                        Apuntador = Apuntador + 1;
                    }
                }
                else
                {
                    Console.WriteLine("la cola esta vacia");
                }
            }

            public void busqueda(float elemento)
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while (Apuntador <= Final)
                    {
                        if (elemento == cola[Apuntador])
                        {
                            Console.WriteLine("dato encontrado en la posicion: " + Apuntador);
                            return;
                        }
                        Apuntador = Apuntador - 1;
                    }
                    Console.WriteLine("dato " + elemento + " no encontrado en la cola");
                }
                else
                {
                    Console.WriteLine("la cola esta vacia");
                }
            }
        }
        ~Program()
       {
            Console.WriteLine("memoria del objeto colas ha sido liberada");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.Title = "programa17 - Cola numeros flotantes";
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long Iniciar = System.GC.GetTotalMemory(true);
            char opc;

            colas obj = null;

            char Menu()
            {
                Console.Clear();
                Console.WriteLine("\n    COLA Números Flotantes");
                Console.WriteLine("\na) Crear la Cola");
                Console.WriteLine("b) Insertar un Elemento al final");
                Console.WriteLine("c) Eliminar el Dato del Frente");
                Console.WriteLine("d) Recorrer la Cola");
                Console.WriteLine("e) Buscar un Elemento");
                Console.WriteLine("f) Salir del Programa");
                Console.Write("\nelije una opción: ");
                char.TryParse(Console.ReadLine(), out char valor);
                return valor;
            }
            void msg()
            {
                Console.WriteLine("\nLa cola no ha sido creada");
                Console.Write("Presione <enter> para continuar.");

            }

            do
            {
                opc = Menu();
                switch (opc)
                {
                    case 'a':
                        Console.Write("elija el tamaño de la cola: ");
                        try
                        {
                            int valor = int.Parse(Console.ReadLine());
                            obj = new colas(valor);
                        }
                        catch
                        {
                            Console.WriteLine("Dato erroneo, intente de nuevo");
                            Console.Write("Presione <enter> para continuar.");
                        }
                        break;
                    case 'b'://Insertar
                        if (obj == null)
                        {
                            msg();
                            break;
                        }
                        Console.Write("Ingrese el dato a añadir: ");
                        try
                        {
                            float dato = float.Parse(Console.ReadLine());
                            obj.encolar(dato);
                            Console.Write("Presione <enter> para continuar.");
                        }
                        catch
                        {
                            Console.WriteLine("Dato erroneo, intente de nuevo");
                            Console.Write("Presione <enter> para continuar.");
                        }
                        break;

                    case 'c'://Eliminar 
                        if (obj == null)
                        {
                            msg();
                            break;
                        }
                        obj.desencolar();
                        break;
                    case 'd'://Desplegar
                        if (obj == null)
                        {
                            msg();
                            break;
                        }
                        obj.recorrido();
                        Console.Write("Presione <enter> para continuar.");
                        break;
                    case 'e'://Buscar            
                        if (obj == null)
                        {
                            msg();
                            break;
                        }
                        Console.Write("Ingrese el dato a buscar: ");
                        try
                        {
                            float buscar = float.Parse(Console.ReadLine());
                            obj.busqueda(buscar);
                        }
                        catch
                        {
                            Console.WriteLine("Dato erroneo, intente de nuevo");
                            Console.Write("Presione <enter> para continuar.");
                        }
                        break;
                    case 'f'://salida
                        stopWatch.Stop();

                        Console.WriteLine("\nTiempo transcurrido de ejecución del programa");
                        Console.WriteLine("\t{0} segundos", Math.Round(stopWatch.Elapsed.TotalSeconds, 3));
                        long Final = System.GC.GetTotalMemory(true);
                        Console.WriteLine("\nMemoria total: {0} bytes", Final - Iniciar);
                        Console.WriteLine("\nEl programa ha finalizado. \nPresione Enter para continuar...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo");
                        Console.Write("Presione <enter> para continuar."); ;
                        break;
                }
                Console.ReadLine();
            } while (opc != 'f');
        }
    }
}

