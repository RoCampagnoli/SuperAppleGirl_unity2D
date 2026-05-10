using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_colisiones : MonoBehaviour{
    private PersonajeVida jugador;
    private int puntos = 10;
   
    void Start(){
        jugador= GetComponent<PersonajeVida>();
    }

    void Update(){
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("malvado verde"))
        {
            Debug.Log("toque al malo");
            if(jugador != null)
            {
                jugador.PerderVida(puntos);

            }
            else
            {
                Debug.Log("No se pudo restar vida");
            }
           
            
        }
    }
    /*private void OnCollisionStay2D(Collision2D collision)
   {
       Debug.Log("tocando");
   }*/
    

}
