using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LevelAccessibility : MonoBehaviour
{
    public Text accessibilityCondition2;
    public Text accessibilityCondition3;
    /*
        Creating a point based level passage using PlayerPrefs utility of Unity.
        See MainMenu script for a detailed explanation.
    */
    private void Start()
    {
#if UNITY_EDITOR
        if (!PlayerPrefs.HasKey("2"))
        {
            accessibilityCondition2.enabled = false;
        } 
        else
        {
            accessibilityCondition2.enabled = true;
        }
            
        if (!PlayerPrefs.HasKey("3"))
        {
            accessibilityCondition3.enabled = false;
        }
        else
        {
            accessibilityCondition3.enabled = true;
        }
            
        if(!PlayerPrefs.HasKey("2") && !PlayerPrefs.HasKey("3"))
        {   
            if(PlayerPrefs.GetInt("MessageShown",0) == 0)
            {
                EditorUtility.DisplayDialog("CONGRATS", "You have unlocked all of the levels", "OK");
                PlayerPrefs.SetInt("MessageShown", 1);
            }
            
        }
#endif

    }
}
