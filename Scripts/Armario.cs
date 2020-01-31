using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario : MonoBehaviour
{
    public GameObject go;
    public static Armario Instance;

    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

        private void OnEnable()
    {
        DelegateHandler.Door += Abrir_Puerta;
    }

    void Abrir_Puerta()
    {
        transform.position = new Vector3(-309, 0, 394);
        transform.Rotate(new Vector3(0, -25, 0));
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
    }

    private void OnDisable()
    {
        DelegateHandler.Door -= Abrir_Puerta;
    }
}
