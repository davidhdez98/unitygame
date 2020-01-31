using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstruo : MonoBehaviour
{
    public Rigidbody rb;
    private float avance;
    public Animator anim;
    public AudioSource fuenteaudio;
    public AudioClip monster;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        fuenteaudio = GetComponent<AudioSource>();
        anim.enabled = false;
        avance = 35;
    }

    private void OnEnable()
    {
        DelegateHandler.Evento_Ascensor2 += Movimiento;
    }

    void Movimiento()
    {
        anim.enabled = true;
        rb.AddRelativeForce(new Vector3(-5, 0, 0) * avance, ForceMode.Acceleration);
        fuenteaudio.clip = monster;
        fuenteaudio.Play();
    }

    private void OnDisable()
    {
        DelegateHandler.Evento_Ascensor2 -= Movimiento;
    }
}
