using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampara4 : MonoBehaviour
{
    public Light rb;

    void Start()
    {
        rb = GetComponent<Light>();
        rb.enabled = false;
    }

    void OnEnable()
    {
        DelegateHandler.Lampara4 += Encender;
    }

    void Encender()
    {
        rb.enabled = true;
    }

    void OnDisable()
    {
        DelegateHandler.Lampara4 -= Encender;
    }

}
