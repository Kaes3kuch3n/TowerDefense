using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    
    public static bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver) return;
        
        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;

        PlayerStats.rounds--;

        if (FastForward.isFastForwarded)
            FastForward.Toggle();

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        if (FastForward.isFastForwarded)
            FastForward.Toggle();
        completeLevelUI.SetActive(true);
    }
}
