using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip moving;
    private Rigidbody playerRb;
    private AudioSource audio;
    private Animator playerAnim;
    private ScoreManager scoreManagerScript;//score variable
    //limits:
    private float limitZMax = -742.0f;
    private float limitZMin = -838.0f;
    private float limitXMax = 399.0f;
    private float limitXMin = 301.0f;
    public bool isOnRiver;
    public bool gameOver;
    public ParticleSystem food;
    public ParticleSystem death;
    public ParticleSystem crash;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        scoreManagerScript =GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !gameOver && transform.position.z<limitZMax){
            //increase the score:
            scoreManagerScript.score+=1;
            transform.Translate(Vector3.forward);
            //playerAnim.SetTrigger("Jump_trig");
            audio.PlayOneShot(moving, 1.0f);
        

        }else if(Input.GetKeyDown(KeyCode.S) && !gameOver && transform.position.z>limitZMin){
            //decrease the score:
            scoreManagerScript.score-=1;
            transform.Translate(Vector3.back);
            //playerAnim.SetTrigger("Jump_trig");
            audio.PlayOneShot(moving, 1.0f);
            
        }else if(Input.GetKeyDown(KeyCode.A) && !gameOver && transform.position.x>limitXMin){
            transform.Translate(Vector3.left);
            //playerAnim.SetTrigger("Jump_trig");
            audio.PlayOneShot(moving, 1.0f);
            
        }else if(Input.GetKeyDown(KeyCode.D) && !gameOver && transform.position.x<limitXMax){
            transform.Translate(Vector3.right);
            //playerAnim.SetTrigger("Jump_trig");
            audio.PlayOneShot(moving, 1.0f);
        
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Vehicle")){
            crash.Play();
            //Si la vida llega a 0, que el jugador desaparezca, no hay animación de muerte
        }else if(collision.gameObject.CompareTag("Food")){
            Destroy(collision.gameObject);
            food.Play();
        }
        
        if(collision.gameObject.CompareTag("River1") || collision.gameObject.CompareTag("River2")){
            //Player dies 
        }
    }
}
