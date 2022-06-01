using System;

public class programa1_ejemplo_estructura_de_datos
{
    struct EDDMPersonas //---- Creamos el struct y agregamos un nombre para identificarlo.
    {
        public string nombre;
        public string inicial;
        public int edad;
      
    }

    //---- Creamos nuestro Main para realizar la Array.

    public static void Main()
    {
        EDDMPersonas[] personas = new EDDMPersonas[10];

        //---------- Persona 1

        personas[0].nombre = "Juan";
        personas[0].inicial = "J";
        personas[0].edad = 20;
       
        Console.Write("La edad de {0} es {1} y su inicial es {2}. ", personas[0].nombre, personas[0].edad, personas[0].inicial);

        //---------- Persona 2

        personas[1].nombre = "Pedro";
        personas[1].inicial = "P";
        personas[1].edad = 26;

        Console.Write("\nLa edad de {0} es {1} y su inicial es {2}. ", personas[1].nombre, personas[1].edad, personas[1].inicial);

        //---------- Persona 3

        personas[2].nombre = "Ignacio";
        personas[2].inicial = "I";
        personas[2].edad = 34;

        Console.Write("\nLa edad de {0} es {1} y su inicial es {2}. ", personas[2].nombre, personas[2].edad, personas[2].inicial);

        //---------- Readkey

        Console.Write("\n\nPulse ENTER para salir del programa. ");
        Console.ReadKey();

    }

}
