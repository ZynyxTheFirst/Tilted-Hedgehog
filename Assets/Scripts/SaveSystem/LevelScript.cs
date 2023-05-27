using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        //Om spelaren g�r in i m�let h�mtar scriptet den aktiva scenen
        if (collision.CompareTag("Player")) {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;

            //Om den aktiva scenen inte �r uppl�st, l�ses den upp
            if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked")) {
                PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
            }

            Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelsUnlocked") + "UNLOCKED");
        }
    }

}
