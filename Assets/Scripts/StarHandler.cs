using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarHandler : MonoBehaviour
{
    public int amountCollected;
    public Sprite starCollected;
    public GameObject[] starsUI;
    public GameObject[] starsPickup;
    public bool resetAllPlayerPref;

    private string currentLevelStars;
    private bool starsActive;
    

    void Start()
    {
        if(resetAllPlayerPref){
            PlayerPrefs.DeleteAll();
        }
        currentLevelStars = "StarsCollected" + SceneManager.GetActiveScene().buildIndex;

        // Temporär, ska egentligen sättas första gången leveln laddas och endast en gång.
        //PlayerPrefs.SetInt(currentLevelStars, 0);
        

        for (int i = 0; i <= PlayerPrefs.GetInt(currentLevelStars); i++)
        {
            if(starsPickup[i].GetComponent<PickupStar>().IsCollected()){
                starsPickup[i].SetActive(false);
            }
            
        }
        
        
    }

    private void Update()
    {
        amountCollected = PlayerPrefs.GetInt("StarsCollected");
        
        for (int i = 0; i < starsPickup.Length; i++)
        {
            if(starsPickup[i].GetComponent<PickupStar>().IsCollected()){
                starsUI[i].GetComponent<Image>().sprite = starCollected;
            }
        }
    }
}
