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

    /// <summary>
    /// Lee un numero entero positivo desde consola.
    /// </summary>
    /// <param name="mensaje">Mensaje que se muestra para pedir el dato.</param>
    /// <returns>Numero entero mayor que cero.</returns>
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

    /// <summary>
    /// Lee una opcion de texto y valida que coincida con una de las opciones permitidas.
    /// </summary>
    /// <param name="mensaje">Mensaje que se muestra para pedir el dato.</param>
    /// <param name="opcion1">Primera opcion permitida.</param>
    /// <param name="opcion2">Segunda opcion permitida.</param>
    /// <param name="opcion3">Tercera opcion permitida, si aplica.</param>
    /// <returns>Texto validado en minusculas.</returns>
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

    /// <summary>
    /// Quita espacios y convierte un texto a minusculas.
    /// </summary>
    /// <param name="texto">Texto escrito por el usuario.</param>
    /// <returns>Texto limpio para comparar.</returns>
    static string NormalizarTexto(string texto)
    {
        if (texto == null)
        {
            return "";
        }

        return texto.Trim().ToLower();
    }

    /// <summary>
    /// Clasifica la reserva segun las noches, el tipo de habitacion y el tipo de cliente.
    /// </summary>
    /// <param name="noches">Cantidad de noches de la reserva.</param>
    /// <param name="tipoHabitacion">Tipo de habitacion: sencilla, doble o suite.</param>
    /// <param name="tipoCliente">Tipo de cliente: regular o vip.</param>
    /// <returns>Categoria de la reserva: Ejecutiva, Premium o Economica.</returns>
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

    /// <summary>
    /// Calcula el valor de las noches en el hotel.
    /// </summary>
    /// <param name="noches">Cantidad de noches reservadas.</param>
    /// <param name="costoDia">Valor de un dia o noche en el hotel.</param>
    /// <returns>Costo base de la estadia.</returns>
    static decimal CalcularCostoBase(int noches, decimal costoDia)
    {
        return noches * costoDia;
    }

    /// <summary>
    /// Calcula el costo adicional segun la categoria y la temporada.
    /// </summary>
    /// <param name="categoriaReserva">Categoria calculada para la reserva.</param>
    /// <param name="temporada">Temporada baja o alta.</param>
    /// <returns>Costo adicional final.</returns>
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

    /// <summary>
    /// Suma el costo base y el costo adicional.
    /// </summary>
    /// <param name="costoBase">Costo por las noches en el hotel.</param>
    /// <param name="costoAdicional">Costo extra por categoria y temporada.</param>
    /// <returns>Total que debe pagar el cliente.</returns>
    static decimal CalcularTotal(decimal costoBase, decimal costoAdicional)
    {
        return costoBase + costoAdicional;
    }

    /// <summary>
    /// Crea el mensaje final para el cliente.
    /// </summary>
    /// <param name="categoriaReserva">Categoria asignada a la reserva.</param>
    /// <param name="costoAdicional">Costo adicional calculado.</param>
    /// <returns>Mensaje con la clasificacion y el costo adicional.</returns>
    static string CrearMensaje(string categoriaReserva, decimal costoAdicional)
    {
        return "Su reserva ha sido clasificada como " + categoriaReserva +
               ". El costo adicional es de $" + costoAdicional + ".";
    }

    /// <summary>
    /// Muestra en consola el resultado final de la reserva.
    /// </summary>
    /// <param name="costoBase">Costo por dias en el hotel.</param>
    /// <param name="categoriaReserva">Categoria final de la reserva.</param>
    /// <param name="costoAdicional">Costo adicional final.</param>
    /// <param name="mensaje">Mensaje para el cliente.</param>
    /// <param name="total">Total a pagar.</param>
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
