using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public AudioMixer mix;
    public Slider volumeFX;
    public Slider volumeMaster;
    public AudioSource fxSource;
    public AudioClip Button;
    public Toggle mute;
    private float lastvol;
    public GameObject pausePanel;
    public GameObject volumePanel;
    public Text remLives;
    public Text remTime;

    private ScoreManager informative;

    // Start is called before the first frame update
    void Start(){
        pausePanel.SetActive(false);
        volumePanel.SetActive(false);
        
    }

    public void ChangeMasterVolume(float masterVol){
        mix.SetFloat("VolMaster", masterVol);
    }

    public void ChangeFXVolume(float fxVol){
        mix.SetFloat("VolFX", fxVol);
    }

    private void Awake(){
        volumeFX.onValueChanged.AddListener(ChangeFXVolume);
        volumeMaster.onValueChanged.AddListener(ChangeMasterVolume);
    }

    public void doMute(){
        if(mute.isOn){
            mix.GetFloat("volMaster", out lastvol);
            mix.SetFloat("VolMaster", -80);
        }else{
            mix.SetFloat("VolMaster", lastvol);
        }
    }

    public void PlaySoundButton(){
        fxSource.PlayOneShot(Button);
    }

    public void ButtonExit(){
        SceneManager.LoadScene("Menu");
    }

    public void ButtonVolume(){
        volumePanel.SetActive(true);
    }

    public void ButtonRestart(){

    }

    public void Information(){
        remLives.text = "Lives: " + informative.heartCounter;
        remTime.text =  "Time: " + ScoreManager.time;
    }
}
