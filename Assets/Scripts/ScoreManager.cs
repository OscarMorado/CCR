using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Text state; //State
    public bool isSober=true;
    public int score;
    public int lastScore;
    public GameObject drunkPanel;
    public static float time;
    public static bool timerIsRunning=false;
    public RawImage heart1, heart2, heart3, heart4, heart5;
    public int heartCounter = 5;
    private SceneTransitions transition;
    private SceneManager manager;
   
    //script
    private GameManager GameManagerScript;


    void Start()
    {
        ResetValues(0,120.0f, 5, 0);
        int cheatcode = PlayerPrefs.GetInt("cheatcode");

        if(cheatcode == 1 ){
            time += 30;
            PlayerPrefs.SetInt("cheatcode", 0);
        }


        drunkPanel.SetActive(false);
        timerIsRunning=true;
        scoreText.text = "SCORE: "+ score.ToString();
        state.text = "Sober ";
        timeText.text= "TIME: "+time.ToString();
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
         
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
         if (timerIsRunning && GameManagerScript.gameActive){
            if (time > 0){
                time -= Time.deltaTime;
            }
            else{
                time=0;
                timerIsRunning = false;
            }
        }
        if (isSober)
        {
            state.text = "Sober";
            drunkPanel.SetActive(false);
        }
        else
        {
            state.text = "Drunk";
            drunkPanel.SetActive(true);
        }
        HeartDisappear();
        Death();
    }
    public void HeartDisappear()
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

    public void ResetValues(int scoreValue, float timeValue, int heartCounterValue, int lastScoreValue){
        score=scoreValue;
        time=timeValue;
        heartCounter = heartCounterValue;
        lastScore=lastScoreValue;
    }


    public void Death(){
        
        if(heartCounter == 0 || time == 0){
            GameManagerScript.gameOver=true;

        }
    }
            

}
