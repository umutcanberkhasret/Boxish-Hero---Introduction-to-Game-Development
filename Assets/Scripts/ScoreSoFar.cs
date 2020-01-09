using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreSoFar : MonoBehaviour
{
    public Text collectedScoreData;
    void Start()

    {   // PlayerPrefs.GetFloat("Score", defaultVal) - On the first run, it would display 0.
        collectedScoreData.text = PlayerPrefs.GetFloat("Score", 0).ToString();
    }
}
