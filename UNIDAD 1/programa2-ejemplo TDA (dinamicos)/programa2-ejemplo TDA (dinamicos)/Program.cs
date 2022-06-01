using System;
using System.Collections;

public class programa2_ejemplo_TDA__dinamicos_
{
    public static void Main()
    {
        //---- Se crea la variable para nuestra pila.

        string Pila;

        //---- Creamos el Stack con el nombre que queremos designar para los stack/datos de nuestro cola/pila.

        Stack Dato = new Stack();

        //---- Creamos la Sintaxis para crear cada uno de nuestros Stack/Datos del cola/pila.

        Dato.Push("[1] Manzana ");
        Dato.Push("[2] Naranja ");
        Dato.Push("[3] Papaya ");
        Dato.Push("[4] Melon ");
        Dato.Push("[5] Sandia ");
        Dato.Push("[6] Platano ");
        Dato.Push("[7] Limon ");
        Dato.Push("[8] Piña ");
        Dato.Push("[9] Pera ");
        Dato.Push("[10] Uva ");

        //----- Se realiza el For para repetir la Pila con la cantidad de Datos en la lista deseada.

        for (byte i = 0; i < 10; i++) //---- Dependiendo el numero que se agregue son la cantidad de datos.
        {
            Pila = (string)Dato.Pop();
            Console.WriteLine(Pila);
        }

        Console.Write("\nPulse ENTER para salir del programa. ");
        Console.ReadKey();

    } 
}
