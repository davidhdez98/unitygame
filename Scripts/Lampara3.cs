using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampara3 : MonoBehaviour
{
    public Light rb;

    void Start()
    {
        rb = GetComponent<Light>();
        rb.enabled = false;
    }

    void OnEnable()
    {
        DelegateHandler.Lampara3 += Encender;
    }

    void Encender()
    {
        rb.enabled = true;
    }

    void OnDisable()
    {
        DelegateHandler.Lampara3 -= Encender;
    }

}
