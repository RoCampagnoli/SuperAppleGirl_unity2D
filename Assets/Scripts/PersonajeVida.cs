using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeVida : MonoBehaviour{
    public int vida=100;
    public int manzanas = 10;
    public bool tengoEspada = false;
    public bool tengoLlave = false;
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        AtacarConEspada();
    }

    public void SumarVidaConPocion(int a){
        vida += a;
        Debug.Log("Vida restante: " + vida);
    }
    public void PerderVida(int a) 
    {
        vida -= a;
        Debug.Log("Vida restante: " + vida);
    }
    public void CantidadManzanas(int a)
    {
        manzanas += a;
        Debug.Log("Manzanas: " + manzanas);
    }

    private void AtacarConEspada() {
        if (Input.GetKeyDown(KeyCode.X) && tengoEspada ) {
            animator.SetTrigger("Ataque");//evento momentaneo
        } 
    }
   
}
