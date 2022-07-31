using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            //Creacion de listas de tipo entero 
            List<int> usorted = new List<int>();
            List<int> sorted;

            ///Generacion de numeros aleatorios a ordenar
            Random random = new Random();
            Console.WriteLine("Elementos originales del arreglo: ");
            for (int i = 0; i < 10; i++)
            {
                //Agregar numeros aleatoros a la lista
                usorted.Add(random.Next(0, 100));
                Console.Write(usorted[i] + " ");
            }

            Console.WriteLine();
            //Igualamos la variable sorted a lo que regresa el metodo MergeSort
            sorted = MergeSort(usorted);
            Console.WriteLine("Elementos ordenados del arreglo: ");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");

        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            //Evalua si la lista tiene 1 o menos elementos si es asi
            //La regresa ya que no hay nada que ordenar
            if (unsorted.Count <= 1)
            {
                return unsorted;
            }

            // Creacion de listas para el ordenado a la izquierda y derecha
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            //Obtenemos un valor numerico con la mitad de la lisdta
            int middle = unsorted.Count / 2;

            //Llenamos la lista izquierda con la mitad de items de la izquierda
            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }

            //Llenamos la lista derecha con la mitad de items de la derecha
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            //Se ejecuta mientras las listas left o right tengan valores
            while (left.Count > 0 || right.Count > 0 )
            {
                if(left.Count > 0 && right.Count > 0)
                {
                    //Comparamos los primero 2 elementos para ver cual es mas pequeña 
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        //El resto de la lista menos el primer elemento
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else
                {
                    if(left.Count > 0)
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        if(right.Count > 0)
                        {
                            result.Add(right.First());
                            right.Remove(right.First());
                        }
                    }
                }
            }

            return result;
        }
    }
}
