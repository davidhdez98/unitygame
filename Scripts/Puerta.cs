using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Muro m;
    public AudioClip screamer;
    public AudioSource fuenteaudio;

    private void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m.Quitar_Bloqueo();
            fuenteaudio.clip = screamer;
            fuenteaudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            m.Poner_Bloqueo();
    }
}
