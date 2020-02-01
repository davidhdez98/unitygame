# PROYECTO
# Introducción
   Este juego ha sido desarrollado con una temática de terror. Está diseñado para jugarlo en cualquier dispositivo con una versión de Android de 9.0, aunque se puede generar para dispositivos con versiones más antiguas. Se utilizará un mando de Play Station 4 para mover al jugador por la escena, y el sistema de VR de Google Cardboard para mover la cámara.
   
   El juego se desarrolla en un hospital. En primer lugar, el personaje se encontrará en un bosque, por el que debe ir caminando hasta encontrarse en la fachada del hospital. Una vez allí, podrá acceder al interior del mismo, que cuenta con dos plantas. El objetivo principal del juego es entrar al hospital para rescatar a una chica que se encuentra allí encerrada. Tanto en el interior del hospital como en el bosque habrá una serie de obstáculos (monstruos, zombies, etc) que, de entrar en contacto con el jugador, le quitarán vida. Cuando el jugador pierda toda la vida, morirá y se le preguntará si quiere reiniciar el juego. Se recomienda la utilización de auriculares para una mejor experiencia y un mayor grado de inmersión en el juego. 
   
  Para dividir las distintas zonas del juego, vamos a crear una escena en la que va a haber dos terrenos, uno para el bosque y otro para el hospital. 
  
# Primer terreno: bosque
   Lo primero que hacemos es añadir un terreno, que es donde vamos a construir el bosque. Para ello, editamos el terreno, le añadimos árboles (coníferas y pinos) y le añadimos una carretera, que será el camino por el que transite el jugador. Asimismo, editamos el skybox, de modo que el escenario esté totalmente oscuro. En este terreno, aparte del camino y los árboles, vamos a añadir un FPSController. Este prefab va a ser nuestro Player, y con él nos moveremos por la escena; podremos caminar, saltar, y a través de él interactuar con los distintos elementos de la escena. En el controlador añadimos la Main Camera, que será la única cámara del juego. Asimismo, también vamos a añadirle al jugador una linterna, y a ella una spot light; así, cuando el jugador pulse el botón X, se encenderá la linterna, y la apagará de la misma forma. Dentro de la cámara añadimos el Canvas, en el que principalmente nos va a aparecer una barra de vida de color verde; según vaya perdiendo vida el jugador, la barra de vida irá llenándose de color rojo. Además, cuando el jugador gane o pierda la partida, le aparecerá un mensaje por pantalla para reiniciar el juego o salir, y también saldrán otros mensajes a medida que avanza el juego. 

# Segundo terreno: hospital
Este terreno incluye la gran mayoría de los elementos del juego: resto de personajes de la escena, escaleras, habitaciones y, lo más importante, la chica que buscamos. El hospital tiene dos plantas, cada una de las cuales con una serie de habitaciones y elementos que comentaremos a continuación.

**Primera planta** 

Cuando el jugador entra por la puerta principal, accede a la primera planta del hospital; allí encontramos una recepción, con sillas de espera a ambos lados. Al lado de la puerta encontramos un interruptor; si lo accionamos, los fluorescentes de la planta baja se encienden, pero a los pocos segundos se funden. En la planta baja podemos tomar dos caminos; si vamos a la izquierda, encontramos un pasillo largo que va a dar a los baños. Al lado del baño se encuentra un ascensor. Si vamos a la derecha, encontramos unas escaleras que llevan a la segunda planta, igual que el ascensor. 

**Segunda planta**

Cuando accedemos a la segunda planta, observamos un pasillo con 3 habitaciones. En cada habitación encontramos dos camas, una mesa de noche con una vela, y un armario cerrado. Si seguimos avanzando por el pasillo, encontramos una puerta metálica al final del todo. Como observaremos a medida que vayamos jugando, esta habitación es donde está encerrada la chica, pero para entrar deberemos encontrar primero la llave.

# Controles
Los controles del juego para un dispositivo android, utilizando un mando de PlayStation4, son los siguientes:
- Triángulo para saltar
- Equis para encender/apagar la linterna 
- Joystick izquierdo para moverte por la escena
- Cuadrado para recargar la escena cuando acabe la partida (tanto al ganar el juego como al morir)
- Círculo para salir del juego (solo en PC)

# Hitos de programación
Para el desempeño de cada una de las funciones del juego, contamos con un total de 25 scripts. A esto hay que añadir otros scripts que vienen implícitos en la escena, como por ejemplo el FirstPersonController, script añadido por defecto al FPSController que permite su movimiento, rotación, salto, sonido de los pasos, etc. Sin embargo, haremos especial hincapié en algunos de los scripts implementados. Entre las técnicas vistas en clase e implementadas en el juego podemos encontrar las siguientes:
- Iluminación. Utilización de diferentes tipos de luz (spot light, directional light, point light). Activación y desactivación de luces.
- Canvas. Creación de textos e imágenes en pantalla. Aparición y desaparición de mensajes de ayuda. Aparición de menú para reiniciar el juego o salir.
- Google VR Cardboard. Habilitada la opción para mover la cámara con el movimiento de la cabeza.
- Delegados y eventos. Creación de múltiples eventos para gestionar la interacción del jugador con el entorno.
- Rigidbody para otorgar movimiento a los objetos.
- Colliders para detectar collisiones con los objetos.

Otras técnicas implementadas son:
- Animaciones. Utilización de animaciones para conseguir un movimiento más realista de algunos personajes.
- Subrutinas. Creación de subrutinas para utilizar la función WaitforSeconds y generar así un tiempo de espera en ciertas funciones.
- Ocludee Static. Con esta opción añadida sobre un gameobject conseguimos que este objeto únicamente se renderice cuando se encuentre dentro del ángulo de la cámara. Cuando salga del plano, desaparece, evitando la sobrecarga y mejorando la renderización del juego. Por ejemplo, objetos como la recepción de la planta baja y las sillas de espera tienen añadida esta característica. 
- Ocluder Static. Esta función es análoga a la anterior. La diferencia es que, mientras el anterior se aplica sobre objetos pequeños, esta opción se aplica sobre objetos grandes que tapen la visión de objetos que se encuentren detrás. Por ejemplo, toda la fachada del hospital incluye esta opción.
- Input Manager. Utilizamos esta opción para mapear el mando de PS4 y poder jugar con él.
De entre todos los scripts implementados, comentaremos algunos de los más importantes, ya sea por su funcionalidad o por su abundante utilización.


**DelegateHandler**

Este es uno de los scripts más importantes del proyecto. Con él gestionamos la mayor parte de las interacciones que realiza el jugador con objetos de la escena. Dentro de este script encontramos numerosos eventos, y las funciones OnCollisionEnter y OnTriggerEnter. Así, se lanzará un evento determinado cada vez que el jugador choque con un objeto en concreto. Por ejemplo, si el jugador choca con una puerta, se lanza un evento al que está suscrito el gameobject Puerta; este evento hará que, cuando el jugador se acerque a una puerta, se reproduzca un sonido y se desactiven los colliders de la puerta y de la pared donde esta se encuentra, de modo que el jugador pueda pasar. Asimismo, utilizamos las funciones OnCollisionExit y OnTriggerExit para volver a activar los colliders; si no, el jugador podría salir de la habitación atravesando la pared. 

**Muro**

   Este script, a pesar de ser muy simple y tener pocas funciones, es uno de los más útiles del juego. Los métodos de esta clase permiten activar y desactivar colliders, así como activar y desactivar gameobjects. Estas funciones son llamadas cada vez que el jugador cruza una puerta, de ahí la utilidad de esta clase; el jugador atraviesa la puerta principal, las tres puertas de las habitaciones, la puerta del baño, la del ascensor y la de la puerta de metal donde está la chica. En todos estos casos se hacen uso de las funciones de esta clase para desactivar los colliders de las paredes adyacentes a las puertas, y también para desactivarlas completamente. Esta última característica es importante ya que, si solo desactivamos el collider y nos olvidamos de desactivar el gameobject, el jugador cruzaría la puerta pero, por el camino, vería que está atravesando la pared. Esto se evita desactivando el gameobject de la pared. Otra solución sería que hubiera un hueco en la pared, donde va la puerta; sin embargo, con esta técnica tendríamos que utilizar más prefabs para crear las paredes, sobrecargando el juego. No obstante, este método sí lo utilizamos en una ocasión, en la puerta del baño.
   
   Por otro lado, este script también resulta muy útil a la hora de utilizar el ascensor. Cuando el ascensor sube, llamamos a estas funciones para desactivar el techo de la planta baja, porque si no lo hacemos veríamos cómo atravesamos el techo. De nuevo, esta técnica resulta más sencilla que dejar un hueco real, aunque a nivel de programación resulte más compleja. 
  
**Barra_Vida**

   Este script controla todos los aspectos relacionados con la vida del jugador, tanto a nivel gráfico como de programación. Cada vez que el jugador realiza una acción que le hace perder vida, se llaman a los métodos de esta clase para reflejar esta característica gráficamente; se ve un aumento en la barra roja de vida, y por tanto una disminución en la barra verde. Por otro lado, la importancia de este script recae en la recarga de la escena. Se comprueba en cada frame que el nivel de vida sea superior a 0; si no lo es, nos aparecerá un mensaje en el canvas que indica que has perdido, activando después dos opciones, Restart o Exit. Si pulsamos restart, se recarga la escena; el jugador vuelve a empezar desde el punto de partida, y se reinician todos los componentes y la barra de vida. 

# Personajes
   Encontramos 5 personajes distintos en todo el juego. Hay que aclarar que puedes ganar el juego sin necesidad de encontrarte a todos ellos; ya veremos que hay un personaje en concreto que puede que no lleguemos a encontrárnoslo.
- Jugador: es el principal personaje, el que se mueve por toda la escena e interactúa con el entorno. No se ve puesto que el juego está en primera persona.
- Chica: es el personaje por el que jugamos. Recordemos que el objetivo del juego es encontrar a la chica. Este personaje está dotada de una animación para moverse hacia el jugador una vez este la encuentre.
- Zombie: es el primer jugador que nos encontramos en el juego. Si nos toca nos quita un 10% de vida.
- Agatha: es un monstruo que nos puede quitar un 40% de vida si nos toca. 
- Monstruo: es el personaje que podemos evitar encontrarnos en el juego. Sin embargo, si llegamos a topar con él nos quita el 100% de la vida.

# Probando el juego
   Al principio, el jugador aparece en un bosque. A su alrededor hay numerosos árboles, y un sendero por el que puede caminar. El jugador comienza la partida a mitad del sendero; puede caminar hacia el principio del mismo, donde no encontrará nada, o hacia delante, encaminándose hacia el hospital. Puede moverse en todas direcciones, caminar entre los árboles o seguir el sendero. Si mueves la cabeza se mueve la cámara, y el jugador se mueve en la dirección hacia la que se está mirando. El terreno cuenta con colliders en cada uno de los extremos para evitar que el jugador se caiga. El jugador cuenta con una linterna; pulsando el botón X se enciende y apaga la linterna, y pulsando el triángulo salta. Según se va dirigiendo el jugador hacia el hospital, en medio del camino hay un hombre. Cuando el jugador se acerca lo suficiente, el hombre se da la vuelta y resulta ser un zombie; se aproxima de repente hacia el jugador, quitándole un 10% de vida si logra tocarlo. A continuación, el jugador ya vislumbra la fachada del hospital. El jugador podrá caminar por la fachada; para entrar deberá subir las escaleras situadas delante de la puerta principal. Para ello, puede subirlas normalmente o saltarlas. Una vez entre al hospital, la puerta chirriará y la música de fondo que había hasta ahora cambiará por una música de tensión, más suave y regular. Desde que el jugador se separe mínimamente de la puerta principal, se escuchará cómo ésta da un portazo; si el jugador intenta ahora salir del hospital no podrá, está encerrado. 
   
   El jugador se encuentra ahora en la planta baja del hospital. A su alrededor puede observar una mesa que se intuye como la recepción del hospital. A ambos lados de la misma se encuentran sillas de espera que, por su aspecto deteriorado y sucio, evidencian que el hospital está abandonado y en desuso. Esta característica ya la veíamos anteriormente en la fachada, dado que tanto puertas como ventanas tenían los cristales rotos. Justo al lado de la puerta se encuentra un interruptor de palanca; si el jugador lo acciona, los fluorescentes de la habitación se enciende momentáneamente, pero en pocos segundos se funden y la estancia vuelve a estar oscura. Por tanto, el jugador debe seguir utilizando su linterna para proseguir su camino. Hay dos caminos por los que el jugador puede seguir. Si vamos por la izquierda, encontramos un largo pasillo que va a dar a la puerta de los baños. Justo al lado del baño se encuentra el ascensor para subir a la primera planta. Si el jugador toma el ascensor, cuando salga se encontrará un monstruo que corre hacia él. En este momento el juego proporciona dos opciones: si el jugador es lo suficientemente ágil, puede retroceder rápidamente y entrar en el ascensor, regresando a la planta baja. Sin embargo, si no lo consigue, el monstruo lo matará, ya que le quita el 100% de la vida desde que entra en contacto con él. Una vez muerto, aparecerá un mensaje de Game Over en el que el jugador puede recargar el juego y volver a empezar desde el bosque, pulsando el botón Cuadrado. 
    
   El otro camino que puede tomar el jugador en la planta baja es ir a la derecha. Aquí encontramos unas escaleras que, al igual que el ascensor, llevan a la primera planta. Una vez suba el jugador, se encuentra en un pasillo con habitaciones a ambos lados. Cuando va caminando a lo largo del pasillo, unos sensores van encendiendo las luces que hay a los lados, otorgando una mejor iluminación a la escena. Existen tres habitaciones; no obstante, el jugador solo puede entrar en la tercera de ellas. Aquí encuentra dos camas, una mesa de noche con una vela, y un armario. A lo largo de su camino, el jugador va escuchando gritos y lamentos; cuando se acerca al final del pasillo, donde hay una puerta azul de metal, escucha claramente a una chica diciendo "¡Socorro! ¡Estoy aquí!". Es la voz de la chica a la que ha venido a rescatar. Cuando se acerca a la puerta de metal para entrar a por ella, aparece un mensaje que indica "La puerta está cerrada. Necesitas encontrar la llave". Además del mensaje, se escucha también una especie de cerradura y unas risas. En este momento el jugador deberá desandar sus pasos y buscar la llave de la puerta. Sin embargo, cuando regresa por el pasillo de repente aparece Agatha, un monstruo que, mientras grita se acerca rápidamente hacia él. El jugador debe ser rápido y entrar en la primera habitación que se encuentra. Si no lo consigue y Agatha le toca, perderá la mitad de la vida. Si logra entrar a la habitación, descubrirá que el armario que antes permanecía cerrado ahora está abierto (de ahí el sonido anterior de cerradura al tocar la puerta de metal). El jugador observa que dentro del armario hay una llave. La coge, aparece un mensaje de "Has conseguido la llave" y se dirige finalmente hacia la puerta de metal. Cuando llega, entra y encuentra ahí a la chica, que se acerca hacia él. En ese momento ha terminado el juego; aparece un mensaje de You Win y de nuevo una opción para recargar el juego si pulsas Cuadrado. 
   
# Dificultades encontradas

   Uno de los principales problemas que hemos encontrado a la hora de realizar el juego es su ralentización en tiempo de ejecución. Al añadir tantos prefabs, el peso total del juego es de más de tres GB. Además, los prefabs incluyen muchos elementos, cada uno de ellos con una gran cantidad de polígonos, de modo que cargar todo esto en la escena implica renderizar muchos detalles, y el juego acababa yendo demasiado lento. Para solucionarlo eliminamos algunos de estos prefabs y nos quedamos con una escena un poco más sencilla, sin perder información importante. Por otro lado, también ocultamos algunos componentes de prefabs que no eran necesarios. Por ejemplo, las bisagras de las puertas, que dada la oscuridad total de la escena, es un detalle que realmente no se llega a apreciar. Este problema no hubiera surgido si hubiésemos utilizado prefabs menos realistas, diseñados para juegos de móvil. Los prefabs empleados son quizás más enfocados a juegos de consolas más potentes. 
   
   Otro problema fue conseguir mover al jugador con el mando de PS4 en Android. Si bien mapeamos correctamente el mando, los botones sí funcionaban pero no los joysticks. Cuando logramos solucionarlo, comprobamos que el jugador no se movía en la posición hacia la que miras con la cámara, sino siempre en la misma dirección, dificultando la movilidad. Sin embargo, finalmente logramos arreglar este problema.
   
# Trabajo en equipo

   Con respecto al trabajo en equipo durante la realización del proyecto, hay algunas partes del juego desarrolladas únicamente por un miembro del grupo, mientras que otras han sido implementadas de forma conjunta. A continuación nombraremos algunas de las partes más importantes del trabajo e indicaremos la coordinación entre los miembros del grupo.
- Desarrollo del bosque: David
- Mapeo del mando: David
- Modificación scripts de movimiento: Eduardo
- Diseño planta baja del hospital: Eduardo
- Diseño primera planta del hospital: David
- Historia del juego: Eduardo y David
- Canvas y Google Cardboard: Eduardo y David
- Documentación del código: Eduardo y David
- README.md: Eduardo y David
- Diapositivas: Eduardo
- Ocluder Static y Ocludee Static: David
- Optimización del juego: Eduardo
- Búsqueda de prefabs: Eduardo y David
A continuación se adjunta un vídeo de 4 minutos en el que se ve la ejecución del juego completo para poderlo visualizar con sonido. No se adjunta archivo Gif porque es más pesado que el archivo de vídeo, y ya en este último se aprecia el funcionamiento del juego.
![Gift](
   
