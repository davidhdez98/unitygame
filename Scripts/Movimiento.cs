using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public AudioClip screamer;
    public AudioSource fuenteaudio;
    Rigidbody rb;
    private float rotespeed;
    private GameObject go;

    void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        go = GameObject.Find("Zombiee");
        go.SetActive(false);
    }

    void OnEnable()
    {
        DelegateHandler.Click += Aparicion;
    }    

    //Función para que aparezca de repente el zombie y suene la risa
    void Aparicion ()
    {
        fuenteaudio.clip = screamer;
        transform.Rotate(new Vector3(0, 180, 0));
        rb.AddForce(new Vector3(0, 0, 4) * 50, ForceMode.Acceleration);
        StartCoroutine(Segundos());
    }

    IEnumerator Segundos()
    {
        yield return new WaitForSeconds(1);
        fuenteaudio.Play();
        go.SetActive(true);
        yield return new WaitForSeconds(1);
        go.SetActive(false);
    }


    void OnDisable()
    {
        DelegateHandler.Click -= Aparicion;
    }

}
