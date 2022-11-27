using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D; 
    public float Speed;
    private Vector2 Direction;
    public AudioClip disparo;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        ControladorSonidos.Instance.EjecutarSonido(disparo);
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject); //destruye la bala cuando abarca todas las animaciones 
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Andatti_Script andatti = other.GetComponent<Andatti_Script>();
        ChompiMovement chompi = other.GetComponent<ChompiMovement>();
        if (andatti != null)
        {
            andatti.Hit();
        }
        if (chompi != null)
        {
            chompi.Hit();
        }
        DestroyBullet();
    }
}
