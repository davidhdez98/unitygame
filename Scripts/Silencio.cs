using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silencio : MonoBehaviour
{
    public AudioSource fuenteaudio;
    public AudioClip interior;

    private void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        DelegateHandler.Sonido += Quitar_Musica;
    }

    void Quitar_Musica ()
    {
        fuenteaudio.clip = interior;
        fuenteaudio.Play();
        fuenteaudio.volume = 1;
    }

    void OnDisable()
    {
        DelegateHandler.Sonido -= Quitar_Musica;    
    }
}
