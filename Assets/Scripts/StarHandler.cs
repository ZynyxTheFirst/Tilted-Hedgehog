using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarHandler : MonoBehaviour
{
    public int amountCollected;
    public Sprite starCollected;
    public GameObject[] stars;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("StarsCollected", 0);
        
    }

    private void Update()
    {
        amountCollected = PlayerPrefs.GetInt("StarsCollected");
        PlayerPrefs.SetInt("StarsCollected", amountCollected);
        for (int i = 0; i < amountCollected; i++)
        {
            stars[i].GetComponent<Image>().sprite = starCollected;
        }
    }
}
