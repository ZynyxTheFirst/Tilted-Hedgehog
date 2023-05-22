using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarHandler : MonoBehaviour
{
    //public int amountCollected;
    public Sprite starCollected;
    public GameObject[] starsUI;
    public GameObject[] starsPickup;
    public bool resetAllPlayerPref;

    private string currentLevelStars;
    

    void Start()
    {
        if(resetAllPlayerPref){
            PlayerPrefs.DeleteAll();
        }
        currentLevelStars = "StarsCollected" + SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i <= PlayerPrefs.GetInt(currentLevelStars); i++)
        {
            if(starsPickup[i].GetComponent<PickupStar>().IsCollected()){
                starsPickup[i].SetActive(false);
            }
            
        }
    }
}
