using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject cheatPanel;
    public GameObject cheatButton;
    public GameObject mainPanel;
    private string input;

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
    }

    public void toMain(){
        cheatPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void CheatCode(string cheat){
        input = cheat;
        Debug.Log(input);
    }
}
