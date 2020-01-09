using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text remainingBulletData;
    public Text remainingGrenadeData;
    public Text remainingLivesData;
    public Text scoreData;
    public static int playerScore = 0;

    /*
      Gives information about the UI elemets;
        -> How many bullet/grenade/lifes left?
        -> How much point did the player gathered?
     */
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        remainingLivesData.text = GameManager.remainingLives.ToString();
        scoreData.text = playerScore.ToString();
        remainingBulletData.text = GameManager.remainingBullets.ToString();
        remainingGrenadeData.text = GameManager.remainingBombs.ToString();

    }

}

