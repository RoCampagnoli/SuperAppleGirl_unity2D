using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float tiempoRestante = 10f;//tiempo inicial
    private bool timerOn; //interruptor


    void Start()
    {
        timerOn = true;//comienza a contar al dar play
    }

    // Update is called once per frame
    void Update()
    {
        TimerCheck();//se ejecuta en cada frame, llamo a la funcion
    }

    void TimerCheck()
    {
        if (timerOn)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                //muestra el tiempo con dos decimales
                Debug.Log("TiempoActual: " + tiempoRestante.ToString("F2"));
                //F formato fixed, 2 dos decimales
            }
        }
        else
        {
            Debug.Log("Se terminó el tiempo!");
            tiempoRestante = 0;
            timerOn = false;
        }

    }
}
