using UnityEngine;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    [SerializeField] Image scoreScreen;

    void Start()
    {
        scoreScreen.transform.localScale = Vector2.zero;
    }

    public void OpenScoreScreen()
    {   
        scoreScreen.transform.LeanScale(Vector2.one, 0.5f);
    }

    public void CloseScoreScreen()
    {
        scoreScreen.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            OpenScoreScreen();
            GetComponent<SpriteRenderer>().enabled = false;
            Pause.PauseGame();
            PlayerPrefs.SetInt("LevelsUnlocked", 2);
        }
    }
}
