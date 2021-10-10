using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainPannel : MonoBehaviour
{
    [Header("Options")]
    public AudioMixer mix;
    public Slider volumeFX;
    public Slider volumeMaster;
    public AudioSource fxSource;
    public AudioClip Button;
    public Toggle mute;
    private float lastvol;
    [Header("Panels")]
    public GameObject optionsPanel;
    public GameObject mainPanel;
    public GameObject cheatPanel;
    

    public void OpenPanel(GameObject panel){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        panel.SetActive(true);
        
    }

    void Start(){
        optionsPanel.SetActive(false);
        cheatPanel.SetActive(false);
    }

    public void ChangeMasterVolume(float masterVol){
        mix.SetFloat("VolMaster", masterVol);
    }

    public void ChangeFXVolume(float fxVol){
        mix.SetFloat("Volfx", fxVol);
    }

    private void Awake(){
        volumeFX.onValueChanged.AddListener(ChangeFXVolume);
        volumeMaster.onValueChanged.AddListener(ChangeMasterVolume);
    }

    public void SoundButton(){
        fxSource.PlayOneShot(Button);
    }

    public void doMute(){
        if(mute.isOn){
            mix.GetFloat("volMaster", out lastvol);
            mix.SetFloat("VolMaster", -80);
        }else{
            mix.SetFloat("VolMaster", lastvol);
        }
    }

    
}
