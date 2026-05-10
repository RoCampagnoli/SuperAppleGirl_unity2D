using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4_malvadoVerde : MonoBehaviour
{
    private int vida = 100;
    private int danio = 10;
    private bool malitoOn;
    [SerializeField] private Timer timer;// cada tanto tiempo va a aparecer el malo

    void Start()
    {
        
    }

    void Update()
    {
        if(!malitoOn && timer.tiempoRestante <= 0)
        {
            malitoOn = true;
            Debug.Log("Modo Salvaje");
            danio *= 2;
        }
    }
}
