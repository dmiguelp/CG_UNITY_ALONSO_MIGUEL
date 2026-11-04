# CG_UNITY_ALONSO_MIGUEL

Proyecto de Unity para la construcción de un entorno 3D explorable con estética
low-poly. El escenario combina la zona natural de **La Cantera**, una piscina
natural, el **Puente de Alcántara**, una zona de parking y una zona elevada con
vegetación, mobiliario, vehículos y personajes controlados por navegación.

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
| `VisualScripting SceneVariables` | Variables de escena de Unity Visual Scripting |
| `New Script Graph` | `ScriptMachine` de Visual Scripting |
| `NavMeshZone` | `NavMeshSurface` para la zona general de navegación |
| `NavMeshZone_parking` | `NavMeshSurface` para la zona del parking |
| `RoamCenter` | Punto de referencia para el movimiento aleatorio de NPCs |
| `RoamCenter_parking` | Punto de referencia de movimiento del parking |
| `DestinoNPC` | Punto preparado como destino explícito de NPC |
| `Plane` | Plano auxiliar de la escena |
| `Sphere` | Esfera con `Rigidbody` y `SphereCollider` |
| `Cube (2)` | Cubo de la escena, con `MeshRenderer` y `BoxCollider` |
| `Cube (3)` | Cubo de la escena, con `MeshRenderer` y `BoxCollider` |
| `Cube (4)` | Cubo de la escena, con `MeshRenderer` y `BoxCollider` |
| `Cube (5)` | Cubo de la escena, con `MeshRenderer` y `BoxCollider` |
| `Cube (6)` | Cubo de la escena, con `MeshRenderer` y `BoxCollider` |
| `Cube (7)` | Cubo de la escena, con `MeshRenderer` y `BoxCollider` |
| `Cube (8)` | Cubo de la escena, con `MeshRenderer` y `BoxCollider` |

Los cubos se usan como geometría auxiliar o elementos de prueba. `Sphere`
conserva física dinámica y gravedad activada.

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
ropa, pelo, ojos y zapatos. Sus texturas se encuentran en
`Assets/Scenes/_MisCosas/Personajes/jugadorUnoTexturas/` e incluyen mapas
diffuse, normal, gloss, specular y opacity para las distintas partes.

La cámara de seguimiento está representada por `PlayerFollowCamera` y el
`PlayerArmature` contiene el `PlayerCameraRoot` utilizado por el controlador de
tercera persona.

## Scripts propios

### `NPCMover.cs`

Script de comportamiento autónomo de NPC descrito en la sección de navegación.
Usa `UnityEngine.AI`, valida dependencias y comunica errores mediante
`Debug.LogError`.

### `NewMonoBehaviourScript.cs`

Componente de prueba utilizado sobre un objeto de la escena. Rota el objeto
continuamente alrededor de los ejes X, Y y Z:

```text
rotationSpeed = 100
```

La rotación se ejecuta en `Update` y está multiplicada por
`Time.deltaTime`.

### `NewEmptyCSharpScript.cs`

Clase vacía creada como plantilla. No hereda de `MonoBehaviour` y no tiene
comportamiento conectado a la escena.

### `primer_script.cs`

Archivo vacío reservado para pruebas iniciales; actualmente no aporta
comportamiento.

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
| `Materials/Rojo.mat` | Material propio de color rojo |
| `VisualScripting/` | Recursos asociados a grafos visuales |

## Input System

El proyecto utiliza el paquete nuevo **Input System** y el asset
`Assets/InputSystem_Actions.inputactions`. El mapa de acciones `Player`
contiene:

| Acción | Tipo | Uso |
| --- | --- | --- |
| `Move` | Vector2 | Movimiento |
| `Look` | Vector2 | Cámara/mirada |
| `Attack` | Button | Acción de ataque |
| `Interact` | Button, Hold | Interacción mantenida |
| `Crouch` | Button | Agacharse |
| `Jump` | Button | Salto |
| `Previous` / `Next` | Button | Navegación entre opciones |
| `Sprint` | Button | Carrera |

`Move` tiene bindings para stick izquierdo de gamepad, WASD y flechas. El
archivo también conserva bindings para gamepad, teclado/ratón y XR.

## Renderizado, iluminación y ambiente

- Render Pipeline: **Universal Render Pipeline (URP)**.
- Versión de Unity: **6000.6.4f1**.
- Paquete URP: **17.6.0**.
- Skybox configurado en `SampleScene`.
- Fog activada con densidad `0.01` y distancia lineal hasta `300`.
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

El repositorio también contiene recursos de terceros/importados, entre ellos
AllSkyFree, Simple Water Shader, Modular Fantasy Bridges, SimplePoly City,
YughuesFreePavementsMaterials, Adobe Substance 3D y Starter Assets. Estos
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

## Limitaciones y tareas recomendadas

Estas observaciones se deducen de la configuración actual:

1. **Build Settings:** la escena principal del entorno no está configurada como
   escena de build. Hay que añadir `SampleScene.unity` y retirar o reordenar la
   escena de ejemplo si se quiere generar el juego directamente.
2. **Punto de entrada:** el producto aparece configurado como
   `Clase_1_Prefab`, con versión `0.1.0` y compañía `DefaultCompany`; conviene
   actualizar estos valores antes de distribuirlo.
3. **Input del jugador:** existe un mapa de acciones amplio, pero en la escena
   no se ha identificado un controlador propio de movimiento del jugador dentro
   de los scripts de `_MisCosas`. Conviene verificar en Unity que el prefab del
   jugador tenga correctamente enlazados el controlador y el asset de input.
4. **NavMesh:** si se modifica el terreno, el puente o las posiciones de NPC,
   hay que volver a hornear las superficies `NavMeshZone` y
   `NavMeshZone_parking`.
5. **Calidad y rendimiento:** la escena contiene muchas instancias de
   elementos modulares, vegetación, agua, vehículos y NPCs. Antes de una build
   final conviene revisar LOD, sombras, oclusión, resolución de texturas y
   perfiles PC/móvil.
6. **Scripts de prueba:** `NewEmptyCSharpScript.cs` y `primer_script.cs` están
   vacíos; pueden conservarse como material didáctico o eliminarse si ya no se
   necesitan.

## Licencias y procedencia

El proyecto mezcla recursos propios con assets de terceros. Antes de publicar
una build fuera del entorno académico hay que revisar las licencias incluidas
por cada paquete y asset, especialmente los contenidos de AllSkyFree,
Mixamo, Starter Assets, Adobe Substance, SimplePoly City, Modular Fantasy
Bridges, Yughues y el shader de agua.
