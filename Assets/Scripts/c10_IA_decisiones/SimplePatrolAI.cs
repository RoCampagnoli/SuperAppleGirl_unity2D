using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrolAI : MonoBehaviour{

    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    public Transform player;
    public float detectionRange = 5f;

    private Transform currentTarget;
   
    void Start(){
        //inicia moviendose al punto A  
        currentTarget = pointA;

    }

    void Update(){

        //calcula la distancia entre el NPC y el jugador    
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange) {
            Vector3 chaseDirection = (player.position - transform.position).normalized;
            transform.Translate(chaseDirection * speed * Time.deltaTime);
        }
        //calcula la distancia entre el NPC y los puntos
        float distance = Vector3.Distance(transform.position, currentTarget.position);
        //si la distancia es menor que un umbral, cambiamos el objetivo
        if (distance < 2f){
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }

        //movemos el NPC hacia el objetivo actual
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
