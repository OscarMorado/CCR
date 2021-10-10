using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public GameObject[] islandPrefabs;
    public GameObject[] islandPrefabs2;
    private float[] roadSpawnX = new float[8] {394f, 307.1f, 394f, 307.1f, 394f, 307.1f, 307.1f, 394f};
    private float[] roadSpawnZ = new float[8] {-835.68f, -832.28f, -809.81f, -806.56f, -784.37f, -780.9f, -758.95f, -755.45f};
    private float startDelay = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        float spawnInterval = Random.Range(3, 6);
        InvokeRepeating("SpawnVehicles", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnVehicles(){
        Vector3 spawnPos1 = new Vector3(roadSpawnX[0], transform.position.y,roadSpawnZ[0]);
        int vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos1, vehiclePrefabs[vehicleIndex].transform.rotation);

        Vector3 spawnPos2 = new Vector3(roadSpawnX[1], transform.position.y,roadSpawnZ[1]);
        vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos2, vehiclePrefabs[vehicleIndex].transform.rotation);

        Vector3 spawnPos3 = new Vector3(roadSpawnX[2], transform.position.y,roadSpawnZ[2]);
        vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos3, vehiclePrefabs[vehicleIndex].transform.rotation);

        Vector3 spawnPos4 = new Vector3(roadSpawnX[3], transform.position.y,roadSpawnZ[3]);
        vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos3, vehiclePrefabs[vehicleIndex].transform.rotation);

        Vector3 spawnPos5 = new Vector3(roadSpawnX[4], transform.position.y,roadSpawnZ[4]);
        vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos5, vehiclePrefabs[vehicleIndex].transform.rotation);

        Vector3 spawnPos6 = new Vector3(roadSpawnX[5], transform.position.y,roadSpawnZ[5]);
        vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos6, vehiclePrefabs[vehicleIndex].transform.rotation);

        Vector3 spawnPos7 = new Vector3(roadSpawnX[6], transform.position.y,roadSpawnZ[6]);
        vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos7, vehiclePrefabs[vehicleIndex].transform.rotation);

        Vector3 spawnPos8 = new Vector3(roadSpawnX[7], transform.position.y,roadSpawnZ[7]);
        vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos8, vehiclePrefabs[vehicleIndex].transform.rotation);
    }

    void SpawnRiver(){

        Vector3 spawnRiver1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        int islandIndex = Random.Range(0, islandPrefabs.Length);
        Instantiate(islandPrefabs[islandIndex], spawnRiver1, islandPrefabs[islandIndex].transform.rotation);

        Vector3 spawnRiver2 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        int islandIndex2 = Random.Range(0, islandPrefabs2.Length);
        Instantiate(islandPrefabs2[islandIndex2], spawnRiver1, islandPrefabs2[islandIndex2].transform.rotation);
    }

    
}
