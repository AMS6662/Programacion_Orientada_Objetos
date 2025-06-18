# Hay 4 pilares de la Programación Orientada a Objetos

## Abstracción
Es la característica de reducir la complejidad y permitir un diseño e implementación que sean más eficientes en sistemas de software complejos.
## Herencia
Todos los objetos absorven capacidades de sus padres
## Encapsulamiento
Habilidad de los objetos de absorver atributos sin que nadie más pueda observarlos.
## Polimorfismo
Se espera que al tener una copia del código se puedan alterar los datos sin perder la estructura de este. 
Permite que se puedan crear muchas formas o iteraciones del código o su comportamientos. 

## Ejemplo
- Abstracción
La clase es _Tamal_.
Su comportamiento es:
Ser comido
Sus características son:
1. Textura.
2. Masa.
3. Color.
4. Ingredientes.

- Herencia
Todos los objetos tipo _tamal_ tendrán las mismas características y comportamientos de estos.
Aunque son diferentes tipos de tamales, heredan las características del tamal:
1. Tamal de dulce
2. Tamal de rajas.

- Encapsulamiento
Su comportamiento es _seCome()_. Este comportamiento es algo que sucede, pero quien lo come no tiene porqué saber cómo se hace. o de qué está hecho.

- Polimorfismo
Pueden existir diferentes formas de comer el tamal, o en el que el comprtamiento _seCome()_ puede ser realizado, sin que el código original sea necesariamente eliminado.
_seCome()_:
1. En torta
2. Frito
3. Ahogado
4. Solo
