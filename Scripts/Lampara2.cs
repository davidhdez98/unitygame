using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampara2 : MonoBehaviour
{
    public Light rb;

    void Start()
    {
        rb = GetComponent<Light>();
        rb.enabled = false;
    }

    void OnEnable()
    {
        DelegateHandler.Lampara2 += Encender;
    }

    void Encender()
    {
        rb.enabled = true;
    }

    void OnDisable()
    {
        DelegateHandler.Lampara2 -= Encender;
    }

}
