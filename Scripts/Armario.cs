using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario : MonoBehaviour
{
    public GameObject go;                       

    private void OnEnable()
    {
        DelegateHandler.Door += Abrir_Puerta;     //Clase suscrita al evento Door, invocado al intentar acceder a la puerta de metal
    }

    void Abrir_Puerta()                            //Abre la puerta del armario para poder ver la llave de la puerta de metal
    {
        transform.position = new Vector3(-309, 0, 394);
        transform.Rotate(new Vector3(0, -25, 0));
    }   

    private void OnDisable()
    {
        DelegateHandler.Door -= Abrir_Puerta;
    }
}
