using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Girl : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animacion;
    private float avance;
    private GameObject go;
    public Scene escena;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animacion = GetComponent<Animator>();
        animacion.enabled = false;
        go = GameObject.Find("Victoria");
        go.SetActive(false);
        escena = SceneManager.GetActiveScene();
    }

    void Caminar() //Activa la animación que hace mover a la chica hacia el jugador
    {
        animacion.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Caminar();
            StartCoroutine(End());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Caminar();
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2);
        go.SetActive(true);

        if (Input.GetKey(KeyCode.R) || (Input.GetButtonDown("Recargar")))
            SceneManager.LoadScene(escena.name);        //Reinicia la escena

        /*else if (Input.GetKey(KeyCode.Escape) || (Input.GetButtonDown("Salir")))
             UnityEditor.EditorApplication.isPlaying = false;*/
    }

}
