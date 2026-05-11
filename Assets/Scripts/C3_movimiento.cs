using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3_movimiento : MonoBehaviour {

    //variables de direccion
    private int movimientoHorizontal;//0  está quieto. 
    //private int movimientoVertical;
    private Vector2 mov;

    //para correr
    [SerializeField] private float speed=5f;//velocidad
    private float ogSpeed;
    private float multSpeed;//velocidad multiplicadas
    [SerializeField] private float valMultSpeed = 1.5f;

    //para saltar
    [SerializeField] private float fuerzaSalto = 15f;
    private bool saltoActivo = false;

    private Rigidbody2D rb;

    Animator animator;
    private bool giroIzq;

    private PersonajeVida personaje;

    void Start() {
        
        rb = GetComponent<Rigidbody2D>();//quiero acceder a las propiedades del rigid body
        //guardamos la velocidad original
        ogSpeed = speed;
        //calculamos la velocidad aumentada
        multSpeed = speed * valMultSpeed;

        //accedo a las propiedades del animator
        animator= GetComponent<Animator>();

        personaje = GetComponent<PersonajeVida>();
    }

    private void Update()
    {
        Sprint(multSpeed);
        MovH(1);
        //MovV(1);
        Salto(1);
    }
    private void MovH(int a)
    {
        //MOVIMIENTO HORIZONTAL
        if (Input.GetKey(KeyCode.D))
        {
            movimientoHorizontal = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movimientoHorizontal = -1;
        }
        else
        {
            movimientoHorizontal = 0;
        }

    }

    private void Salto(int a) {
        
        if (Input.GetKeyDown(KeyCode.Space)&& saltoActivo==false) {
            saltoActivo=true;
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            saltoActivo = false;
        }
    }
    /*private void MovV(int a)
     {
         //MOVIMIENTO VERTICAL
         if (Input.GetKey(KeyCode.W))
         {
             movimientoVertical = 1;
         }
         else if (Input.GetKey(KeyCode.S))
         {
             movimientoVertical = -1;
         }
         else
         {
             movimientoVertical = 0;
         }

     }*/

    //PARA CORRER
    private void Sprint(float multSpeed)
    {
        //para correr
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = multSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = ogSpeed;
        }
    }

    private void FixedUpdate() {
        /*
                //1ro creo un vector de movimiento. le asignamos las variables que determinan la direccion
                mov = new Vector2(movimientoHorizontal, movimientoVertical);
                mov = mov.normalized;//todas las direcciones tienen la misma velocidad
                //rb.AddForce(movVector * velActual * Time.fixedDeltaTime);// se va a mover constantemente sin frenar..
                //si quiero que frene tengo que usar el velocity
                rb.velocity = mov * speed; //con esto, cuando dejo de presionar la tecla debe quedarse qquieto
               */
        // Movimiento en X, preservando la velocidad en Y del motor físico
        rb.velocity = new Vector2(movimientoHorizontal * speed, rb.velocity.y);
        //usamos el Mathf-- devuelve un valor absoluto, siempre positivo
        AnimacionPlayer();
        GirarPlayer();
        
    }

    private void AnimacionPlayer() {

        if (Mathf.Abs(rb.velocity.x) > 0) {
            animator.SetFloat("xVelocity", 1);
            //C A M I N A N D O
            
        } else {
            animator.SetFloat("xVelocity", 0);
            //Q U I E T O 
           
        }
    }

    private void GirarPlayer() {
        //si se esta moviendo a la izquierda, giro al player
        if(rb.velocity.x>0 && !giroIzq) {
            giroIzq = true;
            Vector3 ls=transform.localScale;//guardo la escala actual del objeto
            ls.x *= -1;//invierto el eje X
            transform.localScale = ls;//aplico el cambio

        } else if (rb.velocity.x<0 && giroIzq) { 
            giroIzq = false;
            Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }

    
}

