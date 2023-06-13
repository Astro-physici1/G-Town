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

    // Start is called before the first frame update
    void Start()
    {
        
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