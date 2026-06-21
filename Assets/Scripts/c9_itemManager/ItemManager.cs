using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> gameItems;

    public Dictionary<GameObject, int> inventory= new Dictionary<GameObject, int>();
    void Awake()  //Awake() se ejecuta antes que cualquier Start(), entonces el inventario ya va a estar listo cuando C6_disparos lo necesite.
    {
        gameItems = new List<GameObject>(Resources.LoadAll<GameObject>("Picks"));

        for (int i = 0; i < gameItems.Count; i++){
            inventory.Add(gameItems[i], 0);
        }

        foreach (GameObject key in gameItems) {
            if (key.name == "manzana")
                inventory[key] = 10;
        }

        foreach (KeyValuePair<GameObject, int> item in inventory){
            Debug.Log("Tenes " + item.Value + " de " + item.Key.name);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
