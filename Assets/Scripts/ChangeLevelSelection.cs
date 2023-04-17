using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelSelection : MonoBehaviour
{
    public GameObject[] grids = new GameObject[3];

    public Button leftButton;
    public Button rightButton;

    private int currentPage;

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNextLevels(){
        foreach (var v in grids)
        {
            v.SetActive(false);
        }
        grids[currentPage].SetActive(true);
    }

    public void Back()
    {
        if(currentPage == 1)
        {
            leftButton.interactable = false;
            currentPage -= 1;
            ShowNextLevels();
        }
        else if(grids.Length == currentPage+1)
        {
            rightButton.interactable = true;
            currentPage -= 1;
            ShowNextLevels();
        }
    }

    public void Forward()
    {
        if (currentPage == grids.Length-2)
        {
            rightButton.interactable = false;
            currentPage += 1;
            ShowNextLevels();
        }
        else if (currentPage == 0)
        {
            leftButton.interactable = true;
            currentPage += 1;
            ShowNextLevels();
        }
    }


}
