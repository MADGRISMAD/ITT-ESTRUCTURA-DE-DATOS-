using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Burbuja
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vector = new int[5];
            int i, j, temp;

            Console.WriteLine("Introduce los 5 numeros a ordenar: "); 

            for (i = 0; i < 5; i++)
            {
                Console.Write("{0}.-", i+1);
                vector[i] = int.Parse(Console.ReadLine());
            }


            for (i = 0; i< 4; i++)
            {
                for (j = i+1; j < 5; j++)
                {
                    if (vector[j] < vector[i])
                    {
                        temp = vector[j];
                        vector[j] = vector[i];
                        vector[i] = temp;
                    }
                }
            }

            Console.WriteLine("Numeros ordenados: ");
            for (i = 0; i< 5; i++)
            {
                Console.WriteLine("{0}.-{1}", i+1, vector[i]);
               
            }

            Console.ReadKey();
        }
    }
}
