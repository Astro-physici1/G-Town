using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;
    public static string lvlCompStatus = "";
    public Transform prefabSafe;
    public Transform prefab1;
    public Transform prefab2;
    public float zScenePos = 36.5f;

    // Start is called before the first frame update
    void Start()
    {
         if (zScenePos < 200)
        {
            Instantiate (prefab2, new Vector3 (0, 0, 36.5f), prefabSafe.rotation);
            zScenePos += 66.5f;
            Instantiate (prefabSafe, new Vector3 (0, 0, 73), prefabSafe.rotation);
            zScenePos += 13;
        }
    }

    // Update is called once per frame
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
    }
}