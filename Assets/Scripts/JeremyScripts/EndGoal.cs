using UnityEngine;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    [SerializeField] GameObject scoreScreen;
    public GameObject starUI;
    public GameObject[] starsScoreScreen;

    private GameObject joystickArea;
    private GameObject player;
    private GameObject[] starsPickup;
    private Sprite starCollected;
    private int amountCollected;
    

    void Start()
    {
        player = GameObject.Find("Character");
        joystickArea = GameObject.Find("JoystickArea");
        starCollected = scoreScreen.GetComponent<StarHandler>().starCollected;
        starsPickup = scoreScreen.GetComponent<StarHandler>().starsPickup;
        
        scoreScreen.transform.localScale = Vector2.zero;
    }

    public void OpenScoreScreen()
    {
        if(joystickArea != null) { 
            joystickArea.SetActive(false);
        }

        // Fryser spelarkontrollerna och stoppar spelarens velocity.
        player.GetComponent<MovePlayer>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        for (int i = 0; i < starsPickup.Length; i++){
            if(starsPickup[i].GetComponent<PickupStar>().IsCollected()){
                amountCollected++;
                //starsUI[i].GetComponent<Image>().sprite = starCollected;
            }
        }

        for (int i = 0; i < amountCollected; i++)
        {
            starsScoreScreen[i].GetComponent<Image>().sprite = starCollected;
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
            starUI.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            Pause.PauseGame();
            //PlayerPrefs.SetInt("LevelsUnlocked", levelToUnlock);
        }
    }
}