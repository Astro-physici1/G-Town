using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabs : MonoBehaviour
{
//----Variables------------------------------------------------------------------
    public GameObject[] parcourPrefabsDepart;
    public GameObject[] parcourPrefabs;
    private float distancePrefabs = 36.5f;
    private float distancePrefabsSafe = 0.0f;
    private float distanceDepartPrefabSafe = 36.5f; // Bien différencier avec le Depart !
    public GameObject prefabSafe;

    // Pour faire spawn les prefabs au fur et à mesure de la partie.
    private float distanceJoueurCondition = 0.0f;
    public GameObject joueur;

//-------------------------------------------------------------------------------
    void Start()
    {
        spawnRandomPrefabsDepart();
    }

//-------------------------------------------------------------------------------
    void Update()
    {
       if (joueur.transform.position.z > distanceJoueurCondition)
       {
            spawnRandomPrefabs();
            distanceJoueurCondition += 73.0f;
       }
    }

//-------------------------------------------------------------------------------
    void spawnRandomPrefabs() // Utlisé pour le reste de la partie.
    {
        // On créé une fonction Random pour que les prefabs soit aléatoires.
        int prefabsIndex = Random.Range(0, parcourPrefabs.Length);
        // On écrit la distance correspondante au prefab créé.
        distancePrefabs += 73.0f;
        distancePrefabsSafe = distancePrefabs + 36.5f;
        Vector3 spawnPosition = new Vector3 (0, 0, distancePrefabs);
        Vector3 spawnPositionPrefabSafe = new Vector3 (0, 0, distancePrefabsSafe);

        // On créé le prefab sur la scene.
        Instantiate (parcourPrefabs[prefabsIndex], spawnPosition, parcourPrefabs[prefabsIndex].transform.rotation);
        Instantiate (prefabSafe, spawnPositionPrefabSafe, prefabSafe.transform.rotation);
    }

    void spawnRandomPrefabsDepart() // Utilisé uniquement au début pour plus d'originalité par la suite.
    {
        // On créé une fonction Random pour que les prefabs soit aléatoires.
        int prefabsDepartIndex = Random.Range(0, parcourPrefabsDepart.Length);
        // On écrit la distance correspondante au prefab créé.
        Vector3 spawnPositionDepart = new Vector3 (0, 0, distanceDepartPrefabSafe);
        Vector3 spawnPositionDepartPrefabSafe = new Vector3 (0, 0, distanceDepartPrefabSafe += 36.5f);

        // On créé le prefab sur la scene.
        Instantiate (parcourPrefabsDepart[prefabsDepartIndex], spawnPositionDepart,
        parcourPrefabsDepart[prefabsDepartIndex].transform.rotation);
        Instantiate (prefabSafe, spawnPositionDepartPrefabSafe, prefabSafe.transform.rotation);
    }
}