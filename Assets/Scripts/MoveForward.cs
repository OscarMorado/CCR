using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5.0f;
    private float initXPos = 270.0f;
    private float endXPos = 430.0f;
    void Start()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        int selectedCharachter = PlayerPrefs.GetInt("selectedCharacter");
        speed += (selectedCharachter + 1) * 7;
        Debug.Log("Velocidad: " + speed);
    }

    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
        /*if(transform.position.x>endXPos||transform.position.x<initXPos){//cuando se sale del rango del mapa
            Destroy(gameObject);
        }*/
        if (transform.position.y < -1)
        {//cuando se sale del rango del mapa
            Destroy(gameObject);
        }
    }


    

}
