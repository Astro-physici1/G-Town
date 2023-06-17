using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabs : MonoBehaviour
{
    public GameObject[] parcourPrefabs;
    public float distancePrefabs

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.S))
        {
            spawnRandomPrefabs();
        }
    }

    void spawnRandomPrefabs()
    {
        int prefabsIndex = RandomPrefabs.Range (0, parcourPrefabs.length);
        Vector3 spawnPosition = new Vector3 (0, 0, )
    }
}
