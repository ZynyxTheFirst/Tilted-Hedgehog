using UnityEngine;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    [SerializeField] GameObject scoreScreen;
    // [SerializeField] int levelToUnlock = 0;
    private GameObject[] starsUI;
    private GameObject[] starsPickup;
    private Sprite starCollected;

    void Start()
    {
        for(int i = 0; i < 3; i++){
            starsUI = scoreScreen.GetComponent<StarHandler>().starsUI;
        }
        starCollected = scoreScreen.GetComponent<StarHandler>().starCollected;
        starsPickup = scoreScreen.GetComponent<StarHandler>().starsPickup;
        
        scoreScreen.transform.localScale = Vector2.zero;
    }

    public void OpenScoreScreen()
    {   
        for(int i = 0; i < starsPickup.Length; i++){
            if(starsPickup[i].GetComponent<PickupStar>().IsCollected()){
                starsUI[i].GetComponent<Image>().sprite = starCollected;
            }
        }
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
            //PlayerPrefs.SetInt("LevelsUnlocked", levelToUnlock);
        }
    }
}
