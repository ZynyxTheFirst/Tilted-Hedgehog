using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    // Add scenes in inspector
    //[SerializeField] private List<Scene> _sceneList;

    public void LoadNextLevel(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int sceneAmount = SceneManager.sceneCountInBuildSettings;

        if (currentScene < sceneAmount-1){
            SceneManager.LoadScene(currentScene + 1);
        }
        else{
            print("Its last scene");
        }
    }
}
