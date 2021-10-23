using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    private float speed = 2.0f;
    private float  initXPos;
    private float endXPos;
    private bool aux=true;

    void Start()
    {
        initXPos= transform.position.x- 5.0f;
        endXPos= transform.position.x+ 5.0f;
        transform.position= initPosition();
    }


    void Update()
    {
        
        if(transform.position.x<=initXPos){
            aux=true;
        }else if(transform.position.x>=endXPos){
            aux=false;     
        }

        if(aux){
            transform.Translate(Vector3.right*Time.deltaTime*speed);
        }else{
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
    }

    Vector3 initPosition(){
        return new Vector3(initXPos,transform.position.y,transform.position.z);
    }

}
