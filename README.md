Clasificador de Reservas de Hotel
Descripción

Este proyecto implementa un sistema en C# que clasifica reservas de un hotel y calcula el costo adicional según la duración de la estadía, el tipo de cliente, la temporada y el tipo de habitación seleccionada.

Entradas

Cantidad de noches

Tipo de habitación (sencilla, doble o suite)

Tipo de cliente (regular o VIP)

Temporada (baja o alta)

Proceso

El sistema evalúa un conjunto de reglas de negocio para asignar la categoría de la reserva (económica, premium o ejecutiva) y calcula un recargo adicional si la reserva se realiza en temporada alta.

Salidas

Categoría de reserva

Costo adicional

Mensaje para el cliente

Reglas

Reserva premium si el cliente es VIP y se hospeda 3 o más noches.

Reserva ejecutiva si la habitación es suite o la estadía es de 5 o más noches.

Reserva económica en los demás casos.

Recargo adicional del 20% si la temporada es alta.
| Variable         | Tipo de dato | Descripción                           |
| ---------------- | ------------ | ------------------------------------- |
| noches           | int          | Número de noches reservadas           |
| tipoHabitacion   | string       | Tipo de habitación elegida            |
| tipoCliente      | string       | Indica si el cliente es regular o VIP |
| temporada        | string       | Temporada de la reserva               |
| categoriaReserva | string       | Categoría asignada a la reserva       |
| costoAdicional   | decimal      | Valor adicional calculado             |
| mensaje          | string       | Mensaje informativo para el cliente   |
