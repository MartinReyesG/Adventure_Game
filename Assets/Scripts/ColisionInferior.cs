using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionInferior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
       // FindObjectOfType<ChompiMovement>().SendMessage("niModoPa");

        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ChompiMovement>().niModoPa();
            //audio.PlayOneShot(sonidoVidas);
           // ControladorSonidos.Instance.EjecutarSonido(sonidoVidas);
          //  Destroy(gameObject);

        
        }
    }
}
