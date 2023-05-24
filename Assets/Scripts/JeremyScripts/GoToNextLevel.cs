using UnityEngine.SceneManagement;


public static class GoToNextLevel
{
    // Add scenes in inspector
    //[SerializeField] private List<Scene> _sceneList;

    public static void LoadNextLevel(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int sceneAmount = SceneManager.sceneCountInBuildSettings;

        if (currentScene < sceneAmount-1){
            SceneManager.LoadScene(currentScene + 1);
        }
        else{
            debugScreenLogger.print("Last scene");
        }
    }
}
