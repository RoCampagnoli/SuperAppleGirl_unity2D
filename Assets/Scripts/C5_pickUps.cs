using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_pickUps : MonoBehaviour{
  
    private PersonajeVida jugador;

    public enum TipoElemento {pVerde,pRoja,pAzul};
    public TipoElemento pocion;

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
        switch (pocion){
            case TipoElemento.pVerde:
                jugador.SumarVidaConPocion(20);
                break;
            case TipoElemento.pAzul:
                jugador.SumarVidaConPocion(10);
                break;
            case TipoElemento.pRoja:
                jugador.SumarVidaConPocion(5);
                break;
        }
    }

}
