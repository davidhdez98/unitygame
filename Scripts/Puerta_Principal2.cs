using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_Principal2 : MonoBehaviour
{
    public MeshRenderer h;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Aparece()
    {
        gameObject.SetActive(true);
    }
}
