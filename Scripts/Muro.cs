using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
    BoxCollider bc;
    public Texture pared;
    Renderer renderizado;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        renderizado = GetComponent<Renderer>();
    }

    /*Desactiva los colliders de las paredes para que el jugador pueda entrar por la puerta*/
    public void Quitar_Bloqueo()
    {
        bc.enabled = false;
    }

    /*Reactiva los colliders de las paredes y la puerta para que el jugador no pueda salir*/
    public void Poner_Bloqueo()
    {
        bc.enabled = true;
    }

    /*Hace invisible el muro para que el jugador lo traspase sin que se vea*/
    public void Desactivar()
    {
        gameObject.SetActive(false);
    }

    /*Hace visible el muro*/
    public void Activar()
    {
        gameObject.SetActive(true);
    }

    /*Cambia la textura de la fachada al entrar al hospital*/
    public void Cambiar_Textura()   
    {
        renderizado.material.SetTexture("_MainTex", pared);
    }
}
