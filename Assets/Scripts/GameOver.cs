using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    
    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";
        
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
