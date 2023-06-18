using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour
{
//----Variables------------------------------------------------------------------
    // Pour détruire les prefabs désormais inutiles derrière.
    private Vector3 offset = new Vector3 (0, 0, -73.0f);
    public GameObject joueur;

//-------------------------------------------------------------------------------
    void Start()
    {
        
    }

//-------------------------------------------------------------------------------
    void Update()
    {
        // Détruit les prefabs derrière = le trigger suit le joueur.
        transform.position = joueur.transform.position + offset;
    }

//-------------------------------------------------------------------------------
    void OnTriggerEnter (Collider other) 
    {
        Destroy (other.gameObject);
    }
}
