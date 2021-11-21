using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviour
{
     public GameObject[] characterPrefab;
    public Transform spawnPoint;
    
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefab[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
