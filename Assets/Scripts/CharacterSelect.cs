using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter(){
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter+1)%characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter(){
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter<0){//go to the last charachter
            selectedCharacter+=characters.Length;
        }
        characters[selectedCharacter].SetActive(true);    
    }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1,LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
