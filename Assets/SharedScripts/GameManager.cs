using UnityEngine;
using UnityEngine.SceneManagement;

// was MonoBehaviour
public class GameManager : MonoBehaviour
{
    /*  Implementing the infrastructure to make the GameManager unique throughout
        the game's lifeline to avoid any conflicts.
    */

    public static float remainingLives = 3f;
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

    public void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("gamemanager SA bitti");
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
        ///toMainMenu();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Score.playerScore = 0;
        remainingLives = 3f;

    }
}
