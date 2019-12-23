using System.Collections;
using UnityEngine;

// was MonoBehaviour
public class GameManager
{
    /*  Implementing the infrastructure to make the GameManager unique throughout
        the game's lifeline to avoid any conflicts.
    */


    private new GameObject gameObject;

    private static GameManager myInstance;
    public static GameManager GetInstance
    {
        get
        {
            if (myInstance == null)
            {
                myInstance = new GameManager
                {
                    gameObject = new GameObject("_gameManager")
                };
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
}
