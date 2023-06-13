using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "coin")
        {
            transform.Rotate (0.3f, 0, 0);
        }
        if (gameObject.tag == "bonus")
        {
            transform.Rotate (0.3f, 0, 0);
        }
    }
}