using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casita : MonoBehaviour
{
    [SerializeField] private AudioClip final;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorSonidos.Instance.EjecutarSonido(final);
            other.GetComponent<ChompiMovement>().ganaste();
        }

    }
}