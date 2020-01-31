using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{

    public Light rb;

    void Start()
    {
        rb = GetComponent<Light>();
        rb.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (rb.enabled == true)
                rb.enabled = false;
            else
                rb.enabled = true;
        }

        if (Input.GetButtonDown("Z"))
        {
            if (rb.enabled == true)
                rb.enabled = false;
            else
                rb.enabled = true;
        }


    }
}
