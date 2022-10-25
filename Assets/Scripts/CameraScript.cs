using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Chompi; //crea una referencia al personaje principal

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position; //indica la posicion de Chompi en el mapa
        position.x = Chompi.transform.position.x;
        transform.position = position;
    }
}
