using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorManzanas : MonoBehaviour{
    
    public TMP_Text textoContador; // arrastrar aca el texto "texto cantManzana"

    [SerializeField] private ItemManager inventario;
    private int totalManzanasEnNivel = 0;


    void Start(){
        ContarManzanasEnEscena();
        ActualizarTexto();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarTexto();

    }

    private void ContarManzanasEnEscena() {
        // buscamos TODOS los objetos en la escena que tengan el componente Item
        // (incluso los inactivos, por si alguna manzana arranca desactivada)
        Item[] items = FindObjectsByType<Item>(FindObjectsSortMode.None);
        int contador = 0;
        foreach (Item item in items) {
            if (item.GetObjId() == "manzana") {
                contador++;
            }
        }
        // el total a mostrar es lo que ya tenia el jugador + lo que hay para recolectar en el nivel
        int manzanasIniciales = ObtenerCantidadActual();
        totalManzanasEnNivel = manzanasIniciales + contador;
    }
    private int ObtenerCantidadActual() {
        if (inventario == null) return 0;
        foreach (KeyValuePair<GameObject, int> item in inventario.inventory) {
            if (item.Key.name == "manzana") {
                return item.Value;
            }
        }
        return 0;
    }

    private void ActualizarTexto() {
        if (textoContador != null) {
            textoContador.text = ObtenerCantidadActual() + "/" + totalManzanasEnNivel;
        }
    }

}
