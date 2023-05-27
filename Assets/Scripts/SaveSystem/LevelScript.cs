using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        //Om spelaren går in i målet hämtar scriptet den aktiva scenen
        if (collision.CompareTag("Player")) {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;

            //Om den aktiva scenen inte är upplåst, låses den upp
            if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked")) {
                PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
            }

            Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelsUnlocked") + "UNLOCKED");
        }
    }

}
