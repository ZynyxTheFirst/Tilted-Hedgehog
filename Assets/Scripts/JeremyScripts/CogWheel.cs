using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogWheel : MonoBehaviour
{
    public Image settingsScreen;
    public GameObject canvas;

    void Start()
    {
        settingsScreen.transform.localScale = Vector2.zero;
    }

    // Toggle the settings menu.
    public void toggle(){
        
        if(settingsScreen.transform.localScale.Equals(Vector2.one)){
            settingsScreen.transform.LeanScale(Vector2.zero, 0.5f).setEaseInBack();
        }
        else if(settingsScreen.transform.localScale.Equals(Vector2.zero)){
            settingsScreen.transform.LeanScale(Vector2.one, 0.5f);
        }
    }
}
