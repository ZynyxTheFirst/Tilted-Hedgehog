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
        //I player prefs s�tts hur m�nga levlar som �r uppl�sta, ifall uppl�sta levlar �r null
        //kommer den automatiskt s�tta den f�rsta leveln till ol�st
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        //S�tter alla knappar i level select till l�st
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            buttons[i].interactable = false;
        }

        //Kollar vilka levlar som �r uppl�sta och s�tter korresponderande knappar till ol�st.
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
