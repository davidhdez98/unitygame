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
        avance = 23;
        fuenteaudio = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }

    public void Movimiento()
    {
        gameObject.SetActive(true);
        rb.AddForce(new Vector3(3, 0, 0) * avance, ForceMode.Acceleration);
        fuenteaudio.clip = grito;
        fuenteaudio.Play();
    }

}
