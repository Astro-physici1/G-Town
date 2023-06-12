using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update() {
        GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, 0, 6);

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
            }
            if ((other.gameObject.name == "Bonus de vitesse") || (other.gameObject.name == "Particle System"))
            {
                Destroy (other.gameObject);
            }
        }

     IEnumerator stopSlide()
    {
        yield return new WaitForSeconds (1f);
        horizVel = 0;
        controlLocked = "n";
    }
}