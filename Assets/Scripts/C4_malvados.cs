using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4_malvados : MonoBehaviour { 

    public enum EnumMalvado { m_verde, m_violeta };
    public EnumMalvado malvado;
    //private int vidaMalvado = 100;
    private int danio;
    
    //[SerializeField] private Timer timer;// cada tanto tiempo va a aparecer el malo

    //desplazamiento del malvado
    [SerializeField] private float velocidadMov;
    [SerializeField] private float distanciaMov;
   

    private Vector3 posicionInicial;

    private bool moviendoDerecha = true;
    void Start(){
       posicionInicial = transform.position;
        TipoMalvado();
    }

    void Update(){
        
        desplazamientoMalvado();
        /* if(!malitoOn && timer.tiempoRestante <= 0)
         {
             malitoOn = true;
             Debug.Log("Modo Salvaje");
             danio *= 2;
         }*/
    }

    private void TipoMalvado() {
         switch (malvado) {
            case EnumMalvado.m_verde:
                danio = 10;
                velocidadMov = 1f;
                distanciaMov = 2f;
                break;
            case EnumMalvado.m_violeta:
                danio = 20;
                velocidadMov = 3f;
                distanciaMov = 4f;
                break;
        }
    }
    
    public int getDanio() {
        return danio;
    }

    void GirarMalvado() {
        Vector3 ls=transform.localScale;//guardo la escala actual del objeto
        ls.x *= -1;//cambio el signo de la escala en x para girar el objeto
        transform.localScale = ls;//aplico el cambio
    }

    void desplazamientoMalvado() {
        
        if (moviendoDerecha) {
            transform.Translate(Vector2.right * velocidadMov * Time.deltaTime);
            if (transform.position.x >= posicionInicial.x + distanciaMov) {
                moviendoDerecha = false;
                GirarMalvado();
            }
        } else {
            transform.Translate(Vector2.left * velocidadMov * Time.deltaTime);
            if (transform.position.x <= posicionInicial.x - distanciaMov) {
                moviendoDerecha = true;
                GirarMalvado();
            }
        }
    }
}
