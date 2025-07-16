# Importar Modelos a Unity (FBX)
1. Cuenta en Mixamo
2. Elegir modelo > Download > Format: FBX for Unity > T-pose
3. Once downloaded drag it into a folder in Unity

## Configuraciones de Unity
Consideraciones generales: Asegurarse de que la escala del modelo corresponda con la de Unity. Unity por default trabaja con metros, Maya con centímetros. Unity convierte cualquier modelo a centímetros, por lo que si un modelo tiene escala de centímetros será milimetrico en Unity.

### Inspector
#### Model
1. Scale factor & Convert Units: Activado por default. DESACTIVAR si el modelo fue hecho en centímetros.
2. Bake Axis Conversion: _solo activar si_ hay rigging de la cara, o físicas de estiramiento de la ropa.
3. Import Blend Shapes: OFF. Tick OFF Import Camera and Lights.
4. Mesh Compression: OFF, unless the engine really is suffering.

#### Rig
1. Animation Type:
  - Generic: Humano basico, creaturas con movimiento limitado, vehiculos, cuadrupedos, objetos con torque.
  - Humanoid: Herencia de animaciones.

#### Material
1. Material Creation Mode: Standard permite los reflejos de las luces.
2. Import Textures
3. Import Materials.
Esto permite hacer modificaciones a las texturas y los UVs.

## Adding Animations
1. Seleccionar una animación de Mixamo
2. Download > Without Skin > Select fps.
3. Drag and drop file to an Animations folder in Unity.

### Inspector
En el asset de la animación:
#### Rig
1. Animation Type: Humanoid (o Generic si el modelo lo requiere).

#### Animation
Después de que se ha creado el Rig, **activar**:
- Loop time
- Root Transform Rotation > Bake Into Pose. 
- Root Tranform Position Y > Bake Into Pose.
- Root Transform Position XZ > Bake Into Pose.
Click **Apply**.

**Nota:**
Bake Into Pose es utilizado cuando las animaciones serán llamadas por medio de un código, no cuando estarán reproduciendose constantemente. Un ejemplo de cuando Bake Into Pose **NO** es necesario, es Subway Surfers pues en este caso la animación siempre se está reproduciendo, el código solo cambia la posición en que se encuentra en XYZ. 

## Animation Controller
1. Crear nueva carpeta para Animation Controllers.
2. Create > Animation Controller
3. En el objeto de modelo (el objeto que aparece en _Hierarchy_) > Inspector > Animator > Controller > **Asignar el Controller que se creó específicamente para esta animación**.
4. Double clic on the Controller (open it) > Drag and drop the animation into the diagram
5. Todas las animaciones deben ser asignadas al mismo Controller.

Para revisar las animaciones:
- Acomodar la vista del Scene a como queremos ver el personaje en Play Test Mode.
- Seleccionar Camara > Ctrl + Shift + F (sets Main Camera en la misma posición que la vista que tenemos en Scene).
- Enter Play Test Mode to see the animations.

### Crear Transiciones
1. Una vez que todas las animaciones fueron agregadas al Animation Controller, seleccionar la Animación inicial o base Layer (por ejemplo, Idle) > clic derecho > Make Transition.
  - Por ejemplo, Idle -> Walk -> Run.
2. Repetir este proceso, pero de regreso, de modo que las Transiciones puedan suceder en ambos sentidos.
  - Por ejemplo, Idle <- Walk <- Run.
3. Animator > Parameters > Create New > Float.
Este parametro servirá para crear una base bajo la cual el código podrá saber cúando iniciar cada animación.
- Por ejemplo: velocity == 0.
4. Click on the Transition arrows between the transitions.
5. Check _OFF_ Has Exit Time.
6. Conditions > Add New > velocity.
Al ser una variable tipo Float, este parametro se maneja en comparativas. Con este proceso, las transiciones se harán basadas en el valor que esté asignado al parámetro (en este ejemplo, _velocity_).
  - Por ejemplo:
      - Idle -> Walk: velocity _Greater than_ 0.1.
      - Idle <- Walk: celovity _Less than_ 0.1.
      - Walk -> Run: velocity _Greater than_ 1.
      - Walk <- Run: velocity _LESS than_ 1.


