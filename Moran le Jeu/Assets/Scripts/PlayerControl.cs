using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{
//----Variables------------------------------------------------------------------
    private float speedDepl = 25.0f;
    private float horizVel = 0.0f; 
    private float VertVel;
    public KeyCode moveL;
    public KeyCode moveR;
    private int laneNum = 2;
    private float timer = 0.0f;
    private Rigidbody rb;

//-------------------------------------------------------------------------------
    void Start()
    {
        
    }

//-------------------------------------------------------------------------------
    void Update()
    {
        ApplyPlayerMovement();
        ApplyTempsEtVitesse();
        ApplyGravity();
    }

//-------------------------------------------------------------------------------
    void ApplyPlayerMovement()
    {
        // On donne accès au joueur de bouger de gauche à droite selon sa position (left, middle, right).
        GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, VertVel, speedDepl);

        if ((Input.GetKeyDown (moveL)) && (laneNum>=2))
        {
            if (transform.position.x == 0.0f)
            {
                transform.position = new Vector3 (-0.00000001f, transform.position.y, transform.position.z);
            }
            horizVel = -5.0f;
            laneNum -= 1;
        }
        if ((Input.GetKeyDown (moveR)) && (laneNum<=2))
        {
            if (transform.position.x == 0.0f)
            {
                transform.position = new Vector3 (-0.00000001f, transform.position.y, transform.position.z);
            }
            horizVel = 5.0f;
            laneNum += 1;
        }

        // On empêche le joueur de sortir de la zone de jeu en établissant des limites à ne pas dépasser.
        if (transform.position.x < -2.5f)
        {
            transform.position = new Vector3 (-2.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 2.5f)
        {
            transform.position = new Vector3 (2.5f, transform.position.y, transform.position.z);
        }

        // On stop le joueur une fois arrivé à la valeur x = 0 (middle).
        if ((laneNum == 2) && (horizVel == -5.0f))
        {
            if (transform.position.x < 0)
            {
                horizVel = 0.0f;
                transform.position = new Vector3 (0.0f, transform.position.y, transform.position.z);
            }
        }
        if ((laneNum == 2) && (horizVel == 5.0f))
        {
            if (transform.position.x > 0)
            {
                horizVel = 0.0f;
                transform.position = new Vector3 (0.0f, transform.position.y, transform.position.z);
            }
        }
    }

//-------------------------------------------------------------------------------
    void ApplyTempsEtVitesse()
    {
        // On attend un certain temp avant d'executer l'instruction qui fait avance de plus en plus vite.
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            timer = 0;
            speedDepl += 0.5f;
        }
    
        // On stop la prise de vitesse au bout d'une certaine vitesse donnée.
        if (speedDepl >= 25.0f)
        {
            speedDepl = 25.0f;
        }
    }

//-------------------------------------------------------------------------------
void ApplyGravity()
{  
    // On met une valeur à la gravité.
    rb = GetComponent<Rigidbody>();
    rb.AddForce(Vector3.down * 20f, ForceMode.Acceleration);
}

//-------------------------------------------------------------------------------
    void OnCollisionEnter(Collision other)
    {
        // Permet de tuer le joueur lorsqu'il rentre en contact avec le tag "lethal".
        if (other.gameObject.tag == "Lethal")
        {
            Destroy (gameObject);
            GM.lvlCompStatus = "fail";
        }
    }

//-------------------------------------------------------------------------------
    void OnTriggerEnter (Collider other)
    {
        // On détruit le coin quand il y a un contact avec le joueur.
        if (other.gameObject.tag == "coin")
        {
            Destroy (other.gameObject);
            GM.coinTotal += 1;
        }

        // On détruit le bonus quand il y a un contact avec le joueur.
        if (other.gameObject.tag == "bonus")
        {
            Destroy (other.gameObject);
            speedDepl = 15;
            StartCoroutine (finDuBonus());
        }
        // On monte le joueur sur l'estrade.
        if (other.gameObject.tag == "estrade")
        {
            VertVel = 20f;
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "estrade")
        {
            VertVel = 0f;
        }
    }

//-------------------------------------------------------------------------------
    IEnumerator finDuBonus()
    {
        yield return new WaitForSeconds (10);
        speedDepl += 5;
    }
}