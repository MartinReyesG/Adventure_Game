using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("corazon");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ChompiMovement>().sumarVidas();
            Destroy(gameObject);
        }

           // FindObjectOfType<ChompiMovement>().SendMessage("sumarVidas");
  
        
    }
}
