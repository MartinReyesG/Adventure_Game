using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andatti_Script : MonoBehaviour
{
    public Transform Chompi;
    public GameObject BulletPrefab;
    private Animator Animator;

    private int Health = 3;
    private float LastShoot;


    //[SerializeField] private float velocidad;
   // [SerializeField] private Transform ControladorSuelo;
  //  [SerializeField] private float distancia;
  //  [SerializeField] private bool movimiendoDerecha;
    private Rigidbody2D rb;

    void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Chompi == null) return;

        Vector3 direction = Chompi.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Chompi.position.x - transform.position.x);

        if (distance < 0.7f && Time.time > LastShoot + 0.25f)
        {
            if (Health!=0)
            {
                Shoot();
                LastShoot = Time.time;
            }

        }
    }

    private void Shoot()
    {
        //Debug.Log("Shoot");

        //Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);

        Vector3 direction; //crea la direccion
        if (transform.localScale.x == 1.0f) direction = Vector3.right; //si se cumple es que vamos a la derecha
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BalaScript>().SetDirection(direction);
      //  Debug.Log("shhot");
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0)
        {
            Animator.SetBool("muerte", true);
            Invoke("destruirEnemigo", 0.9f);
    
        }
    }

    public void destruirEnemigo()
    {
        Destroy(gameObject);
    }

    /*
    private void FixedUpdate() //Metodo que actualiza el movimiento del personaje porque la velocidad puede cambiar
    {
        //   Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y); //cambia la direccion de Chompi
        RaycastHit2D informacionSuelo = Physics2D.Raycast(ControladorSuelo.position, Vector2.down, distancia);
        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (informacionSuelo==false)
        {
            girar();
        }
    }

    public void girar()
    {
        movimiendoDerecha = !movimiendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ControladorSuelo.transform.position, ControladorSuelo.transform.position + Vector3.down * distancia);
    }
    
    */

}
