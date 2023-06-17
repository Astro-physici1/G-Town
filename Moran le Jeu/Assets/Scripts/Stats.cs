using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour

{
    void Update()
    {
        // On fait le total des "coins" récupérés lors de la partie.
        if (gameObject.name == "TotalDeCoins")
        {
            GetComponent<TextMesh>().text = "Total coins : " + GM.coinTotal;
        }

        // On compte le temps de la partie.
        if (gameObject.name == "TotalDeTemps")
        {
            GetComponent<TextMesh>().text = "Temps : " + GM.timeTotal;
        }
    }
}