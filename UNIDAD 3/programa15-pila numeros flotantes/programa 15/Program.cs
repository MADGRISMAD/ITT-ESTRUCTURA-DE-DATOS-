using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa_15
{
    class Program
    {
        class pilas
        {
            int Max, Top, Apuntador;
            float[] Pila;
            public pilas(int tamaño)
            {
                Max = tamaño;
                Top = -1;
                Pila = new float[tamaño];
                Console.WriteLine("la pila ha sido creada con exito. ");
                Console.Write("presione  <enter para continuar>");
            }
            public void Insertar(float elemento)
            {
                if (Top!=Max-1)
                {
                    Top = Top + 1;
                    Pila[Top] = elemento;
                }
                else
                {
                    Console.WriteLine("la pila esta llena");
                    Console.ReadKey();
                }
            }
            public void Eliminar()
            {
                if (Top!=1)
                {
                    Console.WriteLine("dato a eliminar" + Pila[Top]);
                    Pila[Top] = 0;
                    Top = Top - 1;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("la pila esta vacia");
                    Console.ReadKey();
                }
            }
            public void Recorrido()
            {
                if (Top!=-1)
                {
                    Apuntador = Top;
                    while (Apuntador!=-1)
                    {
                        Console.WriteLine("\nelemento: " + Pila[Apuntador]+ " posicion: " + Apuntador);
                        
                        Apuntador = Apuntador - 1;
                        

                    }
                    
                }
                else
                {
                    Console.WriteLine("la cola esta vacia");
                    Console.ReadKey();
                }
            }
            public void Busqueda(float Elemento)
            {
                if (Top!=-1)
                {
                    Apuntador = Top;
                    while(Apuntador!=-1)
                    {
                        if (Pila[Apuntador]!=-1)
                        {
                            Console.WriteLine("el dato :"+Elemento+" fue encontrado en la posicion: "+ Apuntador);
                            Console.ReadKey();

                        }
                        else
                        {
                            Apuntador = Apuntador - 1;
                        }
                    }
                    Console.WriteLine("el dato" + Elemento + "no se encontro en la pila");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("la pila esta vacia");
                    Console.ReadKey();
                }
            }



        }
        static void Main(string[] args)
        {
            Stopwatch tiempo = new Stopwatch();

            pilas obj = null;
            
            char opc;
            do
            {
                Console.Clear();
                Console.WriteLine("PILA Numeros Flotantes");
                Console.WriteLine("a) Crear la Pila.\nb) Insertar un Elemento. \nc) Eliminar el Dato del Tope. \nd) Recorrer la Pila. \ne) Buscar un Elemento. \nf) Salir del Programa.");
                Console.Write("Escriba que opcion quiere: ");
                
                opc = Console.ReadKey().KeyChar;
                switch (opc)
                {

                    case 'a':
                        Console.Write("\ningrese el valor de la pila ");
                        obj = new pilas(Convert.ToInt32(Console.ReadLine()));
                        Console.Write("Tamaño confirmado presiona <enter> para continuar");
                        Console.ReadKey();
                        break;
                        /*******************************************************************/
                    case 'b':
                        
                        if (obj==null)
                        {
                            Console.Write("\nla pila no ha sido creada");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("\ningrese el valor que desea agregar: ");
                        float elemento = Convert.ToSingle(Console.ReadLine());
                        obj.Insertar(elemento); 
                        Console.Write("Dato añadido presiona <enter> para continuar");
                        Console.ReadKey();
                        break;
                    /*******************************************************************/
                    case 'c':
                        if (obj == null)
                        {
                            Console.Write("\nla pila no ha sido creada");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("\ningrese el valor que desea eliminar: ");
                        obj.Eliminar();
                        break;
                    /*******************************************************************/
                    case 'd':
                        if (obj == null)
                        {
                            Console.Write("\nla pila no ha sido creada");
                            Console.ReadKey();
                            break;
                        }

                        obj.Recorrido();
                        Console.ReadKey();
                        break;
                    /*******************************************************************/
                    case 'e':
                        if (obj == null)
                        {
                            Console.Write("\nla pila no ha sido creada");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("ingrese el valor a buscar: ");
                        float num = Convert.ToSingle(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    /*******************************************************************/
                    case 'f':
                        tiempo.Stop();
                        Console.WriteLine("\n\n\nRESULTADO DE LAS COMPLEJIDADES DE ESPACIO Y TIEMPO");
                        long ticks1 = tiempo.ElapsedTicks;
                        Console.WriteLine("\n" + ticks1 + " ticks transcurridos");

                        TimeSpan ts = TimeSpan.FromTicks(ticks1);
                        double minutes = ts.TotalMinutes;
                        Console.WriteLine(ts + " segundos transcurridos");
                        Console.WriteLine("\nMemoria total: {0} bytes", GC.GetTotalMemory(true));
                        /*****/
                        Console.WriteLine("\nPresione cualquier tecla para terminar...");

                        Console.ReadKey();
                        
                        break;
                    /*******************************************************************/
                    default:
                        Console.WriteLine("\nopccion no valida, intente itra vez");
                        Console.ReadKey();
                        break;
                }

            } while (opc!='f');
        }
    }
}
