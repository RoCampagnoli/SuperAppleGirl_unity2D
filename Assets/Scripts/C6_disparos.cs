using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_disparos : MonoBehaviour{
    [SerializeField] private GameObject prefabManzana;
    //private PersonajeVida jugador;
    private ItemManager inventario;


    void Start(){
        //jugador = GetComponent<PersonajeVida>();
        inventario = GetComponent<ItemManager>();

    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.F)){
            if (ObtenerManzanas() > 0) { 

                Disparar();

            } else{
                Debug.Log("No tienes manzanas para disparar");
            }

        } 
    }
    int ObtenerManzanas() {
        foreach (KeyValuePair<GameObject, int> item in inventario.inventory) {

            if (item.Key.name == "manzana")
                return item.Value;
        }
        return 0;
    }
    void DescontarManzana() {
        foreach (GameObject key in new List<GameObject>(inventario.inventory.Keys)) {
            if (key.name == "manzana") {
                inventario.inventory[key]--;
                Debug.Log("Manzanas restantes: " + inventario.inventory[key]);

                break;
            }
        }
    }


    void Disparar()
    {
        GameObject manzana_prefab= Instantiate(prefabManzana, transform.position, Quaternion.identity);
        //creamos copias del objeto en tiempo de ejecucion,
        //el primer parametro es el objeto a copiar,
        //el segundo es la posicion donde se va a crear la copia y
        //el tercero es la rotacion de la copia

        Rigidbody2D rb= manzana_prefab.GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            // rb.velocity = Vector2.right * 10f;
            //le aplicamos una fuerza al objeto para que se mueva,
            //el primer parametro es la direccion de la fuerza y el segundo es la magnitud de la fuerza
            float direccion = transform.localScale.x;
            //derecha-->localScale.x=1, izquierda-->localScale.x=-1
            //1x10=10 dispara derecha, -1x10=-10 dispara izquierda
            rb.velocity = new Vector2(direccion * 10f, 0f);
            DescontarManzana();
        }
        Destroy(manzana_prefab, 2f);//las borra a los 2 segundos

    }
}
