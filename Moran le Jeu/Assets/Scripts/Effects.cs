using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour

{
    void Update()
    {
        // On fait tourner le "coin".
        if (gameObject.tag == "coin")
        {
            transform.Rotate (0.3f, 0, 0);
        }

        // On fait tourner le "bonus".
        if (gameObject.tag == "bonus")
        {
            transform.Rotate (0.3f, 0, 0);
        }
    }
}