using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] private AudioClip heridaDePincho;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                other.GetComponent<ChompiMovement>().Hit();
            ControladorSonidos.Instance.EjecutarSonido(heridaDePincho);
           // Debug.Log("pincho");
        }

      


        // FindObjectOfType<ChompiMovement>().SendMessage("sumarVidas");
       // Destroy(gameObject);

    }
}
