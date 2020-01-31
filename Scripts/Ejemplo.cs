using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    public void cambiocolor()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
