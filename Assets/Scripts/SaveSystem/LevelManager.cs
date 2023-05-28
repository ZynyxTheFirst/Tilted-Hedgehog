using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int levelsUnlocked = 1;
    public Button[] buttons;

    void Start() {
        //I player prefs sätts hur många levlar som är upplåsta, ifall upplåsta levlar är null
        //kommer den automatiskt sätta den första leveln till olåst
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        //Sätter alla knappar i level select till låst
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            buttons[i].interactable = false;
        }

        //Kollar vilka levlar som är upplåsta och sätter korresponderande knappar till olåst.
        for (int i = 0; i < levelsUnlocked; i++) {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            buttons[i].interactable = true;
        }
    }

    //Laddar leveln som skickas med som argument
    public void LoadLevel(int levelIndex) {
        SceneManager.LoadScene(levelIndex);
    }

}
