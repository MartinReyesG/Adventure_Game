using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaBoss : MonoBehaviour
{

    public Transform Chompi;
    public GameObject BulletPrefab;
    private Animator Animator;

    private int Health = 10;
    private float LastShoot;

    public AudioClip semanaEstable;


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

        if (distance < 1.7f && Time.time > LastShoot + 0.25f)
        {
            if (Health != 0)
            {
                Shoot();
                LastShoot = Time.time;
            }

        }
    }

    private void Shoot()
    {
  
        Vector3 direction; 
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.4f, Quaternion.identity);


        bullet.GetComponent<BombaScript>().SetDirection(direction);
       
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0)
        {

            //ControladorSonidos.Instance.EjecutarSonido(muerteFinal);
            //Animator.SetBool("muerte", true);
            ControladorSonidos.Instance.EjecutarSonido(semanaEstable);
            Invoke("destruirEnemigo", 0.2f);

        }
    }

    public void destruirEnemigo()
    {
        Destroy(gameObject);
    }

}
