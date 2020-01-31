using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaPrincipal : MonoBehaviour
{
    public AudioClip screamer;
    public AudioClip portazo;
    public AudioSource fuenteaudio;
    public Muro m;
    public Muro m2;
    public Puerta_Principal2 p;    

    private void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSControllerOriginal")
        {
            fuenteaudio.clip = screamer;
            fuenteaudio.Play();
            m2.Quitar_Bloqueo();
            m.Desactivar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FPSControllerOriginal")
        {
            m2.Poner_Bloqueo();
            m.Activar();
            fuenteaudio.clip = portazo;
            fuenteaudio.Play();
            other.gameObject.name = "FPSController";
            p.Aparece();
            m.Cambiar_Textura();
        }
    }
}
