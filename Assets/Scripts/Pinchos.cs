using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tiempoSiguienteDaño -= Time.deltaTime;
            if (tiempoSiguienteDaño<=0) {
                other.GetComponent<ChompiMovement>().Hit();
                tiempoSiguienteDaño = tiempoEntreDaño;
                Debug.Log("pincho");
            }
        }

      


        // FindObjectOfType<ChompiMovement>().SendMessage("sumarVidas");
       // Destroy(gameObject);

    }
}
