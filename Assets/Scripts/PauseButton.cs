using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Image pauseScreen;
    private bool menuOpen = false;
    void Start()
    {
        menuOpen = false;
        pauseScreen.transform.localScale = Vector2.zero;
    }
    
    public void TogglePauseMenu()
    {
        if (GameManager.isGameOver || Pause.isPaused)
            return;
        if (!menuOpen)
        {
            menuOpen=true;
            OpenPauseScreen();
        }
        else
        {
            menuOpen=false;
            ClosePauseScreen();
        }
    }

    private void OpenPauseScreen()
    {
        pauseScreen.transform.LeanScale(Vector2.one, 0.5f);
    }

    private void ClosePauseScreen()
    {
        pauseScreen.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}