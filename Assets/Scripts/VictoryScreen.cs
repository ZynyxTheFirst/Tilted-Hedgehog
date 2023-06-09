using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public Image starImageLeft;
    public Image starImageCenter;
    public Image starImageRight;
    public Sprite collectedStarSprite;
    public Sprite defaultStarSprite;
    public StarManager starManager;
    public GameObject scoreScreen;

    private GameObject joystickArea;
    private GameObject player;
    //private GameObject[] starsPickup;
    private int currentStarsCollected;
    private int starsCollected;
    

    private string levelIdentifier; // Unik identifierare för leveln.

    private void Start()
    {

        joystickArea = GameObject.Find("joystickArea");
        player = GameObject.Find("Character");

        levelIdentifier = SceneManager.GetActiveScene().name;
        currentStarsCollected = PlayerPrefs.GetInt(levelIdentifier + "CurrentStarsCollected", 0);

        PlayerPrefs.SetInt(levelIdentifier + "StarsCollected", 0);
        //int starsCollected = PlayerPrefs.GetInt(levelIdentifier + "StarsCollected", 0);

        // Debugging
        //int totalStarsCollected = PlayerPrefs.GetInt("TotalStarsCollected", 0);
        //Debug.Log("TotalStars Start: " + totalStarsCollected);
        //Debug.Log("CurrentStars Start: " + currentStarsCollected);
        //Debug.Log("StarsCollected Start: " + starsCollected);
    }

    public void UpdateStarSprites(int starsCollected)
    {
        starImageLeft.sprite = (starsCollected >= 1 && starImageLeft.sprite) ? collectedStarSprite : defaultStarSprite;
        starImageCenter.sprite = (starsCollected >= 2 && starImageCenter.sprite) ? collectedStarSprite : defaultStarSprite;
        starImageRight.sprite = (starsCollected >= 3 && starImageRight.sprite) ? collectedStarSprite : defaultStarSprite;
    
    }

    public void OpenScoreScreen()
    {
        if (joystickArea != null)
        {
            joystickArea.SetActive(false);
        }

        // Fryser spelarkontrollerna och stoppar spelarens velocity.
        player.GetComponent<MovePlayer>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        /*
        // Sparar det aktuella antalet stjärnor när score screen öppnas.
        PlayerPrefs.SetInt(starManager.GetComponent<StarManager>().GetLevelIdentifier() + "StarsCollected", starManager.GetComponent<StarManager>().GetStarsCollected());
        PlayerPrefs.Save();
        */

        /*
        // Öka antalet stjärnor för den specifika leveln.
        int starsCollected = PlayerPrefs.GetInt(levelIdentifier + "StarsCollected", 0);
        starsCollected++;
        PlayerPrefs.SetInt(levelIdentifier + "StarsCollected", starsCollected);
        PlayerPrefs.Save();
        */

        starsCollected = PlayerPrefs.GetInt(levelIdentifier + "StarsCollected", 0);
        if (starsCollected > currentStarsCollected)
        {
            currentStarsCollected = starsCollected;
            PlayerPrefs.SetInt(levelIdentifier + "CurrentStarsCollected", currentStarsCollected);

        }

        UpdateStarSprites(currentStarsCollected);
        
        // Öka det totala antalet stjärnor.
        int totalStarsCollected = PlayerPrefs.GetInt("TotalStarsCollected", 0);
        totalStarsCollected += starsCollected;
        PlayerPrefs.SetInt("TotalStarsCollected", totalStarsCollected);
        PlayerPrefs.Save();

        
        /*
        // Debugging
        Debug.Log("CurrentStars Start: " + currentStarsCollected);
        Debug.Log("StarsCollected End: " + starsCollected);
        Debug.Log("TotalStars End: " + totalStarsCollected);
        */
        


        /*
        for (int i = 0; i < starsPickup.Length; i++)
        {
            if (starsPickup[i].GetComponent<PickupStar>().IsCollected())
            {
                amountCollected++;
            }
        }
        for (int i = 0; i < amountCollected; i++)
        {
            starsScoreScreen[i].GetComponent<Image>().sprite = starCollected;
            SCR.FoundStar();
        }
        */

        scoreScreen.transform.LeanScale(Vector2.one, 0.5f);
    }
}
