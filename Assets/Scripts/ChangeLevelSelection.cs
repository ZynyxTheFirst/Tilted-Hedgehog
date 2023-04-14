using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelSelection : MonoBehaviour
{
    public GameObject grid1;
    public GameObject grid2;

    public Button leftButton;
    public Button rightButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonStatus();
    }

    public void ShowNextLevels(){
        grid1.SetActive(false);
        grid2.SetActive(true);
    }

    public void ShowPreviousLevels(){
        grid1.SetActive(true);
        grid2.SetActive(false);
    }

    private void buttonStatus(){
        if (grid1.activeInHierarchy)
        {
            leftButton.interactable = false;
        }

        else if (grid2.activeInHierarchy)
        {
            leftButton.interactable = true;
        }

        if (grid1.activeInHierarchy)
        {
            rightButton.interactable = true;
        }

        else if (grid2.activeInHierarchy)
        {
            rightButton.interactable = false;
        }
    }
}
