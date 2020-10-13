using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public Text coins;
    public static int coinsAmount;

    private void Start()
    {
        coins = GetComponent<Text>();
    }

    private void Update()
    {
        coins.text = coinsAmount.ToString();
    }
}
