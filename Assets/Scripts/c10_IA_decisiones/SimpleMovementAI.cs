using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementAi : MonoBehaviour{
    public Transform target;//target es el objeto que se va a perseguir, en este caso el jugador
    public float speed = 2f;//velocidad del NPC
    public float detectionRange = 1f;//rango de detección del NPC

    void Start(){
        
    }

    void Update(){
        //calculanos la distancia entre el NPC y el objetivo
        float distance= Vector3.Distance(transform.position, target.position);
        //si la distancia es menor que el rango de detección, el NPC se mueve hacia el objetivo
        if (distance < detectionRange){
            Vector3 direction = (target.position - transform.position).normalized;
            //calculamos la dirección hacia el objetivo
            transform.Translate(direction * speed * Time.deltaTime);
            //movemos el NPC hacia el objetivo
        }
    }
}
