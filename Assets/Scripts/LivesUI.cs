using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    private Text livesText;

    private void Awake()
    {
        livesText = this.GetComponent<Text>();
    }

    private void Update()
    {
        if (GameManager.gameIsOver)
        {
            livesText.text = "0 LIVES";
        } else
        {
            livesText.text = PlayerStats.lives.ToString() + " LIVES";
        }
    }
}
