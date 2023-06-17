using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour

{
    public float speedDepl = 5;
    public float horizVel = 0.0f; 
    public KeyCode moveL;
    public KeyCode moveR;
    public int laneNum = 2;

//-------------------------------------------------------------------------------
    void Start()
    {
        
    }

//-------------------------------------------------------------------------------
    void Update()
    {
        // On donne accès au joueur de bouger de gauche à droite selon sa position (left, middle, right).
        GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, 0, speedDepl);

        if ((Input.GetKeyDown (moveL)) && (laneNum>=2))
        {
            horizVel = -2.5f;
            laneNum -= 1;
        }
        if ((Input.GetKeyDown (moveR)) && (laneNum<=2))
        {
            horizVel = 2.5f;
            laneNum += 1;
        }

        // On empêche le joueur de sortir de la zone de jeu en établissant des limites à ne pas dépasser.
        if (transform.position.x < -2.5f)
        {
            transform.position = new Vector3 (-2.5f, 1.1f, transform.position.z);
        }
        if (transform.position.x > 2.5f)
        {
            transform.position = new Vector3 (2.5f, 1.1f, transform.position.z);
        }
    }
}