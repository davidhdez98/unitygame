# PROYECTO
# Introducción
  El juego se desarrolla en un hospital. En primer lugar, el personaje se encontrará en un bosque, por el que debe ir caminando hasta encontrarse en la fachada del hospital. Una vez allí, podrá acceder al interior del mismo, que cuenta con dos plantas. El objetivo principal del juego es entrar al hospital para rescatar a una chica que se encuentra allí encerrada. Tanto en el interior del hospital como en el bosque habrá una serie de obstáculos (monstruos, zombies, etc) que, de entrar en contacto con el jugador, le quitarán vida. Cuando el jugador pierda toda la vida, morirá y se le preguntará si quiere reiniciar el juego. 
  Para dividir las distintas zonas del juego, vamos a crear una escena en la que va a haber dos terrenos, uno para el bosque y otro para el hospital. 
  
# Primer terreno: bosque
Lo primero que hacemos es añadir un terreno, que es donde vamos a construir el bosque. Para ello, editamos el terreno, le añadimos árboles (coníferas y pinos) y le añadimos una carretera, que será el camino por el que transite el jugador. Asimismo, editamos el skybox, de modo que el escenario esté totalmente oscuro. En este terreno, aparte del camino y los árboles, vamos a añadir un FPSController. Este prefab va a ser nuestro Player, y con él nos moveremos por la escena; podremos caminar, saltar, y a través de él interactuar con los distintos elementos de la escena. En el controlador añadimos la Main Camera, que será la única cámara del juego. Asimismo, también vamos a añadirle al jugador una linterna, y a ella una spot light; así, cuando el jugador pulse el botón X, se encenderá la linterna, y la apagará de la misma forma. Dentro de la cámara añadimos el Canvas, en el que principalmente nos va a aparecer una barra de vida de color verde; según vaya perdiendo vida el jugador, la barra de vida irá llenándose de color rojo. Además, cuando el jugador gane o pierda la partida, le aparecerá un mensaje por pantalla para reiniciar el juego o salir. 

# Segundo terreno: hospital
Este terreno incluye la gran mayoría de los elementos del juego. El hospital tiene dos plantas, cada una de las cuales con una serie de habitaciones y elementos que comentaremos a continuación.

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
- Círculo para salir del juego

# Hitos de programación
Para el desempeño de cada una de las funciones del juego, contamos con un total de 25 scripts. A esto hay que añadir otros scripts que vienen implícitos en la escena, como por ejemplo el FirstPersonController, script añadido por defecto al FPSController que permite su movimiento, rotación, salto, sonido de los pasos, etc. Sin embargo, haremos especial hincapié en algunos de los scripts implementados. Entre las técnicas vistas en clase e implementadas en el juego podemos encontrar las siguientes:
- Iluminación. Utilización de diferentes tipos de luz. Activación y desactivación de luces.
- Canvas. Creación de textos e imágenes en pantalla. Aparición y desaparición de mensajes de ayuda. Aparición de menú para reiniciar el juego o salir.
- Google VR Cardboard. Habilitada la opción para mover la cámara con el movimiento de la cabeza.
- Delegados y eventos. Creación de múltiples eventos para gestionar la interacción del jugador con el entorno.
Otras técnicas implementadas son:
- Animaciones. Utilización de animaciones para conseguir un movimiento más realista de algunos personajes.
- Subrutinas. Creación de subrutinas para utilizar la función WaitforSeconds y generar así un tiempo de espera.

**DelegateHandler**

Este es uno de los scripts más importantes del proyecto. Con él gestionamos la mayor parte de las interacciones que realiza el jugador con objetos de la escena. Dentro de este script encontramos numerosos eventos, y las funciones OnCollisionEnter y OnTriggerEnter. Así, se lanzará un evento determinado cada vez que el jugador choque con un objeto en concreto. Por ejemplo, si el jugador choca con una puerta, se lanza un evento al que está suscrito el gameobject Puerta; este evento hará que, cuando el jugador se acerque a una puerta, se reproduzca un sonido y se desactiven los colliders de la puerta y de la pared donde esta se encuentra, de modo que el jugador pueda pasar. Asimismo, utilizamos las funciones OnCollisionExit y OnTriggerExit para volver a activar los colliders; si no, el jugador podría salir de la habitación atravesando la pared. 

**Muro**

Este script, a pesar de ser muy simple y tener pocas funciones, es uno de los más útiles del juego. Los métodos de esta clase permiten activar y desactivar colliders, así como activar y desactivar gameobjects. Estas funciones son llamadas cada vez que el jugador cruza una puerta, de ahí la utilidad de esta clase; el jugador atraviesa la puerta principal, las tres puertas de las habitaciones, la puerta del baño, la del ascensor y la de la puerta de metal donde está la chica. En todos estos casos se hacen uso de las funciones de esta clase para desactivar los colliders de las paredes adyacentes a las puertas, y también para desactivarlas completamente. Esta última característica es importante ya que, si solo desactivamos el collider y nos olvidamos de desactivar el gameobject, el jugador cruzaría la puerta pero, por el camino, vería que está atravesando la pared. Esto se evita desactivando el gameobject de la pared. Otra solución sería que hubiera un hueco en la pared, donde va la puerta; sin embargo, con esta técnica tendríamos que utilizar más prefabs para crear las paredes, sobrecargando el juego. No obstante, este método sí lo utilizamos en una ocasión, en la puerta del baño.
  Por otro lado, este script también resulta muy útil a la hora de utilizar el ascensor. Cuando el ascensor sube, llamamos a estas funciones para desactivar el techo de la planta baja, porque si no lo hacemos veríamos cómo atravesamos el techo. De nuevo, esta técnica resulta más sencilla que dejar un hueco real, aunque a nivel de programación resulte más compleja. 
  
**Barra_Vida**

Este script controla todos los aspectos relacionados con la vida del jugador, tanto a nivel gráfico como de programación. Cada vez que el jugador realiza una acción que le hace perder vida, se llaman a los métodos de esta clase para reflejar esta característica gráficamente; se ve un aumento en la barra roja de vida, y por tanto una disminución en la barra verde. Por otro lado, la importancia de este script recae en la recarga de la escena. Se comprueba en cada frame que el nivel de vida sea superior a 0; si no lo es, nos aparecerá un mensaje en el canvas que indica que has perdido, activando después dos opciones, Restart o Exit. Si pulsamos restart, se recarga la escena; el jugador vuelve a empezar desde el punto de partida, y se reinician todos los componentes y la barra de vida. 

**
