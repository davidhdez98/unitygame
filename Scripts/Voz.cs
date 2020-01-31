using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voz : MonoBehaviour
{
    public AudioSource fuenteaudio;
    public AudioClip voz;

    void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fuenteaudio.clip = voz;
            fuenteaudio.Play();
            StartCoroutine(Parar());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fuenteaudio.clip = voz;
            fuenteaudio.Play();
            StartCoroutine(Parar());
        }
    }

    IEnumerator Parar()
    {
        yield return new WaitForSeconds(7);
        fuenteaudio.enabled = false;
    }

}
