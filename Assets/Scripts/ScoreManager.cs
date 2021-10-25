using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public int score=0;
    public int lastScore=0;
    public static float time=60;
    private bool timerIsRunning=false;

    public RawImage heart1, heart2, heart3, heart4, heart5;
    public int heartCounter = 5;
    

    void Start()
    {
        timerIsRunning=true;
        scoreText.text = "SCORE: "+ score.ToString();
        timeText.text= "TIME: "+time.ToString();
         
    }

    void Update()
    {
        //150>0 
        if(score<lastScore ){
            scoreText.text = "SCORE: "+ lastScore.ToString();
        }else{
            scoreText.text = "SCORE: "+ score.ToString();
        }
        
        timeText.text= "TIME: " + time.ToString("f0");
         if (timerIsRunning){
            if (time > 0){
                time -= Time.deltaTime;
            }
            else{
                time=0;
                timerIsRunning = false;
            }
        }
        HeartDisappear();
    }

    void HeartDisappear()
    {
        if (heartCounter == 4)
            heart5.enabled = false;
        else if (heartCounter == 3)
            heart4.enabled = false;
        else if (heartCounter == 2)
            heart3.enabled = false;
        else if (heartCounter == 1)
            heart2.enabled = false;
        else if (heartCounter == 0)
            heart1.enabled = false;
    }
}
