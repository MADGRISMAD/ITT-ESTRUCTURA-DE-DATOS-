using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Capture un numero entre 1 y 20: ");
            try
            {
                //Esta variable recopilara datos de la entrada del usuario
                string input = Console.ReadLine();
                //Esta variable se usara para realizar varias declaraciones iterativas
                //y se analiza como un entero
                int value_of_input = int.Parse(input);
                //min se usara para almacenar el valor entero aleatorio mas bajo que
                //se puede generar en la matriz binary_search
                int min = 0;
                //max se usara para almacenar el valor entero aleatorio maximo que
                //se puede generar en la matriz binary_search
                int max = 20;
                int[] binary_search = new int[value_of_input];
                //Genera una instancia de objeto de numero aleatorio llamado randNum
                Random randNum = new Random();
                //Rellene la matriz con numero aleatorios entre 0 y 20
                for(int i = 0; i < value_of_input; i++)
                {
                    //Rellene un elemento dentro de la matriz con un numero aleatorio
                    //entre 0 y 20
                    binary_search[i] = randNum.Next(min, max);
                    //Mostrar el elemento generado aleatoriamente en la consola
                    Console.Write(" " + binary_search[i]);
                }
                Console.WriteLine("");
                Console.WriteLine("");
                //Aqui el usuario debe ingresar un valor entero de la lista que
                //muestra la matriz en la consola
                Console.Write("Ahora ingrese un valor entero de esa matriz para realizar la busqueda binaria: ");
                //Esta variable recopilara datos de la entrada del usuario
                string get_search = Console.ReadLine();
                //Esta variable se usara para realizar varias declaraciones
                //iterativas y se analiza como un entero
                int value_of_get_search = int.Parse(get_search);
                //Ahora clasifique los valores enteros en la matriz segun lo requiera
                //la busqueda binaria
                Array.Sort(binary_search);
                Console.WriteLine("");
                Console.WriteLine("Aqui esta la matriz con los valores enteros en orden segun lo requerido por la busqueda binaria");
                Console.WriteLine("");
                //Imprima la matriz ordenada en la consola
                for(int i = 0; i < value_of_input; i++)
                {
                    Console.Write(" " + binary_search[i]);
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Ahora busquemos su valor entero...");
                //get_middle se usara para obtener el elemento en el medio de la matriz
                //Inicialice a 0 por ahora
                int get_middle = 0;
                //Este es el elemento inferior de la matriz. Inicialice a 0 por ahora
                int low = 0;
                //Este es el elemento superior de la matriz
                int high = (binary_search.Length) - 1;
                //Este es el medio de la matriz. mid se redondea automaticamente hacia
                //abajo si (low + high) no es un numero par
                int mid = (low + high) / 2;
                //Esta variable se utiliza para rastrear donde esta el medio. Mas adelante
                //en este codigo, vera como esto evita un bucle infinito en la busqueda binaria
                int track_middle = 0;
                //Aqui esta el algoritmo de busqueda binaria
                while(low <= high)
                {
                    //Restablecer la mitad cada vez que itera
                    mid = (low + high) / 2;
                    //Obtenga el elemento del medio en la matriz binary_search
                    //Restablecer get_middle cada vez que el ciclo while itera
                    get_middle = binary_search[mid];
                    //Esto probara a verdadero si se encuentra la coincidencia en
                    //la busqueda binaria
                    if(get_middle == value_of_get_search)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Encontro su numero entero! Aqui esta: " + value_of_get_search);
                        //sale del ciclo na vez que se encuentre la coincidencia para la busqueda
                        break;
                    }
                    //La prueba && get_middle! = Track_middle se realiza en caso de que el usuario
                    //ingrese un numero entero que no existe en la matriz
                    //Ademas, esta instruccion if se usa para reasignar el valor de high si es necesario
                    if(get_middle > value_of_get_search && get_middle != track_middle)
                    {
                        high = mid + 1;
                        Console.WriteLine("");
                        Console.WriteLine("Encontre este entero: " + get_middle + " Pero eso no es todo!");
                        //Realice un seguimiento de la mitad asignado el valor medio actual (get_middle)
                        //a track_middle
                        track_middle = get_middle;
                    }
                    //Esto reasigna el valor de low segun sea necesario el ciclo
                    else
                    {
                        //Si no se encuentrauna coincidencia, low continuara aumentado 1 mas hasta que
                        //exceda a high (como se probo en el ciclo while), entonces el ciclo se detendra
                        //De lo contrario, se usara low para continuar la busqueda
                        low = mid + 1;
                        Console.WriteLine("");
                        Console.WriteLine("Encontre este entero: " + get_middle + " Pero eso no es todo!");
                    }
                }
                //Si no se encuentra una coincidencia en el ciclo while, esto significa que el valor de
                //low ha excedido a high
                //El valor de low se rastreaen la instruccion else dentro del ciclo while anterior
                if(low > high)
                {
                    Console.WriteLine("");
                    Console.WriteLine("No se pudo encontrar su valor entero en la busqueda. Intentalo de nuevo...");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey(true);
            }//Fin del try
            catch
            {
                Console.WriteLine("Ingrese un numero entero e intente de nuevo...");
                Console.ReadKey(true);
            }
        }
    }
}