using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardFast : MonoBehaviour
{
    private float speed = 50.0f;
    private float initXPos = 290.0f;
    private float endXPos = 410.0f;
    public AudioClip movingSound;
    void Start()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.y < -1)
        {//cuando se sale del rango del mapa
            Destroy(gameObject);
        }
    }




}
