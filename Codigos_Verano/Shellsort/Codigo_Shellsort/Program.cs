using System;

namespace ShellSort
{
    public class ShellSort
    {
        public void shellsort(int[] arr, int arr_size)
        {
            int i, j, inc, temp; //inc is for incrementing the array size 
            inc = 3;  //increment value for array size
            while (inc > 0) 
            {
                for (i = 0; i < arr_size; i++)
                {
                    j = i; //j is for storing the value of i
                    temp = arr[i]; //temp is for storing the value of j
                    while ((j >= inc) && (arr[j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j = j - inc;
                    }
                    arr[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }
        public void show_arr_size(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


        }
    }

    class Program
    {


        static void Main(string[] args)
        {

            int[] arr = new int[] { 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            int n;
            ShellSort ss = new ShellSort();
            n = arr.Length;
            Console.WriteLine("elementos originales del array");
            ss.show_arr_size(arr);
            ss.shellsort(arr, n);
            Console.WriteLine("elementos ordenados del array");
            ss.show_arr_size(arr);
            Console.ReadKey();



        }
    }
}