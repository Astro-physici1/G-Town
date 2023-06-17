using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int spawnRangeX = 20;
    private int spawnRangeY = 18;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("spawnRandomAnimals", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    void spawnRandomAnimals() 
    {
        int animalIndex = Random.Range (0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3 (Random.Range (-spawnRangeY, spawnRangeY), 0, spawnRangeX);
        Instantiate (animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}