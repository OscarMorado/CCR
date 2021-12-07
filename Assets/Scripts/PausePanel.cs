using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public AudioMixer mix;
    public Slider volumeMaster;
    public AudioClip Button;
    public Toggle mute;
    private float lastvol;
    public GameObject pausePanel;
    public GameObject volumePanel;
    public Text remLives;
    public Text remTime;
    private bool active;

    private ScoreManager ScoreManagerScript; 
    private PlayerController restart; 
  

    // Start is called before the first frame update
    void Start(){
        pausePanel.SetActive(false);
        volumePanel.SetActive(false);
        
    }

    public void ChangeMasterVolume(float masterVol){
        mix.SetFloat("VolMaster", masterVol);
    }

    private void Awake(){
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

    public void ButtonExit(){
        SceneManager.LoadScene("Menu");
    }

    public void ButtonVolume(){
        volumePanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void StartPanel(){
        pausePanel.SetActive(true);
        volumePanel.SetActive(false);
    }

    public void ButtonRestart(){
        ScoreManagerScript = GameObject.FindGameObjectWithTag("ButtonB").GetComponent<ScoreManager>();
        Time.timeScale = 1;
        restart = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ScoreManagerScript.ResetValues(0,120.0f, 5, 0);
        //restart.resetPosition();
    }

    public void Information(){
        remLives.text = "Lives: " + ScoreManagerScript.heartCounter.ToString();
        remTime.text =  "Time: " + ScoreManager.time.ToString();
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            active = !active;
            pausePanel.SetActive(active);
            Debug.Log("State: " + active);
            if(!active){
                Time.timeScale = 1;
            }else{
                Time.timeScale = 0;
            }
            
        }
    }
}
