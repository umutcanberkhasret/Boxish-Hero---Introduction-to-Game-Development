using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    Text remainingLivesData;
    // Start is called before the first frame update
    void Start()
    {
        remainingLivesData = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingLivesData.text = GameManager.remainingLives.ToString();
    }
}
