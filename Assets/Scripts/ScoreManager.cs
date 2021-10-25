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

    }


}
