using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoranScript : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, GM.vertVel, 6);

        if ((Input.GetKeyDown (moveL)) && (laneNum>2) && (controlLocked == "n"))
        {
            horizVel = -2.5f;
            StartCoroutine (stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }
        if ((Input.GetKeyDown (moveR)) && (laneNum<4) && (controlLocked == "n"))
        {
            horizVel = 2.5f;
            StartCoroutine (stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lethal")
        {
            Destroy (gameObject);
            GM.lvlCompStatus = "fail";
        }
        if ((other.gameObject.name == "Bonus de vitesse") || (other.gameObject.name == "Particle System"))
        {
            Destroy (other.gameObject);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "RampColiderEnter")
        {
            GM.vertVel = 2.5f;
        }
        if (other.gameObject.name == "RampColiderExit")
        {
            GM.vertVel = 0;
        }
        if (other.gameObject.name == "exit")
        {
            SceneManager.LoadScene ("Level 2");
        }
        if (other.gameObject.tag == "coin")
        {
            Destroy (other.gameObject);
            GM.coinTotal += 1;
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds (1f);
        horizVel = 0;
        controlLocked = "n";
    }
}