using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScreenText : MonoBehaviour
{
    [SerializeField] GameObject levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.GetComponent<TextMeshProUGUI>().text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }
}
