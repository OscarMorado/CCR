using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
   private bool startedscene;

    public Animator animator;
    private int levelToLoad; 
    public GameObject optionsPanel;
    public GameObject mainPanel;
    public GameObject cheatPanel;
    public GameObject instrPanel;  
    public bool flag = false;
    void Start()
    {

    }
//hearts.heartCounter == 0 && Input.GetKeyDown(KeyCode.Space)|| ScoreManager.time == 0 && Input.GetKeyDown(KeyCode.Space)
    // Update is called once per frame
 

    public void FadeToLevel(int levelIndex){
        levelToLoad = levelIndex;
        animator.SetTrigger("Fadeout");
    }

    public void FadeToMenu(){
        FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("Menu");
        Debug.Log("Ok2");
    }

    public void OnFadeComplete(){
        FadeToLevel(1);
        SceneManager.LoadScene("Game");
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        cheatPanel.SetActive(false);
        instrPanel.SetActive(false);
    }
}
