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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeToLevel(int levelIndex){
        levelToLoad = levelIndex;
        animator.SetTrigger("Fadeout");
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
