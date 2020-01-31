using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public AudioSource fuenteaudio;
    public AudioClip key_sound;
    private MeshRenderer mr;
    private GameObject go;
    public PuertaMetal pm;
    private BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
        mr = GetComponent<MeshRenderer>();
        go = GameObject.Find("Recogida");
        go.SetActive(false);
        bc = GetComponent<BoxCollider>();
        bc.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fuenteaudio.clip = key_sound;
            fuenteaudio.Play();
            mr.enabled = false;
            go.SetActive(true);
            pm.Abrir_Puerta();
            StartCoroutine(Aux());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fuenteaudio.clip = key_sound;
            fuenteaudio.Play();
            mr.enabled = false;
            go.SetActive(true);
            pm.Abrir_Puerta();
            StartCoroutine(Aux());
        }
    }

    IEnumerator Aux()
    {
        yield return new WaitForSeconds(3);
        go.SetActive(false);
    }

    public void Activate()
    {
        bc.enabled = true;
    }

}
