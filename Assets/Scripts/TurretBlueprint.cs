using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint {

    public string name;

    public GameObject prefab;
    public GameObject previewPrefab;

    public int price;
    public Text priceLabel;

    public bool hasUpgrade;
    public GameObject upgradedPrefab;
    public int upgradePrice;

    public int GetSellPrice()
    {
        return price / 2;
    }
}
