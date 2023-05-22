using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorehandler : MonoBehaviour
{
    private int starScore;
    public TMP_Text scoreText;
    private void Start()
    {
        starScore = PlayerPrefs.GetInt("StarScore");
    }
    private void Update()
    {
        scoreText.text = "" + starScore;
    }

    public void FoundStar()
    {
        starScore = starScore + 1;
        PlayerPrefs.SetInt("StarScore", starScore);
    }
}
