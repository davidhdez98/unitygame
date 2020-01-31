using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Barra_Vida : MonoBehaviour
{
    float porcentaje_vida;
    float maximo = 100f;
    public Image img;
    public Scene escena;
    public GameObject go;

    void Start()
    {
        porcentaje_vida = maximo;
        escena = SceneManager.GetActiveScene();
        go = GameObject.Find("Fondo");
        go.SetActive(false);
    }

//Función que es llamada cada vez que el jugador sufre un daño. Se le pasa la cantidad de vida que pierde el jugador.
    public void Daño (float cantidad) 
    {
        porcentaje_vida = Mathf.Clamp(porcentaje_vida - cantidad, 0f, maximo);
        img.transform.localScale = new Vector3(porcentaje_vida/maximo, 1, 1);
    }

    private void Update()
    {
        if (porcentaje_vida <= 0)
        {
            StartCoroutine(Dead());


            if (Input.GetKey(KeyCode.R) || (Input.GetButtonDown("Recargar")))            
                SceneManager.LoadScene(escena.name);        //Reinicia la escena
            
           /*else if (Input.GetKey(KeyCode.Escape) || (Input.GetButtonDown("Salir")))
                UnityEditor.EditorApplication.isPlaying = false;*/
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);
        go.SetActive(true);        
    }
  
}
