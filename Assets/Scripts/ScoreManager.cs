using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public int score=0;
    public int lastScore=0;
    public static float time=120;
    private bool timerIsRunning=false;

    public RawImage heart1, heart2, heart3, heart4, heart5;
    public int heartCounter = 5;
    private SceneTransitions transition;
    private SceneManager manager;
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
        Death();
    }
    void HeartDisappear()
    {
        if (heartCounter == 5){
            heart5.enabled = true;
            heart4.enabled = true;
            heart3.enabled = true;
            heart2.enabled = true;
            heart1.enabled = true;
        }
        else if (heartCounter == 4) {
            heart5.enabled = false;
            heart4.enabled = true;
            heart3.enabled = true;
            heart2.enabled = true;
            heart1.enabled = true;
        }
        else if(heartCounter == 3){
            heart5.enabled = false;
            heart4.enabled = false;
            heart3.enabled = true;
            heart2.enabled = true;
            heart1.enabled = true;
        }
        else if(heartCounter == 2){
            heart5.enabled = false;
            heart4.enabled = false;
            heart3.enabled = false;
            heart2.enabled = true;
            heart1.enabled = true;
        }
        else if (heartCounter == 1){
            heart5.enabled = false;
            heart4.enabled = false;
            heart3.enabled = false;
            heart2.enabled = false;
            heart1.enabled = true;
        }
        else if (heartCounter == 0 || time == 0){
            heart5.enabled = false;
            heart4.enabled = false;
            heart3.enabled = false;
            heart2.enabled = false;
            heart1.enabled = false;
        }
        
    }

    public void Death(){
        
        if(heartCounter == 0 || time == 0){
            
            SceneManager.LoadScene("Menu");
            heartCounter = 6;
            time = 1;

        }
    }
            

    IEnumerator Deathtimer(){
        yield return new WaitForSeconds(5f*Time.deltaTime);
        
    }
}
