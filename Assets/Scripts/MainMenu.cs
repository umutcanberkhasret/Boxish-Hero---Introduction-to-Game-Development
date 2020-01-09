using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

using System;
/*
    Level Access: It is controlled by using PlayerPrefs to check if the user has purchased the level's access before.
    PlayerPrefs.SetInt("LevelNumber", 1 for yes - 0 for no)
    
    How do we set Level's cost?
    It is controlled again by "PlayerPrefs". An example usage;
    PlayerPrefs("LevelNumber", "Cost you would like to set")
    
    Later on, it can be retrieved an checked by: PlayerPrefs.GetInt("LevelNumber") to see whether the cost is affordable by what you have or not.
 */
public class MainMenu : MonoBehaviour
{
    public Button Level2, Level3;
    private void Start()
    {
        // If we have defined "2" and "3" level costs directly in Start(), no matter if you have purchased again or not
        // it would be setting the costs at every iteration where the game launches.
        // So; FirstRun is created whether to deal with this check.
        if (PlayerPrefs.GetInt("FirstRun", 1) == 1)
        {
            PlayerPrefs.SetInt("2", 300);
            PlayerPrefs.SetInt("3", 800);
            PlayerPrefs.SetInt("FirstRun", 0);
        }
    }
    public void buyLevelAccess(int level)
    {
        string levelNumber = level.ToString();

        // Purchasing Level Access
        if (PlayerPrefs.HasKey(levelNumber))
        {
           if(PlayerPrefs.GetFloat("Score") >= PlayerPrefs.GetInt(levelNumber))
            {
                float newCumulativeScore = PlayerPrefs.GetFloat("Score") - PlayerPrefs.GetInt(levelNumber);
                PlayerPrefs.SetFloat("Score", newCumulativeScore);
                PlayerPrefs.DeleteKey(levelNumber);
                EditorUtility.DisplayDialog("AMAZING", "Give another click to see the level.. ", "OK");
            }
            else
            {
                EditorUtility.DisplayDialog("OOPS", "Looks like you do not have enough points to gain access. You shall hunt more", "OK");
            }
        }
        
        else
        {
            // Reason why we are adding +2 here is because of the index number.
            // Check Build Settings for initial scene order
            LoadLevel(level);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level+2);
    }

    public void startOver()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
        EditorUtility.DisplayDialog("SUCCESS", "All the data related with collected points and purchased levels are deleted.", "OK");

    }

    public void howToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {  
        Application.Quit();
    }

}

