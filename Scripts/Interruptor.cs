using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public AudioSource fluorescente;
    public AudioClip apagon;

    private void Start()
    {
        fluorescente = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        DelegateHandler.Switch += Sonido_Focos;        
    }

    void Sonido_Focos ()                                //Suenan los fluorescentes cuando tocas el interruptor
    {
        fluorescente.clip = apagon;
        fluorescente.Play();
    }   

    private void OnDisable()
    {
        DelegateHandler.Switch -= Sonido_Focos;
    }
}
