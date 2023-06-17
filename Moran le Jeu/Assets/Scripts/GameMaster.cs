using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour

{
//----Variables------------------------------------------------------------------
    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;
    public static string lvlCompStatus = "";
    public Transform prefabSafe;
    public Transform prefab1;
    public Transform prefab2;
    public float zScenePos = 36.5f;

//-------------------------------------------------------------------------------
    void Start()
    {
       
    }

//-------------------------------------------------------------------------------
    void Update()
    {
        timeTotal += Time.deltaTime;
    
        if (lvlCompStatus == "fail")
        {
        waittoload += Time.deltaTime;
        }
        if (waittoload > 2)
        {
        SceneManager.LoadScene ("Level 2");
        }   

        // On place des prefabs sur la scene manuellement. On fait le parcour.
        while (zScenePos < 200)
        {
            Instantiate (prefab1, new Vector3 (0, 0, zScenePos), prefabSafe.rotation);
            zScenePos += 36.5f;
            Instantiate (prefabSafe, new Vector3 (0, 0, zScenePos), prefabSafe.rotation);
            zScenePos += 36.5f;
            Instantiate (prefab2, new Vector3 (0, 0, zScenePos), prefabSafe.rotation);
            zScenePos += 36.5f;
            Instantiate (prefabSafe, new Vector3 (0, 0, zScenePos), prefabSafe.rotation);
            zScenePos += 36.5f;
        }
    }
}