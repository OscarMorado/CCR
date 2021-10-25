using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject cheatPanel;
    public GameObject cheatButton;
    public GameObject mainPanel;
    public GameObject instrPanel;
    private string input;

    private MainPannel principal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameScene(){
        SceneManager.LoadScene("Game");
    }

    public void Cheat(){
        cheatPanel.SetActive(true);
        mainPanel.SetActive(false);
        principal.PlaySoundButton();
    }

    public void toMain(){
        cheatPanel.SetActive(false);
        mainPanel.SetActive(true);
        principal.PlaySoundButton();
    }

    public void CheatCode(string cheat){
        input = cheat;
        Debug.Log(input);
    }

    public void Instructions(){
        principal.PlaySoundButton();
        mainPanel.SetActive(false);
        instrPanel.SetActive(true);
    }
}
