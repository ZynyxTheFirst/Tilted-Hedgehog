using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllPlayerPrefs : MonoBehaviour
{
    public void PlayerPrefsClear()
    {
        PlayerPrefs.DeleteAll();
    }
}
