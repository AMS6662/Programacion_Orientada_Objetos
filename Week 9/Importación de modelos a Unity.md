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
1. Import Textures
2. Import Materials.
Esto permite hacer modificaciones a las texturas y los UVs.
