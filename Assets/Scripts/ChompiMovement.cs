using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompiMovement : MonoBehaviour
{
    public GameObject BulletPrefab; //objeto de tipo bullet
    public float Speed; //velocidad del movimiento
    public float JumpForce; //Fuerza del salto
    private bool Grounded; //Nos indica si Chompi est� en el suelo o en el aire
    private Rigidbody2D Rigidbody2D; //Componenete encargado de las f�sicas del Chompi
    private Animator Animator; //Componente encargado de la transicion de animaciones
    private float Horizontal; //valor encargado de el movimiento de adelante y hacia atras (-1, 1)
    private float LastShoot; //almacena el tiempo en el que hizo el �ltimo disparo

    void Start() //setup
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); //toma el componenete de rigidbody del personaje Chompi
        Animator = GetComponent<Animator>();//toma el componenete de animator del personaje Chompi
    }

    void Update() //loop
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); //Capura la entrada del usuario (-1,1)



        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); //condicion encargada de cambiar la posicion de Chompi si se dirige   
                                                                                      //hacia atras
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); //sino, se cambia la posici�n a una normal



        Animator.SetBool("running", Horizontal != 0.0f); //si Horizontal diferente de 0 es que se est� moviendo y manda true. Sino, manda false


        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) //verifica si esta tocando el suelo
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded) //si presiona la W, llama al metodo Jump
        {
            Jump();
        }

        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f) //si presiona espacio dispara
        {
            Shoot();
            LastShoot = Time.time; //guarda el tiempo en que disparamos
        }

    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce); //a�ade una fuerza hacia arriba
    }

    private void Shoot()
    {
        Vector3 direction; //crea la direccion
        if (transform.localScale.x == 1.0f) direction = Vector3.right; //si se cumple es que vamos a la derecha
        else direction = Vector3.left; //sino es que estamos orientados a la izquierda

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity); //es la instancia que crea la bala
        bullet.GetComponent<BulletScript>().SetDirection(direction); //llama al metodo de Bullet Script que indica la direccion de la bala
    }


    private void FixedUpdate() //Metodo que actualiza el movimiento del personaje porque la velocidad puede cambiar
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y); //cambia la direccion de Chompi
    }
}