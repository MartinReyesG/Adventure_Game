using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
