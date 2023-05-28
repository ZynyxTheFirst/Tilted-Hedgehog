using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image GOScreen;
    [SerializeField] GameObject canvas;
    private GameObject pauseButton;
    public static bool isGameOver = false;

    private void Awake()
    {
        isGameOver = false;
        canvas.SetActive(true);
        Time.timeScale = 1f;
    }

    void Start()
    {
        
        pauseButton = GameObject.Find("PauseButton"); // Byt inte namn på PauseButton under ScoreUICanvas för då funkar inte detta.
        if(GOScreen != null)
        {
            GOScreen.transform.localScale = Vector2.zero;
        }
        
    }

    private void Update()
    {
        if (isGameOver)
        {
            pauseButton.SetActive(false);
            OpenGOScreen();
            Pause.PauseGame();
            isGameOver = false;
        }
    }

    public static void GameOver()
    {
        isGameOver=true;
    }

    public void OpenGOScreen()
    {
        GOScreen.transform.LeanScale(Vector2.one, 0.5f);
    }

    public void CloseGOScreen()
    {
        GOScreen.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}
