using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SMTag : MonoBehaviour{

    public float detectionRange=3f;//rango en el que el jugador detecta al enemigo

    private List<GameObject>detectedEnemies =new List<GameObject>();//lista de enemigos detectados

    //[SerializeField] private AudioClip clipDeteccion;


    void Start(){
        
    }

    void Update() {
        //obtiene todo los objetos activos en la escena con el tag "malvado verde"
        GameObject[] enemiesverdes = GameObject.FindGameObjectsWithTag("malvado verde");
        GameObject[] enemiesVioletas = GameObject.FindGameObjectsWithTag("malvado Violeta");

        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(enemiesverdes);
        enemies.AddRange(enemiesVioletas);

        //detectedEnemies.Clear();

        foreach (GameObject enemy in enemies) {
            //calcula la distancia entre el jugador y el enemigo
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            //si el enemigo esta dentro del rango de detección, lo añadimos a la lista de enemigos detectados
            if (distance < detectionRange) {
                if (!detectedEnemies.Contains(enemy)) {
                    Debug.Log("Enemigo detectado!!!: " + enemy.gameObject.name);
                    detectedEnemies.Add(enemy);
                   // if (clipDeteccion != null)
                        //AudioSource.PlayClipAtPoint(clipDeteccion, transform.position);

                }
                //si el enemigo esta fuera del rango pero estba en la lista
            } else if (detectedEnemies.Contains(enemy)) {
                detectedEnemies.Remove(enemy);
                Debug.Log(enemy.gameObject.name + " está fuera de alcance");
                //esto permite que si se vuelve a acercar el enemigo,
                //se vuelva a detectar y se imprima el mensaje de nuevo
            }
        }
    }
}
