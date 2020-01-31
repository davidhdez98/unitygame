using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camilla : MonoBehaviour
{
    public Rigidbody rb;
    public float avance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        avance = 20;                                                        //Velocidad a la que se mueve la camilla
    }

    void OnEnable()
    {
        DelegateHandler.Lampara4 += MoverCamilla;    
    }

    void MoverCamilla ()                                                    //Mueve la camilla 
    {
        rb.AddForce(new Vector3(0, 0, 5) * avance, ForceMode.Acceleration);
    }

    void OnDisable()
    {
        DelegateHandler.Lampara4 -= MoverCamilla;
    }
}
