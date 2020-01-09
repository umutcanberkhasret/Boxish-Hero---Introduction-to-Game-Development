using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Implementing the infrastructure to make the GameManager unique throughout
    // the game's lifeline to avoid any conflicts.


    public static float remainingLives = 3f;
    public static int remainingBombs = 3;
    public static int remainingBullets = 50;
    private new GameObject gameObject;

    private static GameManager myInstance;
    public static GameManager GetInstance
    {
        get
        {
            if (GameObject.Find("_gameManager") == null && myInstance == null)
            //if (myInstance == null)
            {
                myInstance = new GameManager
                {
                    gameObject = new GameObject("_gameManager")
                };
                myInstance.gameObject.AddComponent<GameManager>();
                myInstance.gameObject.AddComponent<InputController>();
            }
            return myInstance;
        }
    }

    // If we want to change the Input Controller, we only need to change it on the GameManager class. This is the flexibility we were mentioning on the InputController class.
    private InputController myInputController;
    public InputController InputController
    {
        get
        {
            if (myInputController == null)
            {
                myInputController = gameObject.GetComponent<InputController>();

            }
            return myInputController;

        }
    }

    public void EndGame()
    {
        Debug.Log("Game over..");
        remainingLives--;
        if (remainingLives > 0)
        {
            Restart();
        }
        else if (remainingLives == 0)
        {
            toMainMenu();
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        remainingBombs = 3;
        remainingBullets = 50;
    }

    public void toMainMenu()
    {
      
        SceneManager.LoadScene("MainMenu");
        // we are aware that the playerScore is accessible from the calculateGeneralPoints method as well. Whereas, since the next line of code will make the playerScore 0,
        // with this way of calculation we can expect to avoid unpleasent surprises
        calculateGeneralPoints(Inventory.playerScore);
        Inventory.playerScore = 0;
        remainingLives = 3f;
        remainingBombs = 3;
        remainingBullets = 50;

    }

    void calculateGeneralPoints(float sessionScore)
    {
        float tempValue = PlayerPrefs.GetFloat("Score");
        tempValue += sessionScore;
        PlayerPrefs.SetFloat("Score", tempValue);

    }

}
