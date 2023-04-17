using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    public Image scoreScreen;

    // Start is called before the first frame update
    void Start()
    {
        scoreScreen.transform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        scoreScreen.transform.LeanScale(Vector2.one, 0.8f);
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
