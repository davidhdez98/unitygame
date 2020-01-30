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
Para el desempeño de cada una de las funciones del juego, contamos con un total de 25 scripts. A esto hay que añadir otros scripts que vienen implícitos en la escena, como por ejemplo el FirstPersonController, script añadido por defecto al FPSController que permite su movimiento, rotación, salto, sonido de los pasos, etc. Sin embargo, haremos especial hincapié en algunos de los scripts implementados.
**DelegateHandler**
