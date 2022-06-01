using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa_18
{
    class Program
    {
        public class colas
        {
            int Max, Frente, Final, Apuntador;
            string[] cola;
            public colas(int tamaño)
            {
                Max = tamaño;
                Frente = -1;
                Final = -1;
                cola = new string[tamaño];
                Console.WriteLine("la cola ha sido creada con exito.");
                Console.WriteLine("presione <enter> para continuar.");
            }

            public void encolar(string elemento)
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
                    cola[Frente] = "";
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

            public void busqueda(string elemento)
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
                        Apuntador = Apuntador + 1;
                    }
                    Console.WriteLine("dato " + elemento + " no encontrado en la cola");
                }
                else
                {
                    Console.WriteLine("la cola esta vacia");
                }
            }
            ~colas()
            {
                Console.WriteLine("memoria del objeto colas ha sido liberada");

            }
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
                Console.WriteLine("\n    COLA nombre de colores");
                Console.WriteLine("\na) Crear la Cola");
                Console.WriteLine("b) Insertar un Elemento al final");
                Console.WriteLine("c) Eliminar el Dato del Frente");
                Console.WriteLine("d) Recorrer la Cola");
                Console.WriteLine("e) Buscar un Elemento");
                Console.WriteLine("f) Salir del Programa");
                Console.Write("\nSeleccione una opción: ");
                char.TryParse(Console.ReadLine(), out char valor);
                return valor;
            }

            do
            {
                opc = Menu();
                switch (opc)
                {
                    case 'a':
                        Console.Write("Defina el tamaño de la cola: ");
                        try
                        {
                            int valor = int.Parse(Console.ReadLine());
                            obj = new colas(valor);
                        }
                        catch
                        {
                            Console.WriteLine("Dato inválido, intente de nuevo");
                            Console.Write("Presione <enter> para continuar.");
                        }
                        break;
                    case 'b'://Insertar elemento
                        if (obj == null)
                        {
                            Console.WriteLine("\nLa cola no ha sido creada");
                            Console.Write("Presione <enter> para continuar.");
                            break;
                        }
                        Console.Write("Ingrese el dato a añadir: ");                
                        string dato = Console.ReadLine();
                        obj.encolar(dato);
                        Console.Write("Presione <enter> para continuar.");       
                        break;

                    case 'c'://Eliminar elemento
                        if (obj == null)
                        {
                            Console.WriteLine("\nLa cola no ha sido creada");
                            Console.Write("Presione <enter> para continuar.");
                            break;
                        }
                        obj.desencolar();
                        break;
                    case 'd'://Desplegar elemento
                        if (obj == null)
                        {
                            Console.WriteLine("\nLa cola no ha sido creada");
                            Console.Write("Presione <enter> para continuar.");
                            break;
                        }
                        obj.recorrido();
                        Console.Write("Presione <enter> para continuar.");
                        break;
                    case 'e'://Buscar elemento
                        if (obj == null)
                        {
                            Console.WriteLine("\nLa cola no ha sido creada");
                            Console.Write("Presione <enter> para continuar.");
                            break;
                        }
                        Console.Write("Ingrese el dato a buscar: ");
                        string buscar = Console.ReadLine();
                        obj.busqueda(buscar);                    
                        Console.Write("Presione <enter> para continuar.");
                        
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
