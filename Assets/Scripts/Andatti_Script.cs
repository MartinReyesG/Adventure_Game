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

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Chompi == null) return;

        Vector3 direction = Chompi.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Chompi.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        //Debug.Log("Shoot");
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
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
}
