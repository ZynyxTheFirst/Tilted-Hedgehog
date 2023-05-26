using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    [SerializeField] GameObject scoreScreen;

    [SerializeField] GameObject joyStick;
    
    public GameObject starUI;
    public GameObject[] starsScoreScreen;
    public AudioSource audioSource;
    public string levelIdentifier;

    private GameObject joystickArea;
    private VictoryScreen victoryScreen;
    private GameObject player;
    private GameObject starManager;
    private Scorehandler SCR;
    private Animator playerAnimator;
    private GameObject[] starsPickup;
    private Sprite starCollected;
    
    private int amountCollected;
    private bool animatorOff = true;
    
    private void Update() {
        
        if(SceneTransition.centerReached && animatorOff){
            GetComponent<Animator>().enabled = true;
            animatorOff = false;
        }
        
    }

    void Start()
    {
        // Detta är för samlade stjärnor för individuell level.
        levelIdentifier = SceneManager.GetActiveScene().name;
        int starsCollected = PlayerPrefs.GetInt(levelIdentifier + "StarsCollected", 0);
        starManager = GameObject.Find("StarManager");


        SCR = gameObject.GetComponent<Scorehandler>();
        victoryScreen = GameObject.Find("VictoryScreen").GetComponent<VictoryScreen>();
        player = GameObject.Find("Character");
        joystickArea = GameObject.Find("JoystickArea");
        starCollected = scoreScreen.GetComponent<StarHandler>().starCollected;
        starsPickup = scoreScreen.GetComponent<StarHandler>().starsPickup;
        playerAnimator = player.GetComponent<Animator>();

        scoreScreen.transform.localScale = Vector2.zero;
    }

    /*
    public void OpenScoreScreen()
    {
        
        if(joystickArea != null) { 
            joystickArea.SetActive(false);
        }

        // Fryser spelarkontrollerna och stoppar spelarens velocity.
        player.GetComponent<MovePlayer>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Sparar det aktuella antalet stjärnor när score screen öppnas.
        PlayerPrefs.SetInt(starManager.GetComponent<StarManager>().GetLevelIdentifier() + "StarsCollected", starManager.GetComponent<StarManager>().GetStarsCollected());
        PlayerPrefs.Save();
        
        for (int i = 0; i < starsPickup.Length; i++){
            if(starsPickup[i].GetComponent<PickupStar>().IsCollected()){
                amountCollected++;
            }
        }
        for (int i = 0; i < amountCollected; i++)
        {
            starsScoreScreen[i].GetComponent<Image>().sprite = starCollected;
            SCR.FoundStar();
        }


        scoreScreen.transform.LeanScale(Vector2.one, 0.5f);
    }
    */

    public void CloseScoreScreen()
    {
        scoreScreen.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            
            audioSource.Play();
            victoryScreen.OpenScoreScreen();
            starUI.SetActive(true);
            joyStick.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = false;
            playerAnimator.SetBool("isMoving", false);
            
            Pause.PauseGame();
            gameObject.SetActive(false);
            //PlayerPrefs.SetInt("LevelsUnlocked", levelToUnlock);
        }
    }
}
