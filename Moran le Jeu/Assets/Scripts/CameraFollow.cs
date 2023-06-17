using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{
//----Variables------------------------------------------------------------------
    public GameObject player;
    private Vector3 offset = new Vector3 (0, 4.8f, -8.6f);

//-------------------------------------------------------------------------------
    void LateUpdate()
    {
        // On place la camera derrière le joueur.
        transform.position = player.transform. position + offset;
    }
}