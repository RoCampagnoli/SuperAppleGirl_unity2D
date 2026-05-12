using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_pickUps : MonoBehaviour{
  
    private PersonajeVida jugador;

    public enum TipoElemento { Manzana,pVerde,pRoja,pAzul,espada,llave};
    public TipoElemento elemento;

    private AudioSource aSource;
    [SerializeField] public AudioClip clip;

    void Start(){
        aSource= GetComponent<AudioSource>();
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
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);
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
            case TipoElemento.espada:
                jugador.tengoEspada = true;
                break;
            case TipoElemento.llave:
                jugador.tengoLlave = true;
                break;

        }
    }

}
