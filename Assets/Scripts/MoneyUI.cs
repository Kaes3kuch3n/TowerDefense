using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    private Text moneyText;

    private void Awake()
    {
        moneyText = this.GetComponent<Text>();
    }

    private void Update()
    {
        moneyText.text = "$ " + PlayerStats.money.ToString();
    }
}
