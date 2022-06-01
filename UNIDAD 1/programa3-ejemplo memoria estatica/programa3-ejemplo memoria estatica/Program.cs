using System;

public class programa3_ejemplo_memoria_estatica
{
    static void Main(string[] args)
    {
        int[] Numeros = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

        for (int i = 0; i < 10; i++)
           
        Console.WriteLine("{0}", Numeros[i]); 

        //----- 

        Console.Write("\nPara salir del programa pulse ENTER. ");
        Console.ReadKey();

    }
}
