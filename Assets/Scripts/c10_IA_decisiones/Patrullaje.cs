using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 7f;
    private Transform currentTarget;
    void Start() {
        currentTarget = pointA;
    }
    void Update() {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        if (playerDistance < detectionRange) {
            // Si el jugador está dentro del rango, el NPC cambia a modo persecución
            MoveTowards(player.position);
        } else {
            // Si el jugador sale del rango, el NPC vuelve a patrullar
            Patrol();
        }
    }
    void Patrol() {
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
        if (distanceToTarget < 0.1f) {
            // Cambia de objetivo cuando llega a un punto de patrullaje
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
        MoveTowards(currentTarget.position);
    }
    void MoveTowards(Vector3 targetPosition) {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

}