using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowResetWindow : MonoBehaviour
{
    public GameObject resetPanel;

    public void ShowResetPanel()
    {
        resetPanel.SetActive(true);  
    }

    public void ExitResetPanel()
    {
        resetPanel.SetActive(false);

    }

    public void ResetConfirmed()
    {
        PlayerPrefs.DeleteAll();
        ExitResetPanel();
        SceneManager.LoadScene(0);
    }


}
