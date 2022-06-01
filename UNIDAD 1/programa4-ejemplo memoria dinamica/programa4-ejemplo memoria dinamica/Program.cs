using System;

public class programa4_ejemplo_memoria_dinamica
{

    // ------------ SUMA

    class SUMA
    {
       
        public void IMPSUM (int S1, int S2)
        {

            int RP = S1 + S2;

            Console.Write("\nEl resultado de su suma es: " + RP);

        }

        ~SUMA()
        {
            Console.WriteLine("\n\nLa memoria de la clase SUMA fue liberada. ");
        }

    }

    // ------------ RESTA

    class RESTA
    {
       
        public void IMPRES (int R1, int R2)
        {

            int RS = R1 - R2;

            Console.Write("\nEl resultado de su resta es: " + RS);


        }

        ~RESTA()
        {
            Console.WriteLine("\n\nLa memoria de la clase RESTA fue liberada. ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            char OPS;

            do
            {
                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Hacer una suma. ");
                Console.Write("\nb) Hacer una resta. ");
                Console.Write("\nc) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");
                

                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {
                    case 'a':

                        Console.Clear();

                        Console.Write("Ingrese el primer valor: ");
                        int v1 = int.Parse(Console.ReadLine());

                        Console.Write("\nIngrese el segundo valor: ");
                        int v2 = int.Parse(Console.ReadLine());

                        SUMA S = new SUMA();

                        S.IMPSUM(v1, v2);


                        Console.Write("\n\nPresiona ENTER para volver al menu. ");
                        Console.ReadLine();
                        Console.Clear();

                        break;

                    case 'b':

                        Console.Clear();

                        Console.Write("Ingrese el primer valor: ");
                        int vr1 = int.Parse(Console.ReadLine());

                        Console.Write("\nIngrese el segundo valor: ");
                        int vr2 = int.Parse(Console.ReadLine());

                        RESTA R = new RESTA();

                       R.IMPRES(vr1, vr2);

                  
                        Console.Write("\n\nPresiona ENTER para volver al menu. ");
                        Console.ReadLine();
                        Console.Clear();

                        break;

                    case 'c':

                        Console.Write("\n\nGracias por usar el programa, pulse ENTER para salir. ");

                        break;


                    default:

                        Console.Clear();
                        Console.Write("\nLa opcion que eligio no es correcta, por favor intente de nuevo. ");
                        Console.Write("\nPresiona ENTER para volver al menu. ");

                        Console.ReadKey();
                        Console.Clear();

                        break;
                }

            } while (OPS != 'c');
            Console.ReadKey();
        }
    }
}
