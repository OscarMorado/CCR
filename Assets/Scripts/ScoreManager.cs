using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public int score=10;
    public float time=10;
    private bool timerIsRunning=false;


    void Start()
    {
        timerIsRunning=true;
        scoreText.text = "SCORE: "+ score.ToString();
        timeText.text= "TIME: "+time.ToString();
         
    }

    void Update()
    {
        scoreText.text = "SCORE: "+ score.ToString();
        timeText.text= "TIME: "+Mathf.FloorToInt(time % 60).ToString();
         if (timerIsRunning){
            if (time > 0){
                time -= Time.deltaTime;
            }
            else{
                time=0;
                timerIsRunning = false;
            }
        }

    }


}
