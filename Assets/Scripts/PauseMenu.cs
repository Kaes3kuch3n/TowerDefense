using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    private void Update()
    {
        if (Input.GetButtonDown("Pause") || Input.GetButtonDown("Cancel"))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        } else if (FastForward.isFastForwarded)
        {
            Time.timeScale = FastForward.forwardSpeed;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        if (FastForward.isFastForwarded) 
            FastForward.Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
