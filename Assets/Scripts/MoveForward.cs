using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    private float startDelay = 1.0f;
    //private float speed = 5.0f;
    void Start()
    {
        Invoke("Speed", startDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Speed(){
        int speed = Random.Range(10, 20);
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }

    

}
