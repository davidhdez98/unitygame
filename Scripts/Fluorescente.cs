using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluorescente : MonoBehaviour
{
    public Light luz;

    private void Start()
    {
        luz = GetComponent<Light>();
        luz.enabled = false;
    }

    private void OnEnable()
    {
        DelegateHandler.Switch += Encender_Foco;
    }

    void Encender_Foco()                                            //Enciende los fluorescentes 
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()                                  //Después de 4 segundos apaga los fluorescentes
    {
        luz.enabled = true;
        yield return new WaitForSeconds(4);
        luz.enabled = false;
    }

    private void OnDisable()
    {
        DelegateHandler.Switch -= Encender_Foco;
    }


}





   

    
