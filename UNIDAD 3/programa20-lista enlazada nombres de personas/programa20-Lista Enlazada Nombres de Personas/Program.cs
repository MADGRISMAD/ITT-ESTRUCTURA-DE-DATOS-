using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa20_Lista_Enlazada_Nombres_de_Personas
{
    class Program
    {
        class Nodo
        {
            //campos clase nodo
            public string elemento;
            public int siguiente;

            //constructor clase nodo
            public Nodo(string e, int s)
            {
                elemento = e;
                siguiente = s;
            }

            //destructor clase nodo
            ~Nodo()
            {
                Console.WriteLine("Recursos del Nodo Liberados.");
            }
        }
        class ListaEnlazada
        {
            //campos clase lista enlazada
            int inicio, disponible, Max;

            Nodo[] listanombres;

            //variables auxiliares
            int tamaño, auxiliar, posicion, temporal;
            char otra;

            public ListaEnlazada(int capacidad)
            {
                Max = capacidad;
                inicio = 0;
                disponible = 0;
                tamaño = 0;
                listanombres = new Nodo[Max];
                for (int c=0; c < Max-1; c++)
                {
                    listanombres[c] = new Nodo("", c + 1);
                }
                listanombres[Max - 1] = new Nodo("", -1);
            }

            public void Insertar()//Opcion b
            {
                string dato;
                bool success;
                do
                {
                    if(tamaño==Max)
                    {
                        Console.WriteLine("\nLa Lista está Llena");
                        return;
                    }
                    else
                    {
                        Console.Write("\n¿Qué dato desea ingresar?: ");
                        dato = Console.ReadLine();                    
                        temporal = listanombres[disponible].siguiente;
                        listanombres[disponible].elemento = dato;
                        lugar_insertar(dato);
                        if (posicion==inicio)
                        {
                            listanombres[disponible].siguiente = inicio;
                            inicio = disponible;
                        }
                        else
                        {
                            listanombres[disponible].siguiente = listanombres[auxiliar].siguiente;
                            listanombres[auxiliar].siguiente = disponible;
                        }
                        disponible = temporal;
                        tamaño = tamaño + 1;
                    }
                    Console.Write("¿Desea otra inserción (S/N)?: ");
                    success = char.TryParse(Console.ReadLine(), out otra);
                    if (success == false)
                    {
                        return;
                    }
                } while (otra == 'S');
            }
            public void lugar_insertar(string dato)
            {
                int encontrado = 0;
                posicion = inicio;
                auxiliar = 0;
                while (posicion != -1 && encontrado != 1)
                {
                    if (string.Compare(listanombres[posicion].elemento, dato) > 0)
                    {
                        encontrado = encontrado + 1;
                    }
                    else
                    {
                        auxiliar = posicion;
                        posicion = listanombres[posicion].siguiente;
                    }
                }                
            }

            public void Eliminar()//opcion c
            {
                int encontrado;
                string dato;
                bool success;
                do
                {
                    if (tamaño == 0)
                    {
                        Console.WriteLine("\nLa Lista está vacía");
                        return;
                    }
                    else
                    {
                        Console.Write("\n¿Qué dato desea eliminar?: ");
                        dato = Console.ReadLine();
                        encontrado = busca_eliminar(dato);
                        if (encontrado == 1)
                        {
                            if (auxiliar != -1)
                            {
                                listanombres[auxiliar].siguiente = listanombres[posicion].siguiente;
                            }
                            else
                            {
                                inicio = listanombres[posicion].siguiente;
                            }
                            listanombres[posicion].elemento = "";
                            listanombres[posicion].siguiente = -1;
                            temporal = disponible; //actualización de espacios disponibles
                            while (temporal != -1)
                            {
                                if (listanombres[temporal].siguiente != 0)
                                {
                                    temporal = listanombres[temporal].siguiente;
                                }
                                else
                                {
                                    listanombres[temporal].siguiente = posicion;
                                }
                            }
                            tamaño = tamaño - 1; //decremento por eliminación

                        }
                    }
                    Console.Write("¿Desea otra eliminación? (S/N): ");
                    success = char.TryParse(Console.ReadLine(), out otra);
                    if (success == false)
                    {
                        return;
                    }
                } while (otra == 'S');
            }

            public int busca_eliminar(string dato)
            {
                int encontrado = 0;
                posicion = inicio;
                auxiliar = -1;
                while (posicion !=-1 && encontrado !=1)
                {
                    if (listanombres[posicion].elemento==dato)
                    {
                        encontrado = 1;
                    }
                    else
                    {
                        auxiliar = posicion;
                        posicion = listanombres[posicion].siguiente;
                    }
                }
                if (encontrado ==0)
                {
                    Console.WriteLine("El elemento || " + dato + " ||" + " NO está en la Lista");
                }
                else
                {
                    Console.WriteLine("El elemento || " + dato + " ||" + " será Eliminado de la Lista");
                }
                return encontrado;
            }

            public void Desplegar()//opcion d
            {
                posicion = inicio;
                if(tamaño==0)
                {
                    Console.WriteLine("La Lista está Vacía");
                    return;
                }
                else
                {
                    while(posicion!=-1 && listanombres[posicion].elemento !="")
                    {
                        Console.WriteLine("Elemento: " + listanombres[posicion].elemento + " Posición: " + posicion);
                        posicion = listanombres[posicion].siguiente;
                    }
                }
            }
            public void Contar()//opcion e
            {
                int contador = 0;
                posicion = inicio;
                if(tamaño==0)
                {
                    Console.WriteLine("La Lista está Vacía");
                    return;
                }
                else
                {
                    while(posicion!=-1 && listanombres[posicion].elemento !="")
                    {
                        contador = contador + 1;
                        posicion = listanombres[posicion].siguiente;
                    }
                    Console.WriteLine("El Total de Elementos en la Lista es: " + contador);
                }
            }

            public void Buscar()//opcion f
            {
                string dato;
                int encontrado;
                bool success;
                if(tamaño==0)
                {
                    Console.WriteLine("La Lista está Vacía");
                    return;
                }
                else
                {
                    do
                    {
                        encontrado = 0;
                        posicion = inicio;
                        Console.Write("\n¿Qué dato desea buscar?: ");
                        dato = Console.ReadLine();
                        while (posicion != -1 && encontrado != 1)
                        {
                            if (listanombres[posicion].elemento == dato)
                            {
                                encontrado = 1;
                            }
                            else
                            {
                                posicion = listanombres[posicion].siguiente;
                            }
                        }
                        if (encontrado == 0)
                        {
                            Console.WriteLine("El Elemento " + dato + " No está en la Lista");
                        }
                        else
                        {
                            Console.WriteLine("El Elemento " + dato + " está en la Posición " + posicion);
                        }
                        Console.Write("¿Desea otra búsqueda (S/N)?: ");
                        success = char.TryParse(Console.ReadLine(), out otra);
                        if (success == false)
                        {
                            return;
                        }
                    } while (otra == 'S');
                }
            }
            ~ListaEnlazada()
            {
                Console.WriteLine("Memoria de Lista liberada con éxito");
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "programa20 - Lista Enlazada Nombres de Personas";
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long Iniciar = System.GC.GetTotalMemory(true);
            char opc;

            ListaEnlazada list = null;

            char Menu()
            {
                Console.Clear();
                Console.WriteLine("\n    LISTA Nombres de Personas");
                Console.WriteLine("\na) Crear la lista");
                Console.WriteLine("b) Insertar un Elemento en la lista");
                Console.WriteLine("c) Eliminar un Dato de la Lista");
                Console.WriteLine("d) Recorrer la Lista");
                Console.WriteLine("e) Determinar el Número de Elementos en la Lista");
                Console.WriteLine("f) Localizar un Elemento en Particular de la Lista");
                Console.WriteLine("g) Salir del Programa");
                Console.Write("\nSeleccione una opción: ");                
                char.TryParse(Console.ReadLine(), out char valor);
                return valor;
            }

            void MensajeNull()
            {
                Console.WriteLine("==========================" +
                                "\nLa lista no ha sido creada" +
                                "\n==========================");
                Console.Write("Presione <enter> para continuar.");
            }

            do
            {
                opc = Menu();
                switch (opc)
                {
                    case 'a'://Crear Lista
                        Console.Write("Defina el tamaño de la lista: ");
                        try
                        {
                            int valor = int.Parse(Console.ReadLine());
                            list = new ListaEnlazada(valor);
                            Console.WriteLine("\nLista creada con éxito");
                        }
                        catch
                        {
                            Console.WriteLine("Dato inválido, intente de nuevo");
                            
                        }
                        Console.Write("Presione <enter> para continuar.");
                        break;
                    case 'b'://Insertar
                        if (list == null)
                        {
                            MensajeNull();
                            break;
                        }

                        list.Insertar();
                        Console.Write("Presione <enter> para continuar.");                        
                        
                        break;

                    case 'c'://Eliminar 
                        if (list == null)
                        {
                            MensajeNull();
                            break;
                        }
                        list.Eliminar();
                        Console.Write("Presione <enter> para continuar.");
                        break;
                    case 'd'://Desplegar
                        if (list == null)
                        {
                            MensajeNull();
                            break;
                        }
                        list.Desplegar();
                        Console.Write("Presione <enter> para continuar.");
                        break;
                    case 'e'://Determinar numero de elementos           
                        if (list == null)
                        {
                            MensajeNull();
                            break;
                        }
                        list.Contar();
                        Console.Write("Presione <enter> para continuar.");
                        
                        break;
                    case 'f'://Buscar elemento
                        if (list == null)
                        {
                            MensajeNull();
                            break;
                        }
                        list.Buscar();
                        Console.Write("Presione <enter> para continuar.");
                        break;
                    case 'g'://salida
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
            } while (opc != 'g');
        }
    }
}