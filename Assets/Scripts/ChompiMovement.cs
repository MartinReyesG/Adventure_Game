using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;



public class ChompiMovement : MonoBehaviour
{
    public GameObject BulletPrefab; //objeto de tipo bullet
    public float Speed; //velocidad del movimiento
    public float JumpForce; //Fuerza del salto
    private bool Grounded; //Nos indica si Chompi está en el suelo o en el aire
    private Rigidbody2D Rigidbody2D; //Componenete encargado de las físicas del Chompi
    private Animator Animator; //Componente encargado de la transicion de animaciones
    private float Horizontal; //valor encargado de el movimiento de adelante y hacia atras (-1, 1)
    private float LastShoot; //almacena el tiempo en el que hizo el último disparo
    private int Health = 10;
    public GameObject uiStandBy;
    public enum GameState { Espera, Corriendo };
    public GameState gameState = GameState.Espera;
    public bool tieso = false;
    public TMP_Text vidas;
    public Text contadorVidas;
    private bool uno=false, cinco=false;

   // [SerializeField] private AudioClip salto;
    [SerializeField] private AudioClip unoDeVida_perdonMaiky;
    [SerializeField] private AudioClip cincoDeVida_pinchesVatos;
    //private xInicial;

    void Start() //setup
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); //toma el componenete de rigidbody del personaje Chompi
        Animator = GetComponent<Animator>();//toma el componenete de animator del personaje Chompi
    }

    void Update() //loop
    {
        if (Health == 0)
        {
            mamastePalo();
        }

        mostrarTotalVidas();


        if (gameState == GameState.Espera && Input.GetMouseButtonDown(0))
        {
            gameState = GameState.Corriendo;
            uiStandBy.SetActive(false);
            tieso = false;
        }
        else if (gameState == GameState.Corriendo)
        { 
            Horizontal = Input.GetAxisRaw("Horizontal"); //Capura la entrada del usuario (-1,1) 


        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); //condicion encargada de cambiar la posicion de Chompi si se dirige   
                                                                                      //hacia atras
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); //sino, se cambia la posición a una normal



        Animator.SetBool("running", Horizontal != 0.0f); //si Horizontal diferente de 0 es que se está moviendo y manda true. Sino, manda false


        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) //verifica si esta tocando el suelo
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded) //si presiona la W, llama al metodo Jump
        {
            //Debug.Log("salto");
            Jump();
        }

        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f) //si presiona espacio dispara
        {
            Shoot();
            LastShoot = Time.time; //guarda el tiempo en que disparamos
        }
    }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce); //añade una fuerza hacia arriba
       // ControladorSonidos.Instance.EjecutarSonido(salto);
    }

    private void Shoot()
    {
            Vector3 direction; //crea la direccion
            if (transform.localScale.x == 1.0f) direction = Vector3.right; //si se cumple es que vamos a la derecha
            else direction = Vector3.left; //sino es que estamos orientados a la izquierda
                                           // Se instancia la direccion 

        if (Health > 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity); //es la instancia 
            bullet.GetComponent<BulletScript>().SetDirection(direction); //llama al metodo de Bullet Script que indica la direccion de la bala
        }
    }


    private void FixedUpdate() //Metodo que actualiza el movimiento del personaje porque la velocidad puede cambiar
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y); //cambia la direccion de Chompi
    }

    public void Hit()
    {
       // Animator.SetBool("herida", true);
        Health -= 1;

    }

    public void muerte()
    {
        Horizontal = 0;
        //Rigidbody2D.AddForce(Vector2.up *6);
        Animator.SetBool("muerte", true);
        tieso = true;
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);
    }

    public void ReiniciarJuego()
    {
 
        SceneManager.LoadScene("Runner");

    }

    public void mamastePalo()
    {
        muerte();

       // Invoke("mostrarInicio", 5.3f);
        gameState = GameState.Espera;
        Invoke("ReiniciarJuego", 5.3f);
    }

    public void niModoPa() {
        vidas.text = "Perdiste mi rey :(";
        ControladorSonidos.Instance.EjecutarSonido(unoDeVida_perdonMaiky);
        Invoke("ReiniciarJuego", 5.3f);
        //ReiniciarJuego();
    }

    /*
    public void mostrarInicio()
    {
        uiStandBy.SetActive(true);
    }
    */
    public void mostrarTotalVidas()
    {
        if (Health == 10)
        {
            vidas.text = "Vidas: 10";
        }else if (Health == 9)
        {
            vidas.text = "Vidas: 9";
        }
        else if (Health == 8)
        {
            vidas.text = "Vidas: 8";
        }
        else if (Health == 7)
        {
            vidas.text = "Vidas: 7";
        }
        else if (Health ==6)
        {
            vidas.text = "Vidas: 6";
        }
        else if (Health == 5)
        {
            vidas.text = "Vidas: 5";
            
            if (!cinco)
            {
                ControladorSonidos.Instance.EjecutarSonido(cincoDeVida_pinchesVatos);
            }
            cinco = true;
        }
        else if (Health == 4)
        {
            vidas.text = "Vidas: 4";
        }
        else if (Health == 3)
        {
            vidas.text = "Vidas: 3";
        }
        else if (Health == 2)
        {
            vidas.text = "Vidas: 2";
        }
        else if (Health == 1)
        {
            vidas.text = "Vidas: 1";
        }
        else if (Health <= 0)
        {
            vidas.text = "Perdiste mi rey :(";
            if (!uno)
            {
                ControladorSonidos.Instance.EjecutarSonido(unoDeVida_perdonMaiky);
            }
            uno = true;
        }

    }
    public void sumarVidas()
    {
        if (Health<10)
        {
            Health++;
        }
    }
}
