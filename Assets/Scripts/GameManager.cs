using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool gameActive;
    public GameObject GameOverPanel;
    public GameObject NextLevelPanel;
    public GameObject FinalLevelPanel;

    private ScoreManager ScoreManagerScript;
    

    void Start()
    {
        ScoreManagerScript = GameObject.Find("Score").GetComponent<ScoreManager>();
        GameOverPanel.SetActive(false);
        NextLevelPanel.SetActive(false);
        FinalLevelPanel.SetActive(false);
        gameActive=true;
        gameOver=false;

        if(SceneManager.GetActiveScene().name=="Level2"){
            ScoreManagerScript.ResetValues(0,100.0f,5,0);//when the scene is level2, we change the time to 100
        }
    }
    
    void Update() {

        if(gameOver){
            gameActive=false;
            ScoreManagerScript.isSober = true;
            GameOverPanel.SetActive(true);
            
        }


 
    }
    public void goToMainBtn(){
        SceneManager.LoadScene("Menu");
    }
    public void NextLevelBtn(){
        SetToNextLevel(false);//close canvas panel
        SceneManager.LoadScene("Level2");//load level2 scene
        
    }
    
    public void SetToNextLevel(bool nextLevel){
        NextLevelPanel.SetActive(nextLevel);//show canvas panel
        gameActive=!nextLevel;
    }
    public void FinalGoal(){
        FinalLevelPanel.SetActive(true);
        gameActive=false;
    }

    
}
