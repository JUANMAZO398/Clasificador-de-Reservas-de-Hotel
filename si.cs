using System;

    class Program
    {
        static void Main(string[] args)
        {
			int costodia = 20000;
            // Entradas
            Console.Write("Ingrese la cantidad de noches: ");
            int noches = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el tipo de habitación (sencilla, doble, suite): ");
            string tipoHabitacion = Console.ReadLine().ToLower();

            Console.Write("Ingrese el tipo de cliente (regular o vip): ");
            string tipoCliente = Console.ReadLine().ToLower();

            Console.Write("Ingrese la temporada (baja o alta): ");
            string temporada = Console.ReadLine().ToLower();

            // Variables de salida
            string categoriaReserva;
            decimal costoAdicional = 0;
            string mensaje;

            // Proceso - reglas de negocio
            if (tipoHabitacion == "suite" || noches >= 5)
            {
                categoriaReserva = "Ejecutiva";
                costoAdicional = 120000;
            }
            else if (tipoCliente == "vip" && noches >= 3)
            {
                categoriaReserva = "Premium";
                costoAdicional = 80000;
            }
            else
            {
                categoriaReserva = "Económica";
                costoAdicional = 40000;
            }

            // Recargo por temporada alta
            if (temporada == "alta")
            {
                costoAdicional *= 1.20m;
            }

            // Mensaje para el cliente
            mensaje = $"Su reserva ha sido clasificada como {categoriaReserva}. " +
                      $"El costo adicional es de ${costoAdicional}.";

            // Salidas
            Console.WriteLine("\n--- RESULTADO ---");
			Console.WriteLine($"costo por días en el hotel: {costodia * noches}");
            Console.WriteLine("Categoría de reserva: " + categoriaReserva);
            Console.WriteLine("Costo adicional: $" + costoAdicional);
            Console.WriteLine("Mensaje: " + mensaje);
			Console.WriteLine($"total: {costodia * noches + costoAdicional}");

            Console.ReadKey();
        }
}