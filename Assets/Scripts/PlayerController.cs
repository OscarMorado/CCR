using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip moving;
    public AudioClip nextLevelSound;
    private Rigidbody playerRb;
    private AudioSource audioeffects;
    private Animator playerAnim;
    public ParticleSystem winParticle;
    private ScoreManager scoreManagerScript;//score variable
    public Vector3 startPosition;
    //limits:
    private float limitZMax = -710.0f;
    private float limitZMin = -838.0f;
    private float limitXMax = 399.0f;
    private float limitXMin = 301.0f;
    public bool isOnRiver;
    public bool gameOver = false;
    public bool nextStage = false;//Booleano para determinar si se alcanzo la meta
    public ParticleSystem food;
    public ParticleSystem death;
    public ParticleSystem crash;
    private float lastPositionZ;
    // Start is called before the first frame update
    void Start()
    {
        lastPositionZ=transform.position.z;
        startPosition = new Vector3(349.0727f,0,-838.4476f);//posicion inicial del player
        transform.position=startPosition;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioeffects = GetComponent<AudioSource>();
        scoreManagerScript = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !gameOver && transform.position.z<limitZMax){   
            transform.Translate(Vector3.forward);//avanzar 1 unidad en z
            if(transform.position.z-lastPositionZ>=1){//cada que se presiona la w debe aumentar su posicion en z para sumar
                scoreManagerScript.score+=1;
                lastPositionZ=transform.position.z;
            }
            //playerAnim.SetTrigger("Jump_trig");
            audioeffects.PlayOneShot(moving, 1.0f);
        }else if(Input.GetKeyDown(KeyCode.S) && !gameOver && transform.position.z>limitZMin){
            scoreManagerScript.score-=2; //Se le resta puntaje para que no se puedan farmear puntos
            transform.Translate(Vector3.back);
            //playerAnim.SetTrigger("Jump_trig");
            audioeffects.PlayOneShot(moving, 1.0f);
            
        }else if(Input.GetKeyDown(KeyCode.A) && !gameOver && transform.position.x>limitXMin){
            transform.Translate(Vector3.left);
            //playerAnim.SetTrigger("Jump_trig");
            audioeffects.PlayOneShot(moving, 1.0f);
            
        }else if(Input.GetKeyDown(KeyCode.D) && !gameOver && transform.position.x<limitXMax){
            transform.Translate(Vector3.right);
            //playerAnim.SetTrigger("Jump_trig");
            audioeffects.PlayOneShot(moving, 1.0f);
        
        }
    }

    public void resetPosition(){
        scoreManagerScript.lastScore=scoreManagerScript.score;
        scoreManagerScript.score=0;
        transform.position=startPosition;//regresa a la posicion inicial al player
        lastPositionZ=startPosition.z;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Vehicle")){
            crash.Play();
            resetPosition();
            scoreManagerScript.heartCounter -= 1;
            //Si la vida llega a 0, que el jugador desaparezca, no hay animación de muerte
        }else if(collision.gameObject.CompareTag("Food")){
            Destroy(collision.gameObject);
            food.Play();
            scoreManagerScript.heartCounter += 1;
            ScoreManager.time -= 3;
        }else if (collision.gameObject.CompareTag("GroundIsland")){//Condicion que determina la victoria
            nextStage = true; //Variable bool para ir al siguiente nivel
            audioeffects.PlayOneShot(nextLevelSound, 1.0f);//Cancion cuando se alanza el objetivo
            Debug.Log("Alcanzaste la meta");
            playerAnim.SetBool("Win_b", true);//Animacion
            playerAnim.SetInteger("WinType_int",1);
            winParticle.Play();

            if(nextStage == true){
                SceneManager.LoadScene("Level2");
                scoreManagerScript.heartCounter = 5;
                ScoreManager.time = 150; //Más difícil, más tiempo
                scoreManagerScript.HeartDisappear();
            }
        }

        if (collision.gameObject.CompareTag("Construction")){  //Si entra a la zona de construcción, perderá una vida y tiempo
            resetPosition();
            scoreManagerScript.heartCounter -= 1;
            ScoreManager.time -=5;
        }        
    }
}
