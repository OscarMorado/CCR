using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip moving;
    private Rigidbody playerRb;
    private AudioSource audio;
    private Animator playerAnim;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !gameOver){
            transform.Translate(Vector3.forward);
            //playerAnim.SetTrigger("Jump_trig");
            audio.PlayOneShot(moving, 1.0f);
        }else if(Input.GetKeyDown(KeyCode.S) && !gameOver){
            transform.Translate(Vector3.back);
            //playerAnim.SetTrigger("Jump_trig");
            audio.PlayOneShot(moving, 1.0f);
        }else if(Input.GetKeyDown(KeyCode.A) && !gameOver){
            transform.Translate(Vector3.left);
            //playerAnim.SetTrigger("Jump_trig");
            audio.PlayOneShot(moving, 1.0f);
        }else if(Input.GetKeyDown(KeyCode.D) && !gameOver){
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
