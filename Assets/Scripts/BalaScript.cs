using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("trigger");
        Andatti_Script andatti = other.GetComponent<Andatti_Script>();
        ChompiMovement chompi = other.GetComponent<ChompiMovement>();
        CabezaBoss boss = other.GetComponent<CabezaBoss>();
        if (andatti != null)
        {
            andatti.Hit();
          //  Debug.Log("andatti");
        }
        if (chompi != null)
        {
            chompi.Hit();
         //   Debug.Log("chompi");
        }
        if (boss != null)
        {
            boss.Hit();
        }
        DestroyBullet();
      //  Debug.Log("destroy");
    }
}

