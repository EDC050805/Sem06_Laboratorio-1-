// See https://aka.ms/new-console-template for more information

Console.WriteLine("\tTiendita de Don Mariano");
Console.WriteLine("\t-----------------------\n");
Console.Write("Ingrese un número máximo de personas: ");
int maximo = int.Parse(Console.ReadLine()!);
Console.WriteLine("===========================================");
Console.WriteLine($"El número máximo establecido es de {maximo} ");
Console.WriteLine("personas, presione una tecla para comenzar ");
Console.Write("a contar ");
Console.ReadKey();
Console.Clear();
ConsoleKey tecla;
int persona = 0;
int ingresaron = 0;
int salieron = 0;
/*
Se coloca -1 en vez de 0 porque al iniciar el "do while" las veces que se llenan van a ser aumentadas en dos cada vez que
se llega al máximo y para evitar eso se debe colocar como -1, cosa que solo se aumentaría 1. Para comprobarlo se puede usar
la compilación paso a paso.  
*/
int lleno = -1;
int vacio = 0;

do
{   
    if (persona <= maximo && persona >= 0)
    {
        //Se usa "$" para concatenar un texto con una variable 
        Console.WriteLine("=========================================");
        Console.WriteLine($"| Asistentes actuales | {persona}");
        Console.WriteLine($"| Aforo               | {(persona * 100) / maximo}%");
        Console.WriteLine($"| Máximo              | {maximo} personas");
        Console.WriteLine("=========================================");
        Console.WriteLine("Presione");
        Console.WriteLine("[i] si ingresa una persona");
        Console.WriteLine("[s] si sale una persona");
        Console.Write("[x] para terminar");
    }
    else if (persona > maximo)
    {
        Console.WriteLine("¡Error! La cantidad de asistentes no puede superar el máximo");        
        Console.WriteLine("Presione [s] para seguir contando");        
        ingresaron--;
        salieron--;
        lleno--;
    }
    else
    {
        Console.WriteLine("¡Error! La cantidad de asistentes no puede ser negativo");
        return;
    }

    tecla = Console.ReadKey().Key;
    switch (tecla)
    {
        case ConsoleKey.I: persona++; break;
        case ConsoleKey.S: persona--; break;
    }
    
    if (tecla == ConsoleKey.S) salieron++;
    if (tecla == ConsoleKey.I) ingresaron++;
    if (persona == maximo) lleno++;    
    if (persona == 0) vacio ++;
 
    Console.Clear();
} while (tecla != ConsoleKey.X);

//La cantidad de personas debe ser distinto del maximo y de 0 y como no pasa eso en algunas ocasiones en el
// "do while", por eso es que se aumenta 1 a la variable
//"lleno" y se resta 1 al vacio luego del "do while" para evitar que los datos terminen afectados
if (persona < maximo) lleno++;
if (persona == 0) vacio--;
Console.Clear();
Console.WriteLine("=========================================");
Console.WriteLine("El programa ha terminado");
Console.WriteLine("=========================================");
Console.WriteLine("Estadísticas: ");
Console.WriteLine("--------------------------");
Console.WriteLine(ingresaron + " personas ingresaron");
Console.WriteLine(salieron + " personas salieron");
Console.WriteLine(lleno + " veces se llenó el local");
Console.WriteLine("Estuvo vacío {0} " + "veces", vacio);