using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase permitirá la interacción del jugador con el entorno, detectando los distintos objetos con los que choca
public class DelegateHandler : MonoBehaviour
{
    //Lista de eventos que utilizaremos
    public delegate void ButtonClick();
    public static event ButtonClick Click;
    public static event ButtonClick Lampara1;
    public static event ButtonClick Lampara2;
    public static event ButtonClick Lampara3;
    public static event ButtonClick Lampara4;
    public static event ButtonClick Sonido;
    public static event ButtonClick Switch;
    public static event ButtonClick Evento_Ascensor;
    public static event ButtonClick Evento_Ascensor2;
    public static event ButtonClick Door;
    public Barra_Vida bv;   //Objeto con el que quitaremos vida al jugador
    public Agatha ag;
   
    private void OnCollisionEnter(Collision collision)
    {
        string nombre = collision.gameObject.name;
        switch (nombre)                             //Dependiendo del nombre del objeto, se lanzará un evento u otro
        {
            case "Scary":            
                Click();                            //Evento para que el zombie persiga al jugador
                break;
            case "Sensor1":
                Lampara1();                         //Evento para encender la primera lámpara del pasillo
                break;
            case "Sensor2":
                Lampara2();                         //Evento para encender la segunda lámpara del pasillo
                break;
            case "Sensor3":
                Lampara3();                         //Evento para encender la tercera lámpara del pasillo
                break;
            case "Sensor4":
                Lampara4();                         //Evento para encender la cuarta y quinta lámpara del pasillo
                break;
            case "Interruptor":
                Switch();                           //Evento para encender los fluorescentes de la planta baja
                break;
            case "Vuelta":
                Evento_Ascensor2();                 //Evento para que el monstruo persiga al jugador            
                break;
            case "Monstruo":
                bv.Daño(100);                       //Evento para matar al jugador si el monstruo lo toca
                break;
            case "Door":
                Door();                             //Evento para abrir la puerta del armario, activar a Agatha y salir mensaje de que 
                break;                              //necesitas una llave
            default:
                break;

        }

        if (collision.gameObject.tag == "Death")
            bv.Daño(10);                            //Evento para quitar vida al jugador al tocar el zombie

        else if (nombre == "agatha")        
            bv.Daño(40);                            //Evento para quitar vida al jugador al tocar a Agatha

        else if (nombre == "SensorAG")
            ag.Movimiento();                        //Evento para mover a Agatha

        else if (collision.gameObject.tag == "Puerta")
            Sonido();                               //Evento para abrir una puerta
    }

    private void OnTriggerEnter(Collider other)
    {

        string nombre = other.gameObject.name;

        switch (nombre)
        {
            case "Scary":
                Click();
                break;
            case "Sensor1":
                Lampara1();
                break;
            case "Sensor2":
                Lampara2();
                break;
            case "Sensor3":
                Lampara3();
                break;
            case "Sensor4":
                Lampara4();
                break;
            case "Interruptor":
                Switch();
                break;
            case "Vuelta":
                Evento_Ascensor2();                
                break;
            case "Monstruo":
                bv.Daño(100);
                break;
            case "Door":
                Door();
                break;
            default:
                break;
                
        }

        if (other.gameObject.tag == "Death")
            bv.Daño(10);

        else if (nombre == "agatha")
            bv.Daño(40);

        else if (nombre == "SensorAG")
            ag.Movimiento();

        else if (other.gameObject.tag == "Puerta")
            Sonido();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ascensor")
            Evento_Ascensor();          //Evento para coger el ascensor
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ascensor")
            Evento_Ascensor();
    }

}


