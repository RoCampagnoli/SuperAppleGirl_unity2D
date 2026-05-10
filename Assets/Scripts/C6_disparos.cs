using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_disparos : MonoBehaviour
{
    [SerializeField] private GameObject prefabManzana;
    private PersonajeVida jugador;

    void Start()
    {
        jugador = GetComponent<PersonajeVida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            if (jugador.manzanas > 0) { 

                Disparar();
                jugador.CantidadManzanas(-1);

            } else{
                Debug.Log("No tienes manzanas para disparar");
            }

        } 
    }
    void Disparar()
    {
        GameObject manzana= Instantiate(prefabManzana, transform.position, Quaternion.identity);
        //creamos copias del objeto en tiempo de ejecucion,
        //el primer parametro es el objeto a copiar,
        //el segundo es la posicion donde se va a crear la copia y
        //el tercero es la rotacion de la copia

        Rigidbody2D rb= manzana.GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.velocity = Vector2.right * 10f;
            //le aplicamos una fuerza al objeto para que se mueva,
            //el primer parametro es la direccion de la fuerza y el segundo es la magnitud de la fuerza
        }
        Destroy(manzana, 2f);
    }
}
