# Trabajar con modelos que no fueron creados en Unity

## Reconfigurar el pivote
Cuando se importan objetos de softwares de modelado, o de librerías de assets, a veces los pivotes están mal centrados. Para arreglar eso:
1. Create empty game object
2. Abrirlo/sleccionarlo
3. Reestablecer su posición a 0,0,0.
4. Arrastrar el objeto que se va a mostrar en escena para que sea emparentado por el Empty Object.


## Arreglar texturas
### Objetos grises
Cuando los objetos aparecen como mallas grises, sin texturas, se reconfiguran así:
1. Crear nueva textura
2. Asignar la textura al objeto
3. Asignar el png o jpg al material. Surface inputs > Base Map

### Objetos rosas
Normalmente cuando los objetos aparecen rosas es porque Unity está trabajando con un renderizador viejo, es decir, Built-In. Los rednerizadores nuevos son Universal 2D y Universal 3D. 

#### Forma automatica
1. Edit > Project Settings > Graphics > Scriptable Render Pipeline Settings > Make sure its not empty (usually select URP)
2. Seleccionart material > Edit > Rendering > Materials > Convert Selected Materials to URP

#### Forma manual
Si esto no funciona:
1. Material > Shader > Universal Render > Lit > Agregar Textura en Base Map
