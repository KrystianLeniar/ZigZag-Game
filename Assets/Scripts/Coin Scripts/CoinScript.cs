using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Ball")
        {
            GameplayController.instance.PlayCollectableSounds();
            ScoreTextScript.coinsAmount += 1;
            gameObject.SetActive(false);
        }
    }
}
