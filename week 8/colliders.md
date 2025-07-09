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
3. **Dynamic Rigidbody Collider:** GameObject + Collider + Rigidbody + SIN Kinematic.
   Están completamente bajo el control de físicas de Unity. Responden a fuerzas, gravedad, choques y rebotes. Se usan en objetos como pelotas, proyectiles, o escombros.
5. **Kinematic Rigidbody Collider:** GameObject + Collider + Rigidbody + IS Kinematic.
   No son afectados por fuerzas externas como gravedad o colisiones. Pueden moverse modificando su transform a través de un script. Se usan en personajes controlados por el jugador, puertas, plataformas, etc. con los que se interactuan (como empujar o activar triggers). 

Para diagnosticar porqué las colisiones no funcionan, se´puede utilizar la siguiente tabla:

| Item | Static Collider | Dynamic Rigidbody | Kinematic Rigidbody | Static Trigger | Dynamic Trigger | Kynematic Trigger |
|------| --------------- | ----------------- | ------------------- | -------------- | --------------- | ----------------- |
| Static Collider | - | Collision | - | - | Trigger | Trigger|
| Dynamic | Collision | Collision | Collision | Trigger | Trigger | Trigger |
Kinematic Rigidbody | - | Collision | - | Trigger | Trigger | Trigger|
