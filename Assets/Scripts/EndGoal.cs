using UnityEngine;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    public Image scoreScreen;
    public GameObject canvas;


    private void Awake()
    {
        canvas.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

        scoreScreen.transform.localScale = Vector2.zero;
    }

    public void Open()
    {   
        scoreScreen.transform.LeanScale(Vector2.one, 0.5f);
    }

    public void Close()
    {
        scoreScreen.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Open();
            GetComponent<SpriteRenderer>().enabled = false;
            Pause.PauseGame();
        }
    }
}
