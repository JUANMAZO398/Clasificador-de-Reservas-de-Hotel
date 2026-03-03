Leyder Mosquera 
Juan Mazo

Clasificador de Reservas de Hotel con Cálculo de Costo Total
Descripción

Este proyecto clasifica las reservas de un hotel y calcula el costo total de la estadía, teniendo en cuenta la cantidad de noches, el tipo de habitación, el tipo de cliente, la temporada y un costo fijo por día de hospedaje.
El sistema aplica reglas de negocio para asignar la categoría de la reserva y determinar costos adicionales, mostrando al cliente un resumen completo del valor a pagar.

Entradas

Cantidad de noches

Tipo de habitación (sencilla, doble o suite)

Tipo de cliente (regular o VIP)

Temporada (baja o alta)

Proceso

El sistema evalúa las condiciones de la reserva para asignar una categoría (económica, premium o ejecutiva).
Luego calcula un costo adicional según la categoría asignada y aplica un recargo si la reserva se realiza en temporada alta.
Finalmente, se calcula el costo por días de hospedaje y el total a pagar por la reserva.

Salidas

Categoría de la reserva

Costo por días de hospedaje

Costo adicional

Costo total

Mensaje informativo para el cliente

Reglas

La reserva es ejecutiva si la habitación es suite o la estadía es de 5 o más noches.

La reserva es premium si el cliente es VIP y se hospeda 3 o más noches.

La reserva es económica en los demás casos.

Se aplica un 20% de recargo al costo adicional si la temporada es alta.

El costo por día de hospedaje es fijo y se multiplica por la cantidad de noches.

| Variable         | Tipo de dato | Descripción                                    |
| ---------------- | ------------ | ---------------------------------------------- |
| costodia         | int          | Costo fijo por día de hospedaje                |
| noches           | int          | Número de noches reservadas                    |
| tipoHabitacion   | string       | Tipo de habitación seleccionada                |
| tipoCliente      | string       | Indica si el cliente es regular o VIP          |
| temporada        | string       | Temporada en la que se realiza la reserva      |
| categoriaReserva | string       | Categoría asignada a la reserva                |
| costoAdicional   | decimal      | Costo adicional según la categoría y temporada |
| mensaje          | string       | Mensaje informativo para el cliente            |
| total            | decimal      | Valor total a pagar por la reserva             |
