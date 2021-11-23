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
    public Animator playerAnim;
    public ParticleSystem winParticle;
    //scripts
    private ScoreManager scoreManagerScript;//score variable
     private GameManager GameManagerScript;


    Vector3 startPosition1 = new Vector3(347.13f, .03591731f, -880.5236f);
    Vector3 startPosition2 = new Vector3(349.1303f, .3118293f, -730.79f);
    //limits:
    private float limitZMax = -710.0f;
    private float limitZMin = -880.0f;
    private float limitXMax = 414.0f;
    private float limitXMin = 286.0f;
    public bool isOnRiver;
    public bool nextStage = false;//Booleano para determinar si se alcanzo la meta
    public ParticleSystem food;
    public ParticleSystem death;
    public ParticleSystem crash;
    private float lastPositionZ;

    public GameObject start1;
    public GameObject start2;
    private Vector3 startPosition;
    

    //teclas del movimiento del player
    private bool w;//frente
    private bool s;//atras
    private bool a;//izquierda
    private bool d;//derecha


    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        lastPositionZ=transform.position.z;
        if(scene.name == "Level1"){
            transform.position = startPosition1;
        }else if(scene.name == "Level2"){
            transform.position = startPosition2;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioeffects = GetComponent<AudioSource>();
        scoreManagerScript = GameObject.Find("Score").GetComponent<ScoreManager>();
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

   
    void Update()
    {
        w=Input.GetKeyDown(KeyCode.W);
        s=Input.GetKeyDown(KeyCode.S);
        a=Input.GetKeyDown(KeyCode.A);
        d=Input.GetKeyDown(KeyCode.D);

    
        if(w && GameManagerScript.gameActive && transform.position.z<limitZMax){   
            playerAnim.Play("jump");
            transform.Translate(Vector3.forward);//avanzar 1 unidad en z
            if(transform.position.z-lastPositionZ>=1){//cada que se presiona la w debe aumentar su posicion en z para sumar
                scoreManagerScript.score+=1;
                lastPositionZ=transform.position.z;
            }

            audioeffects.PlayOneShot(moving, 1.0f);
        }else if(s && GameManagerScript.gameActive && transform.position.z>limitZMin){
            playerAnim.Play("backwards");
            scoreManagerScript.score-=2; //Se le resta puntaje para que no se puedan farmear puntos
            transform.Translate(Vector3.back);
            audioeffects.PlayOneShot(moving, 1.0f);
            
        }else if(a && GameManagerScript.gameActive && transform.position.x>limitXMin){
            playerAnim.Play("left");
            transform.Translate(Vector3.left);
            audioeffects.PlayOneShot(moving, 1.0f);
            
        }else if(d && GameManagerScript.gameActive && transform.position.x<limitXMax){
            playerAnim.Play("right");
            transform.Translate(Vector3.right);
            audioeffects.PlayOneShot(moving, 1.0f);
        
        }
    }

    public void resetPosition(){
        Scene scene = SceneManager.GetActiveScene();
        scoreManagerScript.lastScore=scoreManagerScript.score;
        scoreManagerScript.score=0;
        if(scene.name == "Level1"){
            transform.position = startPosition1;
        }else if(scene.name == "Level2"){
            transform.position = startPosition2;
        }
        lastPositionZ = transform.position.z;
    }

    private void OnCollisionEnter(Collision collision){
        Scene scene = SceneManager.GetActiveScene();
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
        }else if (collision.gameObject.CompareTag("GroundIsland") && scene.name == "Level1"){ //llego a la meta nivel 1
            audioeffects.PlayOneShot(nextLevelSound, 1.0f); //Cancion cuando se alanza el objetivo
            winParticle.Play();
            GameManagerScript.SetToNextLevel(true);
        }else if (collision.gameObject.CompareTag("FinalGoal") && scene.name == "Level2"){ //llego a la meta final
            audioeffects.PlayOneShot(nextLevelSound, 1.0f); //Cancion cuando se alanza el objetivo
            playerAnim.Play("chikenDance");
            winParticle.Play();
            GameManagerScript.FinalGoal();
        }

        if (collision.gameObject.CompareTag("Construction")){  //Si entra a la zona de construcción, perderá una vida y tiempo
            resetPosition();
            scoreManagerScript.heartCounter -= 1;
            ScoreManager.time -=5;
        }
        IEnumerator trap(){
            yield return new WaitForSecondsRealtime(1.0f);
            if(collision.gameObject.CompareTag("GrassTrap")){
                ScoreManager.time -=2;
            }
        }
        StartCoroutine(trap());  
    }
}
