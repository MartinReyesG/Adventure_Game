using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Chompi; //crea una referencia al personaje principal
    [SerializeField] public AudioClip sonidoDeFondo;

    void Start()
    {
        ControladorSonidos.Instance.LoopSonido(sonidoDeFondo);
    }
    // Update is called once per frame
    void Update()
    {
        if (Chompi != null)
        {
            Vector3 position = transform.position; //indica la posicion de Chompi en el mapa
            position.x = Chompi.transform.position.x;
            transform.position = position;
        }
    }

    public void detener(AudioClip sonido)
    {
        ControladorSonidos.Instance.DetenerSonido(sonidoDeFondo);
    }
    
}
