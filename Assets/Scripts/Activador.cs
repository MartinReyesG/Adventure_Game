using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip sonidoDeFondo;
    //   CameraScript sound = new CameraScript();



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           // other.GetComponent<ControladorSonidos>().EjecutarSonido(sound);
            ControladorSonidos.Instance.EjecutarSonido(sound);
            Destroy(gameObject);
            // skullpanel.SetActive(true);
            // CameraScript.Instance.detener(sonidoDeFondo);
        }

    }
}
