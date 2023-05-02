using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image GOScreen;
    [SerializeField] GameObject canvas;
    public static bool isGameOver = false;

    private void Awake()
    {
        isGameOver = false;
        canvas.SetActive(true);
    }

    void Start()
    {
        GOScreen.transform.localScale = Vector2.zero;
    }

    private void Update()
    {
        if (isGameOver)
        {
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
