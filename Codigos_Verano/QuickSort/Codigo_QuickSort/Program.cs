using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_QuickSort
{
    class QuickSort
    {
        public void Quick_Sort(int[] arr, int left, int right)
        {
            int privot;
            if(left > right)
            {
                privot = Partition(arr, left, right);
                Quick_Sort(arr, left, privot - 1);
                Quick_Sort(arr, privot + 1, right);

            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int left, right, privot_item = arr[low];
            left = low;
            right = high;

             while(left < right)
            {
                /*Mover left while item < pivot */
                while(arr[left] <= privot_item)
                {
                    left++;
                }

                /*Mover righ while item > privot */
                while(arr[right] > privot_item)
                {
                    right--;

                    if (left < right)
                        Swap(arr, left, right);
                }
            }

            /* right is final position for the privot*/
            arr[low] = arr[right];
            arr[right] = privot_item;
            return right;
        }

        public void Swap(int[] arr, int left, int right)
        {
           
            int  temp;

            temp = arr[right];
            arr[right] = arr[left];
            arr[left] = temp;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort qs = new QuickSort();

            int[] arr = new int[] { 2, 5, -4, 11, 18, 22, 67, 51, 6 };

            Console.WriteLine("Arreglo original: ");
            foreach(var item in arr)
            {
                Console.Write(" "+item);
            }
            Console.WriteLine("");

            qs.Quick_Sort(arr, 0, arr.Length - 1);
            Console.WriteLine("");

            Console.WriteLine("Arreglo Ordenado");
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine("");

        }
    }
}
