using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarManager : MonoBehaviour
{
    private VictoryScreen victoryScreen;
    private string levelIdentifier;

    private int starsCollected;

    void Start()
    {
        levelIdentifier = SceneManager.GetActiveScene().name;
        starsCollected = PlayerPrefs.GetInt(levelIdentifier + "StarsCollected", 0);

        // Sätter StarsCollected till 0 varje gång leveln laddas.
        //PlayerPrefs.SetInt(levelIdentifier + "StarsCollected", 0);
        /*
        if(starsCollected == 1){
            PlayerPrefs.SetInt(levelIdentifier + "StarsCollected", 1);
        }
        else if(starsCollected == 2){
            PlayerPrefs.SetInt(levelIdentifier + "StarsCollected", 2);
        }
        else if (starsCollected == 3)
        {
            PlayerPrefs.SetInt(levelIdentifier + "StarsCollected", 3);
        }
        */
        

    }

    public void CollectStar(string levelIdentifier)
    {

        // Öka antalet stjärnor för den specifika leveln.
        int starsCollected = PlayerPrefs.GetInt(levelIdentifier + "StarsCollected", 0);
        if(starsCollected < 3){
            starsCollected++;
        }
        PlayerPrefs.SetInt(levelIdentifier + "StarsCollected", starsCollected);
        PlayerPrefs.Save();

        // Find the VictoryScreen object for the specific level
        /*
        victoryScreen = GameObject.Find("VictoryScreen").GetComponent<VictoryScreen>();
        victoryScreen.UpdateStarSprites(starsCollected);
        */
        Debug.Log("CollectStar() (StarManager)");
    }

    public int GetStarsCollected(){
        return starsCollected;
    }

    public string GetLevelIdentifier()
    {
        return levelIdentifier;
    }
    
}
