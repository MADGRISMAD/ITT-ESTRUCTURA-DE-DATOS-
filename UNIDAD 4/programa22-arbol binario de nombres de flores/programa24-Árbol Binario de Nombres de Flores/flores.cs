using System;
using System.Diagnostics;

namespace programa24_Árbol_Binario_de_Nombres_de_Flores
{

    class Arbol
    {

        // Campos de la calse 
        string info;
        Arbol izq, der;

        // Constructor de la clase
        public Arbol()
        {
            info = " ";
            izq = null;
            der = null;
        }

        public Arbol raiz = null;

        // Metodos de la clase
        // Procedimiento insertar
        public void insertar(string elemento)
        {
            int bandera = 0;
            Arbol hoja = new Arbol();
            hoja.info = elemento;

            if (raiz == null)
            {
                // Insertar la Raiz 
                raiz = hoja;
            }

            else
            {
                Arbol temp = raiz;
                while (bandera != 1)
                {
                    if (String.Compare(hoja.info, temp.info) < 0)
                    {
                        if (temp.izq == null)
                        {
                            //insertar subarbol derecho
                            temp.izq = hoja;
                            bandera = 1;
                        }
                        else
                        {
                            temp = temp.der;
                        }
                    }
                    else
                    {
                        if (temp.der == null)
                        {
                            // Insertra subarbol derecho
                            temp.der = hoja;
                            bandera = 1;
                        }
                        else
                        {
                            temp = temp.der;
                        }
                    }
                }
            }
        }

        // Metodo Pre-Orden
        public void Preorden(Arbol temp)
        {
            if (temp != null)
            {
                if (temp != null)
                {
                    Console.WriteLine(temp.info);
                    if (temp.izq != null)
                        // Llamada recursiva
                        Preorden(temp.izq);

                    if (temp.der != null)
                        // Llamada recursiva
                        Preorden(temp.der);

                }
                else
                {
                    Console.Write("\nEl Arbol Binario esta Vacio");
                }
            }
        }

        // Metodo In-Orden
        public void Inorden(Arbol temp)
        {
            if (temp != null)
            {
                if (temp.izq != null)
                    // Llamada recursiva
                    Inorden(temp.izq);
                Console.WriteLine(temp.info);
                if (temp.der != null)
                    // Llamada Recursiva
                    Inorden(temp.der);

            }
            else
            {
                Console.Write("\nEl Arbol Binario esta Vacio");
            }
        }

        // Metodo Pos-Orden
        public void Posorden(Arbol temp)
        {
            if (temp != null)
            {
                if (temp.izq != null)
                    // Llamada recursiva
                    Posorden(temp.izq);

                if (temp.der != null)
                    // Llamada Recursiva
                    Posorden(temp.der);
                Console.WriteLine(temp.info);

            }
            else
            {
                Console.Write("\nEl Arbol binario esta Vacio");
            }

        }

        // Busqueda
        public void BusquedaRecursiva(Arbol temp, string key)
        {
            if (temp == null)
            {
                Console.WriteLine("\nNo esta el nodo " + key + " en el Arbol Binario");
            }
            else
            {
                if (key == temp.info)
                {
                    Console.WriteLine("\nEl nodo " + key + " Si esta en el Arbol Binario");
                }
                else
                {
                    if (String.Compare(key, temp.info) < 0)
                    {
                        // Llamada Recursiva
                        BusquedaRecursiva(temp.izq, key);
                    }
                    else
                    {
                        // Llamada Recursiva
                        BusquedaRecursiva(temp.der, key);
                    }
                }
            }
        }

        // Busqueda Iterativa
        public void BusquedaIterativa(Arbol temp, string key)
        {
            bool encontrado = false;

            while (temp != null & encontrado == false)
            {
                if (key == temp.info)
                {
                    encontrado = true;
                }
                else
                {
                    if (String.Compare(key, temp.info) < 0)
                    {
                        temp = temp.izq;
                    }
                    else
                    {
                        temp = temp.der;
                    }
                }
            }
            if (encontrado == false)
            {
                Console.WriteLine("\nEl nodo " + key + " No esta en el Arbol Binario");
            }
            else
            {
                Console.WriteLine("\nEl nodo " + key + " Si esta en el Arbol Binario");
            }
        }

        // Procedimiento Eliminar
        public void Eliminar()
        {
            Arbol p, q, v, s, t;
            bool Encontrado = false;
            string x;

            p = raiz;
            q = null;
            if (p != null)
            {
                Console.Write("\nCual nodo deseas eliminar del Arbol Binario?: ");
                x = Console.ReadLine();

                while (p != null && Encontrado == false)
                {
                    if (p.info == x)
                    {
                        Encontrado = true;
                        Console.Write("El Nodo " + p.info + " Sera ELIMINADO del Arbol");
                    }
                    else
                    {
                        q = p;
                        if (String.Compare(x, p.info) < 0)
                        {
                            // Busca en Sub-arbol izquierdo
                            p = p.izq;
                        }
                        else
                        {
                            // Busca en Sub-arbol derecho
                            p = p.der;
                        }
                    }

                }
                if (Encontrado == true)
                {
                    // Solo tiene hijo derecho
                    if (p.izq == null)
                    {
                        v = p.der;
                    }
                    else
                    {
                        // Solo tiene hijo derecho
                        if (p.der == null)
                        {
                            v = p.izq;
                        }
                        // Tiene sus dos hijos
                        else
                        {
                            t = p;
                            v = p.der;
                            s = v.izq;
                            while (s != null)
                            {
                                t = v;
                                v = s;
                                s = v.izq;
                            }
                            if (t != p)
                            {
                                t.izq = v.der;
                                v.der = p.der;
                            }
                            v.izq = p.izq;
                        }
                    }
                    if (q == null)
                    {
                        // Se reasigna la raiz
                        raiz = v;
                    }
                    else
                    {
                        if (p == q.izq)
                        {
                            // Se reasigna hijo izquierdo
                            q.izq = v;
                        }
                        else
                        {
                            // Se reasigna hijo derecho 
                            q.der = v;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El Nodo " + x + " No esta en el Arbol Bianrio ");
                }
            }
            else
            {
                Console.WriteLine("El Arbol Binario esta Vacio");
            }
        }

        // Destructor de la clase
        ~Arbol()
        {
            Console.WriteLine("La memoria de la clase fue liberada");
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


            // Objeto
            Arbol a = new Arbol();
            string Dat;


            // -------------


            // -- Realizamos el ciclo para el menu

            do
            {

                // -- Hacemos nuestro menu de operaciones

                Console.Clear();

                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Isercion de Nodos. ");
                Console.Write("\n\nb) Recorrido del Arbol en Pre-Orden. ");
                Console.Write("\n\nc) Recorrido del Arbol en In-Orden. ");
                Console.Write("\n\nd) Recorrido del Arbol en Pos-Orden.  ");
                Console.Write("\n\ne) Busqueda de Elementos Recursivamente. ");
                Console.Write("\n\nf) Busqueda de Elementos Iterativamente. ");
                Console.Write("\n\ng) Eliminacion de Nodos. ");
                Console.Write("\n\nh) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");


                // -- Creamos el switch que actuara como nuestro menu con los casos

                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {

                    case 'a':

                        Console.Clear();

                        Console.Write("\nIngresa los Elementos:");
                        string Ele = Console.ReadLine();
                        a.insertar(Ele);
                        Console.Write("\n\nPresiona Enter para Volver al Menu");

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'b':

                        Console.Clear();

                        a.Preorden(a.raiz);

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'c':

                        Console.Clear();

                        a.Inorden(a.raiz);

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'd':

                        Console.Clear();

                        a.Posorden(a.raiz);

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'e':

                        Console.Clear();

                        Console.Write("\nIngresa el Dato a Buscar: ");
                        Dat = Console.ReadLine();
                        a.BusquedaRecursiva(a.raiz, Dat);

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 'f':

                        Console.Clear();

                        Console.Write("\nIngresa el Dato a Buscar: ");
                        Dat = Console.ReadLine();
                        a.BusquedaIterativa(a.raiz, Dat);

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 'g':

                        Console.Clear();

                        a.Eliminar();

                        Console.Write("\n\nPresiona Enter para volver al menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 'h':

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

            } while (OPS != 'h');
        }

    }

}
