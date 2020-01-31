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
        //DelegateHandler.Switch += Mover_Palanca;
    }

    void Sonido_Focos ()
    {
        fluorescente.clip = apagon;
        fluorescente.Play();
    }

    void Mover_Palanca ()
    {

    }

    private void OnDisable()
    {
        DelegateHandler.Switch -= Sonido_Focos;
        //DelegateHandler.Switch -= Mover_Palanca;
    }
}
