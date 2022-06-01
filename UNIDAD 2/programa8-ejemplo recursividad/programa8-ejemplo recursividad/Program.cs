using System;

namespace programa8_ejemplo_recursividad
{

    public class Recursividad
    {
        void Imprimir(int x)
        {
            if (x > 0)
            {
                Imprimir(x - 1);
                Console.WriteLine(x);
            }
        }

        public static void Main()
        {
            char OPS;

            do
            {

                Console.Clear();

                Console.Write("Bienvenido al menu, por favor seleccione una de las siguientes opciones.. ");

                Console.Write("\n\na) Imprimir numero de manera descendiente. ");
                Console.Write("\nb) Salir Del Programa. ");

                Console.Write("\n\nIngrese la opcion a ejecutar: ");


                OPS = Char.Parse(Console.ReadLine());

                switch (OPS)
                {
                    case 'a':

                        Console.Clear();

                        Recursividad re = new Recursividad();

                        Console.Write("Ingresa un valor numerico para que se desglose descendientemente: ");

                        int n = int.Parse(Console.ReadLine());
                        Console.Write("\n");
                        re.Imprimir(n);

                        Console.Write("\nPresiona ENTER para volver al menu. ");
                        Console.ReadKey();

                        break;

                    case 'b':

                        Console.Write("\n\nGracias por usar el programa, pulse ENTER para salir. ");
                        Console.ReadKey();

                        break;


                    default:

                        Console.Clear();
                        Console.Write("\nLa opcion que eligio no es correcta, por favor intente de nuevo. ");
                        Console.Write("\nPresiona ENTER para volver al menu. ");

                        Console.ReadKey();
                        Console.Clear();

                        break;
                }

            } while (OPS != 'b');
        }
    }
}
