using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorehandler : MonoBehaviour
{
    public int starScore;
    public TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = "" + starScore;
    }

    public void FoundStar()
    {
        starScore = starScore + 1;
    }
}
