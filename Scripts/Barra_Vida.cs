using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Barra_Vida : MonoBehaviour
{
    float porcentaje_vida;
    float maximo = 100f;                                                                //Máximo de vida del jugador
    public Image img;
    public Scene escena;                                                                //Escena actual
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
        porcentaje_vida = Mathf.Clamp(porcentaje_vida - cantidad, 0f, maximo);          //Baja el porcentaje de vida en proporcion al daño
        img.transform.localScale = new Vector3(porcentaje_vida/maximo, 1, 1);           //Muestra la pérdida de vida gráficamente con la barra roja
    }

    private void Update()
    {
        if (porcentaje_vida <= 0)
        {
            StartCoroutine(Dead());                                                     //Espera 2 segundos y muestra Game Over por pantalla

            if (Input.GetKey(KeyCode.R) || (Input.GetButtonDown("Recargar")))            
                SceneManager.LoadScene(escena.name);        //Reinicia la escena        //Recarga la escena desde el punto inicial
            
           /*else if (Input.GetKey(KeyCode.Escape) || (Input.GetButtonDown("Salir")))
                UnityEditor.EditorApplication.isPlaying = false;*/
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);                                             
        go.SetActive(true);                                                             //Activa el texto de Game Over
    }
  
}
