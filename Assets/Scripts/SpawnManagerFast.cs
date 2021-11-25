using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerFast : MonoBehaviour
{
    public GameObject[] auto;
    public bool twoWays = true;
    private int minTime = 1;
    private int maxTime = 4;
    private float spaceBetweenCars = 4.0f;//space between cars
    private float diffPosX = 82;//difference between initial and last position.



    void Start()
    {
        Vector3 spawn = new Vector3(transform.position.x - 15, transform.position.y - 1.6f, transform.position.z);
        StartCoroutine(ToLeft());//left road
        StartCoroutine(ToRight(spawn));//right road

    }

    IEnumerator ToRight(Vector3 spawn)
    {
        while (true)
        {
            int spawnInterval = Random.Range(minTime, maxTime);//random time
            yield return new WaitForSeconds(spawnInterval);
            SpawnObstacle(spawn, transform.rotation);//spawn the car
        }

    }

    IEnumerator ToLeft()
    {
        while (true)
        {
            int spawnInterval = Random.Range(minTime, maxTime);//random time
            yield return new WaitForSeconds(spawnInterval);
            Quaternion rotation = transform.rotation;//normal rotation 
            Vector3 toLeftPosition = new Vector3(transform.position.x + 20, transform.position.y - 1.6f, transform.position.z + spaceBetweenCars);//normal position but with space between the last road
            if (twoWays)
            {//when the road is two ways
                rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);//road rotation
                toLeftPosition = new Vector3(transform.position.x + diffPosX + 20, transform.position.y - 1.6f, transform.position.z + spaceBetweenCars);//starts to spawn in the other side
            }
            SpawnObstacle(toLeftPosition, rotation);
        }

    }

    void Update()
    {

    }

    void SpawnObstacle(Vector3 position, Quaternion rotation)
    {
        int RandomAuto = Random.Range(0, auto.Length);//generate a random auto
        Instantiate(auto[RandomAuto], position, rotation);

    }
}
