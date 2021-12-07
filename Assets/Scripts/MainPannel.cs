using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainPannel : MonoBehaviour
{
    [Header("Options")]
    public AudioMixer mix;
    public Slider volumeFX;
    public Slider volumeMaster;
    public AudioSource fxSource;
    public AudioClip Button;
    public AudioClip Acceptance;
    public AudioClip Inexistent;
    public Animator menuanim;
    public Toggle mute;
    private float lastvol;
    [Header("Panels")]
    public GameObject optionsPanel;
    public GameObject mainPanel;
    public GameObject cheatPanel;
    public GameObject instrPanel;
    public GameObject creditsPanel;
    private string input;
    public InputField holder;

    public Text text;

    public GameObject movpanel;
    public GameObject obspanel;
    public GameObject riverpanel;
    public GameObject goalpanel;
    public GameObject goalpanel2;
    public GameObject goalpanel3;
    

    

    public void OpenPanel(GameObject panel){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        cheatPanel.SetActive(false);
        instrPanel.SetActive(false);
        creditsPanel.SetActive(false);
        panel.SetActive(true);
        PlaySoundButton();
        text.enabled = false;
    }

    void Start(){
        optionsPanel.SetActive(false);
        cheatPanel.SetActive(false);
        instrPanel.SetActive(false);
        creditsPanel.SetActive(false);
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

    public void GameScene(){
        SceneManager.LoadScene("CharacterSelect");
    }

    public void Cheat(){
        cheatPanel.SetActive(true);
        mainPanel.SetActive(false);
        PlaySoundButton();
    }

    public void Credits(){
        creditsPanel.SetActive(true);
        mainPanel.SetActive(false);
        PlaySoundButton();
        menuanim.Play("Credits", -1, 0f);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void CheatCode(string cheat){
        Scene scene = SceneManager.GetActiveScene();
        if(holder.text == "Cascadia"){
            fxSource.PlayOneShot(Acceptance);
            PlayerPrefs.SetInt("cheatcode", 1);
            
            text.enabled = true;
            text.text = "Cheat code accepted!";
        }else{
            fxSource.PlayOneShot(Inexistent);
            text.enabled = true;
            text.text = "Invalid cheat code!";
        }
        
    }

    public void Instructions(){
        PlaySoundButton();
        mainPanel.SetActive(false);
        instrPanel.SetActive(true);
        movpanel.SetActive(true);
        obspanel.SetActive(false);
        riverpanel.SetActive(false);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    public void btnf(){
        movpanel.SetActive(false);
        obspanel.SetActive(true);
        riverpanel.SetActive(false);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    public void btnf2(){
        movpanel.SetActive(false);
        obspanel.SetActive(false);
        riverpanel.SetActive(true);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    public void btnf3(){
        movpanel.SetActive(false);
        obspanel.SetActive(false);
        riverpanel.SetActive(false);
        goalpanel.SetActive(true);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    public void btnf4(){
        movpanel.SetActive(false);
        obspanel.SetActive(false);
        riverpanel.SetActive(false);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(true);
        goalpanel3.SetActive(false);
    }

    public void btnf5(){
        movpanel.SetActive(false);
        obspanel.SetActive(false);
        riverpanel.SetActive(false);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(true);
    }

    public void btnb(){
        movpanel.SetActive(true);
        obspanel.SetActive(false);
        riverpanel.SetActive(false);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    

    public void btnb2(){
        movpanel.SetActive(false);
        obspanel.SetActive(true);
        riverpanel.SetActive(false);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    public void btnb3(){
        movpanel.SetActive(false);
        obspanel.SetActive(false);
        riverpanel.SetActive(true);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    public void btnb4(){
        movpanel.SetActive(false);
        obspanel.SetActive(false);
        riverpanel.SetActive(false);
        goalpanel.SetActive(true);
        goalpanel2.SetActive(false);
        goalpanel3.SetActive(false);
    }

    public void btnb5(){
        movpanel.SetActive(false);
        obspanel.SetActive(false);
        riverpanel.SetActive(false);
        goalpanel.SetActive(false);
        goalpanel2.SetActive(true);
        goalpanel3.SetActive(false);
    }



    
}
