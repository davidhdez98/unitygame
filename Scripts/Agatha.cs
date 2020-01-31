using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agatha : MonoBehaviour
{
    public Rigidbody rb;
    private float avance;
    public AudioSource fuenteaudio;
    public AudioClip grito;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        avance = 23;                    //Velocidad a la que avanza Agatha
        fuenteaudio = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }

    public void Movimiento()        //Activa el gameobject Agatha, reproduce un grito y mueve al personaje hacia delante
    {
        gameObject.SetActive(true);
        rb.AddForce(new Vector3(3, 0, 0) * avance, ForceMode.Acceleration);
        fuenteaudio.clip = grito;
        fuenteaudio.Play();
    }

}
