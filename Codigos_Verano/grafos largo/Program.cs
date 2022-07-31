using System;

namespace Grafos2
{
    class CVertice
    {
        //Atributo para guardar el nombre del vertice
        public string nombre;
        //Atributo para apuntar al vertice siguiente
        public CVertice() { }
        public CVertice(string Nombre) //Constructor con parametro declarado
        {
            nombre = Nombre;
        }
        public override string ToString()
        {
            return nombre;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                return nombre.Equals(obj.ToString());
            }
        }
    }
    class CLista
    {
        //Atributo para identificar elemento individual
        private CVertice aElemento;
        //Atributo para identificar conexiones del elemento
        private CLista aSubLista;
        //Atributo para almacenar distancia entre vertices
        private int aPeso;

        public CLista() //Constructor
        {
            aElemento = null;
            aSubLista = null;
            aPeso = 0;
        }
        public CLista(CLista pLista)
        {
            if (pLista != null)
            {
                aElemento = pLista.aElemento;
                aSubLista = pLista.aSubLista;
                aPeso = pLista.aPeso;
            }
        }
        public CLista(CVertice pElemento, CLista pSubLista, int pPeso)
        {
            aElemento = pElemento;
            aSubLista = pSubLista;
            aPeso = pPeso;
        }
        public CVertice Elemento
        {
            get { return aElemento; }
            set { aElemento = value; }
        }
        public CLista SubLista
        {
            get { return aSubLista; }
            set { aSubLista = value; }
        }
        public int Peso
        {
            get { return aPeso; }
            set { aPeso = value; }
        }
        //Metodos
        public bool EsVacia()
        {
            return aElemento == null;
        }
        //Metodo para agregar un vertice al grafo
        public void Agregar(CVertice pElemento, int pPeso)
        {
            if (pElemento != null)
            {
                if (aElemento == null)
                {
                    aElemento = new CVertice(pElemento.nombre);
                    aPeso = pPeso;
                    aSubLista = new CLista();
                }
                else
                {
                    if (!ExisteElemento(pElemento))
                        aSubLista.Agregar(pElemento, pPeso);
                }
            }
        }
        //Metodo para eliminar un vertifce al grafo
        public void Eliminar(CVertice pElemento)
        {
            if (aElemento != null)
            {
                if (aElemento.Equals(pElemento))
                {
                    aElemento = aSubLista.aElemento;
                    aSubLista = aSubLista.SubLista;
                }
                else
                {
                    aSubLista.Eliminar(pElemento);
                }
            }
        }
        //Funcion que regresa el numero de elementos en el grafo
        public int NroElementos()
        {
            if (aElemento != null)
            {
                return 1 + aSubLista.NroElementos();
            }
            else
            {
                return 0;
            }
        }
        //Regresa el elemento numero 10 del grafo
        public object IesimoElemento(int posicion)
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
            {
                if (posicion == 1)
                {
                    return aElemento;
                }
                else
                {
                    return aSubLista.IesimoElemento(posicion - 1);
                }
            }
            else
            {
                return null;
            }
        }
        //Regresa la distancia del elemento numero 10
        public object IesimoElementoPeso(int posicion)
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
            {
                if (posicion == 1)
                {
                    return aPeso;
                }
                else
                {
                    return aSubLista.IesimoElementoPeso(posicion - 1);
                }
            }
            else
            {
                return 0;
            }
        }
        //Funcion que verifica si el elemento existe dentro del grafo
        public bool ExisteElemento(CVertice pElemento)
        {
            if ((aElemento != null) && (pElemento != null))
            {
                return (aElemento.Equals(pElemento) || (aSubLista.ExisteElemento(pElemento)));
            }
            else
            {
                return false;
            }
        }
        //Funcion que regresa la posicion del elemtno dentro del grafo
        public int PosicionElemento(CVertice pElemento)
        {
            if ((aElemento != null) || (ExisteElemento(pElemento)))
            {
                if (aElemento.Equals(pElemento))
                {
                    return 1;
                }
                else
                {
                    return 1 + aSubLista.PosicionElemento(pElemento);
                }
            }
            else
            {
                return 0;
            }
        }
        //Metodo que se encarga de imprimir el nombre de los vertices dentro del grafo
        public void Mostrar1()
        {
            if (aElemento != null)
            {
                Console.WriteLine(aElemento.nombre + "");
                aSubLista.Mostrar1();
            }
        }
        //Metodo que se encarga de imprimir el nombre del elemento y su distancia
        public void Mostrar()
        {
            if (aElemento != null)
            {
                Console.WriteLine(aElemento.nombre + "" + aPeso); aSubLista.Mostrar();
            }
        }
    }

    class CGrafo
    {
        //Atributo para apuntar al vertice siguiente
        protected CVertice aVertice;
        //Atributo para identificar conexiones del elemento
        protected CLista aLista;
        //Atributo para hacer referencia al grafo siguiente
        protected CGrafo aSiguiente;

        //Constructores
        public CGrafo()
        {
            aVertice = null;
            aLista = null;
            aSiguiente = null;
        }
        public CGrafo(CVertice pVertice, CLista pLista, CGrafo pSiguiente)
        {
            aVertice = pVertice;
            aLista = pLista;
            aSiguiente = pSiguiente;
        }
        //getters  setters
        public CVertice Vertice
        {
            get { return aVertice; }
            set { aVertice = value; }
        }
        public CLista Lista
        {
            get { return aLista; }
            set { aLista = value; }
        }
        public CGrafo Siguiente
        {
            get { return aSiguiente; }
            set { aSiguiente = value; }
        }
        //Operaciones basicas
        public bool EstaVacio()
        {
            return (aVertice == null);
        }
        //Funcion que regresa la cantidad de vertices en el grafo
        public int NumerodeVertices()
        {
            if (aVertice == null)
            {
                return 0;
            }
            else
            {
                return 1 + aSiguiente.NumerodeVertices();
            }
        }
        //Verifica si el vertice existe en el grafo
        public bool ExisteVertice(CVertice vertice)
        {
            if ((aVertice == null) || (vertice == null))
            {
                return false;
            }
            else
            {
                if (aVertice.nombre.Equals(vertice.nombre))
                {
                    return true;
                }
                else
                {
                    return aSiguiente.ExisteVertice(vertice);
                }
            }
        }
        //Se agrega un vertice al grafo
        public void AgregarVertice(CVertice vertice)
        {
            if ((vertice != null) && (!ExisteVertice(vertice)))
            {
                if (aVertice != null)
                {
                    if (vertice.nombre.CompareTo(aVertice.nombre) < 0)
                    {
                        CGrafo aux = new CGrafo(aVertice, aLista, aSiguiente);
                        aVertice = new CVertice(vertice.nombre);
                        aSiguiente = aux;
                    }
                    else
                    {
                        aSiguiente.AgregarVertice(vertice);
                    }
                }
                else
                {
                    aVertice = new CVertice(vertice.nombre);
                    aLista = new CLista();
                    aSiguiente = new CGrafo();
                }
            }
        }
        //Crea el arco entre 2 vertices y se almacena su distancia
        public void AgregarArco(CVertice pVerticeOrigen, CVertice pVerticeDestino, int pDistancia)
        {
            if (ExisteVertice(pVerticeOrigen) && (ExisteVertice(pVerticeDestino)))
            {
                agregarArco(pVerticeOrigen, pVerticeDestino, pDistancia);
            }
            else
            {
                Console.WriteLine("Error...No se agrego arco");
            }
        }
        //Metodo que se usa dentro del metodo AgregarArco
        private void agregarArco(CVertice pVerticeOrigen, CVertice pVerticeDestino, int pDistancia)
        {
            if (ExisteVertice(pVerticeOrigen))
            {
                if (aVertice.Equals(pVerticeOrigen))
                {
                    if ((!aLista.ExisteElemento(pVerticeDestino)))
                    {
                        aLista.Agregar(pVerticeDestino, pDistancia);
                    }
                }
                else if (aSiguiente != null)
                {
                    aSiguiente.agregarArco(pVerticeOrigen, pVerticeDestino, pDistancia);
                }
            }
        }
        //Imprimir todos los vertices del grafo
        public void MostrarVertices()
        {
            if (aVertice != null)
            {
                Console.WriteLine(aVertice.nombre);
                aSiguiente.MostrarVertices();
            }
        }
        //Una vez ya creado el grafo, imprimir la informacion en pantalla
        public void MostrarGrafo()
        {
            if (aVertice != null)
            {
                for (int i = 1; i <= aLista.NroElementos(); i++)
                {
                    Console.WriteLine(aVertice.nombre + "==>" + aLista.IesimoElemento(i) + "Con peso>>>(" + aLista.IesimoElementoPeso(i) + " ) "); aSiguiente.MostrarGrafo();
                }
            }
        }
    }

    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("**MENU**");
            Console.WriteLine("1. Crear grafo");
            Console.WriteLine("2. Agregar vertice");
            Console.WriteLine("3. Agregar arco");
            Console.WriteLine("4. Mostrar vertices");
            Console.WriteLine("5. Mostrar grafo");
            Console.WriteLine("0. Salir");
            Console.WriteLine("opcion:");
        }
        static void Main(string[] args)
        {
            string Opcion;
            string flag;
            CGrafo Grafo = new CGrafo();
            CVertice Ver = new CVertice();
            CVertice Ver1 = new CVertice();
            CVertice Ver2 = new CVertice();

            do
            {
                Menu();
                Opcion = Console.ReadLine();
                switch (Opcion)
                {
                    case "1":
                        Console.WriteLine("Desea crear un nuevo grafo: (S)/(N)");
                        flag = Console.ReadLine();
                        if (flag == "S")
                        {
                            Grafo = new CGrafo();
                            Console.WriteLine("Grafo Creado...");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el Nombre del vertice:===>>");
                        Ver.nombre = Console.ReadLine();
                        //Metodo invocado
                        Grafo.AgregarVertice(Ver);
                        break;
                    case "3":
                        Console.WriteLine("Ingrese Vertice Origen:===>>");
                        Ver1.nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Vertice Destino:===>>");
                        Ver2.nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Distancia");
                        int Dist = int.Parse(Console.ReadLine());
                        //Metodo invocado
                        Grafo.AgregarArco(Ver1, Ver2, Dist);
                        break;
                    case "4":
                        Console.WriteLine("Los vertices del grafo son:");
                        //Metodo invocado
                        Grafo.MostrarVertices();
                        break;
                    case "5":
                        Console.WriteLine("El grafo es el siguiente");
                        //Metodo invocado
                        Grafo.MostrarGrafo();
                        break;

                }
            } while (Opcion != "0");
        }
    }
}

