using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Image pauseScreen;

    [SerializeField] GameObject joyStick;
    [SerializeField] GameObject starUI;
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
            joyStick.SetActive(false);
            starUI.SetActive(true);
            OpenPauseScreen();
        }
        else
        {
            menuOpen=false;
            joyStick.SetActive(true);
            starUI.SetActive(false);
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
