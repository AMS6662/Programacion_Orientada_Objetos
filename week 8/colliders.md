# Collisions
## Fundamentos de la Interacción en Unity: Colisiones y Triggers
Los _Colliders_ y _Rigidbody_ son la base del sistema de físicas en Unity.

### Collider
- Es lo que define la forma física de un objeto para el motor de físicas.
- Es un objeto invisible.
- No tiene porqué coincidir con la malla del objeto, es más común utilizar BoxCollider, SphereCollider o CapsuleCollider. Una malla exacta solo se utiliza si se requiere precisión pero es costoso.

### Rigidbody: Motor de interacción
- Es el componente que le dice a Unity "este objeto debe ser controlado por el motor de físicas". Es el cerebro de la operación física.
- Agregar un _Rigidbody_ a un _GameObject_ es como suscribirlo al ciclo de físicas de Unity. En cada _FixedUpdate_ el motor comprueba continuamente sus interacciones dinámicas. 
- Sin un Rigidbody en al menos uno de los objetos que interactuan, los _OnCollision_ y la mayoría de los _OnTrigger_ no funcionarán.

#### Clasificación de Cuerpos Físicos
Su configuración determina su tipo y comportamiento. Existen tres categorías principales:
1. **Static Collider:** GameObject + Collider.
   Son objetos inamovibles (del escenario) como el suelo, paredes, edificios, etc. Los Rigidbody _dinámicos_ pueden chocar contra ellos pero estos no se moverán.
3. **Dynamic Rigidbody Collider:** GameObject + Collider + Rigidbody + SIN is Kinematic.
   Están completamente bajo el control de físicas de Unity. Responden a fuerzas, gravedad, choques y rebotes. Se usan en objetos como pelotas, proyectiles, o escombros.
5. **Kinematic Rigidbody Collider:** GameObject + Collider + Rigidbody + IS Kinematic.
   No son afectados por fuerzas externas como gravedad o colisiones. Pueden moverse modificando su transform a través de un script. Se usan en personajes controlados por el jugador, puertas, plataformas, etc. con los que se interactuan (como empujar o activar triggers). 

Para diagnosticar porqué las colisiones no funcionan, se´puede utilizar la siguiente tabla:

| Item | Static Collider | Dynamic Rigidbody | Kinematic Rigidbody | Static Trigger | Dynamic Trigger | Kynematic Trigger |
|------| --------------- | ----------------- | ------------------- | -------------- | --------------- | ----------------- |
| Static Collider | - | Collision | - | - | Trigger | Trigger|
| Dynamic | Collision | Collision | Collision | Trigger | Trigger | Trigger |
|Kinematic Rigidbody | - | Collision | - | Trigger | Trigger | Trigger|
|Static Trigger | - | Trigger | Trigger | - | Trigger | Trigger|
| Dynamic Trigger | Trigger | Trigger | Trigger| Trigger | Trigger | Trigger| 
| Kinematic Trigger | Trigger | Trigger | Trigger | Trigger | Trigger| Trigger|

### La Bifurcación Fundamental: Eventos de Colisión vs. Eventos de Trigger
En cada collider se puede marcar activa una casilla _Is Trigger_. IS TRIGGER, es la forma más optimizada de realizar comprobaciones de proximidad. Al marcarla activa, el Collider pasa de ser una barrera física a ser un volumen de detección, que divide todas las interacciones físicas en dos categorías:
1. **Colisiones (Is Trigger = False):** El Collider actúa como un objeto que tiene presencia física en el mundo. Las interacciones son basadas en las fuerzas como una bala que choca con una pared o un personaje que camina sobre el suelo.
2. **Colisiones (Is Trigger = TRUE):** El collider se convierte en un "fantasma", ya no impide el paso de otros Colliders. Ahora, su propósito solo es _detectar cuando otros colliders entran, permanecen, o salen de su volumen._

### Los Seis Eventos de Físicas
Existen seis metodos de mensaje principales divididos en dos grupos.
 #### Grupo 1: Eventos de Colisión (Física Real) (is trigger OFF, (Collision collisionInfo))
 Sucede cuando dos Colliders con _Is Trigger DESACTIVADO_ interactúan, y al menos uno de ellos tiene un Rigidbody *dinámico*.
 - **OnCollisionEnter:** Contiene info detallada sobre el choque como puntos de contacto exactos, velocidad relativa del impacto, referencias directas al otro GameObject, Collider y Rigidbody involucrados.
      - _Usos típicos_: Aplicar daño instantaneo por impacto, reproducir sonido de choque, crear un efecto de partículas en el punto de colisión-
- **OnCollisionStay:** Invoca un ciclo de FixedUpdate mientras los dos Colliders estén en contacto.
     - _Usos típicos:_ Aplicar una fuerza de fricción, simular que un objeto está siendo
aplastado por otro, empujar un objeto móvil.
- **OnCollisionExit:** Se invoca una única vez en el frame en que los colliders dejan de tocarse. Marca el final de la interacción física.
     - _Usos típicos:_ Dejar de aplicar un efecto de fricción, cambiar el estado de un
personaje (por ejemplo, de "en el suelo" a "en el aire" cuando salta), restablecer
una variable.

#### Grupo 2: Eventos de TRigger (Detección de zona) (is TRigger ON, (Collider other))
Suceden cuando el Collider entra en contacto con un Collider con _is Trigger ACTIVADO_. Al menos uno de los objetos debe tener un _Rigidbody_.
- **OnTriggerEnter:** Se invoca una unica vez en el momento en que un Collider entra en el volumen del trigger. El parametro _Other_ es una referencia simple y directa al Collider del objeto que ha entrado.
     - _Usos típicos:_ Recoger un item, activar una puerta, iniciar un diálogo o misión entrar en una zona que cambia la música de fondo.
- **OnTriggerSTay:** Se invoca en cada ciclo de FixedUpdate  mientras un
Collider permanezca dentro del volumen del trigger. Es la base para efectos que duran
mientras el jugador está en una zona específica.
○ Usos Típicos: Aplicar daño por segundo en una zona de veneno o lava, curar
gradualmente en un área sagrada, hacer que un objeto levite mientras está sobre
una plataforma de energía.
● OnTriggerExit(Collider other): Se invoca una única vez, en el momento en que el Collider
sale del volumen del trigger.
○ Usos Típicos: Desactivar la puerta automática, detener e
