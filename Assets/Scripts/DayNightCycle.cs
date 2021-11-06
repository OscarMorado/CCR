using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayNightCycle : MonoBehaviour
{
    private float min, grados;
    public float timespeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cycle1();
    }

    public void cycle1(){ //Escenario de día
        min = ScoreManager.time; 
        //Se dividen 180 grados entre el tiempo de juego (120/150 segundos). 120 = 1.5 / 150 = 1.2
        if(min == 120){
            grados = min / 1.5f; //Ciclo normal
        }else{
            grados = min / 1.2f;
        }
        //Rotamos la luz según el tiempo
        this.transform.localEulerAngles = new Vector3(grados, -90f, 0);
    }
}
