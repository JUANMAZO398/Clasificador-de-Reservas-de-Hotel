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

## Como ejecutar


El programa pide:

- Cantidad de noches.
- Tipo de habitacion: `sencilla`, `doble` o `suite`.
- Tipo de cliente: `regular` o `vip`.
- Temporada: `baja` o `alta`.

## Organizacion del codigo

| Funcion | Que hace |
| --- | --- |
| `Main` | Coordina el programa: pide datos, llama calculos y muestra resultado. |
| `LeerEnteroPositivo` | Valida que las noches sean mayores que cero. |
| `LeerOpcion` | Valida opciones como habitacion, cliente y temporada. |
| `NormalizarTexto` | Convierte el texto a minusculas y quita espacios. |
| `CalcularCategoriaReserva` | Decide si la reserva es Ejecutiva, Premium o Economica. |
| `CalcularCostoBase` | Multiplica noches por costo diario. |
| `CalcularCostoAdicional` | Calcula el adicional y aplica recargo del 20% en temporada alta. |
| `CalcularTotal` | Suma costo base y costo adicional. |
| `CrearMensaje` | Arma el mensaje para el cliente. |
| `MostrarResultado` | Imprime el resultado en consola. |

## Reglas usadas

- Suite o 5 noches o mas: categoria `Ejecutiva`, adicional `$120000`.
- Cliente vip con 3 noches o mas: categoria `Premium`, adicional `$80000`.
- Los demas casos: categoria `Economica`, adicional `$40000`.
- Temporada alta aumenta el adicional en 20%.
- El costo por dia es `$20000`.

## Cambios realizados y justificacion

El codigo original estaba completo dentro de `Main`. El cambio principal fue dividirlo en funciones para que cada parte tenga una responsabilidad clara.

| Cambio | Por que fue adecuado |
| --- | --- |
| Se creo `LeerEnteroPositivo` | Evita que el programa acepte noches negativas, cero o textos que causen error. |
| Se creo `LeerOpcion` | Permite validar habitacion, cliente y temporada sin repetir mucho codigo. |
| Se creo `NormalizarTexto` | Permite aceptar respuestas con mayusculas o espacios, por ejemplo ` VIP ` o `Alta`. |
| Se separo `CalcularCategoriaReserva` | La regla para decidir la categoria queda aislada y facil de explicar. |
| Se separo `CalcularCostoBase` | El calculo de noches por costo diario queda independiente. |
| Se separo `CalcularCostoAdicional` | El adicional por categoria y el recargo de temporada alta quedan en una sola funcion. |
| Se creo `CalcularTotal` | El total se calcula en una funcion simple y reutilizable. |
| Se creo `CrearMensaje` | El mensaje final no queda mezclado con los calculos. |
| Se creo `MostrarResultado` | La salida por consola queda separada de la logica de calculo. |

Estos cambios son adecuados porque `Main` queda mas ordenado y solo coordina el programa. Ademas, las funciones de calculo no leen datos ni imprimen mensajes, solo reciben parametros y retornan resultados.

## Casos de prueba

| Noches | Habitacion | Cliente | Temporada | Categoria | Total |
| --- | --- | --- | --- | --- | ---: |
| 2 | sencilla | regular | baja | Economica | $80000 |
| 3 | doble | vip | baja | Premium | $140000 |
| 5 | sencilla | regular | alta | Ejecutiva | $244000 |
| 1 | suite | regular | alta | Ejecutiva | $164000 |
