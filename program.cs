using System;

class Program
{
    static void Main(string[] args)
    {
        decimal costoDia = 20000;

        Console.WriteLine("Reservas De Hotel");
        Console.WriteLine();

        int noches = LeerEnteroPositivo("Ingrese la cantidad de noches: ");
        string tipoHabitacion = LeerOpcion("Ingrese el tipo de habitacion (sencilla, doble, suite): ", "sencilla", "doble", "suite");
        string tipoCliente = LeerOpcion("Ingrese el tipo de cliente (regular o vip): ", "regular", "vip");
        string temporada = LeerOpcion("Ingrese la temporada (baja o alta): ", "baja", "alta");

        string categoriaReserva = CalcularCategoriaReserva(noches, tipoHabitacion, tipoCliente);
        decimal costoBase = CalcularCostoBase(noches, costoDia);
        decimal costoAdicional = CalcularCostoAdicional(categoriaReserva, temporada);
        decimal total = CalcularTotal(costoBase, costoAdicional);
        string mensaje = CrearMensaje(categoriaReserva, costoAdicional);

        MostrarResultado(costoBase, categoriaReserva, costoAdicional, mensaje, total);

        Console.ReadKey();
    }

    /// Lee un numero entero positivo desde consola.
    static int LeerEnteroPositivo(string mensaje)
    {
        int numero;

        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
        {
            Console.WriteLine("Error: ingrese un numero mayor que cero.");
            Console.Write(mensaje);
        }

        return numero;
    }

    /// Lee una opcion de texto y valida que coincida con una de las opciones permitidas.
    static string LeerOpcion(string mensaje, string opcion1, string opcion2, string opcion3 = "")
    {
        string dato;

        Console.Write(mensaje);
        dato = NormalizarTexto(Console.ReadLine());

        while (dato != opcion1 && dato != opcion2 && dato != opcion3)
        {
            Console.WriteLine("Error: opcion no valida.");
            Console.Write(mensaje);
            dato = NormalizarTexto(Console.ReadLine());
        }

        return dato;
    }


    /// Quita espacios y convierte un texto a minusculas.
    static string NormalizarTexto(string texto)
    {
        if (texto == null)
        {
            return "";
        }

        return texto.Trim().ToLower();
    }

    /// Clasifica la reserva segun las noches, el tipo de habitacion y el tipo de cliente.
    static string CalcularCategoriaReserva(int noches, string tipoHabitacion, string tipoCliente)
    {
        if (tipoHabitacion == "suite" || noches >= 5)
        {
            return "Ejecutiva";
        }
        else if (tipoCliente == "vip" && noches >= 3)
        {
            return "Premium";
        }
        else
        {
            return "Economica";
        }
    }


    /// Calcula el valor de las noches en el hotel.
    static decimal CalcularCostoBase(int noches, decimal costoDia)
    {
        return noches * costoDia;
    }


    /// Calcula el costo adicional segun la categoria y la temporada.
    static decimal CalcularCostoAdicional(string categoriaReserva, string temporada)
    {
        decimal costoAdicional;

        if (categoriaReserva == "Ejecutiva")
        {
            costoAdicional = 120000;
        }
        else if (categoriaReserva == "Premium")
        {
            costoAdicional = 80000;
        }
        else
        {
            costoAdicional = 40000;
        }

        if (temporada == "alta")
        {
            costoAdicional = costoAdicional * 1.20m;
        }

        return costoAdicional;
    }


   /// Suma el costo base y el costo adicional.
    static decimal CalcularTotal(decimal costoBase, decimal costoAdicional)
    {
        return costoBase + costoAdicional;
    }


    /// Crea el mensaje final para el cliente.
    static string CrearMensaje(string categoriaReserva, decimal costoAdicional)
    {
        return "Su reserva ha sido clasificada como " + categoriaReserva +
               ". El costo adicional es de $" + costoAdicional + ".";
    }


    /// Muestra en consola el resultado final de la reserva.
    static void MostrarResultado(decimal costoBase, string categoriaReserva, decimal costoAdicional, string mensaje, decimal total)
    {
        Console.WriteLine();
        Console.WriteLine("Resultado final:");
        Console.WriteLine("Costo por dias en el hotel: $" + costoBase);
        Console.WriteLine("Categoria de reserva: " + categoriaReserva);
        Console.WriteLine("Costo adicional: $" + costoAdicional);
        Console.WriteLine("Mensaje: " + mensaje);
        Console.WriteLine("Total: $" + total);
    }
}
