using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float xRange = 18;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // On stoppe le Player sur l'axe x = -20 et 20
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3 (-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3 (xRange, transform.position.y, transform.position.z);
        }
        // On fait bouger le Player de gauche à droite
        horizontalInput = Input.GetAxis ("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown (KeyCode.Space))
        {
            Instantiate (projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}