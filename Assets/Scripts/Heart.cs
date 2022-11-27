using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
  //  private AudioSource audio;
    [SerializeField] private AudioClip sonidoVidas;


    private void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("corazon");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ChompiMovement>().sumarVidas();
            //audio.PlayOneShot(sonidoVidas);
            ControladorSonidos.Instance.EjecutarSonido(sonidoVidas);
            Destroy(gameObject);
        }
    }
}
