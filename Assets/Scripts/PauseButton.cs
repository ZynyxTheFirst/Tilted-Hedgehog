using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Image pauseScreen;

    [SerializeField] GameObject joyStick;
    [SerializeField] GameObject starUI;
    private AudioSource[] audioSources;
    private bool menuOpen = false;

    private void Awake()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        Time.timeScale = 1f;
        menuOpen = false;
        pauseScreen.transform.localScale = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (pauseScreen.transform.localScale.x == 1 && pauseScreen.transform.localScale.y == 1 && menuOpen == true)
        {
            Time.timeScale = 0f;
        }
    }

    public void TogglePauseMenu()
    {
        if (GameManager.isGameOver || Pause.isPaused)
            return;
        // Pausa spelet.
        if (!menuOpen)
        {
            foreach (AudioSource audioSource in audioSources)
            {
                if (audioSource != null && !audioSource.CompareTag("Music"))
                {
                    audioSource.Pause();
                }
                
            }
            menuOpen =true;
            joyStick.SetActive(false);
            starUI.SetActive(true);
            OpenPauseScreen();
        }
        // Unpausa spelet.
        else
        {
            menuOpen=false;
            joyStick.SetActive(true);
            starUI.SetActive(false);
            ClosePauseScreen();
            foreach (AudioSource audioSource in audioSources)
            {
                if(audioSource != null && !audioSource.CompareTag("Music"))
                {
                    audioSource.UnPause();
                }
                
            }
        }
    }

    private void OpenPauseScreen()
    {
        pauseScreen.transform.LeanScale(Vector2.one, 0.1f);
    }

    private void ClosePauseScreen()
    {
        pauseScreen.transform.LeanScale(Vector2.zero, 0.1f).setEaseInBack();
        Time.timeScale = 1f;
    }
}
