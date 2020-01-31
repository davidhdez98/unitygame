using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    public Rigidbody rb;
    private float avance;
    public Muro m;                                              //Techo
    public Muro m2;                                             //Parte de arriba de la pared
    public BoxCollider bc;                                      //Collider del ascensor, que controla su movimiento
    public AudioSource fuenteaudio;             
    public AudioClip ascensor;                                  //Audio del ascensor
   
    private void OnEnable()
    {
        DelegateHandler.Evento_Ascensor += Ascenso;             //Evento para subir el ascensor
        DelegateHandler.Evento_Ascensor2 += Descenso;           //Evento para bajar el ascensor
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        avance = 1;                                             //Velocidad a la que sube o baja el ascensor
        bc = GetComponent<BoxCollider>();
        fuenteaudio = GetComponent<AudioSource>();       
    }

    void Ascenso ()                                             /*Mueve el ascensor hacia arriba o hacia abajo, dependiendo de su 
                                                                  posición inicial*/
    {
        m2.Desactivar();                                         //Desactiva la parte de arriba de la pared
        m.Desactivar();                                          //Desactiva el techo
        bc.enabled = false;                                      //Desactiva el collider que provoca el movimiento del ascensor
        fuenteaudio.clip = ascensor;    
        fuenteaudio.Play();                                      //Reproduce el sonido del ascensor

        if (rb.position.y < 10)                                  //Dependiendo de su posición, el ascensor sube o baja                    
            rb.AddForce(new Vector3(0, 1, 0) * avance, ForceMode.Impulse);        
        else        
            rb.AddForce(new Vector3(0, -1, 0) * avance, ForceMode.Impulse);        
    }

    private void OnTriggerEnter(Collider other)                 //Detecta una barrera en la parte superior para parar al ascensor
    {
        if (other.gameObject.tag == "Sensor")                   
        {
            rb.velocity = Vector3.zero;
            m.Poner_Bloqueo();
            m2.Activar();
        }

        if (other.gameObject.name == "Auxiliar")
        {
            m.Activar();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sensor")               //Llega al tope de arriba
        {
            rb.velocity = Vector3.zero;
            m.Poner_Bloqueo();                                  //Activa el collider del techo de nuevo
            rb.isKinematic = true;                              //Evita que el ascensor siga subiendo
            m2.Activar();                                       //Reactiva la parte de arriba de la pared
        }

        if (collision.gameObject.name == "Auxiliar")            //
        {
            m.Activar();                                        //Activa el techo (ahora suelo, porque hemos subido una planta)
        }       
    }

    void Descenso()
    {
        if (bc.enabled == false)                                //Reactiva el collider que permite que el ascensor suba o baje
            bc.enabled = true;
    }

    private void OnDisable()
    {
        DelegateHandler.Evento_Ascensor -= Ascenso;
        DelegateHandler.Evento_Ascensor2 -= Descenso;
    }

    private void Update()
    {
        if (rb.position.y < 8.7 )                               //Inhabilita el movimiento del ascensor si ha llegado al tope inferior
            rb.isKinematic = true;
    }

}
