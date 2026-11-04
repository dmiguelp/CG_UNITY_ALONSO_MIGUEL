# CG_UNITY_ALONSO_MIGUEL


Observa y explora La Cantera y el puente de Álcantara en un vasto mundo lleno de vegetación. Controlas a un personaje en tercera persona con el que podrás observar a otra gente deambulando por el paisaje. AParca tu coche en la zona de parking o ve directamente a La Cantera y comienza a explorar!

Proyecto de Unity para la construcción de un entorno 3D explorable con estética
low-poly combinado con assets de más alta definición. El escenario combina la zona natural de **La Cantera**, una piscina
natural, el **Puente de Alcántara**, una zona de parking y una zona elevada con
vegetación, vehículos, un personaje jugable con cámara en tercera persona al hombro y NPCs controlados por IA (navegación autónoma por destinos aleatorios).


![Localización de la escena](media/Captura%20de%20pantalla%202026-11-04%20131957.png)

Localización de la escena.

> **Estado documentado:** 4 de noviembre de 2026. Este documento describe lo
> que está serializado en el repositorio, no una funcionalidad hipotética o
> pendiente de implementar.

## Resumen del trabajo realizado

La evolución registrada en Git muestra las siguientes fases:

1. Creación del proyecto Unity y configuración inicial.
2. Incorporación del terreno, el skybox y un personaje base.
3. Creación de la piscina natural de La Cantera mediante el sistema de agua.
4. Incorporación de un avatar de Mixamo con cámara de seguimiento.
5. Integración de animaciones de idle, caminar y correr; el salto conserva la
   animación por defecto.
6. Construcción progresiva del Puente de Alcántara con piezas modulares,
   columnas, muros y detalles de entorno.
7. Añadido de NPCs en la zona de La Cantera y en el parking del puente.
8. Implementación de movimiento autónomo de NPC mediante `NavMeshAgent`,
   destinos aleatorios y sincronización básica con el `Animator`.
9. Añadido de detalles de la zona elevada de La Cantera, como vallas,
   vegetación, rocas, bancos, farolas, vehículos y elementos urbanos.

Los commits que reflejan este proceso son:

| Commit | Descripción |
| --- | --- |
| `b6e9be7` | Primer commit del proyecto Unity |
| `ed7b9af` | Terreno, skybox y personaje iniciales |
| `c3bd59f` | Piscina natural de La Cantera |
| `b201f0f` | Avatar de Mixamo, cámara y animaciones |
| `3439693` | Construcción del Puente de Alcántara |
| `e25c2ba` | Detalles del puente y NPCs con IA |
| `51a39df` | Detalles de la zona elevada de La Cantera |

## Cómo abrir el proyecto

### Requisitos

- Unity **6000.6.4f1**.
- Módulo de plataforma necesario si se desea generar una build (por ejemplo,
  WebGL).
- Sistema operativo compatible con la versión de Unity instalada.

### Pasos

1. Clonar el repositorio.
2. Abrir la carpeta raíz desde Unity Hub.
3. Seleccionar Unity `6000.6.4f1` si Unity Hub solicita una versión.
4. Abrir la escena principal:
   `Assets/Scenes/SampleScene.unity`.
5. Pulsar **Play**.

La escena de trabajo no es actualmente la primera escena de Build Settings:
`ProjectSettings/EditorBuildSettings.asset` referencia
`Assets/_GetStartedWithShaderGraph/Scenes/Sample_Scene.unity`, una escena de
ejemplo del paquete Shader Graph. Para ejecutar el escenario de este proyecto
desde una build, hay que añadir o sustituir esa entrada por
`Assets/Scenes/SampleScene.unity`.

## Escena principal: `SampleScene`

La escena contiene **97 instancias de prefabs** y **19 GameObjects creados
directamente en la escena**. Los nombres con sufijos `(1)`, `(2)`, etc. son
duplicados de una misma familia de prefab.

### GameObjects directos de la escena

| GameObject | Función / componentes relevantes |
| --- | --- |
| `Terrain` | Terreno principal, `Terrain` y `TerrainCollider`; usa datos de terreno y árboles/detalles |
| `Directional Light` | Luz direccional principal; intensidad 5.3 y sombras |
| `Global Volume` | Volumen global URP con el perfil `DefaultVolumeProfile` |
| `NavMeshZone` | `NavMeshSurface` para la zona general de navegación |
| `NavMeshZone_parking` | `NavMeshSurface` para la zona del parking |
| `RoamCenter` | Punto de referencia para el movimiento aleatorio de NPCs |
| `RoamCenter_parking` | Punto de referencia de movimiento del parking |
| `DestinoNPC` | Punto preparado como destino explícito de NPC (auxiliar no utilizado en la escena) |



### Instancias de prefabs de la escena

Este es el inventario completo por familia y cantidad:

| Familia de GameObject | Cantidad | Uso |
| --- | ---: | --- |
| `bridge_01_piece_01` | 8 | Piezas modulares del tablero/estructura del puente |
| `bridge_01_piece_03` | 12 | Piezas modulares del puente |
| `bridge_01_piece_04` | 24 | Piezas repetidas del puente y sus detalles |
| `bridge_wall_01` | 2 | Muros laterales o elementos de contención del puente |
| `WaterBlock_50m` | 4 | Superficie de agua de la piscina natural |
| `Natures_Rock_Big` | 3 | Rocas grandes de ambientación |
| `Natures_Big Tree` | 1 | Árbol grande |
| `PT_Modular_Fence_Wood_01` | 11 | Vallas de madera de la zona elevada |
| `Props_Bench_1` | 7 | Bancos del entorno |
| `Props_Street Light` | 3 | Farolas |
| `Props_BillBoard_small` | 1 | Cartel publicitario pequeño |
| `Props_Dustbin` | 1 | Papelera |
| `Vehicle_Bus_color02` | 2 | Autobuses |
| `Vehicle_Car_color01` | 2 | Coches |
| `Vehicle_Car_color02_separate` | 2 | Coches separados |
| `Vehicle_Car_color03` | 2 | Coches |
| `Vehicle_Taxi` | 1 | Taxi |
| `NPC_01` | 6 | Personajes no jugables |
| `MainCamera` | 1 | Cámara incluida en el conjunto de personaje |
| `PlayerArmature` | 1 | Armadura/controlador del jugador |
| `PlayerFollowCamera` | 1 | Cámara que sigue al jugador |
| `Cube` | 2 | Prefab de cubo auxiliar |

### NPCs y navegación

Los seis `NPC_01` tienen componentes añadidos en la escena:

- `NPCMover`.
- `NavMeshAgent`.
- `Animator` y controlador de animación.

`NPCMover` funciona así:

- Si se asigna `target`, el NPC intenta desplazarse a ese `Transform`.
- Si no hay destino, busca un punto aleatorio alrededor de `roamCenter`.
- El radio de deambulación serializado en la escena es de **20 unidades**.
- Espera **2 segundos** al llegar antes de elegir otro destino.
- Hace hasta **30 intentos** para encontrar un punto válido mediante
  `NavMesh.SamplePosition`.
- Comprueba que el agente esté sobre un NavMesh y registra un error explícito si
  no lo está.
- Desactiva root motion y fija la velocidad de animación en `0.75`.
- Actualiza, cuando existen, los parámetros `Speed`, `MotionSpeed`, `Grounded`
  y `FreeFall`.

El escenario dispone de dos superficies de navegación:

- `NavMeshZone`: zona general.
- `NavMeshZone_parking`: navegación específica del parking.

Los datos horneados se encuentran en:

- `Assets/Scenes/SampleScene/NavMesh-NavMeshZone.asset`
- `Assets/Scenes/SampleScene/NavMesh-NavMeshZone_parking.asset`

## Jugador, avatar y animaciones

El personaje principal procede de Mixamo y se organiza en:

- `Assets/Scenes/_MisCosas/Personajes/Remy.fbx`
- `Assets/Scenes/_MisCosas/Personajes/Remy@Idle.fbx`
- `Assets/Scenes/_MisCosas/Personajes/Remy@Walking.fbx`
- `Assets/Scenes/_MisCosas/Personajes/Remy@Running.fbx`
- `Assets/Scenes/_MisCosas/Personajes/Remy@Jump.fbx`
- `Assets/Scenes/_MisCosas/Prefabs/Remy.prefab`
- `Assets/Scenes/_MisCosas/Prefabs/PlayerArmature (1).prefab`

El avatar incluye jerarquía humanoide, huesos Mixamo, geometría corporal,
ropa, pelo, ojos y zapatos.

La cámara de seguimiento está representada por `PlayerFollowCamera` y el
`PlayerArmature` contiene el `PlayerCameraRoot` utilizado por el controlador de
tercera persona.

## Scripts propios

### `NPCMover.cs`

Script de comportamiento autónomo de NPC descrito en la sección de navegación.
Usa `UnityEngine.AI`, valida dependencias y comunica errores mediante
`Debug.LogError`. Los NPCs reutilizan animaciones del avatar Remy.


## Prefabs propios y materiales

En `Assets/Scenes/_MisCosas/` se encuentran los recursos organizados por
función:

| Ruta | Contenido |
| --- | --- |
| `Prefabs/Remy.prefab` | Personaje humanoide con mallas y animaciones |
| `Prefabs/PlayerArmature (1).prefab` | Armadura/controlador del jugador |
| `Prefabs/Columnas.prefab` | Columnas para la construcción del puente |
| `Prefabs/bridge_01_piece_04.prefab` | Pieza de puente reutilizable |
| `Prefabs/bridge_01_piece_04 (1).prefab` | Variante duplicada de la pieza |
| `Cube.prefab` | Prefab auxiliar con cubo y componentes físicos |


## Input System

El proyecto utiliza el paquete nuevo **Input System** y el asset
`Assets/InputSystem_Actions.inputactions`. El mapa de acciones del jugador
contiene:

| Acción | Teclado 
| --- | --- 
| `Moverse` | WASD / flechas 
| `Mirar` | Ratón | 
| `Saltar` | Espacio | 
| `Correr` | Shift


`Moverse` tiene bindings para mando, WASD y flechas.

## Renderizado, iluminación y ambiente

- Render Pipeline: **Universal Render Pipeline (URP)**.
- Versión de Unity: **6000.6.4f1**.
- Paquete URP: **17.6.0**.
- Skybox configurado en `SampleScene`.
- Fog activada con densidad `0.01` y distancia lineal hasta `300`.
- Gamma del skybox modificado para dar una sensación cálida de atardecer.
- Luz direccional con sombras.
- `Global Volume` activo y perfil global URP.
- Materiales de agua procedentes de `IgniteCoders/Simple Water Shader`.
- Materiales y texturas de terreno procedentes de los recursos importados.
- Hay perfiles separados para PC y móvil en `Assets/Settings/`.

## Paquetes relevantes

El `Packages/manifest.json` incluye, entre otros:

- `com.unity.ai.navigation` `2.0.14`: NavMesh y navegación de NPC.
- `com.unity.cinemachine` `6.6.0`: cámaras.
- `com.unity.inputsystem` `1.20.0`: entrada moderna.
- `com.unity.render-pipelines.universal` `17.6.0`: renderizado URP.
- `com.unity.timeline` `6.6.0`: secuencias.
- `com.unity.ugui` `2.6.0`: UI.
- `com.unity.visualscripting` `1.9.12`: grafos visuales.
- `com.unity.shadergraph`: recursos de Shader Graph incluidos en el proyecto.
- Módulos de terreno, física, animación, audio, vídeo, partículas y XR.

El repositorio también contiene recursos de terceros/importados, entre ellos Polytope Studio (asset principal para árboles, detalles del terrain, etc.), 
AllSkyFree (skybox), Simple Water Shader (dentro de IgniteCoders para el agua), Modular Fantasy Bridges (para el puente), SimplePoly City (elementos decorativos de ciudad: coches, sillas, carteles, luces, etc.),
YughuesFreePavementsMaterials (pavimentos diferentes para el terreno), Adobe Substance 3D y Starter Assets. Estos
recursos aportan modelos, materiales, shaders, escenas de demostración y
herramientas; no todos forman parte de la escena principal.

## Estructura importante del repositorio

```text
Assets/
├── Scenes/
│   ├── SampleScene.unity
│   └── _MisCosas/
│       ├── Materials/
│       ├── Personajes/
│       ├── Prefabs/
│       ├── Scripts/
│       └── VisualScripting/
├── InputSystem_Actions.inputactions
├── Settings/
├── _TerrainAutoUpgrade/
├── AllSkyFree/
├── IgniteCoders/
├── Julien Tonsuso/
├── SimplePoly City - Low Poly Assets/
└── Starter Assets/
ProjectSettings/
Packages/
```

## Limitaciones

Según la configuración actual:

1. **Build Settings:** la escena principal del entorno no está configurada como
   escena de build. Hay que añadir `SampleScene.unity` y retirar o reordenar la
   escena de ejemplo si se quiere generar el juego directamente.

2. **NavMesh:** si se modifica el terreno, el puente o las posiciones de NPC,
   hay que volver a hornear las superficies `NavMeshZone` y
   `NavMeshZone_parking`.
3. **Calidad y rendimiento:** la escena contiene muchas instancias de
   elementos modulares, vegetación, agua, vehículos y NPCs. En el PC de prueba el rendimiento era bueno.
4. **Scripts de prueba:** Hay elementos no relevantes de pruebas anteriores en el proyecto: `NewEmptyCSharpScript.cs`, `primer_script.cs`, etc. 


## Problemas y dificultades encontradas

Durante el desarrollo surgieron varias dificultades. La configuración inicial de Unity y la importación de assets de diferentes paquetes requirieron revisar materiales, prefabs y compatibilidad con URP. La integración del personaje de Mixamo implicó configurar correctamente las animaciones y la cámara de tercera persona.

El puente se ha intentado construir con los materiales disponibles y ajustando cada objeto de manera que se ajustara a la forma del puente. Se ha tratado de reconstruir de una manera fidedigna aunque es un proceso complicado.

La navegación de los NPCs también requirió hornear manualmente los NavMesh y ajustar sus superficies para que pudieran desplazarse por el terreno, el puente y el parking. Además, fue necesario controlar los destinos aleatorios para evitar que los NPCs quedaran fuera de las zonas navegables.