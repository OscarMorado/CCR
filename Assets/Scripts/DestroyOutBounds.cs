using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    private float rightBound = 400.0f;
    private float leftBound = 300.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightBound){
            Destroy(gameObject);
        }else if(transform.position.x < leftBound){
            Destroy(gameObject);
        }
    }
}
