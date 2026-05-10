using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeVida : MonoBehaviour{
    public int vida=100;
    public int manzanas = 10;

    void Start(){

    }

    void Update(){
        

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
}
