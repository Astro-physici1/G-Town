using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Regroupement des Input pour bouger
        horizontalInput = Input.GetAxis ("Horizontal");
        forwardInput = Input.GetAxis ("Vertical");

        // On fait avancer le véhicules en fonction de la variable "speed"
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // On fait tourner le Véhicule en fonction de la variable "turnSpeed"
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}