using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused;

    private void Start()
    {
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Debug.Log("Toggled pause");
    }

    public static void PauseGame()
    {
        isPaused=true;
        Debug.Log("Paused game");
    }

    public static void ResumeGame()
    {
        isPaused=false;
        Debug.Log("Resumed game");
    }
}
