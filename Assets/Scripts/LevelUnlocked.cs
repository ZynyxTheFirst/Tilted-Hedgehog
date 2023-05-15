using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocked : MonoBehaviour
{
    public Button[] levelButtons; // Array of buttons for each level
    public int levelsUnlocked = 1; // Number of levels currently unlocked

    void Start()
    {
        // Get the number of levels currently unlocked from PlayerPrefs
        int levelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked");

        // Loop through each level button and check if it should be unlocked
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < levelsUnlocked)
            {
                // Level is unlocked, enable button
                levelButtons[i].interactable = true;
            }
            else
            {
                // Level is locked, disable button
                levelButtons[i].interactable = false;
            }
        }
    }
}
