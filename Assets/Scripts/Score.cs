using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreData;
    public static int playerScore = 0;


    private void Start()
    {
        scoreData = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreData.text = playerScore.ToString();
    }
}
