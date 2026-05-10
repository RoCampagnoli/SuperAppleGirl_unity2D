using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_pickUps : MonoBehaviour{
  
    private PersonajeVida jugador;

    public enum TipoElemento { Manzana,pVerde,pRoja,pAzul}
    public TipoElemento elemento;
    
    void Start(){
        
    }

    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            jugador=collision.GetComponent<PersonajeVida>();

            if (jugador != null)
            {
                AplicarEfectoElemento();
                gameObject.SetActive(false);
            }
       
        }
    }
    private void AplicarEfectoElemento()
    {
        switch (elemento)
        {
            case TipoElemento.Manzana:
                jugador.CantidadManzanas(1);
                break;
            case TipoElemento.pVerde:
                jugador.SumarVidaConPocion(10);
                break;
            case TipoElemento.pAzul:
                jugador.SumarVidaConPocion(5);
                break;
            case TipoElemento.pRoja:
                jugador.SumarVidaConPocion(1);
                break;

        }
    }

}
