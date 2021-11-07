using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 5.0f;
    private float initXPos = 290.0f;
    private float endXPos = 410.0f;
    void Start()
    {
     transform.Translate(Vector3.right*Time.deltaTime*speed);
    }

    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
        if(transform.position.x>endXPos||transform.position.x<initXPos){//cuando se sale del rango del mapa
            Destroy(gameObject);
        }
    }


    

}
