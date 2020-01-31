using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaMetal : MonoBehaviour
{
    public GameObject go;       //Mensaje    
    public Muro m;
    private BoxCollider bc;     //El collider del muro m (donde está la puerta de metal)
    public Llave key;
    public AudioSource fuenteaudio;
    public AudioClip risas;
    private GameObject sensor;

    private void OnEnable()
    {
        DelegateHandler.Door += Necesita_Llave;
    }

    private void Start()
    {
        go = GameObject.Find("Mensaje");
        go.SetActive(false);
        bc = m.GetComponent<BoxCollider>();
        fuenteaudio = GetComponent<AudioSource>();
        sensor = GameObject.Find("SensorAG");
        sensor.SetActive(false);
    }
    void Necesita_Llave()
    {
        if (bc.enabled == true)
        {
            key.Activate();
            fuenteaudio.clip = risas;
            fuenteaudio.Play();
            go.SetActive(true);
            sensor.SetActive(true);
            StartCoroutine(Message());
        }
    }

    IEnumerator Message()
    {
        yield return new WaitForSeconds(4);
        go.SetActive(false);
    }

    public void Abrir_Puerta()
    {
        m.Quitar_Bloqueo();
    }

    private void OnDisable()
    {
        DelegateHandler.Door -= Necesita_Llave;
    }

}
