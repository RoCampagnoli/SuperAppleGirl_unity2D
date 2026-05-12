using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_colisiones : MonoBehaviour{
    private PersonajeVida jugador;
    private C4_malvados malvado;


    void Start(){
        jugador= GetComponent<PersonajeVida>();
    }

    void Update(){
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         malvado = collision.gameObject.GetComponent<C4_malvados>();

         if (malvado != null &&  (jugador != null && jugador.vida>0)){

             jugador.PerderVida(malvado.getDanio());

         }
    }
    /*private void OnCollisionStay2D(Collision2D collision)
   {
       Debug.Log("tocando");
   }*/
    

}
