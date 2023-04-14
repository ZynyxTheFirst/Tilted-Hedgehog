using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelSelection : MonoBehaviour
{
    public GameObject grid1;
    public GameObject grid2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNextLevels(){
        grid1.SetActive(false);
        grid2.SetActive(true);
    }

    public void ShowPreviousLevels(){
        grid1.SetActive(true);
        grid2.SetActive(false);
    }

}
