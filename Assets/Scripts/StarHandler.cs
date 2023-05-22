using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarHandler : MonoBehaviour
{
    //public int amountCollected;
    public Sprite starCollected;
    public GameObject[] starsPickup;

    private string currentLevelStars;
    

    void Start()
    {
        currentLevelStars = "StarsCollected" + SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i <= PlayerPrefs.GetInt(currentLevelStars); i++)
        {
            if(starsPickup[i].GetComponent<PickupStar>().IsCollected()){
                starsPickup[i].SetActive(false);
            }
            
        }
    }
}
