using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {

        if (FindObjectsOfType<MainMenuMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
        //SceneManager.sceneUnloaded += OnSceneUnloaded;

        // Starta musiken.
        //audioSource.Play();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Kontrollera om den laddade scenen kräver att musik spelas
        if (scene.name == "Main Menu" || scene.name == "Level Select")
        {
            // Fortsätt spela musiken om den var pausad
            audioSource.UnPause();
        }
        else
        {
            // Stoppa musiken.
            audioSource.Pause();
        }
    }

    private void OnSceneUnloaded(Scene scene)
    {
        // Pausa musiken när du går över till en annan scen
        //audioSource.Pause();
    }
}
