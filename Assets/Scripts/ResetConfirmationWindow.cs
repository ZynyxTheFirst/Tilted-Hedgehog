using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetConfirmationWindow : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;

    public Text areYouSure;

    public GameObject resetConfirmationPanel;


    void Start()
    {
        resetConfirmationPanel.SetActive(false);
    }

    public void ShowResetConfirmation()
    {
        resetConfirmationPanel.gameObject.SetActive(true);
    }

    public void ConfirmReset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void CancelReset()
    {
        resetConfirmationPanel.SetActive(false);
    }

}
