using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("StarScore", 0);
        scoreText.text = "Stars: " + score;

    }

}