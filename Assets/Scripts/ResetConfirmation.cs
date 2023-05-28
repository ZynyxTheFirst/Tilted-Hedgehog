using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetConfirmation : MonoBehaviour
{
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
