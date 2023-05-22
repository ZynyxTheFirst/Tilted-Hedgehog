using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{ 
    public void OpenScene(int level)
    {
        //SceneManager.LoadScene("level " + level.ToString());
        SceneManager.LoadScene(level);
    }

    public void OpenScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
